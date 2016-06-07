

DefaultModelBindingContext Class
================================






A context that contains operating information for model binding and validation.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.DefaultModelBindingContext`








Syntax
------

.. code-block:: csharp

    public class DefaultModelBindingContext : ModelBindingContext








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.DefaultModelBindingContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.DefaultModelBindingContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.DefaultModelBindingContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.DefaultModelBindingContext.BinderModelName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string BinderModelName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.DefaultModelBindingContext.BindingSource
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource
    
        
        .. code-block:: csharp
    
            public override BindingSource BindingSource
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.DefaultModelBindingContext.FieldName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string FieldName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.DefaultModelBindingContext.IsTopLevelObject
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool IsTopLevelObject
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.DefaultModelBindingContext.Model
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public override object Model
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.DefaultModelBindingContext.ModelMetadata
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        .. code-block:: csharp
    
            public override ModelMetadata ModelMetadata
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.DefaultModelBindingContext.ModelName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ModelName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.DefaultModelBindingContext.ModelState
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary
    
        
        .. code-block:: csharp
    
            public override ModelStateDictionary ModelState
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.DefaultModelBindingContext.ModelType
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
            public override Type ModelType
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.DefaultModelBindingContext.OperationBindingContext
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.OperationBindingContext
    
        
        .. code-block:: csharp
    
            public override OperationBindingContext OperationBindingContext
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.DefaultModelBindingContext.PropertyFilter
    
        
        :rtype: System.Func<System.Func`2>{Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata<Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata>, System.Boolean<System.Boolean>}
    
        
        .. code-block:: csharp
    
            public override Func<ModelMetadata, bool> PropertyFilter
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.DefaultModelBindingContext.Result
    
        
        :rtype: System.Nullable<System.Nullable`1>{Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult<Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult>}
    
        
        .. code-block:: csharp
    
            public override ModelBindingResult? Result
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.DefaultModelBindingContext.ValidationState
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationStateDictionary
    
        
        .. code-block:: csharp
    
            public override ValidationStateDictionary ValidationState
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.DefaultModelBindingContext.ValueProvider
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider
    
        
        .. code-block:: csharp
    
            public override IValueProvider ValueProvider
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.DefaultModelBindingContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.DefaultModelBindingContext.DefaultModelBindingContext()
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.DefaultModelBindingContext` class.
    
        
    
        
        .. code-block:: csharp
    
            public DefaultModelBindingContext()
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.DefaultModelBindingContext
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.DefaultModelBindingContext.CreateBindingContext(Microsoft.AspNetCore.Mvc.ModelBinding.OperationBindingContext, Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata, Microsoft.AspNetCore.Mvc.ModelBinding.BindingInfo, System.String)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ModelBinding.DefaultModelBindingContext` for top-level model binding operation.
    
        
    
        
        :param operationBindingContext: 
            The :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.DefaultModelBindingContext.OperationBindingContext` associated with the binding operation.
        
        :type operationBindingContext: Microsoft.AspNetCore.Mvc.ModelBinding.OperationBindingContext
    
        
        :param metadata: :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.DefaultModelBindingContext.ModelMetadata` associated with the model.
        
        :type metadata: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        :param bindingInfo: :any:`Microsoft.AspNetCore.Mvc.ModelBinding.BindingInfo` associated with the model.
        
        :type bindingInfo: Microsoft.AspNetCore.Mvc.ModelBinding.BindingInfo
    
        
        :param modelName: The name of the property or parameter being bound.
        
        :type modelName: System.String
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext
        :return: A new instance of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.DefaultModelBindingContext`\.
    
        
        .. code-block:: csharp
    
            public static ModelBindingContext CreateBindingContext(OperationBindingContext operationBindingContext, ModelMetadata metadata, BindingInfo bindingInfo, string modelName)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.DefaultModelBindingContext.EnterNestedScope()
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.NestedScope
    
        
        .. code-block:: csharp
    
            public override ModelBindingContext.NestedScope EnterNestedScope()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.DefaultModelBindingContext.EnterNestedScope(Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata, System.String, System.String, System.Object)
    
        
    
        
        :type modelMetadata: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        :type fieldName: System.String
    
        
        :type modelName: System.String
    
        
        :type model: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.NestedScope
    
        
        .. code-block:: csharp
    
            public override ModelBindingContext.NestedScope EnterNestedScope(ModelMetadata modelMetadata, string fieldName, string modelName, object model)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.DefaultModelBindingContext.ExitNestedScope()
    
        
    
        
        .. code-block:: csharp
    
            protected override void ExitNestedScope()
    

