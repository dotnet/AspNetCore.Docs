

DefaultPooledObjectPolicy<T> Class
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
* :dn:cls:`Microsoft.Extensions.ObjectPool.DefaultPooledObjectPolicy\<T>`








Syntax
------

.. code-block:: csharp

    public class DefaultPooledObjectPolicy<T> : IPooledObjectPolicy<T> where T : class, new ()








.. dn:class:: Microsoft.Extensions.ObjectPool.DefaultPooledObjectPolicy`1
    :hidden:

.. dn:class:: Microsoft.Extensions.ObjectPool.DefaultPooledObjectPolicy<T>

Methods
-------

.. dn:class:: Microsoft.Extensions.ObjectPool.DefaultPooledObjectPolicy<T>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.ObjectPool.DefaultPooledObjectPolicy<T>.Create()
    
        
        :rtype: T
    
        
        .. code-block:: csharp
    
            public T Create()
    
    .. dn:method:: Microsoft.Extensions.ObjectPool.DefaultPooledObjectPolicy<T>.Return(T)
    
        
    
        
        :type obj: T
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Return(T obj)
    

