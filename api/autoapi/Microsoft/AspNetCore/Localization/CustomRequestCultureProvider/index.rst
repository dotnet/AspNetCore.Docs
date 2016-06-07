

CustomRequestCultureProvider Class
==================================






Determines the culture information for a request via the configured delegate.


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
* :dn:cls:`Microsoft.AspNetCore.Localization.CustomRequestCultureProvider`








Syntax
------

.. code-block:: csharp

    public class CustomRequestCultureProvider : RequestCultureProvider, IRequestCultureProvider








.. dn:class:: Microsoft.AspNetCore.Localization.CustomRequestCultureProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Localization.CustomRequestCultureProvider

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Localization.CustomRequestCultureProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Localization.CustomRequestCultureProvider.CustomRequestCultureProvider(System.Func<Microsoft.AspNetCore.Http.HttpContext, System.Threading.Tasks.Task<Microsoft.AspNetCore.Localization.ProviderCultureResult>>)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Localization.CustomRequestCultureProvider` using the specified delegate.
    
        
    
        
        :param provider: The provider delegate.
        
        :type provider: System.Func<System.Func`2>{Microsoft.AspNetCore.Http.HttpContext<Microsoft.AspNetCore.Http.HttpContext>, System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Localization.ProviderCultureResult<Microsoft.AspNetCore.Localization.ProviderCultureResult>}}
    
        
        .. code-block:: csharp
    
            public CustomRequestCultureProvider(Func<HttpContext, Task<ProviderCultureResult>> provider)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Localization.CustomRequestCultureProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Localization.CustomRequestCultureProvider.DetermineProviderCultureResult(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Localization.ProviderCultureResult<Microsoft.AspNetCore.Localization.ProviderCultureResult>}
    
        
        .. code-block:: csharp
    
            public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
    

