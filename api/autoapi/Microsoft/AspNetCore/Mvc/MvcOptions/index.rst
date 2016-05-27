

MvcOptions Class
================






Provides programmatic configuration for the MVC framework.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.MvcOptions`








Syntax
------

.. code-block:: csharp

    public class MvcOptions








.. dn:class:: Microsoft.AspNetCore.Mvc.MvcOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.MvcOptions

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.MvcOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.MvcOptions.CacheProfiles
    
        
    
        
        Gets a Dictionary of CacheProfile Names, :any:`Microsoft.AspNetCore.Mvc.CacheProfile` which are pre-defined settings for
        response caching.
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, Microsoft.AspNetCore.Mvc.CacheProfile<Microsoft.AspNetCore.Mvc.CacheProfile>}
    
        
        .. code-block:: csharp
    
            public IDictionary<string, CacheProfile> CacheProfiles
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.MvcOptions.Conventions
    
        
    
        
        Gets a list of :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.IApplicationModelConvention` instances that will be applied to
        the :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModel` when discovering actions.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.ApplicationModels.IApplicationModelConvention<Microsoft.AspNetCore.Mvc.ApplicationModels.IApplicationModelConvention>}
    
        
        .. code-block:: csharp
    
            public IList<IApplicationModelConvention> Conventions
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.MvcOptions.Filters
    
        
    
        
        Gets a collection of :any:`Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata` which are used to construct filters that
        apply to all actions.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Filters.FilterCollection
    
        
        .. code-block:: csharp
    
            public FilterCollection Filters
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.MvcOptions.FormatterMappings
    
        
    
        
        Used to specify mapping between the URL Format and corresponding media type.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Formatters.FormatterMappings
    
        
        .. code-block:: csharp
    
            public FormatterMappings FormatterMappings
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.MvcOptions.InputFormatters
    
        
    
        
        Gets a list of :any:`Microsoft.AspNetCore.Mvc.Formatters.IInputFormatter`\s that are used by this application.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Formatters.FormatterCollection<Microsoft.AspNetCore.Mvc.Formatters.FormatterCollection`1>{Microsoft.AspNetCore.Mvc.Formatters.IInputFormatter<Microsoft.AspNetCore.Mvc.Formatters.IInputFormatter>}
    
        
        .. code-block:: csharp
    
            public FormatterCollection<IInputFormatter> InputFormatters
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.MvcOptions.MaxModelValidationErrors
    
        
    
        
        Gets or sets the maximum number of validation errors that are allowed by this application before further
        errors are ignored.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int MaxModelValidationErrors
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.MvcOptions.ModelBinderProviders
    
        
    
        
        Gets a list of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinderProvider`\s used by this application.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinderProvider<Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinderProvider>}
    
        
        .. code-block:: csharp
    
            public IList<IModelBinderProvider> ModelBinderProviders
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.MvcOptions.ModelBindingMessageProvider
    
        
    
        
        Gets the default :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IModelBindingMessageProvider`\. Changes here are copied to the
        :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.ModelBindingMessageProvider` property of all :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`
        instances unless overridden in a custom :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IBindingMetadataProvider`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelBindingMessageProvider
    
        
        .. code-block:: csharp
    
            public ModelBindingMessageProvider ModelBindingMessageProvider
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.MvcOptions.ModelMetadataDetailsProviders
    
        
    
        
        Gets a list of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IMetadataDetailsProvider` instances that will be used to
        create :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata` instances.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IMetadataDetailsProvider<Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IMetadataDetailsProvider>}
    
        
        .. code-block:: csharp
    
            public IList<IMetadataDetailsProvider> ModelMetadataDetailsProviders
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.MvcOptions.ModelValidatorProviders
    
        
    
        
        Gets a list of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidatorProvider`\s used by this application.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidatorProvider<Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidatorProvider>}
    
        
        .. code-block:: csharp
    
            public IList<IModelValidatorProvider> ModelValidatorProviders
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.MvcOptions.OutputFormatters
    
        
    
        
        Gets a list of :any:`Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter`\s that are used by this application.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Formatters.FormatterCollection<Microsoft.AspNetCore.Mvc.Formatters.FormatterCollection`1>{Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter<Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter>}
    
        
        .. code-block:: csharp
    
            public FormatterCollection<IOutputFormatter> OutputFormatters
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.MvcOptions.RespectBrowserAcceptHeader
    
        
    
        
        Gets or sets the flag which causes content negotiation to ignore Accept header
        when it contains the media type */*. <xref uid="langword_csharp_false" name="false" href=""></xref> by default.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool RespectBrowserAcceptHeader
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.MvcOptions.SslPort
    
        
    
        
        Gets or sets the SSL port that is used by this application when :any:`Microsoft.AspNetCore.Mvc.RequireHttpsAttribute`
        is used. If not set the port won't be specified in the secured URL e.g. https://localhost/path.
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.Int32<System.Int32>}
    
        
        .. code-block:: csharp
    
            public int ? SslPort
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.MvcOptions.ValueProviderFactories
    
        
    
        
        Gets a list of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IValueProviderFactory` used by this application.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.ModelBinding.IValueProviderFactory<Microsoft.AspNetCore.Mvc.ModelBinding.IValueProviderFactory>}
    
        
        .. code-block:: csharp
    
            public IList<IValueProviderFactory> ValueProviderFactories
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.MvcOptions
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.MvcOptions.MvcOptions()
    
        
    
        
        .. code-block:: csharp
    
            public MvcOptions()
    

