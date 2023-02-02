---
title: Build a .NET MAUI Blazor app
author: guardrex
description: Build a .NET MAUI Blazor app step-by-step.
monikerRange: '>= aspnetcore-6.0'
ms.author: riande
ms.custom: mvc
ms.date: 11/18/2022
uid: blazor/hybrid/tutorials/maui
zone_pivot_groups: blazor-hybrid-tutorial-vs-operating-systems
---
# Build a .NET MAUI Blazor app

:::zone pivot="windows"

This tutorial shows you how to build and run a .NET MAUI Blazor app. You learn how to:

> [!div class="checklist"]
> * Create a .NET MAUI Blazor app project in Visual Studio
> * Run the app on Windows
> * Run the app on an emulated mobile device in the Android Emulator

## Prerequisites

* [Supported platforms (.NET MAUI documentation)](/dotnet/maui/supported-platforms)
* [Visual Studio](https://visualstudio.microsoft.com/vs/) with the **.NET Multi-platform App UI development** workload.
* [Microsoft Edge :::no-loc text="WebView2":::](https://developer.microsoft.com/microsoft-edge/webview2/): :::no-loc text="WebView2"::: is required on Windows when running a native app. When developing .NET MAUI Blazor apps and only running them in Visual Studio's emulators, :::no-loc text="WebView2"::: isn't required.
* [Enable hardware acceleration](/dotnet/maui/android/emulator/hardware-acceleration) to improve the performance of the Android emulator.

For more information on prerequisites and installing software for this tutorial, see the following resources in the .NET MAUI documentation:

* [Supported platforms for .NET MAUI apps](/dotnet/maui/supported-platforms)
* [Installation (Visual Studio)](/dotnet/maui/get-started/installation?tabs=vswin)

## Create a .NET MAUI Blazor app

Launch Visual Studio. In the **Start Window**, select **Create a new project**:

:::image type="content" source="maui/_static/win/new-solution.png" alt-text="New solution.":::

In the **Create a new project** window, use the **Project type** dropdown to filter **MAUI** templates:

:::image type="content" source="maui/_static/win/new-project-1.png" alt-text="Filter templates to .NET MAUI.":::

Select the **.NET MAUI Blazor App** template and then select the **Next** button:

:::image type="content" source="maui/_static/win/new-project-2.png" alt-text="Choose a template.":::

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
> * Create a .NET MAUI Blazor app project in Visual Studio
> * Run the app on Windows
> * Run the app on an emulated mobile device in the Android Emulator

:::zone-end

:::zone pivot="macos"

This tutorial shows you how to build and run a .NET MAUI Blazor app. You learn how to:

> [!div class="checklist"]
> * Create a .NET MAUI Blazor app project in Visual Studio for Mac
> * Run the app on macOS with Mac Catalyst
> * Run the app on an emulated mobile device in the Android Emulator

## Prerequisites

* [Supported platforms (.NET MAUI documentation)](/dotnet/maui/supported-platforms)
* [Apple ID](https://appleid.apple.com/account) / [Apple Developer Program](https://developer.apple.com/programs/)
* [Apple Xcode](https://developer.apple.com/xcode/)
* [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/) with the **.NET Multi-platform App UI development** workload.

> [!IMPORTANT]
> Install Apple Xcode before installing Visual Studio for Mac.
>
> If the IDEs are installed in reverse order, set the Apple SDK in Visual Studio for Mac with the following steps:
>
> 1. Select **Visual Studio** > **Preferences** from the menu bar in Visual Studio for Mac.
> 1. Under **SDK Locations** > **Apple**, set the **Apple SDK** > **Location** path to the physical location of the Xcode app.
> 1. Select the **Restart Visual Studio** button.

For more information on prerequisites and installing software on macOS for this tutorial, see the following resources in the .NET MAUI documentation:

* [Supported platforms for .NET MAUI apps](/dotnet/maui/supported-platforms)
* [Installation (Visual Studio for Mac)](/dotnet/maui/get-started/installation?tabs=vsmac)

## Create a .NET MAUI Blazor app

Launch Visual Studio for Mac. If the **Start Window** isn't open, select **Show Start Window** from the **File** menu.

Select the **New** button to create a new app:

:::image type="content" source="maui/_static/mac/step01.png" alt-text="Visual Studio for Mac Start .":::

Select the **.NET MAUI Blazor App** project template and select the **Continue** button:

:::image type="content" source="maui/_static/mac/step02.png" alt-text="Choose a template for your new project dialog with the .NET MAUI Blazor App project template selected.":::

Select the target framework with the **Target framework** dropdown and select the **Continue** button:

:::image type="content" source="maui/_static/mac/step03.png" alt-text="Configure your new .NET MAUI Blazor App dialog with the .NET 7.0 target framework selected.":::

Name the project in the **Project name** field and select the **Create** button. The project name for this demonstration is `MauiBlazor`:

:::image type="content" source="maui/_static/mac/step04.png" alt-text="Configure your new .NET MAUI Blazor App dialog with an project name of MauiBlazor.":::

## Run the app on macOS with Mac Catalyst

Select the play button (▶) to build and run the app:

:::image type="content" source="maui/_static/mac/step05.png" alt-text="MauiBlazor window indicating the location of the play button.":::

An alternative to using the play button to build and start the app is to select **Start Without Debugging** from the **Debug** menu.

The app running on macOS with Mac Catalyst:

:::image type="content" source="maui/_static/mac/step06.png" alt-text="The .NET MAUI Blazor app running in Apple Safari.":::

## Run the app in the Android Emulator

Select the device portion of the **Debug** > **My Mac (MacCatalyst)** button:

:::image type="content" source="maui/_static/mac/step07.png" alt-text="The Debug device button showing the My Mac (MacCatalyst) portion of the button.":::

Select **Android Emulator** from the dropdown:

:::image type="content" source="maui/_static/mac/step08.png" alt-text="The list of devices that appears after the device portion of the Debug device button is selected in the UI, which shows the Android Emulator as a device selection.":::

Select the play button (▶):

:::image type="content" source="maui/_static/mac/step09.png" alt-text="The play button shown next to the Debug device button.":::

Because no Android devices exist, the **New Device** window appears with a default Android mobile device loaded. The following example shows the default device as a Google Pixel 5 mobile device using API 33. Regardless of the default device recommended or your selection of a different device, select the **Create** button:

:::image type="content" source="maui/_static/mac/step10.png" alt-text="New Device window with the default Android mobile device loaded.":::

If the **License Acceptance** window appears and you agree with the terms of the license, select the **Accept** button:

:::image type="content" source="maui/_static/mac/step11.png" alt-text="The License Acceptance dialog describing the terms and conditions for using the Android Software Development Kit.":::

The **Android Device Manager** dialog appears and shows the progress for downloading, unzipping, and installing the new Android mobile device:

:::image type="content" source="maui/_static/mac/step12.png" alt-text="Android Device Manager dialog showing an 8% downloading progress for the Google Pixel 5 mobile device.":::

Wait until the Android device is installed.

Select the **Play** (▶) button to start the emulated mobile device:

:::image type="content" source="maui/_static/mac/step13.png" alt-text="Android Device Manager dialog Play button for the Google Pixel 5 mobile device.":::

The emulated Android mobile device appears. Wait until the device's emulated OS loads:

:::image type="content" source="maui/_static/mac/step14.png" alt-text="Google Pixel 5 mobile device running in the Android Emulator.":::

In Visual Studio for Mac, use the **Debug** device dropdown to select the new Android mobile device:

:::image type="content" source="maui/_static/mac/step15.png" alt-text="Debug device dropdown showing the Google Pixel 5 mobile device entry.":::

The Android device now appears in the **Debug** device button. Select the **Play** (▶) button to build and launch the app on the mobile device:

:::image type="content" source="maui/_static/mac/step16.png" alt-text="The Play button next to the Debug device button in the Visual Studio for Mac UI.":::

The Visual Studio status bar indicates that the app is deploying to the emulated mobile device:

:::image type="content" source="maui/_static/mac/step17.png" alt-text="Deploying to Device message in the status bar.":::

The app running on the emulated Android mobile device:

:::image type="content" source="maui/_static/mac/step18.png" alt-text="The app running on an emulated Google Pixel 5 mobile device.":::

## Next steps

In this tutorial, you learned how to:

> [!div class="checklist"]
> * Create a .NET MAUI Blazor app project in Visual Studio for Mac
> * Run the app on macOS with Mac Catalyst
> * Run the app on an emulated mobile device in the Android Emulator

:::zone-end

Learn more about Blazor Hybrid apps:

> [!div class="nextstepaction"]
> <xref:blazor/hybrid/index>
