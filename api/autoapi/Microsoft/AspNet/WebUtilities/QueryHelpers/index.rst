

QueryHelpers Class
==================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.WebUtilities.QueryHelpers`








Syntax
------

.. code-block:: csharp

   public class QueryHelpers





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.WebUtilities/QueryHelpers.cs>`_





.. dn:class:: Microsoft.AspNet.WebUtilities.QueryHelpers

Methods
-------

.. dn:class:: Microsoft.AspNet.WebUtilities.QueryHelpers
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.WebUtilities.QueryHelpers.AddQueryString(System.String, System.Collections.Generic.IDictionary<System.String, System.String>)
    
        
    
        Append the given query keys and values to the uri.
    
        
        
        
        :param uri: The base uri.
        
        :type uri: System.String
        
        
        :param queryString: A collection of name value query pairs to append.
        
        :type queryString: System.Collections.Generic.IDictionary{System.String,System.String}
        :rtype: System.String
        :return: The combined result.
    
        
        .. code-block:: csharp
    
           public static string AddQueryString(string uri, IDictionary<string, string> queryString)
    
    .. dn:method:: Microsoft.AspNet.WebUtilities.QueryHelpers.AddQueryString(System.String, System.String, System.String)
    
        
    
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
    
    .. dn:method:: Microsoft.AspNet.WebUtilities.QueryHelpers.ParseQuery(System.String)
    
        
    
        Parse a query string into its component key and value parts.
    
        
        
        
        :type queryString: System.String
        :rtype: System.Collections.Generic.IDictionary{System.String,Microsoft.Extensions.Primitives.StringValues}
        :return: A collection of parsed keys and values.
    
        
        .. code-block:: csharp
    
           public static IDictionary<string, StringValues> ParseQuery(string queryString)
    

