

CompositeModelBinder Class
==========================



.. contents:: 
   :local:



Summary
-------

Represents an :any:`Microsoft.AspNet.Mvc.ModelBinding.IModelBinder` that delegates to one of a collection of :any:`Microsoft.AspNet.Mvc.ModelBinding.IModelBinder`
instances.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.CompositeModelBinder`








Syntax
------

.. code-block:: csharp

   public class CompositeModelBinder : ICompositeModelBinder, IModelBinder





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/ModelBinding/CompositeModelBinder.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.CompositeModelBinder

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.CompositeModelBinder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.CompositeModelBinder.CompositeModelBinder(System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.ModelBinding.IModelBinder>)
    
        
    
        Initializes a new instance of the CompositeModelBinder class.
    
        
        
        
        :param modelBinders: A collection of  instances.
        
        :type modelBinders: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.ModelBinding.IModelBinder}
    
        
        .. code-block:: csharp
    
           public CompositeModelBinder(IEnumerable<IModelBinder> modelBinders)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.CompositeModelBinder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.CompositeModelBinder.BindModelAsync(Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext)
    
        
        
        
        :type bindingContext: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Mvc.ModelBinding.ModelBindingResult}
    
        
        .. code-block:: csharp
    
           public virtual Task<ModelBindingResult> BindModelAsync(ModelBindingContext bindingContext)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.CompositeModelBinder
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.CompositeModelBinder.ModelBinders
    
        
        :rtype: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Mvc.ModelBinding.IModelBinder}
    
        
        .. code-block:: csharp
    
           public IReadOnlyList<IModelBinder> ModelBinders { get; }
    

