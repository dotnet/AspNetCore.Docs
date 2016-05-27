

GoogleHelper Class
==================






Contains static methods that allow to extract user's information from a :any:`Newtonsoft.Json.Linq.JObject`
instance retrieved from Google after a successful authentication process.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication.Google`
Assemblies
    * Microsoft.AspNetCore.Authentication.Google

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authentication.Google.GoogleHelper`








Syntax
------

.. code-block:: csharp

    public class GoogleHelper








.. dn:class:: Microsoft.AspNetCore.Authentication.Google.GoogleHelper
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.Google.GoogleHelper

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authentication.Google.GoogleHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Google.GoogleHelper.GetEmail(Newtonsoft.Json.Linq.JObject)
    
        
    
        
        Gets the user's email.
    
        
    
        
        :type user: Newtonsoft.Json.Linq.JObject
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetEmail(JObject user)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Google.GoogleHelper.GetFamilyName(Newtonsoft.Json.Linq.JObject)
    
        
    
        
        Gets the user's family name.
    
        
    
        
        :type user: Newtonsoft.Json.Linq.JObject
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetFamilyName(JObject user)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Google.GoogleHelper.GetGivenName(Newtonsoft.Json.Linq.JObject)
    
        
    
        
        Gets the user's given name.
    
        
    
        
        :type user: Newtonsoft.Json.Linq.JObject
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetGivenName(JObject user)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Google.GoogleHelper.GetId(Newtonsoft.Json.Linq.JObject)
    
        
    
        
        Gets the Google user ID.
    
        
    
        
        :type user: Newtonsoft.Json.Linq.JObject
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetId(JObject user)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Google.GoogleHelper.GetName(Newtonsoft.Json.Linq.JObject)
    
        
    
        
        Gets the user's name.
    
        
    
        
        :type user: Newtonsoft.Json.Linq.JObject
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetName(JObject user)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Google.GoogleHelper.GetProfile(Newtonsoft.Json.Linq.JObject)
    
        
    
        
        Gets the user's profile link.
    
        
    
        
        :type user: Newtonsoft.Json.Linq.JObject
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetProfile(JObject user)
    

