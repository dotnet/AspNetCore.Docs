---
title: Docker images overview
author: tdykstra
description: Learn how to use the published .NET Core Docker images from the Docker Registry. Pull images and build your own images.
ms.author: tdykstra
ms.custom: mvc
ms.date: 04/09/2019
---

# Learn about Docker images for .NET Core

This tutorial shows how to use ASP.NET Core on Docker. It begins with a survey of the different Docker images offered and maintained by Microsoft. Then you build and dockerize an ASP.NET Core app.

In this tutorial, you:
> [!div class="checklist"]
> * Learn about Microsoft .NET Core Docker images 
> * Get an ASP.NET Core sample app to dockerize
> * Run the ASP.NET Core sample app locally
> * Build and run the sample with Docker for Linux containers
> * Build and run the sample with Docker for Windows containers

## Docker Image Optimizations

When building Docker images for developers, we focused on three main scenarios:

* Images used to develop .NET Core apps
* Images used to build .NET Core apps
* Images used to run .NET Core apps

Why three images?
When developing, building, and running containerized applications, we have different priorities.

* **Development:**  The priority focuses on quickly iterate changes, and the ability to debug the changes. The size of the image isn't as important, rather can you make changes to your code and see them quickly?

* **Build:** This image contains everything needed to compile your app, which includes the compiler and any other dependencies to optimize the binaries.  You use the build image to create the assets you place into a production image. The build image would be used for continuous integration, or in a build environment. This approach allows a build agent to compile and build the application (with all the required dependencies) in a build image instance. Your build agent only needs to know how to run this Docker image.

* **Production:** How fast you can deploy and start your image? This image is small so network performance from your Docker Registry to your Docker hosts is optimized. The contents are ready to run enabling the fastest time from Docker run to processing results. Dynamic code compilation isn't needed in the Docker model. The content you place in this image would be limited to the binaries and content needed to run the application.

    For example, the `dotnet publish` output contains:

    * the compiled binaries
    * .js and .css files


The reason to include the `dotnet publish` command output in your production image is to keep its size to a minimum.

Some .NET Core images share layers between different tags so downloading the latest tag is a relatively lightweight process. If you already have an older version on your machine, this architecture decreases the needed disk space.

When multiple applications use common images on the same machine, memory is shared between the common images. The images must be the same to be shared.

## Docker image variations

To achieve the goals above, we provide image variants under [`microsoft/dotnet`](https://hub.docker.com/r/microsoft/dotnet/).

* `microsoft/dotnet:<version>-sdk`(`microsoft/dotnet:2.1-sdk`) This image contains the .NET Core SDK, which includes the .NET Core and Command Line Tools (CLI). This image maps to the **development scenario**. You use this image for local development, debugging, and unit testing. This image can also be used for your **build** scenarios. Using `microsoft/dotnet:sdk` always gives you the latest version.

> [!TIP]
> If you are unsure about your needs, you want to use the `microsoft/dotnet:<version>-sdk` image. As the "de facto" image, it's designed to be used as a throw away container (mount your source code and start the container to start your app), and as the base image to build other images from.

* `microsoft/dotnet:<version>-runtime`: This image contains the .NET Core (runtime and libraries) and is optimized for running .NET Core apps in **production**.

## Alternative images

In addition to the optimized scenarios of development, build and production, we provide additional images:

* `microsoft/dotnet:<version>-runtime-deps`: The **runtime-deps** image contains the operating system with all of the native dependencies needed by .NET Core. This image is for [self-contained applications](../deploying/index.md).

Latest versions of each variant:

* `microsoft/dotnet` or `microsoft/dotnet:latest` (alias for the SDK image)
* `microsoft/dotnet:sdk`
* `microsoft/dotnet:runtime`
* `microsoft/dotnet:runtime-deps`

## Samples to explore

* [This ASP.NET Core Docker sample](https://github.com/dotnet/dotnet-docker/tree/master/samples/aspnetapp) demonstrates a best practice pattern for building Docker images for ASP.NET Core apps for production. The sample works with both Linux and Windows containers.

* This .NET Core Docker sample demonstrates a best practice pattern for [building Docker images for .NET Core apps for production.](https://github.com/dotnet/dotnet-docker/tree/master/samples/dotnetapp)

## Forward the request scheme and original IP address

Proxy servers, load balancers, and other network appliances often obscure information about a request before it reaches the containerized app:

* When HTTPS requests are proxied over HTTP, the original scheme (HTTPS) is lost and must be forwarded in a header.
* Because an app receives a request from the proxy and not its true source on the Internet or corporate network, the original client IP address must also be forwarded in a header.

This information may be important in request processing, for example in redirects, authentication, link generation, policy evaluation, and client geolocation.

To forward the scheme and original IP address to a containerized ASP.NET Core app, use Forwarded Headers Middleware. For more information, see [Configure ASP.NET Core to work with proxy servers and load balancers](/aspnet/core/host-and-deploy/proxy-load-balancer).

## Your first ASP.NET Core Docker app

For this tutorial, lets use an ASP.NET Core Docker sample application for the app we want to dockerize. This ASP.NET Core Docker sample application demonstrates a best practice pattern for building Docker images for ASP.NET Core apps for production. The sample works with both Linux and Windows containers.

The sample Dockerfile creates an ASP.NET Core application Docker image based off of the ASP.NET Core Runtime Docker base image.

It uses the [Docker multi-stage build feature](https://docs.docker.com/engine/userguide/eng-image/multistage-build/) to:

* build the sample in a container based on the **larger** ASP.NET Core Build Docker base image 
* copies the final build result into a Docker image based on the **smaller** ASP.NET Core Docker Runtime base image

> [!NOTE]
> The build image contains required tools to build applications while the runtime image does not.

### Prerequisites

To build and run, install the following items:

#### .NET Core 2.1 SDK

* Install [.NET Core 2.1 SDK](https://www.microsoft.com/net/core).

* Install your favorite code editor, if you haven't already.

> [!TIP]
> Need to install a code editor? Try [Visual Studio](https://visualstudio.com/downloads)!

#### Installing Docker Client

Install [Docker 18.03](https://docs.docker.com/release-notes/docker-ce/) or later of the Docker client.

The Docker client can be installed in:

* Linux distributions

   * [CentOS](https://docs.docker.com/install/linux/docker-ce/centos/)

   * [Debian](https://docs.docker.com/install/linux/docker-ce/debian/)

   * [Fedora](https://docs.docker.com/install/linux/docker-ce/fedora/)

   * [Ubuntu](https://docs.docker.com/install/linux/docker-ce/ubuntu/)

* [macOS](https://docs.docker.com/docker-for-mac/install/)

* [Windows](https://docs.docker.com/docker-for-windows/install/).

#### Installing Git for sample repository

* Install [git](https://git-scm.com/download) if you wish to clone the repository.

### Getting the sample application

The easiest way to get the sample is by cloning the [.NET Core Docker repository](https://github.com/dotnet/dotnet-docker) with git, using the following instructions: 

```console
git clone https://github.com/dotnet/dotnet-docker
```

You can also download the repository (it is small) as a zip from the .NET Core Docker repository.

### Run the ASP.NET app locally

For a reference point, before we containerize the application, first run the application locally.

You can build and run the application locally with the .NET Core 2.1 SDK using the following commands (The instructions assume the root of the repository):

```console
cd dotnet-docker
cd samples
cd aspnetapp // solution scope where the dockerfile is located
cd aspnetapp // project scope

dotnet run
```

After the application starts, visit **http://localhost:5000** in your web browser.

### Build and run the sample with Docker for Linux containers

You can build and run the sample in Docker using Linux containers using the following commands (The instructions assume the root of the repository):

```console
cd dotnet-docker
cd samples
cd aspnetapp // solution scope where the dockerfile is located

docker build -t aspnetapp .
docker run -it --rm -p 5000:80 --name aspnetcore_sample aspnetapp
```

> [!NOTE]
> The `docker run` '-p' argument maps port 5000 on your local machine to port 80 in the container (the port mapping form is `host:container`). For more information, see the [docker run](https://docs.docker.com/engine/reference/commandline/exec/) reference on command-line parameters.

After the application starts, visit **http://localhost:5000** in your web browser.

### Build and run the sample with Docker for Windows containers

You can build and run the sample in Docker using Windows containers using the following commands (The instructions assume the root of the repository):

```console
cd dotnet-docker
cd samples
cd aspnetapp // solution scope where the dockerfile is located

docker build -t aspnetapp .
docker run -it --rm --name aspnetcore_sample aspnetapp
```

> [!IMPORTANT]
> You must navigate to the **container IP address** (as opposed to `http://localhost`) in your browser directly when using Windows containers. You can get the IP address of your container with the following steps:

* Open up another command prompt.
* Run `docker ps` to see your running containers. The "aspnetcore_sample" container should be there.
* Run `docker exec aspnetcore_sample ipconfig`.
* Copy the container IP address and paste into your browser (for example, 172.29.245.43).

> [!NOTE]
> Docker exec supports identifying containers with name or hash. The name (aspnetcore_sample) is used in our example.

See the following example of how to get the IP address of a running Windows container.

```console
docker exec aspnetcore_sample ipconfig

Windows IP Configuration

Ethernet adapter Ethernet:

   Connection-specific DNS Suffix  . : contoso.com
   Link-local IPv6 Address . . . . . : fe80::1967:6598:124:cfa3%4
   IPv4 Address. . . . . . . . . . . : 172.29.245.43
   Subnet Mask . . . . . . . . . . . : 255.255.240.0
   Default Gateway . . . . . . . . . : 172.29.240.1
```

> [!NOTE]
> Docker exec runs a new command in a running container. For more information, see the [docker exec reference](https://docs.docker.com/engine/reference/commandline/exec/) on command-line parameters.

You can produce an application that is ready to deploy to production locally using the [dotnet publish](../tools/dotnet-publish.md) command.

```console
dotnet publish -c Release -o published
```

> [!NOTE]
> The -c Release argument builds the application in release mode (the default is debug mode). For more information, see the [dotnet run reference](../tools/dotnet-run.md) on command-line parameters.

You can run the application on **Windows** using the following command.

```console
dotnet published\aspnetapp.dll
```

You can run the application on **Linux** or **macOS** using the following command.

```bash
dotnet published/aspnetapp.dll
```

### Docker Images used in this sample

The following Docker images are used in this sample's dockerfile.

* `microsoft/dotnet:2.1-sdk`
* `microsoft/dotnet:2.1-aspnetcore-runtime`

Congratulations! you have just:
> [!div class="checklist"]
> * Learned about Microsoft .NET Core Docker images
> * Got an ASP.NET Core sample app to Dockerize
> * Ran the ASP.NET sample app locally
> * Built and ran the sample with Docker for Linux containers
> * Built and ran the sample with Docker for Windows containers

**Next Steps**

Here are some next steps you can take:

* [Working with Visual Studio Docker Tools](https://docs.microsoft.com/aspnet/core/publishing/visual-studio-tools-for-docker)
* [Deploying Docker Images from the Azure Container Registry to Azure Container Instances](https://blogs.msdn.microsoft.com/stevelasker/2017/07/28/deploying-docker-images-from-the-azure-container-registry-to-azure-container-instances/)
* [Debugging with Visual Studio Code](https://code.visualstudio.com/docs/nodejs/debugging-recipes#_nodejs-typescript-docker-container) 
* [Getting hands on with Visual Studio for Mac, containers, and serverless code in the cloud](https://blogs.msdn.microsoft.com/visualstudio/2017/08/31/hands-on-with-visual-studio-for-mac-containers-serverless-code-in-the-cloud/#comments)
* [Getting Started with Docker and Visual Studio for Mac Lab](https://github.com/Microsoft/vs4mac-labs/tree/master/Docker/Getting-Started)

> [!NOTE]
> If you do not have an Azure subscription, [sign up today](https://azure.microsoft.com/free/?b=16.48) for a free 30-day account and get $200 in Azure Credits to try out any combination of Azure services.