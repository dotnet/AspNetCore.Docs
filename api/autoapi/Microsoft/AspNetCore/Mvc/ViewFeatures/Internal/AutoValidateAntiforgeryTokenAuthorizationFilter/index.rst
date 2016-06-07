

AutoValidateAntiforgeryTokenAuthorizationFilter Class
=====================================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ValidateAntiforgeryTokenAuthorizationFilter`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.AutoValidateAntiforgeryTokenAuthorizationFilter`








Syntax
------

.. code-block:: csharp

    public class AutoValidateAntiforgeryTokenAuthorizationFilter : ValidateAntiforgeryTokenAuthorizationFilter, IAsyncAuthorizationFilter, IAntiforgeryPolicy, IFilterMetadata








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.AutoValidateAntiforgeryTokenAuthorizationFilter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.AutoValidateAntiforgeryTokenAuthorizationFilter

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.AutoValidateAntiforgeryTokenAuthorizationFilter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.AutoValidateAntiforgeryTokenAuthorizationFilter.AutoValidateAntiforgeryTokenAuthorizationFilter(Microsoft.AspNetCore.Antiforgery.IAntiforgery, Microsoft.Extensions.Logging.ILoggerFactory)
    
        
    
        
        :type antiforgery: Microsoft.AspNetCore.Antiforgery.IAntiforgery
    
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
            public AutoValidateAntiforgeryTokenAuthorizationFilter(IAntiforgery antiforgery, ILoggerFactory loggerFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.AutoValidateAntiforgeryTokenAuthorizationFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.AutoValidateAntiforgeryTokenAuthorizationFilter.ShouldValidate(Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected override bool ShouldValidate(AuthorizationFilterContext context)
    

