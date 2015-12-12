

ReadableStringCollectionValueProvider Class
===========================================



.. contents:: 
   :local:



Summary
-------

An :any:`Microsoft.AspNet.Mvc.ModelBinding.IValueProvider` adapter for data stored in an :any:`Microsoft.AspNet.Http.IReadableStringCollection`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.BindingSourceValueProvider`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.ReadableStringCollectionValueProvider`








Syntax
------

.. code-block:: csharp

   public class ReadableStringCollectionValueProvider : BindingSourceValueProvider, IBindingSourceValueProvider, IEnumerableValueProvider, IValueProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/ModelBinding/ReadableStringCollectionValueProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ReadableStringCollectionValueProvider

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ReadableStringCollectionValueProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.ReadableStringCollectionValueProvider.ReadableStringCollectionValueProvider(Microsoft.AspNet.Mvc.ModelBinding.BindingSource, Microsoft.AspNet.Http.IReadableStringCollection, System.Globalization.CultureInfo)
    
        
    
        Creates a provider for :any:`Microsoft.AspNet.Http.IReadableStringCollection` wrapping an existing set of key value pairs.
    
        
        
        
        :param bindingSource: The  for the data.
        
        :type bindingSource: Microsoft.AspNet.Mvc.ModelBinding.BindingSource
        
        
        :param values: The key value pairs to wrap.
        
        :type values: Microsoft.AspNet.Http.IReadableStringCollection
        
        
        :param culture: The culture to return with ValueProviderResult instances.
        
        :type culture: System.Globalization.CultureInfo
    
        
        .. code-block:: csharp
    
           public ReadableStringCollectionValueProvider(BindingSource bindingSource, IReadableStringCollection values, CultureInfo culture)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ReadableStringCollectionValueProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ReadableStringCollectionValueProvider.ContainsPrefix(System.String)
    
        
        
        
        :type prefix: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool ContainsPrefix(string prefix)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ReadableStringCollectionValueProvider.GetKeysFromPrefix(System.String)
    
        
        
        
        :type prefix: System.String
        :rtype: System.Collections.Generic.IDictionary{System.String,System.String}
    
        
        .. code-block:: csharp
    
           public virtual IDictionary<string, string> GetKeysFromPrefix(string prefix)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ReadableStringCollectionValueProvider.GetValue(System.String)
    
        
        
        
        :type key: System.String
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ValueProviderResult
    
        
        .. code-block:: csharp
    
           public override ValueProviderResult GetValue(string key)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ReadableStringCollectionValueProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ReadableStringCollectionValueProvider.Culture
    
        
        :rtype: System.Globalization.CultureInfo
    
        
        .. code-block:: csharp
    
           public CultureInfo Culture { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ReadableStringCollectionValueProvider.PrefixContainer
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.PrefixContainer
    
        
        .. code-block:: csharp
    
           protected PrefixContainer PrefixContainer { get; }
    

