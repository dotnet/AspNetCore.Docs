

ValidationStateEntry Class
==========================






An entry in a :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationStateDictionary`\. Records state information to override the default
behavior of validation for an object.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationStateEntry`








Syntax
------

.. code-block:: csharp

    public class ValidationStateEntry








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationStateEntry
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationStateEntry

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationStateEntry
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationStateEntry.Key
    
        
    
        
        Gets or sets the model prefix associated with the entry.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Key { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationStateEntry.Metadata
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata` associated with the entry.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        .. code-block:: csharp
    
            public ModelMetadata Metadata { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationStateEntry.Strategy
    
        
    
        
        Gets or sets an :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IValidationStrategy` for enumerating child entries of the associated
        model object.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IValidationStrategy
    
        
        .. code-block:: csharp
    
            public IValidationStrategy Strategy { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationStateEntry.SuppressValidation
    
        
    
        
        Gets or sets a value indicating whether the associated model object should be validated.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool SuppressValidation { get; set; }
    

