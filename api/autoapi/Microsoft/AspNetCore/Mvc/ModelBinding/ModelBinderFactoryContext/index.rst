

ModelBinderFactoryContext Class
===============================






A context object for :dn:meth:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderFactory.CreateBinder(Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderFactoryContext)`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderFactoryContext`








Syntax
------

.. code-block:: csharp

    public class ModelBinderFactoryContext








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderFactoryContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderFactoryContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderFactoryContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderFactoryContext.BindingInfo
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.BindingInfo`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.BindingInfo
    
        
        .. code-block:: csharp
    
            public BindingInfo BindingInfo { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderFactoryContext.CacheToken
    
        
    
        
        Gets or sets the cache token. If <code>non-null</code> the resulting :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder`
        will be cached.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public object CacheToken { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderFactoryContext.Metadata
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        .. code-block:: csharp
    
            public ModelMetadata Metadata { get; set; }
    

