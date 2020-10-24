---
title: ASP.NET Core Web API help pages with Swagger / OpenAPI
author: RicoSuter
description: This tutorial provides a walkthrough of adding Swagger to generate documentation and help pages for a Web API app.
ms.author: scaddie
ms.custom: mvc
ms.date: 07/06/2020
no-loc: ["ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: tutorials/web-api-help-pages-using-swagger
---
# ASP.NET Core web API documentation with Swagger / OpenAPI

By [Christoph Nienaber](https://twitter.com/zuckerthoben) and [Rico Suter](https://blog.rsuter.com/)

Swagger (OpenAPI) is a language-agnostic specification for describing REST APIs. It allows both computers and humans to understand the capabilities of an API service without any direct access to the implementation (source code, network access, documentation). Its main goals are to help minimise the amount of work needed to connect decoupled services, as well as reduce the amount of time needed to accurately document a service.

The two main OpenAPI implementations for .Net are [Swashbuckle](https://github.com/domaindrivendev/Swashbuckle.AspNetCore) and [NSwag](https://github.com/RicoSuter/NSwag), see:

* [Getting Started with Swashbuckle](https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-3.1)
* [Getting Started with NSwag](https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-nswag?view=aspnetcore-3.1)

## OpenApi vs Swagger

The Swagger project was donated to the OpenAPI Initiative in 2015, and has since been referred to as OpenAPI. Both names are used interchangeably, however strictly "OpenAPI" refers to the specification, whilst "Swagger" refers to the family of open-source and commercial products produced by SmartBear that work with the OpenAPI Specification (subsequent open-source products such as [OpenAPIGenerator](https://github.com/OpenAPITools/openapi-generator) also fall under the Swagger family name, despite not being released by SmartBear).

In short:

* OpenAPI = specification
* Swagger = tooling that uses the OpenAPI specification (OpenAPIGenerator, SwaggerUI, etc.)

## OpenAPI specification (openapi.json)

The OpenAPI specification is a document that describes the capabilities of your API, based on the XML and Attribute definitions within the Controllers and Models. It is the core part of the OpenAPI flow, and is used to drive tooling such as SwaggerUI. By default it's named _openapi.json_. Here's an example of an OpenAPI specification, reduced for brevity:

```json
{
  "openapi": "3.0.1",
  "info": {
    "title": "API V1",
    "version": "v1"
  },
  "paths": {
    "/api/Todo": {
      "get": {
        "tags": [
          "Todo"
        ],
        "operationId": "ApiTodoGet",
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/ToDoItem"
                  }
                }
              },
              "application/json": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/ToDoItem"
                  }
                }
              },
              "text/json": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/ToDoItem"
                  }
                }
              }
            }
          }
        }
      },
      "post": {
        …
      }
    },
    "/api/Todo/{id}": {
      "get": {
        …
      },
      "put": {
        …
      },
      "delete": {
        …
      }
    }
  },
  "components": {
    "schemas": {
      "ToDoItem": {
        "type": "object",
        "properties": {
          "id": {
            "type": "integer",
            "format": "int32"
          },
          "name": {
            "type": "string",
            "nullable": true
          },
          "isCompleted": {
            "type": "boolean"
          }
        },
        "additionalProperties": false
      }
    }
  }
}
```

## Swagger UI

[Swagger UI](https://swagger.io/swagger-ui/) offers a web-based UI that provides information about the service, using the generated OpenAPI specification. Both Swashbuckle and NSwag include an embedded version of Swagger UI, so that it can be hosted in your ASP.NET Core app using a middleware registration call. The web UI looks like this:

![Swagger UI](web-api-help-pages-using-swagger/_static/swagger-ui.png)

Each public action method in your controllers can be tested from the UI. Click a method name to expand the section. Add any necessary parameters, and click **Try it out!**.

![Example Swagger GET test](web-api-help-pages-using-swagger/_static/get-try-it-out.png)

> [!NOTE]
> The Swagger UI version used for the screenshots is version 2. For a version 3 example, see [Petstore example](https://petstore.swagger.io/).

## Next steps

* [Get started with Swashbuckle](xref:tutorials/get-started-with-swashbuckle)
* [Get started with NSwag](xref:tutorials/get-started-with-nswag)
