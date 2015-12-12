

FragmentString Struct
=====================



.. contents:: 
   :local:



Summary
-------

Provides correct handling for FragmentString value when needed to generate a URI string











Syntax
------

.. code-block:: csharp

   public struct FragmentString : IEquatable<FragmentString>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Http.Abstractions/FragmentString.cs>`_





.. dn:structure:: Microsoft.AspNet.Http.FragmentString

Constructors
------------

.. dn:structure:: Microsoft.AspNet.Http.FragmentString
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Http.FragmentString.FragmentString(System.String)
    
        
    
        Initialize the fragment string with a given value. This value must be in escaped and delimited format with
        a leading '#' character.
    
        
        
        
        :param value: The fragment string to be assigned to the Value property.
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
           public FragmentString(string value)
    

Methods
-------

.. dn:structure:: Microsoft.AspNet.Http.FragmentString
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.FragmentString.Equals(Microsoft.AspNet.Http.FragmentString)
    
        
        
        
        :type other: Microsoft.AspNet.Http.FragmentString
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Equals(FragmentString other)
    
    .. dn:method:: Microsoft.AspNet.Http.FragmentString.Equals(System.Object)
    
        
        
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNet.Http.FragmentString.FromUriComponent(System.String)
    
        
    
        Returns an FragmentString given the fragment as it is escaped in the URI format. The string MUST NOT contain any
        value that is not a fragment.
    
        
        
        
        :param uriComponent: The escaped fragment as it appears in the URI format.
        
        :type uriComponent: System.String
        :rtype: Microsoft.AspNet.Http.FragmentString
        :return: The resulting FragmentString
    
        
        .. code-block:: csharp
    
           public static FragmentString FromUriComponent(string uriComponent)
    
    .. dn:method:: Microsoft.AspNet.Http.FragmentString.FromUriComponent(System.Uri)
    
        
    
        Returns an FragmentString given the fragment as from a Uri object. Relative Uri objects are not supported.
    
        
        
        
        :param uri: The Uri object
        
        :type uri: System.Uri
        :rtype: Microsoft.AspNet.Http.FragmentString
        :return: The resulting FragmentString
    
        
        .. code-block:: csharp
    
           public static FragmentString FromUriComponent(Uri uri)
    
    .. dn:method:: Microsoft.AspNet.Http.FragmentString.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNet.Http.FragmentString.ToString()
    
        
    
        Provides the fragment string escaped in a way which is correct for combining into the URI representation.
        A leading '#' character will be included unless the Value is null or empty. Characters which are potentially
        dangerous are escaped.
    
        
        :rtype: System.String
        :return: The fragment string value
    
        
        .. code-block:: csharp
    
           public override string ToString()
    
    .. dn:method:: Microsoft.AspNet.Http.FragmentString.ToUriComponent()
    
        
    
        Provides the fragment string escaped in a way which is correct for combining into the URI representation.
        A leading '#' character will be included unless the Value is null or empty. Characters which are potentially
        dangerous are escaped.
    
        
        :rtype: System.String
        :return: The fragment string value
    
        
        .. code-block:: csharp
    
           public string ToUriComponent()
    

Fields
------

.. dn:structure:: Microsoft.AspNet.Http.FragmentString
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Http.FragmentString.Empty
    
        
    
        Represents the empty fragment string. This field is read-only.
    
        
    
        
        .. code-block:: csharp
    
           public static readonly FragmentString Empty
    

Properties
----------

.. dn:structure:: Microsoft.AspNet.Http.FragmentString
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.FragmentString.HasValue
    
        
    
        True if the fragment string is not empty
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool HasValue { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.FragmentString.Value
    
        
    
        The escaped fragment string with the leading '#' character
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Value { get; }
    

