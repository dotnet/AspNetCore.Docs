

BindNeverAttribute Class
========================






Indicates that a property should be excluded from model binding. When applied to a property, the model binding
system excludes that property. When applied to a type, the model binding system excludes all properties of that
type.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.BindNeverAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class BindNeverAttribute : BindingBehaviorAttribute, _Attribute








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.BindNeverAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.BindNeverAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.BindNeverAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.BindNeverAttribute.BindNeverAttribute()
    
        
    
        
        Initializes a new :any:`Microsoft.AspNetCore.Mvc.ModelBinding.BindNeverAttribute` instance.
    
        
    
        
        .. code-block:: csharp
    
            public BindNeverAttribute()
    

