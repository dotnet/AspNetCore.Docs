---
title: Publish an ASP.NET Core web API to Azure API Management with Visual Studio
author: codemillmatt
description: Learn how to publish an ASP.NET Core web API to Azure API Management using Visual Studio.
ms.author: masoucou
ms.custom: "devx-track-csharp, mvc"
ms.date: 10/05/2022
uid: tutorials/publish-to-azure-api-management-using-vs
---
# Publish an ASP.NET Core web API to Azure API Management with Visual Studio

By [Matt Soucoup](https://twitter.com/codemillmatt)

In this tutorial you'll learn how to create an ASP.NET Core web API project using Visual Studio, ensure it has OpenAPI support, and then publish the web API to both Azure App Service and Azure API Management.

## Set up

To complete the tutorial you'll need an Azure account.

* Open a [free Azure account](https://azure.microsoft.com/free/dotnet/) if you don't have one.

## Create an ASP.NET Core web API

Visual Studio allows you to easily create a new ASP.NET Core web API project from a template. Follow these directions to create a new ASP.NET Core web API project:

* From the File menu, select **New** > **Project**.
* Enter **Web API** in the search box.
* Select the **ASP.NET Core Web API** template and select **Next**.
* In the **Configure your new project dialog**, name the project **WeatherAPI** and select **Next**.
* In the **Additional information** dialog:
* Confirm the Framework is **.NET 6.0 (Long-term support)**.
* Confirm the checkbox for **Use controllers (uncheck to use minimal APIs)** is checked.
* Confirm the checkbox for **Enable OpenAPI support** is checked.
* Select **Create**.

## Explore the code

Swagger definitions allow Azure API Management to read the app's API definitions. By checking the **Enable OpenAPI support** checkbox during app creation, Visual Studio automatically adds the code to create the Swagger definitions. Open up the `Program.cs` file which shows the following code:

```csharp

...

builder.Services.AddSwaggerGen();

...

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

...

```

### Ensure the Swagger definitions are always generated

Azure API Management needs the Swagger definitions to always be present, regardless of the application's environment. To ensure they are always generated, move `app.UseSwagger();` outside of the `if (app.Environment.IsDevelopment())` block.

The updated code:

```csharp

...

app.UseSwagger();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
}

...

```

### Change the API routing

Change the URL structure needed to access the `Get` action of the `WeatherForecastController`. Complete the following steps:

1. Open the `WeatherForecastController.cs` file.
1. Replace the `[Route("[controller]")]` class-level attribute with `[Route("/")]`. The updated class definition :

    ```csharp
    [ApiController]
    [Route("/")]
    public class WeatherForecastController : ControllerBase
    ```

## Publish the web API to Azure App Service

Complete the following steps to publish the ASP.NET Core web API to Azure API Management:

1. Publish the API app to Azure App Service.
1. Publish the ASP.NET Core web API app to the Azure API Management service instance.

### Publish the API app to Azure App Service

Complete the following steps to publish the ASP.NET Core web API to Azure API Management:

1. In **Solution Explorer**, right-click the project and select **Publish**.    
1. In the **Publish** dialog, select **Azure** and select the **Next** button.    
1. Select **Azure App Service (Windows)** and select the **Next** button.
1. Select **Create a new Azure App Service**.

    The **Create App Service** dialog appears. The **App Name**, **Resource Group**, and **App Service Plan** entry fields are populated. You can keep these names or change them.

1. Select the **Create** button.
1. Once the app service is created, select the **Next** button.
1. Select **Create a new API Management Service**.

    The **Create API Management Service** dialog appears. You can leave the **API Name**, **Subscription Name**, and **Resource Group** entry fields as they are. Select the **new** button next to the **API Management Service** entry and enter the required fields from that dialog box.

    Select the **OK** button to create the API Management service.

1. Select the **Create** button to proceed with the API Management service creation. This step may take several minutes to complete.
1. When that completes, select the **Finish** button.
1. The dialog closes and a summary screen appears with information about the publish. Select the **Publish** button.

    The web API publishes to both Azure App Service and Azure API Management. A new browser window will appear and show the API running in Azure App Service. You can close that window.

1. Open up the Azure portal in a web browser and navigate to the API Management instance you created.
1. Select the **APIs** option from the left-hand menu.
1. Select the API you created in the preceding steps. It's now populated and you can explore around.

### Configure the published API name

Notice the name of the API is named *WeatherAPI*; however, we would like to call it *Weather Forecasts*. Complete the following steps to update the name:

1. Add the following to `Program.cs` immediately after `servies.AddSwaggerGen();`
    
    ```csharp
    builder.Services.ConfigureSwaggerGen(setup =>
    {
        setup.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
        {
            Title = "Weather Forecasts",
            Version = "v1"
        });
    });
    ```
   
1. Republish the ASP.NET Core web API and open the Azure API Management instance in the Azure portal.
1. Refresh the page in your browser. You'll see the name of the API is now correct.
    
### Verify the web API is working

You can test the deployed ASP.NET Core web API in Azure API Management from the Azure portal with the following steps:

1. Open the **Test** tab.
1. Select **/** or the **Get** operation.
1. Select **Send**.

## Clean up

When you've finished testing the app, go to the [Azure portal](https://portal.azure.com/) and delete the app.

1. Select **Resource groups**, then select the resource group you created.

1. In the **Resource groups** page, select **Delete**.

1. Enter the name of the resource group and select **Delete**. Your app and all other resources created in this tutorial are now deleted from Azure.

## Additional resources

* [Azure API Management](/azure/api-management/api-management-key-concepts)
* [Azure App Service](/azure/app-service/app-service-web-overview)
