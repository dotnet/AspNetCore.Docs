---
title: Client-side library acquisition in ASP.NET Core with Library Manager (LibMan)
author: scottaddie
description: Learn how to install client-side library assets in an ASP.NET Core project using Library Manager (LibMan).
ms.author: scaddie
ms.custom: mvc
ms.date: 08/09/2018
uid: client-side/libman
---
# Client-side library acquisition with Library Manager

Library Manager (LibMan) is a lightweight, client-side library acquisition tool. It helps you download popular libraries and frameworks from external sources, such as [CDNJS](https://cdnjs.com/) and [unpkg](https://unpkg.com/#/). Only the necessary files are fetched and placed in the appropriate location within the ASP.NET Core project.

## Prerequisites

* Visual Studio 2017 version 15.8 or later with the **ASP.NET and web development** workload
* .NET Core SDK 2.1.300 or later

## LibMan use cases

LibMan offers the following benefits:

* Only the library files you need are downloaded.
* Additional tooling, such as [Node.js](https://nodejs.org), [npm](https://www.npmjs.com), and [WebPack](https://webpack.js.org), is unnecessary to acquire a subset of files in a library.
* Files can be placed in a specific location, without resorting to build tasks or manual file copying.

For more information about LibMan's benefits, watch [this clip about the initial prototype](https://channel9.msdn.com/Events/Build/2017/B8073#time=43m34s).

LibMan isn't a package management system. If you're happily using a package manager, such as npm or [yarn](https://yarnpkg.com), continue doing so. LibMan wasn't developed to replace those tools.

## LibMan in Visual Studio

Visual Studio has built-in support for LibMan in ASP.NET Core projects, including:

* Support for configuring and running LibMan restore operations on build
* Menu items for triggering LibMan restore and clean operations
* Search dialog for finding libraries and adding the files to your project
* Editing support for *libman.json*&mdash;the LibMan manifest file

There are two ways to add files to your ASP.NET Core project:

1. [Use the Add Client-Side Library dialog](#use-the-add-client-side-library-dialog)
1. [Edit the LibMan manifest](#edit-the-libman-manifest)

### Use the Add Client-Side Library dialog

Follow these steps to install a client-side library:

* In **Solution Explorer**, right-click the folder in which the file(s) should be added. Choose **Add** > **Client-Side Library**. The **Add Client-Side Library** dialog appears.
* Type the library name to fetch in the *Library* text box. IntelliSense provides a list of libraries beginning with the provided text.
* Select the library from the IntelliSense list. The library name is suffixed with the `@` symbol and the latest stable version known to the selected provider.
* To include all of the library's files, choose the **Include all library files** radio button. To include a subset of the library's files, choose the **Choose specific files** radio button. The file selector tree becomes usable. Use the check boxes to the left of the files to select files for download.
* Specify the project folder for storing the new files. As a recommendation, store each library in a separate folder. The default folder suggestion is the location from which the dialog is launched, plus the library name. For example, *wwwroot/lib/jquery/*.
* Click the **Install** button. The *libman.json* file is modified to store the package configuration. The files are downloaded to the specified folder in the project.
* Review the **Output** window's **Library Manager** view for details of the installation.

### Edit the LibMan manifest

All LibMan operations are based on the content of the LibMan manifest&mdash;*libman.json* file at the project root. You can manually edit the file to define library files to download. Visual Studio offers editing support such as colorization, formatting, IntelliSense, and JSON schema validation.

> [!NOTE]
> LibMan only supports one version of each library from each provider. The *libman.json* file fails schema validation if it contains two libraries with the same library name for a given provider.

### Restore library files into your project

If your project has a valid *libman.json* file, the **Restore Client-Side Libraries** operation downloads the defined library files and places them in your project at the location specified for each library. You can trigger a restore operation for all projects in the solution by choosing the restore option that appears on the solution-level context menu.

While the operation is running, the Task Status Center icon on the status bar is animated. Clicking the icon opens a window listing the known background tasks. Messages are sent to the **Library Manager** feed in the **Output** window and the status bar.

### Clean library files from your project

The **Clean Client-Side Libraries** operation removes all the library files that were previously restored by LibMan in Visual Studio. So that additional non-library files aren't unintentionally removed, the clean operation doesn't delete whole directories. It only removes the files that were included in the previous restore.

### Restore library files on build

If you'd like the project to be configured so that it automatically triggers a LibMan restore operation whenever the project is built, you can choose to **Enable Restore Client-Side Libraries on Build**. The [Microsoft.Web.LibraryManager.Build](https://www.nuget.org/packages/Microsoft.Web.LibraryManager.Build/) NuGet package is added to your project. The package contains an MSBuild target that causes LibMan to run as part of the build operation for that project in future builds.

When Restore on Build is enabled, the menu item offers to **Disable Restore Client-Side Libraries on Build**. If you choose this option, the LibMan NuGet package is removed from the project and the client-side libraries are no longer restored on each build.

Regardless of the Restore on Build setting, you can manually restore by activating the Restore Client-Side Libraries command at any time.

### Uninstall library files

To uninstall library files from within Visual Studio, edit the *libman.json* file and save. The restore operation runs on save and removes the library files that are no longer part of the LibMan config.

### Update library versions

To update the version of a library, edit the *libman.json* file by changing to the version required. When the file is saved, the LibMan restore operation removes redundant files from the previous version and adds new and updated files from the new version.

## Additional resources

* [LibMan GitHub repository](https://github.com/aspnet/LibraryManager)
