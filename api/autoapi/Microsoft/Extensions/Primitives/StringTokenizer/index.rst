

StringTokenizer Struct
======================






Tokenizes a <code>string</code> into :any:`Microsoft.Extensions.Primitives.StringSegment`\s.


Namespace
    :dn:ns:`Microsoft.Extensions.Primitives`
Assemblies
    * Microsoft.Extensions.Primitives

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public struct StringTokenizer : IEnumerable<StringSegment>, IEnumerable








.. dn:structure:: Microsoft.Extensions.Primitives.StringTokenizer
    :hidden:

.. dn:structure:: Microsoft.Extensions.Primitives.StringTokenizer

Constructors
------------

.. dn:structure:: Microsoft.Extensions.Primitives.StringTokenizer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Primitives.StringTokenizer.StringTokenizer(System.String, System.Char[])
    
        
    
        
        Initializes a new instance of :any:`Microsoft.Extensions.Primitives.StringTokenizer`\.
    
        
    
        
        :param value: The <code>string</code> to tokenize.
        
        :type value: System.String
    
        
        :param separators: The characters to tokenize by.
        
        :type separators: System.Char<System.Char>[]
    
        
        .. code-block:: csharp
    
            public StringTokenizer(string value, char[] separators)
    

Methods
-------

.. dn:structure:: Microsoft.Extensions.Primitives.StringTokenizer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Primitives.StringTokenizer.GetEnumerator()
    
        
        :rtype: Microsoft.Extensions.Primitives.StringTokenizer.Enumerator
    
        
        .. code-block:: csharp
    
            public StringTokenizer.Enumerator GetEnumerator()
    
    .. dn:method:: Microsoft.Extensions.Primitives.StringTokenizer.System.Collections.Generic.IEnumerable<Microsoft.Extensions.Primitives.StringSegment>.GetEnumerator()
    
        
        :rtype: System.Collections.Generic.IEnumerator<System.Collections.Generic.IEnumerator`1>{Microsoft.Extensions.Primitives.StringSegment<Microsoft.Extensions.Primitives.StringSegment>}
    
        
        .. code-block:: csharp
    
            IEnumerator<StringSegment> IEnumerable<StringSegment>.GetEnumerator()
    
    .. dn:method:: Microsoft.Extensions.Primitives.StringTokenizer.System.Collections.IEnumerable.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
            IEnumerator IEnumerable.GetEnumerator()
    

