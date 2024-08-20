# Creates a Web API project, adds ApiDescription.Server
cls
## any arg sets the Inner_text to ".."
if ($args.Count -gt 0) { 
    $Inner_text = ".."
} else {
    $Inner_text = "./" 
}

Write-Host "Inner_text is set to: $Inner_text, supply any arguement to use ../"

$ProgramName = "MyOpenApiTest"
# remove build from last run
$Project = "$ProgramName.csproj"

if (Test-Path $ProgramName) {
    Write-Host "Removing existing '$ProgramName' directory..."
    Remove-Item $ProgramName -Recurse -Force 
} 

if (Test-Path "$ProgramName.json") {
    Write-Host "Removing existing $ProgramName.json' file"
    Remove-Item $ProgramName -Recurse -Force 
} 

# Write-Output $ProgramName
dotnet new webapi -n $ProgramName
Set-Location $ProgramName
dotnet add package Microsoft.Extensions.ApiDescription.Server --version 9.0.0-*
dotnet build
# show output is in the obj directory
Select-String -Path "obj\$ProgramName.json" -Pattern "." | Select-Object -First 5

# Add property and test build with new property
$xml = [xml](Get-Content $Project)
$newPropGrp1 = $xml.CreateElement("PropertyGroup")

$newElement = $xml.CreateElement("OpenApiDocumentsDirectory")
$newElement.InnerText = $Inner_text
$newPropGrp1.AppendChild($newElement)

$xml.Project.AppendChild($newPropGrp1)
$xml.OuterXml | Set-Content -Path $Project

#$xml.OuterXml # displays the entire file
# 
dotnet build
if ($? -and $Inner_text -eq "..") {
   cd ..  # must move up or formatting bad
   Select-String -Path "$ProgramName.json" -Pattern "." | Select-Object -First 5
}
elseif ($?) {
    Select-String -Path "obj\$ProgramName.json" -Pattern "." | Select-Object -First 5
}
else{   ## build failed so move up directories to run the next command.
      cd .. 
}
