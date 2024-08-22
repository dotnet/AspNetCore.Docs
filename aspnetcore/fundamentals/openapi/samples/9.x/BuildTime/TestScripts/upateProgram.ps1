# Yields error Document with name 'v2' not found.
# This script is similar to updateProgram.ps1, but it adds thee v2 endpoint
cls
$originalDir = Get-Location
cd C:\tmp
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

$ProgramCSname = "Program.cs"

$newContent = @'
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddOpenApi("v2");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.MapGet("/v2/weatherforecast", (HttpContext httpContext) =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithGroupName("v2");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
'@

# Write the new content to the Program.cs file
Set-Content -Path $ProgramCSname -Value $newContent

Write-Host "Program.cs file has been updated successfully."

# --------------------------
#Write-Host "New MapGet code has been added successfully."

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

Set-Location -Path $originalDir
