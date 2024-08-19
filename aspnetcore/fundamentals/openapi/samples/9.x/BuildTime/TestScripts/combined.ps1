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

# Save the modified XML back to the original project file
$xml.Save($Project) 

# Verify the change is saved
$xml2 = [xml](Get-Content $Project)
$xml2.OuterXml 
dotnet build
cd ..
# Remove-Item -Recurse -Force $ProgramName
