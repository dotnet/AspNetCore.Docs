## Overview

This tutorial creates the following API:

|API | Description | Request body | Response body |
|--- | ---- | ---- | ---- |
|GET /api/todo | Get all to-do items | None | Array of to-do items|
|GET /api/todo/{id} | Get an item by ID | None | To-do item|
|POST /api/todo | Add a new item | To-do item | To-do item |
|PUT /api/todo/{id} | Update an existing item &nbsp; | To-do item | None |
|DELETE /api/todo/{id} &nbsp; &nbsp; | Delete an item &nbsp; &nbsp; | None | None|

<br>

The following diagram shows the basic design of the app.

![The client is represented by a box on the left and submits a request and receives a response from the application, a box drawn on the right. Within the application box, three boxes represent the controller, the model, and the data access layer. The request comes into the application's controller, and read/write operations occur between the controller and the data access layer. The model is serialized and returned to the client in the response.](../../tutorials/first-web-api/_static/architecture.png)

* The client is whatever consumes the web API (mobile app, browser, etc.). This tutorial doesn't create a client. [Postman](https://www.getpostman.com/) or [curl](https://developer.apple.com/legacy/library/documentation/Darwin/Reference/ManPages/man1/curl.1.html) is used as the client to test the app.

* A *model* is an object that represents the data in the app. In this case, the only model is a to-do item. Models are represented as C# classes, also know as **P**lain **O**ld **C**# **O**bject (POCOs).

* A *controller* is an object that handles HTTP requests and creates the HTTP response. This app has a single controller.

* To keep the tutorial simple, the app doesn’t use a persistent database. The sample app stores to-do items in an in-memory database.
