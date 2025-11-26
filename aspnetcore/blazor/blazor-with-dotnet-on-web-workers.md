---
title: ASP.NET Core Blazor with .NET on Web Workers
author: guardrex
description: Learn how to use Web Workers to enable JavaScript to run on separate threads that don't block the main UI thread for improved app performance in a Blazor WebAssembly app.
monikerRange: '>= aspnetcore-8.0'
ms.author: wpickett
ms.custom: mvc
ms.date: 11/20/2025
uid: blazor/blazor-web-workers
---
# ASP.NET Core Blazor with .NET on Web Workers

<!-- UPDATE 11.0 - Activate

[!INCLUDE[](~/includes/not-latest-version.md)]

-->

Modern Blazor WebAssembly apps often handle CPU-intensive work alongside rich UI updates. Tasks such as image processing, document parsing, or data crunching can easily freeze the browser's main thread. Web Workers let you push that work to a background thread. Combined with the .NET WebAssembly runtime, you can keep writing C# while the UI stays responsive.

The guidance in this article mirrors the concepts from the React-focused *.NET on Web Workers* walkthrough, but adapts every step to a Blazor frontend. It highlights the same QR-code generation scenario implemented in this repository. To learn about Web Workers with React, see <xref:client-side/dotnet-on-webworkers>.

## Sample app

Explore a complete working implementation in the [Blazor samples GitHub repository](https://github.com/dotnet/blazor-samples). The sample is available for .NET 10 or later and named `DotNetOnWebWorkersBlazorWebAssembly`.

## Prerequisites

Before diving into the implementation, ensure the necessary tools are installed. The [.NET SDK 8.0 or later](https://dotnet.microsoft.com/download) is required.

## Create the Blazor WebAssembly project

Create a Blazor WebAssembly app:

```bash
dotnet new blazorwasm -o WebWorkersOnBlazor
cd WebWorkersOnBlazor
```

Add a package reference for [`QRCoder`](https://www.nuget.org/packages/QRCoder) to simulate heavy computations.

[!INCLUDE[](~/includes/package-reference.md)]

> [!WARNING]
> [`Shane32/QRCoder`](https://github.com/Shane32/QRCoder)/[`QRCoder` NuGet package](https://www.nuget.org/packages/QRCoder) isn't owned or maintained by Microsoft and isn't covered by any Microsoft Support Agreement or license. Use caution when adopting a third-party library, especially for security features. Confirm that the library follows official specifications and adopts security best practices. Keep the library's version current to obtain the latest bug fixes.

Enable the <xref:Microsoft.Build.Tasks.Csc.AllowUnsafeBlocks> property in app's project file, which is required whenever you use [`[JSImport]` attribute](xref:System.Runtime.InteropServices.JavaScript.JSImportAttribute) or [`[JSExport]` attribute](xref:System.Runtime.InteropServices.JavaScript.JSExportAttribute) in WebAssembly projects:

```xml
<PropertyGroup>
  <AllowUnsafeBlocks>true</AllowUnsafeBlocks>
</PropertyGroup>
```

> [!WARNING]
> The JS interop API requires enabling <xref:Microsoft.Build.Tasks.Csc.AllowUnsafeBlocks>. Be careful when implementing your own unsafe code in .NET apps, which can introduce security and stability risks. For more information, see [Unsafe code, pointer types, and function pointers](/dotnet/csharp/language-reference/unsafe-code).

## Add the Web Worker code

Create the following file to expose .NET code to JavaScript using the [`[JSExport]` attribute](xref:System.Runtime.InteropServices.JavaScript.JSExportAttribute):

`Workers/QRGenerator.razor.cs`:

```csharp
using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;
using QRCoder;

[SupportedOSPlatform("browser")]
public partial class QRGenerator
{
    private static readonly int MaxQrSize = 20;

    [JSExport]
    internal static byte[] Generate(string text, int qrSize)
    {
        if (qrSize >= MaxQrSize)
        {
            throw new Exception($"QR code size must be less than {MaxQrSize}.");
        }

        var generator = new QRCodeGenerator();
        QRCodeData data = generator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
        var qrCode = new BitmapByteQRCode(data);
    
        return qrCode.GetGraphic(qrSize);
    }
}
```

Create a matching Razor component file (`.razor`) to act as an empty stub so that the build packs the worker script alongside the component assets:

`Workers/QRGenerator.razor`:

```razor
// dummy file to let blazor handle Worker.razor.js file loading
```

Add the following JavaScript file. The script boots the .NET runtime in the worker, then listens for messages from the main thread. `postMessage` is used to send either a `result` or an `error` payload.

`Workers/QRGenerator.razor.js`:

```javascript
import { dotnet } from '../_framework/dotnet.js';

let assemblyExports;
let startupError;

try {
  const { getAssemblyExports, getConfig } = await dotnet.create();
  const config = getConfig();
  assemblyExports = await getAssemblyExports(config.mainAssemblyName);
} catch (err) {
  startupError = err.message;
}

self.addEventListener('message', async e => {
  try {
    if (!assemblyExports) {
      throw new Error(startupError || 'worker exports not loaded');
    }

    let result;
    switch (e.data.command) {
      case 'generateQR':
        result = assemblyExports.QRGenerator.Generate(e.data.text, e.data.size);
        break;
      default:
        throw new Error(`Unknown command: ${e.data.command}`);
    }

    self.postMessage({ command: 'response', 
      requestId: e.data.requestId, result });
  } catch (err) {
    self.postMessage({ command: 'response', 
      requestId: e.data.requestId, error: err.message });
  }
});
```

## Bridge the worker to the Blazor UI

Create the following JavaScript file that manages the worker instance and exposes helper functions to Blazor.

`Clients/Client.razor.js`:

```javascript
const pendingRequests = {};
let pendingRequestId = 0;

const dotnetWorker = 
  new Worker('./Workers/QRGenerator.razor.js', { type: 'module' });

dotnetWorker.addEventListener('message', e => {
  switch (e.data.command) {
    case 'response':
      const request = pendingRequests[e.data.requestId];
      delete pendingRequests[e.data.requestId];
      if (e.data.error) {
        request.reject(new Error(e.data.error));
      }
      request.resolve(e.data.result);
      break;
    default:
      console.log('Worker said:', e.data);
  }
});

function sendRequestToWorker(request) {
  pendingRequestId++;
  const promise = new Promise((resolve, reject) => {
    pendingRequests[pendingRequestId] = { resolve, reject };
  });

  dotnetWorker.postMessage({ ...request, requestId: pendingRequestId });
  return promise;
}

export async function generateQR(text, size) {
  const response = await sendRequestToWorker({ command: 'generateQR', text, size });
  const blob = new Blob([response], { type: 'image/png' });
  return URL.createObjectURL(blob);
}
```

Similarly as the worker, the `Client` script requires a matching `.razor` file with an empty stub to assure that the JS file is considered a part of the component.

`Clients/Client.razor`:

```razor
// dummy file to let blazor handle Client.razor.js file loading
```

Add the following `Client`, which exposes the JavaScript module to Blazor components using the [`[JSImport]` attribute](xref:System.Runtime.InteropServices.JavaScript.JSImportAttribute). `InitClient` ensures the worker JS module is only loaded once per browser session.

`Clients/Client.razor.cs`:

```csharp
using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;

[SupportedOSPlatform("browser")]
public partial class Client
{
    private static bool _workerStarted;

    public static async Task InitClient()
    {
        if (_workerStarted)
        {
            return;
        }

        _workerStarted = true;

        await JSHost.ImportAsync(
            moduleName: nameof(Client), 
            moduleUrl: "../Clients/Client.razor.js");
    }

    [JSImport("generateQR", nameof(Client))]
    public static partial Task<string> GenerateQR(string text, int size);
}
```

## Demonstrate the flow

You can use the app's Home page to demonstrate the flow.

`Pages/Home.razor`:

```razor
@page "/"
@using Components
@namespace Pages

<PageTitle>Home</PageTitle>

<h1>Hello, world!</h1>

<Popup @ref="popup" />

<div class="input-container">
    <div class="form-group">
        <label for="textInput">Generate a QR from text:</label>
        <input type="text" class="form-control" id="textInput" @bind="text" placeholder="Text" />
    </div>

    <div class="form-group">
        <label for="numberInput">Set size of QR (in pixels):</label>
        <input type="number" class="form-control" id="numberInput" @bind="size" />
    </div>

    <div class="form-group">
        <button class="btn btn-primary" @onclick="GenerateQR">Generate QR</button>
    </div>

    @if (!string.IsNullOrWhiteSpace(imageUrl))
    {
        <div class="form-group">
            <img class="image" src="@imageUrl" id="qrImage" alt="Image" />
        </div>
    }
</div>
```

The following code-behind file initializes the client and generates the QR code. The [`OnAfterRenderAsync` lifecycle method](xref:blazor/components/lifecycle#after-component-render-onafterrenderasync) code guarantees that the JavaScript module is loaded before the user clicks the button, while the `GenerateQR` handler makes a single asynchronous worker request.

`Home.razor.cs`:

```csharp
using Microsoft.AspNetCore.Components;
using System.Runtime.Versioning;
using Components;

namespace Pages;

[SupportedOSPlatform("browser")]
public partial class Home : ComponentBase
{
    private string imageUrl = string.Empty;
    private string? text;
    private int size = 5;
    private Popup popup = new();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await Client.InitClient();
    }

    private async Task GenerateQR()
    {
        try
        {
            if (text is not null)
            {
                imageUrl = await Client.GenerateQR(text, size);
            }
        }
        catch(Exception ex)
        {
            imageUrl = string.Empty;
            popup.Show(title: "Error", message: ex.Message);
        }

        await InvokeAsync(StateHasChanged);
    }
}
```

## Next steps

* Swap the QR code sample for your own CPU-intensive domain logic.
* Move long-running workflows into dedicated worker instances per feature area.
* Explore shared array buffers or Atomics when you need higher-throughput synchronization between Blazor and workers.

## Additional resources

<xref:client-side/dotnet-on-webworkers>
