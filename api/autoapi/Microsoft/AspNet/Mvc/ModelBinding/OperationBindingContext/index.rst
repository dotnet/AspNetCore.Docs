

OperationBindingContext Class
=============================



.. contents:: 
   :local:



Summary
-------

A context that contains information specific to the current request and the action whose parameters
are being model bound.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.OperationBindingContext`








Syntax
------

.. code-block:: csharp

   public class OperationBindingContext





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Abstractions/ModelBinding/OperationBindingContext.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.OperationBindingContext

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.OperationBindingContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.OperationBindingContext.HttpContext
    
        
    
        Gets or sets the :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.OperationBindingContext.HttpContext` for the current request.
    
        
        :rtype: Microsoft.AspNet.Http.HttpContext
    
        
        .. code-block:: csharp
    
           public HttpContext HttpContext { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.OperationBindingContext.InputFormatters
    
        
    
        Gets or sets the set of :any:`Microsoft.AspNet.Mvc.Formatters.IInputFormatter` instances associated with this context.
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.Formatters.IInputFormatter}
    
        
        .. code-block:: csharp
    
           public IList<IInputFormatter> InputFormatters { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.OperationBindingContext.MetadataProvider
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider` associated with this context.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider
    
        
        .. code-block:: csharp
    
           public IModelMetadataProvider MetadataProvider { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.OperationBindingContext.ModelBinder
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Mvc.ModelBinding.IModelBinder` associated with this context.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.IModelBinder
    
        
        .. code-block:: csharp
    
           public IModelBinder ModelBinder { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.OperationBindingContext.ValidatorProvider
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.IModelValidatorProvider` instance used for model validation with this
        context.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.Validation.IModelValidatorProvider
    
        
        .. code-block:: csharp
    
           public IModelValidatorProvider ValidatorProvider { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.OperationBindingContext.ValueProvider
    
        
    
        Gets unaltered value provider collection.
        Value providers can be filtered by specific model binders.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.IValueProvider
    
        
        .. code-block:: csharp
    
           public IValueProvider ValueProvider { get; set; }
    

