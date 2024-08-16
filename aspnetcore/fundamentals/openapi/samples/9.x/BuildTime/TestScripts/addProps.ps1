# Adds OpenApiDocumentsDirectory to MyOpenApiTest.csproj
# builds
$env:ProgramName = "MyOpenApiTest"
$env:Project = "$($env:ProgramName).csproj"
$xml = [xml](Get-Content $env:Project)

$newPropertyGroup = $xml.CreateElement("PropertyGroup")
$newElement = $xml.CreateElement("OpenApiDocumentsDirectory")
$newElement.InnerText = "./"
$newPropertyGroup.AppendChild($newElement)

# Append to the root 'Project' element
$xml.SelectSingleNode("/Project").AppendChild($newPropertyGroup) 

$xml.Save($env:Project)
$xml.OuterXml 
dotnet build