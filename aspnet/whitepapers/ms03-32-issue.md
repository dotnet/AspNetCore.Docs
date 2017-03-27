---
uid: whitepapers/ms03-32-issue
title: "Fix for 'Server Application Unavailable' Error after Applying Security Update for IE | Microsoft Docs"
author: rick-anderson
description: "This paper describes the patch that fixes an issue with the MS03-32 Security Update for Internet Explorer that affects ASP.NET 1.0 applications running on Wi..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 02/10/2010
ms.topic: article
ms.assetid: 1365eebb-bdf7-4a05-8d18-7f200531be55
ms.technology: 
ms.prod: .net-framework
msc.legacyurl: /whitepapers/ms03-32-issue
msc.type: content
---
Fix for 'Server Application Unavailable' Error after Applying Security Update for IE
====================
> This paper describes the patch that fixes an issue with the MS03-32 Security Update for Internet Explorer that affects ASP.NET 1.0 applications running on Windows XP Professional.
> 
> Applies to ASP.NET 1.0 and Windows XP Professional.


Microsoft identified an issue with the MS03-32 Security Update for Internet Explorer security patch and ASP.NET 1.0 running on Windows XP. This patch can be installed manually or by obtaining recent critical updates from the Windows Update site.

The symptom of this issue is that after installing the patch on a Windows XP machine, all requests to ASP.NET applications running on the local IIS 5.1 web server result in an error message saying "Server Application Unavailable". Requests to remote web servers are unaffected.

This issue only impacts installations running ASP.NET 1.0 on Windows XP. It does not impact machines running Windows 2000 or Windows Server 2003. It also does not impact machines running Windows XP with ASP.NET 1.1 installed.

Please note that this issue **is not** a security bug with ASP.NET. It **does not** open up or allow any malicious attacks against an ASP.NET application or server. Instead, it is purely a functional bug caused by the patch itself.

We are working hard on a permanent solution for this issue. In the meantime, you can execute the following batch file as a workaround for the issue. The batch file does the following:

1. Stops the IIS and ASP.NET state services
2. Deletes and recreates the ASPNET account with a known temporary password
3. Uses the Windows `runas` command to launch an executable that creates an ASPNET user profile
4. Re-registers ASP.NET. This creates a new random password for the account and applies default ASP.NET access control settings for it
5. Restarts the IIS service

The batch file contains a hardcoded temporary password of "**1pass@word**" which you will be prompted to enter for the runas command when the batch file is run. After the runas command completes, the ASPNET account password is recreated with a strong random value. Note that the batch file may fail if the hardcoded password does not meet the password complexity requirements in your environment. If that's the case, you can change it to another value that is appropriate for your environment.

*> [!IMPORTANT]* If you have added custom access control settings or database account permissions for the ASPNET account, they will need to be recreated after this batch file completes. This is because when the account is recreated, it will get a new security identifier (SID).

*> [!IMPORTANT]* If you are running the ASP.NET worker process with a custom account other than the ASPNET account, then you should not run this batch file. Instead, you should log in interactively or use the runas command with that account which will create a user profile for that account.

The batch file is included in the self-extracting archive below. To use it:

1. You must be running as an account with Administrator privileges
2. [Download and open the self-extracting executable file](ms03-32-issue/_static/fixup1.exe)
3. Extract the contents to c:\
4. Select Run... from the start menu, and enter `cmd.exe`
5. In the open command windows, type `c:\fixup.cmd`.
6. When prompted, enter **1pass@word** as the password.
7. If you have previously custom access control settings or database account permissions for the ASPNET account, you'll need to re-apply these settings now.

Many apologies for the inconvenience that this has caused. We'll post additional information as it becomes available.

The matrix below details platforms and versions impacted by this issue.

| .NET Framework | Platform | Affected |
| --- | --- | --- |
| Version 1.0 | Windows 2000 Professional | No |
| Version 1.0 | Windows 2000 Server | No |
| Version 1.0 | Windows XP Professional | Yes |
| Version 1.0 | Windows Server 2003 | No |
| Version 1.0 | Windows XP Home with Cassini | No |
| Version 1.1 | Windows 2000 Professional | No |
| Version 1.1 | Windows 2000 Server | No |
| Version 1.1 | Windows XP Professional | No |
| Version 1.1 | Windows Server 2003 | No |
| Version 1.1 | Windows XP Home with Cassini | No |

Thanks,   
 The ASP.NET Team