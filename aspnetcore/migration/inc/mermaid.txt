mermaid incase we want to change images

```mermaid
    sequenceDiagram
        participant core as ASP.NET Core
        participant framework as ASP.NET
        participant session as Session Store
        core ->> framework: GET /session
        framework ->> session: Request session
        session -->> framework: Session
        framework -->> core: Session
```

## Writeable

```mermaid
    sequenceDiagram
        participant core as ASP.NET Core
        participant framework as ASP.NET
        participant session as Session Store
        core ->> framework: GET /session
        framework ->> session: Request session
        session -->> framework: Session
        framework -->> core: Session
        core ->> framework: PUT /session
        framework ->> framework: Deserialize to HttpSessionState
        framework -->> core: Session complete
        framework ->> session: Persist
```
 
 Windows with its supporting libraries:

```mermaid
flowchart LR;
  external[Incoming requests] --> framework[.NET Framework App]
  framework --- libraries[[Business logic]]
```

 but the core app is now set up to start migrating routes to: did below change?

```mermaid
flowchart LR;
  external[Incoming requests] --> core[ASP.NET Core App]
  core --- - --- libraries
  core -- YARP proxy --> framework[ \n\n.NET Framework App\n\n\n]
  framework --- libraries[[Business logic]]
```

In order to start moving over business logic that relies on `HttpContext`, 

```mermaid
flowchart LR;
  external[Incoming requests] --> core[ASP.NET Core App]
  core -- Adapters --- libraries
  core -- YARP proxy --> framework[ \n\n.NET Framework App\n\n\n]
  framework --- libraries[[Business logic]]
```

Over time, the core app will start processing more of the routes served than the .NET Framework App:

```mermaid
flowchart LR;
  external[Incoming requests] --> core[ \n\nASP.NET Core App\n\n\n]
  core -- Adapters --- libraries
  core -- YARP proxy --> framework[.NET Framework App]
  framework --- libraries[[Business logic]]
```

Once the .NET Framework App is no longer needed, it may be removed:

```mermaid
flowchart LR;
  external[Incoming requests] --> core[ASP.NET Core App]
  core -- Adapters --- libraries[[Business logic]]
```

At this point, the application as a whole is running on the ASP.NET Core application stack,
```mermaid
flowchart LR;
  external[Incoming requests] --> core[ASP.NET Core App]
  core --- libraries[[Business logic]]
```
