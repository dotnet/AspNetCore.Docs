

ModelBinderAttribute Class
==========================






An attribute that can specify a model name or type of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder` to use for binding.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinderAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Property | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
    public class ModelBinderAttribute : Attribute, _Attribute, IModelNameProvider, IBinderTypeProviderMetadata, IBindingSourceMetadata








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinderAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinderAttribute

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinderAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinderAttribute.BinderType
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
            public Type BinderType { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinderAttribute.BindingSource
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource
    
        
        .. code-block:: csharp
    
            public virtual BindingSource BindingSource { get; protected set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinderAttribute.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Name { get; set; }
    

