

ObjectPool<T> Class
===================





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
* :dn:cls:`Microsoft.Extensions.ObjectPool.ObjectPool\<T>`








Syntax
------

.. code-block:: csharp

    public abstract class ObjectPool<T>
        where T : class








.. dn:class:: Microsoft.Extensions.ObjectPool.ObjectPool`1
    :hidden:

.. dn:class:: Microsoft.Extensions.ObjectPool.ObjectPool<T>

Methods
-------

.. dn:class:: Microsoft.Extensions.ObjectPool.ObjectPool<T>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.ObjectPool.ObjectPool<T>.Get()
    
        
        :rtype: T
    
        
        .. code-block:: csharp
    
            public abstract T Get()
    
    .. dn:method:: Microsoft.Extensions.ObjectPool.ObjectPool<T>.Return(T)
    
        
    
        
        :type obj: T
    
        
        .. code-block:: csharp
    
            public abstract void Return(T obj)
    

