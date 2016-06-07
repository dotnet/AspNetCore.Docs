

StringBuilderPooledObjectPolicy Class
=====================================





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
* :dn:cls:`Microsoft.Extensions.ObjectPool.StringBuilderPooledObjectPolicy`








Syntax
------

.. code-block:: csharp

    public class StringBuilderPooledObjectPolicy : IPooledObjectPolicy<StringBuilder>








.. dn:class:: Microsoft.Extensions.ObjectPool.StringBuilderPooledObjectPolicy
    :hidden:

.. dn:class:: Microsoft.Extensions.ObjectPool.StringBuilderPooledObjectPolicy

Properties
----------

.. dn:class:: Microsoft.Extensions.ObjectPool.StringBuilderPooledObjectPolicy
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.ObjectPool.StringBuilderPooledObjectPolicy.InitialCapacity
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int InitialCapacity
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.Extensions.ObjectPool.StringBuilderPooledObjectPolicy.MaximumRetainedCapacity
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int MaximumRetainedCapacity
            {
                get;
                set;
            }
    

Methods
-------

.. dn:class:: Microsoft.Extensions.ObjectPool.StringBuilderPooledObjectPolicy
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.ObjectPool.StringBuilderPooledObjectPolicy.Create()
    
        
        :rtype: System.Text.StringBuilder
    
        
        .. code-block:: csharp
    
            public StringBuilder Create()
    
    .. dn:method:: Microsoft.Extensions.ObjectPool.StringBuilderPooledObjectPolicy.Return(System.Text.StringBuilder)
    
        
    
        
        :type obj: System.Text.StringBuilder
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Return(StringBuilder obj)
    

