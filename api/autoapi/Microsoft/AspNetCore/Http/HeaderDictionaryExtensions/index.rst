

HeaderDictionaryExtensions Class
================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Http`
Assemblies
    * Microsoft.AspNetCore.Http.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Http.HeaderDictionaryExtensions`








Syntax
------

.. code-block:: csharp

    public class HeaderDictionaryExtensions








.. dn:class:: Microsoft.AspNetCore.Http.HeaderDictionaryExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.HeaderDictionaryExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Http.HeaderDictionaryExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.HeaderDictionaryExtensions.Append(Microsoft.AspNetCore.Http.IHeaderDictionary, System.String, Microsoft.Extensions.Primitives.StringValues)
    
        
    
        
        Add new values. Each item remains a separate array entry.
    
        
    
        
        :param headers: The :any:`Microsoft.AspNetCore.Http.IHeaderDictionary` to use.
        
        :type headers: Microsoft.AspNetCore.Http.IHeaderDictionary
    
        
        :param key: The header name.
        
        :type key: System.String
    
        
        :param value: The header value.
        
        :type value: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
            public static void Append(IHeaderDictionary headers, string key, StringValues value)
    
    .. dn:method:: Microsoft.AspNetCore.Http.HeaderDictionaryExtensions.AppendCommaSeparatedValues(Microsoft.AspNetCore.Http.IHeaderDictionary, System.String, System.String[])
    
        
    
        
        Quotes any values containing comas, and then coma joins all of the values with any existing values.
    
        
    
        
        :param headers: The :any:`Microsoft.AspNetCore.Http.IHeaderDictionary` to use.
        
        :type headers: Microsoft.AspNetCore.Http.IHeaderDictionary
    
        
        :param key: The header name.
        
        :type key: System.String
    
        
        :param values: The header values.
        
        :type values: System.String<System.String>[]
    
        
        .. code-block:: csharp
    
            public static void AppendCommaSeparatedValues(IHeaderDictionary headers, string key, params string[] values)
    
    .. dn:method:: Microsoft.AspNetCore.Http.HeaderDictionaryExtensions.GetCommaSeparatedValues(Microsoft.AspNetCore.Http.IHeaderDictionary, System.String)
    
        
    
        
        Get the associated values from the collection separated into individual values.
        Quoted values will not be split, and the quotes will be removed.
    
        
    
        
        :param headers: The :any:`Microsoft.AspNetCore.Http.IHeaderDictionary` to use.
        
        :type headers: Microsoft.AspNetCore.Http.IHeaderDictionary
    
        
        :param key: The header name.
        
        :type key: System.String
        :rtype: System.String<System.String>[]
        :return: the associated values from the collection separated into individual values, or StringValues.Empty if the key is not present.
    
        
        .. code-block:: csharp
    
            public static string[] GetCommaSeparatedValues(IHeaderDictionary headers, string key)
    
    .. dn:method:: Microsoft.AspNetCore.Http.HeaderDictionaryExtensions.SetCommaSeparatedValues(Microsoft.AspNetCore.Http.IHeaderDictionary, System.String, System.String[])
    
        
    
        
        Quotes any values containing comas, and then coma joins all of the values.
    
        
    
        
        :param headers: The :any:`Microsoft.AspNetCore.Http.IHeaderDictionary` to use.
        
        :type headers: Microsoft.AspNetCore.Http.IHeaderDictionary
    
        
        :param key: The header name.
        
        :type key: System.String
    
        
        :param values: The header values.
        
        :type values: System.String<System.String>[]
    
        
        .. code-block:: csharp
    
            public static void SetCommaSeparatedValues(IHeaderDictionary headers, string key, params string[] values)
    

