---
title: .NET on Web Workers
ai-usage: ai-assisted
author: guardrex
description: Learn how to use Web Workers to enable JavaScript to run on separate threads that don't block the main UI thread for improved app performance in a React app.
monikerRange: '>= aspnetcore-8.0'
ms.author: wpickett
ms.custom: mvc
ms.date: 04/07/2026
uid: client-side/dotnet-on-webworkers
---
# .NET on Web Workers

<!-- UPDATE 11.0 - Surface the INCLUDES file

[!INCLUDE[](~/includes/not-latest-version.md)]

-->

Modern web apps often require intensive computational tasks that can block the main UI thread, leading to poor user experience. [Web Workers](https://developer.mozilla.org/docs/Web/API/Web_Workers_API) provide a solution to this problem by enabling JavaScript (JS) to run on separate threads. With .NET WebAssembly (Wasm), you can run C# code in Web Workers, combining the performance benefits of compiled code with the non-blocking execution model of background threads.

This approach is particularly valuable when you need to perform complex calculations, data processing, or business logic without requiring direct DOM manipulation. Instead of rewriting algorithms in JS, you can maintain your existing .NET codebase and execute it efficiently in the background while your React.js frontend remains responsive.

:::moniker range=">= aspnetcore-11.0"

> [!TIP]
> In .NET 11 or later, `dotnet new blazorwebworker` generates the worker scripts and starter `[JSExport]` code used by the Blazor integration. For the Blazor-specific walkthrough, see <xref:blazor/blazor-web-workers>.

:::moniker-end

:::moniker range="< aspnetcore-11.0"

> [!TIP]
> For earlier versions, follow the manual `wasmbrowser` steps in this article. For the Blazor-specific walkthrough, see <xref:blazor/blazor-web-workers>.

:::moniker-end

This article demonstrates the React approach using a standalone .NET WebAssembly project.

## Sample app

Explore a complete working implementation in the [Blazor samples GitHub repository](https://github.com/dotnet/blazor-samples). The sample is available for .NET 10 or later and named `DotNetOnWebWorkersReact`.

## Prerequisites and setup

Before diving into the implementation, ensure the necessary tools are installed.

:::moniker range=">= aspnetcore-11.0"

The [.NET 11 SDK or later](https://dotnet.microsoft.com/download) is required for the `blazorwebworker` template approach.

:::moniker-end

:::moniker range="< aspnetcore-11.0"

The [.NET SDK 8.0 or later](https://dotnet.microsoft.com/download) is required. If the WebAssembly build tools aren't already installed, run:

```bash
dotnet workload install wasm-tools
dotnet workload install wasm-experimental
```

:::moniker-end

For the React.js frontend, [Node.js](https://nodejs.org/) and [npm](https://www.npmjs.com) must be installed.

:::moniker range=">= aspnetcore-11.0"

Create a new React app with Vite:

```bash
npm create vite@latest react-app
cd react-app
npm install
```

When prompted, select `React` and `JavaScript`.

:::moniker-end

:::moniker range="< aspnetcore-11.0"

Create a new React app:

```bash
npx create-react-app react-app
cd react-app
```

:::moniker-end

## Create the .NET WebAssembly project

:::moniker range=">= aspnetcore-11.0"

In .NET 11 or later, you can start from the Blazor Web Worker template and adapt it for a React host:

```bash
dotnet new blazorwebworker -o WebWorkersOnReact
cd WebWorkersOnReact
dotnet add package QRCoder
```

Update `WebWorkersOnReact.csproj` to use the WebAssembly SDK and build as a library. The template uses the Razor SDK by default because, in the Blazor scenario, the host app already provides the .NET WebAssembly runtime assets. In a React app, there isn't a Blazor host to provide that runtime bundle, so the worker project must produce its own `_framework` output.

Setting `<OutputType>Library</OutputType>` enables WebAssembly library mode. In this mode, the project produces the runtime files needed by the worker scripts but doesn't require a standalone app entry point:

```xml
<Project Sdk="Microsoft.NET.Sdk.WebAssembly">
  <PropertyGroup>
    <TargetFramework>net11.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <AllowUnsafeBlocks>true</AllowUnsafeBlocks>
    <OutputType>Library</OutputType>
  </PropertyGroup>
</Project>
```

Delete `WebWorkerClient.cs` because it's specific to the Blazor integration.

Update `WorkerMethods.cs` with the methods that the React app should call:

```csharp
using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;
using QRCoder;

namespace WebWorkersOnReact;

[SupportedOSPlatform("browser")]
public static partial class WorkerMethods
{
    private static readonly int MaxQrSize = 20;

    [JSExport]
    public static byte[] Generate(string text, int qrSize)
    {
        if (qrSize >= MaxQrSize)
        {
            throw new ArgumentOutOfRangeException(
                nameof(qrSize),
                $"QR code size must be less than {MaxQrSize}.");
        }

        using var qrGenerator = new QRCodeGenerator();
        using var qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
        var qrCode = new BitmapByteQRCode(qrCodeData);
        return qrCode.GetGraphic(qrSize);
    }
}
```

:::moniker-end

:::moniker range="< aspnetcore-11.0"

Create a new WebAssembly browser project to serve as the Web Worker:

```bash
dotnet new wasmbrowser -o WebWorkersOnReact
cd WebWorkersOnReact
dotnet add package QRCoder
```

Modify the `Program.cs` file to set up the Web Worker entry point and message handling:

```csharp
using System;
using System.Runtime.InteropServices.JavaScript;
using QRCoder;
using System.Linq;

public partial class QRGenerator
{
    private static readonly int MAX_QR_SIZE = 20;

    [JSExport]
    internal static byte[] Generate(string text, int qrSize)
    {
        if (qrSize >= MAX_QR_SIZE)
        {
            throw new Exception(
                $"QR code size must be less than {MAX_QR_SIZE}. Try again.");
        }
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        QRCodeData qrCodeData = qrGenerator.CreateQrCode(
            text, QRCodeGenerator.ECCLevel.Q);
        BitmapByteQRCode qrCode = new BitmapByteQRCode(qrCodeData);
        return qrCode.GetGraphic(qrSize);
    }
}
```

Add a `wwwroot/worker.js` file with code that interops between C# and JS:

```javascript
import { dotnet } from './_framework/dotnet.js'

let assemblyExports = null;
let startupError = undefined;

try {
  const { getAssemblyExports, getConfig } = await dotnet.create();
  const config = getConfig();
  assemblyExports = await getAssemblyExports(config.mainAssemblyName);
}
catch (err) {
  startupError = err.message;
}

self.addEventListener('message', async function(e) {
  try {
    if (!assemblyExports) {
      throw new Error(startupError || "worker exports not loaded");
    }
    let result = null;
    switch (e.data.command) {
      case "generateQR":
        const size = Number(e.data.size);
        const text = e.data.text;
        if (size === undefined || text === undefined)
          new Error("Inner error, got empty QR generation data from React");
        result = assemblyExports.QRGenerator.Generate(text, size);
        break;
      default:
          throw new Error("Unknown command: " + e.data.command);
    }
    self.postMessage({
      command: "response",
      requestId: e.data.requestId,
      result,
    });
  }
  catch (err) {
    self.postMessage({
      command: "response",
      requestId: e.data.requestId,
      error: err.message,
    });
  }
}, false);
```

:::moniker-end

Build the worker project:

```bash
dotnet build
```

## Set up the React app

For a quick test, copy the worker output into the React app's static files manually. For a real app, automate these copies with an npm script or another build step.

:::moniker range=">= aspnetcore-11.0"

Use the generated JavaScript client to host the .NET WebAssembly runtime in a Web Worker. For example:

* Copy `WebWorkersOnReact/bin/Debug/net11.0/wwwroot/_framework` to `react-app/public/_framework`.
* Copy `WebWorkersOnReact/wwwroot/dotnet-web-worker.js` to `react-app/public/_content/WebWorkersOnReact/dotnet-web-worker.js`.
* Copy `WebWorkersOnReact/wwwroot/dotnet-web-worker-client.js` to `react-app/public/_content/WebWorkersOnReact/dotnet-web-worker-client.js`.

Then create a client helper, such as `src/client.js`, to load the generated client and call the worker:

```javascript
let worker;

async function getWorker() {
  if (!worker) {
    const { create } = await import(
      /* @vite-ignore */ '/_content/WebWorkersOnReact/dotnet-web-worker-client.js');
    worker = await create(60000, { assemblyName: 'WebWorkersOnReact' });
  }

  return worker;
}

export async function generateQR(text, size) {
  const worker = await getWorker();
  const response = await worker.invoke(
    'WebWorkersOnReact.WorkerMethods.Generate',
    [text, size],
    60000);
  const blob = new Blob([response], { type: 'image/png' });
  return URL.createObjectURL(blob);
}
```

Replace the starter content in `src/App.jsx` with a button that calls `generateQR`:

```javascript
import { useState } from 'react';
import './App.css';
import { generateQR } from './client';

function App() {
  const [qrUrl, setQrUrl] = useState('');
  const [status, setStatus] = useState('Ready');

  async function handleGenerate() {
    try {
      setStatus('Generating QR code...');
      const url = await generateQR('Hello from docs', 10);
      setQrUrl(url);
      setStatus('Done');
    } catch (error) {
      setStatus(error.message);
    }
  }

  return (
    <main>
      <h1>.NET on Web Workers</h1>
      <p>{status}</p>
      <button onClick={handleGenerate}>Generate QR</button>
      {qrUrl ? <img src={qrUrl} alt="Generated QR code" /> : null}
    </main>
  );
}

export default App;
```

:::moniker-end

:::moniker range="< aspnetcore-11.0"

Create a Web Worker to host the .NET WebAssembly runtime. The sample app copies the entire output folder into `public/qr`, which preserves both `wwwroot/worker.js` and the `_framework` assets required by the runtime. See the [sample app](#sample-app) for reference.

Create a Web Worker file `client.js` to receive messages from dotnet:

```javascript
const dotnetWorker = new Worker('../../qr/wwwroot/worker.js', { type: "module" } );

dotnetWorker.addEventListener('message', async function (e) {
  switch (e.data.command) {
    case "response":
      if (!e.data.requestId) {
        console.error("No requestId in response from worker");
      }
      const request = pendingRequests[e.data.requestId];
      delete pendingRequests[e.data.requestId];
      if (e.data.error) {
        request.reject(new Error(e.data.error));
      }
      request.resolve(e.data.result);
      break;
    default:
      console.log('Worker said: ', e.data);
      break;
  }
}, false);
```

Connect this functionality with UI and add a button that triggers `generateQR`:

```javascript
export async function generateQR(text, size) {
  const response = await sendRequestToWorker({
    command: "generateQR",
    text: text,
    size: size
  });
  const blob = new Blob([response], { type: 'image/png' });
  return URL.createObjectURL(blob);
}

function sendRequestToWorker(request) {
  pendingRequestId++;
  const promise = new Promise((resolve, reject) => {
    pendingRequests[pendingRequestId] = { resolve, reject };
  });
  dotnetWorker.postMessage({
    ...request,
    requestId: pendingRequestId
  });
  return promise;
}
```

:::moniker-end

:::moniker range=">= aspnetcore-11.0"

Run the app:

```bash
npm run dev
```

Open the local URL shown by the development server and select **Generate QR**. If everything is set up correctly, the page displays the generated image.

:::moniker-end

## Performance considerations and optimization

When working with .NET on Web Workers, consider these key optimization strategies:

* **Minimize data transfer**: Serialize only essential data between the main thread and worker to reduce communication overhead.
* **Batch operations**: Group multiple calculations together rather than sending individual requests.
* **Memory management**: Be mindful of memory usage in the WebAssembly environment, especially for long-running workers.
* **Startup cost**: WebAssembly initialization has overhead, so prefer persistent workers over frequent creation/destruction.

See the [sample app](#sample-app) for a demonstration of the preceding concepts.

## Additional resources

<xref:blazor/blazor-web-workers>
