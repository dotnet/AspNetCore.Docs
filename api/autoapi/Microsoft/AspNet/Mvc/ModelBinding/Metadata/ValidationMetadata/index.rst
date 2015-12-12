

ValidationMetadata Class
========================



.. contents:: 
   :local:



Summary
-------

Validation metadata details for a :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.ValidationMetadata`








Syntax
------

.. code-block:: csharp

   public class ValidationMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/ModelBinding/Metadata/ValidationMetadata.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ValidationMetadata

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ValidationMetadata
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ValidationMetadata.IsRequired
    
        
    
        Gets or sets a value indicating whether or not the model is a required value. Will be ignored
        if the model metadata being created is not a property. If <c>null</c> then 
        :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.IsRequired` will be computed based on the model :any:`System.Type`\.
        See :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.IsRequired`\.
    
        
        :rtype: System.Nullable{System.Boolean}
    
        
        .. code-block:: csharp
    
           public bool ? IsRequired { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ValidationMetadata.ValidatorMetadata
    
        
    
        Gets a list of metadata items for validators.
    
        
        :rtype: System.Collections.Generic.IList{System.Object}
    
        
        .. code-block:: csharp
    
           public IList<object> ValidatorMetadata { get; }
    

