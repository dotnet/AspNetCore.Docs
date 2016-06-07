

UvRequest Class
===============





Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel.Networking`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Runtime.ConstrainedExecution.CriticalFinalizerObject`
* :dn:cls:`System.Runtime.InteropServices.SafeHandle`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Networking.UvMemory`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Networking.UvRequest`








Syntax
------

.. code-block:: csharp

    public class UvRequest : UvMemory, IDisposable








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvRequest
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvRequest

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvRequest
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvRequest.UvRequest(Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace)
    
        
    
        
        :type logger: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace
    
        
        .. code-block:: csharp
    
            protected UvRequest(IKestrelTrace logger)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvRequest
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvRequest.Pin()
    
        
    
        
        .. code-block:: csharp
    
            public virtual void Pin()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvRequest.ReleaseHandle()
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected override bool ReleaseHandle()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Networking.UvRequest.Unpin()
    
        
    
        
        .. code-block:: csharp
    
            public virtual void Unpin()
    

