

DefaultComplexObjectValidationStrategy Class
============================================



.. contents:: 
   :local:



Summary
-------

The default implementation of :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.IValidationStrategy` for a complex object.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Validation.DefaultComplexObjectValidationStrategy`








Syntax
------

.. code-block:: csharp

   public class DefaultComplexObjectValidationStrategy : IValidationStrategy





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ModelBinding/Validation/DefaultComplexObjectValidationStrategy.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DefaultComplexObjectValidationStrategy

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DefaultComplexObjectValidationStrategy
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DefaultComplexObjectValidationStrategy.GetChildren(Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata, System.String, System.Object)
    
        
        
        
        :type metadata: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
        
        
        :type key: System.String
        
        
        :type model: System.Object
        :rtype: System.Collections.Generic.IEnumerator{Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationEntry}
    
        
        .. code-block:: csharp
    
           public IEnumerator<ValidationEntry> GetChildren(ModelMetadata metadata, string key, object model)
    

Fields
------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DefaultComplexObjectValidationStrategy
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Mvc.ModelBinding.Validation.DefaultComplexObjectValidationStrategy.Instance
    
        
    
        Gets an instance of :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.DefaultComplexObjectValidationStrategy`\.
    
        
    
        
        .. code-block:: csharp
    
           public static readonly IValidationStrategy Instance
    

