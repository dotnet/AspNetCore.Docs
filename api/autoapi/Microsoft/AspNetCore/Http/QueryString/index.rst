

QueryString Struct
==================






Provides correct handling for QueryString value when needed to reconstruct a request or redirect URI string


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

    public struct QueryString : IEquatable<QueryString>








.. dn:structure:: Microsoft.AspNetCore.Http.QueryString
    :hidden:

.. dn:structure:: Microsoft.AspNetCore.Http.QueryString

Properties
----------

.. dn:structure:: Microsoft.AspNetCore.Http.QueryString
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.QueryString.HasValue
    
        
    
        
        True if the query string is not empty
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool HasValue
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.QueryString.Value
    
        
    
        
        The escaped query string with the leading '?' character
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Value
            {
                get;
            }
    

Constructors
------------

.. dn:structure:: Microsoft.AspNetCore.Http.QueryString
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Http.QueryString.QueryString(System.String)
    
        
    
        
        Initialize the query string with a given value. This value must be in escaped and delimited format with
        a leading '?' character. 
    
        
    
        
        :param value: The query string to be assigned to the Value property.
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
            public QueryString(string value)
    

Fields
------

.. dn:structure:: Microsoft.AspNetCore.Http.QueryString
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Http.QueryString.Empty
    
        
    
        
        Represents the empty query string. This field is read-only.
    
        
        :rtype: Microsoft.AspNetCore.Http.QueryString
    
        
        .. code-block:: csharp
    
            public static readonly QueryString Empty
    

Methods
-------

.. dn:structure:: Microsoft.AspNetCore.Http.QueryString
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.QueryString.Add(Microsoft.AspNetCore.Http.QueryString)
    
        
    
        
        :type other: Microsoft.AspNetCore.Http.QueryString
        :rtype: Microsoft.AspNetCore.Http.QueryString
    
        
        .. code-block:: csharp
    
            public QueryString Add(QueryString other)
    
    .. dn:method:: Microsoft.AspNetCore.Http.QueryString.Add(System.String, System.String)
    
        
    
        
        :type name: System.String
    
        
        :type value: System.String
        :rtype: Microsoft.AspNetCore.Http.QueryString
    
        
        .. code-block:: csharp
    
            public QueryString Add(string name, string value)
    
    .. dn:method:: Microsoft.AspNetCore.Http.QueryString.Create(System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<System.String, Microsoft.Extensions.Primitives.StringValues>>)
    
        
    
        
        Creates a query string composed from the given name value pairs.
    
        
    
        
        :type parameters: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, Microsoft.Extensions.Primitives.StringValues<Microsoft.Extensions.Primitives.StringValues>}}
        :rtype: Microsoft.AspNetCore.Http.QueryString
        :return: The resulting QueryString
    
        
        .. code-block:: csharp
    
            public static QueryString Create(IEnumerable<KeyValuePair<string, StringValues>> parameters)
    
    .. dn:method:: Microsoft.AspNetCore.Http.QueryString.Create(System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<System.String, System.String>>)
    
        
    
        
        Creates a query string composed from the given name value pairs.
    
        
    
        
        :type parameters: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, System.String<System.String>}}
        :rtype: Microsoft.AspNetCore.Http.QueryString
        :return: The resulting QueryString
    
        
        .. code-block:: csharp
    
            public static QueryString Create(IEnumerable<KeyValuePair<string, string>> parameters)
    
    .. dn:method:: Microsoft.AspNetCore.Http.QueryString.Create(System.String, System.String)
    
        
    
        
        Create a query string with a single given parameter name and value.
    
        
    
        
        :param name: The un-encoded parameter name
        
        :type name: System.String
    
        
        :param value: The un-encoded parameter value
        
        :type value: System.String
        :rtype: Microsoft.AspNetCore.Http.QueryString
        :return: The resulting QueryString
    
        
        .. code-block:: csharp
    
            public static QueryString Create(string name, string value)
    
    .. dn:method:: Microsoft.AspNetCore.Http.QueryString.Equals(Microsoft.AspNetCore.Http.QueryString)
    
        
    
        
        :type other: Microsoft.AspNetCore.Http.QueryString
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Equals(QueryString other)
    
    .. dn:method:: Microsoft.AspNetCore.Http.QueryString.Equals(System.Object)
    
        
    
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNetCore.Http.QueryString.FromUriComponent(System.String)
    
        
    
        
        Returns an QueryString given the query as it is escaped in the URI format. The string MUST NOT contain any
        value that is not a query.
    
        
    
        
        :param uriComponent: The escaped query as it appears in the URI format.
        
        :type uriComponent: System.String
        :rtype: Microsoft.AspNetCore.Http.QueryString
        :return: The resulting QueryString
    
        
        .. code-block:: csharp
    
            public static QueryString FromUriComponent(string uriComponent)
    
    .. dn:method:: Microsoft.AspNetCore.Http.QueryString.FromUriComponent(System.Uri)
    
        
    
        
        Returns an QueryString given the query as from a Uri object. Relative Uri objects are not supported.
    
        
    
        
        :param uri: The Uri object
        
        :type uri: System.Uri
        :rtype: Microsoft.AspNetCore.Http.QueryString
        :return: The resulting QueryString
    
        
        .. code-block:: csharp
    
            public static QueryString FromUriComponent(Uri uri)
    
    .. dn:method:: Microsoft.AspNetCore.Http.QueryString.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNetCore.Http.QueryString.ToString()
    
        
    
        
        Provides the query string escaped in a way which is correct for combining into the URI representation. 
        A leading '?' character will be included unless the Value is null or empty. Characters which are potentially
        dangerous are escaped.
    
        
        :rtype: System.String
        :return: The query string value
    
        
        .. code-block:: csharp
    
            public override string ToString()
    
    .. dn:method:: Microsoft.AspNetCore.Http.QueryString.ToUriComponent()
    
        
    
        
        Provides the query string escaped in a way which is correct for combining into the URI representation. 
        A leading '?' character will be included unless the Value is null or empty. Characters which are potentially
        dangerous are escaped.
    
        
        :rtype: System.String
        :return: The query string value
    
        
        .. code-block:: csharp
    
            public string ToUriComponent()
    

