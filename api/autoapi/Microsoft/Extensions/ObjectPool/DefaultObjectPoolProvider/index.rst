

DefaultObjectPoolProvider Class
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
* :dn:cls:`Microsoft.Extensions.ObjectPool.ObjectPoolProvider`
* :dn:cls:`Microsoft.Extensions.ObjectPool.DefaultObjectPoolProvider`








Syntax
------

.. code-block:: csharp

    public class DefaultObjectPoolProvider : ObjectPoolProvider








.. dn:class:: Microsoft.Extensions.ObjectPool.DefaultObjectPoolProvider
    :hidden:

.. dn:class:: Microsoft.Extensions.ObjectPool.DefaultObjectPoolProvider

Properties
----------

.. dn:class:: Microsoft.Extensions.ObjectPool.DefaultObjectPoolProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.ObjectPool.DefaultObjectPoolProvider.MaximumRetained
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int MaximumRetained
            {
                get;
                set;
            }
    

Methods
-------

.. dn:class:: Microsoft.Extensions.ObjectPool.DefaultObjectPoolProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.ObjectPool.DefaultObjectPoolProvider.Create<T>(Microsoft.Extensions.ObjectPool.IPooledObjectPolicy<T>)
    
        
    
        
        :type policy: Microsoft.Extensions.ObjectPool.IPooledObjectPolicy<Microsoft.Extensions.ObjectPool.IPooledObjectPolicy`1>{T}
        :rtype: Microsoft.Extensions.ObjectPool.ObjectPool<Microsoft.Extensions.ObjectPool.ObjectPool`1>{T}
    
        
        .. code-block:: csharp
    
            public override ObjectPool<T> Create<T>(IPooledObjectPolicy<T> policy)where T : class
    

