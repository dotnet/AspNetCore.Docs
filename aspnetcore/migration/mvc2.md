# Migrating From ASP.NET to ASP.NET Core 2.0

By [Isaac Levin](https://isaaclevin.com)

This article acts as a reference guide for migrating ASP.NET Framework Applications (MVC or Web Api) to ASP.Net Core 2.0 (MVC or Web Api). Here you will find initial instructions helpful in moving your .Net proper applications to Core 2.0. Additional articles cover migrating configuration and identity code found in many ASP.NET MVC projects.

> [!IMPORTANT]
> This topic uses a Preview Version of Visual Studio in order to complete it's steps. Please ensure that you have installed [Visual Studio 2017 Preview version 15.3](https://www.visualstudio.com/vs/preview/) before preceeding.


## Key package changes
* Common assemblies and core equivalent (table or mapping diagram)
* Assemblies not supported in Core


## Net Standard
* Introduction to .Net Standard and what it looks like

## Project structure differences
* Changes to .csproj
* Middleware (App_Start/Global.asax vs Startup.cs)

## Storing Configurations
* Using appsettings.json vs Web.config sections

## DI first class citizen
* Code sample of built in DI

## Static file / wwwroot
* Adding assets and publishing through wwwroot
