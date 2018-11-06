function AppendToEnvironmentVariable($name, $appendValue)
{
    $value = [Environment]::GetEnvironmentVariable($name, 'Machine')
    if ($value -eq $null) {
      [Environment]::SetEnvironmentVariable($name, 'StartupDiagnostics', 'Machine')
    } else {
      if ($value -notcontains $appendValue) {
        [Environment]::SetEnvironmentVariable($name, $value + ';' + $appendValue, 'Machine')
      }
    }
}

# Set StartupDiagnostics into the ASPNETCORE_HOSTINGSTARTUPASSEMBLIES environment variable
AppendToEnvironmentVariable "ASPNETCORE_HOSTINGSTARTUPASSEMBLIES" "StartupDiagnostics"
# Set the hosting startup dependencies path into DOTNET_ADDITIONAL_DEPS
AppendToEnvironmentVariable "DOTNET_ADDITIONAL_DEPS" "$PSScriptRoot\additionalDeps\"
