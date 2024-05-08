---
title: ASP.NET Core Data Protection Overview
author: rick-anderson
description: Learn about the concept of data protection and the design principles of the ASP.NET Core Data Protection APIs.
ms.author: riande
ms.custom: mvc
ms.date: 03/07/2022
uid: security/data-protection/introTmp
---
# DO NOT REVIEW THIS is a temporary file

The ASP.NET Core data protection provides a cryptographic API to protect data, including key management and rotation.

Web apps often need to store security-sensitive data. [DPAPI](/dotnet/standard/security/how-to-use-data-protection), the Windows data protection API isn't intended for use in web apps.
------------ Start of new content ---------------

If the developer has not configured data protection, ASP.NET Core sets an environment variable that makes the data protection keys read only. Setting the data configuration keys to read only is designed to maintain data consistency in web farms and and [Azure Container Apps](/azure/container-apps/overview).



----------------------------------------------
