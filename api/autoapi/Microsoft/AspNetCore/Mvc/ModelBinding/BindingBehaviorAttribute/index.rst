

BindingBehaviorAttribute Class
==============================





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








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class BindingBehaviorAttribute : Attribute, _Attribute








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingBehaviorAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingBehaviorAttribute

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingBehaviorAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingBehaviorAttribute.Behavior
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.BindingBehavior
    
        
        .. code-block:: csharp
    
            public BindingBehavior Behavior
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingBehaviorAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingBehaviorAttribute.BindingBehaviorAttribute(Microsoft.AspNetCore.Mvc.ModelBinding.BindingBehavior)
    
        
    
        
        :type behavior: Microsoft.AspNetCore.Mvc.ModelBinding.BindingBehavior
    
        
        .. code-block:: csharp
    
            public BindingBehaviorAttribute(BindingBehavior behavior)
    

