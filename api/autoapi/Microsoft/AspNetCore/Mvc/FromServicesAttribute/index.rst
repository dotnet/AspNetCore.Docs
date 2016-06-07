

FromServicesAttribute Class
===========================






Specifies that an action parameter should be bound using the request services.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.FromServicesAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
    public class FromServicesAttribute : Attribute, _Attribute, IBindingSourceMetadata








.. dn:class:: Microsoft.AspNetCore.Mvc.FromServicesAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.FromServicesAttribute

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.FromServicesAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.FromServicesAttribute.BindingSource
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource
    
        
        .. code-block:: csharp
    
            public BindingSource BindingSource
            {
                get;
            }
    

