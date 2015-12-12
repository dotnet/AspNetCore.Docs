

IRequestCultureProvider Interface
=================================



.. contents:: 
   :local:



Summary
-------

Represents a provider for determining the culture information of an :any:`Microsoft.AspNet.Http.HttpRequest`\.











Syntax
------

.. code-block:: csharp

   public interface IRequestCultureProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/localization/src/Microsoft.AspNet.Localization/IRequestCultureProvider.cs>`_





.. dn:interface:: Microsoft.AspNet.Localization.IRequestCultureProvider

Methods
-------

.. dn:interface:: Microsoft.AspNet.Localization.IRequestCultureProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Localization.IRequestCultureProvider.DetermineProviderCultureResult(Microsoft.AspNet.Http.HttpContext)
    
        
    
        Implements the provider to determine the culture of the given request.
    
        
        
        
        :param httpContext: The  for the request.
        
        :type httpContext: Microsoft.AspNet.Http.HttpContext
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Localization.ProviderCultureResult}
        :return: The determined <see cref="T:Microsoft.AspNet.Localization.ProviderCultureResult" />.
            Returns <c>null</c> if the provider couldn't determine a <see cref="T:Microsoft.AspNet.Localization.ProviderCultureResult" />.
    
        
        .. code-block:: csharp
    
           Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
    

