

ModelBindingContext Class
=========================






A context that contains operating information for model binding and validation.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext`








Syntax
------

.. code-block:: csharp

    public abstract class ModelBindingContext








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.BinderModelName
    
        
    
        
        Gets or sets a model name which is explicitly set using an :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelNameProvider`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public abstract string BinderModelName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.BindingSource
    
        
    
        
        Gets or sets a value which represents the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource` associated with the
        :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.Model`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource
    
        
        .. code-block:: csharp
    
            public abstract BindingSource BindingSource
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.FieldName
    
        
    
        
        Gets or sets the name of the current field being bound.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public abstract string FieldName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.IsTopLevelObject
    
        
    
        
        Gets or sets an indication that the current binder is handling the top-level object.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public abstract bool IsTopLevelObject
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.Model
    
        
    
        
        Gets or sets the model value for the current operation.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public abstract object Model
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.ModelMetadata
    
        
    
        
        Gets or sets the metadata for the model associated with this context.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        .. code-block:: csharp
    
            public abstract ModelMetadata ModelMetadata
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.ModelName
    
        
    
        
        Gets or sets the name of the model. This property is used as a key for looking up values in
        :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider` during model binding.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public abstract string ModelName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.ModelState
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary` used to capture :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.ModelState` values
        for properties in the object graph of the model when binding.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary
    
        
        .. code-block:: csharp
    
            public abstract ModelStateDictionary ModelState
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.ModelType
    
        
    
        
        Gets the type of the model.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
            public abstract Type ModelType
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.OperationBindingContext
    
        
    
        
        Represents the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.OperationBindingContext` associated with this context.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.OperationBindingContext
    
        
        .. code-block:: csharp
    
            public abstract OperationBindingContext OperationBindingContext
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.PropertyFilter
    
        
    
        
        Gets or sets a predicate which will be evaluated for each property to determine if the property
        is eligible for model binding.
    
        
        :rtype: System.Func<System.Func`2>{Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata<Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata>, System.Boolean<System.Boolean>}
    
        
        .. code-block:: csharp
    
            public abstract Func<ModelMetadata, bool> PropertyFilter
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.Result
    
        
    
        
        <p>
        On completion returns a :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult` which
        represents the result of the model binding process.
        </p>
        <p>
        If model binding was successful, the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult` should be a value created
        with :dn:meth:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult.Success(System.String,System.Object)`\. If model binding failed, the
        :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult` should be a value created with :dn:meth:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult.Failed(System.String)`\.
        If there was no data, or this model binder cannot handle the operation, the
        :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult` should be null.
        </p>
    
        
        :rtype: System.Nullable<System.Nullable`1>{Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult<Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult>}
    
        
        .. code-block:: csharp
    
            public abstract ModelBindingResult? Result
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.ValidationState
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationStateDictionary`\. Used for tracking validation state to
        customize validation behavior for a model object.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationStateDictionary
    
        
        .. code-block:: csharp
    
            public abstract ValidationStateDictionary ValidationState
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.ValueProvider
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider` associated with this context.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider
    
        
        .. code-block:: csharp
    
            public abstract IValueProvider ValueProvider
            {
                get;
                set;
            }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.EnterNestedScope()
    
        
    
        
        Pushes a layer of state onto this context. Model binders will call this as part of recursion when binding properties
        or collection items.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.NestedScope
        :return: A :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.NestedScope` scope object which should be used in a using statement where PushContext is called.
    
        
        .. code-block:: csharp
    
            public abstract ModelBindingContext.NestedScope EnterNestedScope()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.EnterNestedScope(Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata, System.String, System.String, System.Object)
    
        
    
        
        Pushes a layer of state onto this context. Model binders will call this as part of recursion when binding properties
        or collection items.
    
        
    
        
        :param modelMetadata: :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata` to assign to the :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.ModelMetadata` property.
        
        :type modelMetadata: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        :param fieldName: Name to assign to the :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.FieldName` property.
        
        :type fieldName: System.String
    
        
        :param modelName: Name to assign to the :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.ModelName` property.
        
        :type modelName: System.String
    
        
        :param model: Instance to assign to the :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.Model` property.
        
        :type model: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.NestedScope
        :return: A :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.NestedScope` scope object which should be used in a using statement where PushContext is called.
    
        
        .. code-block:: csharp
    
            public abstract ModelBindingContext.NestedScope EnterNestedScope(ModelMetadata modelMetadata, string fieldName, string modelName, object model)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.ExitNestedScope()
    
        
    
        
        Removes a layer of state pushed by calling :dn:meth:`EnterNestedScope`\.
    
        
    
        
        .. code-block:: csharp
    
            protected abstract void ExitNestedScope()
    

