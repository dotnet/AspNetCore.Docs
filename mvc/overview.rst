Overview of ASP.NET MVC
=======================
By `Tom Archer`

Based on the `MVC architectural pattern <https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93controller>`_, the ASP.NET MVC framework is a lightweight, cross-platform, highly testable application-development framework that separates an application or Web API into three main components: model, view, and controller:

- :doc:`Models </models/index>` represent data that the user is working with in your application. For example, in an inventory application, one of the model objects might be a Product object that is tasked with retrieving information from a database, operating on that information, and then writing the updated information back to the database. In small applications, the model is often a conceptual separation instead of a physical one. For example, if the application only reads a dataset and sends it to the view, the application does not have a physical model layer and associated classes. Instead, the controller might work directly with the dataset, which takes on the role of the model.

- :doc:`Views </views/index>` are responsible for displaying the application's user interface (UI). Typically, this UI is created from the model data. An example would be an edit view of a Products table that displays text boxes, drop-down lists, and check boxes based on the current state of the Product object being represented in the view.

- :doc:`Controllers </controllers/index>` process incoming requests, work with the model, and ultimately select a view that displays the user interface. In an MVC application, the view only displays information; the controller handles and responds to user input and interaction. For example, the controller handles query-string values, and passes these values to the model, which in turn might use these values to query the database.

The MVC pattern helps you create applications that separate the different aspects of the application (input logic, business logic, and UI logic), while providing a loose coupling between these elements. The pattern specifies where each kind of logic should be located in the application:

- UI logic belongs in the view
- Input logic belongs in the controller
- Business logic belongs in the model

This delineation of responsibilities – referred to as the `separation of concerns (SoC) <https://en.wikipedia.org/wiki/Separation_of_concerns>`_ - helps you scale the application in terms of complexity because it’s much easier to code, debug, and test something (model, view, or controller) that has a single job rather than something that performs multiple tasks.

Features of the ASP.NET MVC framework
-------------------------------------

The ASP.NET MVC framework provides the following features:

- Separation of application tasks (input logic, business logic, and UI logic), testability, and test-driven development (TDD). All core contracts in the MVC framework are interface-based and can be tested by using mock objects, which are simulated objects that imitate the behavior of actual objects in the application. You can unit-test the application without having to run the controllers in an ASP.NET process, which makes unit testing fast and flexible. You can use any unit-testing framework that is compatible with the .NET Framework.
- An extensible and pluggable framework. The components of the ASP.NET MVC framework are designed so that they can be easily replaced or customized. You can plug in your own view engine, URL routing policy, action-method parameter serialization, and other components. The ASP.NET MVC framework also supports the use of Dependency Injection (DI) and Inversion of Control (IoC) container models. DI enables you to inject objects into a class, instead of relying on the class to create the object itself. IOC specifies that if an object requires another object, the first objects should get the second object from an outside source such as a configuration file. This makes testing easier.
- Extensive support for ASP.NET routing, which is a powerful URL-mapping component that lets you build applications that have comprehensible and searchable URLs. URLs do not have to include file-name extensions, and are designed to support URL naming patterns that work well for search engine optimization (SEO) and representational state transfer (REST) addressing.
- Support for using the markup in existing ASP.NET page (.aspx files), user control (.ascx files), and master page (.master files) markup files as view templates. You can use existing ASP.NET features with the ASP.NET MVC framework, such as nested master pages, in-line expressions (<%= %>), declarative server controls, templates, data-binding, localization, and so on.
- Support for existing ASP.NET features. ASP.NET MVC lets you use features such as forms authentication and Windows authentication, URL authorization, membership and roles, output and data caching, session and profile state management, health monitoring, the configuration system, and the provider architecture.
- `Content negotiation <http://www.asp.net/web-api/overview/formats-and-model-binding/content-negotiation>`_ is a mechanism defined in the HTTP specification (RFC 2616) as "the process of selecting the best representation for a given response when there are multiple representations available."

MVC 6 - One framework to rule them all
--------------------------------------

.. image:: overview/_static/one-framework.png
  :align: right

Prior to MVC 6, we have various frameworks built on top of ASP.NET:

- Web Pages is a lightweight framework for building UI. It's designed for being able to quickly and easily create a set of Web pages.
- MVC is what you use for more sophisticated, complex applications that require more structure and the ability to easily unit test.
- Web API is great for coding Web services where you want to target a variety of clients - such as browsers and mobile devices.

All of these frameworks are similar in some ways, but very different in others. They have parts that are common and other places where they diverge. In some cases, these frameworks diverge for specific technical reasons - such as they target different scenarios so they do different things to achieve their goals. In other cases, the frameworks diverge mostly for historical reasons.

For example, Web Pages and MVC both use Razor as their underlying syntax for building views. But, Web Pages and MVC diverge in terms
of the set of the HTML Helpers they support once you're coding your Razor page.

The MVC and Web API frameworks have a lot of concepts that are similar: You create controllers and actions within those controllers with both frameworks.
However, there's no sharing of implementation; the types are completely different.
You have controllers in Web API and controllers in MVC. You have actions in Web API and actions in MVC.
But in terms of implementation, they're actually completely decoupled.
This holds true for other concepts common to both Web API and MVC - filters, model binding, DI, etc.

Prior to MVC 6, the Web API and MVC frameworks shared no code at all, which is due purely for historical reasons. The MVC framework - which came first - was built on top of ASP.NET and tightly bound to the ASP.NET pipeline. Therefore, MVC ran only inside IIS. Web API was created and released a little bit later and it came from a service background. We knew when we built Web API that we wanted to be able to support scenarios such as self-hosting. We wanted to leverage the new modern HTTP programming model, and so on. As a result, the two frameworks
couldn't be the same, but we wanted to allow the concepts to be familiar.

As a result, we ended up with duplication - two different variants of filters, controllers, and actions and so on. And while that meant that things felt familiar, it meant you couldn't reuse its
components in a way that you might like to do - such as being able to implement a single filter that you could use in both MVC and also with Web API.

As a result, you can now have controllers that return views that render html, and those same controllers can also do Web API and return formatted data (such as JSON or XML).

This is why MVC 6 is taking a huge step forward in merging all three frameworks. Therefore, you can think of MVC 6 as being the latest version of all three frameworks:

- Web API 3 = MVC 6
- Web Pages 4 = MVC 6
- MVC 6 = MVC 6
