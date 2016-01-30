

ClientValidatorProviderContext Class
====================================



.. contents:: 
   :local:



Summary
-------

A context for :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.IClientModelValidatorProvider`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Validation.ClientValidatorProviderContext`








Syntax
------

.. code-block:: csharp

   public class ClientValidatorProviderContext





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Abstractions/ModelBinding/Validation/ClientValidatorProviderContext.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ClientValidatorProviderContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ClientValidatorProviderContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ClientValidatorProviderContext.ClientValidatorProviderContext(Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.ClientValidatorProviderContext`\.
    
        
        
        
        :param modelMetadata: The  for the model being validated.
        
        :type modelMetadata: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
    
        
        .. code-block:: csharp
    
           public ClientValidatorProviderContext(ModelMetadata modelMetadata)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ClientValidatorProviderContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ClientValidatorProviderContext.ModelMetadata
    
        
    
        Gets the :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
    
        
        .. code-block:: csharp
    
           public ModelMetadata ModelMetadata { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ClientValidatorProviderContext.ValidatorMetadata
    
        
    
        Gets the validator metadata.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList{System.Object}
    
        
        .. code-block:: csharp
    
           public IReadOnlyList<object> ValidatorMetadata { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ClientValidatorProviderContext.Validators
    
        
    
        Gets the list of :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.IClientModelValidator` instances. :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.IClientModelValidatorProvider`
        instances should add validators to this list when 
        :dn:meth:`Microsoft.AspNet.Mvc.ModelBinding.Validation.IClientModelValidatorProvider.GetValidators(Microsoft.AspNet.Mvc.ModelBinding.Validation.ClientValidatorProviderContext)`
        is called.
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.ModelBinding.Validation.IClientModelValidator}
    
        
        .. code-block:: csharp
    
           public IList<IClientModelValidator> Validators { get; }
    

