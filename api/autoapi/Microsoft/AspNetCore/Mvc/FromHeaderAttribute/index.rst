

FromHeaderAttribute Class
=========================






Specifies that a parameter or property should be bound using the request headers.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.FromHeaderAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
    public class FromHeaderAttribute : Attribute, _Attribute, IBindingSourceMetadata, IModelNameProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.FromHeaderAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.FromHeaderAttribute

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.FromHeaderAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.FromHeaderAttribute.BindingSource
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource
    
        
        .. code-block:: csharp
    
            public BindingSource BindingSource
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.FromHeaderAttribute.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Name
            {
                get;
                set;
            }
    

