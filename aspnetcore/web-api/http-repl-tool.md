---
title: Use the HTTP REPL tool
author: scottaddie
description: Learn how to use the HTTP REPL .NET Core Global Tool to brownse and test an ASP.NET Core web API.
ms.author: scaddie
ms.custom: mvc
ms.date: 05/22/2019
uid: web-api/http-repl-tool
---
# Use the HTTP REPL tool

The HTTP REPL is a cross-platform tool that's supported everywhere .NET Core is supported.

## Prerequisites

* .NET Core <3.0.100-preview6-012264> SDK or later

## Installation

To install the HTTP REPL:

```console
dotnet tool install -g dotnet-httprepl
```

A [.NET Core Global Tool](/dotnet/core/tools/global-tools#install-a-global-tool) is installed from the [dotnet-httprepl](https://www.nuget.org/packages/dotnet-httprepl) NuGet package.

## Usage

After successful installation of the tool, the following command can be used to start the httprepl:

```console
dotnet httprepl
```

to view the available httprepl commands:

```console
dotnet httprepl --help
```

The following sections outline the available CLI commands:
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
echo [on/off]  Turns request echoing on or off, show the request that was mode when using request commands.
exit           Exit the shell.

REPL Customization Commands:
Use these commands to customize the REPL behavior..

pref [get/set] Allows viewing or changing preferences, e.g. 'pref set editor.command.default 'C:\Program Files\Microsoft VS Code\Code.exe'`
run            Runs the script at the given path. A script is a set of commands that can be typed with one command per line.
ui             Displays the swagger UI page, if available, in the default browser.

Use help <COMMAND> to learn more details about individual commands. e.g. `help get`
```
## <Command heading here>



## Additional resources

* <Additional resource link here>
