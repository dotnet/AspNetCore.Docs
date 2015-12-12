

FrameContext Class
==================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.ServiceContext`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.ListenerContext`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.ConnectionContext`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.FrameContext`








Syntax
------

.. code-block:: csharp

   public class FrameContext : ConnectionContext





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/kestrelhttpserver/src/Microsoft.AspNet.Server.Kestrel/Http/FrameContext.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.FrameContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.FrameContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.Http.FrameContext.FrameContext()
    
        
    
        
        .. code-block:: csharp
    
           public FrameContext()
    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.Http.FrameContext.FrameContext(Microsoft.AspNet.Server.Kestrel.Http.ConnectionContext)
    
        
        
        
        :type context: Microsoft.AspNet.Server.Kestrel.Http.ConnectionContext
    
        
        .. code-block:: csharp
    
           public FrameContext(ConnectionContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.FrameContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameContext.FrameControl
    
        
        :rtype: Microsoft.AspNet.Server.Kestrel.Http.IFrameControl
    
        
        .. code-block:: csharp
    
           public IFrameControl FrameControl { get; set; }
    

