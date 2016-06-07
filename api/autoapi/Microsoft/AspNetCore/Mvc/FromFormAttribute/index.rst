

FromFormAttribute Class
=======================






Specifies that a parameter or property should be bound using form-data in the request body.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.FromFormAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
    public class FromFormAttribute : Attribute, _Attribute, IBindingSourceMetadata, IModelNameProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.FromFormAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.FromFormAttribute

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.FromFormAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.FromFormAttribute.BindingSource
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource
    
        
        .. code-block:: csharp
    
            public BindingSource BindingSource
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.FromFormAttribute.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Name
            {
                get;
                set;
            }
    

