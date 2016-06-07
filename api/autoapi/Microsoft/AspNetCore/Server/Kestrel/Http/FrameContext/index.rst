

FrameContext Class
==================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel.Http`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.ServiceContext`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Http.ListenerContext`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Http.ConnectionContext`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Http.FrameContext`








Syntax
------

.. code-block:: csharp

    public class FrameContext : ConnectionContext








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameContext.FrameControl
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Http.IFrameControl
    
        
        .. code-block:: csharp
    
            public IFrameControl FrameControl
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameContext.FrameContext()
    
        
    
        
        .. code-block:: csharp
    
            public FrameContext()
    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameContext.FrameContext(Microsoft.AspNetCore.Server.Kestrel.Http.ConnectionContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Server.Kestrel.Http.ConnectionContext
    
        
        .. code-block:: csharp
    
            public FrameContext(ConnectionContext context)
    

