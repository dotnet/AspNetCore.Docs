---
title: Introduction
author: rick-anderson
description: 
keywords: ASP.NET Core,
ms.author: riande
manager: wpickett
ms.date: 10/14/2016
ms.topic: article
ms.assetid: a6a556ed-ba59-4107-9358-44cf20e5931b
ms.technology: aspnet
ms.prod: asp.net-core
uid: security/authorization/introduction
---
# Introduction

<a name=security-authorization-introduction></a>

Authorization refers to the process that determines what a user is able to do. For example, an administrative user is allowed to create a document library, add documents, edit documents, and delete them. A non-administrative user working with the library is only authorized to read the documents.

Authorization is orthogonal and independent from authentication, which is the process of ascertaining who a user is. Authentication may create one or more identities for the current user.

## Authorization Types

ASP.NET Core authorization provides a simple declarative [role](roles.md#security-authorization-role-based) and a [rich policy based](policies.md#security-authorization-policies-based) model. Authorization is expressed in requirements, and handlers evaluate a user's claims against requirements. Imperative checks can be based on simple policies or policies which evaluate both the user identity and properties of the resource that the user is attempting to access.

## Namespaces

Authorization components, including the `AuthorizeAttribute` and `AllowAnonymousAttribute` attributes are found in the `Microsoft.AspNetCore.Authorization` namespace.
