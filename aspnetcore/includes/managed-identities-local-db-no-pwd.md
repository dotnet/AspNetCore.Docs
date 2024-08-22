---
author: wpickett
ms.author: wpickett
ms.date: 08/22/2024
ms.topic: include
---
In this tutorial, a local database is used that doesn't use a password; therefore a secure authentication flow isn't required.
When the app is deployed to a test server, an environment variable can be used to set the connection string to a test database server. For more information, see [Configuration](xref:fundamentals/configuration/index). 

An environment variable should not be used in a production system. For a production system, use a secure method such as [Azure Key Vault configuration provider](xref:security/key-vault-configuration) or [Managed Identities for Azure resources](/sql/connect/ado-net/sql/azure-active-directory-authentication#using-managed-identity-authentication) to manage sensitive information like connection strings.
