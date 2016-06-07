

DictionaryModelBinder<TKey, TValue> Class
=========================================






:any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder` implementation for binding dictionary values.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.Binders.CollectionModelBinder{System.Collections.Generic.KeyValuePair{{TKey},{TValue}}}`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.Binders.DictionaryModelBinder\<TKey, TValue>`








Syntax
------

.. code-block:: csharp

    public class DictionaryModelBinder<TKey, TValue> : CollectionModelBinder<KeyValuePair<TKey, TValue>>, ICollectionModelBinder, IModelBinder








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.DictionaryModelBinder`2
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.DictionaryModelBinder<TKey, TValue>

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.DictionaryModelBinder<TKey, TValue>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.DictionaryModelBinder<TKey, TValue>.DictionaryModelBinder(Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder, Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Binders.DictionaryModelBinder\`2`\.
    
        
    
        
        :param keyBinder: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder` for <em>TKey</em>.
        
        :type keyBinder: Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder
    
        
        :param valueBinder: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder` for <em>TValue</em>.
        
        :type valueBinder: Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder
    
        
        .. code-block:: csharp
    
            public DictionaryModelBinder(IModelBinder keyBinder, IModelBinder valueBinder)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.DictionaryModelBinder<TKey, TValue>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.DictionaryModelBinder<TKey, TValue>.BindModelAsync(Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext)
    
        
    
        
        :type bindingContext: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task BindModelAsync(ModelBindingContext bindingContext)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.DictionaryModelBinder<TKey, TValue>.CanCreateInstance(System.Type)
    
        
    
        
        :type targetType: System.Type
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool CanCreateInstance(Type targetType)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.DictionaryModelBinder<TKey, TValue>.ConvertToCollectionType(System.Type, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<TKey, TValue>>)
    
        
    
        
        :type targetType: System.Type
    
        
        :type collection: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{TKey, TValue}}
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            protected override object ConvertToCollectionType(Type targetType, IEnumerable<KeyValuePair<TKey, TValue>> collection)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.DictionaryModelBinder<TKey, TValue>.CreateEmptyCollection(System.Type)
    
        
    
        
        :type targetType: System.Type
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            protected override object CreateEmptyCollection(Type targetType)
    

