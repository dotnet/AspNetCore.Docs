---
title: Use .http/.rest files in Visual Studio 2022
author: tdykstra
description: Learn how to use .http/.rest files in Visual Studio 2022 to test ASPNET Core apps.
monikerRange: '>= aspnetcore-8.0'
ms.author: tdykstra
ms.date: 05/09/2023
uid: test/http-files
---
# Use .http/.rest files in Visual Studio 2022

Visual Studio 2022 has an editor for `.http` files (`.rest` is an alternative file extension for the same file format). The purpose of `.http` files is to provide a convenient syntax for making HTTP requests to test ASP.NET Core API apps. The Visual Studio editor window provides a UI to make requests and display the responses. This article is reference documentation for the `.http` file format and the Visual Studio `.http` file editor.

## Prerequisites

* [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) version 17.6 Preview or later with the **ASP.NET and web development** workload installed.

## The following sections explain .http file syntax. For information about how to use the .http file editor, see 
## Comments

Comments are lines that start with either `#` or `//`. These lines are ignored when Visual Studio makes HTTP requests.

## Variables

Variable names begin with an `@` and are followed by an `=` and the value of the variable: `@VariableName=value`. For example:

Variables can be referenced in requests that are defined later in the file. They are referenced by wrapping their names in double curly braces (`{{` and `}}`). The following example shows two variables used in a request:

```
@hostname=localhost
@port=44320
GET https://{{hostname}}:{{port}}/api/search/tool
```

Variables can be defined using values of other variables that have already been defined. The following example uses one variable in the request instead of the two shown in the preceding example:

```
@hostname=localhost
@port=44320
@host={{hostname}}:{{port}}
GET https://{{host}}/api/search/tool
```

## Requests

The format for an HTTP request is `HTTPMethod URL HTTPVersion`, all on one line, where:

* `HTTPMethod` is the HTTP method to use, for example, GET, POST, PUT, PATCH. The method is case-sensitive (must be all-caps).
* `URL` is the URL to send the request to. This URL can include query string parameters.
* `HTTPVersion` is optional and specifies the HTTP version that should be used.

A file can contain multiple requests by using lines with `###` as delimiters:

The following examples illustrate this syntax:

```
GET https://httpbin.org/get

###

GET https://httpbin.org/get?name=Nancy&phone=555-555-3333

###

GET https://httpbin.org/get HTTP/1.1
```

## Request headers

To add one or more headers, add each header on its own line immediately after after the request line (no blank lines). The format is `HeaderName: Value`, as shown in the following examples:

```
GET https://httpbin.org/get?name=Nancy&phone=555-555-3333 HTTP/1.1
Date: Wed, 27 Apr 2023 07:28:00 GMT

###

GET https://httpbin.org/get?name=Nancy?&phone=555-555-3333
Cache-Control: max-age=604800
Age: 100
```

> [!IMPORTANT]
> When calling an API that authenticates with headers, be careful to not commit any secrets to a source code repository. We're working on ways to support secrets in a secure manner.

## Body

Add the request body after a blank line, as shown in the following example:

```
POST https://httpbin.org/post HTTP/1.1
Content-Type: application/json
Accept-Language: en-US,en;q=0.5

{
    "name": "sample",
    "time": "Wed, 21 Oct 2015 18:27:50 GMT"
}
```

## Unsupported syntax

The Visual Studio 2022 `.http` file editor was inspired by the [Visual Studio Code REST Client extension](https://marketplace.visualstudio.com/items?itemName=humao.rest-client) but does not have all the features of the Visual Studio Code extension. Some of the more significant features that it has but Visual Studio 2022 doesn't have are the following:

* Optional HTTP Method
* Request line that spans more than one line
* Named Requests
* Dynamic variables
* Environment files
* Specify file path as body of the request
* Mixed format for body when using multipart/form-data
* GraphQL requests
* cURL request
* Copy/paste as cURL
* Request history
* Save response body to file
* Certificate based authentication
* Prompt variables
* System variables
* Customize response preview
* Per-request settings

The Visual Studio 2022 `.http` file editor is sill under development, and some of these features might be added in the future. For more information, see [Visual Studio Code REST Client extension](https://marketplace.visualstudio.com/items?itemName=humao.rest-client).

## Use the Visual Studio `.http` file editor

The following sections explain how to use the Visual Studio 2022 `.http` file editor.

## Create an `.http` file

To create an .http file:

* In **Solution Explorer**, right-click an ASP.NET Core API or web API project.
* In the context menu, select **Add** > **New Item** > **ASP.NET Core** > **General**.
* Select **HTTP File**, and select **Add**.

  :::image type="content" source="~/test/http-files/_static/add-http-file.png" alt-text="Add New Item dialog showing HTTP File type selected.":::

## Make an HTTP request

To make a request:

* Add a [request](#requests) to the file and save the file.
* Run the project if the request URL points to localhost and the project's port.
* Select the green "run" button to the left of the request to be run.
  The request is sent to the specified URL, and the response appears in a separate pane to the right of the editor window.

  :::image type="content" source="~/test/http-files/_static/make-request.png" alt-text=".http file editor window with 'run' button highlighted and showing the response pane.":::





