

HeaderDictionaryExtensions Class
================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.HeaderDictionaryExtensions`








Syntax
------

.. code-block:: csharp

   public class HeaderDictionaryExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.Http.Extensions/HeaderDictionaryExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Http.HeaderDictionaryExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Http.HeaderDictionaryExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.HeaderDictionaryExtensions.Append(Microsoft.AspNet.Http.IHeaderDictionary, System.String, Microsoft.Extensions.Primitives.StringValues)
    
        
    
        Add new values. Each item remains a separate array entry.
    
        
        
        
        :type headers: Microsoft.AspNet.Http.IHeaderDictionary
        
        
        :param key: The header name.
        
        :type key: System.String
        
        
        :param value: The header value.
        
        :type value: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public static void Append(IHeaderDictionary headers, string key, StringValues value)
    
    .. dn:method:: Microsoft.AspNet.Http.HeaderDictionaryExtensions.AppendCommaSeparatedValues(Microsoft.AspNet.Http.IHeaderDictionary, System.String, System.String[])
    
        
    
        Quotes any values containing comas, and then coma joins all of the values with any existing values.
    
        
        
        
        :type headers: Microsoft.AspNet.Http.IHeaderDictionary
        
        
        :param key: The header name.
        
        :type key: System.String
        
        
        :param values: The header values.
        
        :type values: System.String[]
    
        
        .. code-block:: csharp
    
           public static void AppendCommaSeparatedValues(IHeaderDictionary headers, string key, params string[] values)
    
    .. dn:method:: Microsoft.AspNet.Http.HeaderDictionaryExtensions.GetCommaSeparatedValues(Microsoft.AspNet.Http.IHeaderDictionary, System.String)
    
        
    
        Get the associated values from the collection separated into individual values.
        Quoted values will not be split, and the quotes will be removed.
    
        
        
        
        :type headers: Microsoft.AspNet.Http.IHeaderDictionary
        
        
        :param key: The header name.
        
        :type key: System.String
        :rtype: System.String[]
        :return: the associated values from the collection separated into individual values, or StringValues.Empty if the key is not present.
    
        
        .. code-block:: csharp
    
           public static string[] GetCommaSeparatedValues(IHeaderDictionary headers, string key)
    
    .. dn:method:: Microsoft.AspNet.Http.HeaderDictionaryExtensions.SetCommaSeparatedValues(Microsoft.AspNet.Http.IHeaderDictionary, System.String, System.String[])
    
        
    
        Quotes any values containing comas, and then coma joins all of the values.
    
        
        
        
        :type headers: Microsoft.AspNet.Http.IHeaderDictionary
        
        
        :param key: The header name.
        
        :type key: System.String
        
        
        :param values: The header values.
        
        :type values: System.String[]
    
        
        .. code-block:: csharp
    
           public static void SetCommaSeparatedValues(IHeaderDictionary headers, string key, params string[] values)
    

