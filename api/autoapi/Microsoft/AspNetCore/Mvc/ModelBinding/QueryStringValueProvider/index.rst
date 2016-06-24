

QueryStringValueProvider Class
==============================






An :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider` adapter for data stored in an :any:`Microsoft.AspNetCore.Http.IQueryCollection`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.QueryStringValueProvider`








Syntax
------

.. code-block:: csharp

    public class QueryStringValueProvider : BindingSourceValueProvider, IBindingSourceValueProvider, IEnumerableValueProvider, IValueProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.QueryStringValueProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.QueryStringValueProvider

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.QueryStringValueProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.QueryStringValueProvider.QueryStringValueProvider(Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource, Microsoft.AspNetCore.Http.IQueryCollection, System.Globalization.CultureInfo)
    
        
    
        
        Creates a value provider for :any:`Microsoft.AspNetCore.Http.IQueryCollection`\.
    
        
    
        
        :param bindingSource: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource` for the data.
        
        :type bindingSource: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource
    
        
        :param values: The key value pairs to wrap.
        
        :type values: Microsoft.AspNetCore.Http.IQueryCollection
    
        
        :param culture: The culture to return with ValueProviderResult instances.
        
        :type culture: System.Globalization.CultureInfo
    
        
        .. code-block:: csharp
    
            public QueryStringValueProvider(BindingSource bindingSource, IQueryCollection values, CultureInfo culture)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.QueryStringValueProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.QueryStringValueProvider.ContainsPrefix(System.String)
    
        
    
        
        :type prefix: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool ContainsPrefix(string prefix)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.QueryStringValueProvider.GetKeysFromPrefix(System.String)
    
        
    
        
        :type prefix: System.String
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public virtual IDictionary<string, string> GetKeysFromPrefix(string prefix)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.QueryStringValueProvider.GetValue(System.String)
    
        
    
        
        :type key: System.String
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ValueProviderResult
    
        
        .. code-block:: csharp
    
            public override ValueProviderResult GetValue(string key)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.QueryStringValueProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.QueryStringValueProvider.Culture
    
        
        :rtype: System.Globalization.CultureInfo
    
        
        .. code-block:: csharp
    
            public CultureInfo Culture { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.QueryStringValueProvider.PrefixContainer
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Internal.PrefixContainer
    
        
        .. code-block:: csharp
    
            protected PrefixContainer PrefixContainer { get; }
    

