# Running .NET on Web Workers: A Modern Approach to Offloading Computation in Web Applications

## Introduction and Understanding the Need

Modern web applications often require intensive computational tasks that can block the main UI thread, leading to poor user experience. Web Workers provide a solution by enabling JavaScript to run on separate threads, but what if you could leverage the power and familiarity of .NET for these background computations? With .NET WebAssembly (WASM), you can now run C# code in Web Workers, combining the performance benefits of compiled code with the non-blocking execution model of background threads.

This approach is particularly valuable when you need to perform complex calculations, data processing, or business logic without requiring direct DOM manipulation. Instead of rewriting algorithms in JavaScript, you can maintain your existing .NET codebase and execute it efficiently in the background while your React.js frontend remains responsive.

## Prerequisites and Setup

Before diving into the implementation, ensure you have the necessary tools installed. You'll need .NET 8 or later and the WebAssembly workloads:

```bash
dotnet workload install wasm-tools
dotnet workload install wasm-experimental
```

For the React.js frontend, you'll need Node.js and npm installed. Create a new React application using:

```bash
npx create-react-app react-app
cd react-app
```

## Creating the .NET WebAssembly Project

Start by creating a new WebAssembly browser project that will serve as your Web Worker:

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
            throw new Exception($"QR code size must be less than {MAX_QR_SIZE}. Try again.");
        }
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
        BitmapByteQRCode qrCode = new BitmapByteQRCode(qrCodeData);
        return qrCode.GetGraphic(qrSize);
    }
}
```

Add a `wwwroot/worker.js` file with code that interopts between C# and JS:
```js
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

## Setting Up the React.js Application

In your React application, create a Web Worker that will host the .NET WebAssembly runtime. Use an npm script defined in your `package.json` to automate copying the WebAssembly build artifacts from your .NET project to the React directory.

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

You can connect this functionality with UI and add a button that triggers `generateQR`:
```js
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

## Performance Considerations and Optimization

When working with .NET on Web Workers, consider these key optimization strategies:

• **Minimize data transfer**: Serialize only essential data between the main thread and worker to reduce communication overhead
• **Batch operations**: Group multiple calculations together rather than sending individual requests
• **Memory management**: Be mindful of memory usage in the WebAssembly environment, especially for long-running workers
• **Startup cost**: WebAssembly initialization has overhead, so prefer persistent workers over frequent creation/destruction

You can explore a complete working implementation in the demo repository at [https://github.com/ilonatommy/reactWithDotnetOnWebWorker](https://github.com/ilonatommy/reactWithDotnetOnWebWorker), which showcases these concepts in a qr-generation application.