

MutableObjectBinderContext Class
================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.MutableObjectBinderContext`








Syntax
------

.. code-block:: csharp

   public class MutableObjectBinderContext





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ModelBinding/MutableObjectModelBinderContext.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.MutableObjectBinderContext

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.MutableObjectBinderContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.MutableObjectBinderContext.ModelBindingContext
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext
    
        
        .. code-block:: csharp
    
           public ModelBindingContext ModelBindingContext { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.MutableObjectBinderContext.PropertyMetadata
    
        
        :rtype: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata}
    
        
        .. code-block:: csharp
    
           public IReadOnlyList<ModelMetadata> PropertyMetadata { get; set; }
    

