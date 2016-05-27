

ObjectPoolProviderExtensions Class
==================================





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
* :dn:cls:`Microsoft.Extensions.ObjectPool.ObjectPoolProviderExtensions`








Syntax
------

.. code-block:: csharp

    public class ObjectPoolProviderExtensions








.. dn:class:: Microsoft.Extensions.ObjectPool.ObjectPoolProviderExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.ObjectPool.ObjectPoolProviderExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.ObjectPool.ObjectPoolProviderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.ObjectPool.ObjectPoolProviderExtensions.CreateStringBuilderPool(Microsoft.Extensions.ObjectPool.ObjectPoolProvider)
    
        
    
        
        :type provider: Microsoft.Extensions.ObjectPool.ObjectPoolProvider
        :rtype: Microsoft.Extensions.ObjectPool.ObjectPool<Microsoft.Extensions.ObjectPool.ObjectPool`1>{System.Text.StringBuilder<System.Text.StringBuilder>}
    
        
        .. code-block:: csharp
    
            public static ObjectPool<StringBuilder> CreateStringBuilderPool(ObjectPoolProvider provider)
    
    .. dn:method:: Microsoft.Extensions.ObjectPool.ObjectPoolProviderExtensions.CreateStringBuilderPool(Microsoft.Extensions.ObjectPool.ObjectPoolProvider, System.Int32, System.Int32)
    
        
    
        
        :type provider: Microsoft.Extensions.ObjectPool.ObjectPoolProvider
    
        
        :type initialCapacity: System.Int32
    
        
        :type maximumRetainedCapacity: System.Int32
        :rtype: Microsoft.Extensions.ObjectPool.ObjectPool<Microsoft.Extensions.ObjectPool.ObjectPool`1>{System.Text.StringBuilder<System.Text.StringBuilder>}
    
        
        .. code-block:: csharp
    
            public static ObjectPool<StringBuilder> CreateStringBuilderPool(ObjectPoolProvider provider, int initialCapacity, int maximumRetainedCapacity)
    

