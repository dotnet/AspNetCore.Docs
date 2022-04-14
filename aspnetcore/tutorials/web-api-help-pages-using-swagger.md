---
title: ASP.NET Core web API documentation with Swagger / OpenAPI
author: RicoSuter
description: This tutorial provides a walkthrough of adding Swagger to generate documentation and help pages for a web API app.
ms.author: scaddie
ms.custom: mvc
ms.date: 10/29/2020
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: tutorials/web-api-help-pages-using-swagger
---
# ASP.NET Core web API documentation with Swagger / OpenAPI

By [Christoph Nienaber](https://twitter.com/zuckerthoben) and [Rico Suter](https://blog.rsuter.com/)

Swagger (OpenAPI) is a language-agnostic specification for describing REST APIs. It allows both computers and humans to understand the capabilities of a REST API without direct access to the source code. Its main goals are to:

* Minimize the amount of work needed to connect decoupled services.
* Reduce the amount of time needed to accurately document a service.

The two main OpenAPI implementations for .NET are [Swashbuckle](https://github.com/domaindrivendev/Swashbuckle.AspNetCore) and [NSwag](https://github.com/RicoSuter/NSwag), see:

* [Getting Started with Swashbuckle](xref:tutorials/get-started-with-swashbuckle)
* [Getting Started with NSwag](xref:tutorials/get-started-with-nswag)

## OpenApi vs. Swagger

The Swagger project was donated to the OpenAPI Initiative in 2015 and has since been referred to as OpenAPI. Both names are used interchangeably. However, "OpenAPI" refers to the specification. "Swagger" refers to the family of open-source and commercial products from SmartBear that work with the OpenAPI Specification. Subsequent open-source products, such as [OpenAPIGenerator](https://github.com/OpenAPITools/openapi-generator), also fall under the Swagger family name, despite not being released by SmartBear.

In short:

* OpenAPI is a specification.
* Swagger is tooling that uses the OpenAPI specification. For example, OpenAPIGenerator and SwaggerUI.

## OpenAPI specification (openapi.json)

The OpenAPI specification is a document that describes the capabilities of your API. The document is based on the [XML](xref:tutorials/get-started-with-swashbuckle#xml-comments) and attribute annotations within the controllers and models. It's the core part of the OpenAPI flow and is used to drive tooling such as SwaggerUI. By default, it's named `openapi.json`. Here's an example of an OpenAPI specification, reduced for brevity:

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

Each public action method in your controllers can be tested from the UI. Select a method name to expand the section. Add any necessary parameters, and select **Try it out!**.

![Example Swagger GET test](web-api-help-pages-using-swagger/_static/get-try-it-out.png)

> [!NOTE]
> The Swagger UI version used for the screenshots is version 2. For a version 3 example, see [Petstore example](https://petstore.swagger.io/).

## Next steps

* [Get started with Swashbuckle](xref:tutorials/get-started-with-swashbuckle)
* [Get started with NSwag](xref:tutorials/get-started-with-nswag)
