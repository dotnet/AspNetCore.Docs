

PathString Struct
=================



.. contents:: 
   :local:



Summary
-------

Provides correct escaping for Path and PathBase values when needed to reconstruct a request or redirect URI string











Syntax
------

.. code-block:: csharp

   public struct PathString : IEquatable<PathString>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Http.Abstractions/PathString.cs>`_





.. dn:structure:: Microsoft.AspNet.Http.PathString

Constructors
------------

.. dn:structure:: Microsoft.AspNet.Http.PathString
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Http.PathString.PathString(System.String)
    
        
    
        Initalize the path string with a given value. This value must be in unescaped format. Use
        PathString.FromUriComponent(value) if you have a path value which is in an escaped format.
    
        
        
        
        :param value: The unescaped path to be assigned to the Value property.
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
           public PathString(string value)
    

Methods
-------

.. dn:structure:: Microsoft.AspNet.Http.PathString
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.PathString.Add(Microsoft.AspNet.Http.PathString)
    
        
    
        Adds two PathString instances into a combined PathString value.
    
        
        
        
        :type other: Microsoft.AspNet.Http.PathString
        :rtype: Microsoft.AspNet.Http.PathString
        :return: The combined PathString value
    
        
        .. code-block:: csharp
    
           public PathString Add(PathString other)
    
    .. dn:method:: Microsoft.AspNet.Http.PathString.Add(Microsoft.AspNet.Http.QueryString)
    
        
    
        Combines a PathString and QueryString into the joined URI formatted string value.
    
        
        
        
        :type other: Microsoft.AspNet.Http.QueryString
        :rtype: System.String
        :return: The joined URI formatted string value
    
        
        .. code-block:: csharp
    
           public string Add(QueryString other)
    
    .. dn:method:: Microsoft.AspNet.Http.PathString.Equals(Microsoft.AspNet.Http.PathString)
    
        
    
        Compares this PathString value to another value. The default comparison is StringComparison.OrdinalIgnoreCase.
    
        
        
        
        :param other: The second PathString for comparison.
        
        :type other: Microsoft.AspNet.Http.PathString
        :rtype: System.Boolean
        :return: True if both PathString values are equal
    
        
        .. code-block:: csharp
    
           public bool Equals(PathString other)
    
    .. dn:method:: Microsoft.AspNet.Http.PathString.Equals(Microsoft.AspNet.Http.PathString, System.StringComparison)
    
        
    
        Compares this PathString value to another value using a specific StringComparison type
    
        
        
        
        :param other: The second PathString for comparison
        
        :type other: Microsoft.AspNet.Http.PathString
        
        
        :param comparisonType: The StringComparison type to use
        
        :type comparisonType: System.StringComparison
        :rtype: System.Boolean
        :return: True if both PathString values are equal
    
        
        .. code-block:: csharp
    
           public bool Equals(PathString other, StringComparison comparisonType)
    
    .. dn:method:: Microsoft.AspNet.Http.PathString.Equals(System.Object)
    
        
    
        Compares this PathString value to another value. The default comparison is StringComparison.OrdinalIgnoreCase.
    
        
        
        
        :param obj: The second PathString for comparison.
        
        :type obj: System.Object
        :rtype: System.Boolean
        :return: True if both PathString values are equal
    
        
        .. code-block:: csharp
    
           public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNet.Http.PathString.FromUriComponent(System.String)
    
        
    
        Returns an PathString given the path as it is escaped in the URI format. The string MUST NOT contain any
        value that is not a path.
    
        
        
        
        :param uriComponent: The escaped path as it appears in the URI format.
        
        :type uriComponent: System.String
        :rtype: Microsoft.AspNet.Http.PathString
        :return: The resulting PathString
    
        
        .. code-block:: csharp
    
           public static PathString FromUriComponent(string uriComponent)
    
    .. dn:method:: Microsoft.AspNet.Http.PathString.FromUriComponent(System.Uri)
    
        
    
        Returns an PathString given the path as from a Uri object. Relative Uri objects are not supported.
    
        
        
        
        :param uri: The Uri object
        
        :type uri: System.Uri
        :rtype: Microsoft.AspNet.Http.PathString
        :return: The resulting PathString
    
        
        .. code-block:: csharp
    
           public static PathString FromUriComponent(Uri uri)
    
    .. dn:method:: Microsoft.AspNet.Http.PathString.GetHashCode()
    
        
    
        Returns the hash code for the PathString value. The hash code is provided by the OrdinalIgnoreCase implementation.
    
        
        :rtype: System.Int32
        :return: The hash code
    
        
        .. code-block:: csharp
    
           public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNet.Http.PathString.StartsWithSegments(Microsoft.AspNet.Http.PathString)
    
        
    
        Determines whether the beginning of this :any:`Microsoft.AspNet.Http.PathString` instance matches the specified :any:`Microsoft.AspNet.Http.PathString`\.
    
        
        
        
        :param other: The  to compare.
        
        :type other: Microsoft.AspNet.Http.PathString
        :rtype: System.Boolean
        :return: true if value matches the beginning of this string; otherwise, false.
    
        
        .. code-block:: csharp
    
           public bool StartsWithSegments(PathString other)
    
    .. dn:method:: Microsoft.AspNet.Http.PathString.StartsWithSegments(Microsoft.AspNet.Http.PathString, out Microsoft.AspNet.Http.PathString)
    
        
    
        Determines whether the beginning of this PathString instance matches the specified :any:`Microsoft.AspNet.Http.PathString` when compared
        using the specified comparison option and returns the remaining segments.
    
        
        
        
        :param other: The  to compare.
        
        :type other: Microsoft.AspNet.Http.PathString
        
        
        :param remaining: The remaining segments after the match.
        
        :type remaining: Microsoft.AspNet.Http.PathString
        :rtype: System.Boolean
        :return: true if value matches the beginning of this string; otherwise, false.
    
        
        .. code-block:: csharp
    
           public bool StartsWithSegments(PathString other, out PathString remaining)
    
    .. dn:method:: Microsoft.AspNet.Http.PathString.StartsWithSegments(Microsoft.AspNet.Http.PathString, System.StringComparison)
    
        
    
        Determines whether the beginning of this :any:`Microsoft.AspNet.Http.PathString` instance matches the specified :any:`Microsoft.AspNet.Http.PathString` when compared
        using the specified comparison option.
    
        
        
        
        :param other: The  to compare.
        
        :type other: Microsoft.AspNet.Http.PathString
        
        
        :param comparisonType: One of the enumeration values that determines how this  and value are compared.
        
        :type comparisonType: System.StringComparison
        :rtype: System.Boolean
        :return: true if value matches the beginning of this string; otherwise, false.
    
        
        .. code-block:: csharp
    
           public bool StartsWithSegments(PathString other, StringComparison comparisonType)
    
    .. dn:method:: Microsoft.AspNet.Http.PathString.StartsWithSegments(Microsoft.AspNet.Http.PathString, System.StringComparison, out Microsoft.AspNet.Http.PathString)
    
        
    
        Determines whether the beginning of this :any:`Microsoft.AspNet.Http.PathString` instance matches the specified :any:`Microsoft.AspNet.Http.PathString` and returns
        the remaining segments.
    
        
        
        
        :param other: The  to compare.
        
        :type other: Microsoft.AspNet.Http.PathString
        
        
        :param comparisonType: One of the enumeration values that determines how this  and value are compared.
        
        :type comparisonType: System.StringComparison
        
        
        :param remaining: The remaining segments after the match.
        
        :type remaining: Microsoft.AspNet.Http.PathString
        :rtype: System.Boolean
        :return: true if value matches the beginning of this string; otherwise, false.
    
        
        .. code-block:: csharp
    
           public bool StartsWithSegments(PathString other, StringComparison comparisonType, out PathString remaining)
    
    .. dn:method:: Microsoft.AspNet.Http.PathString.ToString()
    
        
    
        Provides the path string escaped in a way which is correct for combining into the URI representation.
    
        
        :rtype: System.String
        :return: The escaped path value
    
        
        .. code-block:: csharp
    
           public override string ToString()
    
    .. dn:method:: Microsoft.AspNet.Http.PathString.ToUriComponent()
    
        
    
        Provides the path string escaped in a way which is correct for combining into the URI representation.
    
        
        :rtype: System.String
        :return: The escaped path value
    
        
        .. code-block:: csharp
    
           public string ToUriComponent()
    

Fields
------

.. dn:structure:: Microsoft.AspNet.Http.PathString
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Http.PathString.Empty
    
        
    
        Represents the empty path. This field is read-only.
    
        
    
        
        .. code-block:: csharp
    
           public static readonly PathString Empty
    

Properties
----------

.. dn:structure:: Microsoft.AspNet.Http.PathString
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.PathString.HasValue
    
        
    
        True if the path is not empty
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool HasValue { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.PathString.Value
    
        
    
        The unescaped path value
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Value { get; }
    

