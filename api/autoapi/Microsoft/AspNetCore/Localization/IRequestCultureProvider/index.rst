

IRequestCultureProvider Interface
=================================






Represents a provider for determining the culture information of an :any:`Microsoft.AspNetCore.Http.HttpRequest`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Localization`
Assemblies
    * Microsoft.AspNetCore.Localization

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IRequestCultureProvider








.. dn:interface:: Microsoft.AspNetCore.Localization.IRequestCultureProvider
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Localization.IRequestCultureProvider

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Localization.IRequestCultureProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Localization.IRequestCultureProvider.DetermineProviderCultureResult(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        Implements the provider to determine the culture of the given request.
    
        
    
        
        :param httpContext: The :any:`Microsoft.AspNetCore.Http.HttpContext` for the request.
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Localization.ProviderCultureResult<Microsoft.AspNetCore.Localization.ProviderCultureResult>}
        :return: 
                The determined :any:`Microsoft.AspNetCore.Localization.ProviderCultureResult`\.
                Returns <code>null</code> if the provider couldn't determine a :any:`Microsoft.AspNetCore.Localization.ProviderCultureResult`\.
    
        
        .. code-block:: csharp
    
            Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
    

