

DefaultApiDescriptionProvider Class
===================================



.. contents:: 
   :local:



Summary
-------

Implements a provider of :any:`Microsoft.AspNet.Mvc.ApiExplorer.ApiDescription` for actions represented
by :any:`Microsoft.AspNet.Mvc.Controllers.ControllerActionDescriptor`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ApiExplorer.DefaultApiDescriptionProvider`








Syntax
------

.. code-block:: csharp

   public class DefaultApiDescriptionProvider : IApiDescriptionProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ApiExplorer/DefaultApiDescriptionProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ApiExplorer.DefaultApiDescriptionProvider

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ApiExplorer.DefaultApiDescriptionProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ApiExplorer.DefaultApiDescriptionProvider.DefaultApiDescriptionProvider(Microsoft.Extensions.OptionsModel.IOptions<Microsoft.AspNet.Mvc.MvcOptions>, Microsoft.AspNet.Routing.IInlineConstraintResolver, Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider)
    
        
    
        Creates a new instance of :any:`Microsoft.AspNet.Mvc.ApiExplorer.DefaultApiDescriptionProvider`\.
    
        
        
        
        :param optionsAccessor: The accessor for .
        
        :type optionsAccessor: Microsoft.Extensions.OptionsModel.IOptions{Microsoft.AspNet.Mvc.MvcOptions}
        
        
        :param constraintResolver: The  used for resolving inline
            constraints.
        
        :type constraintResolver: Microsoft.AspNet.Routing.IInlineConstraintResolver
        
        
        :param modelMetadataProvider: The .
        
        :type modelMetadataProvider: Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider
    
        
        .. code-block:: csharp
    
           public DefaultApiDescriptionProvider(IOptions<MvcOptions> optionsAccessor, IInlineConstraintResolver constraintResolver, IModelMetadataProvider modelMetadataProvider)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ApiExplorer.DefaultApiDescriptionProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ApiExplorer.DefaultApiDescriptionProvider.OnProvidersExecuted(Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionProviderContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionProviderContext
    
        
        .. code-block:: csharp
    
           public void OnProvidersExecuted(ApiDescriptionProviderContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ApiExplorer.DefaultApiDescriptionProvider.OnProvidersExecuting(Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionProviderContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionProviderContext
    
        
        .. code-block:: csharp
    
           public void OnProvidersExecuting(ApiDescriptionProviderContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ApiExplorer.DefaultApiDescriptionProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ApiExplorer.DefaultApiDescriptionProvider.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Order { get; }
    

