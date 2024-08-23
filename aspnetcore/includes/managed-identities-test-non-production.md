---
author: wpickett
ms.author: wpickett
ms.date: 08/22/2024
ms.topic: include
---
> [!NOTE]
> In this tutorial, a local database is used that doesn't use a password. For production apps:
> * A password is required.
> * Microsoft recommends that you use the most secure authentication flow available.
>
> Azure SQL Database should use [Managed Identities for Azure resources](/sql/connect/ado-net/sql/azure-active-directory-authentication#using-managed-identity-authentication). For non-Azure apps, use a secure authentication flow similar to managed identities for Azure resources.
>
> When the app is deployed to a test server, an environment variable can be used to set the connection string to a test database server. For more information, see [Configuration](xref:fundamentals/configuration/index).
