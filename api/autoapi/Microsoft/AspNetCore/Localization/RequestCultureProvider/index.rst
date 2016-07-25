

RequestCultureProvider Class
============================






An abstract base class provider for determining the culture information of an :any:`Microsoft.AspNetCore.Http.HttpRequest`\.


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








Syntax
------

.. code-block:: csharp

    public abstract class RequestCultureProvider : IRequestCultureProvider








.. dn:class:: Microsoft.AspNetCore.Localization.RequestCultureProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Localization.RequestCultureProvider

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Localization.RequestCultureProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Localization.RequestCultureProvider.DetermineProviderCultureResult(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Localization.ProviderCultureResult<Microsoft.AspNetCore.Localization.ProviderCultureResult>}
    
        
        .. code-block:: csharp
    
            public abstract Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Localization.RequestCultureProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Localization.RequestCultureProvider.Options
    
        
    
        
        The current options for the :any:`Microsoft.AspNetCore.Localization.RequestLocalizationMiddleware`\.
    
        
        :rtype: Microsoft.AspNetCore.Builder.RequestLocalizationOptions
    
        
        .. code-block:: csharp
    
            public RequestLocalizationOptions Options { get; set; }
    

