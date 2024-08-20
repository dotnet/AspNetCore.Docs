# Creates a Web API project, adds ApiDescription.Server
# Use one arguement and it creates ../MyOpenApiTest.json
cls
## any arg sets the Inner_text to ".."
if ($args.Count -gt 0) { 
    $Inner_text = ".."
} else {
    $Inner_text = "./" 
}

Write-Host "Inner_text is set to: $Inner_text, supply any arguement for .. path"

$ProgramName = "MyOpenApiTest"
# remove build from last run
$Project = "$ProgramName.csproj"

if (Test-Path $ProgramName) {
    Write-Host "Removing existing '$ProgramName' directory..."
    Remove-Item $ProgramName -Recurse -Force 
} 

## remove possible $JsonFile

if (Test-Path $JsonFile) {
    Write-Host "Removing existing $JsonFile file"
    Remove-Item $JsonFile -Force 
} 
else{
    Write-Host "No existing $JsonFile file"
}
# Write-Output $ProgramName
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

#$xml.OuterXml # displays the entire file
# 
dotnet build
if ($? -and $Inner_text -eq "..") {
   cd ..  # must move up or formatting bad
   Select-String -Path "$JsonFile" -Pattern "." | Select-Object -First 5
}
elseif ($?) {
    Select-String -Path "obj\$JsonFile" -Pattern "." | Select-Object -First 5
}
else{   ## build failed so move up directories to run the next command.
      cd .. 
}
