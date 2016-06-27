

PathTokenizer Struct
====================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Routing.Internal`
Assemblies
    * Microsoft.AspNetCore.Routing

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public struct PathTokenizer : IReadOnlyList<StringSegment>, IReadOnlyCollection<StringSegment>, IEnumerable<StringSegment>, IEnumerable








.. dn:structure:: Microsoft.AspNetCore.Routing.Internal.PathTokenizer
    :hidden:

.. dn:structure:: Microsoft.AspNetCore.Routing.Internal.PathTokenizer

Constructors
------------

.. dn:structure:: Microsoft.AspNetCore.Routing.Internal.PathTokenizer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Routing.Internal.PathTokenizer.PathTokenizer(Microsoft.AspNetCore.Http.PathString)
    
        
    
        
        :type path: Microsoft.AspNetCore.Http.PathString
    
        
        .. code-block:: csharp
    
            public PathTokenizer(PathString path)
    

Properties
----------

.. dn:structure:: Microsoft.AspNetCore.Routing.Internal.PathTokenizer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Routing.Internal.PathTokenizer.Count
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Count { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Internal.PathTokenizer.Item[System.Int32]
    
        
    
        
        :type index: System.Int32
        :rtype: Microsoft.Extensions.Primitives.StringSegment
    
        
        .. code-block:: csharp
    
            public StringSegment this[int index] { get; }
    

Methods
-------

.. dn:structure:: Microsoft.AspNetCore.Routing.Internal.PathTokenizer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Routing.Internal.PathTokenizer.GetEnumerator()
    
        
        :rtype: Microsoft.AspNetCore.Routing.Internal.PathTokenizer.Enumerator
    
        
        .. code-block:: csharp
    
            public PathTokenizer.Enumerator GetEnumerator()
    
    .. dn:method:: Microsoft.AspNetCore.Routing.Internal.PathTokenizer.System.Collections.Generic.IEnumerable<Microsoft.Extensions.Primitives.StringSegment>.GetEnumerator()
    
        
        :rtype: System.Collections.Generic.IEnumerator<System.Collections.Generic.IEnumerator`1>{Microsoft.Extensions.Primitives.StringSegment<Microsoft.Extensions.Primitives.StringSegment>}
    
        
        .. code-block:: csharp
    
            IEnumerator<StringSegment> IEnumerable<StringSegment>.GetEnumerator()
    
    .. dn:method:: Microsoft.AspNetCore.Routing.Internal.PathTokenizer.System.Collections.IEnumerable.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
            IEnumerator IEnumerable.GetEnumerator()
    

