---
title: Use .http/.rest files in Visual Studio 2022
author: tdykstra
description: Learn how to use .http/.rest files in Visual Studio 2022 to test ASPNET Core apps.
monikerRange: '>= aspnetcore-8.0'
ms.author: tdykstra
ms.date: 05/08/2023
uid: test/http-files
---
# Use .http/.rest files in Visual Studio 2022

Visual Studio 2022 has an editor for `.http` files (`.rest` is an alternative file extension for the same file format). The purpose of `.http` files is to provide a convenient syntax for making HTTP requests, and the editor window displays the responses. This article is reference documentation for the `.http` file format and the Visual Studio `.http` file editor.

## Prerequisites

* [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) version 17.6 Prerview or later with the **ASP.NET and web development** workload installed.

## Comments

Comments are lines that start with either `#` or `//`. These lines are ignored when Visual Studio makes HTTP requests.

## Variables

Variable names begin with an `@` and are followed by an `=` and the value of the variable. For example:

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

To add one or more headers, add each header on its own line immediately after after the request line (no blank lines). The format is `Name: Value`, as shown in the following examples:

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

There is some support that the Visual Studio Code REST Client extension supports that we don’t have support for today. Those include.

Optional HTTP Method. The REST Client has support for not specifying the HTTP method. In those cases, GET is the default HTTP method.
Request URL spans more than one line. In the current implementation in Visual Studio, the request line must be on a single line.
We are hoping to add support for these in a future release.

Multiple requests in the same file
As shown above, an HTTP file can have multiple different requests listed. They need to be separated with ### at the end of each request.

Headers
To add one, or more, headers add each header on its own line immediately after (no blank lines) after the request line. Below are a few different examples.

GET https://httpbin.org/get?name=Sayed?&phone=111-222-3333 HTTP/1.1
Date: Wed, 27 Apr 2023 07:28:00 GMT
###

GET https://httpbin.org/get?name=Sayed?&phone=111-222-3333
Cache-Control: max-age=604800
Age: 100
###

POST https://httpbin.org/post HTTP/1.1
Content-Type: application/json
Accept-Language: en-US,en;q=0.5

{
    "name": "sample",
    "time": "Wed, 21 Oct 2015 18:27:50 GMT"
}
###
If you are calling an API which can authenticate with headers you can specify those in the headers as well. If you do this, be careful to not commit any secrets to your repository. We will be working on ways to supports secrets in a secure manner.

Now that we’ve gone through some of the supported syntax, in the next section we will list some features that the REST Client has which Visual Studio doesn’t currently support. If you’d like to see support for any of these features, please leave a comment below or send some feedback to the team (see the closing section below). This list is in no particular order. For more info on any of the items listed below, see the Visual Studio Code REST Client extension.

Not currently supported in the Visual Studio HTTP Editor
Optional HTTP Method
Request line that spans more than one line
Named Requests
Dynamic variables
Environment files
Specify file path as body of the request
Mixed format for body when using multipart/form-data
GraphQL requests
cURL request
Copy/paste as cURL
Request history
Save response body to file
Certificate based authentication
Prompt variables
System variables
Customize response preview
Per-request settings