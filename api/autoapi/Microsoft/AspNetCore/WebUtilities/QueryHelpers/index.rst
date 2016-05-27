

QueryHelpers Class
==================





Namespace
    :dn:ns:`Microsoft.AspNetCore.WebUtilities`
Assemblies
    * Microsoft.AspNetCore.WebUtilities

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.WebUtilities.QueryHelpers`








Syntax
------

.. code-block:: csharp

    public class QueryHelpers








.. dn:class:: Microsoft.AspNetCore.WebUtilities.QueryHelpers
    :hidden:

.. dn:class:: Microsoft.AspNetCore.WebUtilities.QueryHelpers

Methods
-------

.. dn:class:: Microsoft.AspNetCore.WebUtilities.QueryHelpers
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.QueryHelpers.AddQueryString(System.String, System.Collections.Generic.IDictionary<System.String, System.String>)
    
        
    
        
        Append the given query keys and values to the uri.
    
        
    
        
        :param uri: The base uri.
        
        :type uri: System.String
    
        
        :param queryString: A collection of name value query pairs to append.
        
        :type queryString: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.String<System.String>}
        :rtype: System.String
        :return: The combined result.
    
        
        .. code-block:: csharp
    
            public static string AddQueryString(string uri, IDictionary<string, string> queryString)
    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.QueryHelpers.AddQueryString(System.String, System.String, System.String)
    
        
    
        
        Append the given query key and value to the URI.
    
        
    
        
        :param uri: The base URI.
        
        :type uri: System.String
    
        
        :param name: The name of the query key.
        
        :type name: System.String
    
        
        :param value: The query value.
        
        :type value: System.String
        :rtype: System.String
        :return: The combined result.
    
        
        .. code-block:: csharp
    
            public static string AddQueryString(string uri, string name, string value)
    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseNullableQuery(System.String)
    
        
    
        
        Parse a query string into its component key and value parts.
    
        
    
        
        :param queryString: The raw query string value, with or without the leading '?'.
        
        :type queryString: System.String
        :rtype: System.Collections.Generic.Dictionary<System.Collections.Generic.Dictionary`2>{System.String<System.String>, Microsoft.Extensions.Primitives.StringValues<Microsoft.Extensions.Primitives.StringValues>}
        :return: A collection of parsed keys and values, null if there are no entries.
    
        
        .. code-block:: csharp
    
            public static Dictionary<string, StringValues> ParseNullableQuery(string queryString)
    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(System.String)
    
        
    
        
        Parse a query string into its component key and value parts.
    
        
    
        
        :param queryString: The raw query string value, with or without the leading '?'.
        
        :type queryString: System.String
        :rtype: System.Collections.Generic.Dictionary<System.Collections.Generic.Dictionary`2>{System.String<System.String>, Microsoft.Extensions.Primitives.StringValues<Microsoft.Extensions.Primitives.StringValues>}
        :return: A collection of parsed keys and values.
    
        
        .. code-block:: csharp
    
            public static Dictionary<string, StringValues> ParseQuery(string queryString)
    

