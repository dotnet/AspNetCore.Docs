```mermaid
graph TD;
    subgraph Request Pipeline
    A[Exception Handling] --> B;
    B[HTTPS Redirection] --> C[Static Files];
    C --> D[Routing];
    D --> E[Authentication];
    E --> F[CORS];
    F --> G[Custom Middleware];
    end;
    
    subgraph Response Pipeline
    G --> F;
    F --> E;
    E --> D;
    D --> C;
    C --> B;
    B --> A;
    end;
