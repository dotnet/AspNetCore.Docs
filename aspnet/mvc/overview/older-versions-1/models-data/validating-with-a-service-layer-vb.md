---
uid: mvc/overview/older-versions-1/models-data/validating-with-a-service-layer-vb
title: "Validating with a Service Layer (VB) | Microsoft Docs"
author: StephenWalther
description: "Learn how to move your validation logic out of your controller actions and into a separate service layer. In this tutorial, Stephen Walther explains how you..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 03/02/2009
ms.topic: article
ms.assetid: 344bb38e-4965-4c47-bda1-f6d29ae5b83a
ms.technology: dotnet-mvc
ms.prod: .net-framework
msc.legacyurl: /mvc/overview/older-versions-1/models-data/validating-with-a-service-layer-vb
msc.type: authoredcontent
---
Validating with a Service Layer (VB)
====================
by [Stephen Walther](https://github.com/StephenWalther)

> Learn how to move your validation logic out of your controller actions and into a separate service layer. In this tutorial, Stephen Walther explains how you can maintain a sharp separation of concerns by isolating your service layer from your controller layer.


The goal of this tutorial is to describe one method of performing validation in an ASP.NET MVC application. In this tutorial, you learn how to move your validation logic out of your controllers and into a separate service layer.

## Separating Concerns

When you build an ASP.NET MVC application, you should not place your database logic inside your controller actions. Mixing your database and controller logic makes your application more difficult to maintain over time. The recommendation is that you place all of your database logic in a separate repository layer.

For example, Listing 1 contains a simple repository named the ProductRepository. The product repository contains all of the data access code for the application. The listing also includes the IProductRepository interface that the product repository implements.

**Listing 1 - Models\ProductRepository.vb**

[!code-vb[Main](validating-with-a-service-layer-vb/samples/sample1.vb)]

The controller in Listing 2 uses the repository layer in both its Index() and Create() actions. Notice that this controller does not contain any database logic. Creating a repository layer enables you to maintain a clean separation of concerns. Controllers are responsible for application flow control logic and the repository is responsible for data access logic.

**Listing 2 - Controllers\ProductController.vb**

[!code-vb[Main](validating-with-a-service-layer-vb/samples/sample2.vb)]

## Creating a Service Layer

So, application flow control logic belongs in a controller and data access logic belongs in a repository. In that case, where do you put your validation logic? One option is to place your validation logic in a *service layer*.

A service layer is an additional layer in an ASP.NET MVC application that mediates communication between a controller and repository layer. The service layer contains business logic. In particular, it contains validation logic.

For example, the product service layer in Listing 3 has a CreateProduct() method. The CreateProduct() method calls the ValidateProduct() method to validate a new product before passing the product to the product repository.

**Listing 3 - Models\ProductService.vb**

[!code-vb[Main](validating-with-a-service-layer-vb/samples/sample3.vb)]

The Product controller has been updated in Listing 4 to use the service layer instead of the repository layer. The controller layer talks to the service layer. The service layer talks to the repository layer. Each layer has a separate responsibility.

**Listing 4 - Controllers\ProductController.vb**

[!code-vb[Main](validating-with-a-service-layer-vb/samples/sample4.vb)]

Notice that the product service is created in the product controller constructor. When the product service is created, the model state dictionary is passed to the service. The product service uses model state to pass validation error messages back to the controller.

## Decoupling the Service Layer

We have failed to isolate the controller and service layers in one respect. The controller and service layers communicate through model state. In other words, the service layer has a dependency on a particular feature of the ASP.NET MVC framework.

We want to isolate the service layer from our controller layer as much as possible. In theory, we should be able to use the service layer with any type of application and not only an ASP.NET MVC application. For example, in the future, we might want to build a WPF front-end for our application. We should find a way to remove the dependency on ASP.NET MVC model state from our service layer.

In Listing 5, the service layer has been updated so that it no longer uses model state. Instead, it uses any class that implements the IValidationDictionary interface.

**Listing 5 - Models\ProductService.vb (decoupled)**

[!code-vb[Main](validating-with-a-service-layer-vb/samples/sample5.vb)]

The IValidationDictionary interface is defined in Listing 6. This simple interface has a single method and a single property.

**Listing 6 - Models\IValidationDictionary.cs**

[!code-vb[Main](validating-with-a-service-layer-vb/samples/sample6.vb)]

The class in Listing 7, named the ModelStateWrapper class, implements the IValidationDictionary interface. You can instantiate the ModelStateWrapper class by passing a model state dictionary to the constructor.

**Listing 7 - Models\ModelStateWrapper.vb**

[!code-vb[Main](validating-with-a-service-layer-vb/samples/sample7.vb)]

Finally, the updated controller in Listing 8 uses the ModelStateWrapper when creating the service layer in its constructor.

**Listing 8 - Controllers\ProductController.vb**

[!code-vb[Main](validating-with-a-service-layer-vb/samples/sample8.vb)]

Using the IValidationDictionary interface and the ModelStateWrapper class enables us to completely isolate our service layer from our controller layer. The service layer is no longer dependent on model state. You can pass any class that implements the IValidationDictionary interface to the service layer. For example, a WPF application might implement the IValidationDictionary interface with a simple collection class.

## Summary

The goal of this tutorial was to discuss one approach to performing validation in an ASP.NET MVC application. In this tutorial, you learned how to move all of your validation logic out of your controllers and into a separate service layer. You also learned how to isolate your service layer from your controller layer by creating a ModelStateWrapper class.

>[!div class="step-by-step"]
[Previous](validating-with-the-idataerrorinfo-interface-vb.md)
[Next](validation-with-the-data-annotation-validators-vb.md)