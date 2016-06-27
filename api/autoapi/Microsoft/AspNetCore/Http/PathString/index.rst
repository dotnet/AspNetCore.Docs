

PathString Struct
=================






Provides correct escaping for Path and PathBase values when needed to reconstruct a request or redirect URI string


Namespace
    :dn:ns:`Microsoft.AspNetCore.Http`
Assemblies
    * Microsoft.AspNetCore.Http.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public struct PathString : IEquatable<PathString>








.. dn:structure:: Microsoft.AspNetCore.Http.PathString
    :hidden:

.. dn:structure:: Microsoft.AspNetCore.Http.PathString

Constructors
------------

.. dn:structure:: Microsoft.AspNetCore.Http.PathString
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Http.PathString.PathString(System.String)
    
        
    
        
        Initalize the path string with a given value. This value must be in unescaped format. Use
        PathString.FromUriComponent(value) if you have a path value which is in an escaped format.
    
        
    
        
        :param value: The unescaped path to be assigned to the Value property.
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
            public PathString(string value)
    

Methods
-------

.. dn:structure:: Microsoft.AspNetCore.Http.PathString
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.PathString.Add(Microsoft.AspNetCore.Http.PathString)
    
        
    
        
        Adds two PathString instances into a combined PathString value. 
    
        
    
        
        :type other: Microsoft.AspNetCore.Http.PathString
        :rtype: Microsoft.AspNetCore.Http.PathString
        :return: The combined PathString value
    
        
        .. code-block:: csharp
    
            public PathString Add(PathString other)
    
    .. dn:method:: Microsoft.AspNetCore.Http.PathString.Add(Microsoft.AspNetCore.Http.QueryString)
    
        
    
        
        Combines a PathString and QueryString into the joined URI formatted string value. 
    
        
    
        
        :type other: Microsoft.AspNetCore.Http.QueryString
        :rtype: System.String
        :return: The joined URI formatted string value
    
        
        .. code-block:: csharp
    
            public string Add(QueryString other)
    
    .. dn:method:: Microsoft.AspNetCore.Http.PathString.Equals(Microsoft.AspNetCore.Http.PathString)
    
        
    
        
        Compares this PathString value to another value. The default comparison is StringComparison.OrdinalIgnoreCase.
    
        
    
        
        :param other: The second PathString for comparison.
        
        :type other: Microsoft.AspNetCore.Http.PathString
        :rtype: System.Boolean
        :return: True if both PathString values are equal
    
        
        .. code-block:: csharp
    
            public bool Equals(PathString other)
    
    .. dn:method:: Microsoft.AspNetCore.Http.PathString.Equals(Microsoft.AspNetCore.Http.PathString, System.StringComparison)
    
        
    
        
        Compares this PathString value to another value using a specific StringComparison type
    
        
    
        
        :param other: The second PathString for comparison
        
        :type other: Microsoft.AspNetCore.Http.PathString
    
        
        :param comparisonType: The StringComparison type to use
        
        :type comparisonType: System.StringComparison
        :rtype: System.Boolean
        :return: True if both PathString values are equal
    
        
        .. code-block:: csharp
    
            public bool Equals(PathString other, StringComparison comparisonType)
    
    .. dn:method:: Microsoft.AspNetCore.Http.PathString.Equals(System.Object)
    
        
    
        
        Compares this PathString value to another value. The default comparison is StringComparison.OrdinalIgnoreCase.
    
        
    
        
        :param obj: The second PathString for comparison.
        
        :type obj: System.Object
        :rtype: System.Boolean
        :return: True if both PathString values are equal
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNetCore.Http.PathString.FromUriComponent(System.String)
    
        
    
        
        Returns an PathString given the path as it is escaped in the URI format. The string MUST NOT contain any
        value that is not a path.
    
        
    
        
        :param uriComponent: The escaped path as it appears in the URI format.
        
        :type uriComponent: System.String
        :rtype: Microsoft.AspNetCore.Http.PathString
        :return: The resulting PathString
    
        
        .. code-block:: csharp
    
            public static PathString FromUriComponent(string uriComponent)
    
    .. dn:method:: Microsoft.AspNetCore.Http.PathString.FromUriComponent(System.Uri)
    
        
    
        
        Returns an PathString given the path as from a Uri object. Relative Uri objects are not supported.
    
        
    
        
        :param uri: The Uri object
        
        :type uri: System.Uri
        :rtype: Microsoft.AspNetCore.Http.PathString
        :return: The resulting PathString
    
        
        .. code-block:: csharp
    
            public static PathString FromUriComponent(Uri uri)
    
    .. dn:method:: Microsoft.AspNetCore.Http.PathString.GetHashCode()
    
        
    
        
        Returns the hash code for the PathString value. The hash code is provided by the OrdinalIgnoreCase implementation.
    
        
        :rtype: System.Int32
        :return: The hash code
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNetCore.Http.PathString.StartsWithSegments(Microsoft.AspNetCore.Http.PathString)
    
        
    
        
        Determines whether the beginning of this :any:`Microsoft.AspNetCore.Http.PathString` instance matches the specified :any:`Microsoft.AspNetCore.Http.PathString`\.
    
        
    
        
        :param other: The :any:`Microsoft.AspNetCore.Http.PathString` to compare.
        
        :type other: Microsoft.AspNetCore.Http.PathString
        :rtype: System.Boolean
        :return: true if value matches the beginning of this string; otherwise, false.
    
        
        .. code-block:: csharp
    
            public bool StartsWithSegments(PathString other)
    
    .. dn:method:: Microsoft.AspNetCore.Http.PathString.StartsWithSegments(Microsoft.AspNetCore.Http.PathString, out Microsoft.AspNetCore.Http.PathString)
    
        
    
        
        Determines whether the beginning of this PathString instance matches the specified :any:`Microsoft.AspNetCore.Http.PathString` when compared
        using the specified comparison option and returns the remaining segments.
    
        
    
        
        :param other: The :any:`Microsoft.AspNetCore.Http.PathString` to compare.
        
        :type other: Microsoft.AspNetCore.Http.PathString
    
        
        :param remaining: The remaining segments after the match.
        
        :type remaining: Microsoft.AspNetCore.Http.PathString
        :rtype: System.Boolean
        :return: true if value matches the beginning of this string; otherwise, false.
    
        
        .. code-block:: csharp
    
            public bool StartsWithSegments(PathString other, out PathString remaining)
    
    .. dn:method:: Microsoft.AspNetCore.Http.PathString.StartsWithSegments(Microsoft.AspNetCore.Http.PathString, System.StringComparison)
    
        
    
        
        Determines whether the beginning of this :any:`Microsoft.AspNetCore.Http.PathString` instance matches the specified :any:`Microsoft.AspNetCore.Http.PathString` when compared
        using the specified comparison option.
    
        
    
        
        :param other: The :any:`Microsoft.AspNetCore.Http.PathString` to compare.
        
        :type other: Microsoft.AspNetCore.Http.PathString
    
        
        :param comparisonType: One of the enumeration values that determines how this :any:`Microsoft.AspNetCore.Http.PathString` and value are compared.
        
        :type comparisonType: System.StringComparison
        :rtype: System.Boolean
        :return: true if value matches the beginning of this string; otherwise, false.
    
        
        .. code-block:: csharp
    
            public bool StartsWithSegments(PathString other, StringComparison comparisonType)
    
    .. dn:method:: Microsoft.AspNetCore.Http.PathString.StartsWithSegments(Microsoft.AspNetCore.Http.PathString, System.StringComparison, out Microsoft.AspNetCore.Http.PathString)
    
        
    
        
        Determines whether the beginning of this :any:`Microsoft.AspNetCore.Http.PathString` instance matches the specified :any:`Microsoft.AspNetCore.Http.PathString` and returns
        the remaining segments.
    
        
    
        
        :param other: The :any:`Microsoft.AspNetCore.Http.PathString` to compare.
        
        :type other: Microsoft.AspNetCore.Http.PathString
    
        
        :param comparisonType: One of the enumeration values that determines how this :any:`Microsoft.AspNetCore.Http.PathString` and value are compared.
        
        :type comparisonType: System.StringComparison
    
        
        :param remaining: The remaining segments after the match.
        
        :type remaining: Microsoft.AspNetCore.Http.PathString
        :rtype: System.Boolean
        :return: true if value matches the beginning of this string; otherwise, false.
    
        
        .. code-block:: csharp
    
            public bool StartsWithSegments(PathString other, StringComparison comparisonType, out PathString remaining)
    
    .. dn:method:: Microsoft.AspNetCore.Http.PathString.ToString()
    
        
    
        
        Provides the path string escaped in a way which is correct for combining into the URI representation. 
    
        
        :rtype: System.String
        :return: The escaped path value
    
        
        .. code-block:: csharp
    
            public override string ToString()
    
    .. dn:method:: Microsoft.AspNetCore.Http.PathString.ToUriComponent()
    
        
    
        
        Provides the path string escaped in a way which is correct for combining into the URI representation.
    
        
        :rtype: System.String
        :return: The escaped path value
    
        
        .. code-block:: csharp
    
            public string ToUriComponent()
    

Operators
---------

.. dn:structure:: Microsoft.AspNetCore.Http.PathString
    :noindex:
    :hidden:

    
    .. dn:operator:: Microsoft.AspNetCore.Http.PathString.Addition(Microsoft.AspNetCore.Http.PathString, Microsoft.AspNetCore.Http.PathString)
    
        
    
        
        Operator call through to Add
    
        
    
        
        :param left: The left parameter
        
        :type left: Microsoft.AspNetCore.Http.PathString
    
        
        :param right: The right parameter
        
        :type right: Microsoft.AspNetCore.Http.PathString
        :rtype: Microsoft.AspNetCore.Http.PathString
        :return: The PathString combination of both values
    
        
        .. code-block:: csharp
    
            public static PathString operator +(PathString left, PathString right)
    
    .. dn:operator:: Microsoft.AspNetCore.Http.PathString.Addition(Microsoft.AspNetCore.Http.PathString, Microsoft.AspNetCore.Http.QueryString)
    
        
    
        
        Operator call through to Add
    
        
    
        
        :param left: The left parameter
        
        :type left: Microsoft.AspNetCore.Http.PathString
    
        
        :param right: The right parameter
        
        :type right: Microsoft.AspNetCore.Http.QueryString
        :rtype: System.String
        :return: The PathString combination of both values
    
        
        .. code-block:: csharp
    
            public static string operator +(PathString left, QueryString right)
    
    .. dn:operator:: Microsoft.AspNetCore.Http.PathString.Addition(Microsoft.AspNetCore.Http.PathString, System.String)
    
        
    
        
    
        
    
        
        :param left: The left parameter
        
        :type left: Microsoft.AspNetCore.Http.PathString
    
        
        :param right: The right parameter
        
        :type right: System.String
        :rtype: System.String
        :return: The ToString combination of both values
    
        
        .. code-block:: csharp
    
            public static string operator +(PathString left, string right)
    
    .. dn:operator:: Microsoft.AspNetCore.Http.PathString.Addition(System.String, Microsoft.AspNetCore.Http.PathString)
    
        
    
        
    
        
    
        
        :param left: The left parameter
        
        :type left: System.String
    
        
        :param right: The right parameter
        
        :type right: Microsoft.AspNetCore.Http.PathString
        :rtype: System.String
        :return: The ToString combination of both values
    
        
        .. code-block:: csharp
    
            public static string operator +(string left, PathString right)
    
    .. dn:operator:: Microsoft.AspNetCore.Http.PathString.Equality(Microsoft.AspNetCore.Http.PathString, Microsoft.AspNetCore.Http.PathString)
    
        
    
        
        Operator call through to Equals
    
        
    
        
        :param left: The left parameter
        
        :type left: Microsoft.AspNetCore.Http.PathString
    
        
        :param right: The right parameter
        
        :type right: Microsoft.AspNetCore.Http.PathString
        :rtype: System.Boolean
        :return: True if both PathString values are equal
    
        
        .. code-block:: csharp
    
            public static bool operator ==(PathString left, PathString right)
    
    .. dn:operator:: Microsoft.AspNetCore.Http.PathString.Implicit(Microsoft.AspNetCore.Http.PathString to System.String)
    
        
    
        
        Implicitly calls ToString().
    
        
    
        
        :type path: Microsoft.AspNetCore.Http.PathString
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static implicit operator string (PathString path)
    
    .. dn:operator:: Microsoft.AspNetCore.Http.PathString.Implicit(System.String to Microsoft.AspNetCore.Http.PathString)
    
        
    
        
        Implicitly creates a new PathString from the given string.
    
        
    
        
        :type s: System.String
        :rtype: Microsoft.AspNetCore.Http.PathString
    
        
        .. code-block:: csharp
    
            public static implicit operator PathString(string s)
    
    .. dn:operator:: Microsoft.AspNetCore.Http.PathString.Inequality(Microsoft.AspNetCore.Http.PathString, Microsoft.AspNetCore.Http.PathString)
    
        
    
        
        Operator call through to Equals
    
        
    
        
        :param left: The left parameter
        
        :type left: Microsoft.AspNetCore.Http.PathString
    
        
        :param right: The right parameter
        
        :type right: Microsoft.AspNetCore.Http.PathString
        :rtype: System.Boolean
        :return: True if both PathString values are not equal
    
        
        .. code-block:: csharp
    
            public static bool operator !=(PathString left, PathString right)
    

Fields
------

.. dn:structure:: Microsoft.AspNetCore.Http.PathString
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Http.PathString.Empty
    
        
    
        
        Represents the empty path. This field is read-only.
    
        
        :rtype: Microsoft.AspNetCore.Http.PathString
    
        
        .. code-block:: csharp
    
            public static readonly PathString Empty
    

Properties
----------

.. dn:structure:: Microsoft.AspNetCore.Http.PathString
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.PathString.HasValue
    
        
    
        
        True if the path is not empty
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool HasValue { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.PathString.Value
    
        
    
        
        The unescaped path value
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Value { get; }
    

