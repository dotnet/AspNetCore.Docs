---
title: "Create the View (UI) | Microsoft Docs"
author: MikeWasson
description: ""
ms.author: riande
manager: wpickett
ms.date: 06/16/2014
ms.topic: article
ms.assetid: 
ms.technology: dotnet-webapi
ms.prod: .net-framework
msc.legacyurl: /web-api/overview/data/using-web-api-with-entity-framework/part-7
---
Create the View (UI)
====================
by [Mike Wasson](https://github.com/MikeWasson)

[Download Completed Project](https://github.com/MikeWasson/BookService)

In this section, you will start to define the HTML for the app, and add data binding between the HTML and the view model.

Open the file Views/Home/Index.cshtml. Replace the entire contents of that file with the following.

    @section scripts {
      @Scripts.Render("~/bundles/app")
    }
    
    <div class="page-header">
      <h1>BookService</h1>
    </div>
    
    <div class="row">
    
      <div class="col-md-4">
        <div class="panel panel-default">
          <div class="panel-heading">
            <h2 class="panel-title">Books</h2>
          </div>
          <div class="panel-body">
            <ul class="list-unstyled" data-bind="foreach: books">
              <li>
                <strong><span data-bind="text: AuthorName"></span></strong>: <span data-bind="text: Title"></span>
                <small><a href="#">Details</a></small>
              </li>
            </ul>
          </div>
        </div>
        <div class="alert alert-danger" data-bind="visible: error"><p data-bind="text: error"></p></div>
      </div>
    
      <div class="col-md-4">
        <!-- TODO: Book details -->
      </div>
    
      <div class="col-md-4">
        <!-- TODO: Add new book -->
      </div>
    </div>

Most of the `div` elements are there for [Bootstrap](http://getbootstrap.com/) styling. The important elements are the ones with `data-bind` attributes. This attribute links the HTML to the view model.

For example:

    <p data-bind="text: error">

In this example, the &quot;`text`&quot; binding causes the `<p>` element to show the value of the `error` property from the view model. Recall that `error` was declared as a `ko.observable`:

    self.error = ko.observable();

Whenever a new value is assigned to `error`, Knockout updates the text in the `<p>` element.

The `foreach` binding tells Knockout to loop through the contents of the `books` array. For each item in the array, Knockout creates a new &lt;li&gt; element. Bindings inside the context of the `foreach` refer to properties on the array item. For example:

    <span data-bind="text: Author"></span>

Here the `text` binding reads the Author property of each book.

If you run the application now, it should look like this:

![](part-7/_static/image1.png)

The list of books loads asynchronously, after the page loads. Right now, the &quot;Details&quot; links are not functional. We'll add this functionality in the next section.

>[!div class="step-by-step"] [Previous](part-6.md) [Next](part-8.md)