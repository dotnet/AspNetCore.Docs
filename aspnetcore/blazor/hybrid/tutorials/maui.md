---
title: Build a .NET MAUI Blazor app
author: guardrex
description: Build a .NET MAUI Blazor app step-by-step.
monikerRange: '>= aspnetcore-6.0'
ms.author: riande
ms.custom: mvc
ms.date: 09/29/2022
uid: blazor/hybrid/tutorials/maui
---
# Build a .NET MAUI Blazor app

This tutorial shows you how to build and run a .NET MAUI Blazor app. You learn how to:

> [!div class="checklist"]
> * Create a .NET MAUI Blazor app project
> * Run the app on Windows
> * Run the app in the Android emulator

## Prerequisites

* [Supported platforms (.NET MAUI documentation)](/dotnet/maui/supported-platforms)
* [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) with the **.NET Multi-platform App UI development** workload.
* [Microsoft Edge `WebView2`](https://developer.microsoft.com/microsoft-edge/webview2/): `WebView2` is required on Windows when running a native app. When developing .NET MAUI Blazor apps and only running them in Visual Studio's emulators, `WebView2` isn't required.
* [Enable hardware acceleration](/dotnet/maui/android/emulator/hardware-acceleration) to improve the performance of the Android emulator.

> [!NOTE]
> Blazor Hybrid has reached General Availability (GA) and is fully supported for production workloads. Visual Studio for Mac is in prerelease for working on Blazor Hybrid apps and may be modified before final release. We recommend keeping Visual Studio 2022 updated for the best tooling experience.

## Create a .NET MAUI Blazor app

Launch Visual Studio 2022.

In the Start Window, select **Create a new project**:

:::image type="content" source="maui/_static/new-solution.png" alt-text="New solution.":::

In the **Create a new project** window, use the **Project type** drop-down to filter **MAUI** templates:

:::image type="content" source="maui/_static/new-project-1.png" alt-text="Filter templates to .NET MAUI.":::

Select the **.NET MAUI Blazor App** template and then select the **Next** button:

:::image type="content" source="maui/_static/new-project-2.png" alt-text="Choose a template.":::

In the **Configure your new project** dialog, set the **Project name** to **`MauiBlazor`**, choose a suitable location for the project, and select the **Create** button.

:::image type="content" source="maui/_static/configure-project.png" alt-text="Configure the project.":::

Wait for Visual Studio to create the project and for the project's dependencies to be restored:

:::image type="content" source="maui/_static/restored-dependencies.png" alt-text="Restored dependencies.":::

## Run the app on Windows

In the Visual Studio toolbar, select the **Windows Machine** button to build and start the project:

:::image type="content" source="maui/_static/windows-machine-button.png" alt-text="Windows Machine button.":::

If Developer Mode isn't enabled, you're prompted to enable it in **Settings** > **For developers** > **Developer Mode** (Windows 10) or **Settings** > **Privacy & security** > **For developers** > **Developer Mode** (Windows 11). Set the switch to **On**.

The app running as a Windows desktop app:

:::image type="content" source="maui/_static/running-app-windows.png" alt-text="App running on Windows.":::

## Run the app in the Android Emulator

If you followed the guidance in the [Run the app on Windows](#run-the-app-on-windows) section, select the **Stop Debugging** button in the toolbar to stop the running Windows app:

:::image type="content" source="maui/_static/stop-debugging-button.png" alt-text="Stop Debugging button.":::

In the Visual Studio toolbar, select the start configuration drop-down button. Select **Android Emulators** > **Android Emulator**:

:::image type="content" source="maui/_static/android-emulators-android-emulator-button.png" alt-text="Android Emulators drop-down selection for the Android Emulator button.":::

Android SDKs are required to build apps for Android. In the **Error List** panel, a message appears asking you to double-click the message to install the required Android SDKs:

:::image type="content" source="maui/_static/error-list.png" alt-text="Visual Studio Error List with message asking you to click the message to install Android SDKs.":::

The **Android SDK License Acceptance** window appears, select the **Accept** button for each license that appears. An additional window appears for the **Android Emulator** and **SDK Patch Applier** licenses. Select the **Accept** button.

Wait for Visual Studio to download the Android SDK and Android Emulator. You can track the progress by selecting the background tasks indicator in the lower-left corner of the Visual Studio UI:

:::image type="content" source="maui/_static/background-tasks-indicator.png" alt-text="Visual Studio background tasks indicator.":::

The indicator shows a checkmark when the background tasks are complete:

:::image type="content" source="maui/_static/background-tasks-indicator-checked.png" alt-text="Visual Studio background tasks indicator checked.":::

In the toolbar, select the **Android Emulator** button:

:::image type="content" source="maui/_static/android-emulator-button.png" alt-text="Android Emulator button.":::

In the **Create a Default Android Device** window, select the **Create** button:

:::image type="content" source="maui/_static/new-android-device.png" alt-text="Create a Default Android Device window.":::

Wait for Visual Studio to download, unzip, and create an Android Emulator. When the Android phone emulator is ready, select the **Start** button.

> [!NOTE]
> [Enable hardware acceleration](/xamarin/android/get-started/installation/android-emulator/hardware-acceleration) to improve the performance of the Android emulator.

Close the **Android Device Manager** window. Wait until the emulated phone window appears, the Android OS loads, and the home screen appears.

In the Visual Studio toolbar, select the **Pixel 5 - {VERSION}** button to build and run the project, where the `{VERSION}` placeholder is the Android version. In the following example, the Android version is `API 30 (Android 11.0 - API 30)`, and a later version appears depending on the Android SDK installed:

:::image type="content" source="maui/_static/pixel5-api30.png" alt-text="Pixel 5 API 30 emulator button.":::

Visual Studio builds the project and deploys the app to the emulator.

The app running in the Android Emulator:

:::image type="content" source="maui/_static/running-app-android.png" alt-text="App running in the Android Emulator.":::

## Next steps

In this tutorial, you learned how to:

> [!div class="checklist"]
> * Create a .NET MAUI Blazor app project
> * Run the app on Windows
> * Run the app in the Android Emulator

Learn more about Blazor Hybrid apps:

> [!div class="nextstepaction"]
> <xref:blazor/hybrid/index>
