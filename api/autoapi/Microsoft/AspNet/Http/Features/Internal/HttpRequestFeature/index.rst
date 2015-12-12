

HttpRequestFeature Class
========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.Features.Internal.HttpRequestFeature`








Syntax
------

.. code-block:: csharp

   public class HttpRequestFeature : IHttpRequestFeature





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Http/Features/HttpRequestFeature.cs>`_





.. dn:class:: Microsoft.AspNet.Http.Features.Internal.HttpRequestFeature

Constructors
------------

.. dn:class:: Microsoft.AspNet.Http.Features.Internal.HttpRequestFeature
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Http.Features.Internal.HttpRequestFeature.HttpRequestFeature()
    
        
    
        
        .. code-block:: csharp
    
           public HttpRequestFeature()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Http.Features.Internal.HttpRequestFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.Features.Internal.HttpRequestFeature.Body
    
        
        :rtype: System.IO.Stream
    
        
        .. code-block:: csharp
    
           public Stream Body { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.Internal.HttpRequestFeature.Headers
    
        
        :rtype: Microsoft.AspNet.Http.IHeaderDictionary
    
        
        .. code-block:: csharp
    
           public IHeaderDictionary Headers { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.Internal.HttpRequestFeature.Method
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Method { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.Internal.HttpRequestFeature.Path
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Path { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.Internal.HttpRequestFeature.PathBase
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string PathBase { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.Internal.HttpRequestFeature.Protocol
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Protocol { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.Internal.HttpRequestFeature.QueryString
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string QueryString { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.Internal.HttpRequestFeature.Scheme
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Scheme { get; set; }
    

