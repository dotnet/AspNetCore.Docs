<#

.SYNOPSIS
    Invokes dotnet build on the samples sln and project files.

.DESCRIPTION
    Invokes dotnet build on the samples sln and project files.

.PARAMETER RepoRootDir
    The directory of the repository files on the local machine.

.PARAMETER PullRequest
    The pull requst to process. If 0 or not passed, processes the whole repo

.PARAMETER RepoOwner
    The name of the repository owner.
    
.PARAMETER RepoName
    The name of the repository.

.PARAMETER RangeStart
    A range of results to process.

.PARAMETER RangeEnd
    A range of results to process.

.INPUTS
    None

.OUTPUTS
    None

.NOTES
    Version:        1.4
    Author:         adegeo@microsoft.com
    Creation Date:  12/11/2020
    Purpose/Change: Add support for config file. Select distinct on project files.
#>

[CmdletBinding()]
Param(
    [Parameter(Mandatory = $true, ValueFromPipeline = $false)]
    [System.String] $RepoRootDir = $env:RepoRootDir,

    [Parameter(Mandatory = $false, ValueFromPipeline = $false)]
    [System.Int64] $PullRequest = 0,

    [Parameter(Mandatory = $false, ValueFromPipeline = $false)]
    [System.String] $RepoOwner = "",

    [Parameter(Mandatory = $false, ValueFromPipeline = $false)]
    [System.String] $RepoName = "",

    [Parameter(Mandatory = $false, ValueFromPipeline = $false)]
    [System.Int32] $RangeStart = $env:rangestart,

    [Parameter(Mandatory = $false, ValueFromPipeline = $false)]
    [System.Int32] $RangeEnd = $env:rangeend
)

$Global:statusOutput = @()

Write-Host "Gathering solutions and projects..."

if ($PullRequest -ne 0) {
    Write-Host "Running `"LocateProjects `"$RepoRootDir`" --pullrequest $PullRequest --owner $RepoOwner --repo $RepoName`""
    $output = Invoke-Expression "LocateProjects `"$RepoRootDir`" --pullrequest $PullRequest --owner $RepoOwner --repo $RepoName"
}
else {
    Write-Host "Running `"LocateProjects `"$RepoRootDir`""
    $output = Invoke-Expression "LocateProjects `"$RepoRootDir`""
}

if ($LASTEXITCODE -ne 0)
{
    $output
    throw "Error on running LocateProjects"
}

function New-Result($inputFile, $projectFile, $exitcode, $outputText)
{
    $info = @{}
    
    $info.InputFile = $inputFile
    $info.ProjectFile = $projectFile
    $info.ExitCode = $exitcode
    $info.Output = $outputText

    $object = New-Object -TypeName PSObject -Prop $info
    $Global:statusOutput += $object
}

$workingSet = $output

if (($RangeStart -ne 0) -and ($RangeEnd -ne 0)){
    $workingSet = $output[$RangeStart..$RangeEnd]
}

# Log working set items prior to filtering
$workingSet | Write-Host

# Remove duplicated projects
$projects = @()
$workingSetTemp = @()

foreach ($item in $workingSet) {
    $data = $item.Split('|')
    if ($projects.Contains($data[2].Trim())) {
        continue
    }
    if ($data[2].Trim() -ne "") {
        $projects += $data[2].Trim()
    }
    $workingSetTemp += $item
}

$workingSet = $workingSetTemp

# Process working set
$counter = 1
$length = $workingSet.Count
$thisExitCode = 0

$ErrorActionPreference = "Continue"

foreach ($item in $workingSet) {
    try {
        Write-Host "$counter/$length :: $Item"
                
        $data = $item.Split('|')

        # Project found, build it
        if ([int]$data[0] -eq 0) {
            $projectFile = Resolve-Path "$RepoRootDir\$($data[2])"
            $configFile = [System.IO.Path]::Combine([System.IO.Path]::GetDirectoryName($projectFile), "snippets.5000.json")
            
            # Create the default build command
            "dotnet build `"$projectFile`"" | Out-File ".\run.bat"

            # Check for config file
            if ([System.IO.File]::Exists($configFile) -eq $true) {
                Write-Host "- Config file found"

                $settings = $configFile | Get-ChildItem | Get-Content | ConvertFrom-Json

                if ($settings.host -eq "visualstudio") {
                    Write-Host "- Using visual studio as build host"

                    # Create the visual studio build command
                    "CALL `"C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\Common7\Tools\VsDevCmd.bat`"`n" +
                    "msbuild.exe `"$projectFile`" -restore:True" `
                    | Out-File ".\run.bat"
                }
                elseif ($settings.host -eq "custom") {
                  Write-Host "- Using custom build host: $($settings.command)"

                  $ExecutionContext.InvokeCommand.ExpandString($settings.command) | Out-File ".\run.bat"
                }
                elseif ($settings.host -eq "dotnet") {
                  Write-Host "- Using dotnet build host"

                  "dotnet build `"$projectFile`"" | Out-File ".\run.bat"
                }
                else {
                  throw "snippets.5000.json file isn't valid."
                }
            }

            $result = Invoke-Expression ".\run.bat" | Out-String
            $thisExitCode = 0

            if ($LASTEXITCODE -ne 0) {
                $thisExitCode = 4
            }
            
            New-Result $data[1] $projectFile $thisExitCode $result
        }

        # No project found
        elseif ([int]$data[0] -eq 1) {
            New-Result $data[1] "" 1 "😵 Project missing. A project (and optionally a solution file) must be in this directory or one of the parent directories to validate and build this code."

            $thisExitCode = 1
        }

        # Too many projects found
        elseif ([int]$data[0] -eq 2) {
            New-Result $data[1] $data[2] 2 "😕 Too many projects found. A single project or solution must existing in this directory or one of the parent directories."

            $thisExitCode = 2
        }

        # Solution found, but no project
        elseif ([int]$data[0] -eq 3) {
            New-Result $data[1] $data[2] 2 "😲 Solution found, but missing project. A project is required to compile this code."
            $thisExitCode = 3
        }
    }
    catch {
        New-Result $data[1] $projectFile 1000 "ERROR: $($_.Exception)"
        $thisExitCode = 4
        Write-Host $_.Exception.Message -Foreground "Red"
        Write-Host $_.ScriptStackTrace -Foreground "DarkGray"
    }

    $counter++
}

$resultItems = $Global:statusOutput | Select-Object InputFile, ProjectFile, ExitCode, Output

# Add our output type
$typeResult = @"
public class ResultItem
{
    public string ProjectFile;
    public string InputFile;
    public int ExitCode;
    public string BuildOutput;
    public MSBuildError[] Errors;
    public int ErrorCount;

    public class MSBuildError
    {
        public string Line;
        public string Error;
    }
}
"@
Add-Type $typeResult

$transformedItems = $resultItems | ForEach-Object { New-Object ResultItem -Property @{
                                                    ProjectFile = $_.ProjectFile.Path;
                                                    InputFile = $_.InputFile;
                                                    ExitCode = $_.ExitCode;
                                                    BuildOutput = $_.Output;
                                                    Errors = @();
                                                    ErrorCount = 0}
                                                  }
         
# Transform the build output to break it down into MSBuild result entries
foreach ($item in $transformedItems) {
    $list = @()

    # Clean
    if ($item.ExitCode -eq 0) {
        #$list += New-Object -TypeName "ResultItem+MSBuildError" -Property @{ Line = $item.BuildOutput; Error = $item.BuildOutput }
    }
    # No project found
    # Too many projects found
    # Solution found, but no project
    elseif ($item.ExitCode -ne 4) {
        $list += New-Object -TypeName "ResultItem+MSBuildError" -Property @{ Line = $item.BuildOutput; Error = $item.BuildOutput }
        $item.ErrorCount = 1
    }
    else {
        $errorInfo = $item.BuildOutput -Split [System.Environment]::NewLine |
                                         Select-String ": (?:Solution file error|error) ([^:]*)" | `
                                         Select-Object Line -ExpandProperty Matches | `
                                         Select-Object Line, Groups | `
                                         Sort-Object Line | Get-Unique -AsString
        $item.ErrorCount = $errorInfo.Count
        foreach ($err in $errorInfo) {
            $list += New-Object -TypeName "ResultItem+MSBuildError" -Property @{ Line = $err.Line; Error = $err.Groups[1].Value }
        }

        # Error count of 0 here means that no error was detected from build results, but there was still a failure of some kind
        if ($item.ErrorCount -eq 0) {
            $list += New-Object -TypeName "ResultItem+MSBuildError" -Property @{ Line = "Unknown error occurred. Check log and build output."; Error = "4" }
            $item.ErrorCount = 1
        }
    }

    $item.Errors = $list
    
}

$transformedItems | ConvertTo-Json -Depth 3 | Out-File 'output.json'

exit 0


# Sample snippets.5000.json file
<#
{
    "host": "visualstudio"
}

#>
