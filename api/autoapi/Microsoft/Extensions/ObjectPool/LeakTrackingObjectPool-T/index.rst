

LeakTrackingObjectPool<T> Class
===============================





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
* :dn:cls:`Microsoft.Extensions.ObjectPool.LeakTrackingObjectPool\<T>`








Syntax
------

.. code-block:: csharp

    public class LeakTrackingObjectPool<T> : ObjectPool<T> where T : class








.. dn:class:: Microsoft.Extensions.ObjectPool.LeakTrackingObjectPool`1
    :hidden:

.. dn:class:: Microsoft.Extensions.ObjectPool.LeakTrackingObjectPool<T>

Constructors
------------

.. dn:class:: Microsoft.Extensions.ObjectPool.LeakTrackingObjectPool<T>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.ObjectPool.LeakTrackingObjectPool<T>.LeakTrackingObjectPool(Microsoft.Extensions.ObjectPool.ObjectPool<T>)
    
        
    
        
        :type inner: Microsoft.Extensions.ObjectPool.ObjectPool<Microsoft.Extensions.ObjectPool.ObjectPool`1>{T}
    
        
        .. code-block:: csharp
    
            public LeakTrackingObjectPool(ObjectPool<T> inner)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.ObjectPool.LeakTrackingObjectPool<T>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.ObjectPool.LeakTrackingObjectPool<T>.Get()
    
        
        :rtype: T
    
        
        .. code-block:: csharp
    
            public override T Get()
    
    .. dn:method:: Microsoft.Extensions.ObjectPool.LeakTrackingObjectPool<T>.Return(T)
    
        
    
        
        :type obj: T
    
        
        .. code-block:: csharp
    
            public override void Return(T obj)
    

