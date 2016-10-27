.. _security-authentication-identity-primary-key-configuration:

Configure Identity primary keys data type
=========================================

ASP.NET Core Identity allows you to easily configure the data type you want for the primary keys. By default, Identity uses string data type but you can very quickly override this behavior.

How to
------
 
1. The first step is to implement the Identity's model, and override the <string> behavior to <data type you want>'s one.

  .. literalinclude:: identity/sample/src/ASPET-IdentityDemo-PrimaryKeysConfig/Models/ApplicationUser.cs
    :language: c#
    :lines: 7-13
    :emphasize-lines: 10-12
    :dedent: 8

  .. literalinclude:: identity/sample/src/ASPET-IdentityDemo-PrimaryKeysConfig/Models/ApplicationRole.cs
    :language: c#
    :lines: 7-12
    :emphasize-lines: 9-11
    :dedent: 8

2. Implement the database context of Identity with your models and the data type you want for primary keys

  .. literalinclude:: identity/sample/src/ASPET-IdentityDemo-PrimaryKeysConfig/Data/ApplicationDbContext.cs
    :language: c#
    :lines: 9-26
    :emphasize-lines: 11
    :dedent: 8

3. Use you models and the data type you want for primary keys when you declare the identity service in your application's startup class

  .. literalinclude:: identity/sample/src/ASPET-IdentityDemo-PrimaryKeysConfig/Startup.cs
    :language: c#
    :lines: 39-79
    :emphasize-lines: 47-49
    :dedent: 8

