---
title: Continuous deployment to Azure with Visual Studio and Git
author: rick-anderson
description: Learn how to create an ASP.NET Core web app using Visual Studio and deploy it to Azure App Service, using Git for continuous deployment.
keywords: ASP.NET Core,
ms.author: riande
manager: wpickett
ms.date: 10/14/2016
ms.topic: article
ms.assetid: 2707c7a8-2350-4304-9856-fda58e5c0a16
ms.technology: aspnet
ms.prod: asp.net-core
uid: publishing/azure-continuous-deployment
---
# Continuous deployment to Azure for ASP.NET Core, with Visual Studio and Git

By [Erik Reitan](https://github.com/Erikre)

This tutorial shows you how to create an ASP.NET Core web app using Visual Studio and deploy it from Visual Studio to Azure App Service using continuous deployment. 

See also [Use VSTS to Build and Publish to an Azure Web App with Continuous Deployment](https://www.visualstudio.com/docs/build/get-started/aspnet-4-ci-cd-azure-automatic), which shows how to configure a continuous delivery (CD) workflow for [Azure App Service](https://azure.microsoft.com/documentation/articles/app-service-changes-existing-services/) using Visual Studio Team Services. Azure Continuous Delivery in Team Services simplifies setting up a robust deployment pipeline to publish updates for your app to Azure App Service. The pipeline can be configured from the Azure portal to build, run tests, deploy to a staging slot,  and then deploy to production.

> [!NOTE]
> To complete this tutorial, you need a Microsoft Azure account. If you don't have an account, you can [activate your MSDN subscriber benefits](https://azure.microsoft.com/pricing/member-offers/msdn-benefits-details/?WT.mc_id=A261C142F) or [sign up for a free trial](https://azure.microsoft.com/pricing/free-trial/?WT.mc_id=A261C142F).

## Prerequisites

This tutorial assumes you have already installed the following:

* [Visual Studio](https://www.visualstudio.com)

* [ASP.NET Core](https://download.microsoft.com/download/F/6/E/F6ECBBCC-B02F-424E-8E03-D47E9FA631B7/DotNetCore.1.0.1-VS2015Tools.Preview2.0.3.exe) (runtime and tooling)

* [Git](https://git-scm.com/downloads) for Windows

## Create an ASP.NET Core web app

1. Start Visual Studio.

2. From the **File** menu, select **New** > **Project**.

3. Select the **ASP.NET Web Application** project template. It appears under **Installed** > **Templates** > **Visual C#** > **Web**. Name the project `SampleWebAppDemo`. Select the **Create new Git respository** option and click **OK**.

   ![New Project dialog](azure-continuous-deployment/_static/01-new-project.png)

4. In the **New ASP.NET Project** dialog, select the ASP.NET Core **Empty** template, then click **OK**.

   ![New ASP.NET Project dialog](azure-continuous-deployment/_static/02-web-site-template.png)


### Running the web app locally

1. Once Visual Studio finishes creating the app, run the app by selecting **Debug** -> **Start Debugging**. As an alternative, you can press **F5**.

   It may take time to initialize Visual Studio and the new app. Once it is complete, the browser will show the running app.

   ![Browser window showing running application that displays 'Hello World!'](azure-continuous-deployment/_static/04-browser-runapp.png)

2. After reviewing the running Web app, close the browser and click the "Stop Debugging" icon in the toolbar of Visual Studio to stop the app.

## Create a web app in the Azure Portal

The following steps will guide you through creating a web app in the Azure Portal.

1. Log in to the [Azure Portal](https://portal.azure.com)
2. TAP **NEW** at the top left of the Portal
3. TAP **Web + Mobile** > **Web App**

    ![Microsoft Azure Portal: New button: Web + Mobile under Marketplace: Web App button under Featured Apps](azure-continuous-deployment/_static/05-azure-newwebapp.png)

4.  In the **Web App** blade, enter a unique value for the **App Service Name**.

    ![Web App blade](azure-continuous-deployment/_static/06-azure-newappblade.png)

    >[!NOTE]
    >The **App Service Name** name needs to be unique. The portal will enforce this rule when you attempt to enter the name. After you enter a different value, you'll need to substitute that value for each occurrence of **SampleWebAppDemo** that you see in this tutorial.

	&nbsp;
	
    Also in the **Web App** blade, select an existing **App Service Plan/Location** or create a new one. If you create a new plan, select the pricing tier, location, and other options. For more information on App Service plans, [Azure App Service plans in-depth overview](https://azure.microsoft.com/documentation/articles/azure-web-sites-web-hosting-plans-in-depth-overview/).

5.  Click **Create**. Azure will provision and start your web app.

    ![Azure Portal: Sample Web App Demo 01 Essentials blade](azure-continuous-deployment/_static/07-azure-webappblade.png)

## Enable Git publishing for the new web app

Git is a distributed version control system that you can use to deploy your Azure App Service web app. You'll store the code you write for your web app in a local Git repository, and you'll deploy your code to Azure by pushing to a remote repository.

1. Log into the [Azure Portal](https://portal.azure.com), if you're not already logged in.

2. Click **Browse**, located at the bottom of the navigation pane.

3. Click **Web Apps** to view a list of the web apps associated with your Azure subscription.

4. Select the web app you created in the previous section of this tutorial.

5. If the **Settings** blade is not shown, select **Settings** in the **Web App** blade.

6. In the **Settings** blade, select **Deployment source** > **Choose Source** > **Local Git Repository**.

   ![Settings blade: Deployment source blade: Choose source blade](azure-continuous-deployment/_static/08-azure-localrepository.png)

7. Click **OK**.

8. If you have not previously set up deployment credentials for publishing a web app or other App Service app, set them up now:

   * Click **Settings** > **Deployment credentials**. The **Set deployment credentials** blade will be displayed.

   * Create a user name and password.  You'll need this password later when setting up Git.

   * Click **Save**.

9. In the **Web App** blade, click **Settings** > **Properties**. The URL of the remote Git repository that you'll deploy to is shown under **GIT URL**.

10. Copy the **GIT URL** value for later use in the tutorial.

   ![Azure Portal: application Properties blade](azure-continuous-deployment/_static/09-azure-giturl.png)

## Publish your web app to Azure App Service

In this section, you will create a local Git repository using Visual Studio and push from that repository to Azure to deploy your web app. The steps involved include the following:

   * Add the remote repository setting using your GIT URL value, so you can deploy your local repository to Azure.

   * Commit your project changes.

   * Push your project changes from your local repository to your remote repository on Azure.

&nbsp;
   
1.  In **Solution Explorer** right-click **Solution 'SampleWebAppDemo'** and select **Commit**. The **Team Explorer** will be displayed.

    ![Team Explorer Connect tab](azure-continuous-deployment/_static/10-team-explorer.png)

2.  In **Team Explorer**, select the **Home** (home icon) > **Settings** > **Repository Settings**.

3.  In the **Remotes** section of the **Repository Settings** select **Add**. The **Add Remote** dialog box will be displayed.

4.  Set the **Name** of the remote to **Azure-SampleApp**.

5.  Set the value for **Fetch** to the **Git URL** that you copied from Azure earlier in this tutorial. Note that this is the URL that ends with **.git**.

    ![Edit Remote dialog](azure-continuous-deployment/_static/11-add-remote.png)

    >[!NOTE]
    >As an alternative, you can specify the remote repository from the **Command Window** by opening the **Command Window**, changing to your project directory, and entering the command. For example:`git remote add Azure-SampleApp https://me@sampleapp.scm.azurewebsites.net:443/SampleApp.git`

6.  Select the **Home** (home icon) > **Settings** > **Global Settings**. Make sure you have your name and your email address set. You may also need to select **Update**.

7.  Select **Home** > **Changes** to return to the **Changes** view.

8.  Enter a commit message, such as **Initial Push #1** and click **Commit**. This action will create a *commit* locally. Next, you need to *sync* with Azure.

    ![Team Explorer Connect tab](azure-continuous-deployment/_static/12-initial-commit.png)

    >[!NOTE]
    >As an alternative, you can commit your changes from the **Command Window** by opening the **Command Window**, changing to your project directory, and entering the git commands. For example:
    >
    >`git add .`
    >
    >`git commit -am "Initial Push #1"`

9.  Select **Home** > **Sync** > **Actions** > **Open Command Prompt**. The command prompt will open to your project directory.

10.  Enter the following command in the command window:

    `git push -u Azure-SampleApp master`

11.  Enter your Azure **deployment credentials** password that you created earlier in Azure.

    >[!NOTE]
    >Your password will not be visible as you enter it.

    This command will start the process of pushing your local project files to Azure. The output from the above command ends with a message that deployment was successful.
        
    ```
    remote: Finished successfully.
    remote: Running post deployment command(s)...
    remote: Deployment successful.
    To https://username@samplewebappdemo01.scm.azurewebsites.net:443/SampleWebAppDemo01.git
    * [new branch]      master -> master
    Branch master set up to track remote branch master from Azure-SampleApp.
    ```
    > [!NOTE]
    > If you need to collaborate on a project, you should consider pushing to [GitHub](https://github.com) in between pushing to Azure.
 
### Verify the Active Deployment

You can verify that you successfully transferred the web app from your local environment to Azure. You'll see the listed successful deployment.

1. In the [Azure Portal](https://portal.azure.com), select your web app. Then, select **Settings** > **Continuous deployment**.

   ![Azure Portal: Settings blade: Deployments blade showing successful deployment](azure-continuous-deployment/_static/13-verify-deployment.png)

## Run the app in Azure

Now that you have deployed your web app to Azure, you can run the app.

This can be done in two ways:

* In the Azure Portal, locate the web app blade for your web app, and click **Browse** to view your app in your default browser.

* Open a browser and enter the URL for your web app. For example:

  `http://SampleWebAppDemo.azurewebsites.net`

## Update your web app and republish

After you make changes to your local code, you can republish.

1.  In **Solution Explorer** of Visual Studio, open the *Startup.cs* file.

2.  In the `Configure` method, modify the `Response.WriteAsync` method so that it appears as follows:

    ```aspx-cs
    await context.Response.WriteAsync("Hello World! Deploy to Azure.");
    ```
3.  Save changes to *Startup.cs*.

4.  In **Solution Explorer**, right-click **Solution 'SampleWebAppDemo'** and select **Commit**. The **Team Explorer** will be displayed.

5.  Enter a commit message, such as:

    ```none
    Update #2
    ```

6.  Press the **Commit** button to commit the project changes.

7.  Select **Home** > **Sync** > **Actions** > **Push**.

>[!NOTE]
>As an alternative, you can push your changes from the **Command Window** by opening the **Command Window**, changing to your project directory, and entering a git command. For example:
>
>`git push -u Azure-SampleApp master`

## View the updated web app in Azure

View your updated web app by selecting **Browse** from the web app blade in the Azure Portal or by opening a browser and entering the URL for your web app. For example:

   `http://SampleWebAppDemo.azurewebsites.net`

## Additional Resources

* [Publishing and Deployment](index.md)

* [Project Kudu](https://github.com/projectkudu/kudu/wiki)
