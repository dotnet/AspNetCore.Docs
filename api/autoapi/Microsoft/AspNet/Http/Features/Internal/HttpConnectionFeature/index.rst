

HttpConnectionFeature Class
===========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.Features.Internal.HttpConnectionFeature`








Syntax
------

.. code-block:: csharp

   public class HttpConnectionFeature : IHttpConnectionFeature





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Http/Features/HttpConnectionFeature.cs>`_





.. dn:class:: Microsoft.AspNet.Http.Features.Internal.HttpConnectionFeature

Constructors
------------

.. dn:class:: Microsoft.AspNet.Http.Features.Internal.HttpConnectionFeature
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Http.Features.Internal.HttpConnectionFeature.HttpConnectionFeature()
    
        
    
        
        .. code-block:: csharp
    
           public HttpConnectionFeature()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Http.Features.Internal.HttpConnectionFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.Features.Internal.HttpConnectionFeature.IsLocal
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsLocal { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.Internal.HttpConnectionFeature.LocalIpAddress
    
        
        :rtype: System.Net.IPAddress
    
        
        .. code-block:: csharp
    
           public IPAddress LocalIpAddress { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.Internal.HttpConnectionFeature.LocalPort
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int LocalPort { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.Internal.HttpConnectionFeature.RemoteIpAddress
    
        
        :rtype: System.Net.IPAddress
    
        
        .. code-block:: csharp
    
           public IPAddress RemoteIpAddress { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.Internal.HttpConnectionFeature.RemotePort
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int RemotePort { get; set; }
    

