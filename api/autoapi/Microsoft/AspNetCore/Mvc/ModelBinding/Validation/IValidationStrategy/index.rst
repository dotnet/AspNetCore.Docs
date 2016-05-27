

IValidationStrategy Interface
=============================






Defines a strategy for enumerating the child entries of a model object which should be validated.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IValidationStrategy








.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IValidationStrategy
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IValidationStrategy

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IValidationStrategy
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IValidationStrategy.GetChildren(Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata, System.String, System.Object)
    
        
    
        
        Gets an :any:`System.Collections.Generic.IEnumerator\`1` containing a :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationEntry` for
        each child entry of the model object to be validated.
    
        
    
        
        :param metadata: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata` associated with <em>model</em>.
        
        :type metadata: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        :param key: The model prefix associated with <em>model</em>.
        
        :type key: System.String
    
        
        :param model: The model object.
        
        :type model: System.Object
        :rtype: System.Collections.Generic.IEnumerator<System.Collections.Generic.IEnumerator`1>{Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationEntry<Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationEntry>}
        :return: An :any:`System.Collections.Generic.IEnumerator\`1`\.
    
        
        .. code-block:: csharp
    
            IEnumerator<ValidationEntry> GetChildren(ModelMetadata metadata, string key, object model)
    

