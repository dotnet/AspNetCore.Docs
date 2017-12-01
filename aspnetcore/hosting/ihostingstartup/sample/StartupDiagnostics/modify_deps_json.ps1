function ModifyDepsJson
{
    param([string]$build)
    $s = Get-Content ".\bin\$build\netcoreapp2.0\StartupDiagnostics.deps.json" -Raw|ConvertFrom-Json
    $r = @{
    'lib/netcoreapp2.0/StartupDiagnostics.dll' = @{}
}
    $s.targets.'.NETCoreApp,Version=v2.0'.'StartupDiagnostics/1.0.0'.runtime = $r
    $s|ConvertTo-Json -Depth 5 |Set-Content "bin\$build\netcoreapp2.0\StartupDiagnostics.deps.json"
}

ModifyDepsJson $args[0]
