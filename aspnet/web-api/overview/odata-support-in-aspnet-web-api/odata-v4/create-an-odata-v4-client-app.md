---
title: "Create an OData v4 Client App (C#) | Microsoft Docs"
author: MikeWasson
description: ""
ms.author: riande
manager: wpickett
ms.date: 06/26/2014
ms.topic: article
ms.assetid: 
ms.technology: dotnet-webapi
ms.prod: .net-framework
msc.legacyurl: /web-api/overview/odata-support-in-aspnet-web-api/odata-v4/create-an-odata-v4-client-app
---
Create an OData v4 Client App (C#)
====================
by [Mike Wasson](https://github.com/MikeWasson)

In the previous tutorial, you created a basic OData service that supports CRUD operations. Now let's create a client for the service.

Start a new instance of Visual Studio and create a new console application project. In the **New Project** dialog, select **Installed** &gt; **Templates** &gt; **Visual C#** &gt; **Windows Desktop**, and select the **Console Application** template. Name the project &quot;ProductsApp&quot;.

![](create-an-odata-v4-client-app/_static/image1.png)

> [!NOTE] You can also add the console app to the same Visual Studio solution that contains the OData service.


## Install the OData Client Code Generator

From the **Tools** menu, select **Extensions and Updates**. Select **Online** &gt; **Visual Studio Gallery**. In the search box, search for &quot;OData Client Code Generator&quot;. Click **Download** to install the VSIX. You might be prompted to restart Visual Studio.

[![](create-an-odata-v4-client-app/_static/image3.png)](create-an-odata-v4-client-app/_static/image2.png)

## Run the OData Service Locally

Run the ProductService project from Visual Studio. By default, Visual Studio launches a browser to the application root. Note the URI; you will need this in the next step. Leave the application running.

![](create-an-odata-v4-client-app/_static/image4.png)

> [!NOTE] If you put both projects in the same solution, make sure to run the ProductService project without debugging. In the next step, you will need to keep the service running while you modify the console application project.


## Generate the Service Proxy

The service proxy is a .NET class that defines methods for accessing the OData service. The proxy translates method calls into HTTP requests. You will create the proxy class by running a [T4 template](https://msdn.microsoft.com/en-us/library/bb126445.aspx).

Right-click the project. Select **Add** &gt; **New Item**.

![](create-an-odata-v4-client-app/_static/image5.png)

In the **Add New Item** dialog, select **Visual C# Items** &gt; **Code** &gt; **OData Client**. Name the template &quot;ProductClient.tt&quot;. Click **Add** and click through the security warning.

[![](create-an-odata-v4-client-app/_static/image7.png)](create-an-odata-v4-client-app/_static/image6.png)

At this point, you'll get an error, which you can ignore. Visual Studio automatically runs the template, but the template needs some configuration settings first.

[![](create-an-odata-v4-client-app/_static/image9.png)](create-an-odata-v4-client-app/_static/image8.png)

Open the file ProductClient.odata.config. In the `Parameter` element, paste in the URI from the ProductService project (previous step). For example:

    <Parameter Name="MetadataDocumentUri" Value="http://localhost:61635/" />

[![](create-an-odata-v4-client-app/_static/image11.png)](create-an-odata-v4-client-app/_static/image10.png)

Run the template again. In Solution Explorer, right click the ProductClient.tt file and select **Run Custom Tool**.

The template creates a code file named ProductClient.cs that defines the proxy. As you develop your app, if you change the OData endpoint, run the template again to update the proxy.

![](create-an-odata-v4-client-app/_static/image12.png)

## Use the Service Proxy to Call the OData Service

Open the file Program.cs and replace the boilerplate code with the following.

    using System;
    
    namespace ProductsApp
    {
        class Program
        {
            // Get an entire entity set.
            static void ListAllProducts(Default.Container container)
            {
                foreach (var p in container.Products)
                {
                    Console.WriteLine("{0} {1} {2}", p.Name, p.Price, p.Category);
                }
            }
    
            static void AddProduct(Default.Container container, ProductService.Models.Product product)
            {
                container.AddToProducts(product);
                var serviceResponse = container.SaveChanges();
                foreach (var operationResponse in serviceResponse)
                {
                    Console.WriteLine("Response: {0}", operationResponse.StatusCode);
                }
            }
    
            static void Main(string[] args)
            {
                // TODO: Replace with your local URI.
                string serviceUri = "http://localhost:port/";
                var container = new Default.Container(new Uri(serviceUri));
    
                var product = new ProductService.Models.Product()
                {
                    Name = "Yo-yo",
                    Category = "Toys",
                    Price = 4.95M
                };
    
                AddProduct(container, product);
                ListAllProducts(container);
            }
        }
    }

Replace the value of *serviceUri* with the service URI from earlier.

    // TODO: Replace with your local URI.
    string serviceUri = "http://localhost:port/";

When you run the app, it should output the following:

    Response: 201
    Yo-yo 4.95 Toys