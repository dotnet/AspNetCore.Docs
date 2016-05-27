

Microsoft.AspNetCore.Mvc.DataAnnotations.Internal Namespace
===========================================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/Mvc/DataAnnotations/Internal/AttributeAdapterBase-TAttribute/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/DataAnnotations/Internal/CompareAttributeAdapter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/DataAnnotations/Internal/DataAnnotationsClientModelValidatorProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/DataAnnotations/Internal/DataAnnotationsLocalizationServices/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/DataAnnotations/Internal/DataAnnotationsMetadataProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/DataAnnotations/Internal/DataAnnotationsModelValidator/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/DataAnnotations/Internal/DataAnnotationsModelValidatorProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/DataAnnotations/Internal/DataTypeAttributeAdapter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/DataAnnotations/Internal/DefaultClientModelValidatorProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/DataAnnotations/Internal/MaxLengthAttributeAdapter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/DataAnnotations/Internal/MinLengthAttributeAdapter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/DataAnnotations/Internal/MvcDataAnnotationsLocalizationOptionsSetup/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/DataAnnotations/Internal/MvcDataAnnotationsMvcOptionsSetup/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/DataAnnotations/Internal/NumericClientModelValidator/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/DataAnnotations/Internal/NumericClientModelValidatorProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/DataAnnotations/Internal/RangeAttributeAdapter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/DataAnnotations/Internal/RegularExpressionAttributeAdapter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/DataAnnotations/Internal/RequiredAttributeAdapter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/DataAnnotations/Internal/StringLengthAttributeAdapter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/DataAnnotations/Internal/ValidatableObjectAdapter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/DataAnnotations/Internal/ValidationAttributeAdapterProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/DataAnnotations/Internal/ValidationAttributeAdapter-TAttribute/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal


    .. rubric:: Classes


    class :dn:cls:`AttributeAdapterBase\<TAttribute>`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.AttributeAdapterBase\<TAttribute>

        
        An abstract subclass of :any:`Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.ValidationAttributeAdapter\`1` which wraps up all the required
        interfaces for the adapters.


    class :dn:cls:`CompareAttributeAdapter`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.CompareAttributeAdapter

        


    class :dn:cls:`DataAnnotationsClientModelValidatorProvider`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataAnnotationsClientModelValidatorProvider

        
        An implementation of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IClientModelValidatorProvider` which provides client validators
        for attributes which derive from :any:`System.ComponentModel.DataAnnotations.ValidationAttribute`\. It also provides
        a validator for types which implement :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IClientModelValidator`\.
        The logic to support :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IClientModelValidator`
        is implemented in :any:`Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.ValidationAttributeAdapter\`1`\.


    class :dn:cls:`DataAnnotationsLocalizationServices`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataAnnotationsLocalizationServices

        


    class :dn:cls:`DataAnnotationsMetadataProvider`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataAnnotationsMetadataProvider

        
        An implementation of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IBindingMetadataProvider` and :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IDisplayMetadataProvider` for
        the System.ComponentModel.DataAnnotations attribute classes.


    class :dn:cls:`DataAnnotationsModelValidator`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataAnnotationsModelValidator

        
        Validates based on the given :any:`System.ComponentModel.DataAnnotations.ValidationAttribute`\.


    class :dn:cls:`DataAnnotationsModelValidatorProvider`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataAnnotationsModelValidatorProvider

        
        An implementation of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidatorProvider` which provides validators
        for attributes which derive from :any:`System.ComponentModel.DataAnnotations.ValidationAttribute`\. It also provides
        a validator for types which implement :any:`System.ComponentModel.DataAnnotations.IValidatableObject`\.


    class :dn:cls:`DataTypeAttributeAdapter`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DataTypeAttributeAdapter

        
        A validation adapter that is used to map :any:`System.ComponentModel.DataAnnotations.DataTypeAttribute`\'s to a single client side validation
        rule.


    class :dn:cls:`DefaultClientModelValidatorProvider`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.DefaultClientModelValidatorProvider

        
        A default implementation of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IClientModelValidatorProvider`\.


    class :dn:cls:`MaxLengthAttributeAdapter`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.MaxLengthAttributeAdapter

        


    class :dn:cls:`MinLengthAttributeAdapter`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.MinLengthAttributeAdapter

        


    class :dn:cls:`MvcDataAnnotationsLocalizationOptionsSetup`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.MvcDataAnnotationsLocalizationOptionsSetup

        
        Sets up default options for :any:`Microsoft.AspNetCore.Mvc.DataAnnotations.MvcDataAnnotationsLocalizationOptions`\.


    class :dn:cls:`MvcDataAnnotationsMvcOptionsSetup`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.MvcDataAnnotationsMvcOptionsSetup

        
        Sets up default options for :any:`Microsoft.AspNetCore.Mvc.MvcOptions`\.


    class :dn:cls:`NumericClientModelValidator`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.NumericClientModelValidator

        
        An implementation of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IClientModelValidator` that provides the rule for validating
        numeric types.


    class :dn:cls:`NumericClientModelValidatorProvider`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.NumericClientModelValidatorProvider

        
        An implementation of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IClientModelValidatorProvider` which provides client validators
        for specific numeric types.


    class :dn:cls:`RangeAttributeAdapter`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.RangeAttributeAdapter

        


    class :dn:cls:`RegularExpressionAttributeAdapter`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.RegularExpressionAttributeAdapter

        


    class :dn:cls:`RequiredAttributeAdapter`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.RequiredAttributeAdapter

        


    class :dn:cls:`StringLengthAttributeAdapter`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.StringLengthAttributeAdapter

        


    class :dn:cls:`ValidatableObjectAdapter`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.ValidatableObjectAdapter

        


    class :dn:cls:`ValidationAttributeAdapterProvider`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.ValidationAttributeAdapterProvider

        
        Creates an :any:`Microsoft.AspNetCore.Mvc.DataAnnotations.IAttributeAdapter` for the given attribute.


    class :dn:cls:`ValidationAttributeAdapter\<TAttribute>`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.ValidationAttributeAdapter\<TAttribute>

        
        An implementation of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IClientModelValidator` which understands data annotation attributes.


