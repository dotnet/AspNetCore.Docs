

DictionaryModelBinder<TKey, TValue> Class
=========================================



.. contents:: 
   :local:



Summary
-------

:any:`Microsoft.AspNet.Mvc.ModelBinding.IModelBinder` implementation for binding dictionary values.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.CollectionModelBinder{System.Collections.Generic.KeyValuePair{{TKey},{TValue}}}`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.DictionaryModelBinder\<TKey, TValue>`








Syntax
------

.. code-block:: csharp

   public class DictionaryModelBinder<TKey, TValue> : CollectionModelBinder<KeyValuePair<TKey, TValue>>, ICollectionModelBinder, IModelBinder





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ModelBinding/DictionaryModelBinder.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.DictionaryModelBinder<TKey, TValue>

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.DictionaryModelBinder<TKey, TValue>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.DictionaryModelBinder<TKey, TValue>.BindModelAsync(Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext)
    
        
        
        
        :type bindingContext: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Mvc.ModelBinding.ModelBindingResult}
    
        
        .. code-block:: csharp
    
           public override Task<ModelBindingResult> BindModelAsync(ModelBindingContext bindingContext)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.DictionaryModelBinder<TKey, TValue>.ConvertToCollectionType(System.Type, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<TKey, TValue>>)
    
        
        
        
        :type targetType: System.Type
        
        
        :type collection: System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{{TKey},{TValue}}}
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           protected override object ConvertToCollectionType(Type targetType, IEnumerable<KeyValuePair<TKey, TValue>> collection)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.DictionaryModelBinder<TKey, TValue>.CreateEmptyCollection(System.Type)
    
        
        
        
        :type targetType: System.Type
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           protected override object CreateEmptyCollection(Type targetType)
    

