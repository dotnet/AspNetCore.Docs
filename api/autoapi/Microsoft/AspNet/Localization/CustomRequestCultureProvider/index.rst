

CustomRequestCultureProvider Class
==================================



.. contents:: 
   :local:



Summary
-------

Determines the culture information for a request via the configured delegate.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Localization.RequestCultureProvider`
* :dn:cls:`Microsoft.AspNet.Localization.CustomRequestCultureProvider`








Syntax
------

.. code-block:: csharp

   public class CustomRequestCultureProvider : RequestCultureProvider, IRequestCultureProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/localization/blob/master/src/Microsoft.AspNet.Localization/CustomRequestCultureProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Localization.CustomRequestCultureProvider

Constructors
------------

.. dn:class:: Microsoft.AspNet.Localization.CustomRequestCultureProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Localization.CustomRequestCultureProvider.CustomRequestCultureProvider(System.Func<Microsoft.AspNet.Http.HttpContext, System.Threading.Tasks.Task<Microsoft.AspNet.Localization.ProviderCultureResult>>)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Localization.CustomRequestCultureProvider` using the specified delegate.
    
        
        
        
        :param provider: The provider delegate.
        
        :type provider: System.Func{Microsoft.AspNet.Http.HttpContext,System.Threading.Tasks.Task{Microsoft.AspNet.Localization.ProviderCultureResult}}
    
        
        .. code-block:: csharp
    
           public CustomRequestCultureProvider(Func<HttpContext, Task<ProviderCultureResult>> provider)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Localization.CustomRequestCultureProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Localization.CustomRequestCultureProvider.DetermineProviderCultureResult(Microsoft.AspNet.Http.HttpContext)
    
        
        
        
        :type httpContext: Microsoft.AspNet.Http.HttpContext
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Localization.ProviderCultureResult}
    
        
        .. code-block:: csharp
    
           public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
    

