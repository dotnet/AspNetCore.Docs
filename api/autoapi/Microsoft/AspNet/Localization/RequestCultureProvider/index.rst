

RequestCultureProvider Class
============================



.. contents:: 
   :local:



Summary
-------

An abstract base class provider for determining the culture information of an :any:`Microsoft.AspNet.Http.HttpRequest`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Localization.RequestCultureProvider`








Syntax
------

.. code-block:: csharp

   public abstract class RequestCultureProvider : IRequestCultureProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/localization/blob/master/src/Microsoft.AspNet.Localization/RequestCultureProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Localization.RequestCultureProvider

Methods
-------

.. dn:class:: Microsoft.AspNet.Localization.RequestCultureProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Localization.RequestCultureProvider.DetermineProviderCultureResult(Microsoft.AspNet.Http.HttpContext)
    
        
        
        
        :type httpContext: Microsoft.AspNet.Http.HttpContext
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Localization.ProviderCultureResult}
    
        
        .. code-block:: csharp
    
           public abstract Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Localization.RequestCultureProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Localization.RequestCultureProvider.Options
    
        
    
        The current options for the :any:`Microsoft.AspNet.Localization.RequestLocalizationMiddleware`\.
    
        
        :rtype: Microsoft.AspNet.Localization.RequestLocalizationOptions
    
        
        .. code-block:: csharp
    
           public RequestLocalizationOptions Options { get; set; }
    

