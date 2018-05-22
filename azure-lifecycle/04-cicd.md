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

## Configure access to your GitHub repository

1. When project creation completes, a get started page is displayed. Expand the **or build code from an external repository** accordion, and click the **Setup Build** button.
2. Select the **GitHub** option from the **Select a source** section.
3. Authorization is required before VSTS can access your GitHub repository. Enter *<GitHub_username> GitHub connection* in the **Connection name** textbox.
4. If two-factor authentication is enabled on your GitHub account, a personal access token is required. In that case, click the **Authorize with a GitHub personal access token** link. See the [official GitHub personal access token creation instructions] for help. Only the *repo* scope of permissions is needed. Otherwise, click the **Authorize using OAuth** button. If successful, a new service endpoint is created.
5. Click the ellipsis button next to the **Repository** button. Select the *<GitHub_username>/simple-feed-reader* repository from the list. Click the **Select** button.
6. Select the *master* branch from the **Default branch for manual and scheduled builds** drop-down. Click the **Continue** button.

## Create a build definition

1. Select **ASP.NET Core** from the list of build definition templates. Click the **Apply** button.
2. A build definition appears with a list of tasks to be executed.

## Summary

## Additional reading
