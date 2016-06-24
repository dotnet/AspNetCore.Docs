

SourceLocation Struct
=====================






A location in a Razor file.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    [Serializable]
    public struct SourceLocation : IEquatable<SourceLocation>, IComparable<SourceLocation>








.. dn:structure:: Microsoft.AspNetCore.Razor.SourceLocation
    :hidden:

.. dn:structure:: Microsoft.AspNetCore.Razor.SourceLocation

Constructors
------------

.. dn:structure:: Microsoft.AspNetCore.Razor.SourceLocation
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.SourceLocation.SourceLocation(System.Int32, System.Int32, System.Int32)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Razor.SourceLocation`\.
    
        
    
        
        :param absoluteIndex: The absolute index.
        
        :type absoluteIndex: System.Int32
    
        
        :param lineIndex: The line index.
        
        :type lineIndex: System.Int32
    
        
        :param characterIndex: The character index.
        
        :type characterIndex: System.Int32
    
        
        .. code-block:: csharp
    
            public SourceLocation(int absoluteIndex, int lineIndex, int characterIndex)
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.SourceLocation.SourceLocation(System.String, System.Int32, System.Int32, System.Int32)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Razor.SourceLocation`\.
    
        
    
        
        :param filePath: The file path.
        
        :type filePath: System.String
    
        
        :param absoluteIndex: The absolute index.
        
        :type absoluteIndex: System.Int32
    
        
        :param lineIndex: The line index.
        
        :type lineIndex: System.Int32
    
        
        :param characterIndex: The character index.
        
        :type characterIndex: System.Int32
    
        
        .. code-block:: csharp
    
            public SourceLocation(string filePath, int absoluteIndex, int lineIndex, int characterIndex)
    

Properties
----------

.. dn:structure:: Microsoft.AspNetCore.Razor.SourceLocation
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.SourceLocation.AbsoluteIndex
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int AbsoluteIndex { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.SourceLocation.CharacterIndex
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int CharacterIndex { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.SourceLocation.FilePath
    
        
    
        
        Path of the file.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string FilePath { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.SourceLocation.LineIndex
    
        
    
        
        Gets the 1-based index of the line referred to by this Source Location.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int LineIndex { get; set; }
    

Operators
---------

.. dn:structure:: Microsoft.AspNetCore.Razor.SourceLocation
    :noindex:
    :hidden:

    
    .. dn:operator:: Microsoft.AspNetCore.Razor.SourceLocation.Addition(Microsoft.AspNetCore.Razor.SourceLocation, Microsoft.AspNetCore.Razor.SourceLocation)
    
        
    
        
        Adds two :any:`Microsoft.AspNetCore.Razor.SourceLocation`\s.
    
        
    
        
        :param left: The left operand.
        
        :type left: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        :param right: The right operand.
        
        :type right: Microsoft.AspNetCore.Razor.SourceLocation
        :rtype: Microsoft.AspNetCore.Razor.SourceLocation
        :return: A :any:`Microsoft.AspNetCore.Razor.SourceLocation` that is the sum of the left and right operands.
    
        
        .. code-block:: csharp
    
            public static SourceLocation operator +(SourceLocation left, SourceLocation right)
    
    .. dn:operator:: Microsoft.AspNetCore.Razor.SourceLocation.Equality(Microsoft.AspNetCore.Razor.SourceLocation, Microsoft.AspNetCore.Razor.SourceLocation)
    
        
    
        
        Determines whether the operands are equal.
    
        
    
        
        :param left: The left operand.
        
        :type left: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        :param right: The right operand.
        
        :type right: Microsoft.AspNetCore.Razor.SourceLocation
        :rtype: System.Boolean
        :return: <code>true</code> if <em>left</em> and <em>right</em> are equal.
    
        
        .. code-block:: csharp
    
            public static bool operator ==(SourceLocation left, SourceLocation right)
    
    .. dn:operator:: Microsoft.AspNetCore.Razor.SourceLocation.GreaterThan(Microsoft.AspNetCore.Razor.SourceLocation, Microsoft.AspNetCore.Razor.SourceLocation)
    
        
    
        
        Determines whether the first operand is greater than the second operand.
    
        
    
        
        :param left: The left operand.
        
        :type left: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        :param right: The right operand.
        
        :type right: Microsoft.AspNetCore.Razor.SourceLocation
        :rtype: System.Boolean
        :return: <code>true</code> if <em>left</em> is greater than <em>right</em>.
    
        
        .. code-block:: csharp
    
            public static bool operator>(SourceLocation left, SourceLocation right)
    
    .. dn:operator:: Microsoft.AspNetCore.Razor.SourceLocation.Inequality(Microsoft.AspNetCore.Razor.SourceLocation, Microsoft.AspNetCore.Razor.SourceLocation)
    
        
    
        
        Determines whether the operands are not equal.
    
        
    
        
        :param left: The left operand.
        
        :type left: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        :param right: The right operand.
        
        :type right: Microsoft.AspNetCore.Razor.SourceLocation
        :rtype: System.Boolean
        :return: <code>true</code> if <em>left</em> and <em>right</em> are not equal.
    
        
        .. code-block:: csharp
    
            public static bool operator !=(SourceLocation left, SourceLocation right)
    
    .. dn:operator:: Microsoft.AspNetCore.Razor.SourceLocation.LessThan(Microsoft.AspNetCore.Razor.SourceLocation, Microsoft.AspNetCore.Razor.SourceLocation)
    
        
    
        
        Determines whether the first operand is less than the second operand.
    
        
    
        
        :param left: The left operand.
        
        :type left: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        :param right: The right operand.
        
        :type right: Microsoft.AspNetCore.Razor.SourceLocation
        :rtype: System.Boolean
        :return: <code>true</code> if <em>left</em> is less than <em>right</em>.
    
        
        .. code-block:: csharp
    
            public static bool operator <(SourceLocation left, SourceLocation right)
    
    .. dn:operator:: Microsoft.AspNetCore.Razor.SourceLocation.Subtraction(Microsoft.AspNetCore.Razor.SourceLocation, Microsoft.AspNetCore.Razor.SourceLocation)
    
        
    
        
        Subtracts two :any:`Microsoft.AspNetCore.Razor.SourceLocation`\s.
    
        
    
        
        :param left: The left operand.
        
        :type left: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        :param right: The right operand.
        
        :type right: Microsoft.AspNetCore.Razor.SourceLocation
        :rtype: Microsoft.AspNetCore.Razor.SourceLocation
        :return: A :any:`Microsoft.AspNetCore.Razor.SourceLocation` that is the difference of the left and right operands.
    
        
        .. code-block:: csharp
    
            public static SourceLocation operator -(SourceLocation left, SourceLocation right)
    

Methods
-------

.. dn:structure:: Microsoft.AspNetCore.Razor.SourceLocation
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.SourceLocation.Advance(Microsoft.AspNetCore.Razor.SourceLocation, System.String)
    
        
    
        
        Advances the :any:`Microsoft.AspNetCore.Razor.SourceLocation` by the length of the <em>text</em>.
    
        
    
        
        :param left: The :any:`Microsoft.AspNetCore.Razor.SourceLocation` to advance.
        
        :type left: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        :param text: The :any:`System.String` to advance <em>left</em> by.
        
        :type text: System.String
        :rtype: Microsoft.AspNetCore.Razor.SourceLocation
        :return: The advanced :any:`Microsoft.AspNetCore.Razor.SourceLocation`\.
    
        
        .. code-block:: csharp
    
            public static SourceLocation Advance(SourceLocation left, string text)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.SourceLocation.CompareTo(Microsoft.AspNetCore.Razor.SourceLocation)
    
        
    
        
        :type other: Microsoft.AspNetCore.Razor.SourceLocation
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int CompareTo(SourceLocation other)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.SourceLocation.Equals(Microsoft.AspNetCore.Razor.SourceLocation)
    
        
    
        
        :type other: Microsoft.AspNetCore.Razor.SourceLocation
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Equals(SourceLocation other)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.SourceLocation.Equals(System.Object)
    
        
    
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.SourceLocation.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.SourceLocation.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ToString()
    

Fields
------

.. dn:structure:: Microsoft.AspNetCore.Razor.SourceLocation
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Razor.SourceLocation.Undefined
    
        
    
        
        An undefined :any:`Microsoft.AspNetCore.Razor.SourceLocation`\.
    
        
        :rtype: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
            public static readonly SourceLocation Undefined
    
    .. dn:field:: Microsoft.AspNetCore.Razor.SourceLocation.Zero
    
        
    
        
        A :any:`Microsoft.AspNetCore.Razor.SourceLocation` with :dn:prop:`Microsoft.AspNetCore.Razor.SourceLocation.AbsoluteIndex`\, :dn:prop:`Microsoft.AspNetCore.Razor.SourceLocation.LineIndex`\, and 
        :dn:prop:`Microsoft.AspNetCore.Razor.SourceLocation.CharacterIndex` initialized to 0.
    
        
        :rtype: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
            public static readonly SourceLocation Zero
    

