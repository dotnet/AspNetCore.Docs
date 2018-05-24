# Continuous Integration and Continuous Deployment

## Overview

In the previous chapter, you created a local Git repository containing the Simple Feed Reader app. In this chapter, you'll publish that code to a GitHub repository. Once the code is hosted in GitHub, [Visual Studio Team Services](https://docs.microsoft.com/vsts/) (VSTS) will be used to construct a DevOps pipeline. The pipeline enables continuous builds and deployments of the app. Any commit to the GitHub repository will trigger a build and a release to Azure.

In this section, you'll complete the following tasks:

* Publish the app's code to GitHub
* Create a Team Project in VSTS
* Configure access to your GitHub repository
* Create a build definition

<!-- * Configure VSTS and an Azure subscription
* Commit changes to GitHub and automatically deploy to Azure
* Examine the VSTS CI/CD pipeline -->

## Publish the app's code to GitHub

1. Open a browser window, and navigate to `https://github.com`.
2. Click the **+** drop-down in the header, and select **New repository**.
3. Select your account in the **Owner** drop-down, and enter *simple-feed-reader* in the **Repository name** textbox.
4. Click the **Create repository** button.
5. Open your local machine's command shell. Navigate to the directory in which the *simple-feed-reader* Git repository is stored.
6. Rename the existing *origin* remote to *upstream*. Execute the following command:
    ```console
    git remote rename origin upstream
    ```
7. Add a new *origin* remote pointing to your copy of the repository on GitHub. Execute the following command:
    ```console
    git remote add origin https://github.com/<GitHub_username>/simple-feed-reader/
    ```
8. Publish your local Git repository to the newly created GitHub repository. Execute the following command:
    ```console
    git push -u origin master
    ```
9. Open a browser window, and navigate to `https://github.com/<GitHub_username>/simple-feed-reader/`. Validate that your code is hosted in the GitHub repository.

## Create a Team Project in VSTS

1. Create a memorable name for the new team project. Enter a unique string in the textbox.
2. Select the **Git** radio button to enable source control with Git.
3. Click the **Continue** button. Wait for your project to be created.
4. Note the name of the team project, as it's needed to build the release definition.

## Configure access to your GitHub repository

1. When project creation completes, a get started page is displayed. Expand the **or build code from an external repository** accordion, and click the **Setup Build** button.
2. Select the **GitHub** option from the **Select a source** section.
3. Authorization is required before VSTS can access your GitHub repository. Enter *<GitHub_username> GitHub connection* in the **Connection name** textbox.
4. If two-factor authentication is enabled on your GitHub account, a personal access token is required. In that case, click the **Authorize with a GitHub personal access token** link. See the [official GitHub personal access token creation instructions] for help. Only the *repo* scope of permissions is needed. Otherwise, click the **Authorize using OAuth** button. If successful, a new service endpoint is created.
5. Click the ellipsis button next to the **Repository** button. Select the *<GitHub_username>/simple-feed-reader* repository from the list. Click the **Select** button.
6. Select the *master* branch from the **Default branch for manual and scheduled builds** drop-down. Click the **Continue** button.

## Create a build definition

1. Select **ASP.NET Core** from the list of build definition templates. Click the **Apply** button.
2. The **Tasks** tab displays the tasks necessary to complete the ASP.NET Core build. Notice that the first four tasks are calling into the .NET Core CLI.
3. Click the **Triggers** tab, and check the **Enable continuous integration** checkbox. Any time code is pushed to the *master* branch, the build is triggered as a result of this change.
4. Click the **Save & queue** button. The build definition is saved, and a modal dialog appears.
5. Select *Hosted VS2017* from the **Agent queue** drop-down, and click the **Save & queue** button. The build process has been triggered.
6. Click the build number link to view the build's progress.
7. Upon completion, the build has produced a *.zip* file containing the assets to be published. The release definition, to be created in the next section, is responsible for deploying those assets to Azure.

## Create a release definition

1. Click the **Releases** tab within the **Build and Release** page of the VSTS team project.
2. Click the **New definition** button.
3. Click the **Azure App Service Deployment** template, and click the **Apply** button.

## Configure the release environment

1. The release definition's **Pipeline** designer page appears. Click the existing **Environment 1** box. A blade appears with the environment's details. Replace the default name in the **Environment name** textbox with **Production**.
2. Click the **Tasks** tab.
3. Select the subscription, from the **Azure subscription** drop-down, under which the web app was deployed. Click the **Authorize** button to configure the required Azure service endpoint.
4. Once authorization succeeds, select *Web App* from the **App type** drop-down.
5. Select *mywebapp<unique_id>* from the **App service name** drop-down.
6. Click the **Save** button. A modal dialog appears. Enter a comment, if desired, and click the **OK** button.

## Configure the release artifact

1. Click the **Add artifact** box in the **Artifacts** box of the **Pipeline** tab.
2. Select the *Build* option from the **Source type** section.
3. Select the team project from the **Project** drop-down.
4. Select the build definition which was created in the previous section. This makes the association between the release definition and build definition. It allows the release definition to access any artifacts produced by the build definition.
5. Select *Latest* from the **Default version** drop-down. This option causes the latest build's artifacts to deploy.
6. Keep the default **Source alias** value, and click the **Add** button.
7. Click the **Continuous deployment trigger** lightning bolt icon in the **Artifacts** box. Change the toggle button to *Enabled*. This change causes a new release each time the associated build produces new artifacts.
8. Create a new build branch filter by clicking the **Add** button in the **Build branch filters** section. Select *Include* from the **Type** drop-down. Select *master* from the **Build branch** drop-down. With this filter, a release is triggered only for a successful build of the GitHub repository's *master* branch.
9. Click the **Save** button to preserve changes made to the release definition. A modal dialog appears. Enter a comment, if desired, and click the **OK** button.

## Summary

## Additional reading
