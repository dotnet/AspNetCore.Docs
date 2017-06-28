---
uid: identity/overview/features-api/best-practices-for-deploying-passwords-and-other-sensitive-data-to-aspnet-and-azure
title: "Best practices for deploying passwords and other sensitive data to ASP.NET and Azure App Service | Microsoft Docs"
author: Rick-Anderson
description: "This tutorial shows how your code can securely store and access secure information. The most important point is you should never store passwords or other sen..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 05/21/2015
ms.topic: article
ms.assetid: 97902c66-cb61-4d11-be52-73f962f2db0a
ms.technology: 
ms.prod: .net-framework
msc.legacyurl: /identity/overview/features-api/best-practices-for-deploying-passwords-and-other-sensitive-data-to-aspnet-and-azure
msc.type: authoredcontent
---
Best practices for deploying passwords and other sensitive data to ASP.NET and Azure App Service
====================
by [Rick Anderson](https://github.com/Rick-Anderson)

> This tutorial shows how your code can securely store and access secure information. The most important point is you should never store passwords or other sensitive data in source code, and you shouldn't use production secrets in development and test mode.
> 
> The sample code is a simple WebJob console app and a ASP.NET MVC app that needs access to a database connection string password, Twilio, Google and SendGrid secure keys.
> 
> On premise settings and PHP is also mentioned.


- [Working with passwords in the development environment](#pwd)
- [Working with connection strings in the development environment](#con)
- [WebJobs console apps](#wj)
- [Deploying secrets to Azure](#da)
- [Notes for On-Premise and PHP](#not)
- [Additional Resources](#addRes)

<a id="pwd"></a>
## Working with passwords in the development environment

Tutorials frequently show sensitive data in source code, hopefully with a caveat that you should never store sensitive data in source code. For example, my [ASP.NET MVC 5 app with SMS and email 2FA](../../../mvc/overview/security/aspnet-mvc-5-app-with-sms-and-email-two-factor-authentication.md) tutorial shows the following in the *web.config* file:

[!code-xml[Main](best-practices-for-deploying-passwords-and-other-sensitive-data-to-aspnet-and-azure/samples/sample1.xml)]

The *web.config* file is source code, so these secrets should never be stored in that file. Fortunately, the `<appSettings>` element has a `file` attribute that allows you to specify an external file that contains sensitive app config settings. You can move all your secrets to an external file as long as the external file is not checked into your source tree. For example, in the following markup, the file *AppSettingsSecrets.config* contains all the app secrets:

[!code-xml[Main](best-practices-for-deploying-passwords-and-other-sensitive-data-to-aspnet-and-azure/samples/sample2.xml)]

The markup in the external file (*AppSettingsSecrets.config* in this sample), is the same markup found in the *web.config* file:

[!code-xml[Main](best-practices-for-deploying-passwords-and-other-sensitive-data-to-aspnet-and-azure/samples/sample3.xml)]

The ASP.NET runtime merges the contents of the external file with the markup in &lt;appSettings&gt; element. The runtime ignores the file attribute if the specified file cannot be found.

> [!WARNING]
> Security - Do not add your *secrets .config* file to your project or check it into source control. By default, Visual Studio sets the `Build Action` to `Content`, which means the file is deployed. For more information see [Why don't all of the files in my project folder get deployed?](https://msdn.microsoft.com/en-us/library/ee942158(v=vs.110).aspx#can_i_exclude_specific_files_or_folders_from_deployment) Although you can use any extension for the *secrets .config* file, it's best to keep it *.config*, as config files are not served by IIS. Notice also that the *AppSettingsSecrets.config* file is two directory levels up from the *web.config* file, so it's completely out of the solution directory. By moving the file out of the solution directory, &quot;git add \*&quot; won't add it to your repository.


<a id="con"></a>
## Working with connection strings in the development environment

Visual Studio creates new ASP.NET projects that use [LocalDB](https://blogs.msdn.com/b/sqlexpress/archive/2011/07/12/introducing-localdb-a-better-sql-express.aspx). LocalDB was created specifically for the development environment. It doesn't require a password, therefore you don't need to do anything to prevent secrets from being checked into your source code. Some development teams use the full versions of SQL Server (or other DBMS) that require a password.

You can use the `configSource` attribute to replace the entire `<connectionStrings>` markup. Unlike the `<appSettings>` `file` attribute that merges the markup, the `configSource` attribute replaces the markup. The following markup shows the `configSource` attribute in the *web.config* file:

[!code-xml[Main](best-practices-for-deploying-passwords-and-other-sensitive-data-to-aspnet-and-azure/samples/sample4.xml?highlight=1)]

> [!NOTE]
> If you use the `configSource` attribute as shown above to move your connection strings to an external file, and have Visual Studio create a new web site, it won't be able to detect you are using a database, and you won't get the option of configuring the database when you publish to Azure from Visual Studio. If you are using the `configSource` attribute, you can use PowerShell to create and deploy your web site and database, or you can create the web site and the database in the portal before you publish. The [New-AzureWebsitewithDB.ps1](https://gallery.technet.microsoft.com/scriptcenter/Ultimate-Create-Web-SQL-DB-9e0fdfd3) script will create a new web site and database.


> [!WARNING]
> Security - Unlike the *AppSettingsSecrets.config* file, the external connection strings file must be in the same directory as the root *web.config* file, so you'll have to take precautions to ensure you don't check it into your source repository.


> [!NOTE]
> **Security Warning on secrets file:** A best practice is to not use production secrets in test and development. Using production passwords in test or development leaks those secrets.


<a id="wj"></a>
## WebJobs console apps

The *app.config* file used by a console app doesn't support relative paths, but it does support absolute paths. You can use an absolute path to move your secrets out of your project directory. The following markup shows the secrets in the *C:\secrets\AppSettingsSecrets.config* file, and non sensitive data in the *app.config* file.

[!code-xml[Main](best-practices-for-deploying-passwords-and-other-sensitive-data-to-aspnet-and-azure/samples/sample5.xml?highlight=2)]

<a id="da"></a>
## Deploying secrets to Azure

When you deploy your web app to Azure, the *AppSettingsSecrets.config* file won't be deployed (that's what you want). You could go to the [Azure Management Portal](https://azure.microsoft.com/services/management-portal/) and set them manually, to do that:

1. Go to [https://portal.azure.com](https://portal.azure.com), and sign in with your Azure credentials.
2. Click **Browse &gt; Web Apps**, then click the name of your web app.
3. Click **All settings &gt; Application settings**.

The **app settings** and **connection string** values override the same settings in the *web.config* file. In our example, we did not deploy these settings to Azure, but if these keys were in the *web.config* file, the settings shown on the portal would take precedence.

A best practice is to follow a [DevOps workflow](../../../aspnet/overview/developing-apps-with-windows-azure/building-real-world-cloud-apps-with-windows-azure/automate-everything.md) and use [Azure PowerShell](https://azure.microsoft.com/en-us/documentation/articles/install-configure-powershell/) (or another framework such as [Chef](http://www.opscode.com/chef/) or [Puppet](http://puppetlabs.com/puppet/what-is-puppet)) to automate setting these values in Azure. The following PowerShell script uses [Export-CliXml](http://www.powershellcookbook.com/recipe/PukO/securely-store-credentials-on-disk) to export the encrypted secrets to disk:

[!code-powershell[Main](best-practices-for-deploying-passwords-and-other-sensitive-data-to-aspnet-and-azure/samples/sample6.ps1)]

In the script above, ‘Name' is the name of the secret key, such as ‘&quot;FB\_AppSecret&quot; or "TwitterSecret". You can view the ".credential" file created by the script in your browser. The snippet below tests each of the credential files and sets the secrets for the named web app:

[!code-powershell[Main](best-practices-for-deploying-passwords-and-other-sensitive-data-to-aspnet-and-azure/samples/sample7.ps1)]

> [!WARNING]
> Security - Don't include passwords or other secrets in the PowerShell script, doing so defeats the purpose of using a PowerShell script to deploy sensitive data. The [Get-Credential](https://technet.microsoft.com/en-us/library/hh849815.aspx) cmdlet provides a secure mechanism to obtain a password. Using a UI prompt can prevent leaking a password.


### Deploying DB connection strings

DB connection strings are handled similarly to app settings. If you deploy your web app from Visual Studio, the connection string will be configured for you. You can verify this in the portal. The recommended way to set the connection string is with PowerShell. For an example of a PowerShell script the creates a website and database and sets the connection string in the website, download [New-AzureWebsitewithDB.ps1](https://gallery.technet.microsoft.com/scriptcenter/Ultimate-Create-Web-SQL-DB-9e0fdfd3) from the [Azure Script library](https://gallery.technet.microsoft.com/scriptcenter/site/search?f%5B0%5D.Type=RootCategory&amp;f%5B0%5D.Value=WindowsAzure).

<a id="not"></a>
## Notes for PHP

Since the key-value pairs for both **app settings** and **connection strings** are stored in environment variables on Azure App Service, developers that use any web app frameworks (such as PHP) can easily retrieve these values. See Stefan Schackow's [Windows Azure Web Sites: How Application Strings and Connection Strings Work](https://azure.microsoft.com/blog/2013/07/17/windows-azure-web-sites-how-application-strings-and-connection-strings-work/) blog post which shows a PHP snippet to read app settings and connection strings.

## Notes for on-premises servers

If you are deploying to on-premises web servers, you can help secure secrets by [encrypting the configuration sections of configuration files](https://msdn.microsoft.com/en-us/library/ff647398.aspx). As an alternative, you can use the same approach recommended for Azure Websites: keep development settings in configuration files, and use environment variable values for production settings. In this case, however, you have to write application code for functionality that is automatic in Azure Websites: retrieve settings from environment variables and use those values in place of configuration file settings, or use configuration file settings when environment variables are not found.

<a id="addRes"></a>
## Additional Resources

For an example of a PowerShell script that creates a web app + database, sets the connection string + app settings, download [New-AzureWebsitewithDB.ps1](https://gallery.technet.microsoft.com/scriptcenter/Ultimate-Create-Web-SQL-DB-9e0fdfd3) from the [Azure Script library](https://gallery.technet.microsoft.com/scriptcenter/site/search?f%5B0%5D.Type=RootCategory&amp;f%5B0%5D.Value=WindowsAzure). 

See Stefan Schackow's [Windows Azure Web Sites: How Application Strings and Connection Strings Work](https://azure.microsoft.com/blog/2013/07/17/windows-azure-web-sites-how-application-strings-and-connection-strings-work/)


Special thanks to Barry Dorrans ( [@blowdart](https://twitter.com/blowdart) ) and Carlos Farre for reviewing.
