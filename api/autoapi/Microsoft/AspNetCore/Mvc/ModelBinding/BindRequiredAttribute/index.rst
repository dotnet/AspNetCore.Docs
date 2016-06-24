

BindRequiredAttribute Class
===========================






Indicates that a property is required for model binding. When applied to a property, the model binding system
requires a value for that property. When applied to a type, the model binding system requires values for all
properties of that type.


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
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.BindingBehaviorAttribute`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.BindRequiredAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class BindRequiredAttribute : BindingBehaviorAttribute, _Attribute








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.BindRequiredAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.BindRequiredAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.BindRequiredAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.BindRequiredAttribute.BindRequiredAttribute()
    
        
    
        
        Initializes a new :any:`Microsoft.AspNetCore.Mvc.ModelBinding.BindRequiredAttribute` instance.
    
        
    
        
        .. code-block:: csharp
    
            public BindRequiredAttribute()
    

