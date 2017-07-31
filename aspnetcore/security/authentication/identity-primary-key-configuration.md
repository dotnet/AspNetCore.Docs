---
title: Configure Identity primary keys data type
uid: security/authentication/identity-primary-key-configuration
---
# Configure Identity primary keys data type

ASP.NET Core Identity allows you to easily configure the data type you want for the primary keys. By default, Identity uses string data type but you can very quickly override this behavior.

## How to

1.  The first step is to implement the Identity's model, and override the string type with the data type you want.

    [!code-csharp[Main](identity/sample/src/ASPET-IdentityDemo-PrimaryKeysConfig/Models/ApplicationUser.cs?highlight=4-6&range=7-13)]

    [!code-csharp[Main](identity/sample/src/ASPET-IdentityDemo-PrimaryKeysConfig/Models/ApplicationRole.cs?highlight=3-5&range=7-12)]
	
2.  Implement the database context of Identity with your models and the data type you want for primary keys

    [!code-csharp[Main](identity/sample/src/ASPET-IdentityDemo-PrimaryKeysConfig/Data/ApplicationDbContext.cs?highlight=3&range=9-26)]
	
3.  Use your models and the data type you want for primary keys when you declare the identity service in your application's startup class

    [!code-csharp[Main](identity/sample/src/ASPET-IdentityDemo-PrimaryKeysConfig/Startup.cs?highlight=9-11&range=39-79)]
