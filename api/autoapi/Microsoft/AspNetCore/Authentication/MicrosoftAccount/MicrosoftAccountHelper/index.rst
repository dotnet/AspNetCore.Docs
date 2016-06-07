

MicrosoftAccountHelper Class
============================






Contains static methods that allow to extract user's information from a :any:`Newtonsoft.Json.Linq.JObject`
instance retrieved from Microsoft after a successful authentication process.
http://graph.microsoft.io/en-us/docs/api-reference/v1.0/resources/user


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication.MicrosoftAccount`
Assemblies
    * Microsoft.AspNetCore.Authentication.MicrosoftAccount

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authentication.MicrosoftAccount.MicrosoftAccountHelper`








Syntax
------

.. code-block:: csharp

    public class MicrosoftAccountHelper








.. dn:class:: Microsoft.AspNetCore.Authentication.MicrosoftAccount.MicrosoftAccountHelper
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.MicrosoftAccount.MicrosoftAccountHelper

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authentication.MicrosoftAccount.MicrosoftAccountHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authentication.MicrosoftAccount.MicrosoftAccountHelper.GetDisplayName(Newtonsoft.Json.Linq.JObject)
    
        
    
        
        Gets the user's name.
    
        
    
        
        :type user: Newtonsoft.Json.Linq.JObject
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetDisplayName(JObject user)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.MicrosoftAccount.MicrosoftAccountHelper.GetEmail(Newtonsoft.Json.Linq.JObject)
    
        
    
        
        Gets the user's email address.
    
        
    
        
        :type user: Newtonsoft.Json.Linq.JObject
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetEmail(JObject user)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.MicrosoftAccount.MicrosoftAccountHelper.GetGivenName(Newtonsoft.Json.Linq.JObject)
    
        
    
        
        Gets the user's given name.
    
        
    
        
        :type user: Newtonsoft.Json.Linq.JObject
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetGivenName(JObject user)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.MicrosoftAccount.MicrosoftAccountHelper.GetId(Newtonsoft.Json.Linq.JObject)
    
        
    
        
        Gets the Microsoft Account user ID.
    
        
    
        
        :type user: Newtonsoft.Json.Linq.JObject
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetId(JObject user)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.MicrosoftAccount.MicrosoftAccountHelper.GetSurname(Newtonsoft.Json.Linq.JObject)
    
        
    
        
        Gets the user's surname.
    
        
    
        
        :type user: Newtonsoft.Json.Linq.JObject
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetSurname(JObject user)
    

