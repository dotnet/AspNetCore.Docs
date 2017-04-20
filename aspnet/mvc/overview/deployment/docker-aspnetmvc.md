---
uid: mvc/overview/deployment/docker-aspnetmvc
title: Migrating ASP.NET MVC Applications to Windows Containers
description: Learn how to take an existing ASP.NET MVC application and run it in a Windows Docker Container
keywords: Windows Containers, Docker, ASP.NET MVC
author: BillWagner
ms.author: wiwagn
ms.date: 02/01/2017
ms.topic: article
ms.prod: .net-framework
ms.technology: dotnet-mvc
ms.devlang: dotnet
ms.assetid: c9f1d52c-b4bd-4b5d-b7f9-8f9ceaf778c4
uid: mvc/overview/deployment/docker
---
# Migrating ASP.NET MVC Applications to Windows Containers

Running an existing .NET Framework-based application in a Windows container doesn't require any changes to your app. To run your app in a Windows container you create a Docker image containing your app and
start the container. This topic explains
how to take an existing [ASP.NET MVC application](http://www.asp.net/mvc)
and deploy it in a Windows container.

You start with an existing ASP.NET MVC app, then build the published assets using Visual Studio. You use Docker
to create the image that contains and runs your app. You'll browse to the site running in a Windows container and verify the app is
working.

This article assumes a basic understanding of Docker. You can learn about Docker by reading the [Docker Overview](https://docs.docker.com/engine/understanding-docker/).

The app you'll run in a container is a simple website that
answers questions randomly. This app is a basic MVC application
with no authentication or database storage; it lets you focus
on moving the web tier to a container. Future topics will show how to
move and manage persistent storage in containerized applications.

Moving your application involves these steps:

1. [Creating a publish task to build the assets for an image.](#publish-script)
1. [Building a Docker image that will run your application.](#build-the-image)
1. [Starting a Docker container that runs your image.](#start-a-container)
1. [Verifying the application using your browser.](#verify-in-the-browser)

The [finished application](https://github.com/dotnet/docs/tree/master/samples/framework/docker/MVCRandomAnswerGenerator) is on GitHub.

## Prerequisites

The development machine must be running

- [Windows 10 Anniversary Update](https://www.microsoft.com/en-us/software-download/windows10/) (or higher) or [Windows Server 2016](https://www.microsoft.com/en-us/cloud-platform/windows-server) (or higher).
- [Docker for Windows](https://docs.docker.com/docker-for-windows/) - version Stable 1.13.0 or 1.12 Beta 26 (or newer versions)
- [Visual Studio 2017](https://www.visualstudio.com/en-us/visual-studio-homepage-vs.aspx).

> [!IMPORTANT]
> If you are using Windows Server 2016, follow the
> instructions for [Container Host Deployment - Windows Server](https://msdn.microsoft.com/virtualization/windowscontainers/deployment/deployment).

After installing and starting Docker,  right-click on the
tray icon and select **Switch to Windows containers**. This is required to run
Docker images based on Windows. This command takes a few seconds to
execute:

![Windows Container][windows-container]

## Publish script

Collect all the assets that you need to load into
a Docker image in one place. You can use the Visual Studio
**Publish** command to create a publish profile for your app. This
profile will put all the assets in one directory tree that you copy to your target image later in this tutorial.

**Publish Steps**

1. Right click on the web project in Visual Studio, and select **Publish**.
1. Click the **Custom profile button**, and then select **File System** as the method.
1. Choose the directory. By convention, the downloaded sample uses `bin\Release\PublishOutput`.

![Publish Connection][publish-connection]

Open the **File Publish Options** section of the **Settings** tab. Select
**Precompile during publishing**. This optimization means that you'll be
compiling views in the Docker container, you are copying the precompiled
views.

![Publish Settings][publish-settings]

Click **Publish**, and Visual Studio will copy all the needed assets to the destination folder.

## Build the image

Define your Docker image in a Dockerfile. The Dockerfile contains instructions
for the base image, additional components, the app you
want to run, and other configuration images.  The Dockerfile is the input
to the `docker build` command, which creates the image.

You will build an image based on the `microsft/aspnet`
image located on [Docker Hub](https://hub.docker.com/r/microsoft/aspnet/).
The base image, `microsoft/aspnet`, is a Windows Server image. It contains
Windows Server Core, IIS and ASP.NET 4.6.2. When you run this image in your container, it will
automatically start IIS and installed websites.

The Dockerfile that creates your image looks like this:

```console
# The `FROM` instruction specifies the base image. You are
# extending the `microsoft/aspnet` image.

FROM microsoft/aspnet

# The final instruction copies the site you published earlier into the container.
COPY ./bin/Release/PublishOutput/ /inetpub/wwwroot
```

There is no `ENTRYPOINT` command in this Dockerfile. You don't need one. When running Windows Server with IIS, the IIS process is the entrypoint, which is configured to start in the aspnet base image.

Run the Docker build command to create the image that
runs your ASP.NET app. To do this, open a PowerShell
window in the directory of your project and type the following command in the solution directory:

```console
docker build -t mvcrandomanswers .
```

This command will build the new image using the instructions in your
Dockerfile, naming (-t tagging) the image as mvcrandomanswers. This may include pulling the base image from [Docker Hub](http://hub.docker.com),
and then adding your app to that image.

Once that command completes, you can run the `docker images` command
to see information on the new image:

```console
REPOSITORY                    TAG                 IMAGE ID            CREATED             SIZE
mvcrandomanswers              latest              86838648aab6        2 minutes ago       10.1 GB
```

The IMAGE ID will be different on your machine. Now, let's run the app.

## Start a container

Start a container by executing the following `docker run` command:

```console
docker run -d --name randomanswers mvcrandomanswers
```

The `-d` argument tells Docker to start the image in detached mode. That
means the Docker image runs disconnected from the current shell.

In many docker examples, you may see -p to map the container and host ports. The default aspnet image has already configured the container to listen on port 80 and expose it. 

The `--name randomanswers` gives a name to the running container. You can use
this name instead of the container ID in most commands.

The `mvcrandomanswers` is the name of the image to start.

## Verify in the browser

> [!NOTE]
> With the current Windows Container release, you can't browse to `http://localhost`.
> This is a known behavior in WinNAT, and it will
> be resolved in the future. Until that is addressed, you need to use
> the IP address of the container.

Once the container starts, find its IP address so that you
can connect to your running container from a browser:

```console
docker inspect -f "{{ .NetworkSettings.Networks.nat.IPAddress }}" randomanswers
172.31.194.61
```

Connect to the running container using the IPv4 address, `http://172.31.194.61`
in the example shown. Type that URL into your browser, and you should see the running site.

> [!NOTE]
> Some VPN or proxy software may prevent you from navigating to your site.
> You can temporarily disable it to make sure your container is working.

The sample directory on GitHub contains a [PowerShell script](https://github.com/dotnet/docs/tree/master/samples/framework/docker/MVCRandomAnswerGenerator/run.ps1) that executes these commands for you. Open a PowerShell window, change directory to your solution directory, and type:

```console
./run.ps1
```

The command above builds the image, displays the list of images on your machine, starts a container, and displays the IP address for that container.

To stop your container, issue a `docker
stop` command:

```console
docker stop randomanswers
```

To remove the container, issue a `docker rm` command:

```console
docker rm randomanswers
```

[windows-container]: media/aspnetmvc/SwitchContainer.png "Switch to Windows Container"
[publish-connection]: media/aspnetmvc/PublishConnection.png "Publish to File System"
[publish-settings]: media/aspnetmvc/PublishSettings.png "Publish Settings"
