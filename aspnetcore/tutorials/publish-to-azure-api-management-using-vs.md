---
title: Publish an ASP.NET Core web API to Azure API Management with Visual Studio
author: codemillmatt
description: Learn how to publish an ASP.NET Core web API to Azure API Management using Visual Studio.
ms.author: masoucou
ms.custom: "devx-track-csharp, mvc"
ms.date: 08/20/2020
no-loc: 
uid: tutorials/publish-to-azure-api-management-using-vs
---
# Publish an ASP.NET Core app to Azure API Management with Visual Studio

By [Matt Soucoup](https://twitter.com/codemillmatt)

## Set up

- Open a [free Azure account](https://azure.microsoft.com/free/dotnet/) if you don't have one.
- [Create a new Azure API Management instance](/azure/api-management/get-started-create-service-instance) if you have not already.

## Create a web api app

In the Visual Studio Start dialog, select **Create a new project**

![New project from start dialog](publish-to-azure-api-management-using-vs/_static/file_new_project.png)

Select the **ASP.NET Core Web Application** template

![Template selection dialog](publish-to-azure-api-management-using-vs/_static/select_template.png)

Configure the project by providing:

- A project name
- Location to save the project's files
- A solution name

![Configure project dialog](publish-to-azure-api-management-using-vs/_static/configure_prj.png)

Complete the **New Project** dialog:

- Select **API**.
- Click **Create**.

![Finish](publish-to-azure-api-management-using-vs/_static/select_aspnet_core_webapi.png)

Visual Studio creates the solution.

## Configure the app

Adding Swagger definitions to the ASP.NET Core web API will allow Azure API Management to read the app's API definitions.

### Add Swagger

Add the **Swashbuckle.AspNetCore** NuGet package to the ASP.NET Core web API's project.

![configure nuget dialog](publish-to-azure-api-management-using-vs/_static/configure_nuget.png)

Open the `Startup.cs` file and add the following line to the `ConfigureServices` function:

```csharp

services.AddSwaggerGen();

```

Add the following line to the `Configure` function.

```csharp

app.UseSwagger();

```

### Change the API routing

Here you'll change the URL structure needed to access the `Get` function of the `WeatherForecastController`.

Open the `WeatherForecastController.cs` file.

Delete the `[Route("[controller]")]` class-level attribute. The class definition will look like the following:

```csharp

[ApiController]
public class WeatherForecastController : ControllerBase

```

Add a `[Route("/")]` attribute to the `Get()` function. The function definition will look like the following:

```csharp

[HttpGet]
[Route("/")]
public IEnumerable<WeatherForecast> Get()

```

## Publish the API app to Azure API Management

In order to publish the ASP.NET Core web API to Azure API Management you need to first publish the API app to Azure App Service, add an API in the Azure API Management service, then publish the API there.

### Publish the API app to Azure App Service

Right click on the project in the Solution Explorer and select **Publish...**.

![Contextual menu open with Publish link highlighted](publish-to-azure-api-management-using-vs/_static/publish_menu.png)

In the **Publish** dialog:

- Select **Azure**.
- Select **Next**.

![Publish dialog](publish-to-azure-api-management-using-vs/_static/publish_dialog.png)

In the **Publish** dialog:

- Select **Azure App Service (Windows)**.
- Select **Next**.

![Publish dialog: select App Service](publish-to-azure-api-management-using-vs/_static/publish_dialog_app_svc.png)

In the **Publish** dialog select **Create a new Azure App Service...**

![Publish dialog: select Azure Service instance](publish-to-azure-api-management-using-vs/_static/publish_dialog_create_new_app_svc.png)

The **Create App Service** dialog appears:

- The **App Name**, **Resource Group**, and **App Service Plan** entry fields are populated. You can keep these names or change them.
- Select **Create**.

![Create App Service dialog](publish-to-azure-api-management-using-vs/_static/publish_dialog_app_svc_attributes.png)

After creation is completed the dialog is automatically closed and the **Publish** dialog gets focus again:

- The new instance that was just created is automatically selected.

![Publish dialog: select App Service instance](publish-to-azure-api-management-using-vs/_static/publish_dialog_app_svc_created.png)

At this point you need to add an API to the Azure API Management service. Leave Visual Studio open while you complete the following tasks.

### Add an API to Azure API Management

Open the API Management Service instance created previously in the Azure portal and select the **APIs** blade.

![APIs blade selected from the API Management Service instance](publish-to-azure-api-management-using-vs/_static/portal_api_overview.png)

From the **Add a new API** panel, click the **Blank API** tile.

![Screen showing the blank API tile highlighted](publish-to-azure-api-management-using-vs/_static/portal_api_create_blank.png)

The **Create a blank API** dialog appears, enter the following values:

- **Display Name**: _WeatherForecasts_
- **Name**: _weatherforecasts_
- **API Url suffix**: _v1_

Leave the **Web service URL** field empty.

Click the **Create** button.

![Screenshot of the completed create a blank api dialog](publish-to-azure-api-management-using-vs/_static/portal_api_blank_complete.png)

The blank API is created.

![Screenshot of a blank API in the API Management portal](publish-to-azure-api-management-using-vs/_static/portal_api_blank_created_empty.png)

### Publish the ASP.NET Core Web API to Azure API Management

Switch back to Visual Studio.

The **Publish** dialog should still be open where you left off before.

- Select the Azure App Service that was just published so it is highlighted.
- Click the **Next** button.

![Screenshot of the publish dialog with the app service selected](publish-to-azure-api-management-using-vs/_static/publish_dialog_app_svc_created.png)

The dialog now shows the Azure API Management service created before. Expand it and the **APIs** folder and you will see the blank API you just created.

- Select the blank API's name.
- Click **Finish**.

![Screenshot of the newly created Azure API Management blank API selected in the publish dialog](publish-to-azure-api-management-using-vs/_static/publish_dialog_api_selected.png)

The dialog closes and a summary screen appears with information regarding the publish. Click the **Publish** button.

![Screenshot of Visual Studio with the publish profile displayed](publish-to-azure-api-management-using-vs/_static/vs_publish_profile.png)

The web API will publish to both Azure App Service and Azure API Management. 

- A new browser window will appear showing the API running in Azure App Service, you can close that window.
- Switch back to the Azure API Management instance in the Azure portal.
- Refresh the browser window.
- Select the blank API you created in the steps above, it is now populated and you can explore around.

![Screenshot of the populated API in Azure API Management](publish-to-azure-api-management-using-vs/_static/deployed_to_azure_api_mgmt.png)

### Configure the published API name

Notice the name of the API is different than what you named it.

Here the published API is named **WeatherAPI** whereas you named it **WeatherForecasts** when you created it.

![Screenshot of populated API with different names highlighted](publish-to-azure-api-management-using-vs/_static/deployed_to_azure_api_mgmt_wrong_name.png)

To fix the name, open the `Startup.cs` file, navigate to the `ConfigureServices` function and delete the following line:

```csharp

services.AddSwaggerGen();

```

Then add in the following code to the `ConfigureServices` function:

```csharp

services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("WeatherForecasts", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Weather Forecasts",
        Version = "v1"
    });
});

```

Open the publish profile that was just created. It can be found from the Solution Explorer in the **Properties** -> **PublishProfiles** folder.

![Screenshot showing the publish profile file location highlighted](publish-to-azure-api-management-using-vs/_static/vs_publish_profile_highlighted.png)

Find the `<OpenAPIDocumentName>` element and change its value from `v1` to `WeatherForecasts`.

![screenshot of the changes necessary for the publish profile](publish-to-azure-api-management-using-vs/_static/vs_publish_profile_changes.png)

Republish the ASP.NET Core web API application and open the Azure API Management instance in the Azure portal.

After refreshing the page, you will see the name of the API is now correct.

![Screenshot of the finished API in the portal](publish-to-azure-api-management-using-vs/_static/portal_finish.png)

### Verify the web API is working

You can test the deployed ASP.NET Core web API in Azure API Management from the Azure portal with the following steps:

- Open the **Test** tab
- Select **/** or the **Get** operation
- Click **Send**

![Screenshot of the portal before the test](publish-to-azure-api-management-using-vs/_static/portal_pre_test.png)

A successful response will look like the following:

![Screenshot of a successful response from API Management](publish-to-azure-api-management-using-vs/_static/portal_successful_response.png)

## Clean up

When you have finished testing the app, go to the [Azure portal](https://portal.azure.com/) and delete the app.

- Select **Resource groups**, then select the resource group you created.

![Azure Portal: Resource Groups in sidebar menu](publish-to-azure-api-management-using-vs/_static/portalrg.png)

- In the **Resource groups** page, select **Delete**.

![Azure Portal: Resource Groups page](publish-to-azure-api-management-using-vs/_static/rgd.png)

- Enter the name of the resource group and select **Delete**. Your app and all other resources created in this tutorial are now deleted from Azure.

## Next steps

- <xref:host-and-deploy/azure-apps/azure-continuous-deployment>

## Additional resources

- [Azure API Management](/azure/api-management/api-management-key-concepts)
- [Azure App Service](/azure/app-service/app-service-web-overview)
