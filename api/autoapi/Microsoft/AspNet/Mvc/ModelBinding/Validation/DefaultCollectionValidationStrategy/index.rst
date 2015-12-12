

DefaultCollectionValidationStrategy Class
=========================================



.. contents:: 
   :local:



Summary
-------

The default implementation of :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.IValidationStrategy` for a collection.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Validation.DefaultCollectionValidationStrategy`








Syntax
------

.. code-block:: csharp

   public class DefaultCollectionValidationStrategy : IValidationStrategy





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/ModelBinding/Validation/DefaultCollectionValidationStrategy.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DefaultCollectionValidationStrategy

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DefaultCollectionValidationStrategy
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DefaultCollectionValidationStrategy.GetChildren(Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata, System.String, System.Object)
    
        
        
        
        :type metadata: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
        
        
        :type key: System.String
        
        
        :type model: System.Object
        :rtype: System.Collections.Generic.IEnumerator{Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationEntry}
    
        
        .. code-block:: csharp
    
           public IEnumerator<ValidationEntry> GetChildren(ModelMetadata metadata, string key, object model)
    

Fields
------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DefaultCollectionValidationStrategy
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DefaultCollectionValidationStrategy.Instance
    
        
    
        Gets an instance of :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.DefaultCollectionValidationStrategy`\.
    
        
    
        
        .. code-block:: csharp
    
           public static readonly IValidationStrategy Instance
    

