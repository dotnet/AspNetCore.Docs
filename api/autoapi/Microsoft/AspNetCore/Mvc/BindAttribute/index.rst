

BindAttribute Class
===================






This attribute can be used on action parameters and types, to indicate model level metadata.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.BindAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
    public class BindAttribute : Attribute, _Attribute, IModelNameProvider, IPropertyFilterProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.BindAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.BindAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.BindAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.BindAttribute.BindAttribute(System.String[])
    
        
    
        
        Creates a new instace of :any:`Microsoft.AspNetCore.Mvc.BindAttribute`\.
    
        
    
        
        :param include: Names of parameters to include in binding.
        
        :type include: System.String<System.String>[]
    
        
        .. code-block:: csharp
    
            public BindAttribute(params string[] include)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.BindAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.BindAttribute.Include
    
        
    
        
        Gets the names of properties to include in model binding.
    
        
        :rtype: System.String<System.String>[]
    
        
        .. code-block:: csharp
    
            public string[] Include { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.BindAttribute.Microsoft.AspNetCore.Mvc.ModelBinding.IModelNameProvider.Name
    
        
    
        
        Represents the model name used during model binding.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string IModelNameProvider.Name { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.BindAttribute.Prefix
    
        
    
        
        Allows a user to specify a particular prefix to match during model binding.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Prefix { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.BindAttribute.PropertyFilter
    
        
        :rtype: System.Func<System.Func`2>{Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata<Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata>, System.Boolean<System.Boolean>}
    
        
        .. code-block:: csharp
    
            public Func<ModelMetadata, bool> PropertyFilter { get; }
    

