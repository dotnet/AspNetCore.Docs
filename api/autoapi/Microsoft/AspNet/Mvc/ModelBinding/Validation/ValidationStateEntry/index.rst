

ValidationStateEntry Class
==========================



.. contents:: 
   :local:



Summary
-------

An entry in a :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateDictionary`\. Records state information to override the default
behavior of validation for an object.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateEntry`








Syntax
------

.. code-block:: csharp

   public class ValidationStateEntry





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Abstractions/ModelBinding/Validation/ValidationStateEntry.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateEntry

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateEntry
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateEntry.Key
    
        
    
        Gets or sets the model prefix associated with the entry.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Key { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateEntry.Metadata
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata` associated with the entry.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
    
        
        .. code-block:: csharp
    
           public ModelMetadata Metadata { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateEntry.Strategy
    
        
    
        Gets or sets an :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.IValidationStrategy` for enumerating child entries of the associated
        model object.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.Validation.IValidationStrategy
    
        
        .. code-block:: csharp
    
           public IValidationStrategy Strategy { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateEntry.SuppressValidation
    
        
    
        Gets or sets a value indicating whether the associated model object should be validated.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool SuppressValidation { get; set; }
    

