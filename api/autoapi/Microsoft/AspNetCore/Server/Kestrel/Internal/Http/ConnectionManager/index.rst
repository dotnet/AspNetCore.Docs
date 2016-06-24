

ConnectionManager Class
=======================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel.Internal.Http`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Internal.Http.ConnectionManager`








Syntax
------

.. code-block:: csharp

    public class ConnectionManager








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.ConnectionManager
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.ConnectionManager

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.ConnectionManager
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.ConnectionManager.ConnectionManager(Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelThread)
    
        
    
        
        :type thread: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelThread
    
        
        .. code-block:: csharp
    
            public ConnectionManager(KestrelThread thread)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.ConnectionManager
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.ConnectionManager.WaitForConnectionCloseAsync()
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task WaitForConnectionCloseAsync()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.ConnectionManager.WalkConnectionsAndClose()
    
        
    
        
        .. code-block:: csharp
    
            public void WalkConnectionsAndClose()
    

