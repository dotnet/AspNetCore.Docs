

LeakTrackingObjectPoolProvider Class
====================================





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
* :dn:cls:`Microsoft.Extensions.ObjectPool.LeakTrackingObjectPoolProvider`








Syntax
------

.. code-block:: csharp

    public class LeakTrackingObjectPoolProvider : ObjectPoolProvider








.. dn:class:: Microsoft.Extensions.ObjectPool.LeakTrackingObjectPoolProvider
    :hidden:

.. dn:class:: Microsoft.Extensions.ObjectPool.LeakTrackingObjectPoolProvider

Constructors
------------

.. dn:class:: Microsoft.Extensions.ObjectPool.LeakTrackingObjectPoolProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.ObjectPool.LeakTrackingObjectPoolProvider.LeakTrackingObjectPoolProvider(Microsoft.Extensions.ObjectPool.ObjectPoolProvider)
    
        
    
        
        :type inner: Microsoft.Extensions.ObjectPool.ObjectPoolProvider
    
        
        .. code-block:: csharp
    
            public LeakTrackingObjectPoolProvider(ObjectPoolProvider inner)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.ObjectPool.LeakTrackingObjectPoolProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.ObjectPool.LeakTrackingObjectPoolProvider.Create<T>(Microsoft.Extensions.ObjectPool.IPooledObjectPolicy<T>)
    
        
    
        
        :type policy: Microsoft.Extensions.ObjectPool.IPooledObjectPolicy<Microsoft.Extensions.ObjectPool.IPooledObjectPolicy`1>{T}
        :rtype: Microsoft.Extensions.ObjectPool.ObjectPool<Microsoft.Extensions.ObjectPool.ObjectPool`1>{T}
    
        
        .. code-block:: csharp
    
            public override ObjectPool<T> Create<T>(IPooledObjectPolicy<T> policy)where T : class
    

