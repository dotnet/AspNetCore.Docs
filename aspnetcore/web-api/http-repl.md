---
title: Test APIs with the HTTP REPL tool
author: scottaddie
description: Learn how to use the HTTP REPL .NET Core Global Tool to browse and test an ASP.NET Core web API.
monikerRange: '>= aspnetcore-2.1'
ms.author: scaddie
ms.custom: mvc
ms.date: 06/28/2019
uid: web-api/http-repl
---
# Test APIs with the HTTP REPL tool

By [Scott Addie](https://twitter.com/Scott_Addie)

The HTTP REPL is:

* A lightweight, cross-platform command-line tool that's supported everywhere .NET Core is supported.
* Used for making HTTP requests to test ASP.NET Core web APIs and view their results.

To follow along, [view or download the sample ASP.NET Core web API](https://github.com/aspnet/AspNetCore.Docs/tree/master/aspnetcore/web-api/http-repl-tool/samples) ([how to download](xref:index#how-to-download-a-sample)).

## Prerequisites

* [!INCLUDE [2.1-SDK](../../includes/2.1-SDK.md)]

## Installation

To install the HTTP REPL:

```console
dotnet tool install -g dotnet-httprepl --version 2.2.0-preview3-35497
```

A [.NET Core Global Tool](/dotnet/core/tools/global-tools#install-a-global-tool) is installed from the [dotnet-httprepl](https://www.nuget.org/packages/dotnet-httprepl) NuGet package.

## Usage

After successful installation of the tool, the following command can be used to start the HTTP REPL:

```console
dotnet httprepl
```

To view the available HTTP REPL commands:

```console
dotnet httprepl --help
```

The following output is displayed:

```console
Usage: dotnet httprepl [<BASE_ADDRESS>] [options]

Arguments:
  <BASE_ADDRESS> - The initial base address for the REPL.

Options:
  --help - Show help information.

REPL Commands:

HTTP Commands:
Use these commands to execute requests against your application.

GET            Issues a GET request.
POST           Issues a POST request.
PUT            Issues a PUT request.
DELETE         Issues a DELETE request.
PATCH          Issues a PATCH request.
HEAD           Issues a HEAD request.
OPTIONS        Issues an OPTIONS request.

set header     Sets or clears a header for all requests. e.g. `set header content-type application/json`


Navigation Commands:
The REPL allows you to navigate your URL space and focus on specific APIs that you are working on.

set base       Set the base URI. e.g. `set base http://locahost:5000`
set swagger    Set the URI, relative to your base if set, of the Swagger document for this API. e.g. `set swagger /swagger/v1/swagger.json`
ls             Show all endpoints for the current path.
cd             Append the given directory to the currently selected path, or move up a path when using `cd ..`.

Shell Commands:
Use these commands to interact with the REPL shell.

clear          Removes all text from the shell.
echo [on/off]  Turns request echoing on or off, show the request that was made when using request commands.
exit           Exit the shell.

REPL Customization Commands:
Use these commands to customize the REPL behavior..

pref [get/set] Allows viewing or changing preferences, e.g. 'pref set editor.command.default 'C:\Program Files\Microsoft VS Code\Code.exe'`
run            Runs the script at the given path. A script is a set of commands that can be typed with one command per line.
ui             Displays the Swagger UI page, if available, in the default browser.

Use help <COMMAND> to learn more details about individual commands. e.g. `help get`
```

The HTTP REPL offers command completion. Pressing `Tab` iterates through the list of commands that complete the characters or API endpoint that you typed. The following sections outline the available CLI commands. 

## Connect to the API service

Connect to a service by running the following command:

```console
dotnet httprepl <BASE URI>
```

`<BASE URI>` is the base URI for the service. For example, `dotnet httprepl https://localhost:5001`.

Alternatively, run the following command at any time while the HTTP REPL is running:

```console
set base <BASE URI>
```

For example, `(Disconnected)~ set base https://localhost:5001`.

## Point to the Swagger document for the API service

To properly inspect the service, set the relative URI to the Swagger document for the API service. To do so, run the following command:

```console
set swagger <RELATIVE URI>
```

For example, `https://localhost:5001~ set swagger /swagger/v1/swagger.json`.

## Navigate the web API

### View available endpoints

To list the different endpoints at the current subtree of the web API, run the `ls` command:

```console
https://localhot:5001~ ls
```

The following output format is displayed:

```console
.        []
Fruits   [get|post]
People   [get|post]

https://localhost:5001/~
```

Alternatively, run the `ui` command to open the web API's Swagger UI page in a browser. For example:

```console
https://localhost:5001/~ ui
```

### Navigate to an endpoint

To navigate to a different endpoint of the API service, run the `cd` command:

```console
https://localhost:5001~ cd people
```

The following output format is displayed:

```console
/people    [get|post]

https://localhost:5001/people~
```

## Set the default colors

To customize the default HTTP REPL tool coloring, run the `pref get` command. For example:

```console
https://localhost:5001/~ pref get
```

The preceding command displays the available key-value pairs:

```console
colors.json=Green
colors.json.arrayBrace=BoldCyan
colors.json.comma=BoldYellow
colors.json.name=BoldMagenta
colors.json.nameSeparator=BoldWhite
colors.json.objectBrace=Cyan
colors.protocol=BoldGreen
colors.status=BoldYellow
```

Locate the key corresponding to the color to be changed. For example, change the `colors.json` key value from `Green` to `White` as follows:

```console
https://localhost:5001/people~ pref set colors.json White
```

Only the [allowed colors](https://github.com/aspnet/HttpRepl/blob/01d5c3c3373e98fe566ff5ef8a17c571de880293/src/Microsoft.Repl/ConsoleHandling/AllowedColors.cs) may be used. The updated coloring is persisted across the current session and is honored in future sessions. Subsequent HTTP requests display output with the new coloring.

## Set the default editor

To test API methods requiring an HTTP request body, a default editor must be set. The HTTP REPL tool launches the configured editor for the sole purpose of composing the request body. Run the following command to set your preferred editor as the default editor:

```console
pref set editor.command.default "<EXECUTABLE>"
```

In the preceding command, `<EXECUTABLE>` is the full path to the editor's executable file. For example, run the following command to set Visual Studio Code as the default editor:

# [Linux](#tab/linux)

```console
pref set editor.command.default "/usr/bin/code"
```

# [macOS](#tab/macos)

```console
pref set editor.command.default "/Applications/Visual Studio Code.app/Contents/Resources/app/bin/code"
```

# [Windows](#tab/windows)

```console
pref set editor.command.default "C:\Program Files\Microsoft VS Code\Code.exe"
```

---

## Test the API service

To test the API service, issue one of the following [HTTP requests](https://github.com/microsoft/api-guidelines/blob/vNext/Guidelines.md#74-supported-methods):

* [GET](#http-get-requests)
* [POST](#http-post-requests)
* [PUT](#http-put-requests)
* [DELETE](#http-delete-requests)
* PATCH
* HEAD
* OPTIONS

### HTTP GET requests

To issue an HTTP GET request:

1. Run the `get` command on an endpoint that supports it:

    ```console
    https://localhost:5001/people~ get
    ```
    
    The preceding command displays the following output format:
    
    ```console
    HTTP/1.1 200 OK
    Content-Type: application/json; charset=utf-8
    Date: Fri, 21 Jun 2019 03:38:45 GMT
    Server: Kestrel
    Transfer-Encoding: chunked
    
    [
      {
        "id": 1,
        "name": "Scott Hunter"
      },
      {
        "id": 2,
        "name": "Scott Hanselman"
      },
      {
        "id": 3,
        "name": "Scott Guthrie"
      }
    ]
    
    
    https://localhost:5001/people~
    ```

1. Retrieve a specific record by passing a parameter to the `get` command:

    ```console
    https://localhost:5001/people~ get 2
    ```
    
    The preceding command displays the following output format:
    
    ```console
    HTTP/1.1 200 OK
    Content-Type: application/json; charset=utf-8
    Date: Fri, 21 Jun 2019 06:17:57 GMT
    Server: Kestrel
    Transfer-Encoding: chunked
    
    [
      {
        "id": 2,
        "name": "Scott Hanselman"
      }
    ]
    
    
    https://localhost:5001/people~
    ```

### HTTP POST requests

To issue an HTTP POST request:

1. Set the appropriate HTTP request headers. For example, indicate that the request body's media type is JSON:

    ```console
    https://localhost:5001/people~ set header content-type application/json    
    ```

1. Run the `post` command on an endpoint that supports it:

    ```console
    https://localhost:5001/people~ post
    ```

    The default editor opens a *.tmp* file with a JSON template representing the HTTP request body. For example:

    ```json
    {
      "id": 0,
      "name": "Scott Addie"
    }
    ```

    > [!TIP]
    > To set the default editor, see the [Set the default editor](#set-the-default-editor) section.

1. Modify the JSON template, and save your changes.

1. Close the editor. The following output appears in the command shell:

    ```console
    HTTP/1.1 201 Created
    Content-Type: application/json; charset=utf-8
    Date: Thu, 27 Jun 2019 21:24:18 GMT
    Location: https://localhost:5001/People/4
    Server: Kestrel
    Transfer-Encoding: chunked
    
    {
      "id": 4,
      "name": "Scott Addie"
    }
    
    
    https://localhost:5001/People~    
    ```

### HTTP PUT requests

To issue an HTTP PUT request:

1. *Optional*: Run the `get` command to view the data before modifying it:

    ```console
    https://localhost:5001/fruits~ get
    HTTP/1.1 200 OK
    Content-Type: application/json; charset=utf-8
    Date: Sat, 22 Jun 2019 00:07:32 GMT
    Server: Kestrel
    Transfer-Encoding: chunked
    
    [
      {
        "id": 1,
        "data": "Apple"
      },
      {
        "id": 2,
        "data": "Orange"
      },
      {
        "id": 3,
        "data": "Strawberry"
      }
    ]

1. Set the appropriate HTTP request headers. For example, indicate that the request body's media type is JSON:

    ```console
    https://localhost:5001/fruits~ set header content-type application/json    
    ```

1. Run the `put` command on an endpoint that supports it:

    ```console    
    https://localhost:5001/fruits~ put 2
    ```

    The default editor opens a *.tmp* file with a JSON template representing the HTTP request body. For example:

    ```json
    {
      "id": 2,
      "name": "Cherry"
    }
    ```

    > [!TIP]
    > To set the default editor, see the [Set the default editor](#set-the-default-editor) section.

1. Modify the JSON template, and save your changes.

1. Close the editor. The following output appears in the command shell:

    ```console
    [main 2019-06-28T17:27:01.805Z] update#setState idle
    HTTP/1.1 204 No Content
    Date: Fri, 28 Jun 2019 17:28:21 GMT
    Server: Kestrel
    ```

1. *Optional*: Issue a `get` command to see the modifications. For example, if you typed "Cherry" in the editor, a `get` returns the following:

    ```console
    https://localhost:5001/fruits~ get
    HTTP/1.1 200 OK
    Content-Type: application/json; charset=utf-8
    Date: Sat, 22 Jun 2019 00:08:20 GMT
    Server: Kestrel
    Transfer-Encoding: chunked
    
    [
      {
        "id": 1,
        "data": "Apple"
      },
      {
        "id": 2,
        "data": "Cherry"
      },
      {
        "id": 3,
        "data": "Strawberry"
      }
    ]
    
    
    https://localhost:5001/fruits~ 
    ```

### HTTP DELETE requests

To issue an HTTP DELETE request:

1. Run the `delete` command on an endpoint that supports it:

    ```console
    https://localhost:5001/fruits~ delete 2
    ```

    The preceding command displays the following output format:

    ```console
    HTTP/1.1 204 No Content
    Date: Fri, 28 Jun 2019 17:36:42 GMT
    Server: Kestrel
    ```

1. *Optional*: Issue a `get` command to see the modifications. In this example, a `get` returns the following:

    ```console
    https://localhost:5001/fruits~ get
    HTTP/1.1 200 OK
    Content-Type: application/json; charset=utf-8
    Date: Sat, 22 Jun 2019 00:16:30 GMT
    Server: Kestrel
    Transfer-Encoding: chunked
    
    [
      {
        "id": 1,
        "data": "Apple"
      },
      {
        "id": 3,
        "data": "Strawberry"
      }
    ]
    
    
    https://localhost:5001/fruits~
    ```

## Toggle HTTP request display

By default, display of the HTTP request being sent is suppressed.

### Enable display

View the HTTP request being sent by running the `echo on` command. For example:

```console
https://localhost:5001/people~ echo on
Request echoing is on
```

Subsequent HTTP requests in the current session display the request headers. For example:

```console
https://localhost:5001/People~ POST

[main 2019-06-28T18:50:11.930Z] update#setState idle
Request to https://localhost:5001...

POST /People HTTP/1.1
Content-Length: 41
Content-Type: application/json
User-Agent: HTTP-REPL

{
  "id": 0,
  "name": "Scott Addie"
}

Response from https://localhost:5001...

HTTP/1.1 201 Created
Content-Type: application/json; charset=utf-8
Date: Fri, 28 Jun 2019 18:50:21 GMT
Location: https://localhost:5001/People/4
Server: Kestrel
Transfer-Encoding: chunked

{
  "id": 4,
  "name": "Scott Addie"
}


https://localhost:5001/People~
```

### Disable display

Suppress display of the HTTP request being sent by running the `echo off` command. For example:

```console
https://localhost:5001/people~ echo off
Request echoing is off
```

## Additional resources

* [REST API requests](https://github.com/microsoft/api-guidelines/blob/vNext/Guidelines.md#74-supported-methods)
* [HTTP REPL GitHub repository](https://github.com/aspnet/HttpRepl)
