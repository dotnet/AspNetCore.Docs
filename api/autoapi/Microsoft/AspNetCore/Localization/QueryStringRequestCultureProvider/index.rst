

QueryStringRequestCultureProvider Class
=======================================






Determines the culture information for a request via values in the query string.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Localization`
Assemblies
    * Microsoft.AspNetCore.Localization

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Localization.RequestCultureProvider`
* :dn:cls:`Microsoft.AspNetCore.Localization.QueryStringRequestCultureProvider`








Syntax
------

.. code-block:: csharp

    public class QueryStringRequestCultureProvider : RequestCultureProvider, IRequestCultureProvider








.. dn:class:: Microsoft.AspNetCore.Localization.QueryStringRequestCultureProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Localization.QueryStringRequestCultureProvider

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Localization.QueryStringRequestCultureProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Localization.QueryStringRequestCultureProvider.QueryStringKey
    
        
    
        
        The key that contains the culture name.
        Defaults to "culture".
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string QueryStringKey
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Localization.QueryStringRequestCultureProvider.UIQueryStringKey
    
        
    
        
        The key that contains the UI culture name. If not specified or no value is found,
        :dn:prop:`Microsoft.AspNetCore.Localization.QueryStringRequestCultureProvider.QueryStringKey` will be used.
        Defaults to "ui-culture".
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string UIQueryStringKey
            {
                get;
                set;
            }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Localization.QueryStringRequestCultureProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Localization.QueryStringRequestCultureProvider.DetermineProviderCultureResult(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Localization.ProviderCultureResult<Microsoft.AspNetCore.Localization.ProviderCultureResult>}
    
        
        .. code-block:: csharp
    
            public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
    

