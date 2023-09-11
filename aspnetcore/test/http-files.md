---
title: Use .http files in Visual Studio 2022
author: tdykstra
description: Learn how to use .http files in Visual Studio 2022 to test ASPNET Core apps.
monikerRange: '>= aspnetcore-8.0'
ms.topic: how-to
ms.author: tdykstra
ms.date: 08/01/2023
uid: test/http-files
---
# Use .http files in Visual Studio 2022

The [Visual Studio 2022](https://visualstudio.microsoft.com/vs/preview/) `.http` file editor provides a convenient way to test ASP.NET Core projects, especially API apps.  The editor provides a UI that:

* Creates and updates `.http` files.
* Sends HTTP requests specified in `.http` files.
* Displays the responses.

This article contains documentation for:

* [The `.http` file syntax](#http-file-syntax).
* [How to use the `.http` file editor](#use-the-http-file-editor).
* [How to create requests in `.http` files by using the Visual Studio 2022 **Endpoints Explorer**](#use-endpoints-explorer).

The `.http` file format and editor was inspired by the Visual Studio Code [REST Client extension](https://marketplace.visualstudio.com/items?itemName=humao.rest-client). The Visual Studio 2022 `.http` editor recognizes `.rest` as an alternative file extension for the same file format.

## Prerequisites

* [Visual Studio 2022 version 17.6 or later](https://visualstudio.microsoft.com/vs/) with the **ASP.NET and web development** workload installed.

## `.http` file syntax

The following sections explain `.http` file syntax.

### Comments

Lines that start with either `#` or `//` are comments. These lines are ignored when Visual Studio sends HTTP requests.

### Variables

A line that starts with `@` defines a variable by using the syntax `@VariableName=Value`.

Variables can be referenced in requests that are defined later in the file. They are referenced by wrapping their names in double curly braces, `{{` and `}}`. The following example shows two variables defined and used in a request:

```
@hostname=localhost
@port=44320
GET https://{{hostname}}:{{port}}/weatherforecast
```

Variables can be defined using values of other variables that were defined earlier in the file. The following example uses one variable in the request instead of the two shown in the preceding example:

```
@hostname=localhost
@port=44320
@host={{hostname}}:{{port}}
GET https://{{host}}/api/search/tool
```

### Requests

The format for an HTTP request is `HTTPMethod URL HTTPVersion`, all on one line, where:

* `HTTPMethod` is the HTTP method to use, for example:
  * [OPTIONS](https://developer.mozilla.org/docs/Web/HTTP/Methods/OPTIONS)
  * [GET](https://developer.mozilla.org/docs/Web/HTTP/Methods/GET)
  * [HEAD](https://developer.mozilla.org/docs/Web/HTTP/Methods/HEAD)
  * [POST](https://developer.mozilla.org/docs/Web/HTTP/Methods/POST)
  * [PUT](https://developer.mozilla.org/docs/Web/HTTP/Methods/put)
  * [PATCH](https://developer.mozilla.org/docs/Web/HTTP/Methods/PATCH)
  * [DELETE](https://developer.mozilla.org/docs/Web/HTTP/Methods/DELETE)
  * [TRACE](https://developer.mozilla.org/docs/Web/HTTP/Methods/TRACE)
  * [CONNECT](https://developer.mozilla.org/docs/Web/HTTP/Methods/CONNECT)
* `URL` is the URL to send the request to. The URL can include query string parameters. The URL doesn't have to point to a local web project. It can point to any URL that Visual Studio can access.
* `HTTPVersion` is optional and specifies the HTTP version that should be used, that is, `HTTP/1.1`, `HTTP/2`, or `HTTP/3`.

A file can contain multiple requests by using lines with `###` as delimiters. The following example showing 3 requests in a file illustrates this syntax:

```
GET https://localhost:7220/weatherforecast

###

GET https://localhost:7220/weatherforecast?date=2023-05-11&location=98006

###

GET https://localhost:7220/weatherforecast HTTP/3

###
```

## Request headers

To add one or more headers, add each header on its own line immediately after the request line. Don't include any blank lines between the request line and the first header or between subsequent header lines. The format is `HeaderName: Value`, as shown in the following examples:

```
GET https://localhost:7220/weatherforecast
Date: Wed, 27 Apr 2023 07:28:00 GMT

###

GET https://localhost:7220/weatherforecast
Cache-Control: max-age=604800
Age: 100

###
```

> [!IMPORTANT]
> When calling an API that authenticates with headers, do not commit any secrets to a source code repository.

### Body

Add the request body after a blank line, as shown in the following example:

```
POST https://localhost:7220/weatherforecast
Content-Type: application/json
Accept-Language: en-US,en;q=0.5

{
    "date": "2023-05-10",
    "temperatureC": 30,
    "summary": "Warm"
}

###
```

### Unsupported syntax

The Visual Studio 2022 `.http` file editor doesn't have all the features that the Visual Studio Code [REST Client extension](https://marketplace.visualstudio.com/items?itemName=humao.rest-client) has. The following list includes some of the more significant features available only in the Visual Studio Code extension:

* Optional HTTP method
* Request line that spans more than one line
* Named requests
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

## Use the `.http` file editor

Create an `.http` file by using the **Add New Item** dialog or by renaming the extension of any text file to `.http`. Send a request by selecting the green "run" button to the left of the request. The response appears in a separate pane.

### Create an `.http` file

* In **Solution Explorer**, right-click an ASP.NET Core project.
* In the context menu, select **Add** > **New Item**.
* In the **Add New Item** dialog, select **ASP.NET Core** > **General**.
* Select **HTTP File**, and select **Add**.

  :::image type="content" source="~/test/http-files/_static/add-http-file.png" alt-text="Add New Item dialog showing HTTP File type selected.":::

## Send an HTTP request

* Add at least one [request](#requests) to an `.http` file and save the file.
* If the request URL points to localhost and the project's port, run the project before trying to send a request to it.
* Select the green "run" button to the left of the request to be sent.

  The request is sent to the specified URL, and the response appears in a separate pane to the right of the editor window.

  :::image type="content" source="~/test/http-files/_static/make-request.png" alt-text=".http file editor window with 'run' button highlighted and showing the response pane.":::

## Use Endpoints Explorer

**Endpoints Explorer** is a tool window in Visual Studio 2022 that provides a UI that integrates with the `.http` file editor for testing HTTP requests.

### Open Endpoints Explorer

Select **View** > **Other Windows** > **Endpoints Explorer**.

### Add a request to an `.http` file

Right-click a request in **Endpoints Explorer** and select **Generate Request**.

:::image type="content" source="~/test/http-files/_static/generate-request.png" alt-text="Endpoints Explorer window showing request context menu with 'Generate Request' menu selection highlighted.":::

* If an `.http` file with the project name as the file name exists, the request is added to that file.
* Otherwise, an `.http` file is created with the project name as the file name, and the request is added to that file.

The preceding screenshot shows endpoints defined by the minimal API project template. The following example shows the request that is generated for the selected endpoint:

```
@ApiApplication1_HostAddress = http://localhost:5155

Get {{ApiApplication1_HostAddress}}/todos/

###
```

Send the request as described [earlier in this article](#send-an-http-request).

## See also

* [Endpoints Explorer window only recognizes literal strings for routes](https://github.com/dotnet/AspNetCore.Docs/issues/30293)
* [Web API development in Visual Studio 2022](https://devblogs.microsoft.com/visualstudio/web-api-development-in-visual-studio-2022/)
* [Visual Studio Code REST Client extension](https://marketplace.visualstudio.com/items?itemName=humao.rest-client)
