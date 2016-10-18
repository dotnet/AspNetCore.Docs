.. _security-authentication-identity-options:

Configure Identity
==================

ASP.NET Core Identity has some default behaviors that you can override easily in your application's startup class.

Password's policy
-----------------
 
By default, Identity requires very secure passwords who have to contains uppercase character, lowercase character, digits and some others restrictions that you sometimes need to simplify. It's very simple to do that, all the configuration is accessible in the startup class of your application.

   .. literalinclude:: identity/sample/src/ASPET-IdentityDemo-PrimaryKeysConfig/Startup.cs
    :language: c#
    :lines: 60-65
    :emphasize-lines: 61
    :dedent: 8

Application's cookie settings
-----------------------------

With the same philosophy of the password's policy, all the settings about the application's cookie can be change in the startup class.

   .. literalinclude:: identity/sample/src/ASPET-IdentityDemo-PrimaryKeysConfig/Startup.cs
    :language: c#
    :lines: 72-80
    :emphasize-lines: 73
    :dedent: 8
	
User's lockout
--------------

   .. literalinclude:: identity/sample/src/ASPET-IdentityDemo-PrimaryKeysConfig/Startup.cs
    :language: c#
    :lines: 67-70
    :emphasize-lines: 68
    :dedent: 8
	