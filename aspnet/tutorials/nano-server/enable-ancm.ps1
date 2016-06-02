Import-Module IISAdministration 

$sm = Get-IISServerManager

# Add AppSettings section (for Asp.Net Core)
$sm.GetApplicationHostConfiguration().RootSectionGroup.Sections.Add("appSettings")

# Unlock handlers section
$appHostconfig = $sm.GetApplicationHostConfiguration()
$section = $appHostconfig.GetSection("system.webServer/handlers")
$section.OverrideMode="Allow"

# Add httpPlatform section to system.webServer
$sectionHttpPlatform = $appHostConfig.RootSectionGroup.SectionGroups["system.webServer"].Sections.Add("aspNetCore")
$sectionHttpPlatform.OverrideModeDefault = "Allow"

# Add to globalModules
$globalModules = Get-IISConfigSection "system.webServer/globalModules" | Get-IISConfigCollection
New-IISConfigCollectionElement $globalModules -ConfigAttribute @{"name"="AspNetCoreModule";"image"="%SystemRoot%\system32\inetsrv\aspnetcore.dll"}

# Add to modules
$modules = Get-IISConfigSection "system.webServer/modules" | Get-IISConfigCollection
New-IISConfigCollectionElement $modules -ConfigAttribute @{"name"="AspNetCoreModule"}
$sm.CommitChanges()