```mermaid
sequenceDiagram
    participant Client
    participant ASP.NET Core App
    participant StaticFiles
    participant Routing
    participant Authentication
    participant CustomMiddleware1
    participant Endpoint

    Client->>ASP.NET Core App: Request
    ASP.NET Core App->>StaticFiles: Request
    StaticFiles->>Routing: Request
    Routing->>Authentication: Request
    Authentication->>CustomMiddleware1: Request
    CustomMiddleware1->>Endpoint: Request
    Endpoint-->>CustomMiddleware1: Response
    CustomMiddleware1-->>Authentication: Response
    Authentication-->>Routing: Response
    Routing-->>StaticFiles: Response
    StaticFiles-->>ASP.NET Core App: Response
    ASP.NET Core App-->>Client: Response
