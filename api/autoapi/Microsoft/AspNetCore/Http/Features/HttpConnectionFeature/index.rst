

HttpConnectionFeature Class
===========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Http.Features`
Assemblies
    * Microsoft.AspNetCore.Http

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Http.Features.HttpConnectionFeature`








Syntax
------

.. code-block:: csharp

    public class HttpConnectionFeature : IHttpConnectionFeature








.. dn:class:: Microsoft.AspNetCore.Http.Features.HttpConnectionFeature
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.Features.HttpConnectionFeature

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Http.Features.HttpConnectionFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.HttpConnectionFeature.ConnectionId
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ConnectionId
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.HttpConnectionFeature.LocalIpAddress
    
        
        :rtype: System.Net.IPAddress
    
        
        .. code-block:: csharp
    
            public IPAddress LocalIpAddress
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.HttpConnectionFeature.LocalPort
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int LocalPort
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.HttpConnectionFeature.RemoteIpAddress
    
        
        :rtype: System.Net.IPAddress
    
        
        .. code-block:: csharp
    
            public IPAddress RemoteIpAddress
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.HttpConnectionFeature.RemotePort
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int RemotePort
            {
                get;
                set;
            }
    

