---
title: Test web APIs with the HttpRepl
author: rick-anderson
description: Learn how to use the HttpRepl .NET Core Global Tool to browse and test an ASP.NET Core web API.
monikerRange: '>= aspnetcore-3.1'
ms.author: scaddie
ms.custom: mvc
ms.date: 11/12/2020
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: web-api/http-repl
---
# Test web APIs with the HttpRepl

The HTTP Read-Eval-Print Loop (REPL) is:

* A lightweight, cross-platform command-line tool that's supported everywhere .NET Core is supported.
* Used for making HTTP requests to test ASP.NET Core web APIs (and non-ASP.NET Core web APIs) and view their results.
* Capable of testing web APIs hosted in any environment, including localhost and Azure App Service.

The following [HTTP verbs](https://github.com/microsoft/api-guidelines/blob/vNext/Guidelines.md#74-supported-methods) are supported:

* [DELETE](#test-http-delete-requests)
* [GET](#test-http-get-requests)
* [HEAD](#test-http-head-requests)
* [OPTIONS](#test-http-options-requests)
* [PATCH](#test-http-patch-requests)
* [POST](#test-http-post-requests)
* [PUT](#test-http-put-requests)

To follow along, [view or download the sample ASP.NET Core web API](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/web-api/http-repl/samples) ([how to download](xref:index#how-to-download-a-sample)).

## Prerequisites

* [!INCLUDE [3.1-SDK](~/includes/3.1-SDK.md)]

## Installation

To install the HttpRepl, run the following command:

```dotnetcli
dotnet tool install -g Microsoft.dotnet-httprepl
```

A [.NET Core Global Tool](/dotnet/core/tools/global-tools#install-a-global-tool) is installed from the [Microsoft.dotnet-httprepl](https://www.nuget.org/packages/Microsoft.dotnet-httprepl) NuGet package.

## Usage

After successful installation of the tool, run the following command to start the HttpRepl:

```console
httprepl
```

To view the available HttpRepl commands, run one of the following commands:

```console
httprepl -h
```

```console
httprepl --help
```

The following output is displayed:

```console
Usage:
  httprepl [<BASE_ADDRESS>] [options]

Arguments:
  <BASE_ADDRESS> - The initial base address for the REPL.

Options:
  -h|--help - Show help information.

Once the REPL starts, these commands are valid:

Setup Commands:
Use these commands to configure the tool for your API server

connect        Configures the directory structure and base address of the api server
set header     Sets or clears a header for all requests. e.g. `set header content-type application/json`

HTTP Commands:
Use these commands to execute requests against your application.

GET            get - Issues a GET request
POST           post - Issues a POST request
PUT            put - Issues a PUT request
DELETE         delete - Issues a DELETE request
PATCH          patch - Issues a PATCH request
HEAD           head - Issues a HEAD request
OPTIONS        options - Issues a OPTIONS request

Navigation Commands:
The REPL allows you to navigate your URL space and focus on specific APIs that you are working on.

ls             Show all endpoints for the current path
cd             Append the given directory to the currently selected path, or move up a path when using `cd ..`

Shell Commands:
Use these commands to interact with the REPL shell.

clear          Removes all text from the shell
echo [on/off]  Turns request echoing on or off, show the request that was made when using request commands
exit           Exit the shell

REPL Customization Commands:
Use these commands to customize the REPL behavior.

pref [get/set] Allows viewing or changing preferences, e.g. 'pref set editor.command.default 'C:\\Program Files\\Microsoft VS Code\\Code.exe'`
run            Runs the script at the given path. A script is a set of commands that can be typed with one command per line
ui             Displays the Swagger UI page, if available, in the default browser

Use `help <COMMAND>` for more detail on an individual command. e.g. `help get`.
For detailed tool info, see https://aka.ms/http-repl-doc.
```

The HttpRepl offers command completion. Pressing the <kbd>Tab</kbd> key iterates through the list of commands that complete the characters or API endpoint that you typed. The following sections outline the available CLI commands.

## Connect to the web API

Connect to a web API by running the following command:

```console
httprepl <ROOT URI>
```

`<ROOT URI>` is the base URI for the web API. For example:

```console
httprepl https://localhost:5001
```

Alternatively, run the following command at any time while the HttpRepl is running:

```console
connect <ROOT URI>
```

For example:

```console
(Disconnected)> connect https://localhost:5001
```

### Manually point to the OpenAPI description for the web API

The connect command above will attempt to find the OpenAPI description automatically. If for some reason it's unable to do so, you can specify the URI of the OpenAPI description for the web API by using the `--openapi` option:

```console
connect <ROOT URI> --openapi <OPENAPI DESCRIPTION ADDRESS>
```

For example:

```console
(Disconnected)> connect https://localhost:5001 --openapi /swagger/v1/swagger.json
```

### Enable verbose output for details on OpenAPI description searching, parsing, and validation

Specifying the `--verbose` option with the `connect` command will produce more details when the tool searches for the OpenAPI description, parses, and validates it.

```console
connect <ROOT URI> --verbose
```

For example:

```console
(Disconnected)> connect https://localhost:5001 --verbose
Checking https://localhost:5001/swagger.json... 404 NotFound
Checking https://localhost:5001/swagger/v1/swagger.json... 404 NotFound
Checking https://localhost:5001/openapi.json... Found
Parsing... Successful (with warnings)
The field 'info' in 'document' object is REQUIRED [#/info]
The field 'paths' in 'document' object is REQUIRED [#/paths]
```

## Navigate the web API

### View available endpoints

To list the different endpoints (controllers) at the current path of the web API address, run the `ls` or `dir` command:

```console
https://localhost:5001/> ls
```

The following output format is displayed:

```console
.        []
Fruits   [get|post]
People   [get|post]

https://localhost:5001/>
```

The preceding output indicates that there are two controllers available: `Fruits` and `People`. Both controllers support parameterless HTTP GET and POST operations.

Navigating into a specific controller reveals more detail. For example, the following command's output shows the `Fruits` controller also supports HTTP GET, PUT, and DELETE operations. Each of these operations expects an `id` parameter in the route:

```console
https://localhost:5001/fruits> ls
.      [get|post]
..     []
{id}   [get|put|delete]

https://localhost:5001/fruits>
```

Alternatively, run the `ui` command to open the web API's Swagger UI page in a browser. For example:

```console
https://localhost:5001/> ui
```

### Navigate to an endpoint

To navigate to a different endpoint on the web API, run the `cd` command:

```console
https://localhost:5001/> cd people
```

The path following the `cd` command is case insensitive. The following output format is displayed:

```console
/people    [get|post]

https://localhost:5001/people>
```

## Customize the HttpRepl

The HttpRepl's default [colors](#set-color-preferences) can be customized. Additionally, a [default text editor](#set-the-default-text-editor) can be defined. The HttpRepl preferences are persisted across the current session and are honored in future sessions. Once modified, the preferences are stored in the following file:

# [Linux](#tab/linux)

*%HOME%/.httpreplprefs*

# [macOS](#tab/macos)

*%HOME%/.httpreplprefs*

# [Windows](#tab/windows)

*%USERPROFILE%\\.httpreplprefs*

---

The *.httpreplprefs* file is loaded on startup and not monitored for changes at runtime. Manual modifications to the file take effect only after restarting the tool.

### View the settings

To view the available settings, run the `pref get` command. For example:

```console
https://localhost:5001/> pref get
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

### Set color preferences

Response colorization is currently supported for JSON only. To customize the default HttpRepl tool coloring, locate the key corresponding to the color to be changed. For instructions on how to find the keys, see the [View the settings](#view-the-settings) section. For example, change the `colors.json` key value from `Green` to `White` as follows:

```console
https://localhost:5001/people> pref set colors.json White
```

Only the [allowed colors](https://github.com/dotnet/HttpRepl/blob/01d5c3c3373e98fe566ff5ef8a17c571de880293/src/Microsoft.Repl/ConsoleHandling/AllowedColors.cs) may be used. Subsequent HTTP requests display output with the new coloring.

When specific color keys aren't set, more generic keys are considered. To demonstrate this fallback behavior, consider the following example:

* If `colors.json.name` doesn't have a value, `colors.json.string` is used.
* If `colors.json.string` doesn't have a value, `colors.json.literal` is used.
* If `colors.json.literal` doesn't have a value, `colors.json` is used. 
* If `colors.json` doesn't have a value, the command shell's default text color (`AllowedColors.None`) is used.

### Set indentation size

Response indentation size customization is currently supported for JSON only. The default size is two spaces. For example:

```json
[
  {
    "id": 1,
    "name": "Apple"
  },
  {
    "id": 2,
    "name": "Orange"
  },
  {
    "id": 3,
    "name": "Strawberry"
  }
]
```

To change the default size, set the `formatting.json.indentSize` key. For example, to always use four spaces:

```console
pref set formatting.json.indentSize 4
```

Subsequent responses honor the setting of four spaces:

```json
[
    {
        "id": 1,
        "name": "Apple"
    },
    {
        "id": 2,
        "name": "Orange"
    },
    {
        "id": 3,
        "name": "Strawberry"
    }
]
```

### Set the default text editor

By default, the HttpRepl has no text editor configured for use. To test web API methods requiring an HTTP request body, a default text editor must be set. The HttpRepl tool launches the configured text editor for the sole purpose of composing the request body. Run the following command to set your preferred text editor as the default:

```console
pref set editor.command.default "<EXECUTABLE>"
```

In the preceding command, `<EXECUTABLE>` is the full path to the text editor's executable file. For example, run the following command to set Visual Studio Code as the default text editor:

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

To launch the default text editor with specific CLI arguments, set the `editor.command.default.arguments` key. For example, assume Visual Studio Code is the default text editor and that you always want the HttpRepl to open Visual Studio Code in a new session with extensions disabled. Run the following command:

```console
pref set editor.command.default.arguments "--disable-extensions --new-window"
```

> [!TIP]
> If your default editor is Visual Studio Code, you'll usually want to pass the `-w` or `--wait` argument to force Visual Studio Code to wait for you to close the file before returning.

### Set the OpenAPI Description search paths

By default, the HttpRepl has a set of relative paths that it uses to find the OpenAPI description when executing the `connect` command without the `--openapi` option. These relative paths are combined with the root and base paths specified in the `connect` command. The default relative paths are:

- `swagger.json`
- `swagger/v1/swagger.json`
- `/swagger.json`
- `/swagger/v1/swagger.json`
- `openapi.json`
- `/openapi.json`

To use a different set of search paths in your environment, set the `swagger.searchPaths` preference. The value must be a pipe-delimited list of relative paths. For example:

```console
pref set swagger.searchPaths "swagger/v2/swagger.json|swagger/v3/swagger.json"
```

Instead of replacing the default list altogether, the list can also be modified by adding or removing paths.

To add one or more search paths to the default list, set the `swagger.addToSearchPaths` preference. The value must be a pipe-delimited list of relative paths. For example:

```console
pref set swagger.addToSearchPaths "openapi/v2/openapi.json|openapi/v3/openapi.json"
```

To remove one or more search paths from the default list, set the `swagger.addToSearchPaths` preference. The value must be a pipe-delimited list of relative paths. For example:

```console
pref set swagger.removeFromSearchPaths "swagger.json|/swagger.json"
```

## Test HTTP GET requests

### Synopsis

```console
get <PARAMETER> [-F|--no-formatting] [-h|--header] [--response:body] [--response:headers] [-s|--streaming]
```

### Arguments

`PARAMETER`

The route parameter, if any, expected by the associated controller action method.

### Options

The following options are available for the `get` command:

[!INCLUDE [standard CLI options](~/includes/http-repl/standard-options.md)]

### Example

To issue an HTTP GET request:

1. Run the `get` command on an endpoint that supports it:

    ```console
    https://localhost:5001/people> get
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


    https://localhost:5001/people>
    ```

1. Retrieve a specific record by passing a parameter to the `get` command:

    ```console
    https://localhost:5001/people> get 2
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


    https://localhost:5001/people>
    ```

## Test HTTP POST requests

### Synopsis

```console
post <PARAMETER> [-c|--content] [-f|--file] [-h|--header] [--no-body] [-F|--no-formatting] [--response] [--response:body] [--response:headers] [-s|--streaming]
```

### Arguments

`PARAMETER`

The route parameter, if any, expected by the associated controller action method.

### Options

[!INCLUDE [standard CLI options](~/includes/http-repl/standard-options.md)]

[!INCLUDE [HTTP request body CLI options](~/includes/http-repl/requires-body-options.md)]

### Example

To issue an HTTP POST request:

1. Run the `post` command on an endpoint that supports it:

    ```console
    https://localhost:5001/people> post -h Content-Type=application/json
    ```

    In the preceding command, the `Content-Type` HTTP request header is set to indicate a request body media type of JSON. The default text editor opens a *.tmp* file with a JSON template representing the HTTP request body. For example:

    ```json
    {
      "id": 0,
      "name": ""
    }
    ```

    > [!TIP]
    > To set the default text editor, see the [Set the default text editor](#set-the-default-text-editor) section.

1. Modify the JSON template to satisfy model validation requirements:

    ```json
    {
      "id": 0,
      "name": "Scott Addie"
    }
    ```

1. Save the *.tmp* file, and close the text editor. The following output appears in the command shell:

    ```console
    HTTP/1.1 201 Created
    Content-Type: application/json; charset=utf-8
    Date: Thu, 27 Jun 2019 21:24:18 GMT
    Location: https://localhost:5001/people/4
    Server: Kestrel
    Transfer-Encoding: chunked

    {
      "id": 4,
      "name": "Scott Addie"
    }


    https://localhost:5001/people>
    ```

## Test HTTP PUT requests

### Synopsis

```console
put <PARAMETER> [-c|--content] [-f|--file] [-h|--header] [--no-body] [-F|--no-formatting] [--response] [--response:body] [--response:headers] [-s|--streaming]
```

### Arguments

`PARAMETER`

The route parameter, if any, expected by the associated controller action method.

### Options

[!INCLUDE [standard CLI options](~/includes/http-repl/standard-options.md)]

[!INCLUDE [HTTP request body CLI options](~/includes/http-repl/requires-body-options.md)]

### Example

To issue an HTTP PUT request:

1. *Optional*: Run the `get` command to view the data before modifying it:

    ```console
    https://localhost:5001/fruits> get
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
    ```

1. Run the `put` command on an endpoint that supports it:

    ```console
    https://localhost:5001/fruits> put 2 -h Content-Type=application/json
    ```

    In the preceding command, the `Content-Type` HTTP request header is set to indicate a request body media type of JSON. The default text editor opens a *.tmp* file with a JSON template representing the HTTP request body. For example:

    ```json
    {
      "id": 0,
      "name": ""
    }
    ```

    > [!TIP]
    > To set the default text editor, see the [Set the default text editor](#set-the-default-text-editor) section.

1. Modify the JSON template to satisfy model validation requirements:

    ```json
    {
      "id": 2,
      "name": "Cherry"
    }
    ```

1. Save the *.tmp* file, and close the text editor. The following output appears in the command shell:

    ```console
    [main 2019-06-28T17:27:01.805Z] update#setState idle
    HTTP/1.1 204 No Content
    Date: Fri, 28 Jun 2019 17:28:21 GMT
    Server: Kestrel
    ```

1. *Optional*: Issue a `get` command to see the modifications. For example, if you typed "Cherry" in the text editor, a `get` returns the following output:

    ```console
    https://localhost:5001/fruits> get
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


    https://localhost:5001/fruits>
    ```

## Test HTTP DELETE requests

### Synopsis

```console
delete <PARAMETER> [-F|--no-formatting] [-h|--header] [--response] [--response:body] [--response:headers] [-s|--streaming]
```

### Arguments

`PARAMETER`

The route parameter, if any, expected by the associated controller action method.

### Options

[!INCLUDE [standard CLI options](~/includes/http-repl/standard-options.md)]

### Example

To issue an HTTP DELETE request:

1. *Optional*: Run the `get` command to view the data before modifying it:

    ```console
    https://localhost:5001/fruits> get
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
    ```

1. Run the `delete` command on an endpoint that supports it:

    ```console
    https://localhost:5001/fruits> delete 2
    ```

    The preceding command displays the following output format:

    ```console
    HTTP/1.1 204 No Content
    Date: Fri, 28 Jun 2019 17:36:42 GMT
    Server: Kestrel
    ```

1. *Optional*: Issue a `get` command to see the modifications. In this example, a `get` returns the following output:

    ```console
    https://localhost:5001/fruits> get
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


    https://localhost:5001/fruits>
    ```

## Test HTTP PATCH requests

### Synopsis

```console
patch <PARAMETER> [-c|--content] [-f|--file] [-h|--header] [--no-body] [-F|--no-formatting] [--response] [--response:body] [--response:headers] [-s|--streaming]
```

### Arguments

`PARAMETER`

The route parameter, if any, expected by the associated controller action method.

### Options

[!INCLUDE [standard CLI options](~/includes/http-repl/standard-options.md)]

[!INCLUDE [HTTP request body CLI options](~/includes/http-repl/requires-body-options.md)]

## Test HTTP HEAD requests

### Synopsis

```console
head <PARAMETER> [-F|--no-formatting] [-h|--header] [--response] [--response:body] [--response:headers] [-s|--streaming]
```

### Arguments

`PARAMETER`

The route parameter, if any, expected by the associated controller action method.

### Options

[!INCLUDE [standard CLI options](~/includes/http-repl/standard-options.md)]

## Test HTTP OPTIONS requests

### Synopsis

```console
options <PARAMETER> [-F|--no-formatting] [-h|--header] [--response] [--response:body] [--response:headers] [-s|--streaming]
```

### Arguments

`PARAMETER`

The route parameter, if any, expected by the associated controller action method.

### Options

[!INCLUDE [standard CLI options](~/includes/http-repl/standard-options.md)]

## Set HTTP request headers

To set an HTTP request header, use one of the following approaches:

* Set inline with the HTTP request. For example:

    ```console
    https://localhost:5001/people> post -h Content-Type=application/json
    ```
    
    With the preceding approach, each distinct HTTP request header requires its own `-h` option.

* Set before sending the HTTP request. For example:

    ```console
    https://localhost:5001/people> set header Content-Type application/json
    ```
    
    When setting the header before sending a request, the header remains set for the duration of the command shell session. To clear the header, provide an empty value. For example:
    
    ```console
    https://localhost:5001/people> set header Content-Type
    ```

## Test secured endpoints

The HttpRepl supports the testing of secured endpoints in the following ways:

* Via the default credentials of the logged in user.
* Through the use of HTTP request headers.

### Default credentials

Consider a web API you're testing that's hosted in IIS and secured with Windows authentication. You want the credentials of the user running the tool to flow across to the HTTP endpoints being tested. To pass the default credentials of the logged in user:

1. Set the `httpClient.useDefaultCredentials` preference to `true`:

    ```console
    pref set httpClient.useDefaultCredentials true
    ```

1. Exit and restart the tool before sending another request to the web API.
 
### Default proxy credentials

Consider a scenario in which the web API you're testing is behind a proxy secured with Windows authentication. You want the credentials of the user running the tool to flow to the proxy. To pass the default credentials of the logged in user:

1. Set the `httpClient.proxy.useDefaultCredentials` preference to `true`:

    ```console
    pref set httpClient.proxy.useDefaultCredentials true
    ```

1. Exit and restart the tool before sending another request to the web API.

### HTTP request headers

Examples of supported authentication and authorization schemes include:

* basic authentication
* JWT bearer tokens
* digest authentication

For example, you can send a bearer token to an endpoint with the following command:

```console
set header Authorization "bearer <TOKEN VALUE>"
```

To access an Azure-hosted endpoint or to use the [Azure REST API](/rest/api/azure/), you need a bearer token. Use the following steps to obtain a bearer token for your Azure subscription via the [Azure CLI](/cli/azure/). The HttpRepl sets the bearer token in an HTTP request header. A list of Azure App Service Web Apps is retrieved.

1. Sign in to Azure:

    ```azurecli
    az login
    ```

1. Get your subscription ID with the following command:

    ```azurecli
    az account show --query id
    ```

1. Copy your subscription ID and run the following command:

    ```azurecli
    az account set --subscription "<SUBSCRIPTION ID>"
    ```

1. Get your bearer token with the following command:

    ```azurecli
    az account get-access-token --query accessToken
    ```

1. Connect to the Azure REST API via the HttpRepl:

    ```console
    httprepl https://management.azure.com
    ```

1. Set the `Authorization` HTTP request header:

    ```console
    https://management.azure.com/> set header Authorization "bearer <ACCESS TOKEN>"
    ```

1. Navigate to the subscription:

    ```console
    https://management.azure.com/> cd subscriptions/<SUBSCRIPTION ID>
    ```

1. Get a list of your subscription's Azure App Service Web Apps:

    ```console
    https://management.azure.com/subscriptions/{SUBSCRIPTION ID}> get providers/Microsoft.Web/sites?api-version=2016-08-01
    ```

    The following response is displayed:

    ```console
    HTTP/1.1 200 OK
    Cache-Control: no-cache
    Content-Length: 35948
    Content-Type: application/json; charset=utf-8
    Date: Thu, 19 Sep 2019 23:04:03 GMT
    Expires: -1
    Pragma: no-cache
    Strict-Transport-Security: max-age=31536000; includeSubDomains
    X-Content-Type-Options: nosniff
    x-ms-correlation-request-id: <em>xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx</em>
    x-ms-original-request-ids: <em>xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx;xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx</em>
    x-ms-ratelimit-remaining-subscription-reads: 11999
    x-ms-request-id: xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
    x-ms-routing-request-id: WESTUS:xxxxxxxxxxxxxxxx:xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxx
    {
      "value": [
        <AZURE RESOURCES LIST>
      ]
    }
    ```

## Toggle HTTP request display

By default, display of the HTTP request being sent is suppressed. It's possible to change the corresponding setting for the duration of the command shell session.

### Enable request display

View the HTTP request being sent by running the `echo on` command. For example:

```console
https://localhost:5001/people> echo on
Request echoing is on
```

Subsequent HTTP requests in the current session display the request headers. For example:

```console
https://localhost:5001/people> post

[main 2019-06-28T18:50:11.930Z] update#setState idle
Request to https://localhost:5001...

POST /people HTTP/1.1
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
Location: https://localhost:5001/people/4
Server: Kestrel
Transfer-Encoding: chunked

{
  "id": 4,
  "name": "Scott Addie"
}


https://localhost:5001/people>
```

### Disable request display

Suppress display of the HTTP request being sent by running the `echo off` command. For example:

```console
https://localhost:5001/people> echo off
Request echoing is off
```

## Run a script

If you frequently execute the same set of HttpRepl commands, consider storing them in a text file. Commands in the file take the same form as commands executed manually on the command line. The commands can be executed in a batched fashion using the `run` command. For example:

1. Create a text file containing a set of newline-delimited commands. To illustrate, consider a *people-script.txt* file containing the following commands:

    ```text
    set base https://localhost:5001
    ls
    cd People
    ls
    get 1
    ```

1. Execute the `run` command, passing in the text file's path. For example:

    ```console
    https://localhost:5001/> run C:\http-repl-scripts\people-script.txt
    ```

    The following output appears:

    ```console
    https://localhost:5001/> set base https://localhost:5001
    Using OpenAPI description at https://localhost:5001/swagger/v1/swagger.json
    
    https://localhost:5001/> ls
    .        []
    Fruits   [get|post]
    People   [get|post]
    
    https://localhost:5001/> cd People
    /People    [get|post]
    
    https://localhost:5001/People> ls
    .      [get|post]
    ..     []
    {id}   [get|put|delete]
    
    https://localhost:5001/People> get 1
    HTTP/1.1 200 OK
    Content-Type: application/json; charset=utf-8
    Date: Fri, 12 Jul 2019 19:20:10 GMT
    Server: Kestrel
    Transfer-Encoding: chunked
    
    {
      "id": 1,
      "name": "Scott Hunter"
    }
    
    
    https://localhost:5001/People>
    ```

## Clear the output

To remove all output written to the command shell by the HttpRepl tool, run the `clear` or `cls` command. To illustrate, imagine the command shell contains the following output:

```console
httprepl https://localhost:5001
(Disconnected)> set base "https://localhost:5001"
Using OpenAPI description at https://localhost:5001/swagger/v1/swagger.json

https://localhost:5001/> ls
.        []
Fruits   [get|post]
People   [get|post]

https://localhost:5001/>
```

Run the following command to clear the output:

```console
https://localhost:5001/> clear
```

After running the preceding command, the command shell contains only the following output:

```console
https://localhost:5001/>
```

## Additional resources

* [REST API requests](https://github.com/microsoft/api-guidelines/blob/vNext/Guidelines.md#74-supported-methods)
* [HttpRepl GitHub repository](https://github.com/dotnet/HttpRepl)
* [Configure Visual Studio to launch HttpRepl](https://devblogs.microsoft.com/aspnet/httprepl-a-command-line-tool-for-interacting-with-restful-http-services/#configure-visual-studio-for-windows-to-launch-httprepl-on-f5)
* [Configure Visual Studio Code to launch HttpRepl](https://devblogs.microsoft.com/aspnet/httprepl-a-command-line-tool-for-interacting-with-restful-http-services/#configure-visual-studio-code-to-launch-httprepl-on-debug)
* [Configure Visual Studio for Mac to launch HttpRepl](https://devblogs.microsoft.com/aspnet/httprepl-a-command-line-tool-for-interacting-with-restful-http-services/#configure-visual-studio-for-mac-to-launch-httprepl-as-a-custom-tool)
