

StringSegment Struct
====================






An optimized representation of a substring.


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

    public struct StringSegment : IEquatable<StringSegment>, IEquatable<string>








.. dn:structure:: Microsoft.Extensions.Primitives.StringSegment
    :hidden:

.. dn:structure:: Microsoft.Extensions.Primitives.StringSegment

Constructors
------------

.. dn:structure:: Microsoft.Extensions.Primitives.StringSegment
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Primitives.StringSegment.StringSegment(System.String)
    
        
    
        
        Initializes an instance of the :any:`Microsoft.Extensions.Primitives.StringSegment` struct.
    
        
    
        
        :param buffer: 
            The original :any:`System.String`\. The :any:`Microsoft.Extensions.Primitives.StringSegment` includes the whole :any:`System.String`\.
        
        :type buffer: System.String
    
        
        .. code-block:: csharp
    
            public StringSegment(string buffer)
    
    .. dn:constructor:: Microsoft.Extensions.Primitives.StringSegment.StringSegment(System.String, System.Int32, System.Int32)
    
        
    
        
        Initializes an instance of the :any:`Microsoft.Extensions.Primitives.StringSegment` struct.
    
        
    
        
        :param buffer: The original :any:`System.String` used as buffer.
        
        :type buffer: System.String
    
        
        :param offset: The offset of the segment within the <em>buffer</em>.
        
        :type offset: System.Int32
    
        
        :param length: The length of the segment.
        
        :type length: System.Int32
    
        
        .. code-block:: csharp
    
            public StringSegment(string buffer, int offset, int length)
    

Properties
----------

.. dn:structure:: Microsoft.Extensions.Primitives.StringSegment
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Primitives.StringSegment.Buffer
    
        
    
        
        Gets the :any:`System.String` buffer for this :any:`Microsoft.Extensions.Primitives.StringSegment`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Buffer { get; }
    
    .. dn:property:: Microsoft.Extensions.Primitives.StringSegment.HasValue
    
        
    
        
        Gets whether or not this :any:`Microsoft.Extensions.Primitives.StringSegment` contains a valid value.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool HasValue { get; }
    
    .. dn:property:: Microsoft.Extensions.Primitives.StringSegment.Length
    
        
    
        
        Gets the length of this :any:`Microsoft.Extensions.Primitives.StringSegment`\.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Length { get; }
    
    .. dn:property:: Microsoft.Extensions.Primitives.StringSegment.Offset
    
        
    
        
        Gets the offset within the buffer for this :any:`Microsoft.Extensions.Primitives.StringSegment`\.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Offset { get; }
    
    .. dn:property:: Microsoft.Extensions.Primitives.StringSegment.Value
    
        
    
        
        Gets the value of this segment as a :any:`System.String`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Value { get; }
    

Operators
---------

.. dn:structure:: Microsoft.Extensions.Primitives.StringSegment
    :noindex:
    :hidden:

    
    .. dn:operator:: Microsoft.Extensions.Primitives.StringSegment.Equality(Microsoft.Extensions.Primitives.StringSegment, Microsoft.Extensions.Primitives.StringSegment)
    
        
    
        
        Checks if two specified :any:`Microsoft.Extensions.Primitives.StringSegment` have the same value.
    
        
    
        
        :param left: The first :any:`Microsoft.Extensions.Primitives.StringSegment` to compare, or <pre><code>null</code></pre>.
        
        :type left: Microsoft.Extensions.Primitives.StringSegment
    
        
        :param right: The second :any:`Microsoft.Extensions.Primitives.StringSegment` to compare, or <pre><code>null</code></pre>.
        
        :type right: Microsoft.Extensions.Primitives.StringSegment
        :rtype: System.Boolean
        :return: <pre>
            <code>true</code>
            </pre> if the value of <em>left</em> is the same as the value of <em>right</em>; otherwise, <pre><code>false</code></pre>.
    
        
        .. code-block:: csharp
    
            public static bool operator ==(StringSegment left, StringSegment right)
    
    .. dn:operator:: Microsoft.Extensions.Primitives.StringSegment.Inequality(Microsoft.Extensions.Primitives.StringSegment, Microsoft.Extensions.Primitives.StringSegment)
    
        
    
        
        Checks if two specified :any:`Microsoft.Extensions.Primitives.StringSegment` have different values.
    
        
    
        
        :param left: The first :any:`Microsoft.Extensions.Primitives.StringSegment` to compare, or <pre><code>null</code></pre>.
        
        :type left: Microsoft.Extensions.Primitives.StringSegment
    
        
        :param right: The second :any:`Microsoft.Extensions.Primitives.StringSegment` to compare, or <pre><code>null</code></pre>.
        
        :type right: Microsoft.Extensions.Primitives.StringSegment
        :rtype: System.Boolean
        :return: <pre>
            <code>true</code>
            </pre> if the value of <em>left</em> is different from the value of <em>right</em>; otherwise, <pre><code>false</code></pre>.
    
        
        .. code-block:: csharp
    
            public static bool operator !=(StringSegment left, StringSegment right)
    

Methods
-------

.. dn:structure:: Microsoft.Extensions.Primitives.StringSegment
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Primitives.StringSegment.EndsWith(System.String, System.StringComparison)
    
        
    
        
        Checks if the end of this :any:`Microsoft.Extensions.Primitives.StringSegment` matches the specified :any:`System.String` when compared using the specified <em>comparisonType</em>.
    
        
    
        
        :param text: The :any:`System.String`\to compare.
        
        :type text: System.String
    
        
        :param comparisonType: One of the enumeration values that specifies the rules to use in the comparison.
        
        :type comparisonType: System.StringComparison
        :rtype: System.Boolean
        :return: <pre>
            <code>true</code>
            </pre> if <em>text</em> matches the end of this :any:`Microsoft.Extensions.Primitives.StringSegment`\; otherwise, <pre><code>false</code></pre>.
    
        
        .. code-block:: csharp
    
            public bool EndsWith(string text, StringComparison comparisonType)
    
    .. dn:method:: Microsoft.Extensions.Primitives.StringSegment.Equals(Microsoft.Extensions.Primitives.StringSegment)
    
        
    
        
        Indicates whether the current object is equal to another object of the same type.
    
        
    
        
        :param other: An object to compare with this object.
        
        :type other: Microsoft.Extensions.Primitives.StringSegment
        :rtype: System.Boolean
        :return: <pre>
            <code>true</code>
            </pre> if the current object is equal to the other parameter; otherwise, <pre><code>false</code></pre>.
    
        
        .. code-block:: csharp
    
            public bool Equals(StringSegment other)
    
    .. dn:method:: Microsoft.Extensions.Primitives.StringSegment.Equals(Microsoft.Extensions.Primitives.StringSegment, System.StringComparison)
    
        
    
        
        Indicates whether the current object is equal to another object of the same type.
    
        
    
        
        :param other: An object to compare with this object.
        
        :type other: Microsoft.Extensions.Primitives.StringSegment
    
        
        :param comparisonType: One of the enumeration values that specifies the rules to use in the comparison.
        
        :type comparisonType: System.StringComparison
        :rtype: System.Boolean
        :return: <pre>
            <code>true</code>
            </pre> if the current object is equal to the other parameter; otherwise, <pre><code>false</code></pre>.
    
        
        .. code-block:: csharp
    
            public bool Equals(StringSegment other, StringComparison comparisonType)
    
    .. dn:method:: Microsoft.Extensions.Primitives.StringSegment.Equals(System.Object)
    
        
    
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.Extensions.Primitives.StringSegment.Equals(System.String)
    
        
    
        
        Checks if the specified :any:`System.String` is equal to the current :any:`Microsoft.Extensions.Primitives.StringSegment`\.
    
        
    
        
        :param text: The :any:`System.String` to compare with the current :any:`Microsoft.Extensions.Primitives.StringSegment`\.
        
        :type text: System.String
        :rtype: System.Boolean
        :return: <pre>
            <code>true</code>
            </pre> if the specified :any:`System.String` is equal to the current :any:`Microsoft.Extensions.Primitives.StringSegment`\; otherwise, <pre><code>false</code></pre>.
    
        
        .. code-block:: csharp
    
            public bool Equals(string text)
    
    .. dn:method:: Microsoft.Extensions.Primitives.StringSegment.Equals(System.String, System.StringComparison)
    
        
    
        
        Checks if the specified :any:`System.String` is equal to the current :any:`Microsoft.Extensions.Primitives.StringSegment`\.
    
        
    
        
        :param text: The :any:`System.String` to compare with the current :any:`Microsoft.Extensions.Primitives.StringSegment`\.
        
        :type text: System.String
    
        
        :param comparisonType: One of the enumeration values that specifies the rules to use in the comparison.
        
        :type comparisonType: System.StringComparison
        :rtype: System.Boolean
        :return: <pre>
            <code>true</code>
            </pre> if the specified :any:`System.String` is equal to the current :any:`Microsoft.Extensions.Primitives.StringSegment`\; otherwise, <pre><code>false</code></pre>.
    
        
        .. code-block:: csharp
    
            public bool Equals(string text, StringComparison comparisonType)
    
    .. dn:method:: Microsoft.Extensions.Primitives.StringSegment.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    
    .. dn:method:: Microsoft.Extensions.Primitives.StringSegment.IndexOf(System.Char)
    
        
    
        
        Gets the zero-based index of the first occurrence of the character <em>c</em> in this :any:`Microsoft.Extensions.Primitives.StringSegment`\.
    
        
    
        
        :param c: The Unicode character to seek.
        
        :type c: System.Char
        :rtype: System.Int32
        :return: The zero-based index position of <em>c</em> from the beginning of the :any:`Microsoft.Extensions.Primitives.StringSegment` if that character is found, or -1 if it is not.
    
        
        .. code-block:: csharp
    
            public int IndexOf(char c)
    
    .. dn:method:: Microsoft.Extensions.Primitives.StringSegment.IndexOf(System.Char, System.Int32)
    
        
    
        
        Gets the zero-based index of the first occurrence of the character <em>c</em> in this :any:`Microsoft.Extensions.Primitives.StringSegment`\.
        The search starts at <em>start</em>.
    
        
    
        
        :param c: The Unicode character to seek.
        
        :type c: System.Char
    
        
        :param start: The zero-based index position at which the search starts. 
        
        :type start: System.Int32
        :rtype: System.Int32
        :return: The zero-based index position of <em>c</em> from the beginning of the :any:`Microsoft.Extensions.Primitives.StringSegment` if that character is found, or -1 if it is not.
    
        
        .. code-block:: csharp
    
            public int IndexOf(char c, int start)
    
    .. dn:method:: Microsoft.Extensions.Primitives.StringSegment.IndexOf(System.Char, System.Int32, System.Int32)
    
        
    
        
        Gets the zero-based index of the first occurrence of the character <em>c</em> in this :any:`Microsoft.Extensions.Primitives.StringSegment`\.
        The search starts at <em>start</em> and examines a specified number of <em>count</em> character positions.
    
        
    
        
        :param c: The Unicode character to seek.
        
        :type c: System.Char
    
        
        :param start: The zero-based index position at which the search starts. 
        
        :type start: System.Int32
    
        
        :param count: The number of characters to examine.
        
        :type count: System.Int32
        :rtype: System.Int32
        :return: The zero-based index position of <em>c</em> from the beginning of the :any:`Microsoft.Extensions.Primitives.StringSegment` if that character is found, or -1 if it is not.
    
        
        .. code-block:: csharp
    
            public int IndexOf(char c, int start, int count)
    
    .. dn:method:: Microsoft.Extensions.Primitives.StringSegment.StartsWith(System.String, System.StringComparison)
    
        
    
        
        Checks if the beginning of this :any:`Microsoft.Extensions.Primitives.StringSegment` matches the specified :any:`System.String` when compared using the specified <em>comparisonType</em>.
    
        
    
        
        :param text: The :any:`System.String`\to compare.
        
        :type text: System.String
    
        
        :param comparisonType: One of the enumeration values that specifies the rules to use in the comparison.
        
        :type comparisonType: System.StringComparison
        :rtype: System.Boolean
        :return: <pre>
            <code>true</code>
            </pre> if <em>text</em> matches the beginning of this :any:`Microsoft.Extensions.Primitives.StringSegment`\; otherwise, <pre><code>false</code></pre>.
    
        
        .. code-block:: csharp
    
            public bool StartsWith(string text, StringComparison comparisonType)
    
    .. dn:method:: Microsoft.Extensions.Primitives.StringSegment.Subsegment(System.Int32, System.Int32)
    
        
    
        
        Retrieves a :any:`Microsoft.Extensions.Primitives.StringSegment` that represents a substring from this :any:`Microsoft.Extensions.Primitives.StringSegment`\.
        The :any:`Microsoft.Extensions.Primitives.StringSegment` starts at the position specified by <em>offset</em> and has the specified <em>length</em>.
    
        
    
        
        :param offset: The zero-based starting character position of a substring in this :any:`Microsoft.Extensions.Primitives.StringSegment`\.
        
        :type offset: System.Int32
    
        
        :param length: The number of characters in the substring.
        
        :type length: System.Int32
        :rtype: Microsoft.Extensions.Primitives.StringSegment
        :return: A :any:`Microsoft.Extensions.Primitives.StringSegment` that is equivalent to the substring of length <em>length</em> that begins at <em>offset</em> in this :any:`Microsoft.Extensions.Primitives.StringSegment`
    
        
        .. code-block:: csharp
    
            public StringSegment Subsegment(int offset, int length)
    
    .. dn:method:: Microsoft.Extensions.Primitives.StringSegment.Substring(System.Int32, System.Int32)
    
        
    
        
        Retrieves a substring from this :any:`Microsoft.Extensions.Primitives.StringSegment`\.
        The substring starts at the position specified by <em>offset</em> and has the specified <em>length</em>.
    
        
    
        
        :param offset: The zero-based starting character position of a substring in this :any:`Microsoft.Extensions.Primitives.StringSegment`\.
        
        :type offset: System.Int32
    
        
        :param length: The number of characters in the substring.
        
        :type length: System.Int32
        :rtype: System.String
        :return: A :any:`System.String` that is equivalent to the substring of length <em>length</em> that begins at <em>offset</em> in this :any:`Microsoft.Extensions.Primitives.StringSegment`
    
        
        .. code-block:: csharp
    
            public string Substring(int offset, int length)
    
    .. dn:method:: Microsoft.Extensions.Primitives.StringSegment.ToString()
    
        
    
        
        Returns the :any:`System.String` represented by this :any:`Microsoft.Extensions.Primitives.StringSegment` or <pre><code>String.Empty</code></pre> if the :any:`Microsoft.Extensions.Primitives.StringSegment` does not contain a value.
    
        
        :rtype: System.String
        :return: The :any:`System.String` represented by this :any:`Microsoft.Extensions.Primitives.StringSegment` or <pre><code>String.Empty</code></pre> if the :any:`Microsoft.Extensions.Primitives.StringSegment` does not contain a value.
    
        
        .. code-block:: csharp
    
            public override string ToString()
    
    .. dn:method:: Microsoft.Extensions.Primitives.StringSegment.Trim()
    
        
    
        
        Removes all leading and trailing whitespaces.
    
        
        :rtype: Microsoft.Extensions.Primitives.StringSegment
        :return: The trimmed :any:`Microsoft.Extensions.Primitives.StringSegment`\.
    
        
        .. code-block:: csharp
    
            public StringSegment Trim()
    
    .. dn:method:: Microsoft.Extensions.Primitives.StringSegment.TrimEnd()
    
        
    
        
        Removes all trailing whitespaces.
    
        
        :rtype: Microsoft.Extensions.Primitives.StringSegment
        :return: The trimmed :any:`Microsoft.Extensions.Primitives.StringSegment`\.
    
        
        .. code-block:: csharp
    
            public StringSegment TrimEnd()
    
    .. dn:method:: Microsoft.Extensions.Primitives.StringSegment.TrimStart()
    
        
    
        
        Removes all leading whitespaces.
    
        
        :rtype: Microsoft.Extensions.Primitives.StringSegment
        :return: The trimmed :any:`Microsoft.Extensions.Primitives.StringSegment`\.
    
        
        .. code-block:: csharp
    
            public StringSegment TrimStart()
    

