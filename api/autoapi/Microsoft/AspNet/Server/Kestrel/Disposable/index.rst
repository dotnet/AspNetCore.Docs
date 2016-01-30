

Disposable Class
================



.. contents:: 
   :local:



Summary
-------

Summary description for Disposable





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Disposable`








Syntax
------

.. code-block:: csharp

   public class Disposable : IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/kestrelhttpserver/blob/master/src/Microsoft.AspNet.Server.Kestrel/Infrastructure/Disposable.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.Disposable

Constructors
------------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Disposable
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.Disposable.Disposable(System.Action)
    
        
        
        
        :type dispose: System.Action
    
        
        .. code-block:: csharp
    
           public Disposable(Action dispose)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Disposable
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Disposable.Dispose()
    
        
    
        
        .. code-block:: csharp
    
           public void Dispose()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Disposable.Dispose(System.Boolean)
    
        
        
        
        :type disposing: System.Boolean
    
        
        .. code-block:: csharp
    
           protected virtual void Dispose(bool disposing)
    

