

QueryString Struct
==================



.. contents:: 
   :local:



Summary
-------

Provides correct handling for QueryString value when needed to reconstruct a request or redirect URI string











Syntax
------

.. code-block:: csharp

   public struct QueryString : IEquatable<QueryString>





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.Http.Abstractions/QueryString.cs>`_





.. dn:structure:: Microsoft.AspNet.Http.QueryString

Constructors
------------

.. dn:structure:: Microsoft.AspNet.Http.QueryString
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Http.QueryString.QueryString(System.String)
    
        
    
        Initialize the query string with a given value. This value must be in escaped and delimited format with
        a leading '?' character.
    
        
        
        
        :param value: The query string to be assigned to the Value property.
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
           public QueryString(string value)
    

Methods
-------

.. dn:structure:: Microsoft.AspNet.Http.QueryString
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.QueryString.Add(Microsoft.AspNet.Http.QueryString)
    
        
        
        
        :type other: Microsoft.AspNet.Http.QueryString
        :rtype: Microsoft.AspNet.Http.QueryString
    
        
        .. code-block:: csharp
    
           public QueryString Add(QueryString other)
    
    .. dn:method:: Microsoft.AspNet.Http.QueryString.Add(System.String, System.String)
    
        
        
        
        :type name: System.String
        
        
        :type value: System.String
        :rtype: Microsoft.AspNet.Http.QueryString
    
        
        .. code-block:: csharp
    
           public QueryString Add(string name, string value)
    
    .. dn:method:: Microsoft.AspNet.Http.QueryString.Create(System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<System.String, Microsoft.Extensions.Primitives.StringValues>>)
    
        
    
        Creates a query string composed from the given name value pairs.
    
        
        
        
        :type parameters: System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String,Microsoft.Extensions.Primitives.StringValues}}
        :rtype: Microsoft.AspNet.Http.QueryString
        :return: The resulting QueryString
    
        
        .. code-block:: csharp
    
           public static QueryString Create(IEnumerable<KeyValuePair<string, StringValues>> parameters)
    
    .. dn:method:: Microsoft.AspNet.Http.QueryString.Create(System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<System.String, System.String>>)
    
        
    
        Creates a query string composed from the given name value pairs.
    
        
        
        
        :type parameters: System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String,System.String}}
        :rtype: Microsoft.AspNet.Http.QueryString
        :return: The resulting QueryString
    
        
        .. code-block:: csharp
    
           public static QueryString Create(IEnumerable<KeyValuePair<string, string>> parameters)
    
    .. dn:method:: Microsoft.AspNet.Http.QueryString.Create(System.String, System.String)
    
        
    
        Create a query string with a single given parameter name and value.
    
        
        
        
        :param name: The un-encoded parameter name
        
        :type name: System.String
        
        
        :param value: The un-encoded parameter value
        
        :type value: System.String
        :rtype: Microsoft.AspNet.Http.QueryString
        :return: The resulting QueryString
    
        
        .. code-block:: csharp
    
           public static QueryString Create(string name, string value)
    
    .. dn:method:: Microsoft.AspNet.Http.QueryString.Equals(Microsoft.AspNet.Http.QueryString)
    
        
        
        
        :type other: Microsoft.AspNet.Http.QueryString
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Equals(QueryString other)
    
    .. dn:method:: Microsoft.AspNet.Http.QueryString.Equals(System.Object)
    
        
        
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNet.Http.QueryString.FromUriComponent(System.String)
    
        
    
        Returns an QueryString given the query as it is escaped in the URI format. The string MUST NOT contain any
        value that is not a query.
    
        
        
        
        :param uriComponent: The escaped query as it appears in the URI format.
        
        :type uriComponent: System.String
        :rtype: Microsoft.AspNet.Http.QueryString
        :return: The resulting QueryString
    
        
        .. code-block:: csharp
    
           public static QueryString FromUriComponent(string uriComponent)
    
    .. dn:method:: Microsoft.AspNet.Http.QueryString.FromUriComponent(System.Uri)
    
        
    
        Returns an QueryString given the query as from a Uri object. Relative Uri objects are not supported.
    
        
        
        
        :param uri: The Uri object
        
        :type uri: System.Uri
        :rtype: Microsoft.AspNet.Http.QueryString
        :return: The resulting QueryString
    
        
        .. code-block:: csharp
    
           public static QueryString FromUriComponent(Uri uri)
    
    .. dn:method:: Microsoft.AspNet.Http.QueryString.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNet.Http.QueryString.ToString()
    
        
    
        Provides the query string escaped in a way which is correct for combining into the URI representation.
        A leading '?' character will be included unless the Value is null or empty. Characters which are potentially
        dangerous are escaped.
    
        
        :rtype: System.String
        :return: The query string value
    
        
        .. code-block:: csharp
    
           public override string ToString()
    
    .. dn:method:: Microsoft.AspNet.Http.QueryString.ToUriComponent()
    
        
    
        Provides the query string escaped in a way which is correct for combining into the URI representation.
        A leading '?' character will be included unless the Value is null or empty. Characters which are potentially
        dangerous are escaped.
    
        
        :rtype: System.String
        :return: The query string value
    
        
        .. code-block:: csharp
    
           public string ToUriComponent()
    

Fields
------

.. dn:structure:: Microsoft.AspNet.Http.QueryString
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Http.QueryString.Empty
    
        
    
        Represents the empty query string. This field is read-only.
    
        
    
        
        .. code-block:: csharp
    
           public static readonly QueryString Empty
    

Properties
----------

.. dn:structure:: Microsoft.AspNet.Http.QueryString
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.QueryString.HasValue
    
        
    
        True if the query string is not empty
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool HasValue { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.QueryString.Value
    
        
    
        The escaped query string with the leading '?' character
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Value { get; }
    

