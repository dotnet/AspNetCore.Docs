

OperationBindingContext Class
=============================






A context that contains information specific to the current request and the action whose parameters
are being model bound.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.OperationBindingContext`








Syntax
------

.. code-block:: csharp

    public class OperationBindingContext








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.OperationBindingContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.OperationBindingContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.OperationBindingContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.OperationBindingContext.ActionContext
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.ActionContext` for the current request.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        .. code-block:: csharp
    
            public ActionContext ActionContext
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.OperationBindingContext.HttpContext
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Http.HttpContext` for the current request.
    
        
        :rtype: Microsoft.AspNetCore.Http.HttpContext
    
        
        .. code-block:: csharp
    
            public HttpContext HttpContext
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.OperationBindingContext.InputFormatters
    
        
    
        
        Gets or sets the set of :any:`Microsoft.AspNetCore.Mvc.Formatters.IInputFormatter` instances associated with this context.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.Formatters.IInputFormatter<Microsoft.AspNetCore.Mvc.Formatters.IInputFormatter>}
    
        
        .. code-block:: csharp
    
            public IList<IInputFormatter> InputFormatters
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.OperationBindingContext.MetadataProvider
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider` associated with this context.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider
    
        
        .. code-block:: csharp
    
            public IModelMetadataProvider MetadataProvider
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.OperationBindingContext.ValidatorProvider
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidatorProvider` instance used for model validation with this
        context.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidatorProvider
    
        
        .. code-block:: csharp
    
            public IModelValidatorProvider ValidatorProvider
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.OperationBindingContext.ValueProvider
    
        
    
        
        Gets unaltered value provider collection.
        Value providers can be filtered by specific model binders.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider
    
        
        .. code-block:: csharp
    
            public IValueProvider ValueProvider
            {
                get;
                set;
            }
    

