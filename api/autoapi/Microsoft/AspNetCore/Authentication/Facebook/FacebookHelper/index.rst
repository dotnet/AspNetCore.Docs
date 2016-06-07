

FacebookHelper Class
====================






Contains static methods that allow to extract user's information from a :any:`Newtonsoft.Json.Linq.JObject`
instance retrieved from Facebook after a successful authentication process.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication.Facebook`
Assemblies
    * Microsoft.AspNetCore.Authentication.Facebook

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authentication.Facebook.FacebookHelper`








Syntax
------

.. code-block:: csharp

    public class FacebookHelper








.. dn:class:: Microsoft.AspNetCore.Authentication.Facebook.FacebookHelper
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.Facebook.FacebookHelper

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authentication.Facebook.FacebookHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Facebook.FacebookHelper.GetAgeRangeMax(Newtonsoft.Json.Linq.JObject)
    
        
    
        
        Gets the user's max age.
    
        
    
        
        :type user: Newtonsoft.Json.Linq.JObject
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetAgeRangeMax(JObject user)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Facebook.FacebookHelper.GetAgeRangeMin(Newtonsoft.Json.Linq.JObject)
    
        
    
        
        Gets the user's min age.
    
        
    
        
        :type user: Newtonsoft.Json.Linq.JObject
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetAgeRangeMin(JObject user)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Facebook.FacebookHelper.GetBirthday(Newtonsoft.Json.Linq.JObject)
    
        
    
        
        Gets the user's birthday.
    
        
    
        
        :type user: Newtonsoft.Json.Linq.JObject
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetBirthday(JObject user)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Facebook.FacebookHelper.GetEmail(Newtonsoft.Json.Linq.JObject)
    
        
    
        
        Gets the Facebook email.
    
        
    
        
        :type user: Newtonsoft.Json.Linq.JObject
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetEmail(JObject user)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Facebook.FacebookHelper.GetFirstName(Newtonsoft.Json.Linq.JObject)
    
        
    
        
        Gets the user's first name.
    
        
    
        
        :type user: Newtonsoft.Json.Linq.JObject
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetFirstName(JObject user)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Facebook.FacebookHelper.GetGender(Newtonsoft.Json.Linq.JObject)
    
        
    
        
        Gets the user's gender.
    
        
    
        
        :type user: Newtonsoft.Json.Linq.JObject
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetGender(JObject user)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Facebook.FacebookHelper.GetId(Newtonsoft.Json.Linq.JObject)
    
        
    
        
        Gets the Facebook user ID.
    
        
    
        
        :type user: Newtonsoft.Json.Linq.JObject
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetId(JObject user)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Facebook.FacebookHelper.GetLastName(Newtonsoft.Json.Linq.JObject)
    
        
    
        
        Gets the user's family name.
    
        
    
        
        :type user: Newtonsoft.Json.Linq.JObject
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetLastName(JObject user)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Facebook.FacebookHelper.GetLink(Newtonsoft.Json.Linq.JObject)
    
        
    
        
        Gets the user's link.
    
        
    
        
        :type user: Newtonsoft.Json.Linq.JObject
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetLink(JObject user)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Facebook.FacebookHelper.GetLocale(Newtonsoft.Json.Linq.JObject)
    
        
    
        
        Gets the user's locale.
    
        
    
        
        :type user: Newtonsoft.Json.Linq.JObject
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetLocale(JObject user)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Facebook.FacebookHelper.GetLocation(Newtonsoft.Json.Linq.JObject)
    
        
    
        
        Gets the user's location.
    
        
    
        
        :type user: Newtonsoft.Json.Linq.JObject
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetLocation(JObject user)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Facebook.FacebookHelper.GetMiddleName(Newtonsoft.Json.Linq.JObject)
    
        
    
        
        Gets the user's middle name.
    
        
    
        
        :type user: Newtonsoft.Json.Linq.JObject
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetMiddleName(JObject user)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Facebook.FacebookHelper.GetName(Newtonsoft.Json.Linq.JObject)
    
        
    
        
        Gets the user's name.
    
        
    
        
        :type user: Newtonsoft.Json.Linq.JObject
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetName(JObject user)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Facebook.FacebookHelper.GetTimeZone(Newtonsoft.Json.Linq.JObject)
    
        
    
        
        Gets the user's timezone.
    
        
    
        
        :type user: Newtonsoft.Json.Linq.JObject
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetTimeZone(JObject user)
    

