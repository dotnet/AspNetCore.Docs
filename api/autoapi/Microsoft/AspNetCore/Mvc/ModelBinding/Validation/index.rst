

Microsoft.AspNetCore.Mvc.ModelBinding.Validation Namespace
==========================================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ModelBinding/Validation/ClientModelValidationContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ModelBinding/Validation/ClientValidatorItem/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ModelBinding/Validation/ClientValidatorProviderContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ModelBinding/Validation/CompositeClientModelValidatorProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ModelBinding/Validation/CompositeModelValidatorProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ModelBinding/Validation/IClientModelValidator/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ModelBinding/Validation/IClientModelValidatorProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ModelBinding/Validation/IModelValidator/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ModelBinding/Validation/IModelValidatorProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ModelBinding/Validation/IObjectModelValidator/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ModelBinding/Validation/IValidationStrategy/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ModelBinding/Validation/ModelValidationContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ModelBinding/Validation/ModelValidationContextBase/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ModelBinding/Validation/ModelValidationResult/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ModelBinding/Validation/ModelValidatorProviderContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ModelBinding/Validation/ValidationEntry/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ModelBinding/Validation/ValidationStateDictionary/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ModelBinding/Validation/ValidationStateEntry/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ModelBinding/Validation/ValidationVisitor/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/ModelBinding/Validation/ValidatorItem/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation


    .. rubric:: Interfaces


    interface :dn:iface:`IClientModelValidator`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IClientModelValidator

        


    interface :dn:iface:`IClientModelValidatorProvider`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IClientModelValidatorProvider

        
        Provides a collection of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IClientModelValidator`\s.


    interface :dn:iface:`IModelValidator`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidator

        
        Validates a model value.


    interface :dn:iface:`IModelValidatorProvider`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidatorProvider

        
        Provides validators for a model value.


    interface :dn:iface:`IObjectModelValidator`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IObjectModelValidator

        
        Provides methods to validate an object graph.


    interface :dn:iface:`IValidationStrategy`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IValidationStrategy

        
        Defines a strategy for enumerating the child entries of a model object which should be validated.


    .. rubric:: Classes


    class :dn:cls:`ClientModelValidationContext`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientModelValidationContext

        
        The context for client-side model validation.


    class :dn:cls:`ClientValidatorItem`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorItem

        
        Used to associate validators with :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorItem.ValidatorMetadata` instances
        as part of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorProviderContext`\. An :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IClientModelValidator` should
        inspect :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorProviderContext.Results` and set :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorItem.Validator` and 
        :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorItem.IsReusable` as appropriate.


    class :dn:cls:`ClientValidatorProviderContext`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorProviderContext

        
        A context for :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IClientModelValidatorProvider`\.


    class :dn:cls:`CompositeClientModelValidatorProvider`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ModelBinding.Validation.CompositeClientModelValidatorProvider

        
        Aggregate of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IClientModelValidatorProvider`\s that delegates to its underlying providers.


    class :dn:cls:`CompositeModelValidatorProvider`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ModelBinding.Validation.CompositeModelValidatorProvider

        
        Aggregate of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidatorProvider`\s that delegates to its underlying providers.


    class :dn:cls:`ModelValidationContext`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationContext

        
        A context object for :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidator`\.


    class :dn:cls:`ModelValidationContextBase`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationContextBase

        
        A common base class for :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationContext` and :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientModelValidationContext`\.


    class :dn:cls:`ModelValidationResult`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidationResult

        


    class :dn:cls:`ModelValidatorProviderContext`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidatorProviderContext

        
        A context for :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidatorProvider`\.


    class :dn:cls:`ValidationStateDictionary`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationStateDictionary

        
        Used for tracking validation state to customize validation behavior for a model object.


    class :dn:cls:`ValidationStateEntry`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationStateEntry

        
        An entry in a :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationStateDictionary`\. Records state information to override the default
        behavior of validation for an object.


    class :dn:cls:`ValidationVisitor`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationVisitor

        
        A visitor implementation that interprets :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationStateDictionary` to traverse
        a model object graph and perform validation.


    class :dn:cls:`ValidatorItem`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidatorItem

        
        Used to associate validators with :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidatorItem.ValidatorMetadata` instances
        as part of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidatorProviderContext`\. An :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidator` should
        inspect :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidatorProviderContext.Results` and set :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidatorItem.Validator` and 
        :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidatorItem.IsReusable` as appropriate.


    .. rubric:: Structures


    struct :dn:struct:`ValidationEntry`
        .. object: type=struct name=Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationEntry

        
        Contains data needed for validating a child entry of a model object. See :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IValidationStrategy`\.


