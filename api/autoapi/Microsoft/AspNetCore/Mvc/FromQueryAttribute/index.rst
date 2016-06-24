

FromQueryAttribute Class
========================






Specifies that a parameter or property should be bound using the request query string.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.FromQueryAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
    public class FromQueryAttribute : Attribute, _Attribute, IBindingSourceMetadata, IModelNameProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.FromQueryAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.FromQueryAttribute

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.FromQueryAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.FromQueryAttribute.BindingSource
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource
    
        
        .. code-block:: csharp
    
            public BindingSource BindingSource { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.FromQueryAttribute.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Name { get; set; }
    

