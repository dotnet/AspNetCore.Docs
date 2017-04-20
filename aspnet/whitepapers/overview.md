---
uid: whitepapers/overview
title: "Whitepapers | Microsoft Docs"
author: rick-anderson
description: "On this page you will find whitepapers to help you install and configure ASP.NET, and to assist you to write secure, fast and flexible ASP.NET applications."
ms.author: aspnetcontent
manager: wpickett
ms.date: 11/15/2011
ms.topic: article
ms.assetid: d5e79470-01f2-4d65-8077-11c3e10a6784
ms.technology: 
ms.prod: .net-framework
msc.legacyurl: /whitepapers
msc.type: content
---
Whitepapers
====================
> On this page you will find whitepapers to help you install and configure ASP.NET, and to assist you to write secure, fast and flexible ASP.NET applications.
> 
> - [ASP.NET 4](#aspnet4)
> - [ASP.NET Security Whitepapers](#security)
> - [Installation and Setup Whitepapers](#setup)
> - [SQL Server Whitepapers](#sql)
> - [General Whitepapers](#general)


<a id="aspnet4"></a>
## ASP.NET 4

Information related to ASP.NET 4 and Visual Studio 2010.

[ASP.NET MVC 4 Release Notes](mvc4-beta-release-notes.md "mvc4-release-notes")

This document describes new features and improvements introduced in the ASP.NET MVC 4 Developer Preview for Visual Studio 2010, as well as installation notes and known issues.

[ASP.NET MVC 3 Release Notes](mvc3-release-notes.md "mvc3-release-notes")

This document describes new features and improvements introduced in ASP.NET MVC 3, as well as installation notes and known issues.

[ASP.NET 4 and Visual Studio 2010 Web Development Overview](aspnet4/index.md "aspnet4")

Many exciting changes for ASP.NET are coming in the .NET Framework version 4. This document gives an overview of many of the new features that are included in the upcoming release.

[ASP.NET 4 Beta 2 Breaking Changes](aspnet4/breaking-changes.md "breaking-changes")

This document describes changes that have been made for the .NET Framework version 4 Beta 2 release (that is, the ASP.NET 4 Beta 2 release) that can potentially affect applications that were created using earlier releases, including the ASP.NET 4 Beta 1 release.

[What's New in ASP.NET MVC 2](what-is-new-in-aspnet-mvc.md "what is new in aspnet mvc")

This document describes new features and improvements introduced in ASP.NET MVC 2.

[Upgrading an ASP.NET MVC 1.0 Application to ASP.NET MVC 2](aspnet-mvc2-upgrade-notes.md "aspnet-mvc2-upgrade-notes")

ASP.NET MVC 2 can be installed side by side with ASP.NET MVC 1.0 on the same server. This gives application developers flexibility in choosing when to upgrade an ASP.NET MVC 1.0 application to ASP.NET MVC 2. This document descibes both how to upgrade manually and with a wizard in Visual...

<a id="security"></a>
## ASP.NET Security Whitepapers

Security is an important aspect of internet applications, and these whitepapers discuss how to design and implement secure ASP.NET applications.

[Instrument ASP.NET 2.0 Applications for Security](https://msdn.microsoft.com/en-us/library/ms998325.aspx)

This How To shows you how to use custom health monitoring events to instrument your ASP.NET application to track security-related events and operations. ASP.NET version 2.0 provides health monitoring that includes instrumentation for many standard ...

[Perform a Security Deployment Review for ASP.NET 2.0](https://msdn.microsoft.com/en-us/library/ms998367.aspx)

This How To shows you how to perform a security deployment review for an ASP.NET 2.0 application to identify potential security vulnerabilities introduced by inappropriate configuration settings. The majority of the review process involves making...

[Use ADAM for Roles in ASP.NET 2.0](https://msdn.microsoft.com/en-us/library/ms998331.aspx)

This How To shows you how you can develop an ASP.NET Web site that uses Active Directory Application Mode (ADAM) to store ASP.NET roles. It shows you how to configure ADAM and the Authorization Manager (AzMan) policy store, how to create new roles and...

[Use Authorization Manager (AzMan) with ASP.NET 2.0](https://msdn.microsoft.com/en-us/library/ms998336.aspx)

This How To shows you how to use the Authorization Manager (AzMan) in conjunction with the ASP.NET role manager API to manage roles, check user role membership, and authorize roles to perform specific operations against an AzMan policy store. The How To...

[Use Membership in ASP.NET 2.0](https://msdn.microsoft.com/en-us/library/ms998347.aspx)

This How To shows how to use the membership feature in ASP.NET version 2.0 applications. It shows you how to use two different membership providers: the ActiveDirectoryMembershipProvider and the SqlMembershipProvider. The membership feature...

[Use Role Manager in ASP.NET 2.0](https://msdn.microsoft.com/en-us/library/ms998314.aspx)

This How To shows you how to use the ASP.NET 2.0 role manager. The role manager eases the task of managing roles and performing role-based authorization in your application. It shows how to configure the various role providers for use with your...

[Use Windows Authentication in ASP.NET 2.0](https://msdn.microsoft.com/en-us/library/ms998358.aspx)

This How To shows you how to configure and use Windows authentication in an ASP.NET Web application. Windows authentication is the preferred approach whenever users are a part of your Windows domain. This approach enables you to use an existing identity store...

[Perform a Security Code Review for Managed Code (Baseline Activity)](https://msdn.microsoft.com/en-us/library/ms998364.aspx)

This How To shows you how to perform security code reviews. This module presents the steps involved in the activity, and techniques for analyzing your results. Use this How To with "Security Question List: Managed Code (.NET Framework 2.0)" ...

[Perform a Security Deployment Review for ASP.NET 2.0](https://msdn.microsoft.com/en-us/library/ms998367.aspx)

This How To shows you how to perform a security deployment review for an ASP.NET 2.0 application to identify potential security vulnerabilities introduced by inappropriate configuration settings. The majority of the review process involves making...

[Implement Kerberos Delegation for Windows 2000](https://msdn.microsoft.com/en-us/library/aa302400.aspx)

Kerberos delegation allows you to flow an authenticated identity across multiple physical tiers of an application to support downstream authentication and authorization. This How To shows you the configuration steps required to make this work.

[Use Impersonation and Delegation in ASP.NET 2.0](https://msdn.microsoft.com/en-us/library/ms998351.aspx)

This How To shows you how and when you should use impersonation in ASP.NET 2.0 applications. By default, impersonation is turned off, and you can access resources by using the ASP.NET Web application's process identity. However, you can use...

[Create a Threat Model for a Web Application at Design Time](https://msdn.microsoft.com/en-us/library/ms978527.aspx)

This How To describes an approach for creating a threat model for a Web application. The threat modeling activity helps you to model your security design so that you can expose potential security design flaws and vulnerabilities before you invest...

### Forms Authentication

[Protect Forms Authentication in ASP.NET 2.0](https://msdn.microsoft.com/en-us/library/ms998310.aspx)

This How To shows you how to securely configure and use forms authentication with ASP.NET 2.0 applications. Key factors to consider include properly securing the authentication ticket and securing the user identity store and access to that store. ...

[Use Forms Authentication with Active Directory in ASP.NET 2.0](https://msdn.microsoft.com/en-us/library/ms998360.aspx)

This How To shows you how to use forms authentication with Microsoft® Active Directory® directory service by using the ActiveDirectoryMembershipProvider. The How To shows you how to configure the provider and create and authenticate users....

[Use Forms Authentication with Active Directory in Multiple Domains in ASP.NET 2.0](https://msdn.microsoft.com/en-us/library/ms998345.aspx)

This How To shows you how to use forms authentication with Microsoft® Active Directory® directory service by using the ActiveDirectoryMembershipProvider. The How To shows you how to configure the provider and create and authenticate users....

[Use Forms Authentication with SQL Server in ASP.NET 2.0](https://msdn.microsoft.com/en-us/library/ms998317.aspx)

This How To shows you how you can use forms authentication with the SQL Server membership provider. Forms authentication with SQL Server is most applicable in situations where users of your application are not part of your Windows domain, and as a result,...

[Create GenericPrincipal Objects with Forms Authentication in ASP.NET 1.1](https://msdn.microsoft.com/en-us/library/aa302399.aspx)

This How To shows you how to create and handle GenericPrincipal and FormsIdentity objects when using Forms authentication.

[Use Forms Authentication with Active Directory in ASP.NET 1.1](https://msdn.microsoft.com/en-us/library/aa302397.aspx)

This How To article shows you how to implement Forms authentication against an Active Directory credential store.

[Use Forms Authentication with SQL Server in ASP.NET 1.1](https://msdn.microsoft.com/en-us/library/aa302398.aspx)

This How To shows you how to implement Forms authentication against a SQL Server credential store. It also shows you how to store password digests in the database.

### User Input Data Validation

[Request Validation - Preventing Script Attacks](request-validation.md "request-validation")

This paper describes the request validation feature of ASP.NET where, by default, the application is prevented from processing unencoded HTML content submitted to the server. This request validation feature can be disabled when the application has been...

[Prevent Cross-Site Scripting in ASP.NET](https://msdn.microsoft.com/en-us/library/ms998274.aspx)

This How To shows how you can help protect your ASP.NET applications from cross-site scripting attacks by using proper input validation techniques and by encoding the output. It also describes a number of other protection mechanisms that you can use in...

[Protect From SQL Injection in ASP.NET](https://msdn.microsoft.com/en-us/library/ms998271.aspx)

This How To shows a number of ways to help protect your ASP.NET application from SQL injection attacks. SQL injection can occur when an application uses input to construct dynamic SQL statements or when it uses stored procedures to connect to the...

[Use Regular Expressions to Constrain Input in ASP.NET](https://msdn.microsoft.com/en-us/library/ms998267.aspx)

This How To shows how you can use regular expressions within ASP.NET applications to constrain untrusted input. Regular expressions are a good way to validate text fields such as names, addresses, phone numbers, and other user information. You can use...

### Code Access Security

[Use Code Access Security in ASP.NET 2.0](https://msdn.microsoft.com/en-us/library/ms998326.aspx)

This How To shows you how to select an appropriate trust level for your application, and where necessary, how to create a custom ASP.NET code access security policy file to define a custom trust level. You can use different code access security trust...

[Create a Custom Encryption Permission](https://msdn.microsoft.com/en-us/library/aa302362.aspx)

This How To describes how to create a custom code access security permission to control programmatic access to unmanaged encryption functionality that Win32® Data Protection API (DPAPI) provides. Use this custom permission with the managed DPAPI wrapper ...

[Use Code Access Security Policy to Constrain an Assembly](https://msdn.microsoft.com/en-us/library/aa302361.aspx)

An administrator can configure code access security policy to constrain the operations of .NET Framework code (assemblies). In this How To, you configure code access security policy to constrain the ability of an assembly to perform file I/O and restrict...

### Communications Security

[Set Up SSL on a Web Server](https://msdn.microsoft.com/en-us/library/aa302411.aspx)

A Web server must be configured for SSL in order to support https connections from client applications. This How To shows you how to configure SSL on a Web Server.

[Set Up Client Certificates](https://msdn.microsoft.com/en-us/library/aa302412.aspx)

IIS supports client certificate authentication. This How To shows you how to configure a Web application to require client certificates. It also shows you how to install a certificate on a client computer and use it when calling the Web application.

[Use IPSec for Filtering Ports and Authentication](https://msdn.microsoft.com/en-us/library/aa302366.aspx)

Internet Protocol security (IPSec) is a protocol, not a service, that provides encryption, integrity, and authentication services for IP-based network traffic. Because IPSec provides server-to-server protection, you can use IPSec to counter internal threats...

[Use IPSec to Provide Secure Communication Between Two Servers](https://msdn.microsoft.com/en-us/library/aa302413.aspx)

IPSec is a technology provided by Windows 2000 that allows you to create encrypted channels between two servers. IPSec can be used to filter IP traffic and to authenticate servers. This How To shows you how to configure IPSec to provide a secure (encrypted) ...

[Use SSL to Secure Communication with SQL Server](https://msdn.microsoft.com/en-us/library/aa302414.aspx)

It is often vital for applications to be able to secure the data passed to and from a SQL Server database server. With SQL Server, you can use SSL to create an encrypted channel. This How To shows you how to install a certificate on the database server, ...

[Call a Web Service Using Client Certificates from ASP.NET 1.1](https://msdn.microsoft.com/en-us/library/aa302408.aspx)

This How To describes how you can pass a client certificate to a Web service for authentication from an ASP.NET Web application or from a Windows Forms application. You can install the client certificate in either the local machine store or the user store. If...

[Call a Web Service Using SSL from ASP.NET 1.1](https://msdn.microsoft.com/en-us/library/aa302409.aspx)

Secure Sockets Layer (SSL) encryption can be used to guarantee the integrity and confidentiality of the messages passed to and from a Web service. This How To shows you how to use SSL with Web services.

### Cryptography

[Create a DPAPI Library in .NET 1.1](https://msdn.microsoft.com/en-us/library/aa302402.aspx)

This How To shows you how to create a managed class library that exposes DPAPI functionality to applications that want to encrypt data, for example, database connection strings and account credentials.

[Create an Encryption Library in .NET 1.1](https://msdn.microsoft.com/en-us/library/aa302405.aspx)

This How To shows you how to create a managed class library to provide encryption functionality for applications. It allows an application to choose the encryption algorithm. Supported algorithms include DES, Triple DES, RC2, and Rijndael.

[Store an Encrypted Connection String in the Registry in ASP.NET 1.1](https://msdn.microsoft.com/en-us/library/aa302406.aspx)

Applications may choose to store encrypted data such as connection strings and account credentials in the Windows registry. This How To shows you how to store and retrieve encrypted strings in the registry.

[Use DPAPI (Machine Store) from ASP.NET 1.1](https://msdn.microsoft.com/en-us/library/aa302403.aspx)

This How To shows you how to use DPAPI from an ASP.NET Web application or Web service to encrypt sensitive data.

[Use DPAPI (User Store) from ASP.NET 1.1 with Enterprise Services](https://msdn.microsoft.com/en-us/library/aa302404.aspx)

This How To shows you how to use DPAPI from an ASP.NET Web application or service to encrypt sensitive data. This How To uses DPAPI with the user store, which requires the use of an out of process Enterprise Services component.

<a id="setup"></a>
## Installation and Setup Whitepapers

These whitepapers provide step-by-step instructions for installing and configuring ASP.NET on your server.

[Create a Service Account for an ASP.NET 2.0 Application](https://msdn.microsoft.com/en-us/library/ms998297.aspx)

This How To shows you how to create and configure a custom least-privileged service account to run an ASP.NET Web application. By default, an ASP.NET application on Microsoft Windows Server 2003 and IIS 6.0 runs using the built-in Network Service ...

[Improve Security When Hosting Multiple Applications in ASP.NET 2.0](https://msdn.microsoft.com/en-us/library/aa480478.aspx)

This How To shows how you can isolate multiple applications from one another and from shared system resources in a Web hosting environment. The hosting environment might be a Web server provided by an Internet Service Provider (ISP) that hosts multiple ...

[Use Medium Trust in ASP.NET 2.0](https://msdn.microsoft.com/en-us/library/ms998341.aspx)

This How To shows you how to configure ASP.NET Web applications to run in medium trust. If you host multiple applications on the same server, you can use code access security and the medium trust level to provide application isolation. By setting ...

[Use the Network Service Account to Access Resources in ASP.NET 2.0](https://msdn.microsoft.com/en-us/library/ms998320.aspx)

This How To shows you how you can use the NT AUTHORITY\Network Service machine account to access local and network resources. By default on Windows Server 2003, ASP.NET applications run using this account's identity. It is a least privileged...

[Use Protocol Transition and Constrained Delegation in ASP.NET 2.0](https://msdn.microsoft.com/en-us/library/ms998355.aspx)

This How To shows you how to configure and use protocol transition and constrained delegation to allow your ASP.NET application to access network resources while impersonating the original caller. The Microsoft® Windows® 2000 operating system ...

[ASP.NET Side-by-Side Execution of .NET Framework 1.0 and 1.1](side-by-side-with-10.md "side by side with 1.0")

This whitepaper describes how to install both .NET 1.0 and .NET 1.1 on your machine, allowing an ASP.NET Web application to run on either version of the framework.

[ASP.NET Denied Access to IIS Directories](denied-access-to-iis-directories.md "denied access to iis directories")

This whitepaper describes what you must do if a request to your ASP.NET application returns the error, "Denied Access to *DirectoryName* directory. Failed to start monitoring directory changes."

[Running ASP.NET 1.1 with IIS 6.0](aspnet-and-iis6.md "aspnet and iis6")

While Windows Server 2003 includes both IIS 6.0 and ASP.NET 1.1, these components are disabled by default. This whitepaper describes how to enable IIS 6.0 and ASP.NET 1.1, and recommends several configuration settings to get the optimal...

[Fix for ‘Server Application Unavailable' Error after Applying Security Update for IE](ms03-32-issue.md "ms03-32-issue")

This paper describes the patch that fixes an issue with the MS03-32 Security Update for Internet Explorer that affects ASP.NET 1.0 applications running on Windows XP Professional.

[Create a Custom Account To Run ASP.NET 1.1](https://msdn.microsoft.com/en-us/library/aa302396.aspx)

ASP.NET Web applications usually run using the built-in ASPNET account. On occasion, you may want to use a custom account instead. This How To article shows you how to create a least privileged local account to run ASP.NET Web applications. ...

### Configuration

[Configure the Machine Key in ASP.NET 2.0](https://msdn.microsoft.com/en-us/library/ms998288.aspx)

This How To explains the &lt;machineKey&gt; element in the Web.config file and shows how to configure the &lt;machineKey&gt; element to control tamper proofing and encryption of ViewState, forms authentication tickets, and role cookies. ViewState is signed...

[Encrypt Configuration Sections in ASP.NET 2.0 Using DPAPI](https://msdn.microsoft.com/en-us/library/ms998280.aspx)

This How To shows how to use the Windows Data Protection application programming interface (DPAPI) protected configuration provider and the Aspnet\_regiis.exe tool to encrypt sections of your configuration files. You can use the Aspnet\_regiis.exe tool to ...

[Encrypt Configuration Sections in ASP.NET 2.0 Using RSA](https://msdn.microsoft.com/en-us/library/ms998283.aspx)

This How To shows how to use the RSA Protected Configuration provider and the Aspnet\_regiis.exe tool to encrypt sections of your configuration files. You can use Aspnet\_regiis.exe tool to encrypt sensitive data, such as connection strings, held in the ...

[Use Impersonation and Delegation in ASP.NET 2.0](https://msdn.microsoft.com/en-us/library/ms998351.aspx)

This How To shows you how and when you should use impersonation in ASP.NET 2.0 applications. By default, impersonation is turned off, and you can access resources by using the ASP.NET Web application's process identity. However, you can use...

<a id="sql"></a>
## SQL Server Whitepapers

While ASP.NET works with a variety of databases, these whitepapers look specifically at connecting ASP.NET applications to SQL Server.

[Connect to SQL Server Using SQL Authentication in ASP.NET 2.0](https://msdn.microsoft.com/en-us/library/ms998300.aspx)

This How To shows you how to connect an ASP.NET application securely to Microsoft® SQL Server™ when database access authentication uses native SQL authentication. Windows authentication is the recommended way to connect to SQL Server because you...

[Connect to SQL Server Using Windows Authentication in ASP.NET 2.0](https://msdn.microsoft.com/en-us/library/ms998292.aspx)

This How To shows you how to connect to SQL Server 2000 using a Windows service account from an ASP.NET version 2.0 application. You should use Windows authentication instead of SQL authentication whenever possible because you avoid storing credentials in ...

[Use SSL to Secure Communication with SQL Server 2000](https://msdn.microsoft.com/en-us/library/aa302414.aspx)

It is often vital for applications to be able to secure the data passed to and from a SQL Server database server. With SQL Server, you can use SSL to create an encrypted channel. This How To shows you how to install a certificate on the database server,...

<a id="general"></a>
## General Whitepapers

The following case study describes the process that was used to migrate Microsoft's .NET community websites from a traditional hosting environment to Microsoft Azure.

[Migrating Microsoft's ASP.NET and IIS.NET Community Websites to Microsoft Azure](https://go.microsoft.com/fwlink/?LinkId=400656)

These whitepapers cover a variety of topics concerning ASP.NET.

[Use Health Monitoring in ASP.NET 2.0](https://msdn.microsoft.com/en-us/library/ms998306.aspx)

This How To shows you how to use health monitoring to instrument your application for a custom event. To create a custom health monitoring event, you create a class that derives from System.Web.Management.WebBaseEvent, configure the &lt;healthMonitoring&gt; ...

[Implement Patch Management](https://msdn.microsoft.com/en-us/library/aa302364.aspx)

This How To explains patch management, including how to keep single or multiple servers up to date. Additional software is not required, except for the tools available for download from Microsoft. Operations and security policy should adopt a patch management...

[ASP.NET Server Controls for Silverlight in the Silverlight 3 SDK](https://go.microsoft.com/fwlink/?LinkId=153377)

The ASP.NET Server Controls for Silverlight ("ASP.NET Silverlight controls"), which are the ASP.NET MediaPlayer and Silverlight controls, have been removed from the Silverlight SDK for Silverlight version 3. This document provides guidance for developers who worked with these ASP.NET...

[Building High Performance Web Applications](https://ajaxcontroltoolkit.codeplex.com/documentation)

Learn how to use the new features in ASP.NET Ajax Library to build High Performance Web Applications