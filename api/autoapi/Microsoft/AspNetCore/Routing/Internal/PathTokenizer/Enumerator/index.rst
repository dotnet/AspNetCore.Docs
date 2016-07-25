

Enumerator Struct
=================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Routing.Internal.PathTokenizer`
Assemblies
    * Microsoft.AspNetCore.Routing

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public struct Enumerator : IEnumerator<StringSegment>, IDisposable, IEnumerator








.. dn:structure:: Microsoft.AspNetCore.Routing.Internal.PathTokenizer.Enumerator
    :hidden:

.. dn:structure:: Microsoft.AspNetCore.Routing.Internal.PathTokenizer.Enumerator

Constructors
------------

.. dn:structure:: Microsoft.AspNetCore.Routing.Internal.PathTokenizer.Enumerator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Routing.Internal.PathTokenizer.Enumerator.Enumerator(Microsoft.AspNetCore.Routing.Internal.PathTokenizer)
    
        
    
        
        :type tokenizer: Microsoft.AspNetCore.Routing.Internal.PathTokenizer
    
        
        .. code-block:: csharp
    
            public Enumerator(PathTokenizer tokenizer)
    

Properties
----------

.. dn:structure:: Microsoft.AspNetCore.Routing.Internal.PathTokenizer.Enumerator
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Routing.Internal.PathTokenizer.Enumerator.Current
    
        
        :rtype: Microsoft.Extensions.Primitives.StringSegment
    
        
        .. code-block:: csharp
    
            public StringSegment Current { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Internal.PathTokenizer.Enumerator.System.Collections.IEnumerator.Current
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            object IEnumerator.Current { get; }
    

Methods
-------

.. dn:structure:: Microsoft.AspNetCore.Routing.Internal.PathTokenizer.Enumerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Routing.Internal.PathTokenizer.Enumerator.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    
    .. dn:method:: Microsoft.AspNetCore.Routing.Internal.PathTokenizer.Enumerator.MoveNext()
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool MoveNext()
    
    .. dn:method:: Microsoft.AspNetCore.Routing.Internal.PathTokenizer.Enumerator.Reset()
    
        
    
        
        .. code-block:: csharp
    
            public void Reset()
    

