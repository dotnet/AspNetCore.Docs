

FromBodyAttribute Class
=======================






Specifies that a parameter or property should be bound using the request body.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.FromBodyAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
    public class FromBodyAttribute : Attribute, _Attribute, IBindingSourceMetadata








.. dn:class:: Microsoft.AspNetCore.Mvc.FromBodyAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.FromBodyAttribute

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.FromBodyAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.FromBodyAttribute.BindingSource
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource
    
        
        .. code-block:: csharp
    
            public BindingSource BindingSource
            {
                get;
            }
    

