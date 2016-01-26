

SessionExtensions Class
=======================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.SessionExtensions`








Syntax
------

.. code-block:: csharp

   public class SessionExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.Http.Extensions/SessionExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Http.SessionExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Http.SessionExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.SessionExtensions.Get(Microsoft.AspNet.Http.Features.ISession, System.String)
    
        
        
        
        :type session: Microsoft.AspNet.Http.Features.ISession
        
        
        :type key: System.String
        :rtype: System.Byte[]
    
        
        .. code-block:: csharp
    
           public static byte[] Get(ISession session, string key)
    
    .. dn:method:: Microsoft.AspNet.Http.SessionExtensions.GetInt32(Microsoft.AspNet.Http.Features.ISession, System.String)
    
        
        
        
        :type session: Microsoft.AspNet.Http.Features.ISession
        
        
        :type key: System.String
        :rtype: System.Nullable{System.Int32}
    
        
        .. code-block:: csharp
    
           public static int ? GetInt32(ISession session, string key)
    
    .. dn:method:: Microsoft.AspNet.Http.SessionExtensions.GetString(Microsoft.AspNet.Http.Features.ISession, System.String)
    
        
        
        
        :type session: Microsoft.AspNet.Http.Features.ISession
        
        
        :type key: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public static string GetString(ISession session, string key)
    
    .. dn:method:: Microsoft.AspNet.Http.SessionExtensions.SetInt32(Microsoft.AspNet.Http.Features.ISession, System.String, System.Int32)
    
        
        
        
        :type session: Microsoft.AspNet.Http.Features.ISession
        
        
        :type key: System.String
        
        
        :type value: System.Int32
    
        
        .. code-block:: csharp
    
           public static void SetInt32(ISession session, string key, int value)
    
    .. dn:method:: Microsoft.AspNet.Http.SessionExtensions.SetString(Microsoft.AspNet.Http.Features.ISession, System.String, System.String)
    
        
        
        
        :type session: Microsoft.AspNet.Http.Features.ISession
        
        
        :type key: System.String
        
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
           public static void SetString(ISession session, string key, string value)
    

