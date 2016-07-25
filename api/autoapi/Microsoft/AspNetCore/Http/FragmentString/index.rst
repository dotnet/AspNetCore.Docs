

FragmentString Struct
=====================






Provides correct handling for FragmentString value when needed to generate a URI string


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

    public struct FragmentString : IEquatable<FragmentString>








.. dn:structure:: Microsoft.AspNetCore.Http.FragmentString
    :hidden:

.. dn:structure:: Microsoft.AspNetCore.Http.FragmentString

Constructors
------------

.. dn:structure:: Microsoft.AspNetCore.Http.FragmentString
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Http.FragmentString.FragmentString(System.String)
    
        
    
        
        Initialize the fragment string with a given value. This value must be in escaped and delimited format with
        a leading '#' character.
    
        
    
        
        :param value: The fragment string to be assigned to the Value property.
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
            public FragmentString(string value)
    

Methods
-------

.. dn:structure:: Microsoft.AspNetCore.Http.FragmentString
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.FragmentString.Equals(Microsoft.AspNetCore.Http.FragmentString)
    
        
    
        
        :type other: Microsoft.AspNetCore.Http.FragmentString
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Equals(FragmentString other)
    
    .. dn:method:: Microsoft.AspNetCore.Http.FragmentString.Equals(System.Object)
    
        
    
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNetCore.Http.FragmentString.FromUriComponent(System.String)
    
        
    
        
        Returns an FragmentString given the fragment as it is escaped in the URI format. The string MUST NOT contain any
        value that is not a fragment.
    
        
    
        
        :param uriComponent: The escaped fragment as it appears in the URI format.
        
        :type uriComponent: System.String
        :rtype: Microsoft.AspNetCore.Http.FragmentString
        :return: The resulting FragmentString
    
        
        .. code-block:: csharp
    
            public static FragmentString FromUriComponent(string uriComponent)
    
    .. dn:method:: Microsoft.AspNetCore.Http.FragmentString.FromUriComponent(System.Uri)
    
        
    
        
        Returns an FragmentString given the fragment as from a Uri object. Relative Uri objects are not supported.
    
        
    
        
        :param uri: The Uri object
        
        :type uri: System.Uri
        :rtype: Microsoft.AspNetCore.Http.FragmentString
        :return: The resulting FragmentString
    
        
        .. code-block:: csharp
    
            public static FragmentString FromUriComponent(Uri uri)
    
    .. dn:method:: Microsoft.AspNetCore.Http.FragmentString.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNetCore.Http.FragmentString.ToString()
    
        
    
        
        Provides the fragment string escaped in a way which is correct for combining into the URI representation.
        A leading '#' character will be included unless the Value is null or empty. Characters which are potentially
        dangerous are escaped.
    
        
        :rtype: System.String
        :return: The fragment string value
    
        
        .. code-block:: csharp
    
            public override string ToString()
    
    .. dn:method:: Microsoft.AspNetCore.Http.FragmentString.ToUriComponent()
    
        
    
        
        Provides the fragment string escaped in a way which is correct for combining into the URI representation.
        A leading '#' character will be included unless the Value is null or empty. Characters which are potentially
        dangerous are escaped.
    
        
        :rtype: System.String
        :return: The fragment string value
    
        
        .. code-block:: csharp
    
            public string ToUriComponent()
    

Operators
---------

.. dn:structure:: Microsoft.AspNetCore.Http.FragmentString
    :noindex:
    :hidden:

    
    .. dn:operator:: Microsoft.AspNetCore.Http.FragmentString.Equality(Microsoft.AspNetCore.Http.FragmentString, Microsoft.AspNetCore.Http.FragmentString)
    
        
    
        
        :type left: Microsoft.AspNetCore.Http.FragmentString
    
        
        :type right: Microsoft.AspNetCore.Http.FragmentString
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool operator ==(FragmentString left, FragmentString right)
    
    .. dn:operator:: Microsoft.AspNetCore.Http.FragmentString.Inequality(Microsoft.AspNetCore.Http.FragmentString, Microsoft.AspNetCore.Http.FragmentString)
    
        
    
        
        :type left: Microsoft.AspNetCore.Http.FragmentString
    
        
        :type right: Microsoft.AspNetCore.Http.FragmentString
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool operator !=(FragmentString left, FragmentString right)
    

Fields
------

.. dn:structure:: Microsoft.AspNetCore.Http.FragmentString
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Http.FragmentString.Empty
    
        
    
        
        Represents the empty fragment string. This field is read-only.
    
        
        :rtype: Microsoft.AspNetCore.Http.FragmentString
    
        
        .. code-block:: csharp
    
            public static readonly FragmentString Empty
    

Properties
----------

.. dn:structure:: Microsoft.AspNetCore.Http.FragmentString
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.FragmentString.HasValue
    
        
    
        
        True if the fragment string is not empty
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool HasValue { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.FragmentString.Value
    
        
    
        
        The escaped fragment string with the leading '#' character
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Value { get; }
    

