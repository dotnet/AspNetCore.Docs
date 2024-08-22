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
exit
Set-Location $ProgramName
dotnet add package Microsoft.Extensions.ApiDescription.Server --version 9.0.0-* --source https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet9/nuget/v3/index.json

$ProgramCSname = "Program.cs"

# Read the content of the program.cs file
$programContent = Get-Content -Path $ProgramCSname

# Define the new MapGet code to be added
$newMapGetCode = @'
app.MapGet("/v2/weatherforecast", (HttpContext httpContext) =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = summaries[Random.Shared.Next(summaries.Length)]
        })
        .ToArray();
    return forecast;
})
.WithGroupName("v2");
'@

# Find the index of the line containing "app.Run();"
$runIndex = $programContent.IndexOf("app.Run();")

# Insert the new MapGet code just before the app.Run() statement
$updatedContent = $programContent[0..($runIndex-1)] + $newMapGetCode + $programContent[$runIndex..($programContent.Length-1)]

# Write the updated content back to the program.cs file
Set-Content -Path $ProgramCSname -Value $updatedContent

#Write-Host "New MapGet code has been added successfully."
exit
dotnet build
if ($LASTEXITCODE -eq 0) {
    Write-Output "Build succeeded."
} else {
    Write-Output "Build failed."
}
# Add property and test build with new property
$xml = [xml](Get-Content $Project)
$newPropGrp1 = $xml.CreateElement("PropertyGroup")

$newElement = $xml.CreateElement("OpenApiGenerateDocumentsOptions")
$newElement.InnerText = "--document-name v2"
$newPropGrp1.AppendChild($newElement)

$xml.Project.AppendChild($newPropGrp1)
$xml.OuterXml | Set-Content -Path $Project

dotnet build
if ($LASTEXITCODE -eq 0) {
    Write-Output "Build succeeded."
    Select-String -Path "obj\$ProgramName.json" -Pattern "." | Select-Object -First 5
}
else {
    Write-Output "Build failed."
}
