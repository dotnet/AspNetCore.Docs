function SetEnvironmentVariables
{
    # Set StartupDiagnostics into the ASPNETCORE_HOSTINGSTARTUPASSEMBLIES environment variable
    $value = [Environment]::GetEnvironmentVariable('ASPNETCORE_HOSTINGSTARTUPASSEMBLIES', 'Machine')
    if ($value -eq $null) {
      [Environment]::SetEnvironmentVariable('ASPNETCORE_HOSTINGSTARTUPASSEMBLIES', 'StartupDiagnostics', 'Machine')
    } else {
      if ($value -notlike '*StartupDiagnostics*') {
        [Environment]::SetEnvironmentVariable('ASPNETCORE_HOSTINGSTARTUPASSEMBLIES', $value + ';StartupDiagnostics', 'Machine')
      }
    } 
    
    # Set the hosting startup dependencies path into DOTNET_ADDITIONAL_DEPS
    $value = [Environment]::GetEnvironmentVariable('DOTNET_ADDITIONAL_DEPS', 'Machine')
    if ($value -eq $null) {
      [Environment]::SetEnvironmentVariable('DOTNET_ADDITIONAL_DEPS', '%UserProfile%\.dotnet\x64\additionalDeps\StartupDiagnostics\', 'Machine')
    } else {
      if ($value -notlike '*StartupDiagnostics*') {
        [Environment]::SetEnvironmentVariable('DOTNET_ADDITIONAL_DEPS', $value + ';%UserProfile%\.dotnet\x64\additionalDeps\StartupDiagnostics\', 'Machine')
      }
    }
}

SetEnvironmentVariables
