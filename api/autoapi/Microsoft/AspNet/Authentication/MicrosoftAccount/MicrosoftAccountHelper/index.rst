

MicrosoftAccountHelper Class
============================



.. contents:: 
   :local:



Summary
-------

Contains static methods that allow to extract user's information from a :any:`Newtonsoft.Json.Linq.JObject`
instance retrieved from Google after a successful authentication process.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.MicrosoftAccount.MicrosoftAccountHelper`








Syntax
------

.. code-block:: csharp

   public class MicrosoftAccountHelper





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication.MicrosoftAccount/MicrosoftAccountHelper.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.MicrosoftAccount.MicrosoftAccountHelper

Methods
-------

.. dn:class:: Microsoft.AspNet.Authentication.MicrosoftAccount.MicrosoftAccountHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authentication.MicrosoftAccount.MicrosoftAccountHelper.GetEmail(Newtonsoft.Json.Linq.JObject)
    
        
    
        Gets the user's email address.
    
        
        
        
        :type user: Newtonsoft.Json.Linq.JObject
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public static string GetEmail(JObject user)
    
    .. dn:method:: Microsoft.AspNet.Authentication.MicrosoftAccount.MicrosoftAccountHelper.GetFirstName(Newtonsoft.Json.Linq.JObject)
    
        
    
        Gets the user's first name.
    
        
        
        
        :type user: Newtonsoft.Json.Linq.JObject
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public static string GetFirstName(JObject user)
    
    .. dn:method:: Microsoft.AspNet.Authentication.MicrosoftAccount.MicrosoftAccountHelper.GetId(Newtonsoft.Json.Linq.JObject)
    
        
    
        Gets the Microsoft Account user ID.
    
        
        
        
        :type user: Newtonsoft.Json.Linq.JObject
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public static string GetId(JObject user)
    
    .. dn:method:: Microsoft.AspNet.Authentication.MicrosoftAccount.MicrosoftAccountHelper.GetLastName(Newtonsoft.Json.Linq.JObject)
    
        
    
        Gets the user's last name.
    
        
        
        
        :type user: Newtonsoft.Json.Linq.JObject
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public static string GetLastName(JObject user)
    
    .. dn:method:: Microsoft.AspNet.Authentication.MicrosoftAccount.MicrosoftAccountHelper.GetName(Newtonsoft.Json.Linq.JObject)
    
        
    
        Gets the user's name.
    
        
        
        
        :type user: Newtonsoft.Json.Linq.JObject
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public static string GetName(JObject user)
    

