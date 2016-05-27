

CompositeValueProvider Class
============================






Represents a :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider` whose values come from a collection of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider`\s.


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
* :dn:cls:`System.Collections.ObjectModel.Collection{Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider}`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.CompositeValueProvider`








Syntax
------

.. code-block:: csharp

    public class CompositeValueProvider : Collection<IValueProvider>, IList<IValueProvider>, ICollection<IValueProvider>, IList, ICollection, IReadOnlyList<IValueProvider>, IReadOnlyCollection<IValueProvider>, IEnumerable<IValueProvider>, IEnumerable, IEnumerableValueProvider, IBindingSourceValueProvider, IValueProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.CompositeValueProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.CompositeValueProvider

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.CompositeValueProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.CompositeValueProvider.CompositeValueProvider()
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.CompositeValueProvider`\.
    
        
    
        
        .. code-block:: csharp
    
            public CompositeValueProvider()
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.CompositeValueProvider.CompositeValueProvider(System.Collections.Generic.IList<Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider>)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.CompositeValueProvider`\.
    
        
    
        
        :param valueProviders: The sequence of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider` to add to this instance of 
            :any:`Microsoft.AspNetCore.Mvc.ModelBinding.CompositeValueProvider`\.
        
        :type valueProviders: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider<Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider>}
    
        
        .. code-block:: csharp
    
            public CompositeValueProvider(IList<IValueProvider> valueProviders)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.CompositeValueProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.CompositeValueProvider.ContainsPrefix(System.String)
    
        
    
        
        :type prefix: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public virtual bool ContainsPrefix(string prefix)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.CompositeValueProvider.Filter(Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource)
    
        
    
        
        :type bindingSource: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider
    
        
        .. code-block:: csharp
    
            public IValueProvider Filter(BindingSource bindingSource)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.CompositeValueProvider.GetKeysFromPrefix(System.String)
    
        
    
        
        :type prefix: System.String
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public virtual IDictionary<string, string> GetKeysFromPrefix(string prefix)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.CompositeValueProvider.GetValue(System.String)
    
        
    
        
        :type key: System.String
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ValueProviderResult
    
        
        .. code-block:: csharp
    
            public virtual ValueProviderResult GetValue(string key)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.CompositeValueProvider.InsertItem(System.Int32, Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider)
    
        
    
        
        :type index: System.Int32
    
        
        :type item: Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider
    
        
        .. code-block:: csharp
    
            protected override void InsertItem(int index, IValueProvider item)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.CompositeValueProvider.SetItem(System.Int32, Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider)
    
        
    
        
        :type index: System.Int32
    
        
        :type item: Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider
    
        
        .. code-block:: csharp
    
            protected override void SetItem(int index, IValueProvider item)
    

