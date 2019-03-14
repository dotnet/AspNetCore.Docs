$TempPackagesFolder = Join-Path  $PSScriptRoot "obj\packages"
$TempPublishFolder = Join-Path  $PSScriptRoot "obj\pub"
$TargetFolder = Join-Path  $PSScriptRoot "deployment"
$TargetStoreFolder = Join-Path  $TargetFolder "store"
$TargetDepsFolder = Join-Path  $TargetFolder "additionalDeps\shared\Microsoft.AspNetCore.App\2.2.0\"
$MsbuildFlags = @("-v", "q", "/nologo");

function RemoveManifestFromDeps ($depsLocation, $depsTarget) {
    $deps = Get-Content $depsLocation -Raw | ConvertFrom-Json
    # remove item from libraries
    $deps.libraries.PSObject.Properties.Remove("store.manifest/1.0.0");
    # remove item from targets
    $deps.targets.PSObject.properties.Value.PSObject.Properties.Remove("store.manifest/1.0.0");

    $deps | ConvertTo-Json -Depth 5 | Set-Content $depsTarget
}

if (Test-Path $TempPackagesFolder)
{
    Remove-Item $TempPackagesFolder -Recurse -Force
}

if (Test-Path $TempPublishFolder)
{
    Remove-Item $TempPublishFolder -Recurse -Force
}

if (!(Test-Path $TargetDepsFolder))
{
    mkdir $TargetDepsFolder | Out-Null;
}

Write-Host "Generating StartupDiagnostics package"
dotnet pack ..\StartupDiagnostics\StartupDiagnostics.csproj -o $TempPackagesFolder $MsbuildFlags

Write-Host "Generating runtime store for StartupDiagnostics at $TargetStoreFolder"
dotnet store -r win7-x64 -o $TargetStoreFolder --manifest store.manifest.csproj --skip-optimization $MsbuildFlags

Write-Host "Generating additionalDeps for StartupDiagnostics at $TargetDepsFolder"
dotnet publish store.manifest.csproj -o $TempPublishFolder $MsbuildFlags
RemoveManifestFromDeps (Join-Path  $TempPublishFolder "store.manifest.deps.json") "$TargetDepsFolder\StartupDiagnostics.deps.json"

Write-Host "Placing deploy.ps1 file to $TargetFolder"
Copy-Item deploy.ps1 $TargetFolder -Force
