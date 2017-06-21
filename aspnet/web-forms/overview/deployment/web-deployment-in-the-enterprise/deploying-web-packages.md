---
uid: web-forms/overview/deployment/web-deployment-in-the-enterprise/deploying-web-packages
title: "Deploying Web Packages | Microsoft Docs"
author: jrjlee
description: "This topic describes how you can publish web deployment packages to a remote server by using the Internet Information Services (IIS) Web Deployment Tool (Web..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 05/04/2012
ms.topic: article
ms.assetid: a5c5eed2-8683-40a5-a2e1-35c9f8d17c29
ms.technology: dotnet-webforms
ms.prod: .net-framework
msc.legacyurl: /web-forms/overview/deployment/web-deployment-in-the-enterprise/deploying-web-packages
msc.type: authoredcontent
---
Deploying Web Packages
====================
by [Jason Lee](https://github.com/jrjlee)

[Download PDF](https://msdnshared.blob.core.windows.net/media/MSDNBlogsFS/prod.evol.blogs.msdn.com/CommunityServer.Blogs.Components.WeblogFiles/00/00/00/63/56/8130.DeployingWebAppsInEnterpriseScenarios.pdf)

> This topic describes how you can publish web deployment packages to a remote server by using the Internet Information Services (IIS) Web Deployment Tool (Web Deploy) 2.0.
> 
> There are two main ways in which you can deploy a web package to a remote server:
> 
> - You can use the MSDeploy.exe command-line utility directly.
> - You can run the *[project name].deploy.cmd* file that the build process generates.
> 
> The end result is the same regardless of which approach you use. Essentially, all the *.deploy.cmd* file does is to run MSDeploy.exe with some predetermined values, so that you don't have to provide as much information in order to deploy the package. This simplifies the deployment process. On the other hand, using MSDeploy.exe directly gives you a lot more flexibility over exactly how your package is deployed.
> 
> Which approach you use will depend on a variety of factors, including how much control you require over the deployment process and whether you're targeting the Web Deploy Remote Agent service or the Web Deploy Handler. This topic explains how to use each approach and identifies when each approach is appropriate.
> 
> The tasks and walkthroughs in this topic assume that:
> 
> - You've built and packaged your web application, as described in [Building and Packaging Web Application Projects](building-and-packaging-web-application-projects.md).
> - You've modified the *SetParameters.xml* file to provide the right parameter values for your target environment, as described in [Configuring Parameters for Web Package Deployment](configuring-parameters-for-web-package-deployment.md).


Running the [*project name*]*.deploy.cmd* file is the simplest way to deploy a web package. In particular, using the *.deploy.cmd* file offers these advantages over using MSDeploy.exe directly:

- You don't need to specify the location of the web deployment package&#x2014;the *.deploy.cmd* file already knows where it is.
- You don't need to specify the location of the *SetParameters.xml* file&#x2014;the *.deploy.cmd* file already knows where it is.
- You don't need to specify source and destination MSDeploy providers&#x2014;the *.deploy.cmd* file already knows which values to use.
- You don't need to specify MSDeploy operation settings&#x2014;the *.deploy.cmd* file adds the commonly required values to the MSDeploy.exe command automatically.

Before you use the *.deploy.cmd* file to deploy a web package, you should ensure that:

- The *.deploy.cmd* file, the [*project name*].*SetParameters.xml* file, and the web package ([*project name*].*zip*) are in the same folder.
- Web Deploy (MSDeploy.exe) is installed on the computer that runs the *.deploy.cmd* file.

The *.deploy.cmd* file supports various command-line options. When you run the file from a command prompt, this is the basic syntax:


[!code-console[Main](deploying-web-packages/samples/sample1.cmd)]


You must specify either a **/T** flag or a **/Y** flag, to indicate whether you want to perform a trial run or a live deployment respectively (don't use both flags in the same command). This table explains the purpose of each of these flags.

| Flag | Description |
| --- | --- |
| **/T** | Calls MSDeploy.exe with the **–whatif** flag, which indicates a trial run. Rather than deploying the package, it creates a report of what would happen if you did deploy the package. |
| **/Y** | Calls MSDeploy.exe without the **–whatif** flag. This deploys the package to the local computer or the specified destination server. |
| **/M** | Specifies the destination server name or service URL. For more information on the values you can provide here, see the **Endpoint Considerations** section in this topic. If you omit the **/M** flag, the package will be deployed to the local computer. |
| **/A** | Specifies the authentication type that MSDeploy.exe should use to perform the deployment. Possible values are **NTLM** and **Basic**. If you omit the **/A** flag, the authentication type defaults to **NTLM** for deployment to the Web Deploy Remote Agent service and to **Basic** for deployment to the Web Deploy Handler. |
| **/U** | Specifies the user name. This applies only if you're using basic authentication. |
| **/P** | Specifies the password. This applies only if you're using basic authentication. |
| **/L** | Indicates that the package should be deployed to the local IIS Express instance. |
| **/G** | Specifies that the package is deployed using the [tempAgent provider setting](https://technet.microsoft.com/en-us/library/ee517345(WS.10).aspx). If you omit the **/G** flag, the value defaults to **false**. |

> [!NOTE]
> Every time the build process creates a web package, it also creates a file named *[project name].deploy-readme.txt* that explains these deployment options.


In addition to these flags, you can specify Web Deploy operation settings as additional *.deploy.cmd* parameters. Any additional settings you specify are simply passed through to the underlying MSDeploy.exe command. For more information on these settings, see [Web Deploy Operation Settings](https://technet.microsoft.com/en-us/library/dd569089(WS.10).aspx).

Suppose you want to deploy the ContactManager.Mvc web application project to a test environment by running the *.deploy.cmd* file. Your test environment is configured to use the Web Deploy Remote Agent service, as described in [Configure a Web Server for Web Deploy Publishing (Remote Agent)](../configuring-server-environments-for-web-deployment/configuring-a-web-server-for-web-deploy-publishing-remote-agent.md). To deploy the web application, you need to complete the next steps.

**To deploy a web application using the .deploy.cmd file**

1. Build and package the web application project, as described in [Building and Packaging Web Application Projects](building-and-packaging-web-application-projects.md).
2. Modify the *ContactManager.Mvc.SetParameters.xml* file to contain the correct parameter values for your test environment, as described in [Configuring Parameters for Web Package Deployment](configuring-parameters-for-web-package-deployment.md).
3. Open a Command Prompt window and navigate to the location of the *ContactManager.Mvc.deploy.cmd* file.
4. Type this command, and then press Enter:

    [!code-console[Main](deploying-web-packages/samples/sample2.cmd)]

In this example:

- The **/Y** flag indicates that you want to actually deploy the package, rather than doing a trial run.
- The **/M** flag indicates that you want to deploy the package to the server named TESTWEB1. From this value, MSDeploy.exe will attempt to deploy the package to the Web Deploy Remote Agent service at http://TESTWEB1/MSDeployAgentService.
- The **/A** flag indicates that you want to use NTLM authentication. As such, you don't need to specify a user name and password.

To illustrate how using the *.deploy.cmd* file simplifies the deployment process, take a look at the MSDeploy.exe command that gets generated and executed when you run *ContactManager.Mvc.deploy.cmd* using the options shown above.


[!code-console[Main](deploying-web-packages/samples/sample3.cmd)]


For more information on using the *.deploy.cmd* file to deploy a web package, see [How to: Install a Deployment Package Using the deploy.cmd File](https://msdn.microsoft.com/en-us/library/ff356104.aspx).

## Using MSDeploy.exe

Although using the *.deploy.cmd* file generally simplifies the deployment process, there are some situations when it's preferable to use MSDeploy.exe directly. For example:

- If you want to deploy to the Web Deploy Handler as a non-administrator user, you can't use the *.deploy.cmd* file. This is due to a bug in Web Deploy 2.0, as described under **Endpoint Considerations**.
- If you want to manually switch between different *SetParameters.xml* files in different locations, you may prefer to use MSDeploy.exe directly.
- If you want to override several MSDeploy.exe command-line arguments, you may prefer to use MSDeploy.exe directly.

When you use MSDeploy.exe, you need to provide three key pieces of information:

- A **–source** parameter that indicates where your data is coming from.
- A **–dest** parameter that indicates where your data is going to.
- A **–verb** parameter that indicates the [operation](https://technet.microsoft.com/en-us/library/dd568989(WS.10).aspx) you want to perform.

MSDeploy.exe relies on [Web Deploy providers](https://technet.microsoft.com/en-us/library/dd569040(WS.10).aspx) to process source and destination data. Web Deploy includes a lot of providers that represent the range of applications and data sources it can work with&#x2014;for example, there are providers for SQL Server databases, IIS web servers, certificates, global assembly cache (GAC) assemblies, various different configuration files, and lots of other types of data. Both the **–source** parameter and the **–dest** parameter must specify a provider, in the form **–source**:[*providerName*]=[*location*]. When you're deploying a web package to an IIS website, you should use these values:

- The **–source** provider is always [package](https://technet.microsoft.com/en-us/library/dd569019(WS.10).aspx). For example:

    [!code-console[Main](deploying-web-packages/samples/sample4.cmd)]
- The **–dest** provider is always [auto](https://technet.microsoft.com/en-us/library/dd569016(WS.10).aspx). For example:

    [!code-console[Main](deploying-web-packages/samples/sample5.cmd)]
- The **–verb** is always **sync**.

    [!code-console[Main](deploying-web-packages/samples/sample6.cmd)]

In addition, you'll need to specify various other [provider-specific settings](https://technet.microsoft.com/en-us/library/dd569001(WS.10).aspx) and general [operation settings](https://technet.microsoft.com/en-us/library/dd569089(WS.10).aspx). For example, suppose you want to deploy the ContactManager.Mvc web application to a staging environment. The deployment will target the Web Deploy Handler and must use basic authentication. To deploy the web application, you need to complete the next steps.

**To deploy a web application using MSDeploy.exe**

1. Build and package the web application project, as described in [Building and Packaging Web Application Projects](building-and-packaging-web-application-projects.md).
2. Modify the *ContactManager.Mvc.SetParameters.xml* file to contain the correct parameter values for your staging environment, as described in [Configuring Parameters for Web Package Deployment](configuring-parameters-for-web-package-deployment.md).
3. Open a Command Prompt window and browse to the location of MSDeploy.exe. This is typically at %PROGRAMFILES%\IIS\Microsoft Web Deploy V2\msdeploy.exe.
4. Type this command, and then press Enter (disregard the line breaks):

    [!code-console[Main](deploying-web-packages/samples/sample7.cmd)]

In this example:

- The **–source** parameter specifies the **package** provider and indicates the location of the web package.
- The **–dest** parameter specifies the **auto** provider. The **computerName** setting provides the service URL of the Web Deploy Handler on the destination server. The **authtype** setting indicates that you want to use basic authentication, and as such you need to provide a **username** and a **password**. Finally, the **includeAcls="False"** setting indicates that you don't want to copy the access control lists (ACLs) of the files in your source web application to the destination server.
- The **–verb:sync** argument indicates that you want to replicate the source content on the destination server.
- The **–disableLink** arguments indicate that you don't want to replicate application pools, virtual directory configuration, or Secure Sockets Layer (SSL) certificates on the destination server. For more information, see [Web Deploy Link Extensions](https://technet.microsoft.com/en-us/library/dd569028(WS.10).aspx).
- The **–setParamFile** parameter provides the location of the *SetParameters.xml* file.
- The **–allowUntrusted** switch indicates that Web Deploy should accept SSL certificates that were not issued by a trusted certification authority. If you're deploying to the Web Deploy Handler, and you've used a self-signed certificate to secure the service URL, you need to include this switch.

## Automating Web Package Deployment

In a lot of enterprise scenarios, you'll want to deploy your web packages as part of a larger single-step or automated deployment. Regardless of whether you choose to deploy your web packages by running the *.deploy.cmd* file or by using MSDeploy.exe directly, you can parameterize your commands and call them from a target in a Microsoft Build Engine (MSBuild) project file.

In the Contact Manager sample solution, take a look at the **PublishWebPackages** target in the *Publish.proj* file. This target runs once for each *.deploy.cmd* file identified by an item list named **PublishPackages**. The target uses properties and item metadata to build up a full set of argument values for each *.deploy.cmd* file and then uses the **Exec** task to run the command.


[!code-xml[Main](deploying-web-packages/samples/sample8.xml)]


> [!NOTE]
> For a broader overview of the project file model in the sample solution, and an introduction to custom project files in general, see [Understanding the Project File](understanding-the-project-file.md) and [Understanding the Build Process](understanding-the-build-process.md).


## Endpoint Considerations

Regardless of whether you deploy your web package by running the *.deploy.cmd* file or by using MSDeploy.exe directly, you need to specify a computer name or a service endpoint for your deployment.

If the destination web server is configured for deployment using the Web Deploy Remote Agent service, you specify the target service URL as your destination.


[!code-console[Main](deploying-web-packages/samples/sample9.cmd)]


Alternatively, you can specify the server name alone as your destination, and Web Deploy will infer the remote agent service URL.


[!code-console[Main](deploying-web-packages/samples/sample10.cmd)]


If the destination web server is configured for deployment using the Web Deploy Handler, you need to specify the endpoint address of the IIS Web Management Service (WMSvc) as your destination. By default, this takes the form:


[!code-console[Main](deploying-web-packages/samples/sample11.cmd)]


You can target any of these endpoints using either the *.deploy.cmd* file or MSDeploy.exe directly. However, if you want to deploy to the Web Deploy Handler as a non-administrator user, as described in [Configure a Web Server for Web Deploy Publishing (Web Deploy Handler)](../configuring-server-environments-for-web-deployment/configuring-a-web-server-for-web-deploy-publishing-web-deploy-handler.md), you need to add a query string to the service endpoint address.


[!code-console[Main](deploying-web-packages/samples/sample12.cmd)]


This is because the non-administrator user doesn't have server-level access to IIS; he or she only has access to a specific IIS website. At the time of writing, due to a bug in the Web Publishing Pipeline (WPP), you can't run the *.deploy.cmd* file using an endpoint address that includes a query string. In this scenario, you need to deploy your web package by using MSDeploy.exe directly.

> [!NOTE]
> For more information on the Web Deploy Remote Agent service and the Web Deploy Handler, see [Choosing the Right Approach to Web Deployment](../configuring-server-environments-for-web-deployment/choosing-the-right-approach-to-web-deployment.md). For guidance on how to configure your environment-specific project files to deploy to these endpoints, see [Configure Deployment Properties for a Target Environment](../configuring-server-environments-for-web-deployment/configuring-deployment-properties-for-a-target-environment.md).


## Authentication Considerations

Regardless of whether you deploy your web package by running the *.deploy.cmd* file or by using MSDeploy.exe directly, you need to specify an authentication type. Web Deploy accepts two possible values: **NTLM** or **Basic**. If you specify basic authentication, you also need to provide a user name and password. There are various factors you need to be aware of when you select an authentication type:

- If you're deploying to the Web Deploy Remote Agent service, you must use NTLM authentication. The remote agent service doesn't accept basic authentication credentials.
- If you're deploying to the Web Deploy Handler, you can use either NTLM or basic authentication. The default setting is basic authentication. Although basic authentication relies on user names and passwords being transmitted in plain text, your credentials are protected as the Web Deploy Handler always uses SSL encryption.
- If your web package includes a database, and the web server and database server are separate machines, you won't be able to deploy the database using NTLM authentication due to the [NTLM "double-hop" limitation](https://go.microsoft.com/?linkid=9805120). You need to either use SQL Server credentials in your deployment connection string or supply basic authentication credentials to Web Deploy. This issue is described in more detail in [Deploying Membership Databases to Enterprise Environments](../advanced-enterprise-web-deployment/deploying-membership-databases-to-enterprise-environments.md).

## Conclusion

This topic described how you can deploy a web package either by running the *.deploy.cmd* file or by using MSDeploy.exe directly. It explained when each approach might be appropriate, and it described how you can parameterize and run a deployment command as part of a larger single-step or automated build process.

## Further Reading

For guidance on how to create and parameterize a web deployment package, see [Building and Packaging Web Application Projects](building-and-packaging-web-application-projects.md) and [Configuring Parameters for Web Package Deployment](configuring-parameters-for-web-package-deployment.md). For guidance on how to build and deploy web packages from a Team Foundation Server (TFS) instance, see [Configuring Team Foundation Server for Automated Web Deployment](../configuring-team-foundation-server-for-web-deployment/configuring-team-foundation-server-for-web-deployment.md). For information on how to customize and troubleshoot the deployment process, see [Excluding Files and Folders from Deployment](../advanced-enterprise-web-deployment/excluding-files-and-folders-from-deployment.md).

>[!div class="step-by-step"]
[Previous](configuring-parameters-for-web-package-deployment.md)
[Next](deploying-database-projects.md)