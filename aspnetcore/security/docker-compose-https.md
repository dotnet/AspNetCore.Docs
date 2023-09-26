---
title: Hosting ASP.NET Core image in container using docker compose with HTTPS
author: ravipal
description: Learn how to host ASP.NET Core Images with Docker Compose over HTTPS
monikerRange: '>= aspnetcore-2.1'
ms.author: riande
ms.custom: mvc
ms.date: 03/28/2020
uid: security/docker-compose-https
---
# Hosting ASP.NET Core images with Docker Compose over HTTPS

<!-- This topic drops loc for "Let's Encrypt" -->

ASP.NET Core uses [HTTPS by default](./enforcing-ssl.md). [HTTPS](https://en.wikipedia.org/wiki/HTTPS) relies on [certificates](https://en.wikipedia.org/wiki/Public_key_certificate) for trust, identity, and encryption.

This document explains how to run pre-built container images with HTTPS.

See [Developing ASP.NET Core Applications with Docker over HTTPS](https://github.com/dotnet/dotnet-docker/blob/main/samples/run-aspnetcore-https-development.md) for development scenarios.

This sample requires [Docker 17.06](https://docs.docker.com/release-notes/docker-ce) or later of the [Docker client](https://www.docker.com/products/docker).

## Prerequisites

The [.NET Core 2.2 SDK](https://dotnet.microsoft.com/download) or later is required for some of the instructions in this document.

## Certificates

A certificate from a [certificate authority](https://wikipedia.org/wiki/Certificate_authority) is required for [production hosting](https://blogs.msdn.microsoft.com/webdev/2017/11/29/configuring-https-in-asp-net-core-across-different-platforms/) for a domain. [:::no-loc text="Let's Encrypt":::](https://letsencrypt.org/) is a certificate authority that offers free certificates.

This document uses [self-signed development certificates](https://wikipedia.org/wiki/Self-signed_certificate) for hosting pre-built images over `localhost`. The instructions are similar to using production certificates.

For production certificates:

* The `dotnet dev-certs` tool is not required.
* Certificates don't need to be stored in the location used in the instructions. Store the certificates in any location outside the site directory.

The instructions contained in the following section volume mount certificates into containers using the `volumes` property in *docker-compose.yml.* You could add certificates into container images with a `COPY` command in a *Dockerfile*, but it's not recommended. Copying certificates into an image isn't recommended for the following reasons:

* It makes it difficult to use the same image for testing with developer certificates.
* It makes it difficult to use the same image for Hosting with production certificates.
* There is significant risk of certificate disclosure.

## Starting a container with https support using docker compose

Use the following instructions for your operating system configuration.

### Windows using Linux containers

Generate certificate and configure local machine:

```powershell
dotnet dev-certs https -ep "$env:USERPROFILE\.aspnet\https\aspnetapp.pfx"  -p $CREDENTIAL_PLACEHOLDER$
dotnet dev-certs https --trust
```

The previous command using the .NET CLI:

```dotnetcli
dotnet dev-certs https -ep %USERPROFILE%\.aspnet\https\aspnetapp.pfx -p $CREDENTIAL_PLACEHOLDER$
dotnet dev-certs https --trust
```

In the preceding commands, replace `$CREDENTIAL_PLACEHOLDER$` with a password.

Create a _docker-compose.debug.yml_ file with the following content:

```yaml
version: '3.4'

services:
  webapp:
    image: mcr.microsoft.com/dotnet/samples:aspnetapp
    ports:
      - 80
      - 443
    environment:
      - ASPNETCORE_ENVIRONMENT=Development
      - ASPNETCORE_URLS=https://+:443;http://+:80
      - ASPNETCORE_Kestrel__Certificates__Default__Password=password
      - ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx
    volumes:
      - ~/.aspnet/https:/https:ro
```
The password specified in the docker compose file must match the password used for the certificate.

Start the container with ASP.NET Core configured for HTTPS:

```console
docker-compose -f "docker-compose.debug.yml" up -d
```

### macOS or Linux

Generate certificate and configure local machine:

```dotnetcli
dotnet dev-certs https -ep ${HOME}/.aspnet/https/aspnetapp.pfx -p $CREDENTIAL_PLACEHOLDER$
dotnet dev-certs https --trust
```

`dotnet dev-certs https --trust` is only supported on macOS and Windows. You need to trust certificates on Linux in the way that is supported by your distribution. It is likely that you need to trust the certificate in your browser.

In the preceding commands, replace `$CREDENTIAL_PLACEHOLDER$` with a password.

Create a _docker-compose.debug.yml_ file with the following content:

```yaml
version: '3.4'

services:
  webapp:
    image: mcr.microsoft.com/dotnet/samples:aspnetapp
    ports:
      - 80
      - 443
    environment:
      - ASPNETCORE_ENVIRONMENT=Development
      - ASPNETCORE_URLS=https://+:443;http://+:80
      - ASPNETCORE_Kestrel__Certificates__Default__Password=password
      - ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx
    volumes:
      - ~/.aspnet/https:/https:ro
```
The password specified in the docker compose file must match the password used for the certificate.

Start the container with ASP.NET Core configured for HTTPS:

```console
docker-compose -f "docker-compose.debug.yml" up -d
```

### Windows using Windows containers

Generate certificate and configure local machine:

```dotnetcli
dotnet dev-certs https -ep %USERPROFILE%\.aspnet\https\aspnetapp.pfx -p $CREDENTIAL_PLACEHOLDER$
dotnet dev-certs https --trust
```

In the preceding commands, replace `$CREDENTIAL_PLACEHOLDER$` with a password.

Create a _docker-compose.debug.yml_ file with the following content:

```yaml
version: '3.4'

services:
  webapp:
    image: mcr.microsoft.com/dotnet/samples:aspnetapp
    ports:
      - 80
      - 443
    environment:
      - ASPNETCORE_ENVIRONMENT=Development
      - ASPNETCORE_URLS=https://+:443;http://+:80
      - ASPNETCORE_Kestrel__Certificates__Default__Password=password
      - ASPNETCORE_Kestrel__Certificates__Default__Path=C:\https\aspnetapp.pfx
    volumes:
      - ${USERPROFILE}\.aspnet\https:C:\https:ro
```
The password specified in the docker compose file must match the password used for the certificate.

Start the container with ASP.NET Core configured for HTTPS:

```console
docker-compose -f "docker-compose.debug.yml" up -d
```

## See also

* [`dotnet dev-certs`](/dotnet/core/tools/dotnet-dev-certs)
