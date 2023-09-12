Throughout this article, the terms **client**/**client-side** and **server**/**server-side** are used to distinguish locations where app code executes:

* **Client**/**client-side**
  * Interactive client rendering of a Blazor Web App. The `Program` file is `Program.cs` of the client project (`.Client`). Blazor script start configuration is found in the `App` component (`Components/App.razor`) of the server project.
  * A Blazor WebAssembly app. The `Program` file is `Program.cs`. Blazor script start configuration is found in the `wwwroot/index.html` file.
* **Server**/**server-side**: Interactive server rendering of a Blazor Web App. The `Program` file is `Program.cs` of the server project. Blazor script start configuration is found in the `App` component (`Components/App.razor`).

Routable components with an `@page` directive are placed in the `Components/Pages` folder. Non-routable shared components are placed in the `Components` folder.
