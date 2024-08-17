$env:Project = "$($env:PRONAM).csproj"
$newPropertyGroup = $xml.CreateElement("PropertyGroup")
$newElement = $xml.CreateElement("OpenApiDocumentsDirectory")
$newElement.InnerText = "./"
$newPropertyGroup.AppendChild($newElement)
$xml.Project.AppendChild($newPropertyGroup)
$xml.OuterXml | Set-Content -Path $env:Project
$xml.OuterXml
# verify change is saved
# $xml2 = [xml](Get-Content $env:Project)
# $xml2.OuterXml
dotnet build
