

FormDataCollectionExtensions Class
==================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.WebApiCompatShim.FormDataCollectionExtensions`








Syntax
------

.. code-block:: csharp

   public class FormDataCollectionExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.WebApiCompatShim/FormDataCollectionExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.WebApiCompatShim.FormDataCollectionExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.WebApiCompatShim.FormDataCollectionExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.WebApiCompatShim.FormDataCollectionExtensions.GetJQueryNameValuePairs(System.Net.Http.Formatting.FormDataCollection)
    
        
        
        
        :type formData: System.Net.Http.Formatting.FormDataCollection
        :rtype: System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String,System.String}}
    
        
        .. code-block:: csharp
    
           public static IEnumerable<KeyValuePair<string, string>> GetJQueryNameValuePairs(FormDataCollection formData)
    
    .. dn:method:: Microsoft.AspNet.Mvc.WebApiCompatShim.FormDataCollectionExtensions.NormalizeJQueryToMvc(System.String)
    
        
        
        
        :type key: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public static string NormalizeJQueryToMvc(string key)
    

