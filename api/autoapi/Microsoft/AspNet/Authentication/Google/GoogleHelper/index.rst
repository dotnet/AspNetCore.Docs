

GoogleHelper Class
==================



.. contents:: 
   :local:



Summary
-------

Contains static methods that allow to extract user's information from a :any:`Newtonsoft.Json.Linq.JObject`
instance retrieved from Google after a successful authentication process.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.Google.GoogleHelper`








Syntax
------

.. code-block:: csharp

   public class GoogleHelper





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication.Google/GoogleHelper.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.Google.GoogleHelper

Methods
-------

.. dn:class:: Microsoft.AspNet.Authentication.Google.GoogleHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authentication.Google.GoogleHelper.GetEmail(Newtonsoft.Json.Linq.JObject)
    
        
    
        Gets the user's email.
    
        
        
        
        :type user: Newtonsoft.Json.Linq.JObject
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public static string GetEmail(JObject user)
    
    .. dn:method:: Microsoft.AspNet.Authentication.Google.GoogleHelper.GetFamilyName(Newtonsoft.Json.Linq.JObject)
    
        
    
        Gets the user's family name.
    
        
        
        
        :type user: Newtonsoft.Json.Linq.JObject
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public static string GetFamilyName(JObject user)
    
    .. dn:method:: Microsoft.AspNet.Authentication.Google.GoogleHelper.GetGivenName(Newtonsoft.Json.Linq.JObject)
    
        
    
        Gets the user's given name.
    
        
        
        
        :type user: Newtonsoft.Json.Linq.JObject
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public static string GetGivenName(JObject user)
    
    .. dn:method:: Microsoft.AspNet.Authentication.Google.GoogleHelper.GetId(Newtonsoft.Json.Linq.JObject)
    
        
    
        Gets the Google user ID.
    
        
        
        
        :type user: Newtonsoft.Json.Linq.JObject
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public static string GetId(JObject user)
    
    .. dn:method:: Microsoft.AspNet.Authentication.Google.GoogleHelper.GetName(Newtonsoft.Json.Linq.JObject)
    
        
    
        Gets the user's name.
    
        
        
        
        :type user: Newtonsoft.Json.Linq.JObject
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public static string GetName(JObject user)
    
    .. dn:method:: Microsoft.AspNet.Authentication.Google.GoogleHelper.GetProfile(Newtonsoft.Json.Linq.JObject)
    
        
    
        Gets the user's profile link.
    
        
        
        
        :type user: Newtonsoft.Json.Linq.JObject
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public static string GetProfile(JObject user)
    

