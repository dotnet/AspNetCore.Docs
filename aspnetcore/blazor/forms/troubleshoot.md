---
title: Troubleshoot ASP.NET Core Blazor forms
author: guardrex
description: Learn how to troubleshoot forms in Blazor.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/08/2022
uid: blazor/forms/troubleshoot
---
# Troubleshoot ASP.NET Core Blazor forms

[!INCLUDE[](~/includes/not-latest-version.md)]

This article provides troubleshooting guidance for Blazor forms.

## Large form payloads and the SignalR message size limit

*This section only applies to Blazor Web Apps, Blazor Server apps, and hosted Blazor WebAssembly solutions that implement SignalR.*

:::moniker range=">= aspnetcore-6.0"

If form processing fails because the component's form payload has exceeded the maximum incoming SignalR message size permitted for hub methods, the form can adopt [streaming JS interop](xref:blazor/js-interop/call-dotnet-from-javascript#stream-from-javascript-to-net) without increasing the message size limit. For more information on the size limit and the error thrown, see <xref:blazor/fundamentals/signalr#maximum-receive-message-size>.

In the following example a text area (`<textarea>`) is used with streaming JS interop to move up to 50,000 bytes of data to the server.

Add a JavaScript (JS) `getText` function to the app:

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

```javascript
window.getText = (elem) => {
  const textValue = elem.value;
  const utf8Encoder = new TextEncoder();
  const encodedTextValue = utf8Encoder.encode(textValue);
  return encodedTextValue;
};
```

For information on where to place JS in a Blazor app, see <xref:blazor/js-interop/index#javaScript-location>.

Due to security considerations, zero-length streams aren't permitted for streaming JS Interop. Therefore, the following `StreamFormData` component traps a <xref:Microsoft.JSInterop.JSException> and returns an empty string if the text area is blank when the form is submitted.

`StreamFormData.razor`:

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

```razor
@page "/stream-form-data"
@rendermode RenderMode.InteractiveServer
@inject IJSRuntime JS
@inject ILogger<StreamFormData> Logger

<h1>Stream form data with JS interop</h1>

<EditForm Model="@this" OnSubmit="@Submit" FormName="StreamFormData">
    <div>
        <label>
            &lt;textarea&gt; value streamed for assignment to
            <code>TextAreaValue (&lt;= 50,000 characters)</code>:
            <textarea @ref="largeTextArea" />
        </label>
    </div>
    <div>
        <button type="submit">Submit</button>
    </div>
</EditForm>

<div>
    Length: @TextAreaValue?.Length
</div>

@code {
    private ElementReference largeTextArea;

    public string? TextAreaValue { get; set; }

    protected override void OnInitialized() =>
        TextAreaValue ??= string.Empty;

    private async Task Submit()
    {
        TextAreaValue = await GetTextAsync();

        Logger.LogInformation("TextAreaValue length: {Length}",
            TextAreaValue.Length);
    }

    public async Task<string> GetTextAsync()
    {
        try
        {
            var streamRef =
                await JS.InvokeAsync<IJSStreamReference>("getText", largeTextArea);
            var stream = await streamRef.OpenReadStreamAsync(maxAllowedSize: 50_000);
            var streamReader = new StreamReader(stream);

            return await streamReader.ReadToEndAsync();
        }
        catch (JSException jsException)
        {
            if (jsException.InnerException is
                    ArgumentOutOfRangeException outOfRangeException &&
                outOfRangeException.ActualValue is not null &&
                outOfRangeException.ActualValue is long actualLength &&
                actualLength == 0)
            {
                return string.Empty;
            }

            throw;
        }
    }
}
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

```razor
@page "/stream-form-data"
@inject IJSRuntime JS
@inject ILogger<StreamFormData> Logger

<h1>Stream form data with JS interop</h1>

<EditForm Model="@this" OnSubmit="@Submit">
    <div>
        <label>
            &lt;textarea&gt; value streamed for assignment to
            <code>TextAreaValue (&lt;= 50,000 characters)</code>:
            <textarea @ref="largeTextArea" />
        </label>
    </div>
    <div>
        <button type="submit">Submit</button>
    </div>
</EditForm>

<div>
    Length: @TextAreaValue?.Length
</div>

@code {
    private ElementReference largeTextArea;

    public string? TextAreaValue { get; set; }

    protected override void OnInitialized() => 
        TextAreaValue ??= string.Empty;

    private async Task Submit()
    {
        TextAreaValue = await GetTextAsync();

        Logger.LogInformation("TextAreaValue length: {Length}",
            TextAreaValue.Length);
    }

    public async Task<string> GetTextAsync()
    {
        try
        {
            var streamRef =
                await JS.InvokeAsync<IJSStreamReference>("getText", largeTextArea);
            var stream = await streamRef.OpenReadStreamAsync(maxAllowedSize: 50_000);
            var streamReader = new StreamReader(stream);

            return await streamReader.ReadToEndAsync();
        }
        catch (JSException jsException)
        {
            if (jsException.InnerException is
                    ArgumentOutOfRangeException outOfRangeException &&
                outOfRangeException.ActualValue is not null &&
                outOfRangeException.ActualValue is long actualLength &&
                actualLength == 0)
            {
                return string.Empty;
            }

            throw;
        }
    }
}
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

If form processing fails because the component's form payload has exceeded the maximum incoming SignalR message size permitted for hub methods, the message size limit can be increased. For more information on the size limit and the error thrown, see <xref:blazor/fundamentals/signalr#maximum-receive-message-size>.

:::moniker-end

## EditForm parameter error

> InvalidOperationException: EditForm requires a Model parameter, or an EditContext parameter, but not both.

Confirm that the <xref:Microsoft.AspNetCore.Components.Forms.EditForm> assigns a <xref:Microsoft.AspNetCore.Components.Forms.EditForm.Model> **or** an <xref:Microsoft.AspNetCore.Components.Forms.EditForm.EditContext>. Don't use both for the same form.

When assigning to <xref:Microsoft.AspNetCore.Components.Forms.EditForm.Model>, confirm that the model type is instantiated.

## Connection disconnected

> Error: Connection disconnected with error 'Error: Server returned an error on close: Connection closed with an error.'.

> System.IO.InvalidDataException: The maximum message size of 32768B was exceeded. The message size can be configured in AddHubOptions.

For more information and guidance, see the following resources:

* [Large form payloads and the SignalR message size limit](#large-form-payloads-and-the-signalr-message-size-limit)
* <xref:blazor/fundamentals/signalr#maximum-receive-message-size>
