---
title: "Add a New Item to the Database | Microsoft Docs"
author: MikeWasson
description: ""
ms.author: riande
manager: wpickett
ms.date: 06/16/2014
ms.topic: article
ms.assetid: 
ms.technology: dotnet-webapi
ms.prod: .net-framework
msc.legacyurl: /web-api/overview/data/using-web-api-with-entity-framework/part-9
---
Add a New Item to the Database
====================
by [Mike Wasson](https://github.com/MikeWasson)

[Download Completed Project](https://github.com/MikeWasson/BookService)

In this section, you will add the ability for users to create a new book. In app.js, add the following code to the view model:

    self.authors = ko.observableArray();
    self.newBook = {
        Author: ko.observable(),
        Genre: ko.observable(),
        Price: ko.observable(),
        Title: ko.observable(),
        Year: ko.observable()
    }
    
    var authorsUri = '/api/authors/';
    
    function getAuthors() {
        ajaxHelper(authorsUri, 'GET').done(function (data) {
            self.authors(data);
        });
    }
    
    self.addBook = function (formElement) {
        var book = {
            AuthorId: self.newBook.Author().Id,
            Genre: self.newBook.Genre(),
            Price: self.newBook.Price(),
            Title: self.newBook.Title(),
            Year: self.newBook.Year()
        };
    
        ajaxHelper(booksUri, 'POST', book).done(function (item) {
            self.books.push(item);
        });
    }
    
    getAuthors();

In Index.cshtml, replace the following markup:

    <div class="col-md-4">
        <!-- TODO: Add new book -->
    </div>

With:

    <div class="col-md-4">
    <div class="panel panel-default">
      <div class="panel-heading">
        <h2 class="panel-title">Add Book</h2>
      </div>
    
      <div class="panel-body">
        <form class="form-horizontal" data-bind="submit: addBook">
          <div class="form-group">
            <label for="inputAuthor" class="col-sm-2 control-label">Author</label>
            <div class="col-sm-10">
              <select data-bind="options:authors, optionsText: 'Name', value: newBook.Author"></select>
            </div>
          </div>
    
          <div class="form-group" data-bind="with: newBook">
            <label for="inputTitle" class="col-sm-2 control-label">Title</label>
            <div class="col-sm-10">
              <input type="text" class="form-control" id="inputTitle" data-bind="value:Title"/>
            </div>
    
            <label for="inputYear" class="col-sm-2 control-label">Year</label>
            <div class="col-sm-10">
              <input type="number" class="form-control" id="inputYear" data-bind="value:Year"/>
            </div>
    
            <label for="inputGenre" class="col-sm-2 control-label">Genre</label>
            <div class="col-sm-10">
              <input type="text" class="form-control" id="inputGenre" data-bind="value:Genre"/>
            </div>
    
            <label for="inputPrice" class="col-sm-2 control-label">Price</label>
            <div class="col-sm-10">
              <input type="number" step="any" class="form-control" id="inputPrice" data-bind="value:Price"/>
            </div>
          </div>
          <button type="submit" class="btn btn-default">Submit</button>
        </form>
      </div>
    </div>
    </div>

This markup creates a form for submitting a new author. The values for the author drop-down list are data-bound to the `authors` observable in the view model. For the other form inputs, the values are data-bound to the `newBook` property of the view model.

The submit handler on the form is bound to the `addBook` function:

    <form class="form-horizontal" data-bind="submit: addBook">

The `addBook` function reads the current values of the data-bound form inputs to create a JSON object. Then it POSTs the JSON object to `/api/books`.

>[!div class="step-by-step"] [Previous](part-8.md) [Next](part-10.md)