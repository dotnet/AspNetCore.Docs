

JsonArrayPool<T> Class
======================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Formatters.Json.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Formatters.Json

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Formatters.Json.Internal.JsonArrayPool\<T>`








Syntax
------

.. code-block:: csharp

    public class JsonArrayPool<T> : IArrayPool<T>








.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Json.Internal.JsonArrayPool`1
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Json.Internal.JsonArrayPool<T>

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Json.Internal.JsonArrayPool<T>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Formatters.Json.Internal.JsonArrayPool<T>.JsonArrayPool(System.Buffers.ArrayPool<T>)
    
        
    
        
        :type inner: System.Buffers.ArrayPool<System.Buffers.ArrayPool`1>{T}
    
        
        .. code-block:: csharp
    
            public JsonArrayPool(ArrayPool<T> inner)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Json.Internal.JsonArrayPool<T>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.Json.Internal.JsonArrayPool<T>.Rent(System.Int32)
    
        
    
        
        :type minimumLength: System.Int32
        :rtype: T[]
    
        
        .. code-block:: csharp
    
            public T[] Rent(int minimumLength)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.Json.Internal.JsonArrayPool<T>.Return(T[])
    
        
    
        
        :type array: T[]
    
        
        .. code-block:: csharp
    
            public void Return(T[] array)
    

