

BindAttribute Class
===================



.. contents:: 
   :local:



Summary
-------

This attribute can be used on action parameters and types, to indicate model level metadata.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNet.Mvc.BindAttribute`








Syntax
------

.. code-block:: csharp

   public class BindAttribute : Attribute, _Attribute, IModelNameProvider, IPropertyBindingPredicateProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/BindAttribute.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.BindAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.BindAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.BindAttribute.BindAttribute(System.String[])
    
        
    
        Creates a new instace of :any:`Microsoft.AspNet.Mvc.BindAttribute`\.
    
        
        
        
        :param include: Names of parameters to include in binding.
        
        :type include: System.String[]
    
        
        .. code-block:: csharp
    
           public BindAttribute(params string[] include)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.BindAttribute.BindAttribute(System.Type)
    
        
    
        Creates a new instance of :any:`Microsoft.AspNet.Mvc.BindAttribute`\.
    
        
        
        
        :param predicateProviderType: The type which implements
            .
        
        :type predicateProviderType: System.Type
    
        
        .. code-block:: csharp
    
           public BindAttribute(Type predicateProviderType)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.BindAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.BindAttribute.Include
    
        
    
        Gets the names of properties to include in model binding.
    
        
        :rtype: System.String[]
    
        
        .. code-block:: csharp
    
           public string[] Include { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.BindAttribute.Microsoft.AspNet.Mvc.ModelBinding.IModelNameProvider.Name
    
        
    
        Represents the model name used during model binding.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string IModelNameProvider.Name { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.BindAttribute.PredicateProviderType
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
           public Type PredicateProviderType { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.BindAttribute.Prefix
    
        
    
        Allows a user to specify a particular prefix to match during model binding.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Prefix { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.BindAttribute.PropertyFilter
    
        
        :rtype: System.Func{Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext,System.String,System.Boolean}
    
        
        .. code-block:: csharp
    
           public Func<ModelBindingContext, string, bool> PropertyFilter { get; }
    

