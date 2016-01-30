

IHttpConnectionFeature Interface
================================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IHttpConnectionFeature





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.Http.Features/IHttpConnectionFeature.cs>`_





.. dn:interface:: Microsoft.AspNet.Http.Features.IHttpConnectionFeature

Properties
----------

.. dn:interface:: Microsoft.AspNet.Http.Features.IHttpConnectionFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.Features.IHttpConnectionFeature.IsLocal
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool IsLocal { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.IHttpConnectionFeature.LocalIpAddress
    
        
        :rtype: System.Net.IPAddress
    
        
        .. code-block:: csharp
    
           IPAddress LocalIpAddress { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.IHttpConnectionFeature.LocalPort
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int LocalPort { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.IHttpConnectionFeature.RemoteIpAddress
    
        
        :rtype: System.Net.IPAddress
    
        
        .. code-block:: csharp
    
           IPAddress RemoteIpAddress { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.IHttpConnectionFeature.RemotePort
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int RemotePort { get; set; }
    

