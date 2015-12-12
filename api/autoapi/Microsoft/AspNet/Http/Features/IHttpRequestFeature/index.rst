

IHttpRequestFeature Interface
=============================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IHttpRequestFeature





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Http.Features/IHttpRequestFeature.cs>`_





.. dn:interface:: Microsoft.AspNet.Http.Features.IHttpRequestFeature

Properties
----------

.. dn:interface:: Microsoft.AspNet.Http.Features.IHttpRequestFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.Features.IHttpRequestFeature.Body
    
        
        :rtype: System.IO.Stream
    
        
        .. code-block:: csharp
    
           Stream Body { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.IHttpRequestFeature.Headers
    
        
        :rtype: Microsoft.AspNet.Http.IHeaderDictionary
    
        
        .. code-block:: csharp
    
           IHeaderDictionary Headers { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.IHttpRequestFeature.Method
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string Method { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.IHttpRequestFeature.Path
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string Path { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.IHttpRequestFeature.PathBase
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string PathBase { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.IHttpRequestFeature.Protocol
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string Protocol { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.IHttpRequestFeature.QueryString
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string QueryString { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.IHttpRequestFeature.Scheme
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string Scheme { get; set; }
    

