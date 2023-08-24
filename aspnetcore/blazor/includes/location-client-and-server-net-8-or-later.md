Throughout this article, the terms **client**/**client-side** and **server**/**server-side** are used to distinguish locations where app code executes:

* **Client**/**client-side**
  * Client-side rendering (CSR) and interactivity of a Blazor Web App. The `Program` file is `Program.cs` of the client project (`BlazorWeb-CSharp.Client`). Blazor script start configuration is found in the `App` component (`Components/App.razor`) of the server project (`BlazorWeb-CSharp`).
  * A Blazor WebAssembly app. The `Program` file is `Program.cs`. Blazor script start configuration is found in the `wwwroot/index.html` file.
* **Server**/**server-side**: Server-side rendering (SSR) and interactivity of a Blazor Web App. The `Program` file is `Program.cs` of the server project (`BlazorWeb-CSharp`). Blazor script start configuration is found in the `App` component (`Components/App.razor`).

Routable components with an `@page` directive are placed in the `Components/Pages` folder. Non-routable shared components are placed in the `Components` folder.
