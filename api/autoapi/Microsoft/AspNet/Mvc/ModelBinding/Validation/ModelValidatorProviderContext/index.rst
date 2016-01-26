

ModelValidatorProviderContext Class
===================================



.. contents:: 
   :local:



Summary
-------

A context for :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.IModelValidatorProvider`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelValidatorProviderContext`








Syntax
------

.. code-block:: csharp

   public class ModelValidatorProviderContext





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Abstractions/ModelBinding/Validation/ModelValiatorProviderContext.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelValidatorProviderContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelValidatorProviderContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelValidatorProviderContext.ModelValidatorProviderContext(Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelValidatorProviderContext`\.
    
        
        
        
        :param modelMetadata: The .
        
        :type modelMetadata: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
    
        
        .. code-block:: csharp
    
           public ModelValidatorProviderContext(ModelMetadata modelMetadata)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelValidatorProviderContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelValidatorProviderContext.ModelMetadata
    
        
    
        Gets the :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
    
        
        .. code-block:: csharp
    
           public ModelMetadata ModelMetadata { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelValidatorProviderContext.ValidatorMetadata
    
        
    
        Gets the validator metadata.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList{System.Object}
    
        
        .. code-block:: csharp
    
           public IReadOnlyList<object> ValidatorMetadata { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelValidatorProviderContext.Validators
    
        
    
        Gets the list of :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.IModelValidator` instances. :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.IModelValidatorProvider` instances
        should add validators to this list when 
        :dn:meth:`Microsoft.AspNet.Mvc.ModelBinding.Validation.IModelValidatorProvider.GetValidators(Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelValidatorProviderContext)`
        is called.
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.ModelBinding.Validation.IModelValidator}
    
        
        .. code-block:: csharp
    
           public IList<IModelValidator> Validators { get; }
    

