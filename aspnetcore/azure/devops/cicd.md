---
title: Continuous integration and deployment - DevOps with ASP.NET Core and Azure
author: CamSoper
description: Continuous integration and deployment in DevOps with ASP.NET Core and Azure
ms.author: scaddie
ms.date: 10/24/2018
ms.custom: "devx-track-csharp, mvc, seodec18"
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: azure/devops/cicd
---
# Continuous integration and deployment

In the previous chapter, you created a local Git repository for the Simple Feed Reader app. In this chapter, you'll publish that code to a GitHub repository and construct an Azure DevOps Services pipeline using Azure Pipelines. The pipeline enables continuous builds and deployments of the app. Any commit to the GitHub repository triggers a build and a deployment to the Azure Web App's staging slot.

In this section, you'll complete the following tasks:

* Publish the app's code to GitHub
* Disconnect local Git deployment
* Create an Azure DevOps organization
* Create a team project in Azure DevOps Services
* Create a build definition
* Create a release pipeline
* Commit changes to GitHub and automatically deploy to Azure
* Examine the Azure Pipelines pipeline

## Publish the app's code to GitHub

1. Open a browser window, and navigate to `https://github.com`.
1. Click the **+** drop-down in the header, and select **New repository**:

    ![GitHub New Repository option](media/cicd/github-new-repo.png)

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

## Disconnect local Git deployment

Remove the local Git deployment with the following steps. Azure Pipelines (an Azure DevOps service) both replaces and augments that functionality.

1. Open the [Azure portal](https://portal.azure.com/), and navigate to the *staging (mywebapp\<unique_number\>/staging)* Web App. The Web App can be quickly located by entering *staging* in the portal's search box:

    ![staging Web App search term](media/cicd/portal-search-box.png)

1. Click **Deployment Center**. A new panel appears. Click **Disconnect** to remove the local Git source control configuration that was added in the previous chapter. Confirm the removal operation by clicking the **Yes** button.
1. Navigate to the *mywebapp<unique_number>* App Service. As a reminder, the portal's search box can be used to quickly locate the App Service.
1. Click **Deployment Center**. A new panel appears. Click **Disconnect** to remove the local Git source control configuration that was added in the previous chapter. Confirm the removal operation by clicking the **Yes** button.

## Create an Azure DevOps organization

1. Open a browser, and navigate to the [Azure DevOps organization creation page](https://go.microsoft.com/fwlink/?LinkId=307137).
1. Type a unique name into the **Pick a memorable name** textbox to form the URL for accessing your Azure DevOps organization.
1. Select the **Git** radio button, since the code is hosted in a GitHub repository.
1. Click the **Continue** button. After a short wait, an account and a team project, named *MyFirstProject*, are created.

    ![Azure DevOps organization creation page](media/cicd/vsts-account-creation.png)

1. Open the confirmation email indicating that the Azure DevOps organization and project are ready for use. Click the **Start your project** button:

    ![Start your project button](media/cicd/vsts-start-project.png)

1. A browser opens to *\<account_name\>.visualstudio.com*. Click the *MyFirstProject* link to begin configuring the project's DevOps pipeline.

## Configure the Azure Pipelines pipeline

There are three distinct steps to complete. Completing the steps in the following three sections results in an operational DevOps pipeline.

### Grant Azure DevOps access to the GitHub repository

1. Expand the **or build code from an external repository** accordion. Click the **Setup Build** button:

    ![Setup Build button](media/cicd/vsts-setup-build.png)

1. Select the **GitHub** option from the **Select a source** section:

    ![Select a source - GitHub](media/cicd/vsts-select-source.png)

1. Authorization is required before Azure DevOps can access your GitHub repository. Enter *<GitHub_username> GitHub connection* in the **Connection name** textbox. For example:

    ![GitHub connection name](media/cicd/vsts-repo-authz.png)

1. If two-factor authentication is enabled on your GitHub account, a personal access token is required. In that case, click the **Authorize with a GitHub personal access token** link. See the [official GitHub personal access token creation instructions](https://help.github.com/articles/creating-a-personal-access-token-for-the-command-line/) for help. Only the *repo* scope of permissions is needed. Otherwise, click the **Authorize using OAuth** button.
1. When prompted, sign in to your GitHub account. Then select Authorize to grant access to your Azure DevOps organization. If successful, a new service endpoint is created.
1. Click the ellipsis button next to the **Repository** button. Select the *<GitHub_username>/simple-feed-reader* repository from the list. Click the **Select** button.
1. Select the *master* branch from the **Default branch for manual and scheduled builds** drop-down. Click the **Continue** button. The template selection page appears.

### Create the build definition

1. From the template selection page, enter *ASP.NET Core* in the search box:

    ![ASP.NET Core search on template page](media/cicd/vsts-template-selection.png)

1. The template search results appear. Hover over the **ASP.NET Core** template, and click the **Apply** button.
1. The **Tasks** tab of the build definition appears. Click the **Triggers** tab.
1. Check the **Enable continuous integration** box. Under the **Branch filters** section, confirm that the **Type** drop-down is set to *Include*. Set the **Branch specification** drop-down to *master*.

    ![Enable continuous integration settings](media/cicd/vsts-enable-ci.png)

    These settings cause a build to trigger when any change is pushed to the *master* branch of the GitHub repository. Continuous integration is tested in the [Commit changes to GitHub and automatically deploy to Azure](#commit-changes-to-github-and-automatically-deploy-to-azure) section.

1. Click the **Save & queue** button, and select the **Save** option:

    ![Save button](media/cicd/vsts-save-build.png)

1. The following modal dialog appears:

    ![Save build definition - modal dialog](media/cicd/vsts-save-modal.png)

    Use the default folder of *\\*, and click the **Save** button.

### Create the release pipeline

1. Click the **Releases** tab of your team project. Click the **New pipeline** button.

    ![Releases tab - New definition button](media/cicd/vsts-new-release-definition.png)

    The template selection pane appears.

1. From the template selection page, enter *App Service* in the search box:

    ![Release pipeline template search box](media/cicd/vsts-release-template-search.png)

1. The template search results appear. Hover over the **Azure App Service Deployment with Slot** template, and click the **Apply** button. The **Pipeline** tab of the release pipeline appears.

    ![Release pipeline Pipeline tab](media/cicd/vsts-release-definition-pipeline.png)

1. Click the **Add** button in the **Artifacts** box. The **Add artifact** panel appears:

    ![Release pipeline - Add artifact panel](media/cicd/vsts-release-add-artifact.png)

1. Select the **Build** tile from the **Source type** section. This type allows for the linking of the release pipeline to the build definition.
1. Select *MyFirstProject* from the **Project** drop-down.
1. Select the build definition name, *MyFirstProject-ASP.NET Core-CI*, from the **Source (Build definition)** drop-down.
1. Select *Latest* from the **Default version** drop-down. This option builds the artifacts produced by the latest run of the build definition.
1. Replace the text in the **Source alias** textbox with *Drop*.
1. Click the **Add** button. The **Artifacts** section updates to display the changes.
1. Click the lightning bolt icon to enable continuous deployments:

    ![Release pipeline Artifacts - lightning bolt icon](media/cicd/vsts-artifacts-lightning-bolt.png)

    With this option enabled, a deployment occurs each time a new build is available.
1. A **Continuous deployment trigger** panel appears to the right. Click the toggle button to enable the feature. It isn't necessary to enable the **Pull request trigger**.
1. Click the **Add** drop-down in the **Build branch filters** section. Choose the **Build Definition's default branch** option. This filter causes the release to trigger only for a build from the GitHub repository's *master* branch.
1. Click the **Save** button. Click the **OK** button in the resulting **Save** modal dialog.
1. Click the **Environment 1** box. An **Environment** panel appears to the right. Change the *Environment 1* text in the **Environment name** textbox to *Production*.

   ![Release pipeline - Environment name textbox](media/cicd/vsts-environment-name-textbox.png)

1. Click the **1 phase, 2 tasks** link in the **Production** box:

    ![Release pipeline - Production environment link.png](media/cicd/vsts-production-link.png)

    The **Tasks** tab of the environment appears.
1. Click the **Deploy Azure App Service to Slot** task. Its settings appear in a panel to the right.
1. Select the Azure subscription associated with the App Service from the **Azure subscription** drop-down. Once selected, click the **Authorize** button.
1. Select *Web App* from the **App type** drop-down.
1. Select *mywebapp/<unique_number/>* from the **App service name** drop-down.
1. Select *AzureTutorial* from the **Resource group** drop-down.
1. Select *staging* from the **Slot** drop-down.
1. Click the **Save** button.
1. Hover over the default release pipeline name. Click the pencil icon to edit it. Use *MyFirstProject-ASP.NET Core-CD* as the name.

    ![Release pipeline name](media/cicd/vsts-release-definition-name.png)

1. Click the **Save** button.

## Commit changes to GitHub and automatically deploy to Azure

1. Open *SimpleFeedReader.sln* in Visual Studio.
1. In Solution Explorer, open *Pages\Index.cshtml*. Change `<h2>Simple Feed Reader - V3</h2>` to `<h2>Simple Feed Reader - V4</h2>`.
1. Press **Ctrl**+**Shift**+**B** to build the app.
1. Commit the file to the GitHub repository. Use either the **Changes** page in Visual Studio's *Team Explorer* tab, or execute the following using the local machine's command shell:

    ```console
    git commit -a -m "upgraded to V4"
    ```

1. Push the change in the *master* branch to the *origin* remote of your GitHub repository:

    ```console
    git push origin master
    ```

    The commit appears in the GitHub repository's *master* branch:

    ![GitHub commit in master branch](media/cicd/github-commit.png)

    The build is triggered, since continuous integration is enabled in the build definition's **Triggers** tab:

    ![enable continuous integration](media/cicd/enable-ci.png)

1. Navigate to the **Queued** tab of the **Azure Pipelines** > **Builds** page in Azure DevOps Services. The queued build shows the branch and commit that triggered the build:

    ![queued build](media/cicd/build-queued.png)

1. Once the build succeeds, a deployment to Azure occurs. Navigate to the app in the browser. Notice that the "V4" text appears in the heading:

    ![updated app](media/cicd/updated-app-v4.png)

## Examine the Azure Pipelines pipeline

### Build definition

A build definition was created with the name *MyFirstProject-ASP.NET Core-CI*. Upon completion, the build produces a *.zip* file including the assets to be published. The release pipeline deploys those assets to Azure.

The build definition's **Tasks** tab lists the individual steps being used. There are five build tasks.

![build definition tasks](media/cicd/build-definition-tasks.png)

1. **Restore** &mdash; Executes the `dotnet restore` command to restore the app's NuGet packages. The default package feed used is nuget.org.
1. **Build** &mdash; Executes the `dotnet build --configuration release` command to compile the app's code. This `--configuration` option is used to produce an optimized version of the code, which is suitable for deployment to a production environment. Modify the *BuildConfiguration* variable on the build definition's **Variables** tab if, for example, a debug configuration is needed.
1. **Test** &mdash; Executes the `dotnet test --configuration release --logger trx --results-directory <local_path_on_build_agent>` command to run the app's unit tests. Unit tests are executed within any C# project matching the `**/*Tests/*.csproj` glob pattern. Test results are saved in a *.trx* file at the location specified by the `--results-directory` option. If any tests fail, the build fails and isn't deployed.

    > [!NOTE]
    > To verify the unit tests work, modify *SimpleFeedReader.Tests\Services\NewsServiceTests.cs* to purposefully break one of the tests. For example, change `Assert.True(result.Count > 0);` to `Assert.False(result.Count > 0);` in the `Returns_News_Stories_Given_Valid_Uri` method. Commit and push the change to GitHub. The build is triggered and fails. The build pipeline status changes to **failed**. Revert the change, commit, and push again. The build succeeds.

1. **Publish** &mdash; Executes the `dotnet publish --configuration release --output <local_path_on_build_agent>` command to produce a *.zip* file with the artifacts to be deployed. The `--output` option specifies the publish location of the *.zip* file. That location is specified by passing a [predefined variable](/azure/devops/pipelines/build/variables) named `$(build.artifactstagingdirectory)`. That variable expands to a local path, such as *c:\agent\_work\1\a*, on the build agent.
1. **Publish Artifact** &mdash; Publishes the *.zip* file produced by the **Publish** task. The task accepts the *.zip* file location as a parameter, which is the predefined variable `$(build.artifactstagingdirectory)`. The *.zip* file is published as a folder named *drop*.

Click the build definition's **Summary** link to view a history of builds with the definition:

![Screenshot showing build definition history](media/cicd/build-definition-summary.png)

On the resulting page, click the link corresponding to the unique build number:

![Screenshot showing build definition summary page](media/cicd/build-definition-completed.png)

A summary of this specific build is displayed. Click the **Artifacts** tab, and notice the *drop* folder produced by the build is listed:

![Screenshot showing build definition artifacts - drop folder](media/cicd/build-definition-artifacts.png)

Use the **Download** and **Explore** links to inspect the published artifacts.

### Release pipeline

A release pipeline was created with the name *MyFirstProject-ASP.NET Core-CD*:

![Screenshot showing release pipeline overview](media/cicd/release-definition-overview.png)

The two major components of the release pipeline are the **Artifacts** and the **Environments**. Clicking the box in the **Artifacts** section reveals the following panel:

![Screenshot showing release pipeline artifacts](media/cicd/release-definition-artifacts.png)

The **Source (Build definition)** value represents the build definition to which this release pipeline is linked. The *.zip* file produced by a successful run of the build definition is provided to the *Production* environment for deployment to Azure. Click the *1 phase, 2 tasks* link in the *Production* environment box to view the release pipeline tasks:

![Screenshot showing release pipeline tasks](media/cicd/release-definition-tasks.png)

The release pipeline consists of two tasks: *Deploy Azure App Service to Slot* and *Manage Azure App Service - Slot Swap*. Clicking the first task reveals the following task configuration:

![Screenshot showing release pipeline deploy task](media/cicd/release-definition-task1.png)

The Azure subscription, service type, web app name, resource group, and deployment slot are defined in the deployment task. The **Package or folder** textbox holds the *.zip* file path to be extracted and deployed to the *staging* slot of the *mywebapp\<unique_number\>* web app.

Clicking the slot swap task reveals the following task configuration:

![Screenshot showing release pipeline slot swap task](media/cicd/release-definition-task2.png)

The subscription, resource group, service type, web app name, and deployment slot details are provided. The **Swap with Production** check box is checked. Consequently, the bits deployed to the *staging* slot are swapped into the production environment.

## Additional reading

* [Create your first pipeline with Azure Pipelines](/azure/devops/pipelines/get-started-yaml)
* [Build and .NET Core project](/azure/devops/pipelines/languages/dotnet-core)
* [Deploy a web app with Azure Pipelines](/azure/devops/pipelines/targets/webapp)
