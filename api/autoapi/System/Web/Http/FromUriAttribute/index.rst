

FromUriAttribute Class
======================






An attribute that specifies that the value can be bound from the query string or route data.


Namespace
    :dn:ns:`System.Web.Http`
Assemblies
    * Microsoft.AspNetCore.Mvc.WebApiCompatShim

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`System.Web.Http.FromUriAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
    public class FromUriAttribute : Attribute, _Attribute, IOptionalBinderMetadata, IBindingSourceMetadata, IModelNameProvider








.. dn:class:: System.Web.Http.FromUriAttribute
    :hidden:

.. dn:class:: System.Web.Http.FromUriAttribute

Properties
----------

.. dn:class:: System.Web.Http.FromUriAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: System.Web.Http.FromUriAttribute.BindingSource
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource
    
        
        .. code-block:: csharp
    
            public BindingSource BindingSource { get; }
    
    .. dn:property:: System.Web.Http.FromUriAttribute.IsOptional
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsOptional { get; set; }
    
    .. dn:property:: System.Web.Http.FromUriAttribute.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Name { get; set; }
    

