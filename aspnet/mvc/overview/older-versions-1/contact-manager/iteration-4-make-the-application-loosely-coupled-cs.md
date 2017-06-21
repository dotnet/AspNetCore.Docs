---
uid: mvc/overview/older-versions-1/contact-manager/iteration-4-make-the-application-loosely-coupled-cs
title: "Iteration #4 – Make the application loosely coupled (C#) | Microsoft Docs"
author: microsoft
description: "In this third iteration, we take advantage of several software design patterns to make it easier to maintain and modify the Contact Manager application. For..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 02/20/2009
ms.topic: article
ms.assetid: 829f589f-e201-4f6e-9ae6-08ae84322065
ms.technology: dotnet-mvc
ms.prod: .net-framework
msc.legacyurl: /mvc/overview/older-versions-1/contact-manager/iteration-4-make-the-application-loosely-coupled-cs
msc.type: authoredcontent
---
Iteration #4 – Make the application loosely coupled (C#)
====================
by [Microsoft](https://github.com/microsoft)

[Download Code](iteration-4-make-the-application-loosely-coupled-cs/_static/contactmanager_4_cs1.zip)

> In this third iteration, we take advantage of several software design patterns to make it easier to maintain and modify the Contact Manager application. For example, we refactor our application to use the Repository pattern and the Dependency Injection pattern.


## Building a Contact Management ASP.NET MVC Application (C#)

In this series of tutorials, we build an entire Contact Management application from start to finish. The Contact Manager application enables you to store contact information - names, phone numbers and email addresses - for a list of people.

We build the application over multiple iterations. With each iteration, we gradually improve the application. The goal of this multiple iteration approach is to enable you to understand the reason for each change.

- Iteration #1 - Create the application. In the first iteration, we create the Contact Manager in the simplest way possible. We add support for basic database operations: Create, Read, Update, and Delete (CRUD).

- Iteration #2 - Make the application look nice. In this iteration, we improve the appearance of the application by modifying the default ASP.NET MVC view master page and cascading style sheet.

- Iteration #3 - Add form validation. In the third iteration, we add basic form validation. We prevent people from submitting a form without completing required form fields. We also validate email addresses and phone numbers.

- Iteration #4 - Make the application loosely coupled. In this third iteration, we take advantage of several software design patterns to make it easier to maintain and modify the Contact Manager application. For example, we refactor our application to use the Repository pattern and the Dependency Injection pattern.

- Iteration #5 - Create unit tests. In the fifth iteration, we make our application easier to maintain and modify by adding unit tests. We mock our data model classes and build unit tests for our controllers and validation logic.

- Iteration #6 - Use test-driven development. In this sixth iteration, we add new functionality to our application by writing unit tests first and writing code against the unit tests. In this iteration, we add contact groups.

- Iteration #7 - Add Ajax functionality. In the seventh iteration, we improve the responsiveness and performance of our application by adding support for Ajax.

## This Iteration

In this fourth iteration of the Contact Manager application, we refactor the application to make the application more loosely coupled. When an application is loosely coupled, you can modify the code in one part of the application without needing to modify the code in other parts of the application. Loosely coupled applications are more resilient to change.

Currently, all of the data access and validation logic used by the Contact Manager application is contained in the controller classes. This is a bad idea. Whenever you need to modify one part of your application, you risk introducing bugs into another part of your application. For example, if you modify your validation logic, you risk introducing new bugs into your data access or controller logic.

> [!NOTE] 
> 
> (SRP), a class should never have more than one reason to change. Mixing controller, validation, and database logic is a massive violation of the Single Responsibility Principle.


There are several reasons that you might need to modify your application. You might need to add a new feature to your application, you might need to fix a bug in your application, or you might need to modify how a feature of your application is implemented. Applications are rarely static. They tend to grow and mutate over time.

Imagine, for example, that you decide to change how you implement your data access layer. Right now, the Contact Manager application uses the Microsoft Entity Framework to access the database. However, you might decide to migrate to a new or alternative data access technology such as ADO.NET Data Services or NHibernate. However, because the data access code is not isolated from the validation and controller code, there is no way to modify the data access code in your application without modifying other code that is not directly related to data access.

When an application is loosely coupled, on the other hand, you can make changes to one part of an application without touching other parts of an application. For example, you can switch data access technologies without modifying your validation or controller logic.

In this iteration, we take advantage of several software design patterns that enable us to refactor our Contact Manager application into a more loosely coupled application. When we are done, the Contact Manager won t do anything that it didn t do before. However, we'll be able to change the application more easily in the future.

> [!NOTE] 
> 
> Refactoring is the process of rewriting an application in such a way that it does not lose any existing functionality.


## Using the Repository Software Design Pattern

Our first change is to take advantage of a software design pattern called the Repository pattern. We'll use the Repository pattern to isolate our data access code from the rest of our application.

Implementing the Repository pattern requires us to complete the following two steps:

1. Create an interface
2. Create a concrete class that implements the interface

First, we need to create an interface that describes all of the data access methods that we need to perform. The IContactManagerRepository interface is contained in Listing 1. This interface describes five methods: CreateContact(), DeleteContact(), EditContact(), GetContact, and ListContacts().

**Listing 1 - Models\IContactManagerRepositiory.cs**

[!code-csharp[Main](iteration-4-make-the-application-loosely-coupled-cs/samples/sample1.cs)]

Next, we need to create a concrete class that implements the IContactManagerRepository interface. Because we are using the Microsoft Entity Framework to access the database, we'll create a new class named EntityContactManagerRepository. This class is contained in Listing 2.

**Listing 2 - Models\EntityContactManagerRepository.cs**

[!code-csharp[Main](iteration-4-make-the-application-loosely-coupled-cs/samples/sample2.cs)]

Notice that the EntityContactManagerRepository class implements the IContactManagerRepository interface. The class implements all five of the methods described by that interface.

You might wonder why we need to bother with an interface. Why do we need to create both an interface and a class that implements it?

With one exception, the remainder of our application will interact with the interface and not the concrete class. Instead of calling the methods exposed by the EntityContactManagerRepository class, we'll call the methods exposed by the IContactManagerRepository interface.

That way, we can implement the interface with a new class without needing to modify the remainder of our application. For example, at some future date, we might want to implement an DataServicesContactManagerRepository class that implements the IContactManagerRepository interface. The DataServicesContactManagerRepository class might use ADO.NET Data Services to access a database instead of the Microsoft Entity Framework.

If our application code is programmed against the IContactManagerRepository interface instead of the concrete EntityContactManagerRepository class then we can switch concrete classes without modifying any of the rest of our code. For example, we can switch from the EntityContactManagerRepository class to the DataServicesContactManagerRepository class without modifying our data access or validation logic.

Programming against interfaces (abstractions) instead of concrete classes makes our application more resilient to change.

> [!NOTE] 
> 
> You can quickly create an interface from a concrete class within Visual Studio by selecting the menu option Refactor, Extract Interface. For example, you can create the EntityContactManagerRepository class first and then use Extract Interface to generate the IContactManagerRepository interface automatically.


## Using the Dependency Injection Software Design Pattern

Now that we have migrated our data access code to a separate Repository class, we need to modify our Contact controller to use this class. We will take advantage of a software design pattern called Dependency Injection to use the Repository class in our controller.

The modified Contact controller is contained in Listing 3.

**Listing 3 - Controllers\ContactController.cs**

[!code-csharp[Main](iteration-4-make-the-application-loosely-coupled-cs/samples/sample3.cs)]

Notice that the Contact controller in Listing 3 has two constructors. The first constructor passes a concrete instance of the IContactManagerRepository interface to the second constructor. The Contact controller class uses *Constructor Dependency Injection*.

The one and only place that the EntityContactManagerRepository class is used is in the first constructor. The remainder of the class uses the IContactManagerRepository interface instead of the concrete EntityContactManagerRepository class.

This makes it easy to switch implementations of the IContactManagerRepository class in the future. If you want to use the DataServicesContactRepository class instead of the EntityContactManagerRepository class, just modify the first constructor.

Constructor Dependency injection also makes the Contact controller class very testable. In your unit tests, you can instantiate the Contact controller by passing a mock implementation of the IContactManagerRepository class. This feature of Dependency Injection will be very important to us in the next iteration when we build unit tests for the Contact Manager application.

> [!NOTE] 
> 
> If you want to completely decouple the Contact controller class from a particular implementation of the IContactManagerRepository interface then you can take advantage of a framework that supports Dependency Injection such as StructureMap or the Microsoft Entity Framework (MEF). By taking advantage of a Dependency Injection framework, you never need to refer to a concrete class in your code.


## Creating a Service Layer

You might have noticed that our validation logic is still mixed up with our controller logic in the modified controller class in Listing 3. For the same reason that it is a good idea to isolate our data access logic, it is a good idea to isolate our validation logic.

To fix this problem, we can create a separate [*service layer*](http://martinfowler.com/eaaCatalog/serviceLayer.html). The service layer is a separate layer that we can insert between our controller and repository classes. The service layer contains our business logic including all of our validation logic.

The ContactManagerService is contained in Listing 4. It contains the validation logic from the Contact controller class.

**Listing 4 - Models\ContactManagerService.cs**

[!code-csharp[Main](iteration-4-make-the-application-loosely-coupled-cs/samples/sample4.cs)]

Notice that the constructor for the ContactManagerService requires a ValidationDictionary. The service layer communicates with the controller layer through this ValidationDictionary. We discuss the ValidationDictionary in detail in the following section when we discuss the Decorator pattern.

Notice, furthermore, that the ContactManagerService implements the IContactManagerService interface. You should always strive to program against interfaces instead of concrete classes. Other classes in the Contact Manager application do not interact with the ContactManagerService class directly. Instead, with one exception, the remainder of the Contact Manager application is programmed against the IContactManagerService interface.

The IContactManagerService interface is contained in Listing 5.

**Listing 5 - Models\IContactManagerService.cs**

[!code-csharp[Main](iteration-4-make-the-application-loosely-coupled-cs/samples/sample5.cs)]

The modified Contact controller class is contained in Listing 6. Notice that the Contact controller no longer interacts with the ContactManager repository. Instead, the Contact controller interacts with the ContactManager service. Each layer is isolated as much as possible from other layers.

**Listing 6 - Controllers\ContactController.cs**

[!code-csharp[Main](iteration-4-make-the-application-loosely-coupled-cs/samples/sample6.cs)]

Our application no longer runs afoul of the Single Responsibility Principle (SRP). The Contact controller in Listing 6 has been stripped of every responsibility other than controlling the flow of application execution. All the validation logic has been removed from the Contact controller and pushed into the service layer. All of the database logic has been pushed into the repository layer.

## Using the Decorator Pattern

We want to be able to completely decouple our service layer from our controller layer. In principle, we should be able to compile our service layer in a separate assembly from our controller layer without needing to add a reference to our MVC application.

However, our service layer needs to be able to pass validation error messages back to the controller layer. How can we enable the service layer to communicate validation error messages without coupling the controller and service layer? We can take advantage of a software design pattern named the [Decorator pattern](http://en.wikipedia.org/wiki/Decorator_pattern).

A controller uses a ModelStateDictionary named ModelState to represent validation errors. Therefore, you might be tempted to pass ModelState from the controller layer to the service layer. However, using ModelState in the service layer would make your service layer dependent on a feature of the ASP.NET MVC framework. This would be bad because, someday, you might want to use the service layer with a WPF application instead of an ASP.NET MVC application. In that case, you wouldn t want to reference the ASP.NET MVC framework to use the ModelStateDictionary class.

The Decorator pattern enables you to wrap an existing class in a new class in order to implement an interface. Our Contact Manager project includes the ModelStateWrapper class contained in Listing 7. The ModelStateWrapper class implements the interface in Listing 8.

**Listing 7 - Models\Validation\ModelStateWrapper.cs**

[!code-csharp[Main](iteration-4-make-the-application-loosely-coupled-cs/samples/sample7.cs)]

**Listing 8 - Models\Validation\IValidationDictionary.cs**

[!code-csharp[Main](iteration-4-make-the-application-loosely-coupled-cs/samples/sample8.cs)]

If you take a close look at Listing 5 then you'll see that the ContactManager service layer uses the IValidationDictionary interface exclusively. The ContactManager service is not dependent on the ModelStateDictionary class. When the Contact controller creates the ContactManager service, the controller wraps its ModelState like this:

[!code-csharp[Main](iteration-4-make-the-application-loosely-coupled-cs/samples/sample9.cs)]

## Summary

In this iteration, we did not add any new functionality to the Contact Manager application. The goal of this iteration was to refactor the Contact Manager application so that is easier to maintain and modify.

First, we implemented the Repository software design pattern. We migrated all of the data access code to a separate ContactManager repository class.

We also isolated our validation logic from our controller logic. We created a separate service layer that contains all of our validation code. The controller layer interacts with the service layer, and the service layer interacts with the repository layer.

When we created the service layer, we took advantage of the Decorator pattern to isolate ModelState from our service layer. In our service layer, we programmed against the IValidationDictionary interface instead of ModelState.

Finally, we took advantage of a software design pattern named the Dependency Injection pattern. This pattern enables us to program against interfaces (abstractions) instead of concrete classes. Implementing the Dependency Injection design pattern also makes our code more testable. In the next iteration, we add unit tests to our project.

>[!div class="step-by-step"]
[Previous](iteration-3-add-form-validation-cs.md)
[Next](iteration-5-create-unit-tests-cs.md)