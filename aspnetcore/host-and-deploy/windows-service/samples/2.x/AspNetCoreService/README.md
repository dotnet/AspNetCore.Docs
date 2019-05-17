# ASP.NET Core Windows Service Sample (Framework-dependent Deployment)

This sample shows how to host an ASP.NET Core app as a Windows Service without using IIS. This sample demonstrates the scenario described in [Host an ASP.NET Core app in a Windows Service](https://docs.microsoft.com/aspnet/core/host-and-deploy/windows-service).

## Logging level

For demonstration and testing purposes, the sample app's Production environment settings file sets the logging level to `Information`. In production app, the value is typically set to `Error`. For more information, see [Windows Eventlog Provider](https://docs.microsoft.com/aspnet/core/fundamentals/logging/index#windows-eventlog-provider).

## Publish the sample app

To publish the sample app using command-line interface (CLI) tools, execute the [dotnet publish](https://docs.microsoft.com/dotnet/core/tools/dotnet-publish) command in a command shell from the project folder. The default project configuration is Release but can be changed by passing the [-c|--configuration](https://docs.microsoft.com/dotnet/core/tools/dotnet-publish#options) option to the command. Use the [-o|--output](https://docs.microsoft.com/dotnet/core/tools/dotnet-publish#options) option with a path to publish to a folder (the folder is created if it doesn't exist when the command is executed).

## PowerShell

Execute PowerShell commands from an administrative PowerShell 6 command shell.

## Create a user account

Create a user account with the name `ServiceUser`.

On Windows 10 October 2018 Update (version 1809/build 10.0.17763) or later:

```PowerShell
New-LocalUser -Name ServiceUser
```

On Windows OS earlier than the Windows 10 October 2018 Update (version 1809/build 10.0.17763):

```console
powershell -Command "New-LocalUser -Name ServiceUser"
```

Provide a [strong password](https://docs.microsoft.com/windows/security/threat-protection/security-policy-settings/password-must-meet-complexity-requirements) when prompted.

Unless the `-AccountExpires` parameter is supplied to the [New-LocalUser](https://docs.microsoft.com/powershell/module/microsoft.powershell.localaccounts/new-localuser) cmdlet with an expiration <xref:System.DateTime>, the account doesn't expire.

## Provide the service user account with Log on as a service rights

1. Open the Local Security Policy editor by running *secpool.msc*.
1. Expand the **Local Policies** node and select **User Rights Assignment**.
1. Open the **Log on as a service** policy.
1. Select **Add User or Group**.
1. Provide the object name (user account) using either of the following approaches:
   1. Type the user account (`{DOMAIN OR COMPUTER NAME\USER}`) in the object name field and select **OK** to add the user to the policy.
   1. Select **Advanced**. Select **Find Now**. Select the user account from the list. Select **OK**. Select **OK** again to add the user to the policy.
1. Select **OK** or **Apply** to accept the changes.

## Create the service

Use the [RegisterService.ps1](https://github.com/aspnet/AspNetCore.Docs/tree/master/aspnetcore/host-and-deploy/windows-service/scripts) PowerShell script to register the service. From an administrative PowerShell 6 command shell, execute the script with the following command:

```powershell
.\RegisterService.ps1 
    -Name AspNetCoreService 
    -DisplayName "ASP.NET Core Service" 
    -Description "This is the ASP.NET Core Sample App service." 
    -Exe "c:\svc\SampleApp.exe" 
    -User {DOMAIN OR COMPUTER NAME}\ServiceUser
```

* The service is named **AspNetCoreService**.
* The published service resides in the *c:\\svc* folder. The app executable is named *SampleApp.exe*.
* The service runs under the `ServiceUser` account. Replace `{DOMAIN OR COMPUTER NAME}` with the domain or computer name of the user account.

## Manage the service

### Start the service

To start the sample app service, use the following command:

```powershell
Start-Service -Name AspNetCoreService
```

The command takes a few seconds to start the service.

### Determine the service status

Use the following command to check the status of the sample app service:

```powershell
Get-Service -Name AspNetCoreService
```

## Browse a web app service

When the service is in the `RUNNING` state and if the service is a web app, browse the app at its path (by default, `http://localhost:5000`, which redirects to `https://localhost:5001` when using [HTTPS Redirection Middleware](https://docs.microsoft.com/aspnet/core/security/enforcing-ssl)).

### Stop the service

The following command stops the sample app service:

```powershell
Stop-Service -Name AspNetCoreService
```

### Remove the service

The following command removes the sample app service:

```powershell
Remove-Service -Name AspNetCoreService
```
