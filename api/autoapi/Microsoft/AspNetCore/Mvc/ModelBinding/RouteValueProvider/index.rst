

RouteValueProvider Class
========================






An :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider` adapter for data stored in an :any:`Microsoft.AspNetCore.Routing.RouteValueDictionary`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.BindingSourceValueProvider`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.RouteValueProvider`








Syntax
------

.. code-block:: csharp

    public class RouteValueProvider : BindingSourceValueProvider, IBindingSourceValueProvider, IValueProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.RouteValueProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.RouteValueProvider

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.RouteValueProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.RouteValueProvider.PrefixContainer
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Internal.PrefixContainer
    
        
        .. code-block:: csharp
    
            protected PrefixContainer PrefixContainer
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.RouteValueProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.RouteValueProvider.RouteValueProvider(Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource, Microsoft.AspNetCore.Routing.RouteValueDictionary)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ModelBinding.RouteValueProvider`\.
    
        
    
        
        :param bindingSource: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource` of the data.
        
        :type bindingSource: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource
    
        
        :param values: The values.
        
        :type values: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        .. code-block:: csharp
    
            public RouteValueProvider(BindingSource bindingSource, RouteValueDictionary values)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.RouteValueProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.RouteValueProvider.ContainsPrefix(System.String)
    
        
    
        
        :type key: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool ContainsPrefix(string key)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.RouteValueProvider.GetValue(System.String)
    
        
    
        
        :type key: System.String
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ValueProviderResult
    
        
        .. code-block:: csharp
    
            public override ValueProviderResult GetValue(string key)
    

