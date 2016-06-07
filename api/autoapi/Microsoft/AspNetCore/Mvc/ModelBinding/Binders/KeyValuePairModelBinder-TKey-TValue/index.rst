

KeyValuePairModelBinder<TKey, TValue> Class
===========================================






An :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder` for :any:`System.Collections.Generic.KeyValuePair\`2`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.Binders.KeyValuePairModelBinder\<TKey, TValue>`








Syntax
------

.. code-block:: csharp

    public class KeyValuePairModelBinder<TKey, TValue> : IModelBinder








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.KeyValuePairModelBinder`2
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.KeyValuePairModelBinder<TKey, TValue>

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.KeyValuePairModelBinder<TKey, TValue>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.KeyValuePairModelBinder<TKey, TValue>.KeyValuePairModelBinder(Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder, Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder)
    
        
    
        
        Creates a new :any:`System.Collections.Generic.KeyValuePair\`2`\.
    
        
    
        
        :param keyBinder: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder` for <em>TKey</em>.
        
        :type keyBinder: Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder
    
        
        :param valueBinder: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder` for <em>TValue</em>.
        
        :type valueBinder: Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder
    
        
        .. code-block:: csharp
    
            public KeyValuePairModelBinder(IModelBinder keyBinder, IModelBinder valueBinder)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.KeyValuePairModelBinder<TKey, TValue>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.KeyValuePairModelBinder<TKey, TValue>.BindModelAsync(Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext)
    
        
    
        
        :type bindingContext: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task BindModelAsync(ModelBindingContext bindingContext)
    

