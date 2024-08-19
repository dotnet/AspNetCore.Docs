# Creates a Web API project, adds ApiDescription.Server
# and displays first few lines
$ProgramName = "MyOpenApiTest"
$Project = "$ProgramName.csproj"
# $ProgramName
dotnet new webapi -n $ProgramName
Set-Location $ProgramName
dotnet add package Microsoft.Extensions.ApiDescription.Server --version 9.0.0-*
dotnet build
Select-String -Path "obj\$ProgramName.json" -Pattern "." | Select-Object -First 5

# Add property and test
$xml = [xml](Get-Content $Project) 
$newPropertyGroup = $xml.CreateElement("PropertyGroup")
$newElement = $xml.CreateElement("OpenApiDocumentsDirectory")
$newElement.InnerText = "./"
$newPropertyGroup.AppendChild($newElement)
$xml.Project.AppendChild($newPropertyGroup)
$xml.Save($Project) 
$xml.OuterXml | Set-Content -Path $env:Project
$xml.OuterXml
#verify change is saved
$xml2 = [xml](Get-Content $env:Project)
$xml2.OuterXml
dotnet build
cd ..
# Remove-Item -Recurse -Force $ProgramName
