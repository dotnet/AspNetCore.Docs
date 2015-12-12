

MvcOptions Class
================



.. contents:: 
   :local:



Summary
-------

Provides programmatic configuration for the MVC framework.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.MvcOptions`








Syntax
------

.. code-block:: csharp

   public class MvcOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/MvcOptions.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.MvcOptions

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.MvcOptions
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.MvcOptions.MvcOptions()
    
        
    
        
        .. code-block:: csharp
    
           public MvcOptions()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.MvcOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.MvcOptions.CacheProfiles
    
        
    
        Gets a Dictionary of CacheProfile Names, :any:`Microsoft.AspNet.Mvc.CacheProfile` which are pre-defined settings for 
        :any:`Microsoft.AspNet.Mvc.Filters.ResponseCacheFilter`\.
    
        
        :rtype: System.Collections.Generic.IDictionary{System.String,Microsoft.AspNet.Mvc.CacheProfile}
    
        
        .. code-block:: csharp
    
           public IDictionary<string, CacheProfile> CacheProfiles { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.MvcOptions.Conventions
    
        
    
        Gets a list of :any:`Microsoft.AspNet.Mvc.ApplicationModels.IApplicationModelConvention` instances that will be applied to
        the :any:`Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModel` when discovering actions.
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.ApplicationModels.IApplicationModelConvention}
    
        
        .. code-block:: csharp
    
           public IList<IApplicationModelConvention> Conventions { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.MvcOptions.Filters
    
        
    
        Gets a collection of :any:`Microsoft.AspNet.Mvc.Filters.IFilterMetadata` which are used to construct filters that
        apply to all actions.
    
        
        :rtype: Microsoft.AspNet.Mvc.Filters.FilterCollection
    
        
        .. code-block:: csharp
    
           public FilterCollection Filters { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.MvcOptions.FormatterMappings
    
        
    
        Used to specify mapping between the URL Format and corresponding 
        :any:`Microsoft.Net.Http.Headers.MediaTypeHeaderValue`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.Formatters.FormatterMappings
    
        
        .. code-block:: csharp
    
           public FormatterMappings FormatterMappings { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.MvcOptions.InputFormatters
    
        
    
        Gets a list of :any:`Microsoft.AspNet.Mvc.Formatters.IInputFormatter`\s that are used by this application.
    
        
        :rtype: Microsoft.AspNet.Mvc.Formatters.FormatterCollection{Microsoft.AspNet.Mvc.Formatters.IInputFormatter}
    
        
        .. code-block:: csharp
    
           public FormatterCollection<IInputFormatter> InputFormatters { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.MvcOptions.MaxModelValidationErrors
    
        
    
        Gets or sets the maximum number of validation errors that are allowed by this application before further
        errors are ignored.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int MaxModelValidationErrors { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.MvcOptions.ModelBinders
    
        
    
        Gets a list of :any:`Microsoft.AspNet.Mvc.ModelBinding.IModelBinder`\s used by this application.
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.ModelBinding.IModelBinder}
    
        
        .. code-block:: csharp
    
           public IList<IModelBinder> ModelBinders { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.MvcOptions.ModelBindingMessageProvider
    
        
    
        Gets the default :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.IModelBindingMessageProvider`\. Changes here are copied to the 
        :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.ModelBindingMessageProvider` property of all :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata`
        instances unless overridden in a custom :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.IBindingMetadataProvider`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelBindingMessageProvider
    
        
        .. code-block:: csharp
    
           public ModelBindingMessageProvider ModelBindingMessageProvider { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.MvcOptions.ModelMetadataDetailsProviders
    
        
    
        Gets a list of :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.IMetadataDetailsProvider` instances that will be used to
        create :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata` instances.
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.ModelBinding.Metadata.IMetadataDetailsProvider}
    
        
        .. code-block:: csharp
    
           public IList<IMetadataDetailsProvider> ModelMetadataDetailsProviders { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.MvcOptions.ModelValidatorProviders
    
        
    
        Gets a list of :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.IModelValidatorProvider`\s used by this application.
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.ModelBinding.Validation.IModelValidatorProvider}
    
        
        .. code-block:: csharp
    
           public IList<IModelValidatorProvider> ModelValidatorProviders { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.MvcOptions.OutputFormatters
    
        
    
        Gets a list of :any:`Microsoft.AspNet.Mvc.Formatters.IOutputFormatter`\s that are used by this application.
    
        
        :rtype: Microsoft.AspNet.Mvc.Formatters.FormatterCollection{Microsoft.AspNet.Mvc.Formatters.IOutputFormatter}
    
        
        .. code-block:: csharp
    
           public FormatterCollection<IOutputFormatter> OutputFormatters { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.MvcOptions.RespectBrowserAcceptHeader
    
        
    
        Gets or sets the flag which causes content negotiation to ignore Accept header
        when it contains the media type */*. <see langword="false" /> by default.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool RespectBrowserAcceptHeader { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.MvcOptions.ValidationExcludeFilters
    
        
    
        Gets a collection of :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.IExcludeTypeValidationFilter`\s that are used by this application.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.Validation.ExcludeTypeValidationFilterCollection
    
        
        .. code-block:: csharp
    
           public ExcludeTypeValidationFilterCollection ValidationExcludeFilters { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.MvcOptions.ValueProviderFactories
    
        
    
        Gets a list of :any:`Microsoft.AspNet.Mvc.ModelBinding.IValueProviderFactory` used by this application.
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.ModelBinding.IValueProviderFactory}
    
        
        .. code-block:: csharp
    
           public IList<IValueProviderFactory> ValueProviderFactories { get; }
    

