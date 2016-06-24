

IHttpConnectionFeature Interface
================================






Information regarding the TCP/IP connection carrying the request.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Http.Features`
Assemblies
    * Microsoft.AspNetCore.Http.Features

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IHttpConnectionFeature








.. dn:interface:: Microsoft.AspNetCore.Http.Features.IHttpConnectionFeature
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Http.Features.IHttpConnectionFeature

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Http.Features.IHttpConnectionFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.IHttpConnectionFeature.ConnectionId
    
        
    
        
        The unique identifier for the connection the request was received on. This is primarily for diagnostic purposes.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string ConnectionId { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.IHttpConnectionFeature.LocalIpAddress
    
        
    
        
        The local IPAddress on which the request was received.
    
        
        :rtype: System.Net.IPAddress
    
        
        .. code-block:: csharp
    
            IPAddress LocalIpAddress { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.IHttpConnectionFeature.LocalPort
    
        
    
        
        The local port on which the request was received.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            int LocalPort { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.IHttpConnectionFeature.RemoteIpAddress
    
        
    
        
        The IPAddress of the client making the request. Note this may be for a proxy rather than the end user.
    
        
        :rtype: System.Net.IPAddress
    
        
        .. code-block:: csharp
    
            IPAddress RemoteIpAddress { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.IHttpConnectionFeature.RemotePort
    
        
    
        
        The remote port of the client making the request.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            int RemotePort { get; set; }
    

