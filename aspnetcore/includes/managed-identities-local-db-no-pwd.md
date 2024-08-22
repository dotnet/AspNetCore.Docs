---
author: wpickett
ms.author: wpickett
ms.date: 08/22/2024
ms.topic: include
---
In this tutorial, a local database is used that doesn't use a password; therefore a secure authentication flow isn't required.
When the app is deployed to a test server, an environment variable can be used to set the connection string to a test database server. For more information, see [Configuration](xref:fundamentals/configuration/index). An environment variable should not be used in a production system.