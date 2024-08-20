# Creates a Web API project, adds ApiDescription.Server
# and displays first few lines
cls
$ProgramName = "MyOpenApiTest"
# remove build from last run
if (Test-Path $ProgramName) {
    Write-Host "Removing existing '$ProgramName' directory..."
    Remove-Item $ProgramName -Recurse -Force 
} 
$Project = "$ProgramName.csproj"
Write-Output $ProgramName
dotnet new webapi -n $ProgramName
Set-Location $ProgramName
dotnet add package Microsoft.Extensions.ApiDescription.Server --version 9.0.0-*
dotnet build
# show output is in the obj directory
Select-String -Path "obj\$ProgramName.json" -Pattern "." | Select-Object -First 5

# Add property and test
$xml = [xml](Get-Content $Project)
$newPropGrp1 = $xml.CreateElement("PropertyGroup")
$newElement = $xml.CreateElement("OpenApiDocumentsDirectory")
$newElement.InnerText = "./"
$newPropGrp1.AppendChild($newElement)
$xml.Project.AppendChild($newPropGrp1)
$xml.OuterXml | Set-Content -Path $Project

#$xml.OuterXml # displays the entire file
# 
dotnet build
cd ..
