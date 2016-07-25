

Enumerator Struct
=================





Namespace
    :dn:ns:`Microsoft.Extensions.Primitives.StringValues`
Assemblies
    * Microsoft.Extensions.Primitives

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public struct Enumerator : IEnumerator<string>, IEnumerator, IDisposable








.. dn:structure:: Microsoft.Extensions.Primitives.StringValues.Enumerator
    :hidden:

.. dn:structure:: Microsoft.Extensions.Primitives.StringValues.Enumerator

Constructors
------------

.. dn:structure:: Microsoft.Extensions.Primitives.StringValues.Enumerator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Primitives.StringValues.Enumerator.Enumerator(ref Microsoft.Extensions.Primitives.StringValues)
    
        
    
        
        :type values: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public Enumerator(ref StringValues values)
    

Properties
----------

.. dn:structure:: Microsoft.Extensions.Primitives.StringValues.Enumerator
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Primitives.StringValues.Enumerator.Current
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Current { get; }
    
    .. dn:property:: Microsoft.Extensions.Primitives.StringValues.Enumerator.System.Collections.IEnumerator.Current
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            object IEnumerator.Current { get; }
    

Methods
-------

.. dn:structure:: Microsoft.Extensions.Primitives.StringValues.Enumerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Primitives.StringValues.Enumerator.MoveNext()
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool MoveNext()
    
    .. dn:method:: Microsoft.Extensions.Primitives.StringValues.Enumerator.System.Collections.IEnumerator.Reset()
    
        
    
        
        .. code-block:: csharp
    
            void IEnumerator.Reset()
    
    .. dn:method:: Microsoft.Extensions.Primitives.StringValues.Enumerator.System.IDisposable.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            void IDisposable.Dispose()
    

