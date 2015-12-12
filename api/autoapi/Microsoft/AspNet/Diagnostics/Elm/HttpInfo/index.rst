

HttpInfo Class
==============



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Diagnostics.Elm.HttpInfo`








Syntax
------

.. code-block:: csharp

   public class HttpInfo





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/diagnostics/src/Microsoft.AspNet.Diagnostics.Elm/HttpInfo.cs>`_





.. dn:class:: Microsoft.AspNet.Diagnostics.Elm.HttpInfo

Properties
----------

.. dn:class:: Microsoft.AspNet.Diagnostics.Elm.HttpInfo
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Elm.HttpInfo.ContentType
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ContentType { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Elm.HttpInfo.Cookies
    
        
        :rtype: Microsoft.AspNet.Http.IReadableStringCollection
    
        
        .. code-block:: csharp
    
           public IReadableStringCollection Cookies { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Elm.HttpInfo.Headers
    
        
        :rtype: Microsoft.AspNet.Http.IHeaderDictionary
    
        
        .. code-block:: csharp
    
           public IHeaderDictionary Headers { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Elm.HttpInfo.Host
    
        
        :rtype: Microsoft.AspNet.Http.HostString
    
        
        .. code-block:: csharp
    
           public HostString Host { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Elm.HttpInfo.Method
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Method { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Elm.HttpInfo.Path
    
        
        :rtype: Microsoft.AspNet.Http.PathString
    
        
        .. code-block:: csharp
    
           public PathString Path { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Elm.HttpInfo.Protocol
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Protocol { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Elm.HttpInfo.Query
    
        
        :rtype: Microsoft.AspNet.Http.QueryString
    
        
        .. code-block:: csharp
    
           public QueryString Query { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Elm.HttpInfo.RequestID
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string RequestID { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Elm.HttpInfo.Scheme
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Scheme { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Elm.HttpInfo.StatusCode
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int StatusCode { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Elm.HttpInfo.User
    
        
        :rtype: System.Security.Claims.ClaimsPrincipal
    
        
        .. code-block:: csharp
    
           public ClaimsPrincipal User { get; set; }
    

