

FormDataCollectionExtensions Class
==================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.WebApiCompatShim`
Assemblies
    * Microsoft.AspNetCore.Mvc.WebApiCompatShim

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.WebApiCompatShim.FormDataCollectionExtensions`








Syntax
------

.. code-block:: csharp

    public class FormDataCollectionExtensions








.. dn:class:: Microsoft.AspNetCore.Mvc.WebApiCompatShim.FormDataCollectionExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.WebApiCompatShim.FormDataCollectionExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.WebApiCompatShim.FormDataCollectionExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.WebApiCompatShim.FormDataCollectionExtensions.GetJQueryNameValuePairs(System.Net.Http.Formatting.FormDataCollection)
    
        
    
        
        :type formData: System.Net.Http.Formatting.FormDataCollection
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, System.String<System.String>}}
    
        
        .. code-block:: csharp
    
            public static IEnumerable<KeyValuePair<string, string>> GetJQueryNameValuePairs(FormDataCollection formData)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.WebApiCompatShim.FormDataCollectionExtensions.NormalizeJQueryToMvc(System.String)
    
        
    
        
        :type key: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string NormalizeJQueryToMvc(string key)
    

