

BinderTypeModelBinder Class
===========================






An :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder` for models which specify an :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder` using 
:dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.BindingInfo.BinderType`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.Binders.BinderTypeModelBinder`








Syntax
------

.. code-block:: csharp

    public class BinderTypeModelBinder : IModelBinder








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.BinderTypeModelBinder
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.BinderTypeModelBinder

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.BinderTypeModelBinder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.BinderTypeModelBinder.BinderTypeModelBinder(System.Type)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Binders.BinderTypeModelBinder`\.
    
        
    
        
        :param binderType: The :any:`System.Type` of the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder`\.
        
        :type binderType: System.Type
    
        
        .. code-block:: csharp
    
            public BinderTypeModelBinder(Type binderType)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.BinderTypeModelBinder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.BinderTypeModelBinder.BindModelAsync(Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext)
    
        
    
        
        :type bindingContext: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task BindModelAsync(ModelBindingContext bindingContext)
    

