---
title: .NET on Web Workers
author: guardrex
description: Learn how to use Web Workers to enable JavaScript to run on separate threads that don't block the main UI thread for improved app performance.
monikerRange: '>= aspnetcore-10.0'
ms.author: wpickett
ms.custom: mvc
ms.date: 10/01/2025
uid: client-side/dotnet-on-webworkers
---
# .NET on Web Workers

<!-- UPDATE 11.0 - Surface the INCLUDES file

[!INCLUDE[](~/includes/not-latest-version.md)]

-->

Modern web apps often require intensive computational tasks that can block the main UI thread, leading to poor user experience. [Web Workers](https://developer.mozilla.org/docs/Web/API/Web_Workers_API) provide a solution to this problem by enabling JavaScript (JS) to run on separate threads. With .NET WebAssembly (WASM), you can run C# code in Web Workers, combining the performance benefits of compiled code with the non-blocking execution model of background threads.

This approach is particularly valuable when you need to perform complex calculations, data processing, or business logic without requiring direct DOM manipulation. Instead of rewriting algorithms in JS, you can maintain your existing .NET codebase and execute it efficiently in the background while your React.js frontend remains responsive.

## Prerequisites and setup

Before diving into the implementation, ensure the necessary tools are installed. The [.NET SDK 8.0 or later](https://dotnet.microsoft.com/download) is required and the WebAssembly workloads:

```bash
dotnet workload install wasm-tools
dotnet workload install wasm-experimental
```

For the React.js frontend, [Node.js](https://nodejs.org/) and [npm](https://www.npmjs.com) must be installed.

Create a new React app:

```bash
npx create-react-app react-app
cd react-app
```

## Create the .NET WebAssembly project

Create a new WebAssembly browser project to serve as the Web Worker:

```bash
dotnet new wasmbrowser -n DotNetWorker
cd DotNetWorker
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

Build the WebAssembly project to generate the necessary files:

```bash
dotnet build
```

## Set up the React.js app

In the React app, create a Web Worker to host the .NET WebAssembly runtime. Use an npm script defined in the `package.json` to automate copying the WebAssembly build artifacts from the .NET project to the React directory.

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

## Performance considerations and optimization

When working with .NET on Web Workers, consider these key optimization strategies:

• **Minimize data transfer**: Serialize only essential data between the main thread and worker to reduce communication overhead.
• **Batch operations**: Group multiple calculations together rather than sending individual requests.
• **Memory management**: Be mindful of memory usage in the WebAssembly environment, especially for long-running workers.
• **Startup cost**: WebAssembly initialization has overhead, so prefer persistent workers over frequent creation/destruction.

Explore a complete working implementation in the demo repository at [`ilonatommy/reactWithDotnetOnWebWorker`](https://github.com/ilonatommy/reactWithDotnetOnWebWorker), which showcases these concepts in a QR code generation app.
