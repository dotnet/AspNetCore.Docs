

DictionaryBasedValueProvider Class
==================================



.. contents:: 
   :local:



Summary
-------

An :any:`Microsoft.AspNet.Mvc.ModelBinding.IValueProvider` adapter for data stored in an 
:any:`System.Collections.Generic.IDictionary\`2`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.BindingSourceValueProvider`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.DictionaryBasedValueProvider`








Syntax
------

.. code-block:: csharp

   public class DictionaryBasedValueProvider : BindingSourceValueProvider, IBindingSourceValueProvider, IValueProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ModelBinding/DictionaryBasedValueProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.DictionaryBasedValueProvider

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.DictionaryBasedValueProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.DictionaryBasedValueProvider.DictionaryBasedValueProvider(Microsoft.AspNet.Mvc.ModelBinding.BindingSource, System.Collections.Generic.IDictionary<System.String, System.Object>)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ModelBinding.DictionaryBasedValueProvider`\.
    
        
        
        
        :param bindingSource: The  of the data.
        
        :type bindingSource: Microsoft.AspNet.Mvc.ModelBinding.BindingSource
        
        
        :param values: The values.
        
        :type values: System.Collections.Generic.IDictionary{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           public DictionaryBasedValueProvider(BindingSource bindingSource, IDictionary<string, object> values)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.DictionaryBasedValueProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.DictionaryBasedValueProvider.ContainsPrefix(System.String)
    
        
        
        
        :type key: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool ContainsPrefix(string key)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.DictionaryBasedValueProvider.GetValue(System.String)
    
        
        
        
        :type key: System.String
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ValueProviderResult
    
        
        .. code-block:: csharp
    
           public override ValueProviderResult GetValue(string key)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.DictionaryBasedValueProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.DictionaryBasedValueProvider.PrefixContainer
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.PrefixContainer
    
        
        .. code-block:: csharp
    
           protected PrefixContainer PrefixContainer { get; }
    

