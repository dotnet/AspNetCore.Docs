

StringSegment Struct
====================





Namespace
    :dn:ns:`Microsoft.Extensions.Primitives.VSRC1`
Assemblies
    * Microsoft.Extensions.Primitives.VSRC1

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public struct StringSegment : IEquatable<StringSegment>, IEquatable<string>








.. dn:structure:: Microsoft.Extensions.Primitives.VSRC1.StringSegment
    :hidden:

.. dn:structure:: Microsoft.Extensions.Primitives.VSRC1.StringSegment

Properties
----------

.. dn:structure:: Microsoft.Extensions.Primitives.VSRC1.StringSegment
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Primitives.VSRC1.StringSegment.Buffer
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Buffer
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.Primitives.VSRC1.StringSegment.HasValue
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool HasValue
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.Primitives.VSRC1.StringSegment.Length
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Length
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.Primitives.VSRC1.StringSegment.Offset
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Offset
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.Primitives.VSRC1.StringSegment.Value
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Value
            {
                get;
            }
    

Constructors
------------

.. dn:structure:: Microsoft.Extensions.Primitives.VSRC1.StringSegment
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Primitives.VSRC1.StringSegment.StringSegment(System.String, System.Int32, System.Int32)
    
        
    
        
        :type buffer: System.String
    
        
        :type offset: System.Int32
    
        
        :type length: System.Int32
    
        
        .. code-block:: csharp
    
            public StringSegment(string buffer, int offset, int length)
    

Methods
-------

.. dn:structure:: Microsoft.Extensions.Primitives.VSRC1.StringSegment
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Primitives.VSRC1.StringSegment.EndsWith(System.String, System.StringComparison)
    
        
    
        
        :type text: System.String
    
        
        :type comparisonType: System.StringComparison
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool EndsWith(string text, StringComparison comparisonType)
    
    .. dn:method:: Microsoft.Extensions.Primitives.VSRC1.StringSegment.Equals(Microsoft.Extensions.Primitives.VSRC1.StringSegment)
    
        
    
        
        :type other: Microsoft.Extensions.Primitives.VSRC1.StringSegment
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Equals(StringSegment other)
    
    .. dn:method:: Microsoft.Extensions.Primitives.VSRC1.StringSegment.Equals(Microsoft.Extensions.Primitives.VSRC1.StringSegment, System.StringComparison)
    
        
    
        
        :type other: Microsoft.Extensions.Primitives.VSRC1.StringSegment
    
        
        :type comparisonType: System.StringComparison
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Equals(StringSegment other, StringComparison comparisonType)
    
    .. dn:method:: Microsoft.Extensions.Primitives.VSRC1.StringSegment.Equals(System.Object)
    
        
    
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.Extensions.Primitives.VSRC1.StringSegment.Equals(System.String)
    
        
    
        
        :type text: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Equals(string text)
    
    .. dn:method:: Microsoft.Extensions.Primitives.VSRC1.StringSegment.Equals(System.String, System.StringComparison)
    
        
    
        
        :type text: System.String
    
        
        :type comparisonType: System.StringComparison
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Equals(string text, StringComparison comparisonType)
    
    .. dn:method:: Microsoft.Extensions.Primitives.VSRC1.StringSegment.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    
    .. dn:method:: Microsoft.Extensions.Primitives.VSRC1.StringSegment.StartsWith(System.String, System.StringComparison)
    
        
    
        
        :type text: System.String
    
        
        :type comparisonType: System.StringComparison
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool StartsWith(string text, StringComparison comparisonType)
    
    .. dn:method:: Microsoft.Extensions.Primitives.VSRC1.StringSegment.Subsegment(System.Int32, System.Int32)
    
        
    
        
        :type offset: System.Int32
    
        
        :type length: System.Int32
        :rtype: Microsoft.Extensions.Primitives.VSRC1.StringSegment
    
        
        .. code-block:: csharp
    
            public StringSegment Subsegment(int offset, int length)
    
    .. dn:method:: Microsoft.Extensions.Primitives.VSRC1.StringSegment.Substring(System.Int32, System.Int32)
    
        
    
        
        :type offset: System.Int32
    
        
        :type length: System.Int32
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Substring(int offset, int length)
    
    .. dn:method:: Microsoft.Extensions.Primitives.VSRC1.StringSegment.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ToString()
    

