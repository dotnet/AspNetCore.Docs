cls
$Inner_text = "."   # "./" fails on Windows, but works on Linux/Mac
$ProgramName = "MyOpenApiTest"
$Project = "$ProgramName.csproj"
$JsonFile = "$ProgramName.json"

if (Test-Path $ProgramName) {
    Write-Host "Removing existing '$ProgramName' directory..."
    Remove-Item $ProgramName -Recurse -Force 
} 

dotnet new webapi -n $ProgramName
Set-Location $ProgramName
dotnet add package Microsoft.Extensions.ApiDescription.Server --version 9.0.0-* --source https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet9/nuget/v3/index.json

dotnet build
# show output is in the obj directory
Select-String -Path "obj\$JsonFile" -Pattern "." | Select-Object -First 5

# Add property and test build with new property

$xml = [xml](Get-Content $Project)
$newPropGrp1 = $xml.CreateElement("PropertyGroup")

$newElement = $xml.CreateElement("OpenApiDocumentsDirectory")
$newElement.InnerText = $Inner_text
$newPropGrp1.AppendChild($newElement)

$xml.Project.AppendChild($newPropGrp1)
$xml.OuterXml | Set-Content -Path $Project

dotnet build

Select-String -Path "obj\$JsonFile" -Pattern "." | Select-Object -First 5
# must remove so project builds
 Remove-Item Program.cs 
cd .. 

