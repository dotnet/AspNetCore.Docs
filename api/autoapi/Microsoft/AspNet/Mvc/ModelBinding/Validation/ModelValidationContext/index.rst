

ModelValidationContext Class
============================



.. contents:: 
   :local:



Summary
-------

A context object for :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.IModelValidator`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelValidationContext`








Syntax
------

.. code-block:: csharp

   public class ModelValidationContext





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Abstractions/ModelBinding/Validation/ModelValidationContext.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelValidationContext

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelValidationContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelValidationContext.Container
    
        
    
        Gets or sets the model container object.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public object Container { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelValidationContext.Metadata
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata` associated with :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelValidationContext.Model`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
    
        
        .. code-block:: csharp
    
           public ModelMetadata Metadata { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelValidationContext.Model
    
        
    
        Gets or sets the model object.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public object Model { get; set; }
    

