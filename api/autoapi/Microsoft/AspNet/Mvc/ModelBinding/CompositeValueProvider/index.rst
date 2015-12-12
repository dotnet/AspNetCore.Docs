

CompositeValueProvider Class
============================



.. contents:: 
   :local:



Summary
-------

Represents a :any:`Microsoft.AspNet.Mvc.ModelBinding.IValueProvider` whose values come from a collection of :any:`Microsoft.AspNet.Mvc.ModelBinding.IValueProvider`\s.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Collections.ObjectModel.Collection{Microsoft.AspNet.Mvc.ModelBinding.IValueProvider}`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.CompositeValueProvider`








Syntax
------

.. code-block:: csharp

   public class CompositeValueProvider : Collection<IValueProvider>, IList<IValueProvider>, ICollection<IValueProvider>, IList, ICollection, IReadOnlyList<IValueProvider>, IReadOnlyCollection<IValueProvider>, IEnumerable<IValueProvider>, IEnumerable, IEnumerableValueProvider, IBindingSourceValueProvider, IValueProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/ModelBinding/CompositeValueProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.CompositeValueProvider

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.CompositeValueProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.CompositeValueProvider.CompositeValueProvider()
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Mvc.ModelBinding.CompositeValueProvider`\.
    
        
    
        
        .. code-block:: csharp
    
           public CompositeValueProvider()
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.CompositeValueProvider.CompositeValueProvider(System.Collections.Generic.IList<Microsoft.AspNet.Mvc.ModelBinding.IValueProvider>)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Mvc.ModelBinding.CompositeValueProvider`\.
    
        
        
        
        :param valueProviders: The sequence of  to add to this instance of
            .
        
        :type valueProviders: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.ModelBinding.IValueProvider}
    
        
        .. code-block:: csharp
    
           protected CompositeValueProvider(IList<IValueProvider> valueProviders)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.CompositeValueProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.CompositeValueProvider.ContainsPrefix(System.String)
    
        
        
        
        :type prefix: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual bool ContainsPrefix(string prefix)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.CompositeValueProvider.CreateAsync(System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.ModelBinding.IValueProviderFactory>, Microsoft.AspNet.Mvc.ModelBinding.ValueProviderFactoryContext)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ModelBinding.CompositeValueProvider` from the provided ``context``
        and ``factories``.
    
        
        
        
        :param factories: The set of  instances.
        
        :type factories: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.ModelBinding.IValueProviderFactory}
        
        
        :param context: The .
        
        :type context: Microsoft.AspNet.Mvc.ModelBinding.ValueProviderFactoryContext
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Mvc.ModelBinding.CompositeValueProvider}
        :return: A <see cref="T:Microsoft.AspNet.Mvc.ModelBinding.CompositeValueProvider" /> containing all <see cref="T:Microsoft.AspNet.Mvc.ModelBinding.IValueProvider" /> instances
            created.
    
        
        .. code-block:: csharp
    
           public static Task<CompositeValueProvider> CreateAsync(IEnumerable<IValueProviderFactory> factories, ValueProviderFactoryContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.CompositeValueProvider.Filter(Microsoft.AspNet.Mvc.ModelBinding.BindingSource)
    
        
        
        
        :type bindingSource: Microsoft.AspNet.Mvc.ModelBinding.BindingSource
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.IValueProvider
    
        
        .. code-block:: csharp
    
           public IValueProvider Filter(BindingSource bindingSource)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.CompositeValueProvider.GetKeysFromPrefix(System.String)
    
        
        
        
        :type prefix: System.String
        :rtype: System.Collections.Generic.IDictionary{System.String,System.String}
    
        
        .. code-block:: csharp
    
           public virtual IDictionary<string, string> GetKeysFromPrefix(string prefix)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.CompositeValueProvider.GetValue(System.String)
    
        
        
        
        :type key: System.String
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ValueProviderResult
    
        
        .. code-block:: csharp
    
           public virtual ValueProviderResult GetValue(string key)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.CompositeValueProvider.InsertItem(System.Int32, Microsoft.AspNet.Mvc.ModelBinding.IValueProvider)
    
        
        
        
        :type index: System.Int32
        
        
        :type item: Microsoft.AspNet.Mvc.ModelBinding.IValueProvider
    
        
        .. code-block:: csharp
    
           protected override void InsertItem(int index, IValueProvider item)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.CompositeValueProvider.SetItem(System.Int32, Microsoft.AspNet.Mvc.ModelBinding.IValueProvider)
    
        
        
        
        :type index: System.Int32
        
        
        :type item: Microsoft.AspNet.Mvc.ModelBinding.IValueProvider
    
        
        .. code-block:: csharp
    
           protected override void SetItem(int index, IValueProvider item)
    

