<#

.SYNOPSIS
    Reads the output.json file and outputs status to GitHub Actions

.DESCRIPTION
    Reads the output.json file and outputs status to GitHub Actions

.INPUTS
    None

.OUTPUTS
    None

.NOTES
    Version:        1.1
    Author:         adegeo@microsoft.com
    Creation Date:  06/24/2020
    Purpose/Change: Change reporting items
#>

[CmdletBinding()]
Param(
)

$json = Get-Content output.json | ConvertFrom-Json

$errors = $json | Where-Object ErrorCount -ne 0 | Select-Object InputFile -ExpandProperty Errors | Select-Object InputFile, Error, Line

if ($errors.Count -eq 0) {
    Write-Host "All builds passed"
    exit 0
}

Write-Host "Total errors: $($errors.Count)"

foreach ($er in $errors) {

    $lineColMatch = $er.Line | Select-String "(^.*)\((\d*),(\d*)\)" | Select-Object -ExpandProperty Matches | Select-Object -ExpandProperty Groups
    $errorFile = $er.InputFile
    $errorLineNumber = 0
    $errorColNumber = 0

    if ($lineColMatch.Count -eq 4) {
        $errorFile = $lineColMatch[1].Value.Replace("D:\a\docs\docs\", "").Replace("\", "/")
        $errorLineNumber = $lineColMatch[2].Value
        $errorColNumber = $lineColMatch[3].Value
    }

    Write-Host "::error file=$errorFile,line=$errorLineNumber,col=$errorColNumber::$($er.Line)"
}

exit 1
