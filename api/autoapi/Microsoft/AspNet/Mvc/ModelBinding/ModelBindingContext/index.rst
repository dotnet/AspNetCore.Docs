

ModelBindingContext Class
=========================



.. contents:: 
   :local:



Summary
-------

A context that contains operating information for model binding and validation.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext`








Syntax
------

.. code-block:: csharp

   public class ModelBindingContext





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Abstractions/ModelBinding/ModelBindingContext.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext.ModelBindingContext()
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext` class.
    
        
    
        
        .. code-block:: csharp
    
           public ModelBindingContext()
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext.CreateBindingContext(Microsoft.AspNet.Mvc.ModelBinding.OperationBindingContext, Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary, Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata, Microsoft.AspNet.Mvc.ModelBinding.BindingInfo, System.String)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext` for top-level model binding operation.
    
        
        
        
        :param operationBindingContext: The  associated with the binding operation.
        
        :type operationBindingContext: Microsoft.AspNet.Mvc.ModelBinding.OperationBindingContext
        
        
        :type modelState: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary
        
        
        :param metadata: associated with the model.
        
        :type metadata: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
        
        
        :param bindingInfo: associated with the model.
        
        :type bindingInfo: Microsoft.AspNet.Mvc.ModelBinding.BindingInfo
        
        
        :param modelName: The name of the property or parameter being bound.
        
        :type modelName: System.String
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext
        :return: A new instance of <see cref="T:Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext" />.
    
        
        .. code-block:: csharp
    
           public static ModelBindingContext CreateBindingContext(OperationBindingContext operationBindingContext, ModelStateDictionary modelState, ModelMetadata metadata, BindingInfo bindingInfo, string modelName)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext.CreateChildBindingContext(Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext, Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata, System.String, System.String, System.Object)
    
        
        
        
        :type parent: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext
        
        
        :type modelMetadata: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
        
        
        :type fieldName: System.String
        
        
        :type modelName: System.String
        
        
        :type model: System.Object
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext
    
        
        .. code-block:: csharp
    
           public static ModelBindingContext CreateChildBindingContext(ModelBindingContext parent, ModelMetadata modelMetadata, string fieldName, string modelName, object model)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext.BinderModelName
    
        
    
        Gets or sets a model name which is explicitly set using an :any:`Microsoft.AspNet.Mvc.ModelBinding.IModelNameProvider`\. 
        :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext.Model`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string BinderModelName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext.BinderType
    
        
    
        Gets the :any:`System.Type` of an :any:`Microsoft.AspNet.Mvc.ModelBinding.IModelBinder` associated with the 
        :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext.Model`\.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
           public Type BinderType { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext.BindingSource
    
        
    
        Gets or sets a value which represents the :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext.BindingSource` associated with the 
        :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext.Model`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.BindingSource
    
        
        .. code-block:: csharp
    
           public BindingSource BindingSource { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext.FallbackToEmptyPrefix
    
        
    
        Gets or sets a value that indicates whether the binder should use an empty prefix to look up
        values in :any:`Microsoft.AspNet.Mvc.ModelBinding.IValueProvider` when no values are found using the :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext.ModelName` prefix.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool FallbackToEmptyPrefix { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext.FieldName
    
        
    
        Gets or sets the name of the current field being bound.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string FieldName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext.IsTopLevelObject
    
        
    
        Gets or sets an indication that the current binder is handling the top-level object.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsTopLevelObject { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext.Model
    
        
    
        Gets or sets the model value for the current operation.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public object Model { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext.ModelMetadata
    
        
    
        Gets or sets the metadata for the model associated with this context.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
    
        
        .. code-block:: csharp
    
           public ModelMetadata ModelMetadata { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext.ModelName
    
        
    
        Gets or sets the name of the model. This property is used as a key for looking up values in 
        :any:`Microsoft.AspNet.Mvc.ModelBinding.IValueProvider` during model binding.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ModelName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext.ModelState
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary` used to capture :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext.ModelState` values
        for properties in the object graph of the model when binding.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary
    
        
        .. code-block:: csharp
    
           public ModelStateDictionary ModelState { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext.ModelType
    
        
    
        Gets the type of the model.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
           public Type ModelType { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext.OperationBindingContext
    
        
    
        Represents the :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext.OperationBindingContext` associated with this context.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.OperationBindingContext
    
        
        .. code-block:: csharp
    
           public OperationBindingContext OperationBindingContext { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext.PropertyFilter
    
        
    
        Gets or sets a predicate which will be evaluated for each property to determine if the property
        is eligible for model binding.
    
        
        :rtype: System.Func{Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext,System.String,System.Boolean}
    
        
        .. code-block:: csharp
    
           public Func<ModelBindingContext, string, bool> PropertyFilter { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext.ValidationState
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateDictionary`\. Used for tracking validation state to
        customize validation behavior for a model object.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.Validation.ValidationStateDictionary
    
        
        .. code-block:: csharp
    
           public ValidationStateDictionary ValidationState { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext.ValueProvider
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Mvc.ModelBinding.IValueProvider` associated with this context.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.IValueProvider
    
        
        .. code-block:: csharp
    
           public IValueProvider ValueProvider { get; set; }
    

