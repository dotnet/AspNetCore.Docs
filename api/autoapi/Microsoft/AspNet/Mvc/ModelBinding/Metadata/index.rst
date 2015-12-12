

Microsoft.AspNet.Mvc.ModelBinding.Metadata Namespace
====================================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNet/Mvc/ModelBinding/Metadata/BindingMetadata/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ModelBinding/Metadata/BindingMetadataProviderContext/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ModelBinding/Metadata/DataAnnotationsMetadataProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ModelBinding/Metadata/DataMemberRequiredBindingMetadataProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ModelBinding/Metadata/DefaultBindingMetadataProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ModelBinding/Metadata/DefaultCompositeMetadataDetailsProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ModelBinding/Metadata/DefaultMetadataDetails/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ModelBinding/Metadata/DefaultModelMetadata/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ModelBinding/Metadata/DefaultModelMetadataProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ModelBinding/Metadata/DefaultValidationMetadataProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ModelBinding/Metadata/DisplayMetadata/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ModelBinding/Metadata/DisplayMetadataProviderContext/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ModelBinding/Metadata/IBindingMetadataProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ModelBinding/Metadata/ICompositeMetadataDetailsProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ModelBinding/Metadata/IDisplayMetadataProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ModelBinding/Metadata/IMetadataDetailsProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ModelBinding/Metadata/IModelBindingMessageProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ModelBinding/Metadata/IValidationMetadataProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ModelBinding/Metadata/ModelBindingMessageProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ModelBinding/Metadata/ModelMetadataIdentity/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ModelBinding/Metadata/ModelMetadataKind/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ModelBinding/Metadata/ValidationMetadata/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/ModelBinding/Metadata/ValidationMetadataProviderContext/index
   
   











.. dn:namespace:: Microsoft.AspNet.Mvc.ModelBinding.Metadata


    .. rubric:: Classes


    class :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.BindingMetadata`
        Binding metadata details for a :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata`\.


    class :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.BindingMetadataProviderContext`
        A context for an :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.IBindingMetadataProvider`\.


    class :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.DataAnnotationsMetadataProvider`
        An implementation of :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.IBindingMetadataProvider` and :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.IDisplayMetadataProvider` for
        the System.ComponentModel.DataAnnotations attribute classes.


    class :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.DataMemberRequiredBindingMetadataProvider`
        An :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.IBindingMetadataProvider` for :dn:prop:`System.Runtime.Serialization.DataMemberAttribute.IsRequired`\.


    class :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultBindingMetadataProvider`
        A default implementation of :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.IBindingMetadataProvider`\.


    class :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultCompositeMetadataDetailsProvider`
        A default implementation of :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.ICompositeMetadataDetailsProvider`\.


    class :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultMetadataDetails`
        Holds associated metadata objects for a :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata`\.


    class :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata`
        A default :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata` implementation.


    class :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadataProvider`
        A default implementation of :any:`Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider` based on reflection.


    class :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultValidationMetadataProvider`
        A default implementation of :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.IValidationMetadataProvider`\.


    class :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadata`
        Display metadata details for a :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata`\.


    class :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadataProviderContext`
        A context for and :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.IDisplayMetadataProvider`\.


    class :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelBindingMessageProvider`
        Read / write :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.IModelBindingMessageProvider` implementation.


    class :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.ValidationMetadata`
        Validation metadata details for a :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata`\.


    class :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.ValidationMetadataProviderContext`
        A context for an :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.IValidationMetadataProvider`\.


    .. rubric:: Structures


    struct :dn:struct:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelMetadataIdentity`
        A key type which identifies a :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata`\.


    .. rubric:: Interfaces


    interface :dn:iface:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.IBindingMetadataProvider`
        Provides :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.BindingMetadata` for a :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata`\.


    interface :dn:iface:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.ICompositeMetadataDetailsProvider`
        A composite :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.IMetadataDetailsProvider`\.


    interface :dn:iface:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.IDisplayMetadataProvider`
        Provides :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.DisplayMetadata` for a :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata`\.


    interface :dn:iface:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.IMetadataDetailsProvider`
        Marker interface for a provider of metadata details about model objects. Implementations should
        implement one or more of :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.IBindingMetadataProvider`\, :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.IDisplayMetadataProvider`\,
        and :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.IValidationMetadataProvider`\.


    interface :dn:iface:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.IModelBindingMessageProvider`
        Provider for error messages the model binding system detects.


    interface :dn:iface:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.IValidationMetadataProvider`
        Provides :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.ValidationMetadata` for a :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.DefaultModelMetadata`\.


    .. rubric:: Enumerations


    enum :dn:enum:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelMetadataKind`
        Enumeration for the kinds of :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata`


