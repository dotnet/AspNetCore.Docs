

ConnectionFilterContext Class
=============================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel.Filter`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Filter.ConnectionFilterContext`








Syntax
------

.. code-block:: csharp

    public class ConnectionFilterContext








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Filter.ConnectionFilterContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Filter.ConnectionFilterContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Filter.ConnectionFilterContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Filter.ConnectionFilterContext.Address
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.ServerAddress
    
        
        .. code-block:: csharp
    
            public ServerAddress Address { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Filter.ConnectionFilterContext.Connection
    
        
        :rtype: System.IO.Stream
    
        
        .. code-block:: csharp
    
            public Stream Connection { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Filter.ConnectionFilterContext.PrepareRequest
    
        
        :rtype: System.Action<System.Action`1>{Microsoft.AspNetCore.Http.Features.IFeatureCollection<Microsoft.AspNetCore.Http.Features.IFeatureCollection>}
    
        
        .. code-block:: csharp
    
            public Action<IFeatureCollection> PrepareRequest { get; set; }
    

