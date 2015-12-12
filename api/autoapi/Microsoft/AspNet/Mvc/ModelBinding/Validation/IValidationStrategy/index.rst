

IValidationStrategy Interface
=============================



.. contents:: 
   :local:



Summary
-------

Defines a strategy for enumerating the child entries of a model object which should be validated.











Syntax
------

.. code-block:: csharp

   public interface IValidationStrategy





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Abstractions/ModelBinding/Validation/IValidationStrategy.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.ModelBinding.Validation.IValidationStrategy

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.ModelBinding.Validation.IValidationStrategy
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Validation.IValidationStrategy.GetChildren(Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata, System.String, System.Object)
    
        
    
        Gets an :any:`System.Collections.Generic.IEnumerator\`1` containing a :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationEntry` for
        each child entry of the model object to be validated.
    
        
        
        
        :param metadata: The  associated with .
        
        :type metadata: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
        
        
        :param key: The model prefix associated with .
        
        :type key: System.String
        
        
        :param model: The model object.
        
        :type model: System.Object
        :rtype: System.Collections.Generic.IEnumerator{Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationEntry}
        :return: An <see cref="T:System.Collections.Generic.IEnumerator`1" />.
    
        
        .. code-block:: csharp
    
           IEnumerator<ValidationEntry> GetChildren(ModelMetadata metadata, string key, object model)
    

