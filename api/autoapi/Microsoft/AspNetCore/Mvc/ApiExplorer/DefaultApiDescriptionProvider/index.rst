

DefaultApiDescriptionProvider Class
===================================






Implements a provider of :any:`Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription` for actions represented
by :any:`Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ApiExplorer`
Assemblies
    * Microsoft.AspNetCore.Mvc.ApiExplorer

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ApiExplorer.DefaultApiDescriptionProvider`








Syntax
------

.. code-block:: csharp

    public class DefaultApiDescriptionProvider : IApiDescriptionProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.ApiExplorer.DefaultApiDescriptionProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ApiExplorer.DefaultApiDescriptionProvider

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ApiExplorer.DefaultApiDescriptionProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ApiExplorer.DefaultApiDescriptionProvider.DefaultApiDescriptionProvider(Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Mvc.MvcOptions>, Microsoft.AspNetCore.Routing.IInlineConstraintResolver, Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider)
    
        
    
        
        Creates a new instance of :any:`Microsoft.AspNetCore.Mvc.ApiExplorer.DefaultApiDescriptionProvider`\.
    
        
    
        
        :param optionsAccessor: The accessor for :any:`Microsoft.AspNetCore.Mvc.MvcOptions`\.
        
        :type optionsAccessor: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Mvc.MvcOptions<Microsoft.AspNetCore.Mvc.MvcOptions>}
    
        
        :param constraintResolver: The :any:`Microsoft.AspNetCore.Routing.IInlineConstraintResolver` used for resolving inline
            constraints.
        
        :type constraintResolver: Microsoft.AspNetCore.Routing.IInlineConstraintResolver
    
        
        :param modelMetadataProvider: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider`\.
        
        :type modelMetadataProvider: Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider
    
        
        .. code-block:: csharp
    
            public DefaultApiDescriptionProvider(IOptions<MvcOptions> optionsAccessor, IInlineConstraintResolver constraintResolver, IModelMetadataProvider modelMetadataProvider)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ApiExplorer.DefaultApiDescriptionProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ApiExplorer.DefaultApiDescriptionProvider.OnProvidersExecuted(Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionProviderContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionProviderContext
    
        
        .. code-block:: csharp
    
            public void OnProvidersExecuted(ApiDescriptionProviderContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ApiExplorer.DefaultApiDescriptionProvider.OnProvidersExecuting(Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionProviderContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionProviderContext
    
        
        .. code-block:: csharp
    
            public void OnProvidersExecuting(ApiDescriptionProviderContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ApiExplorer.DefaultApiDescriptionProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApiExplorer.DefaultApiDescriptionProvider.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Order { get; }
    

