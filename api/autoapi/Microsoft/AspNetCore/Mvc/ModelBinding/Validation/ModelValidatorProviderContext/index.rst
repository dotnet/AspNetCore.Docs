

ModelValidatorProviderContext Class
===================================






A context for :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidatorProvider`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidatorProviderContext`








Syntax
------

.. code-block:: csharp

    public class ModelValidatorProviderContext








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidatorProviderContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidatorProviderContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidatorProviderContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidatorProviderContext.ModelMetadata
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        .. code-block:: csharp
    
            public ModelMetadata ModelMetadata
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidatorProviderContext.Results
    
        
    
        
        Gets the list of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidatorItem` instances. :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidatorProvider` instances
        should add the appropriate :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidatorItem.Validator` properties when
        :dn:meth:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidatorProvider.CreateValidators(Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidatorProviderContext)`
        is called.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidatorItem<Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidatorItem>}
    
        
        .. code-block:: csharp
    
            public IList<ValidatorItem> Results
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidatorProviderContext.ValidatorMetadata
    
        
    
        
        Gets the validator metadata.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public IReadOnlyList<object> ValidatorMetadata
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidatorProviderContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidatorProviderContext.ModelValidatorProviderContext(Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata, System.Collections.Generic.IList<Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidatorItem>)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidatorProviderContext`\.
    
        
    
        
        :param modelMetadata: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`\.
        
        :type modelMetadata: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        :param items: The list of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidatorItem`\s.
        
        :type items: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidatorItem<Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidatorItem>}
    
        
        .. code-block:: csharp
    
            public ModelValidatorProviderContext(ModelMetadata modelMetadata, IList<ValidatorItem> items)
    

