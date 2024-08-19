# Creates a Web API project, adds ApiDescription.Server
# and displays first few lines
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
Select-String -Path "obj\$ProgramName.json" -Pattern "." | Select-Object -First 5

# Add prob and test
$env:Project = $Project 
$newPropertyGroup = $xml.CreateElement("PropertyGroup")
$newElement = $xml.CreateElement("OpenApiDocumentsDirectory")
$newElement.InnerText = "./"
$newPropertyGroup.AppendChild($newElement)
$xml.Project.AppendChild($newPropertyGroup)
$xml.OuterXml | Set-Content -Path $env:Project
$xml.OuterXml
# verify change is saved
$xml2 = [xml](Get-Content $env:Project)
$xml2.OuterXml

# Remove-Item $Project -Force
# Rename-Item -Path ".csproj" -NewName $Project
dotnet build
cd ..
