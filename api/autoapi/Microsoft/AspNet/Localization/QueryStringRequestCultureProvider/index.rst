

QueryStringRequestCultureProvider Class
=======================================



.. contents:: 
   :local:



Summary
-------

Determines the culture information for a request via values in the query string.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Localization.RequestCultureProvider`
* :dn:cls:`Microsoft.AspNet.Localization.QueryStringRequestCultureProvider`








Syntax
------

.. code-block:: csharp

   public class QueryStringRequestCultureProvider : RequestCultureProvider, IRequestCultureProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/localization/blob/master/src/Microsoft.AspNet.Localization/QueryStringRequestCultureProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Localization.QueryStringRequestCultureProvider

Methods
-------

.. dn:class:: Microsoft.AspNet.Localization.QueryStringRequestCultureProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Localization.QueryStringRequestCultureProvider.DetermineProviderCultureResult(Microsoft.AspNet.Http.HttpContext)
    
        
        
        
        :type httpContext: Microsoft.AspNet.Http.HttpContext
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Localization.ProviderCultureResult}
    
        
        .. code-block:: csharp
    
           public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Localization.QueryStringRequestCultureProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Localization.QueryStringRequestCultureProvider.QueryStringKey
    
        
    
        The key that contains the culture name.
        Defaults to "culture".
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string QueryStringKey { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Localization.QueryStringRequestCultureProvider.UIQueryStringKey
    
        
    
        The key that contains the UI culture name. If not specified or no value is found, 
        :dn:prop:`Microsoft.AspNet.Localization.QueryStringRequestCultureProvider.QueryStringKey` will be used.
        Defaults to "ui-culture".
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string UIQueryStringKey { get; set; }
    

