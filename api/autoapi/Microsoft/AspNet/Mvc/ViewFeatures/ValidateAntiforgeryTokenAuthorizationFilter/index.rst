

ValidateAntiforgeryTokenAuthorizationFilter Class
=================================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewFeatures.ValidateAntiforgeryTokenAuthorizationFilter`








Syntax
------

.. code-block:: csharp

   public class ValidateAntiforgeryTokenAuthorizationFilter : IAsyncAuthorizationFilter, IFilterMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewFeatures/ValidateAntiforgeryTokenAuthorizationFilter.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.ValidateAntiforgeryTokenAuthorizationFilter

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.ValidateAntiforgeryTokenAuthorizationFilter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ViewFeatures.ValidateAntiforgeryTokenAuthorizationFilter.ValidateAntiforgeryTokenAuthorizationFilter(Microsoft.AspNet.Antiforgery.IAntiforgery)
    
        
        
        
        :type antiforgery: Microsoft.AspNet.Antiforgery.IAntiforgery
    
        
        .. code-block:: csharp
    
           public ValidateAntiforgeryTokenAuthorizationFilter(IAntiforgery antiforgery)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.ValidateAntiforgeryTokenAuthorizationFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.ValidateAntiforgeryTokenAuthorizationFilter.OnAuthorizationAsync(Microsoft.AspNet.Mvc.Filters.AuthorizationContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.AuthorizationContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task OnAuthorizationAsync(AuthorizationContext context)
    

