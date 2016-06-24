

FromRouteAttribute Class
========================






Specifies that a parameter or property should be bound using route-data from the current request.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.FromRouteAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
    public class FromRouteAttribute : Attribute, _Attribute, IBindingSourceMetadata, IModelNameProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.FromRouteAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.FromRouteAttribute

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.FromRouteAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.FromRouteAttribute.BindingSource
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource
    
        
        .. code-block:: csharp
    
            public BindingSource BindingSource { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.FromRouteAttribute.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Name { get; set; }
    

