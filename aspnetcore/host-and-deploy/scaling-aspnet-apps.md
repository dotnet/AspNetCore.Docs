---
title: Scaling ASP.NET Core Apps on Azure
author: alexwolfmsft
description: Learn how to horizontally scale ASP.NET Core apps on Azure and address common architectural challenges
ms.author: alexwolf
ms.custom: mvc
ms.date: 08/25/2022
---
# Deploying and scaling an ASP.NET Core on Azure

Applications deployed to Azure must be able to scale in order to fully leverage cloud benefits. Properly architected apps should be able to dynamically scale horizontally across any number of instances without producing errors. ASP.NET Core apps are able to meet these requirements, but developers must implement certain configurations and architectural patterns to ensure success. This tutorial will demonstrate how to deploy a scalable Razor Pages app to Azure container apps by completing the following tasks:

1. Create a containerized ASP.NET Core app
1. Configure the application code
1. Create the Azure services
1. Deploy the app to Azure Container Apps
1. Connect the Azure Services
1. Scale the app
1. Configure roles for local development

In some cases, simple ASP.NET Core apps are able to scale without special considerations. However, apps that utilize certain framework features or architectural patterns require additional configurations, including the following:

* **Secure form submissions**: Razor Pages, MVC and Web API apps often rely on form submissions. By default these apps use cross site forgery tokens and internal data protection services to secure requests. When deployed to the cloud, these apps must be configured to use a managed data protection service concerns in a secure, centralized location.

* **SignalR circuits**: Blazor Server applications require the use of a centralized Azure SignalR service in order to scale properly and securely. These services also utilize the data protection services mentioned previously.

* **Centralized caching or state management services**: Scalable applications may use Azure Cache for Redis to provide distributed caching. Azure storage may be needed to store state for frameworks such as Orleans, which can assist in writing apps that manage state across many different app instances.

The steps ahead demonstrate how to properly address these concerns by deploying a scalable app to Azure Container Apps. Most of the concepts in this tutorial also apply when scaling Azure App Service instances.

## 1) Create a containerized ASP.NET Core app

This tutorial uses a Razor Pages app to demonstrate the concepts ahead. However, the same steps and concepts also apply to MVC and Web API projects.

1. On the main navigation menu in Visual Studio, select **File > New > Project...**.

1. In the **Create a new project** dialog, search for and select the  **ASP.NET Core Web App** template, and then choose **Next**.

1. For the **Project name**, enter *ScalableRazor* and choose a location for the project. Leave the rest of the settings at their default and select **Next**.

1. On the **Additional Information** dialog, make sure the following values are set:
    * **Framework**: Select **.NET 6.0**.
    * **Authentication type**: Select **None**.
    * **Configure for HTTPS**: Make sure this checkbox is checked.
    * **Enable Docker**: Make sure this checkbox is checked. This will generate a Dockerfile in the project that will be used to containerize the app.
    * **Docker OS**: Choose **Linux**.
    * **Do not use top-level statements**: Make sure this checkbox is unchecked.


Visual Studio will generate a new Razor Pages project for you.

## 2) Setup the application code and dependencies

To configure and connect to the required Azure services, you'll need to install the following NuGet packages in your project:

* **Azure.Identity**: Provides classes to work with the Azure identity and access management services.
* **Microsoft.AspNetCore.DataProtection**: Provides services to configure data protection.
* **Microsoft.Extensions.Azure**: Provides helpful extension methods to perform core Azure configurations.

## [Azure CLI](#tab/azure-cli)

You can use the dotnet add package command to add the required packages to your project:

```dotnetcli
dotnet add package Azure.Identity
dotnet add package Microsoft.AspNetCore.DataProtection
dotnet add package Microsoft.Extensions.Azure
```

## [Visual Studio](#tab/visual-studio)

// todo

---

Next, update the `Program.cs` code to match the following example:

```csharp
using Azure.Identity;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Azure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddAzureClientsCore();

// Todo: Update the placeholders with your service values
builder.Services.AddDataProtection()
                .PersistKeysToAzureBlobStorage(new Uri("<your-storage-account-uri>"), new DefaultAzureCredential())
                .ProtectKeysWithAzureKeyVault(new Uri($"https://<key-vault-name>.vault.azure.net/keys/<key-name>/"), new DefaultAzureCredential());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.MapRazorPages();
app.UseStaticFiles();
app.UseRouting();
app.Run();
```

The preceding example features a standard Razor Pages `Program` class with a few additional configurations to handle data protection using Azure Blob Storage and Key Vault. These changes will allow the app to manage data protection using a centralized, scalable architecture.

## 3) Create the Azure Services

To host and scale a .NET app you'll need to create one or more services in Azure. These services will handle common concerns such as application hosting, storage, caching, secrets and more. For this tutorial you'll need to create the following services:

* **Azure Container App**: This service will host your containerized app and scale to multiple instances as needed.
* **Azure Storage Account**: The storage service will handle storing data for the Data Protection Services of your app. This provides a centralized location to store key data as the app scales. Storage accounts can also be used to hold documents, queue data, file shares, and almost any type of blob data.
* **Azure KeyVault**: This service will be used to store secrets for your application, and be used to help manage encryption concerns for the Data Protection Services.

#### Create the Container App service

1. In the Azure portal search bar, enter *Container Apps* and select the matching result.
1. On the Container Apps listing page, select **+ Create**.
1. On the **Basics** tab, enter the following values:
    * **Subscription**: Select the subscription you'd like to use.
    * **Resource Group**: Choose **Create New** and name the new resource group *msdocs-scalable-razor*.
    * **Container app name**: Enter a value of *scalablerazor*.
    * **Region**: Select a region close to your location.
    * **Container Apps Environment**: Choose **Create new** and name the environment **scalablerazorenv**. Leave the rest of the settings at their default and select **Create**.
1. Azure will take a moment to provision the new services. When the task completes, click **Go to resource** to view your new container app.

#### Create and connect to the Storage Account service and container

1. In the Azure Portal search bar, enter *Storage account* and select the matching result.
1. On the storage accounts listing page, select **+ Create**.
1. On the **Basics** tab, enter the following values:
    * **Subscription**: Select the same subscription that chose for you Container App.
    * **Resource Group**: Select the *msdocs-scalable-razor* resource group you created previously.
    * **Storage account name**: Name the account scalablerazorXXXX where the X's are random numbers of your choosing. This name must be unique across all of Azure.
    * **Region**: Select a region that is close to you.
1. Leave the rest of the values at their default and select **Review**. After Azure validates your inputs, select **Create**.
1. Azure will take a moment to provision the new storage account. When the task completes, click **Go to resource** to view the new service.

Next you'll need to create the Container that will be used to store your app's data protection keys.

1. On the storage account overview page, select *Storage browser** on the left navigation.
1. Select **Blob containers**.
1. Select **+ Add container** to open the **New container** flyout menu.
1. Enter a name of *scalablerazorkeys*, leave the rest of the settings at their defaults, and then choose **Create**.

You should see the new container appear on the page list.

#### Create the Key Vault service and secret

Next you'll need to create the key vault service.

1. In the Azure Portal search bar, enter *Key Vault* and select the matching result
1. On the key vault listing page, select **+Create++.
1. On the **Basics** tab, enter the following values:
    * **Subscription**: Select the same subscription that chose for you Container App.
    * **Resource Group**: Select the *msdocs-scalable-razor* resource group you created previously.
    * **Key Vault name**: Enter the name *scalablerazorvault*.
1. Leave the rest of the settings at their default, and then select **Review + create**. Wait for Azure to validate your settings, and then choose **Create**.
1. Azure will take a moment to provision the new key vault. When the ask completes, click **Go to resource** to view the new service.

Next you need to create a secret key to protect the data in the blob storage account.

1. On the main key vault overview page, select **Keys** from the left navigation.
1. On the **Create a key** page, enter *razorkey* in the **Name** field. 
1. Leave the rest of the settings at their default values and then choose **Create**.

A new key should appear on the key list page.

## 4) Configure and deploy the app to Azure

Next you will build and deploy your app to the Azure Container app.

1. Inside Visual Studio, right click on the project node and select **Publish**.
1. In the publishing dialog, select Azure for the deployment target, and then choose **Next**.
1. For the **Specific target**, select **Azure Container Apps (Linux)**, and then choose **Next** again.
1. On the **Container App** screen, make sure to select the **Subscription** you created the container app in earlier. Select the **razorscaling** container app, and then choose **Next**.
1. You need to create an Azure Container Registry to store your app image. Select the green **+** icon on the right side of the dialog. 
    1. In the new dialog, for the **Resource group** make sure the **msdocs-razor-scaling** group you created earlier is selected, and then choose **Create**. Visual Studio will create the registry in Azure and return to the previous dialog.
1. Make sure the newly created registry is selected, and then select **Finish**.
1. Select the **Publish** button in the upper right corner of the publishing summary. Visual Studio will begin deploying the app, which may take a few moments to complete.
1. When the deployment finishes Visual Studio will launch the browser and open to your application. However, you should see an error page at this point. Although our app is running in Azure, the required services are not connected yet, so you'll do that next.

## 5) Connect the Azure Services

The Container App requires a secure connect to the storage account and key vault services in order for the data protection services to work properly. These services are also necessary for the app to scale correctly. You can connect your services together using the following steps:

> [!IMPORTANT]
> Security role assignments through Service Connector and other tools generally take a minute or two to propagate, and in some rare cases can take up to eight minutes.

#### Connect the storage account

1. In the Azure portal, navigate to your Container App overview page.
1. On the left navigation, select **Service connector**
1. On the Service Connector page, choose **+ Create** to open the **Creation Connection* flyout panel and enter the following values:
    * **Container**: Select the Container App you created previously.
    * **Service type**: Choose **Storage - blob**.
    * **Subscription**: Select the subscription you used previously.
    * **Connection name**: Leave the default value or enter a name of your choosing.
    * **Storage account**: Select the storage account you created earlier.
    * **Client type**: Select **.NET**.
1. Select **Next: Authentication** to progress to the next step.
1. Select **System assigned managed identity** and choose **Next: Networking**.
1. Leave the default networking options selected, and then choose **Review + Create**.
1. After Azure validates your settings, select **Create**.

#### Connect the key vault

1. In the Azure portal, navigate to your Container App overview page.
1. On the left navigation, select **Service connector**
1. On the Service Connector page, choose **+ Create** to open the **Creation Connection* flyout panel and enter the following values:
    * **Container**: Select the Container App you created previously.
    * **Service type**: Choose **Key Vault**.
    * **Subscription**: Select the subscription you used previously.
    * **Connection name**: Leave the default value or enter a name of your choosing.
    * **Key vault**: Select the key vault you created earlier.
    * **Client type**: Select **.NET**.
1. Select **Next: Authentication** to progress to the next step.
1. Select **System assigned managed identity** and choose **Next: Networking**.
1. Leave the default networking options selected, and then choose **Review + Create**.
1. After Azure validates your settings, select **Create**.

## 6) Scale the app

1. Navigate to the overview page of your Container App
1. Select **Scale** from the left navigation panel, and then choose **Edit and deploy**.
1. Switch to the **Scale tab**, and then set both the min and max replicas to *3*.
1. Select **Create**, and Azure will redeploy and scale your app up to three instances.
1. On the overview page of the container app, click on the **Application URL** link to launch your site in the browser again.
1. At this point your app should load and work correctly. You can further test this by entering data into the form and clicking submit. The form relies on data protection services, which means a successful submission validates your services are connected properly.

## 7) Configure roles for local development

The existing code and configuration of your app can also work while running locally during development. The `DefaultAzureCredential` class you configured earlier is able to pick up local environment credentials to authenticate to Azure Services. You will need to assign the same roles to your own account that were assigned to your application's managed identity in order for the authentication to work. This should be the same account you use to log into Visual Studio or the Azure CLI.

#### Sign-in to your local development environment

You'll need to be signed in to the Azure CLI, Visual Studio, or Azure Powershell for your credentials to be picked up by `DefaultAzureCredential`.

## [Azure CLI](#tab/login-azure-cli)

```azurecli
az login
```

## [Visual Studio](#tab/login-visual-studio)

// todo

## [PowerShell](#tab/login-powershell)

```powershell
## todo
```

---

#### Assign roles to your developer account

1. In the Azure Portal, navigate to the `razorscaling` storage account you created earlier.
1. Select **Access Control (IAM)** from the left navigation.
1. Choose **+ Add** and then **Add role assignment** from the drop down menu.
1. On the **Add role assignment** page, search for *Storage blob data contributor*, select the matching result, and then choose **Next**.
1. Make sure **User, group, or service principal** is select, and then choose **+ Select members**.
1. In the **Select members** flyout, search for your own *user@domain* account and select it from the results.
1. Choose **Next** and then choose **Review + assign**. After Azure validates your settings, select **Review + assign** again.

Remember, role assignment permissions make take a minute or two to propagate, or in rare cases up to eight minutes.

Next you'll need to assign a role to your account so that it can access the key vault service and secret.

1. In the Azure Portal, navigate to the `razorscalingkeys` key vault you created earlier.
1. Select **Access Control (IAM)** from the left navigation.
1. Choose **+ Add** and then **Add role assignment** from the drop down menu.
1. On the **Add role assignment** page, search for *Key Vault Crypto Service Encryption User*, select the matching result, and then choose **Next**.
1. Make sure **User, group, or service principal** is select, and then choose **+ Select members**.
1. In the **Select members** flyout, search for your own *user@domain* account and select it from the results.
1. Choose **Next** and then choose **Review + assign**. After Azure validates your settings, select **Review + assign** again.

You may need to wait again for this role assignment to propagate.

You can then return to Visual Studio and run the app locally. The code should continue to function as expected. `DefaultAzureCredential` will use your existing credentials from Visual Studio or the Azure CLI
