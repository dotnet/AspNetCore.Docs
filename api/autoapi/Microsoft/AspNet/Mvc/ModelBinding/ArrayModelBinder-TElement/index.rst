

ArrayModelBinder<TElement> Class
================================



.. contents:: 
   :local:



Summary
-------

:any:`Microsoft.AspNet.Mvc.ModelBinding.IModelBinder` implementation for binding array values.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.CollectionModelBinder{{TElement}}`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.ArrayModelBinder\<TElement>`








Syntax
------

.. code-block:: csharp

   public class ArrayModelBinder<TElement> : CollectionModelBinder<TElement>, ICollectionModelBinder, IModelBinder





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/ModelBinding/ArrayModelBinder.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ArrayModelBinder<TElement>

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ArrayModelBinder<TElement>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ArrayModelBinder<TElement>.BindModelAsync(Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext)
    
        
        
        
        :type bindingContext: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Mvc.ModelBinding.ModelBindingResult}
    
        
        .. code-block:: csharp
    
           public override Task<ModelBindingResult> BindModelAsync(ModelBindingContext bindingContext)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ArrayModelBinder<TElement>.CanCreateInstance(System.Type)
    
        
        
        
        :type targetType: System.Type
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool CanCreateInstance(Type targetType)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ArrayModelBinder<TElement>.ConvertToCollectionType(System.Type, System.Collections.Generic.IEnumerable<TElement>)
    
        
        
        
        :type targetType: System.Type
        
        
        :type collection: System.Collections.Generic.IEnumerable{{TElement}}
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           protected override object ConvertToCollectionType(Type targetType, IEnumerable<TElement> collection)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ArrayModelBinder<TElement>.CopyToModel(System.Object, System.Collections.Generic.IEnumerable<TElement>)
    
        
        
        
        :type target: System.Object
        
        
        :type sourceCollection: System.Collections.Generic.IEnumerable{{TElement}}
    
        
        .. code-block:: csharp
    
           protected override void CopyToModel(object target, IEnumerable<TElement> sourceCollection)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ArrayModelBinder<TElement>.CreateEmptyCollection(System.Type)
    
        
        
        
        :type targetType: System.Type
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           protected override object CreateEmptyCollection(Type targetType)
    

