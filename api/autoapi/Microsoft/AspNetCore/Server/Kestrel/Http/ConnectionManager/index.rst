

ConnectionManager Class
=======================





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
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Http.ConnectionManager`








Syntax
------

.. code-block:: csharp

    public class ConnectionManager








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.ConnectionManager
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.ConnectionManager

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.ConnectionManager
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Http.ConnectionManager.ConnectionManager(Microsoft.AspNetCore.Server.Kestrel.KestrelThread)
    
        
    
        
        :type thread: Microsoft.AspNetCore.Server.Kestrel.KestrelThread
    
        
        .. code-block:: csharp
    
            public ConnectionManager(KestrelThread thread)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.ConnectionManager
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.ConnectionManager.WaitForConnectionCloseAsync()
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task WaitForConnectionCloseAsync()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.ConnectionManager.WalkConnectionsAndClose()
    
        
    
        
        .. code-block:: csharp
    
            public void WalkConnectionsAndClose()
    

