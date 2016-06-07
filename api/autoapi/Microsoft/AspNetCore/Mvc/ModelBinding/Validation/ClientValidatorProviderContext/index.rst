

ClientValidatorProviderContext Class
====================================






A context for :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IClientModelValidatorProvider`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorProviderContext`








Syntax
------

.. code-block:: csharp

    public class ClientValidatorProviderContext








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorProviderContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorProviderContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorProviderContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorProviderContext.ModelMetadata
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        .. code-block:: csharp
    
            public ModelMetadata ModelMetadata
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorProviderContext.Results
    
        
    
        
        Gets the list of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorItem` instances. :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IClientModelValidatorProvider`
        instances should add the appropriate :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorItem.Validator` properties when
        :dn:meth:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IClientModelValidatorProvider.CreateValidators(Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorProviderContext)`
        is called.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorItem<Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorItem>}
    
        
        .. code-block:: csharp
    
            public IList<ClientValidatorItem> Results
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorProviderContext.ValidatorMetadata
    
        
    
        
        Gets the validator metadata.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public IReadOnlyList<object> ValidatorMetadata
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorProviderContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorProviderContext.ClientValidatorProviderContext(Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata, System.Collections.Generic.IList<Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorItem>)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorProviderContext`\.
    
        
    
        
        :param modelMetadata: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata` for the model being validated.
            
        
        :type modelMetadata: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        :param items: The list of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorItem`\s.
        
        :type items: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorItem<Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorItem>}
    
        
        .. code-block:: csharp
    
            public ClientValidatorProviderContext(ModelMetadata modelMetadata, IList<ClientValidatorItem> items)
    

