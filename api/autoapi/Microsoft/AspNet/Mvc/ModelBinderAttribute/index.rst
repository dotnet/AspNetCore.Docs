

ModelBinderAttribute Class
==========================



.. contents:: 
   :local:



Summary
-------

An attribute that can specify a model name or type of :any:`Microsoft.AspNet.Mvc.ModelBinding.IModelBinder` to use for binding.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinderAttribute`








Syntax
------

.. code-block:: csharp

   public class ModelBinderAttribute : Attribute, _Attribute, IModelNameProvider, IBinderTypeProviderMetadata, IBindingSourceMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/ModelBinderAttribute.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinderAttribute

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinderAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinderAttribute.BinderType
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
           public Type BinderType { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinderAttribute.BindingSource
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.BindingSource
    
        
        .. code-block:: csharp
    
           public BindingSource BindingSource { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinderAttribute.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Name { get; set; }
    

