# Continuous Integration and Continuous Deployment

## Overview

In the previous chapter, you created a local Git repository containing the Simple Feed Reader app. In this chapter, you'll publish that code to a GitHub repository and construct a Visual Studio Team Services (VSTS) DevOps pipeline. The pipeline enables continuous builds and deployments of the app. Any commit to the GitHub repository triggers a build and a release to the Azure Web App's staging slot.

In this section, you'll complete the following tasks:

* Publish the app's code to GitHub
* Create a VSTS account
* Create a team project in VSTS
* Create a build definition
* Create a release definition
* Commit changes to GitHub and automatically deploy to Azure
* Examine the VSTS DevOps pipeline

## Publish the app's code to GitHub

1. Open a browser window, and navigate to `https://github.com`.
1. Click the **+** drop-down in the header, and select **New repository**:

    ![GitHub New Repository option](media/04/github-new-repo.png)

1. Select your account in the **Owner** drop-down, and enter *simple-feed-reader* in the **Repository name** textbox.
1. Click the **Create repository** button.
1. Open your local machine's command shell. Navigate to the directory in which the *simple-feed-reader* Git repository is stored.
1. Rename the existing *origin* remote to *upstream*. Execute the following command:
    ```console
    git remote rename origin upstream
    ```
1. Add a new *origin* remote pointing to your copy of the repository on GitHub. Execute the following command:
    ```console
    git remote add origin https://github.com/<GitHub_username>/simple-feed-reader/
    ```
1. Publish your local Git repository to the newly created GitHub repository. Execute the following command:
    ```console
    git push -u origin master
    ```
1. Open a browser window, and navigate to `https://github.com/<GitHub_username>/simple-feed-reader/`. Validate that your code appears in the GitHub repository.

## Configure the DevOps pipeline

1. Open the [Azure portal](https://portal.azure.com/), and navigate to the *staging (mywebapp<unique_number>/staging)* Web App.
1. Click **Deployment options**. A new panel appears. Click **Disconnect** to remove the local Git source control configuration that was added in the previous chapter. Confirm the removal operation by clicking the **Yes** button.
1. Navigate to the *mywebapp<unique_number>* App Service.
1. Click **Deployment options**. A new panel appears. Click **Disconnect** to remove the local Git source control configuration that was added in the previous chapter. Confirm the removal operation by clicking the **Yes** button.
1. Click **Continuous Delivery (Preview)**:

    ![Continuous Delivery (Preview) button](media/04/cd-preview.png)

1. Click the **Configure** button. A **Configure Continuous Delivery** panel appears:

    ![Configure Continuous Delivery panel](media/04/configure-cd.png)

1. Navigate to the sections listed below to complete the configuration. No modifications are needed to the **Setup load test** section.

### Choose repository

Click the **Source code: Choose repository** option, and follow these steps:

1. Select *GitHub* from the **Code repository** drop-down.
1. Select *<GitHub_username>/simple-feed-reader* from the **Repository** drop-down.
1. Select *master* from the **Branch** drop-down.
1. Click the **OK** button to save your selections.

### Configure Continuous Delivery

Click the **Build: Configure Continuous Delivery** option, and follow these steps:

1. Select *ASP.NET Core* from the **Web Application framework** drop-down. This selection is important. It determines the build definition template to be used.
1. Click the *Create new* option of the **Visual Studio Team Service account** toggle button.
1. Enter a unique name in the **Account name** textbox.
1. Select the region closest to you from the **Location** drop-down.
1. Click the **OK** button to save your selections.

### Configure deployment

Click the **Deploy: Configure deployment** option, and follow these steps:

1. Click the *YES* option of the **Deploy to staging** toggle button. Without this change, the default behavior is to deploy to production.
1. In the **Deployment slot** section, select the *Use existing* radio button. Select *staging* from the drop-down.
1. Click the **OK** button to save your selections.

    ![Configure deployment panel](media/04/configure-deployment-panel.png)

Click the **OK** button on the **Configure Continuous Delivery** panel. A new VSTS account is created and is accessible at `https://<account_name>.visualstudio.com` after a few minutes. A build definition and a release definition were created within a new team project named *MyFirstProject*. Additionally, a build was triggered. When the build succeeds, a release to the production environment is triggered. Click the **Build triggered** link to monitor the build's progress.

![Build triggered link](media/04/build-triggered-link.png)

## Commit changes to GitHub and automatically deploy to Azure

<!-- TODO -->

## Examine the VSTS DevOps pipeline

### Build definition

A build definition was created with the name *mywebapp<unique_number> - CI*. Upon completion, the build produces a *.zip* file including the assets to be published. The release definition deploys those assets to Azure.

<!-- TODO -->

### Release definition

A release definition was created with the name *mywebapp<unique_number> - CD*:

![release definition overview](media/04/release-definition-overview.png)

The two major components of the release definition are the **Artifacts** and the **Environments**. Clicking the box in the **Artifacts** section reveals the following panel:

![release definition artifacts](media/04/release-definition-artifacts.png)

The **Source (Build definition)** value represents the build definition to which this release definition is linked. The *.zip* file produced by a successful run of the build definition is provided to the *Production* environment for release to Azure. Click the *1 phase, 2 tasks* link in the *Production* environment box to view the release definition tasks:

![release definition tasks](media/04/release-definition-tasks.png)

The release definition consists of two tasks: *Deploy Azure App Service to Slot* and *Manage Azure App Service - Slot Swap*. Clicking the first task reveals the following task configuration:

![release definition deploy task](media/04/release-definition-task1.png)

The Azure subscription, service type, web app name, resource group, and deployment slot are defined in the deployment task. The **Package or folder** textbox contains the path to the *.zip* file to be extracted and deployed to the *staging* slot of the *mywebapp14997* web app.

Clicking the slot swap task reveals the following task configuration:

![release definition slot swap task](media/04/release-definition-task2.png)

As was seen in the previous task, the necessary subscription, resource group, service type, web app name, and deployment slot details are provided. The **Swap with Production** checkbox is checked. Consequently, the bits deployed to the *staging* slot are swapped into the production environment.

## Summary

<!-- TODO -->

## Additional reading

* [Build your ASP.NET Core app](https://docs.microsoft.com/vsts/build-release/apps/aspnet/build-aspnet-core)
* [Build and deploy to an Azure Web App](https://docs.microsoft.com/vsts/build-release/apps/cd/azure/aspnet-core-to-azure-webapp)