

IPooledObjectPolicy<T> Interface
================================





Namespace
    :dn:ns:`Microsoft.Extensions.ObjectPool`
Assemblies
    * Microsoft.Extensions.ObjectPool

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IPooledObjectPolicy<T>








.. dn:interface:: Microsoft.Extensions.ObjectPool.IPooledObjectPolicy`1
    :hidden:

.. dn:interface:: Microsoft.Extensions.ObjectPool.IPooledObjectPolicy<T>

Methods
-------

.. dn:interface:: Microsoft.Extensions.ObjectPool.IPooledObjectPolicy<T>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.ObjectPool.IPooledObjectPolicy<T>.Create()
    
        
        :rtype: T
    
        
        .. code-block:: csharp
    
            T Create()
    
    .. dn:method:: Microsoft.Extensions.ObjectPool.IPooledObjectPolicy<T>.Return(T)
    
        
    
        
        :type obj: T
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            bool Return(T obj)
    

