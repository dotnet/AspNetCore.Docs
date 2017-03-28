---
uid: web-forms/overview/moving-to-aspnet-20/configuration-and-instrumentation
title: "Configuration and Instrumentation | Microsoft Docs"
author: microsoft
description: "There are major changes in configuration and instrumentation in ASP.NET 2.0. The new ASP.NET configuration API allows for configuration changes to be made pr..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 02/20/2005
ms.topic: article
ms.assetid: 21ebbaee-7ed8-45ae-b6c1-c27c88342e48
ms.technology: dotnet-webforms
ms.prod: .net-framework
msc.legacyurl: /web-forms/overview/moving-to-aspnet-20/configuration-and-instrumentation
msc.type: authoredcontent
---
Configuration and Instrumentation
====================
by [Microsoft](https://github.com/microsoft)

> There are major changes in configuration and instrumentation in ASP.NET 2.0. The new ASP.NET configuration API allows for configuration changes to be made programmatically. In addition, many new configuration settings exist allow for new configurations and instrumentation.


There are major changes in configuration and instrumentation in ASP.NET 2.0. The new ASP.NET configuration API allows for configuration changes to be made programmatically. In addition, many new configuration settings exist allow for new configurations and instrumentation.

In this module, we will discuss ASP.NET the configuration API as it relates to reading from and writing to ASP.NET configuration files, and we will also cover ASP.NET instrumentation. We will also cover the new features available in ASP.NET tracing.

## ASP.NET Configuration API

The ASP.NET configuration API allows you to develop, deploy, and manage application configuration data by using a single programming interface. You can use the configuration API to develop and modify complete ASP.NET configurations programmatically without directly editing the XML in the configuration files. In addition, you can use the configuration API in console applications and scripts that you develop, in Web-based management tools, and in Microsoft Management Console (MMC) snap-ins.

The following two configuration-management tools use the configuration API and are included with the .NET Framework version 2.0:

- The ASP.NET MMC snap-in, which uses the configuration API to simplify administrative tasks, providing an integrated view of local configuration data from all levels of the configuration hierarchy.
- The Web Site Administration Tool, which allows you to manage configuration settings for local and remote applications, including hosted sites.

The ASP.NET configuration API comprises a set of ASP.NET management objects that you can use to configure Web sites and applications programmatically. Management objects are implemented as a .NET Framework class library. The configuration API programming model helps ensure code consistency and reliability by enforcing data types at compile time. To make it easier to manage application configurations, the configuration API allows you to view data that is merged from all points in the configuration hierarchy as a single collection, instead of viewing the data as separate collections from different configuration files. Additionally, the configuration API enables you to manipulate entire application configurations without directly editing the XML in the configuration files. Finally, the API simplifies configuration tasks by supporting administrative tools, such as the Web Site Administration Tool. The configuration API simplifies deployment by supporting the creation of configuration files on a computer and running configuration scripts across multiple computers.

> [!NOTE]
> The configuration API does not support the creation of IIS applications.


## Working with Local and Remote Configuration Settings

A Configuration object represents the merged view of the configuration settings that apply to a specific physical entity, such as a computer, or to a logical entity, such as an application or a Web site. The specified logical entity can exist on the local computer or on a remote server. When no configuration file exists for a specified entity, the Configuration object represents the default configuration settings as defined by the Machine.config file.

You can get a Configuration object by using one of the open configuration methods from the following classes:

1. The ConfigurationManager class, if your entity is a client application.
2. The WebConfigurationManager class, if your entity is a Web application.

These methods will return a Configuration object, which in turn provides the required methods and properties to handle the underlying configuration files. You can access these files for reading or writing.

### Reading

You use the GetSection or GetSectionGroup method to read configuration information. The user or process that reads must have Read permissions on all of the configuration files in the hierarchy.

> [!NOTE]
> If you use a static GetSection method that takes a path parameter, the path parameter must refer to the application in which the code is running. Otherwise, the parameter is ignored and the configuration information for the currently running application is returned.


### Writing

You use one of the Save methods to write configuration information. The user or process that writes must have Write permissions on the configuration file and directory at the current configuration hierarchy level, as well as Read permissions on all of the configuration files in the hierarchy.

To generate a configuration file that represents the inherited configuration settings for a specified entity, use one of the following save-configuration methods:

1. The Save method to create a new configuration file.
2. The SaveAs method to generate a new configuration file at another location.

## Configuration Classes and Namespaces

Many configuration classes and methods are similar to each other. The following table describes the most commonly used configuration classes and namespaces.

| **Configuration class or namespace** | **Description** |
| --- | --- |
| [System.Configuration](https://msdn.microsoft.com/en-us/library/system.configuration.aspx) namespace | Contains the main configuration classes for all .NET Framework applications. Section handler classes are used to obtain configuration data for a section from methods, such as GetSection and GetSectionGroup. These two methods are non-static. |
| System.Configuration.Configuration class | Represents a set of configuration data for a computer, application, Web directory, or other resource. This class contains useful methods, such as GetSection and GetSectionGroup, for updating configuration settings and obtaining references to sections and section groups. This class is used as a return type for methods that obtain design-time configuration data, such as the methods of the WebConfigurationManager and ConfigurationManager classes. |
| System.Web.Configuration namespace | Contains the section handler classes for the ASP.NET configuration sections defined at [ASP.NET Configuration Settings](https://msdn.microsoft.com/en-us/library/b5ysx397.aspx). Section handler classes are used to obtain configuration data for a section from methods, such as GetSection and GetSectionGroup. |
| System.Web.Configuration.WebConfigurationManager class | Provides useful methods for obtaining references to run-time and design-time configuration settings. These methods use the System.Configuration.Configuration class as a return type. You can use the static GetSection method of this class or the non-static GetSection method of the System.Configuration.ConfigurationManager class interchangeably. For Web application configurations, the System.Web.Configuration.WebConfigurationManager class is recommended instead of the System.Configuration.ConfigurationManager class. |
| [System.Configuration.Provider](https://msdn.microsoft.com/en-us/library/system.configuration.provider.aspx) namespace | Provides a way to customize and extend the configuration provider. This is the base class for all provider classes in the configuration system. |
| [System.Web.Management](https://msdn.microsoft.com/en-us/library/system.web.management.aspx) namespace | Contains classes and interfaces for managing and monitoring the health of Web applications. Strictly speaking, this namespace is not considered part of the configuration API. For example, tracing and event firing is accomplished by the classes in this namespace. |
| [System.Management.Instrumentation](https://msdn.microsoft.com/en-us/library/system.management.instrumentation.aspx) namespace | Provides the classes necessary for the instrumentation of applications to expose their management information and events through Windows Management Instrumentation (WMI) to potential consumers. ASP.NET health monitoring uses WMI to deliver events. Strictly speaking, this namespace is not considered part of the configuration API. |

## Reading from ASP.NET Configuration Files

The WebConfigurationManager class is the core class for reading from ASP.NET configuration files. There are essentially three steps to reading ASP.NET configuration files:

1. Get a Configuration object using the OpenWebConfiguration method.
2. Get a reference to the desired section in the configuration file.
3. Read the desired information from the configuration file.

The Configuration object represents does not represent a particular configuration file. Instead, it represents a merged view of the configuration of a computer, application, or Web site. The following code sample instantiates a Configuration object representing the configuration of a Web application called *ProductInfo*.

[!code-csharp[Main](configuration-and-instrumentation/samples/sample1.cs)]

> [!NOTE]
> Note that if the /ProductInfo path doesn't exist, the above code will return the default configuration as specified in the machine.config file.


Once you have the Configuration object, you can then use the GetSection or GetSectionGroup method to drill into the configuration settings. The following example gets a reference to the impersonation settings for the above ProductInfo application:

[!code-csharp[Main](configuration-and-instrumentation/samples/sample2.cs)]

## Writing to ASP.NET Configuration Files

As in reading from configuration files, the WebConfigurationManager class is the core for writing to Asp.NET configuration files. There are also three steps to writing to ASP.NET configuration files.

1. Get a Configuration object using the OpenWebConfiguration method.
2. Get a reference to the desired section in the configuration file.
3. Write the desired information from the configuration file using the Save or SaveAs method.

The following code changes the **debug** attribute of the &lt;compilation&gt; element to false:

[!code-csharp[Main](configuration-and-instrumentation/samples/sample3.cs)]

When this code is executed, the **debug** attribute of the &lt;compilation&gt; element will be set to false for the *webApp* application's web.config file.

## System.Web.Management Namespace

The System.Web.Management namespace provides the classes and interfaces for managing and monitoring the health of ASP.NET applications.

Logging is accomplished by defining a rule that associates events with a provider. The rule defines the type of events that are sent to the provider. The following base events are available for you to log:

| **WebBaseEvent** | The base event class for all events. Contains the required properties for all events such as event code, event detail code, the date and time the event was raised, sequence number, the event message, and event details. |
| --- | --- |
| **WebManagementEvent** | The base event class for management events, such as application lifetime, request, error, and audit events. |
| **WebHeartbeatEvent** | The event generated by the application in regular intervals to capture useful runtime state information. |
| **WebAuditEvent** | The base class for security audit events, which are used to mark conditions such as authorization failure, decryption failure, *etc.* |
| **WebRequestEvent** | The base class for all informational request events. |
| **WebBaseErrorEvent** | The base class for all events indicating error conditions. |

The types of providers available allow you to send event output to Event Viewer, SQL Server, Windows Management Instrumentation (WMI), and e-mail. The pre-configured providers and event mappings reduce the amount of work necessary to get event output logged.

ASP.NET 2.0 uses the Event Log provider out-of-the-box to log events based on application domains starting and stopping, as well as logging any unhandled exceptions. This helps to cover some of the basic scenarios. For example, let's say that your application throws an exception, but the user doesn't save the error and you can't reproduce it. With the default Event Log rule, you would be able to gather the exception and stack information to get a better idea of what kind of error occurred. Another example applies if your application is losing session state. In that case, you can look in the Event Log to determine whether the application domain is recycling, and why the application domain stopped in the first place.

Also, the health monitoring system is extensible. For example, you can define custom Web events, fire them within your application, and then define a rule to send the event information to a provider such as your e-mail. This allows you to easily tie your instrumentation to the health monitoring providers. As another example, you could fire an event each time an order is processed and set up a rule that sends each event to the SQL Server database. You could also fire an event when a user fails to log on multiple times in a row, and set up the event to use the e-mail-based providers.

The configuration for the default providers and events is stored in the global Web.config file. The global Web.config file stores all the Web-based settings that were stored in the Machine.config file in ASP.NET 1x. The global Web.config file is located in the following directory:

`%windir%\Microsoft.Net\Framework\v2.0.*\config\Web.config`

The &lt;healthMonitoring&gt; section of the global Web.config file provides default configuration settings. You can override these setting or configure your own settings by implementing the &lt;healthMonitoring&gt; section in the Web.config file for your application.

The &lt;healthMonitoring&gt; section of the global Web.config file contains the following items:

| **providers** | Contains providers set up for the Event Viewer, WMI, and SQL Server. |
| --- | --- |
| **eventMappings** | Contains mappings for the various WebBase classes. You can extend this list if you generate your own event class. Generating your own event class gives you finer granularity over the providers you send information to. For example, you could configure unhandled exceptions to be sent to SQL Server, while sending your own custom events to e-mail. |
| **rules** | Links the eventMappings to the provider. |
| **buffering** | Used with SQL Server and e-mail providers to determine how often to flush the events to the provider. |

Below is a code example from the global Web.config file.

[!code-xml[Main](configuration-and-instrumentation/samples/sample4.xml)]

## How to store events to Event Viewer

As mentioned earlier, the provider for logging events in the Event Viewer is configured for you in the global Web.config file. By default, all events based on **WebBaseErrorEvent** and **WebFailureAuditEvent** are logged. You can add additional rules to log additional information to the Event Log. For example, if you wanted to log all events (*i.e.*, every event based on **WebBaseEvent**), you could add the following rule to your Web.config file:

[!code-xml[Main](configuration-and-instrumentation/samples/sample5.xml)]

This rule would link the **All Events** event map to the Event Log provider. Both eventMapping and the provider are included in the global Web.config file.

## How to store events to SQL Server

This method uses the **ASPNETDB** database, which is generated by the Aspnet\_regsql.exe tool. The default provider uses the LocalSqlServer connection string, which uses either a file-based database in the App\_data folder or the local SQLExpress instance of SQL Server. Both the LocalSqlServer connection string and the SqlProvider are configured in the global Web.config file.

The LocalSqlServer connection string in the global Web.config file looks like this:

[!code-xml[Main](configuration-and-instrumentation/samples/sample6.xml)]

If you want to use another SQL Server instance, you'll need to use the Aspnet\_regsql.exe tool, which can be found in the %windir%\Microsoft.Net\Framework\v2.0.\* folder. Use the Aspnet\_regsql.exe tool to generate a custom **ASPNETDB** database on the SQL Server instance, then add the connection string to your applications configuration file, and then add a provider by using the new connection string. Once you have the **ASPNETDB** database created, you'll need to set a rule to link an eventMapping to the sqlProvider.

Whether you use the default SqlProvider or configure your own provider, you'll need to add a rule linking the provider with an event map. The following rule links the new provider that you created above to the **All Events** event map. This rule will log all the events based on **WebBaseEvent** and send them to the MySqlWebEventProvider that will use the MYASPNETDB connection string. The following code adds a rule to link the provider with an event map:

[!code-xml[Main](configuration-and-instrumentation/samples/sample7.xml)]

If you wanted to only send errors to SQL Server, you could add the following rule:

[!code-xml[Main](configuration-and-instrumentation/samples/sample8.xml)]

## How to forward events to WMI

You can also forward the events to WMI. The WMI provider is configured for you in the global Web.config file by default.

The following code example adds a rule to forward the events to WMI:

[!code-xml[Main](configuration-and-instrumentation/samples/sample9.xml)]

You will need to add a rule to associate an eventMapping to the provider, and also a WMI listener application to listen for the events. The following code example adds a rule to link the WMI provider to the **All Events** event map:

[!code-xml[Main](configuration-and-instrumentation/samples/sample10.xml)]

## How to forward events to e-mail

You can also forward events to e-mail. Be careful about which event rules you map to your e-mail provider, as you can unintentionally send yourself a lot of information that may be better suited for SQL Server or the Event Log. There are two e-mail providers; SimpleMailWebEventProvider and TemplatedMailWebEventProvider. Each has the same configuration attributes, with the exception of the "template" and "detailedTemplateErrors" attributes, both of which are only available on the TemplatedMailWebEventProvider.

> [!NOTE]
> Neither of these e-mail providers is configured for you. You'll need to add them to your Web.config file.


The main difference between these two e-mail providers is that SimpleMailWebEventProvider sends e-mails in a generic template that cannot be modified. The sample Web.config file adds this e-mail provider to the list of configured providers by using the following rule:

[!code-xml[Main](configuration-and-instrumentation/samples/sample11.xml)]

The following rule is also added to tie the e-mail provider to the **All Events** event map:

[!code-xml[Main](configuration-and-instrumentation/samples/sample12.xml)]

## ASP.NET 2.0 Tracing

There are three major enhancements to tracing in ASP.NET 2.0.

1. Integrated tracing functionality
2. Programmatic access to trace messages
3. Improved application-level tracing

## Integrated Tracing Functionality

You can now route messages emitted by the System.Diagnostics.Trace class to ASP.NET tracing output, and route messages emitted by ASP.NET tracing to System.Diagnostics.Trace. You can also forward ASP.NET instrumentation events to System.Diagnostics.Trace. This functionality is provided by the new **writeToDiagnosticsTrace** attribute of the &lt;trace&gt; element. When this Boolean value is true, ASP.NET Trace messages are forwarded to the System.Diagnostics tracing infrastructure for use by any listeners that are registered to display Trace messages.

## Programmatic Access to Trace Messages

ASP.NET 2.0 allows for programmatic access to all trace messages via the **TraceContextRecord** class and the **TraceRecords** collection. The most efficient way of accessing trace messages is to register a **TraceContextEventHandler** delegate (also new in ASP.NET 2.0) to handle the new **TraceFinished** event. You can then loop through the trace messages as you wish.

The following code sample illustrates this:

[!code-csharp[Main](configuration-and-instrumentation/samples/sample13.cs)]

In the above example, I loop through the TraceRecords collection and then write each message to the Response stream.

## Improved Application-Level Tracing

Application-level tracing is improved via the introduction of the new **mostRecent** attribute of the &lt;trace&gt; element. This attribute specifies whether the most recent application-level tracing output is displayed and older trace data beyond the limits that are indicated by the requestLimit are discarded. If false, trace data are displayed for requests until the requestLimit attribute is reached.

## ASP.NET Command Line Tools

There are several command-line tools to aid in configuration of ASP.NET. ASP.NET developers should be familiar with the aspnet\_regiis.exe tool. ASP.NET 2.0 provides three other command-line tools to aid in configuration.

The following command-line tools are available:

| **Tool** | **Use** |
| --- | --- |
| **aspnet\_regiis.exe** | Allows for registration of ASP.NET with IIS. There are two versions of this tools that ship with ASP.NET 2.0, one for 32-bit systems (in the Framework folder) and one for 64-bit systems (in the Framework64 folder.) The 64-bit version will not be installed on a 32-bit OS. |
| **aspnet\_regsql.exe** | The ASP.NET SQL Server Registration tool is used to create a Microsoft SQL Server database for use by the SQL Server providers in ASP.NET, or to add or remove options from an existing database. The Aspnet\_regsql.exe file is located in the [drive:]\WINDOWS\Microsoft.NET\Framework\versionNumber folder on your Web server. |
| **aspnet\_regbrowsers.exe** | The ASP.NET Browser Registration tool parses and compiles all system-wide browser definitions into an assembly and installs the assembly into the global assembly cache. The tool uses the browser definition files (.BROWSER files) from the .NET Framework Browsers subdirectory. The tool can be found in the %SystemRoot%\Microsoft.NET\Framework\version\ directory. |
| **aspnet\_compiler.exe** | The ASP.NET Compilation tool enables you to compile an ASP.NET Web application, either in place or for deployment to a target location such as a production server. In-place compilation helps application performance because end users do not encounter a delay on the first request to the application while the application is compiled. |

Because the aspnet\_regiis.exe tool is not new to ASP.NET 2.0, we will not discuss it here.

## ASP.NET SQL Server Registration Tool - aspnet\_regsql.exe

You can set several types of options using the ASP.NET SQL Server Registration tool. You can specify a SQL connection, specify which ASP.NET application services use SQL Server to manage information, indicate which database or table is used for SQL cache dependency, and add or remove support for using SQL Server to store procedures and session state.

Several ASP.NET application services rely on a provider to manage storing and retrieving data from a data source. Each provider is specific to the data source. ASP.NET includes a SQL Server provider for the following ASP.NET features:

- Membership (the [SqlMembershipProvider](https://msdn.microsoft.com/en-us/library/system.web.security.sqlmembershipprovider.aspx) class).
- Role Management (the [SqlRoleProvider](https://msdn.microsoft.com/en-us/library/system.web.security.sqlroleprovider.aspx) class).
- Profile (the [SqlProfileProvider](https://msdn.microsoft.com/en-us/library/system.web.profile.sqlprofileprovider.aspx) class).
- Web Parts Personalization (the [SqlPersonalizationProvider](https://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.webparts.sqlpersonalizationprovider.aspx) class).
- Web Events (the [SqlWebEventProvider](https://msdn.microsoft.com/en-us/library/system.web.management.sqlwebeventprovider.aspx) class).

When you install ASP.NET, the Machine.config file for your server includes configuration elements that specify SQL Server providers for each of the ASP.NET features that rely on a provider. These providers are configured, by default, to connect to a local user instance of SQL Server Express 2005. If you change the default connection string used by the providers, then before you can use any of the ASP.NET features configured in the machine configuration, you must install the SQL Server database and the database elements for your chosen feature using Aspnet\_regsql.exe. If the database that you specify with the SQL registration tool does not already exist (aspnetdb will be the default database if one is not specified on the command line), then the current user must have rights to create databases in SQL Server as well as to create schema elements within a database.

### SQL Cache Dependency

An advanced feature of ASP.NET output caching is SQL cache dependency. SQL cache dependency supports two different modes of operation: one that uses an ASP.NET implementation of table polling and a second mode that uses the query notification features of SQL Server 2005. The SQL registration tool can be used to configure the table-polling mode of operation.

### Session State

By default, session state values and information are stored in memory within the ASP.NET process. Alternatively, you can store session data in a SQL Server database, where it can be shared by multiple Web servers. If the database that you specify for session state with the SQL registration tool does not already exist, then the current user must have rights to create databases in SQL Server as well as to create schema elements within a database. If the database does exist, then the current user must have rights to create schema elements in the existing database.

To install the session state database on SQL Server, run the Aspnet\_regsql.exe tool and supply the following information with the command:

- The name of the SQL Server instance, using the **-S** option.
- The logon credentials for an account that has permission to create a database on a computer running SQL Server. Use the **-E** option to use the currently logged-on user, or use the **-U** option to specify a user ID along with the **-P** option to specify a password.
- The **-ssadd** command-line option to add the session state database.

By default, you cannot use the Aspnet\_regsql.exe tool to install the session state database on a computer running SQL Server 2005 Express Edition.

### The ASP.NET Browser Registration Tool - aspnet\_regbrowsers.exe

In ASP.NET version 1.1, the Machine.config file contained a section called &lt;browserCaps&gt;. This section contained a series of XML entries that defined the configurations for various browsers based on a regular expression. For ASP.NET version 2.0, a new .BROWSER file defines the parameters of a particular browser using XML entries. You add information on a new browser by adding a new .BROWSER file to the folder located at %SystemRoot%\Microsoft.NET\Framework\version\CONFIG\Browsers on your system.

Because an application is not reading a .config file every time it requires browser information, you can create a new .BROWSER file and run Aspnet\_regbrowsers.exe to add the required changes to the assembly. This allows the server to access the new browser information immediately so you do not have to shut down any of your applications to pick up the information. An application can access browser capabilities through the Browser property of the current HttpRequest.

The following options are available when running aspnet\_regbrowser.exe:

| **Option** | **Description** |
| --- | --- |
| **-?** | Displays the Aspnet\_regbbrowsers.exe Help text in the command window. |
| **-i** | Creates the runtime browser capabilities assembly and installs it in the global assembly cache. |
| **-u** | Uninstalls the runtime browser capabilities assembly from the global assembly cache. |

## The ASP.NET Compilation Tool - aspnet\_compiler.exe

The ASP.NET Compilation tool can be used in two general ways: for in-place compilation and compilation for deployment, where a target output directory is specified.

### [Compiling an Application in Place](https://msdn.microsoft.com/en-us/library/ms229863.aspx)

The ASP.NET Compilation tool can compile an application in place, that is, it mimics the behavior of making multiple requests to the application, thus causing regular compilation. Users of a pre-compiled site will not experience a delay caused by compiling the page on first request.

When you precompile a site in place, the following items apply:

- The site retains its files and directory structure.
- You must have compilers for all programming languages used by the site on the server.
- If any file fails compilation, the entire site fails compilation.

You can also recompile an application in place after adding new source files to it. The tool compiles only the new or changed files unless you include the **-c** option.

> [!NOTE]
> Compilation of an application that contains a nested application does not compile the nested application. The nested application must be compiled separately.


### [Compiling an Application for Deployment](https://msdn.microsoft.com/en-us/library/ms229863.aspx)

You compile an application for deployment (compilation to a target location) by specifying the targetDir parameter. The targetDir can be the final location for the Web application, or the compiled application can be further deployed. Using the **-u** option compiles the application in such a way that you can make changes to certain files in the compiled application without recompiling it. Aspnet\_compiler.exe makes a distinction between static and dynamic file types, and handles them differently when creating the resulting application.

- Static file types are those that do not have an associated compiler or build provider, such as files whose named have extensions such as .css, .gif, .htm, .html, .jpg, .js and so on. These files are simply copied to the target location, with their relative places in the directory structure preserved.
- Dynamic file types are those that have an associated compiler or build provider, including files with ASP.NET-specific file name extensions such as .asax, .ascx, .ashx, .aspx, .browser, .master, and so on. The ASP.NET Compilation tool generates assemblies from these files. If the **-u** option is omitted, the tool also creates files with the file name extension .COMPILED that map the original source files to their assembly. To ensure that the directory structure of the application source is preserved, the tool generates placeholder files in the corresponding locations in the target application.

You must use the **-u** option to indicate that the content of the compiled application can be modified. Otherwise, subsequent modifications are ignored or cause run-time errors.

The following table describes how the ASP.NET Compilation tool handles different file types when the **-u** option is included.

| **File type** | **Compiler action** |
| --- | --- |
| .ascx, .aspx, .master | These files are split into markup and source code, which includes both code-behind files and any code that is enclosed in &lt;script runat="server"&gt; elements. Source code is compiled into assemblies, with names that are derived from a hashing algorithm, and the assemblies are placed in the Bin directory. Any inline code, that is, code enclosed between the **&lt;%** and **%&gt;** brackets, is included with markup and not compiled. New files with the same name as the source files are created to contain the markup and placed in the corresponding output directories. |
| .ashx, .asmx | These files are not compiled and are moved to the output directories as is and not compiled. If you wish to have the handler code compiled, place the code into source code files in the App\_Code directory. |
| .cs, .vb, .jsl, .cpp (not including code-behind files for the file types listed earlier) | These files are compiled and included as a resource in assemblies that reference them. Source files are not copied to the output directory. If a code file is not referenced, it is not compiled. |
| Custom file types | These files are not compiled. These files are copied to the corresponding output directories. |
| Source code files in the App\_Code subdirectory | These files are compiled into assemblies and placed in the Bin directory. |
| .resx and .resource files in the App\_GlobalResources subdirectory | These files are compiled into assemblies and placed in the Bin directory. No App\_GlobalResources subdirectory is created under the main output directory, and no .resx or .resources files located in the source directory are copied to the output directories. |
| .resx and .resource files in the App\_LocalResources subdirectory | These files are not compiled and are copied to the corresponding output directories. |
| .skin files in the App\_Themes subdirectory | The .skin files and static theme files are not compiled and are copied to the corresponding output directories. |
| .browser Web.config Static file types Assemblies already present in the Bin directory | These files are copied as is to the output directories. |

The following table describes how the ASP.NET Compilation tool handles different file types when the **-u** option is omitted.

| **File type** | **Compiler action** |
| --- | --- |
| .aspx, .asmx, .ashx, .master | These files are split into markup and source code, which includes both code-behind files and any code that is enclosed in &lt;script runat="server"&gt; elements. Source code is compiled into assemblies, with names that are derived from a hashing algorithm. The resulting assemblies are placed in the Bin directory. Any inline code, that is, code enclosed between the **&lt;%** and **%&gt;** brackets, is included with markup and not compiled. The compiler creates new files to contain the markup with the same name as the source files. These resulting files are placed in the Bin directory. The compiler also creates files with the same name as the source files but with the extension .COMPILED that contain mapping information. The .COMPILED files are placed in the output directories corresponding to the original location of the source files. |
| .ascx | These files are split into markup and source code. Source code is compiled into assemblies and placed in the Bin directory, with names that are derived from a hashing algorithm. No markup files are generated. |
| .cs, .vb, .jsl, .cpp (not including code-behind files for the file types listed earlier) | Source code that is referenced by the assemblies generated from .ascx, .ashx, or .aspx files is compiled into assemblies and placed in the Bin directory. No source files are copied. |
| Custom file types | These files are compiled like dynamic files. Depending on the type of file they are based on, the compiler can place mapping files in the output directories. |
| Files in the App\_Code subdirectory | Source code files in this subdirectory are compiled into assemblies and placed in the Bin directory. |
| Files in the App\_GlobalResources subdirectory | These files are compiled into assemblies and placed in the Bin directory. No App\_GlobalResources subdirectory is created under the main output directory. If the configuration file specifies appliesTo="All", .resx and .resources files are copied to the output directories. They are not copied if they are referenced by a [BuildProvider](https://msdn.microsoft.com/en-us/library/system.web.configuration.buildprovider.aspx). |
| .resx and .resource files in the App\_LocalResources subdirectory | These files are compiled into assemblies with unique names and placed in the Bin directory. No .resx or .resource files are copied to the output directories. |
| .skin files in the App\_Themes subdirectory | Themes are compiled into assemblies and placed in the Bin directory. Stub files are created for .skin files and placed in the corresponding output directory. Static files (such as .css) are copied to the output directories. |
| .browser Web.config Static file types Assemblies already present in the Bin directory | These files are copied as is to the output directory. |

### [Fixed Assembly Names](https://msdn.microsoft.com/en-us/library/ms229863.aspx##)

Some scenarios, such as deploying a Web application using the MSI Windows Installer, require the use of consistent file names and contents, as well as consistent directory structures to identify assemblies or configuration settings for updates. In those cases, you can use the **-fixednames** option to specify that the ASP.NET Compilation tool should compile an assembly for each source file instead of using the where multiple pages are compiled into assemblies. This can lead to a large number of assemblies, so if you are concerned with scalability you should use this option with caution.

### [Strong-Name Compilation](https://msdn.microsoft.com/en-us/library/ms229863.aspx##)

The **-aptca**, **-delaysign**, **-keycontainer** and **-keyfile** options are provided so that you can use Aspnet\_compiler.exe to create strongly named assemblies without using the [Strong Name Tool (Sn.exe)](https://msdn.microsoft.com/en-us/library/k5b5tt23.aspx) separately. These options correspond, respectively, to **AllowPartiallyTrustedCallersAttribute**, **AssemblyDelaySignAttribute**, **AssemblyKeyNameAttribute**, and **AssemblyKeyFileAttribute**.

Discussion of these attributes is outside of the scope of this course.

## Labs

Each of the following labs builds on the previous labs. You will need to do them in order.

## Lab 1: Using the Configuration API

1. Create a new Web site called *mod9lab*.
2. Add a new Web Configuration File to the site.
3. Add the following to the web.config file:


[!code-xml[Main](configuration-and-instrumentation/samples/sample14.xml)]

This will ensure that you have permission to save changes to the web.config file.

1. Add a new Label control to Default.aspx and change the ID to **lblDebugStatus**.
2. Add a new Button control to Default.aspx.
3. Change the Button control's ID to **btnToggleDebug** and the Text to **Toggle Debug Status**.
4. Open the Code View for the code-behind file of Default.aspx and add a **using** statement for **System.Web.Configuration** as follows:


[!code-csharp[Main](configuration-and-instrumentation/samples/sample15.cs)]

1. Add two private variables to the class and a Page\_Init method as shown below:


[!code-csharp[Main](configuration-and-instrumentation/samples/sample16.cs)]

1. Add the following code to Page\_Load:


[!code-csharp[Main](configuration-and-instrumentation/samples/sample17.cs)]

1. Save and browse default.aspx. Notice that the Label control displays the current debug status.
2. Double-click on the Button control in the designer and add the following code to the Click event for the Button control:


[!code-csharp[Main](configuration-and-instrumentation/samples/sample18.cs)]

1. Save and browse default.aspx and click the button.
2. Open the web.config file after each button click and observe the **debug** attribute in the &lt;compilation&gt; section.

## Lab 2: Logging Application Restarts

In this lab, you will create code that will allow you to toggle the logging of application shutdowns, startups, and recompilations in the Event Viewer.

1. Add a DropDownList to default.aspx and change the ID to ddlLogAppEvents.
2. Set the **AutoPostBack** property for the DropDownList to **true**.
3. Add three items to the Items collection for the DropDownList. Make the **Text** for the first item *Select Value* and the value -1. Make the **Text** and **Value** of the second item **True** and the **Text** and **Value** of the third item **False**.
4. Add a new Label to default.aspx. Change the ID to **lblLogAppEvents**.
5. Open the code-behind view for default.aspx and add a new declaration for a variable of type HealthMonitoringSection as shown below:


[!code-csharp[Main](configuration-and-instrumentation/samples/sample19.cs)]

1. Add the following code to the existing code in Page\_Init:


[!code-csharp[Main](configuration-and-instrumentation/samples/sample20.cs)]

1. Double-click on the DropDownList and add the following code to the SelectedIndexChanged event:


[!code-csharp[Main](configuration-and-instrumentation/samples/sample21.cs)]

1. Browse default.aspx.
2. Set the dropdown to **False**.
3. Clear the Application log in the Event Viewer.
4. Click the button to change the Debug attribute for the application.
5. Refresh the Application log in the Event Viewer. 

    1. Were any events logged?
    2. Why or why not?
6. Set the dropdown to **True.**
7. Click the button to toggle the Debug attribute for the application.
8. Refresh the Application login the Event Viewer. 

    1. Were any events logged?
    2. What was the reason for the app shutdown?
9. Experiment with turning on and off logging and look at the changes made to the web.config file.

## More Information:

ASP.NET 2.0's Provider model allows you to create your own providers for not only application instrumentation, but for many other uses as well such as Membership, Profiles, etc. For detailed information on writing a custom provider to log application events to a text file, visit [this link](https://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnaspp/html/ASPNETProvMod_Prt6.asp).