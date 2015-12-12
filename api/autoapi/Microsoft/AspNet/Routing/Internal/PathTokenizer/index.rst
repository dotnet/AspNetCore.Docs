

PathTokenizer Struct
====================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public struct PathTokenizer : IReadOnlyList<StringSegment>, IReadOnlyCollection<StringSegment>, IEnumerable<StringSegment>, IEnumerable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/routing/src/Microsoft.AspNet.Routing/Internal/PathTokenizer.cs>`_





.. dn:structure:: Microsoft.AspNet.Routing.Internal.PathTokenizer

Constructors
------------

.. dn:structure:: Microsoft.AspNet.Routing.Internal.PathTokenizer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Routing.Internal.PathTokenizer.PathTokenizer(Microsoft.AspNet.Http.PathString)
    
        
        
        
        :type path: Microsoft.AspNet.Http.PathString
    
        
        .. code-block:: csharp
    
           public PathTokenizer(PathString path)
    

Methods
-------

.. dn:structure:: Microsoft.AspNet.Routing.Internal.PathTokenizer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Routing.Internal.PathTokenizer.GetEnumerator()
    
        
        :rtype: Microsoft.AspNet.Routing.Internal.PathTokenizer.Enumerator
    
        
        .. code-block:: csharp
    
           public PathTokenizer.Enumerator GetEnumerator()
    
    .. dn:method:: Microsoft.AspNet.Routing.Internal.PathTokenizer.System.Collections.Generic.IEnumerable<Microsoft.Extensions.Primitives.StringSegment>.GetEnumerator()
    
        
        :rtype: System.Collections.Generic.IEnumerator{Microsoft.Extensions.Primitives.StringSegment}
    
        
        .. code-block:: csharp
    
           IEnumerator<StringSegment> IEnumerable<StringSegment>.GetEnumerator()
    
    .. dn:method:: Microsoft.AspNet.Routing.Internal.PathTokenizer.System.Collections.IEnumerable.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
           IEnumerator IEnumerable.GetEnumerator()
    

Properties
----------

.. dn:structure:: Microsoft.AspNet.Routing.Internal.PathTokenizer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Routing.Internal.PathTokenizer.Count
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Count { get; }
    
    .. dn:property:: Microsoft.AspNet.Routing.Internal.PathTokenizer.Item[System.Int32]
    
        
        
        
        :type index: System.Int32
        :rtype: Microsoft.Extensions.Primitives.StringSegment
    
        
        .. code-block:: csharp
    
           public StringSegment this[int index] { get; }
    

