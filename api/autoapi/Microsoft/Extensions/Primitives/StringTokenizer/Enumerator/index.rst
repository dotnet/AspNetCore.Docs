

Enumerator Struct
=================





Namespace
    :dn:ns:`Microsoft.Extensions.Primitives.StringTokenizer`
Assemblies
    * Microsoft.Extensions.Primitives

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public struct Enumerator : IEnumerator<StringSegment>, IEnumerator, IDisposable








.. dn:structure:: Microsoft.Extensions.Primitives.StringTokenizer.Enumerator
    :hidden:

.. dn:structure:: Microsoft.Extensions.Primitives.StringTokenizer.Enumerator

Properties
----------

.. dn:structure:: Microsoft.Extensions.Primitives.StringTokenizer.Enumerator
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Primitives.StringTokenizer.Enumerator.Current
    
        
        :rtype: Microsoft.Extensions.Primitives.StringSegment
    
        
        .. code-block:: csharp
    
            public StringSegment Current
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.Primitives.StringTokenizer.Enumerator.System.Collections.IEnumerator.Current
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            object IEnumerator.Current
            {
                get;
            }
    

Constructors
------------

.. dn:structure:: Microsoft.Extensions.Primitives.StringTokenizer.Enumerator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Primitives.StringTokenizer.Enumerator.Enumerator(ref Microsoft.Extensions.Primitives.StringTokenizer)
    
        
    
        
        :type tokenizer: Microsoft.Extensions.Primitives.StringTokenizer
    
        
        .. code-block:: csharp
    
            public Enumerator(ref StringTokenizer tokenizer)
    

Methods
-------

.. dn:structure:: Microsoft.Extensions.Primitives.StringTokenizer.Enumerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Primitives.StringTokenizer.Enumerator.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    
    .. dn:method:: Microsoft.Extensions.Primitives.StringTokenizer.Enumerator.MoveNext()
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool MoveNext()
    
    .. dn:method:: Microsoft.Extensions.Primitives.StringTokenizer.Enumerator.Reset()
    
        
    
        
        .. code-block:: csharp
    
            public void Reset()
    

