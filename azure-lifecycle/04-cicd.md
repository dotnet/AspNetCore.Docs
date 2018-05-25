# Continuous Integration and Continuous Deployment

## Overview

In the previous chapter, you created a local Git repository containing the Simple Feed Reader app. In this chapter, you'll publish that code to a GitHub repository. Once the code is hosted in GitHub, [Visual Studio Team Services](https://docs.microsoft.com/vsts/) (VSTS) will be used to construct a DevOps pipeline. The pipeline enables continuous builds and deployments of the app. Any commit to the GitHub repository will trigger a build and a release to Azure.

In this section, you'll complete the following tasks:

* Publish the app's code to GitHub
* Create a Team Project in VSTS
* Configure access to your GitHub repository
* Create a build definition
* Create a release definition
* Commit changes to GitHub and automatically deploy to Azure
* Examine the VSTS CI/CD pipeline

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

## Prepare web app for CI/CD

1. Open the Azure portal, and navigate to the *staging (mywebapp<unique_number>/staging)* Web App.
2. Click **Deployment options**. A new panel appears. Click **Disconnect** to remove the local Git source control configuration that was added in the previous chapter. Confirm the removal operation by clicking the **Yes** button.
3. Navigate to the *mywebapp<unique_number>* App Service.
4. Click **Deployment options**. A new panel appears. Click **Disconnect** to remove the local Git source control configuration that was added in the previous chapter. Confirm the removal operation by clicking the **Yes** button.
5. Click **Continuous Delivery (Preview)**.
6. Click the **Configure** button. A **Configure Continuous Delivery** panel appears.
7. Navigate to the sections listed below to complete the configuration.

### Choose repository

Click the **Choose repository** option, and follow these steps:

1. Select *GitHub* from the **Code repository** drop-down.
2. Select *<GitHub_username>/simple-feed-reader* from the **Repository** drop-down.
3. Select *master* from the **Branch** drop-down.
4. Click the **OK** button to save your selections.

### Configure Continuous Delivery

Click the **Configure Continuous Delivery** option, and follow these steps:

1. Select *ASP.NET Core* from the **Web Application framework** drop-down. This selection is important. It determines the build definition template to be used.
2. Click the *Use existing* option of the **Visual Studio Team Service account** toggle button.
3. Select your VSTS account name from the **Account name** drop-down.
4. Select the team project within the selected VSTS account from the **Project name** drop-down.
5. Click the **OK** button to save your selections.

### Configure deployment

Click the **Configure deployment** option, and follow these steps:

1. Click the *YES* option of the **Deploy to staging** toggle button. Without this change, the default behavior is to deploy to production.
2. Select the *Use existing* radio button.
3. Select *staging* from the drop-down.
4. Click the **OK** button to save your selections.

Click the **OK** button on the **Configure Continuous Delivery** panel. A build definition and a release definition were created. Additionally, a build was triggered. When the build succeeds, a release to the production environment is triggered. Click the **Build triggered** link to monitor the build's progress.

## Configure access to your GitHub repository

1. When project creation completes, a get started page is displayed. Expand the **or build code from an external repository** accordion, and click the **Setup Build** button.
2. Select the **GitHub** option from the **Select a source** section.
3. Authorization is required before VSTS can access your GitHub repository. Enter *<GitHub_username> GitHub connection* in the **Connection name** textbox.
4. If two-factor authentication is enabled on your GitHub account, a personal access token is required. In that case, click the **Authorize with a GitHub personal access token** link. See the [official GitHub personal access token creation instructions] for help. Only the *repo* scope of permissions is needed. Otherwise, click the **Authorize using OAuth** button. If successful, a new service endpoint is created.
5. Click the ellipsis button next to the **Repository** button. Select the *<GitHub_username>/simple-feed-reader* repository from the list. Click the **Select** button.
6. Select the *master* branch from the **Default branch for manual and scheduled builds** drop-down. Click the **Continue** button.

## Commit changes to GitHub and automatically deploy to Azure

## Examine the VSTS CI/CD pipeline

<!-- TODO
NOTES:
A build definition was created with the name *mywebapp<unique_number> - CI*.

Upon completion, the build has produced a *.zip* file including the assets to be published. The release definition, to be created in the next section, deploys those assets to Azure.
-->

## Summary

## Additional reading
