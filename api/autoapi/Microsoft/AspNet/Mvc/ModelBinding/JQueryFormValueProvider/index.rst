

JQueryFormValueProvider Class
=============================



.. contents:: 
   :local:



Summary
-------

An :any:`Microsoft.AspNet.Mvc.ModelBinding.IValueProvider` for form data stored in an :any:`System.Collections.Generic.IDictionary\`2`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.BindingSourceValueProvider`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.JQueryFormValueProvider`








Syntax
------

.. code-block:: csharp

   public class JQueryFormValueProvider : BindingSourceValueProvider, IBindingSourceValueProvider, IEnumerableValueProvider, IValueProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/ModelBinding/JQueryFormValueProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.JQueryFormValueProvider

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.JQueryFormValueProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.JQueryFormValueProvider.JQueryFormValueProvider(Microsoft.AspNet.Mvc.ModelBinding.BindingSource, System.Collections.Generic.IDictionary<System.String, Microsoft.Extensions.Primitives.StringValues>, System.Globalization.CultureInfo)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.ModelBinding.DictionaryBasedValueProvider` class.
    
        
        
        
        :param bindingSource: The  of the data.
        
        :type bindingSource: Microsoft.AspNet.Mvc.ModelBinding.BindingSource
        
        
        :type values: System.Collections.Generic.IDictionary{System.String,Microsoft.Extensions.Primitives.StringValues}
        
        
        :param culture: The culture to return with ValueProviderResult instances.
        
        :type culture: System.Globalization.CultureInfo
    
        
        .. code-block:: csharp
    
           public JQueryFormValueProvider(BindingSource bindingSource, IDictionary<string, StringValues> values, CultureInfo culture)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.JQueryFormValueProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.JQueryFormValueProvider.ContainsPrefix(System.String)
    
        
        
        
        :type prefix: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool ContainsPrefix(string prefix)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.JQueryFormValueProvider.GetKeysFromPrefix(System.String)
    
        
        
        
        :type prefix: System.String
        :rtype: System.Collections.Generic.IDictionary{System.String,System.String}
    
        
        .. code-block:: csharp
    
           public IDictionary<string, string> GetKeysFromPrefix(string prefix)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.JQueryFormValueProvider.GetValue(System.String)
    
        
        
        
        :type key: System.String
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ValueProviderResult
    
        
        .. code-block:: csharp
    
           public override ValueProviderResult GetValue(string key)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.JQueryFormValueProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.JQueryFormValueProvider.PrefixContainer
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.PrefixContainer
    
        
        .. code-block:: csharp
    
           protected PrefixContainer PrefixContainer { get; }
    

