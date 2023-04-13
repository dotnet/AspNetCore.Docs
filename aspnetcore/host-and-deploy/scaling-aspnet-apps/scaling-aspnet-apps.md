---
title: Scaling ASP.NET Core Apps on Azure
author: alexwolfmsft
description: Learn how to horizontally scale ASP.NET Core apps on Azure and address common architectural challenges
ms.author: alexwolf
ms.custom: mvc
uid: host-and-deploy/scaling-aspnet-apps/scaling-aspnet-apps
ms.date: 8/31/2022
---
# Deploying and scaling an ASP.NET Core app on Azure Container Apps

Apps deployed to Azure that experience intermittent high demand benefit from scalability to meet demand. Scalable apps can scale out to ensure capacity during workload peaks and then scale down automatically when the peak drops, which can lower costs. Horizontal scaling (scaling out) adds new instances of a resource, such as VMs or database replicas. This article demonstrates how to deploy a horizontally scalable ASP.NET Core app to [Azure container apps](/azure/container-apps/overview) by completing the following tasks:

1. [Set up the sample project](#set-up-the-sample-project)
1. [Deploy the app to Azure Container Apps](#deploy-the-app-to-azure-container-apps)
1. [Scale and troubleshoot the app](#scale-and-troubleshoot-the-app)
1. [Create the Azure Services](#create-the-azure-services)
1. [Connect the Azure services](#connect-the-azure-services)
1. [Configure and redeploy the app](#configure-and-redeploy-the-app)

This article uses Razor Pages, but most of it applies to other ASP.NET Core apps.

In some cases, basic ASP.NET Core apps are able to scale without special considerations. However, apps that utilize certain framework features or architectural patterns require extra configurations, including the following:

* **Secure form submissions**: Razor Pages, MVC and Web API apps often rely on form submissions. By default these apps use [cross site forgery tokens](xref:security/anti-request-forgery) and internal data protection services to secure requests. When deployed to the cloud, these apps must be configured to manage data protection service concerns in a secure, centralized location.

* **SignalR circuits**: Blazor Server apps require the use of a centralized [Azure SignalR service](/azure/azure-signalr/signalr-overview) in order to securely scale. These services also utilize the data protection services mentioned previously.

* **Centralized caching or state management services**: Scalable apps may use [Azure Cache for Redis](/azure/azure-cache-for-redis/cache-overview) to provide distributed caching. [Azure storage](/azure/storage/common/storage-introduction) may be needed to store state for frameworks such as [Microsoft Orleans](/dotnet/orleans/overview), which can help write apps that manage state across many different app instances.

The steps in this article demonstrate how to properly address the preceding concerns by deploying a scalable app to Azure Container Apps. Most of the concepts in this tutorial also apply when scaling [Azure App Service](/azure/app-service/overview) instances.

## Set up the sample project

Use the GitHub Explorer sample app to follow along with this tutorial. Clone the app from GitHub using the following command:

```dotnetcli
git clone "https://github.com/dotnet/AspNetCore.Docs.Samples.git"
```

Navigate to the `/tutorials/scalable-razor-apps/start` folder and open the `ScalableRazor.csproj`.

The sample app uses a search form to browse GitHub repositories by name. The form relies on the built-in ASP.NET Core data protection services to handle anti-forgery concerns. By default, when the app scales horizontally on Container Apps, the data protection service throws an exception. 

#### Test the app

1. Launch the app in Visual Studio. The project includes a Docker file, which means that the arrow next to the run button can be selected to start the app using either a Docker Desktop setup or the standard ASP.NET Core local web server.

Use the search form to browse for GitHub repositories by name.

:::image type="content" source="./media/scaling-app-screenshot.png" alt-text="A screenshot showing the GitHub Explorer app.":::

## Deploy the app to Azure Container Apps

Visual Studio is used to deploy the app to Azure Container Apps. Container apps provide a managed service designed to simplify hosting containerized apps and microservices.

> [!NOTE]
> Many of the resources created for the app require a location. For this app, location isn't important. A real app should select a location closest to the clients. You may want to select a location near you.

1. In Visual Studio solution explorer, right click on the top level project node and select **Publish**.
1. In the publishing dialog, select **Azure** as the deployment target, and then select **Next**.
1. For the specific target, select **Azure Container Apps (Linux)**, and then select **Next**.
1. Create a new container app to deploy to. Select the green **+** icon to open a new dialog and enter the following values:

    :::image type="content" source="./media/scaling-deploy-visual-studio-small.png" lightbox="./media/scaling-deploy-visual-studio.png" alt-text="A screenshot showing Visual Studio deployment.":::

    * **Container app name**: Leave the default value or enter a name.
    * **Subscription name**: Select the subscription to deploy to.
    * **Resource group**: Select **New** and create a new resource group called *msdocs-scalable-razor*.
    * **Container apps environment**: Select **New** to open the container apps environment dialog and enter the following values:
        * **Environment name**: Keep the default value.
        * **Location**: Select a location near you.
        * **Azure Log Analytics Workspace**: Select **New** to open the log analytics workspace dialog.
            * **Name**: Leave the default value.
            * **Location**: Select a location near you and then select **Ok** to close the dialog.
        * Select **Ok** to close the container apps environment dialog.
    * Select **Create** to close the original container apps dialog. Visual Studio creates the container app resource in Azure.
1. Once the resource is created, make sure it's selected in the list of container apps, and then select **Next**.
1. You'll need to create an Azure Container Registry to store the published image artifact for your app. Select the green **+** icon on the container registry screen. 

    :::image type="content" source="./media/scaling-create-new.png" alt-text="A screenshot showing how to create a new container registry.":::

1. Leave the default values, and then select **Create**.

    :::image type="content" source="./media/scaling-new-registry-small.png" lightbox="./media/scaling-new-registry.png" alt-text="A screenshot showing the values for a new container registry.":::

1. After the container registry is created, make sure it's selected, and then select finish to close the dialog workflow and display a summary of the publishing profile.
    
    If Visual Studio prompts you to enable the Admin user to access the published docker container, select **Yes**.

1. Select **Publish** in the upper right of the publishing profile summary to deploy the app to Azure.

When the deployment finishes, Visual Studio launches the browser to display the hosted app. Search for `Microsoft` in the form field, and a list of repositories is displayed.

## Scale and troubleshoot the app

The app is currently working without any issues, but we'd like to scale the app across more instances in anticipation of high traffic volumes.

1. In the Azure portal, search for the `razorscaling-app-****` container app in the top level search bar and select it from the results.
1. On the overview page, select **Scale** from the left navigation, and then select **+ Edit and deploy**.
1. On the revisions page, switch to the **Scale** tab.
1. Set both the min and max instances to **4** and then select **Create**. This configuration change guarantees your app is scaled horizontally across four instances.

Navigate back to the app. When the page loads, at first it appears everything is working correctly. However, when a search term is entered and submitted, an error may occur. If an error is not displayed, submit the form several more times.

#### Troubleshooting the error

It's not immediately apparent why the search requests are failing. The browser tools indicate a 400 Bad Request response was sent back. However, you can use the logging features of container apps to diagnose errors occurring in your environment.

1. On the overview page of the container app, select **Logs** from the left navigation.
1. On the **Logs** page, close the pop-up that opens and navigate to the **Tables** tab.
1. Expand the **Custom Logs** item to reveal the **ContainerAppConsoleLogs_CL** node. This table holds various logs for the container app that can be queried to troubleshoot problems.

    :::image type="content" source="./media/scaling-logs-small.png" lightbox="./media/scaling-logs.png" alt-text="A screenshot showing the container app logs.":::

1. In the query editor, compose a basic query to search the **ContainerAppConsoleLogs_CL Logs** table for recent exceptions, such as the following script:

    ```KQL
    ContainerAppConsoleLogs_CL
    | where Log_s contains "exception"
    | sort by TimeGenerated desc
    | limit 500
    | project ContainerAppName_s, Log_s
    ```

    The preceding query searches the **ContainerAppConsoleLogs_CL** table for any rows that contain the word exception. The results are ordered by the time generated, limited to 500 results, and only include the **ContainerAppName_s** and **Log_s** columns to make the results easier to read.

1. Select **Run**,  a list of results is displayed. Read through the logs and note that most of them are related to antiforgery tokens and cryptography.

    :::image type="content" source="./media/scaling-troubleshoot-small.png" lightbox="./media/scaling-troubleshoot.png" alt-text="A screenshot showing the logs query.":::

    > [!IMPORTANT]
    > The errors in the app are caused by the .NET data protection services. When multiple instances of the app are running, there is no guarantee that the HTTP POST request to submit the form is routed to the same container that initially loaded the page from the HTTP GET request. If the requests are handled by different instances, the antiforgery tokens aren't handled correctly and an exception occurs.

    In the steps ahead, this issue is resolved by centralizing the data protection keys in an Azure storage service and protecting them with Key Vault.

## Create the Azure Services

To resolve the preceding errors,  the following services are created and connected to the app:

* [Azure Storage Account](/azure/storage/common/storage-account-overview): Handles storing data for the Data Protection Services. Provides a centralized location to store key data as the app scales. Storage accounts can also be used to hold documents, queue data, file shares, and almost any type of blob data.
* [Azure KeyVault](/azure/key-vault/general/basic-concepts): This service stores secrets for an app, and is used to help manage encryption concerns for the Data Protection Services.

#### Create the storage account service

1. In the Azure portal search bar, enter `Storage accounts` and select the matching result.
1. On the storage accounts listing page, select **+ Create**.
1. On the **Basics** tab, enter the following values:
    * **Subscription**: Select the same subscription that you chose for the container app.
    * **Resource Group**: Select the *msdocs-scalable-razor* resource group you created previously.
    * **Storage account name**: Name the account *scalablerazorstorageXXXX* where the X's are random numbers of your choosing. This name must be unique across all of Azure.
    * **Region**: Select the same region you previously selected.
1. Leave the rest of the values at their default and select **Review**. After Azure validates the inputs, select **Create**.

Azure provisions the new storage account. When the task completes, choose **Go to resource** to view the new service.

#### Create the storage container

Create a Container to store the app's data protection keys.

1. On the overview page for the new storage account, select **Storage browser** on the left navigation.
1. Select **Blob containers**.
1. Select **+ Add container** to open the **New container** flyout menu.
1. Enter a name of *scalablerazorkeys*, leave the rest of the settings at their defaults, and then select **Create**.

The new containers appear on the page list.

#### Create the key vault service

Create a key vault to hold the keys that protect the data in the blob storage container.

1. In the Azure portal search bar, enter `Key Vault` and select the matching result.
1. On the key vault listing page, select **+ Create**.
1. On the **Basics** tab, enter the following values:
    * **Subscription**: Select the same subscription that was previously selected.
    * **Resource Group**: Select the *msdocs-scalable-razor* resource group previously created.
    * **Key Vault name**: Enter the name *scalablerazorvaultXXXX*.
    * **Region**: Select a region near your location.
1. Leave the rest of the settings at their default, and then select **Review + create**. Wait for Azure to validate your settings, and then select **Create**.

Azure provisions the new key vault. When the task completes, select **Go to resource** to view the new service.

#### Create the key

Create a secret key to protect the data in the blob storage account.

1. On the main overview page of the key vault, select **Keys** from the left navigation.
1. On the **Create a key** page, select **+ Generate/Import** to open the **Create a key** flyout menu. 
1. Enter *razorkey* in the **Name** field. Leave the rest of the settings at their default values and then select **Create**. A new key appears on the key list page.

## Connect the Azure Services

The Container App requires a secure connection to the storage account and the key vault services in order to resolve the data protection errors and scale correctly. The new services are connected together using the following steps:

> [!IMPORTANT]
> Security role assignments through Service Connector and other tools typically take a minute or two to propagate, and in some rare cases can take up to eight minutes.

#### Connect the storage account

1. In the Azure portal, navigate to the Container App overview page.
1. On the left navigation, select **Service connector**
1. On the Service Connector page, choose **+ Create** to open the **Creation Connection** flyout panel and enter the following values:
    * **Container**: Select the Container App created previously.
    * **Service type**: Choose **Storage - blob**.
    * **Subscription**: Select the subscription previously used.
    * **Connection name**: Leave the default value.
    * **Storage account**: Select the storage account created previously.
    * **Client type**: Select **.NET**.
1. Select **Next: Authentication** to progress to the next step.
1. Select **System assigned managed identity** and choose **Next: Networking**.
1. Leave the default networking options selected, and then select **Review + Create**.
1. After Azure validates the settings, select **Create**.

The service connector enables a system-assigned managed identity on the container app. It also assigns a role of **Storage Blob Data Contributor** to the identity so it can perform data operations on the storage containers.

#### Connect the key vault

1. In the Azure portal, navigate to your Container App overview page.
1. On the left navigation, select **Service connector**.
1. On the Service Connector page, choose **+ Create** to open the **Creation Connection** flyout panel and enter the following values:
    * **Container**: Select the container app created previously.
    * **Service type**: Choose **Key Vault**.
    * **Subscription**: Select the subscription previously used.
    * **Connection name**: Leave the default value.
    * **Key vault**: Select the key vault created previously.
    * **Client type**: Select **.NET**.
1. Select **Next: Authentication** to progress to the next step.
1. Select **System assigned managed identity** and choose **Next: Networking**.
1. Leave the default networking options selected, and then select **Review + Create**.
1. After Azure validates the settings, select **Create**.

The service connector assigns a role to the identity so it can perform data operations on the key vault keys.

## Configure and redeploy the app

The necessary Azure resources have been created. In this section the app code is configured to use the new resources.

1. Install the following NuGet packages:

    * **Azure.Identity**: Provides classes to work with the Azure identity and access management services.
    * **Microsoft.Extensions.Azure**: Provides helpful extension methods to perform core Azure configurations.
    * **Azure.Extensions.AspNetCore.DataProtection.Blobs**: Allows storing ASP.NET Core DataProtection keys in Azure Blob Storage so that keys can be shared across several instances of a web app.
    * **Azure.Extensions.AspNetCore.DataProtection.Keys**: Enables protecting keys at rest using the Azure Key Vault Key Encryption/Wrapping feature.

    ```dotnetcli
    dotnet add package Azure.Identity
    dotnet add package Microsoft.Extensions.Azure
    dotnet add package Azure.Extensions.AspNetCore.DataProtection.Blobs
    dotnet add package Azure.Extensions.AspNetCore.DataProtection.Keys
    ```

1. Update `Program.cs` with the following highlighted code:

    :::code language="csharp" source="~/../AspNetCore.Docs.Samples/tutorials/scalable-razor-apps/end/Program.cs" id="snippet_ProgramConfigurations" highlight="1-4,6-7,13-19":::

The preceding changes allow the app to manage data protection using a centralized, scalable architecture. `DefaultAzureCredential` discovers the managed identity configurations enabled earlier when the app is redeployed.

Update the placeholders in `AzureURIs` section of the `appsettings.json` file to include the following:

1. Replace the `<storage-account-name>` placeholder with the name of the `scalablerazorstorageXXXX` storage account.
1. Replace the `<container-name>` placeholder with the name of the `scalablerazorkeys` storage container.
1. Replace the `<key-vault-name>` placeholder with the name of the `scalablerazorvaultXXXX` key vault.
1. Replace the `<key-name>` placeholder in the key vault URI with the `razorkey` name created previously.

    :::code language="csharp" source="~/../AspNetCore.Docs.Samples/tutorials/scalable-razor-apps/end/appsettings.json" highlight="9-12":::

#### Redeploy the app

The app is now configured correctly to use the Azure services created previously. Redeploy the app for the code changes to be applied.

1. Right click on the project node in the solution explorer and select **Publish**.
1. On the publishing profile summary view, select the **Publish** button in the upper right corner.

Visual Studio redeploys the app to the container apps environment created previously. When the processes finished, the browser launches to the app home page.

Test the app again by searching for *Microsoft* in the search field. The page should now reload with the correct results every time you submit.

## Configure roles for local development

The existing code and configuration of the app can also work while running locally during development. The `DefaultAzureCredential` class configured previously is able to pick up local environment credentials to authenticate to Azure Services. You'll need to assign the same roles to your own account that were assigned to your app's managed identity in order for the authentication to work. This should be the same account you use to log into Visual Studio or the Azure CLI.

#### Sign-in to your local development environment

You'll need to be signed in to the Azure CLI, Visual Studio, or Azure PowerShell for your credentials to be picked up by `DefaultAzureCredential`.

## [Azure CLI](#tab/login-azure-cli)

```azurecli
az login
```

## [Visual Studio](#tab/login-visual-studio)

Sign in to Azure using the account settings dialog, which can be accessed in the upper right of the Visual Studio interface.

:::image type="content" source="./media/scaling-visual-studio-account.png" alt-text="A screenshot showing the Visual Studio account sign-in.":::

## [PowerShell](#tab/login-powershell)

```powershell
Connect-AzAccount
```

---

#### Assign roles to your developer account

1. In the Azure portal, navigate to the `scalablerazor****` storage account created previously.
1. Select **Access Control (IAM)** from the left navigation.
1. Choose **+ Add** and then **Add role assignment** from the drop-down menu.
1. On the **Add role assignment** page, search for `Storage blob data contributor`, select the matching result, and then select **Next**.
1. Make sure **User, group, or service principal** is selected, and then select **+ Select members**.
1. In the **Select members** flyout, search for your own *user@domain* account and select it from the results.
1. Choose **Next** and then select **Review + assign**. After Azure validates the settings, select **Review + assign** again.

As previously stated, role assignment permissions might take a minute or two to propagate, or in rare cases up to eight minutes.

Repeat the previous steps to assign a role to your account so that it can access the key vault service and secret.

1. In the Azure portal, navigate to the `razorscalingkeys` key vault created previously.
1. Select **Access Control (IAM)** from the left navigation.
1. Choose **+ Add** and then **Add role assignment** from the drop-down menu.
1. On the **Add role assignment** page, search for `Key Vault Crypto Service Encryption User`, select the matching result, and then select **Next**.
1. Make sure **User, group, or service principal** is selected, and then select **+ Select members**.
1. In the **Select members** flyout, search for your own *user@domain* account and select it from the results.
1. Choose **Next** and then select **Review + assign**. After Azure validates your settings, select **Review + assign** again.

You may need to wait again for this role assignment to propagate.

You can then return to Visual Studio and run the app locally. The code should continue to function as expected. `DefaultAzureCredential` uses your existing credentials from Visual Studio or the Azure CLI.

[!INCLUDE[](~/includes/reliableWAP_H2.md)]