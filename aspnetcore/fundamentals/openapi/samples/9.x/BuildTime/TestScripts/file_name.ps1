# Creates a Web API project, adds ApiDescription.Server
cls
$ProgramName = "MyOpenApiTest"
# remove build from last run
if (Test-Path $ProgramName) {
    Write-Host "Removing existing '$ProgramName' directory..."
    Remove-Item $ProgramName -Recurse -Force 
} 
$Project = "$ProgramName.csproj"

dotnet new webapi -n $ProgramName
Set-Location $ProgramName
dotnet add package Microsoft.Extensions.ApiDescription.Server --version 9.0.0-* --source https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet9/nuget/v3/index.json

dotnet build

# Add property and test build with new property
$xml = [xml](Get-Content $Project)
$newPropGrp1 = $xml.CreateElement("PropertyGroup")

$newOpenApiName = "my-open-api"
$newElement = $xml.CreateElement("OpenApiGenerateDocumentsOptions")
$newElement.InnerText = "--file-name $newOpenApiName"
$newPropGrp1.AppendChild($newElement)

$xml.Project.AppendChild($newPropGrp1)
$xml.OuterXml | Set-Content -Path $Project

dotnet build

# Select-String -Path "obj\$newOpenApiName.json" -Pattern "." | Select-Object -First 5
$command
$command = "Select-String -Path 'obj/$newOpenApiName.json' -Pattern '.' | Select-Object -First 5"
$command | Invoke-Expression

$command | Invoke-Expression | Out-Host  # must run twice to see output
cd ..
