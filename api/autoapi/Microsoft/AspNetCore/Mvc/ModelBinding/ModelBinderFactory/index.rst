

ModelBinderFactory Class
========================






A factory for :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder` instances.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderFactory`








Syntax
------

.. code-block:: csharp

    public class ModelBinderFactory : IModelBinderFactory








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderFactory
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderFactory

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderFactory
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderFactory.ModelBinderFactory(Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Mvc.MvcOptions>)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderFactory`\.
    
        
    
        
        :param metadataProvider: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider`\.
        
        :type metadataProvider: Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider
    
        
        :param options: The :any:`Microsoft.Extensions.Options.IOptions\`1` for :any:`Microsoft.AspNetCore.Mvc.MvcOptions`\.
        
        :type options: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Mvc.MvcOptions<Microsoft.AspNetCore.Mvc.MvcOptions>}
    
        
        .. code-block:: csharp
    
            public ModelBinderFactory(IModelMetadataProvider metadataProvider, IOptions<MvcOptions> options)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderFactory.CreateBinder(Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderFactoryContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderFactoryContext
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder
    
        
        .. code-block:: csharp
    
            public IModelBinder CreateBinder(ModelBinderFactoryContext context)
    

