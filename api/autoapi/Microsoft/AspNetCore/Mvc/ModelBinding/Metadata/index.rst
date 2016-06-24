

Microsoft.AspNetCore.Mvc.ModelBinding.Metadata Namespace
========================================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ModelBinding/Metadata/BindingMetadata/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ModelBinding/Metadata/BindingMetadataProviderContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ModelBinding/Metadata/DataMemberRequiredBindingMetadataProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ModelBinding/Metadata/DefaultMetadataDetails/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ModelBinding/Metadata/DefaultModelMetadata/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ModelBinding/Metadata/DefaultModelMetadataProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ModelBinding/Metadata/DisplayMetadata/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ModelBinding/Metadata/DisplayMetadataProviderContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ModelBinding/Metadata/ExcludeBindingMetadataProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ModelBinding/Metadata/IBindingMetadataProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ModelBinding/Metadata/ICompositeMetadataDetailsProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ModelBinding/Metadata/IDisplayMetadataProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ModelBinding/Metadata/IMetadataDetailsProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ModelBinding/Metadata/IModelBindingMessageProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ModelBinding/Metadata/IValidationMetadataProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ModelBinding/Metadata/ModelBindingMessageProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ModelBinding/Metadata/ModelMetadataIdentity/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ModelBinding/Metadata/ModelMetadataKind/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ModelBinding/Metadata/ValidationMetadata/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ModelBinding/Metadata/ValidationMetadataProviderContext/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata


    .. rubric:: Interfaces


    interface :dn:iface:`IBindingMetadataProvider`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IBindingMetadataProvider

        
        Provides :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.BindingMetadata` for a :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata`\.


    interface :dn:iface:`ICompositeMetadataDetailsProvider`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ICompositeMetadataDetailsProvider

        
        A composite :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IMetadataDetailsProvider`\.


    interface :dn:iface:`IDisplayMetadataProvider`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IDisplayMetadataProvider

        
        Provides :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DisplayMetadata` for a :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata`\.


    interface :dn:iface:`IMetadataDetailsProvider`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IMetadataDetailsProvider

        
        Marker interface for a provider of metadata details about model objects. Implementations should
        implement one or more of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IBindingMetadataProvider`\, :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IDisplayMetadataProvider`\, 
        and :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IValidationMetadataProvider`\.


    interface :dn:iface:`IModelBindingMessageProvider`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IModelBindingMessageProvider

        
        Provider for error messages the model binding system detects.


    interface :dn:iface:`IValidationMetadataProvider`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IValidationMetadataProvider

        
        Provides :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ValidationMetadata` for a :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata`\.


    .. rubric:: Enumerations


    enum :dn:enum:`ModelMetadataKind`
        .. object: type=enum name=Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataKind

        
        Enumeration for the kinds of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`


    .. rubric:: Classes


    class :dn:cls:`BindingMetadata`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.BindingMetadata

        
        Binding metadata details for a :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`\.


    class :dn:cls:`BindingMetadataProviderContext`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.BindingMetadataProviderContext

        
        A context for an :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IBindingMetadataProvider`\.


    class :dn:cls:`DataMemberRequiredBindingMetadataProvider`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DataMemberRequiredBindingMetadataProvider

        
        An :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IBindingMetadataProvider` for :dn:prop:`System.Runtime.Serialization.DataMemberAttribute.IsRequired`\.


    class :dn:cls:`DefaultMetadataDetails`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultMetadataDetails

        
        Holds associated metadata objects for a :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata`\.


    class :dn:cls:`DefaultModelMetadata`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata

        
        A default :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata` implementation.


    class :dn:cls:`DefaultModelMetadataProvider`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadataProvider

        
        A default implementation of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider` based on reflection.


    class :dn:cls:`DisplayMetadata`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DisplayMetadata

        
        Display metadata details for a :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`\.


    class :dn:cls:`DisplayMetadataProviderContext`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DisplayMetadataProviderContext

        
        A context for and :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IDisplayMetadataProvider`\.


    class :dn:cls:`ExcludeBindingMetadataProvider`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ExcludeBindingMetadataProvider

        
        An :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IBindingMetadataProvider` which configures :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.IsBindingAllowed` to
        <code>false</code> for matching types.


    class :dn:cls:`ModelBindingMessageProvider`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelBindingMessageProvider

        
        Read / write :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IModelBindingMessageProvider` implementation.


    class :dn:cls:`ValidationMetadata`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ValidationMetadata

        
        Validation metadata details for a :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`\.


    class :dn:cls:`ValidationMetadataProviderContext`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ValidationMetadataProviderContext

        
        A context for an :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IValidationMetadataProvider`\.


    .. rubric:: Structures


    struct :dn:struct:`ModelMetadataIdentity`
        .. object: type=struct name=Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelMetadataIdentity

        
        A key type which identifies a :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`\.


