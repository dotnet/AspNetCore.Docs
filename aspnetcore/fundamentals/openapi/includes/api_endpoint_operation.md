## API v. API operation v. API endpoint

The following sections explain the differences between an API, an API endpoint, and an API operation in the context of ASP.NET Core and OpenAPI documentation.

### API (Application Programming Interface)

An API is a set of rules and protocols for building and interacting with software applications. It defines how different software components should communicate. An API typically refers to a web service that exposes functionality over HTTP.

In ASP.NET Core, an API is usually built using controllers or minimal APIs, which handle incoming HTTP requests and return responses.

### API Operation

An API operation represents a specific action or capability that an API provides. In ASP.NET Core, this corresponds to:

* Controller action methods in MVC-style APIs
* Route handlers in Minimal APIs

Each operation is defined by its HTTP method (`GET`, `POST`, `PUT`, etc.), path, parameters, and responses.

### API Endpoint

An API endpoint is a specific URL:

* That represents a specific resource or functionality exposed by the API.
* Provides the exact address that a client needs to send an HTTP request to in order to interact with a particular API operation.

An endpoint is a combination of the API's base URL and a specific path to the desired resource, along with the supported HTTP methods:

* For controller-based APIs, endpoints combine the route template with controller and action.
* For Minimal APIs, endpoints are explicitly defined with `app.MapGet()`, `app.MapPost()`, etc.

For example:

* `GET /api/products`
* `POST /api/products`
* `PUT /api/products/{id}`

### OpenAPI Documentation

In the context of OpenAPI, the documentation describes the API as a whole, including all its endpoints and operations. OpenAPI provides a structured way to document APIs, making it easier for developers to understand how to interact with them.

API Operations are the primary focus of OpenAPI documentation. The [OpenAPI specification](https://spec.openapis.org/oas/latest.html) organizes documentation by operations, which are grouped by paths (endpoints). Each operation is described with details such as parameters, request bodies, responses, and more. This structured format allows tools to generate client libraries, server stubs, and interactive documentation automatically.

In an OpenAPI document:

* The entire document describes the API as a whole
* Each path item (like `/api/products/{id}`) represents an endpoint
* Under each path, the HTTP methods (`GET`, `POST`, `PUT`, etc.) define the operations
* Each operation contains details about parameters, request body, responses, etc.

Example in OpenAPI JSON format:

```JSON
json{
  "paths": {
    "/api/products/{id}": {  // This is the endpoint
      "get": {  // This is the operation
        "summary": "Get a product by ID",
        "parameters": [...],
        "responses": {...}
      },
      "put": {  // Another operation on the same endpoint
        "summary": "Update a product",
        "parameters": [...],
        "responses": {...}
      }
    }
  }
}
```

## API v. API operation v. API endpoint

| Concept         | API Operation                                      | API Endpoint                                      |
|-----------------|----------------------------------------------------|--------------------------------------------------|
| **Definition**  | A logical description of an API action: method + path + behavior | The actual configured HTTP route that listens for requests |
| **Level**       | Conceptual, what action can happen                 | Concrete, what URL and method are matched        |
| **Tied to**     | OpenAPI API design/specification                   | ASP.NET Core routing at runtime                 |
| **Describes**   | What the API does for example, "create product"           | Where and how to call it, for example, `POST https://localhost:7099/api/products`,  `POST https://contoso.com/api/products` |
| **In ASP.NET Core** | Controller actions or Minimal API methods, before routing resolves | Endpoint objects resolved at runtime |
