

IModelBinderProvider Interface
==============================






Creates :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder` instances. Register :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinderProvider`
instances in <code>MvcOptions</code>.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IModelBinderProvider








.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinderProvider
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinderProvider

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinderProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinderProvider.GetBinder(Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderProviderContext)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder` based on :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderProviderContext`\.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderProviderContext`\.
        
        :type context: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderProviderContext
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder
        :return: An :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder`\.
    
        
        .. code-block:: csharp
    
            IModelBinder GetBinder(ModelBinderProviderContext context)
    

