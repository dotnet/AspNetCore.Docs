

ComplexTypeModelBinder Class
============================






:any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder` implementation for binding complex types.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding.Binders`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.Binders.ComplexTypeModelBinder`








Syntax
------

.. code-block:: csharp

    public class ComplexTypeModelBinder : IModelBinder








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.ComplexTypeModelBinder
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.ComplexTypeModelBinder

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.ComplexTypeModelBinder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.ComplexTypeModelBinder.ComplexTypeModelBinder(System.Collections.Generic.IDictionary<Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata, Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder>)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Binders.ComplexTypeModelBinder`\.
    
        
    
        
        :param propertyBinders: 
            The :any:`System.Collections.Generic.IDictionary\`2` of binders to use for binding properties.
        
        :type propertyBinders: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata<Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata>, Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder<Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder>}
    
        
        .. code-block:: csharp
    
            public ComplexTypeModelBinder(IDictionary<ModelMetadata, IModelBinder> propertyBinders)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.ComplexTypeModelBinder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.ComplexTypeModelBinder.BindModelAsync(Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext)
    
        
    
        
        :type bindingContext: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task BindModelAsync(ModelBindingContext bindingContext)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.ComplexTypeModelBinder.BindProperty(Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext)
    
        
    
        
        Attempts to bind a property of the model.
    
        
    
        
        :param bindingContext: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext` for the model property.
        
        :type bindingContext: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext
        :rtype: System.Threading.Tasks.Task
        :return: 
            A :any:`System.Threading.Tasks.Task` that when completed will set :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.Result` to the
            result of model binding.
    
        
        .. code-block:: csharp
    
            protected virtual Task BindProperty(ModelBindingContext bindingContext)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.ComplexTypeModelBinder.CanBindProperty(Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext, Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata)
    
        
    
        
        Gets a value indicating whether or not the model property identified by <em>propertyMetadata</em>
        can be bound.
    
        
    
        
        :param bindingContext: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext` for the container model.
        
        :type bindingContext: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext
    
        
        :param propertyMetadata: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata` for the model property.
        
        :type propertyMetadata: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
        :rtype: System.Boolean
        :return: <code>true</code> if the model property can be bound, otherwise <code>false</code>.
    
        
        .. code-block:: csharp
    
            protected virtual bool CanBindProperty(ModelBindingContext bindingContext, ModelMetadata propertyMetadata)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.ComplexTypeModelBinder.CreateModel(Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext)
    
        
    
        
        Creates suitable :any:`System.Object` for given <em>bindingContext</em>.
    
        
    
        
        :param bindingContext: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext`\.
        
        :type bindingContext: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext
        :rtype: System.Object
        :return: An :any:`System.Object` compatible with :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.ModelType`\.
    
        
        .. code-block:: csharp
    
            protected virtual object CreateModel(ModelBindingContext bindingContext)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.ComplexTypeModelBinder.SetProperty(Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext, System.String, Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata, Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult)
    
        
    
        
        Updates a property in the current :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.Model`\.
    
        
    
        
        :param bindingContext: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext`\.
        
        :type bindingContext: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext
    
        
        :param modelName: The model name.
        
        :type modelName: System.String
    
        
        :param propertyMetadata: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata` for the property to set.
        
        :type propertyMetadata: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        :param result: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult` for the property's new value.
        
        :type result: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult
    
        
        .. code-block:: csharp
    
            protected virtual void SetProperty(ModelBindingContext bindingContext, string modelName, ModelMetadata propertyMetadata, ModelBindingResult result)
    

