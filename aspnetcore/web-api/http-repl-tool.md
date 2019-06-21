---
title: Use the HTTP REPL tool
author: scottaddie
description: Learn how to use the HTTP REPL .NET Core Global Tool to browse and test an ASP.NET Core web API.
monikerRange: '>= aspnetcore-3.0'
ms.author: scaddie
ms.custom: mvc
ms.date: 06/21/2019
uid: web-api/http-repl-tool
---
# Use the HTTP REPL tool

The HTTP REPL is a cross-platform tool that's supported everywhere .NET Core is supported.

## Prerequisites

* [.NET Core SDK 3.0.100](https://dotnet.microsoft.com/download/dotnet-core/3.0) or later

## Installation

To install the HTTP REPL:

```console
dotnet tool install -g dotnet-httprepl
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

The preceding command displays output similar to the following:

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
The REPL allows you to navigate your URL space and focus on specific APIS that you are working on.

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
ui             Displays the swagger UI page, if available, in the default browser.

Use help <COMMAND> to learn more details about individual commands. e.g. `help get`
```

The HTTP REPL offers command completion. Pressing `Tab` iterates through the list of commands that complete the characters or API endpoint that you typed. The following sections outline the available CLI commands. 

## Connect to the API service

Connect to a service by running the following command:

```console
dotnet httprepl <BASE URI>
```

`<BASE URI>` is the base URI for the service. For example, `dotnet httprepl http://localhost:5000`.

Alternatively, you can run the navigation command `set base <BASE URI>` at any time while the HTTP REPL is running. For example, `(Disconnected)~ set base http://localhost:5000`.

## Point to the Swagger document for the API service

To properly inspect the service, set the relative URI to the Swagger document for the API service. To do so, run the navigation command `set swagger <RELATIVE URI>`. For example, `http://localhost:5000~ set swagger /swagger/v1/swagger.json`.

## Navigate the API service

To list the different endpoints at the current subtree of the API service, run the command `ls`.

```console
http://localhot:5000~ ls
```

The preceding command displays output similar to the following:

```console
.        []
People   [get|post]
Values   [get|post]

http://localhost:5000/~
```

To navigate to a different endpoint of the API service, run the command `cd`.

```console
http://localhost:5000~ cd people
```

The preceding command displays output similar to the following:

```console
/people    [get|post]

http://localhost:5000/people~
```

## Test the API service

To test the API service, you can issue GET, POST, PUT, DELETE, PATCH, HEAD, and OPTIONS [HTTP requests](https://github.com/microsoft/api-guidelines/blob/vNext/Guidelines.md#74-supported-methods).

### HTTP GET requests

To issue an HTTP GET request, run the `get` command:

```console
http://localhost:5000~ get
```

The preceding command displays output similar to the following:

```console
HTTP/1.1 200 OK
Content-Type: application/json; charset=utf-8
Date: Fri, 21 Jun 2019 03:38:45 GMT
Server: Kestrel
Transfer-Encoding: chunked

[
  {
    "id": 0,
    "name": "Scott Hunter"
  },
  {
    "id": 1,
    "name": "Scott Hanselman"
  },
  {
    "id": 2,
    "name": "Scott Guthrie"
  }
]


http://localhost:5000/People~
```

You can also retrieve a specific record:

```console
http://localhost:5000~ get 2
```

The preceding command displays output similar to the following:

```console
HTTP/1.1 200 OK
Content-Type: application/json; charset=utf-8
Date: Fri, 21 Jun 2019 06:17:57 GMT
Server: Kestrel
Transfer-Encoding: chunked

[
  {
    "id": 2,
    "name": "Scott Guthrie"
  }
]


http://localhost:5000/People~
```

### HTTP POST requests

To issue an HTTP POST request, run the `post` command:

```console
http://localhost:5000~ post
```

Issuing a `post` command opens an editor with the JSON template for you to enter the data to post. To use your preferred editor, use the command `pref set editor.command.default '<EXECUTABLE>'`, where `<EXECUTABLE>` is the full path to the editor's executable file. For example, `pref set editor.command.default 'C:\Program Files\Microsoft VS Code\Code.exe'`.

## Additional resources

* [REST API requests](https://github.com/microsoft/api-guidelines/blob/vNext/Guidelines.md#74-supported-methods)
* [HTTPRepl GitHub repository](https://github.com/aspnet/AspLabs)
