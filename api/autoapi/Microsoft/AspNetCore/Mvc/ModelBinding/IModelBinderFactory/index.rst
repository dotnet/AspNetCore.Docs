

IModelBinderFactory Interface
=============================






A factory abstraction for creating :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder` instances.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IModelBinderFactory








.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinderFactory
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinderFactory

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinderFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinderFactory.CreateBinder(Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderFactoryContext)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder`\.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderFactoryContext`\.
        
        :type context: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderFactoryContext
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder
        :return: An :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder` instance.
    
        
        .. code-block:: csharp
    
            IModelBinder CreateBinder(ModelBinderFactoryContext context)
    

