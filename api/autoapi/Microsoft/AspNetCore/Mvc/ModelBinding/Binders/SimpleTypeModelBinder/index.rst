

SimpleTypeModelBinder Class
===========================






An :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder` for simple types.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.Binders.SimpleTypeModelBinder`








Syntax
------

.. code-block:: csharp

    public class SimpleTypeModelBinder : IModelBinder








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.SimpleTypeModelBinder
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.SimpleTypeModelBinder

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.SimpleTypeModelBinder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.SimpleTypeModelBinder.SimpleTypeModelBinder(System.Type)
    
        
    
        
        :type type: System.Type
    
        
        .. code-block:: csharp
    
            public SimpleTypeModelBinder(Type type)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.SimpleTypeModelBinder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.SimpleTypeModelBinder.BindModelAsync(Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext)
    
        
    
        
        :type bindingContext: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task BindModelAsync(ModelBindingContext bindingContext)
    

