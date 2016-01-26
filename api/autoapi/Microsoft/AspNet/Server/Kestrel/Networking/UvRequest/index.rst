

UvRequest Class
===============



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Runtime.ConstrainedExecution.CriticalFinalizerObject`
* :dn:cls:`System.Runtime.InteropServices.SafeHandle`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Networking.UvMemory`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Networking.UvRequest`








Syntax
------

.. code-block:: csharp

   public class UvRequest : UvMemory, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/kestrelhttpserver/blob/master/src/Microsoft.AspNet.Server.Kestrel/Networking/UvRequest.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.Networking.UvRequest

Constructors
------------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Networking.UvRequest
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.Networking.UvRequest.UvRequest(Microsoft.AspNet.Server.Kestrel.Infrastructure.IKestrelTrace)
    
        
        
        
        :type logger: Microsoft.AspNet.Server.Kestrel.Infrastructure.IKestrelTrace
    
        
        .. code-block:: csharp
    
           protected UvRequest(IKestrelTrace logger)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Networking.UvRequest
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.UvRequest.Pin()
    
        
    
        
        .. code-block:: csharp
    
           public virtual void Pin()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.UvRequest.ReleaseHandle()
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           protected override bool ReleaseHandle()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.UvRequest.Unpin()
    
        
    
        
        .. code-block:: csharp
    
           public virtual void Unpin()
    

