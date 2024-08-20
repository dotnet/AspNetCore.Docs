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

try {
    # Add property and test
    $xml = [xml](Get-Content $Project)

    # Check if PropertyGroup with OpenApiDocumentsDirectory already exists
    $existingPropertyGroup = $xml.SelectSingleNode("//PropertyGroup[OpenApiDocumentsDirectory]")

    if (-not $existingPropertyGroup) { 
        $newPropGrp1 = $xml.CreateElement("PropertyGroup")
        $newElement = $xml.CreateElement("OpenApiDocumentsDirectory")
        $newElement.InnerText = "./"
        $newPropGrp1.AppendChild($newElement)
        $xml.Project.AppendChild($newPropGrp1)

        # Save the changes to the original project file
        $xml.Save($Project) 
    }

    # Verify change is saved (directly from the original file)
    $xml2 = [xml](Get-Content $Project)
    $xml2.OuterXml
}
catch {
    Write-Error "An error occurred: $($_.Exception.Message)"
}

dotnet build
cd ..
