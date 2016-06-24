

SessionExtensions Class
=======================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Http`
Assemblies
    * Microsoft.AspNetCore.Http.Extensions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Http.SessionExtensions`








Syntax
------

.. code-block:: csharp

    public class SessionExtensions








.. dn:class:: Microsoft.AspNetCore.Http.SessionExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.SessionExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Http.SessionExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.SessionExtensions.Get(Microsoft.AspNetCore.Http.ISession, System.String)
    
        
    
        
        :type session: Microsoft.AspNetCore.Http.ISession
    
        
        :type key: System.String
        :rtype: System.Byte<System.Byte>[]
    
        
        .. code-block:: csharp
    
            public static byte[] Get(this ISession session, string key)
    
    .. dn:method:: Microsoft.AspNetCore.Http.SessionExtensions.GetInt32(Microsoft.AspNetCore.Http.ISession, System.String)
    
        
    
        
        :type session: Microsoft.AspNetCore.Http.ISession
    
        
        :type key: System.String
        :rtype: System.Nullable<System.Nullable`1>{System.Int32<System.Int32>}
    
        
        .. code-block:: csharp
    
            public static int ? GetInt32(this ISession session, string key)
    
    .. dn:method:: Microsoft.AspNetCore.Http.SessionExtensions.GetString(Microsoft.AspNetCore.Http.ISession, System.String)
    
        
    
        
        :type session: Microsoft.AspNetCore.Http.ISession
    
        
        :type key: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetString(this ISession session, string key)
    
    .. dn:method:: Microsoft.AspNetCore.Http.SessionExtensions.SetInt32(Microsoft.AspNetCore.Http.ISession, System.String, System.Int32)
    
        
    
        
        :type session: Microsoft.AspNetCore.Http.ISession
    
        
        :type key: System.String
    
        
        :type value: System.Int32
    
        
        .. code-block:: csharp
    
            public static void SetInt32(this ISession session, string key, int value)
    
    .. dn:method:: Microsoft.AspNetCore.Http.SessionExtensions.SetString(Microsoft.AspNetCore.Http.ISession, System.String, System.String)
    
        
    
        
        :type session: Microsoft.AspNetCore.Http.ISession
    
        
        :type key: System.String
    
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
            public static void SetString(this ISession session, string key, string value)
    

