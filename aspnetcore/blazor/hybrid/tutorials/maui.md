---
title: Build a .NET MAUI Blazor Hybrid app
author: guardrex
description: Build a .NET MAUI Blazor Hybrid app step-by-step.
monikerRange: '>= aspnetcore-6.0'
ms.author: riande
ms.custom: mvc
ms.date: 11/14/2023
uid: blazor/hybrid/tutorials/maui
---
# Build a .NET MAUI Blazor Hybrid app

[!INCLUDE[](~/includes/not-latest-version.md)]

This tutorial shows you how to build and run a .NET MAUI Blazor Hybrid app. You learn how to:

> [!div class="checklist"]
> * Create a .NET MAUI Blazor Hybrid app project in Visual Studio
> * Run the app on Windows
> * Run the app on an emulated mobile device in the Android Emulator

## Prerequisites

* [Supported platforms (.NET MAUI documentation)](/dotnet/maui/supported-platforms)
* [Visual Studio](https://visualstudio.microsoft.com/vs/) with the **.NET Multi-platform App UI development** workload.
* [Microsoft Edge :::no-loc text="WebView2":::](https://developer.microsoft.com/microsoft-edge/webview2/): :::no-loc text="WebView2"::: is required on Windows when running a native app. When developing .NET MAUI Blazor Hybrid apps and only running them in Visual Studio's emulators, :::no-loc text="WebView2"::: isn't required.
* [Enable hardware acceleration](/dotnet/maui/android/emulator/hardware-acceleration) to improve the performance of the Android emulator.

For more information on prerequisites and installing software for this tutorial, see the following resources in the .NET MAUI documentation:

* [Supported platforms for .NET MAUI apps](/dotnet/maui/supported-platforms)
* [Installation (Visual Studio)](/dotnet/maui/get-started/installation?tabs=vswin)

## Create a .NET MAUI Blazor Hybrid app

Launch Visual Studio. In the **Start Window**, select **Create a new project**:

:::image type="content" source="maui/_static/win/new-solution.png" alt-text="New solution.":::

In the **Create a new project** window, use the **Project type** dropdown to filter **MAUI** templates:

:::image type="content" source="maui/_static/win/new-project-1.png" alt-text="Filter templates to .NET MAUI.":::

Select the **.NET MAUI Blazor Hybrid App** template and then select the **Next** button:

:::image type="content" source="maui/_static/win/new-project-2.png" alt-text="Choose a template.":::

> [!NOTE]
> In .NET 7.0 or earlier, the template is named **.NET MAUI Blazor App**.

In the **Configure your new project** dialog:

* Set the **Project name** to **:::no-loc text="MauiBlazor":::**.
* Choose a suitable location for the project.
* Select the **Next** button.

:::image type="content" source="maui/_static/win/configure-project.png" alt-text="Configure the project.":::

In the **Additional information** dialog, select the framework version with the **Framework** dropdown list. Select the **Create** button:

:::image type="content" source="maui/_static/win/additional-information.png" alt-text="Additional information dialog for selecting the framework version and creating the project.":::

Wait for Visual Studio to create the project and restore the project's dependencies. Monitor the progress in **Solution Explorer** by opening the **Dependencies** entry.

Dependencies restoring:

:::image type="content" source="maui/_static/win/dependencies-restoring.png" alt-text="Restoring dependencies.":::

Dependencies restored:

:::image type="content" source="maui/_static/win/dependencies-restored.png" alt-text="Restored dependencies.":::

## Run the app on Windows

In the Visual Studio toolbar, select the **Windows Machine** button to build and start the project:

:::image type="content" source="maui/_static/win/windows-machine-button.png" alt-text="Windows Machine button.":::

If Developer Mode isn't enabled, you're prompted to enable it in **Settings** > **For developers** > **Developer Mode** (Windows 10) or **Settings** > **Privacy & security** > **For developers** > **Developer Mode** (Windows 11). Set the switch to **On**.

The app running as a Windows desktop app:

:::image type="content" source="maui/_static/win/running-app-windows.png" alt-text="App running on Windows.":::

## Run the app in the Android Emulator

If you followed the guidance in the [Run the app on Windows](#run-the-app-on-windows) section, select the **Stop Debugging** button in the toolbar to stop the running Windows app:

:::image type="content" source="maui/_static/win/stop-debugging-button.png" alt-text="Stop Debugging button.":::

In the Visual Studio toolbar, select the start configuration dropdown button. Select **Android Emulators** > **Android Emulator**:

:::image type="content" source="maui/_static/win/android-emulators-android-emulator-button.png" alt-text="Android Emulators dropdown selection for the Android Emulator button.":::

Android SDKs are required to build apps for Android. In the **Error List** panel, a message appears asking you to double-click the message to install the required Android SDKs:

:::image type="content" source="maui/_static/win/error-list.png" alt-text="Visual Studio Error List with message asking you to click the message to install Android SDKs.":::

The **Android SDK License Acceptance** window appears, select the **Accept** button for each license that appears. An additional window appears for the **Android Emulator** and **SDK Patch Applier** licenses. Select the **Accept** button.

Wait for Visual Studio to download the Android SDK and Android Emulator. You can track the progress by selecting the background tasks indicator in the lower-left corner of the Visual Studio UI:

:::image type="content" source="maui/_static/win/background-tasks-indicator.png" alt-text="Visual Studio background tasks indicator.":::

The indicator shows a checkmark when the background tasks are complete:

:::image type="content" source="maui/_static/win/background-tasks-indicator-checked.png" alt-text="Visual Studio background tasks indicator checked.":::

In the toolbar, select the **Android Emulator** button:

:::image type="content" source="maui/_static/win/android-emulator-button.png" alt-text="Android Emulator button.":::

In the **Create a Default Android Device** window, select the **Create** button:

:::image type="content" source="maui/_static/win/new-android-device.png" alt-text="Create a Default Android Device window.":::

Wait for Visual Studio to download, unzip, and create an Android Emulator. When the Android phone emulator is ready, select the **Start** button.

> [!NOTE]
> [Enable hardware acceleration](/xamarin/android/get-started/installation/android-emulator/hardware-acceleration) to improve the performance of the Android emulator.

Close the **Android Device Manager** window. Wait until the emulated phone window appears, the Android OS loads, and the home screen appears.

> [!IMPORTANT]
> The emulated phone must be powered on with the Android OS loaded in order to load and run the app in the debugger. If the emulated phone isn't running, turn on the phone using either the <kbd>Ctrl</kbd>+<kbd>P</kbd> keyboard shortcut or by selecting the **Power** button in the UI:
>
> :::image type="content" source="maui/_static/win/android-phone-power-button.png" alt-text="The Android Emulator's Power button.":::

In the Visual Studio toolbar, select the **:::no-loc text="Pixel 5 - {VERSION}":::** button to build and run the project, where the `{VERSION}` placeholder is the Android version. In the following example, the Android version is **:::no-loc text="API 30 (Android 11.0 - API 30)":::**, and a later version appears depending on the Android SDK installed:

:::image type="content" source="maui/_static/win/pixel5-api30.png" alt-text="Pixel 5 API 30 emulator button.":::

Visual Studio builds the project and deploys the app to the emulator.

Starting the emulator, loading the emulated phone and OS, and deploying and running the app can take several minutes depending on the speed of the system and whether or not [hardware acceleration](/xamarin/android/get-started/installation/android-emulator/hardware-acceleration) is enabled. You can monitor the progress of the deployment by inspecting Visual Studio's status bar at the bottom of the UI. The **Ready** indicator receives a checkmark and the emulator's deployment and app loading indicators disappear when the app is running:

During deployment:

:::image type="content" source="maui/_static/win/deploy-run-indicator-1.png" alt-text="The first deploy-run indicator that appears in the Visual Studio footer bar.":::

During app startup:

:::image type="content" source="maui/_static/win/deploy-run-indicator-2.png" alt-text="The second deploy-run indicator that appears in the Visual Studio footer bar.":::

The app running in the Android Emulator:

:::image type="content" source="maui/_static/win/running-app-android.png" alt-text="App running in the Android Emulator.":::

## Next steps

In this tutorial, you learned how to:

> [!div class="checklist"]
> * Create a .NET MAUI Blazor Hybrid app project in Visual Studio
> * Run the app on Windows
> * Run the app on an emulated mobile device in the Android Emulator

Learn more about Blazor Hybrid apps:

> [!div class="nextstepaction"]
> <xref:blazor/hybrid/index>
