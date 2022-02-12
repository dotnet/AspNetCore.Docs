---
title: Build a .NET MAUI Blazor app
author: guardrex
description: Build a .NET MAUI Blazor app step-by-step.
monikerRange: '>= aspnetcore-6.0'
ms.author: riande
ms.custom: mvc
ms.date: 02/12/2022
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/hybrid/tutorials/maui
---
# Build a .NET MAUI Blazor app

This tutorial shows you how to build and modify a .NET MAUI Blazor app. You learn how to:

> [!div class="checklist"]
> * Create a .NET MAUI Blazor app project
> * Run the project in the Windows Machine emulator
> * Run the project in the Android emulator

At the end of this tutorial, you'll have a working app.

## Prerequisites

* [Supported platforms (.NET MAUI documentation)](/dotnet/maui/supported-platforms)
* [Visual Studio 2022 Preview](https://visualstudio.microsoft.com/vs/preview/) with the following workloads:
  * **Mobile development with .NET**
  * **Universal Windows Platform development**
* [Microsoft Edge WebView2](https://developer.microsoft.com/microsoft-edge/webview2/): WebView2 is required on Windows when running a native app. When developing .NET MAUI Blazor apps and only running them in Visual Studio's emulators, WebView2 isn't required.

## Installation

Follow the guidance in [Installation (.NET MAUI documentation)](/dotnet/maui/get-started/installation).

## Create a .NET MAUI Blazor app

Launch Visual Studio 2022 17.1 Preview, and in the start window click **Create a new project** to create a new project:

:::image type="content" source="maui/_static/new-solution.png" alt-text="New solution.":::

In the **Create a new project** window, select **MAUI** in the **Project type** drop-down, select the **.NET MAUI App (Preview)** template, and click the **Next** button:

:::image type="content" source="maui/_static/new-project.png" alt-text="Choose a template.":::

> [!NOTE]
> If the **.NET MAUI App (Preview)** project template does not appear in the **Create a new project** window, open the Developer Command Prompt for VS 2022 Preview and run the following command: `devenv.exe /updateConfiguration`. Then, restart Visual Studio.

In the **Configure your new project** window, name your project, choose a suitable location for it, and click the **Create** button:

:::image type="content" source="maui/_static/configure-project.png" alt-text="Configure the project.":::

Wait for Visual Studio to create the project and for the project's dependencies to be restored:

:::image type="content" source="maui/_static/restored-dependencies.png" alt-text="Restored dependencies.":::

In the **Android SDK License Acceptance** window, select the **Accept** button:

:::image type="content" source="maui/_static/android-sdk-license.png" alt-text="Android SDK License Acceptance window.":::

In the **User Account Control** dialog, select the **Yes** button:

:::image type="content" source="maui/_static/user-account-control.png" alt-text="User Account Control dialog.":::

Wait for Visual Studio to download the Android SDK and Android Emulator.

## Run the app in the Windows Machine Emulator

In the Visual Studio toolbar, select the **Windows Machine** button to build the app:

:::image type="content" source="maui/_static/windows-machine-button.png" alt-text="Windows Machine button.":::

In the **User Account Control** dialog, select the **Yes** button:

:::image type="content" source="maui/_static/user-account-control.png" alt-text="User Account Control dialog.":::

If Developer Mode isn't enabled, you're prompted to enable it in **Settings** > **For developers** > **Developer Mode**. Set the switch to **On**:

:::image type="content" source="maui/_static/windows-developer-mode.png" alt-text="Windows Developer Mode enabled.":::

The running app in the Windows Machine Emulator:

:::image type="content" source="maui/_static/running-app-windows-1.png" alt-text="App running in the Windows Machine Emulator.":::

Navigate to the **`Counter`** page. Select the **`Click me`** button to increment the counter:

:::image type="content" source="maui/_static/running-app-windows-2.png" alt-text="Counter page running in the Windows Machine Emulator.":::

## Run the app in the Android Emulator

In the Visual Studio toolbar, select the **Android Emulator** button to build the app:

:::image type="content" source="maui/_static/android-emulator-button.png" alt-text="Android Emulator button.":::

In the **User Account Control** dialog, select the **Yes** button:

:::image type="content" source="maui/_static/user-account-control.png" alt-text="User Account Control dialog.":::

In the **New Device** window, select the **Create** button:

:::image type="content" source="maui/_static/new-android-device.png" alt-text="New Android Device window.":::

In the **License Acceptance** window, select the **Accept** button:

:::image type="content" source="maui/_static/license-acceptance.png" alt-text="License Acceptance window.":::

Wait for Visual Studio to download, unzip, and create an Android Emulator.

Close the **Android Device Manager** window:

:::image type="content" source="maui/_static/android-device-manager.png" alt-text="Android Device Manager window.":::

In the Visual Studio toolbar, select the **Pixel 5 - API 30 (Android 11.0 - API 30)** button to build and run the app:

:::image type="content" source="maui/_static/pixel5-api30.png" alt-text="Pixel 5 API 30 emulator button.":::

Visual Studio starts the Android Emulator, builds the app, and deploys the app to the emulator.

In the running app in the Android Emulator, select the **CLICK ME** button several times and observe that the count of the number of button clicks is incremented.

:::image type="content" source="maui/_static/running-app-android.png" alt-text="App running in the Android Emulator.":::

## Next steps

In this tutorial, you learned how to:

> [!div class="checklist"]
> * Create a .NET MAUI Blazor app project
> * Run the project in the Windows Machine emulator
> * Run the project in the Android emulator

Learn more about Blazor Hybrid apps:

> [!div class="nextstepaction"]
> <xref:blazor/hybrid/index>
