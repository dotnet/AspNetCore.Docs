

FacebookHelper Class
====================



.. contents:: 
   :local:



Summary
-------

Contains static methods that allow to extract user's information from a :any:`Newtonsoft.Json.Linq.JObject`
instance retrieved from Facebook after a successful authentication process.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.Facebook.FacebookHelper`








Syntax
------

.. code-block:: csharp

   public class FacebookHelper





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authentication.Facebook/FacebookHelper.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.Facebook.FacebookHelper

Methods
-------

.. dn:class:: Microsoft.AspNet.Authentication.Facebook.FacebookHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authentication.Facebook.FacebookHelper.GetEmail(Newtonsoft.Json.Linq.JObject)
    
        
    
        Gets the Facebook email.
    
        
        
        
        :type user: Newtonsoft.Json.Linq.JObject
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public static string GetEmail(JObject user)
    
    .. dn:method:: Microsoft.AspNet.Authentication.Facebook.FacebookHelper.GetId(Newtonsoft.Json.Linq.JObject)
    
        
    
        Gets the Facebook user ID.
    
        
        
        
        :type user: Newtonsoft.Json.Linq.JObject
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public static string GetId(JObject user)
    
    .. dn:method:: Microsoft.AspNet.Authentication.Facebook.FacebookHelper.GetLink(Newtonsoft.Json.Linq.JObject)
    
        
    
        Gets the user's link.
    
        
        
        
        :type user: Newtonsoft.Json.Linq.JObject
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public static string GetLink(JObject user)
    
    .. dn:method:: Microsoft.AspNet.Authentication.Facebook.FacebookHelper.GetName(Newtonsoft.Json.Linq.JObject)
    
        
    
        Gets the user's name.
    
        
        
        
        :type user: Newtonsoft.Json.Linq.JObject
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public static string GetName(JObject user)
    
    .. dn:method:: Microsoft.AspNet.Authentication.Facebook.FacebookHelper.GetUserName(Newtonsoft.Json.Linq.JObject)
    
        
    
        Gets the Facebook username.
    
        
        
        
        :type user: Newtonsoft.Json.Linq.JObject
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public static string GetUserName(JObject user)
    

