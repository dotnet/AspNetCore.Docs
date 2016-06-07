

ObjectPoolProvider Class
========================





Namespace
    :dn:ns:`Microsoft.Extensions.ObjectPool`
Assemblies
    * Microsoft.Extensions.ObjectPool

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.ObjectPool.ObjectPoolProvider`








Syntax
------

.. code-block:: csharp

    public abstract class ObjectPoolProvider








.. dn:class:: Microsoft.Extensions.ObjectPool.ObjectPoolProvider
    :hidden:

.. dn:class:: Microsoft.Extensions.ObjectPool.ObjectPoolProvider

Methods
-------

.. dn:class:: Microsoft.Extensions.ObjectPool.ObjectPoolProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.ObjectPool.ObjectPoolProvider.Create<T>()
    
        
        :rtype: Microsoft.Extensions.ObjectPool.ObjectPool<Microsoft.Extensions.ObjectPool.ObjectPool`1>{T}
    
        
        .. code-block:: csharp
    
            public ObjectPool<T> Create<T>()where T : class, new ()
    
    .. dn:method:: Microsoft.Extensions.ObjectPool.ObjectPoolProvider.Create<T>(Microsoft.Extensions.ObjectPool.IPooledObjectPolicy<T>)
    
        
    
        
        :type policy: Microsoft.Extensions.ObjectPool.IPooledObjectPolicy<Microsoft.Extensions.ObjectPool.IPooledObjectPolicy`1>{T}
        :rtype: Microsoft.Extensions.ObjectPool.ObjectPool<Microsoft.Extensions.ObjectPool.ObjectPool`1>{T}
    
        
        .. code-block:: csharp
    
            public abstract ObjectPool<T> Create<T>(IPooledObjectPolicy<T> policy)where T : class
    

