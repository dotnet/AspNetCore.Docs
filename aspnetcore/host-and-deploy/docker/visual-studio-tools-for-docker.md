---
title: Visual Studio Tools for Docker with ASP.NET Core
author: spboyer
description: Learn how to use Visual Studio 2017 tooling and Docker for Windows to containerize an ASP.NET Core app.
manager: wpickett
ms.author: scaddie
ms.custom: mvc
ms.date: 12/12/2017
ms.prod: aspnet-core
ms.technology: aspnet
ms.topic: article
uid: host-and-deploy/docker/visual-studio-tools-for-docker
---
# Visual Studio Tools for Docker with ASP.NET Core

[Visual Studio 2017](https://www.visualstudio.com/) supports building, debugging, and running ASP.NET Core apps targeting either .NET Framework or .NET Core. Both Windows and Linux containers are supported.

## Prerequisites

* [Visual Studio 2017](https://www.visualstudio.com/) with the **.NET Core cross-platform development** workload
* [Docker for Windows](https://docs.docker.com/docker-for-windows/install/)

## Installation and setup

For Docker installation, review the information at [Docker for Windows: What to know before you install](https://docs.docker.com/docker-for-windows/install/#what-to-know-before-you-install) and install [Docker For Windows](https://docs.docker.com/docker-for-windows/install/).

**[Shared Drives](https://docs.docker.com/docker-for-windows/#shared-drives)** in Docker for Windows must be configured to support volume mapping and debugging. Right-click the System Tray's Docker icon, select **Settings...**, and select **Shared Drives**. Select the drive where Docker stores files. Select **Apply**.

![Shared Drives](./visual-studio-tools-for-docker/_static/settings-shared-drives-win.png)

> [!TIP]
> Visual Studio 2017 versions 15.6 and later prompt when **Shared Drives** aren't configured.

## Add Docker support to an app

The ASP.NET Core project's target framework determines the supported container types. Projects targeting .NET Core support both Linux and Windows containers. Projects targeting .NET Framework only support Windows containers.

When adding Docker support to a project, choose either a Windows or a Linux container. The Docker host must be running the same container type. To change the container type in the running Docker instance, right-click the System Tray's Docker icon and choose **Switch to Windows containers...** or **Switch to Linux containers...**.

### New app

When creating a new app with the **ASP.NET Core Web Application** project templates, select the **Enable Docker Support** checkbox:

![Enable Docker Support checkbox](visual-studio-tools-for-docker/_static/enable-docker-support-checkbox.png)

If the target framework is .NET Core, the **OS** drop-down allows for the selection of a container type.

### Existing app

The Visual Studio Tools for Docker don't support adding Docker to an existing ASP.NET Core project targeting .NET Framework. For ASP.NET Core projects targeting .NET Core, there are two options for adding Docker support via the tooling. Open the project in Visual Studio, and choose one of the following options:

* Select **Docker Support** from the **Project** menu.
* Right-click the project in Solution Explorer and select **Add** > **Docker Support**.

## Docker assets overview

The Visual Studio Tools for Docker add a *docker-compose* project to the solution, containing the following:

* *.dockerignore*: Contains a list of file and directory patterns to exclude when generating a build context.
* *docker-compose.yml*: The base [Docker Compose](https://docs.docker.com/compose/overview/) file used to define the collection of images to be built and run with `docker-compose build` and `docker-compose run`, respectively.
* *docker-compose.override.yml*: An optional file, read by Docker Compose, containing configuration overrides for services. Visual Studio executes `docker-compose -f "docker-compose.yml" -f "docker-compose.override.yml"` to merge these files.

A *Dockerfile*, the recipe for creating a final Docker image, is added to the project root. Refer to [Dockerfile reference](https://docs.docker.com/engine/reference/builder/) for an understanding of the commands within it. This particular *Dockerfile* uses a [multi-stage build](https://docs.docker.com/engine/userguide/eng-image/multistage-build/) containing four distinct, named build stages:

[!code-text[](visual-studio-tools-for-docker/samples/HelloDockerTools/HelloDockerTools/Dockerfile?highlight=1,5,14,17)]

The *Dockerfile* is based on the [microsoft/aspnetcore](https://hub.docker.com/r/microsoft/aspnetcore) image. This base image includes the ASP.NET Core NuGet packages, which have been pre-jitted to improve startup performance.

The *docker-compose.yml* file contains the name of the image that is created when the project runs:

[!code-yaml[](visual-studio-tools-for-docker/samples/HelloDockerTools/docker-compose.yml?highlight=5)]

In the preceding example, `image: hellodockertools` generates the image `hellodockertools:dev` when the app runs in **Debug** mode. The `hellodockertools:latest` image is generated when the app runs in **Release** mode.

Prefix the image name with the [Docker Hub](https://hub.docker.com/) username (for example, `dockerhubusername/hellodockertools`) if the image will be pushed to the registry. Alternatively, change the image name to include the private registry URL (for example, `privateregistry.domain.com/hellodockertools`) depending on the configuration.

## Debug

Select **Docker** from the debug drop-down in the toolbar, and start debugging the app. The **Docker** view of the **Output** window shows the following actions taking place:

* The *microsoft/aspnetcore* runtime image is acquired (if not already in the cache).
* The *microsoft/aspnetcore-build* compile/publish image is acquired (if not already in the cache).
* The *ASPNETCORE_ENVIRONMENT* environment variable is set to `Development` within the container.
* Port 80 is exposed and mapped to a dynamically-assigned port for localhost. The port is determined by the Docker host and can be queried with the `docker ps` command.
* The app is copied to the container.
* The default browser is launched with the debugger attached to the container using the dynamically-assigned port. 

The resulting Docker image is the *dev* image of the app with the *microsoft/aspnetcore* images as the base image. Run the `docker images` command in the **Package Manager Console** (PMC) window. The images on the machine are displayed:

```console
REPOSITORY                   TAG                   IMAGE ID            CREATED             SIZE
hellodockertools             latest                f8f9d6c923e2        About an hour ago   391MB
hellodockertools             dev                   85c5ffee5258        About an hour ago   389MB
microsoft/aspnetcore-build   2.0-nanoserver-1709   d7cce94e3eb0        15 hours ago        1.86GB
microsoft/aspnetcore         2.0-nanoserver-1709   8872347d7e5d        40 hours ago        389MB
```

> [!NOTE]
> The dev image lacks the app contents, as **Debug** configurations use volume mounting to provide the iterative experience. To push an image, use the **Release** configuration.

Run the `docker ps` command in PMC. Notice the app is running using the container:

```console
CONTAINER ID        IMAGE                  COMMAND                   CREATED             STATUS              PORTS                   NAMES
baf9a678c88d        hellodockertools:dev   "C:\\remote_debugge..."   21 seconds ago      Up 19 seconds       0.0.0.0:37630->80/tcp   dockercompose4642749010770307127_hellodockertools_1
```

## Edit and continue

Changes to static files and Razor views are automatically updated without the need for a compilation step. Make the change, save, and refresh the browser to view the update.  

Modifications to code files requires compiling and a restart of Kestrel within the container. After making the change, use CTRL + F5 to perform the process and start the app within the container. The Docker container isn't rebuilt or stopped. Run the `docker ps` command in PMC. Notice the original container is still running as of 10 minutes ago:

```console
CONTAINER ID        IMAGE                  COMMAND                   CREATED             STATUS              PORTS                   NAMES
baf9a678c88d        hellodockertools:dev   "C:\\remote_debugge..."   10 minutes ago      Up 10 minutes       0.0.0.0:37630->80/tcp   dockercompose4642749010770307127_hellodockertools_1
```

## Publish Docker images

Once the develop and debug cycle of the app is completed, the Visual Studio Tools for Docker assist in creating the production image of the app. Change the configuration drop-down to **Release** and build the app. The tooling produces the image with the *latest* tag, which can be pushed to the private registry or Docker Hub. 

Run the `docker images` command in PMC to see the list of images:

```console
REPOSITORY                   TAG                   IMAGE ID            CREATED             SIZE
hellodockertools             latest                4cb1fca533f0        19 seconds ago      391MB
hellodockertools             dev                   85c5ffee5258        About an hour ago   389MB
microsoft/aspnetcore-build   2.0-nanoserver-1709   d7cce94e3eb0        16 hours ago        1.86GB
microsoft/aspnetcore         2.0-nanoserver-1709   8872347d7e5d        40 hours ago        389MB
```

> [!NOTE]
> The `docker images` command returns intermediary images with repository names and tags identified as *\<none>* (not listed above). These unnamed images are produced by the [multi-stage build](https://docs.docker.com/engine/userguide/eng-image/multistage-build/) *Dockerfile*. They improve the efficiency of building the final image&mdash;only the necessary layers are rebuilt when changes occur. When the intermediary images are no longer needed, delete them using the [docker rmi](https://docs.docker.com/engine/reference/commandline/rmi/) command.

There may be an expectation for the production or release image to be smaller in size by comparison to the *dev* image. Because of the volume mapping, the debugger and app were running from the local machine and not within the container. The *latest* image has packaged the necessary app code to run the app on a host machine. Therefore, the delta is the size of the app code.
