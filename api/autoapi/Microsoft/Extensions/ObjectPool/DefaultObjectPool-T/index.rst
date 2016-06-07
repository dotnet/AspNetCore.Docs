

DefaultObjectPool<T> Class
==========================





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
* :dn:cls:`Microsoft.Extensions.ObjectPool.ObjectPool{{T}}`
* :dn:cls:`Microsoft.Extensions.ObjectPool.DefaultObjectPool\<T>`








Syntax
------

.. code-block:: csharp

    public class DefaultObjectPool<T> : ObjectPool<T> where T : class








.. dn:class:: Microsoft.Extensions.ObjectPool.DefaultObjectPool`1
    :hidden:

.. dn:class:: Microsoft.Extensions.ObjectPool.DefaultObjectPool<T>

Constructors
------------

.. dn:class:: Microsoft.Extensions.ObjectPool.DefaultObjectPool<T>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.ObjectPool.DefaultObjectPool<T>.DefaultObjectPool(Microsoft.Extensions.ObjectPool.IPooledObjectPolicy<T>)
    
        
    
        
        :type policy: Microsoft.Extensions.ObjectPool.IPooledObjectPolicy<Microsoft.Extensions.ObjectPool.IPooledObjectPolicy`1>{T}
    
        
        .. code-block:: csharp
    
            public DefaultObjectPool(IPooledObjectPolicy<T> policy)
    
    .. dn:constructor:: Microsoft.Extensions.ObjectPool.DefaultObjectPool<T>.DefaultObjectPool(Microsoft.Extensions.ObjectPool.IPooledObjectPolicy<T>, System.Int32)
    
        
    
        
        :type policy: Microsoft.Extensions.ObjectPool.IPooledObjectPolicy<Microsoft.Extensions.ObjectPool.IPooledObjectPolicy`1>{T}
    
        
        :type maximumRetained: System.Int32
    
        
        .. code-block:: csharp
    
            public DefaultObjectPool(IPooledObjectPolicy<T> policy, int maximumRetained)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.ObjectPool.DefaultObjectPool<T>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.ObjectPool.DefaultObjectPool<T>.Get()
    
        
        :rtype: T
    
        
        .. code-block:: csharp
    
            public override T Get()
    
    .. dn:method:: Microsoft.Extensions.ObjectPool.DefaultObjectPool<T>.Return(T)
    
        
    
        
        :type obj: T
    
        
        .. code-block:: csharp
    
            public override void Return(T obj)
    

