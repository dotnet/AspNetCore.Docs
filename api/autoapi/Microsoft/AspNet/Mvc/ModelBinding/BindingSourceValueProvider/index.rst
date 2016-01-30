

BindingSourceValueProvider Class
================================



.. contents:: 
   :local:



Summary
-------

A value provider which provides data from a specific :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.BindingSourceValueProvider.BindingSource`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.BindingSourceValueProvider`








Syntax
------

.. code-block:: csharp

   public abstract class BindingSourceValueProvider : IBindingSourceValueProvider, IValueProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ModelBinding/BindingSourceValueProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.BindingSourceValueProvider

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.BindingSourceValueProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.BindingSourceValueProvider.BindingSourceValueProvider(Microsoft.AspNet.Mvc.ModelBinding.BindingSource)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ModelBinding.BindingSourceValueProvider`\.
    
        
        
        
        :param bindingSource: The . Must be a single-source (non-composite) with
            equal to false.
        
        :type bindingSource: Microsoft.AspNet.Mvc.ModelBinding.BindingSource
    
        
        .. code-block:: csharp
    
           public BindingSourceValueProvider(BindingSource bindingSource)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.BindingSourceValueProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.BindingSourceValueProvider.ContainsPrefix(System.String)
    
        
        
        
        :type prefix: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public abstract bool ContainsPrefix(string prefix)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.BindingSourceValueProvider.Filter(Microsoft.AspNet.Mvc.ModelBinding.BindingSource)
    
        
        
        
        :type bindingSource: Microsoft.AspNet.Mvc.ModelBinding.BindingSource
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.IValueProvider
    
        
        .. code-block:: csharp
    
           public virtual IValueProvider Filter(BindingSource bindingSource)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.BindingSourceValueProvider.GetValue(System.String)
    
        
        
        
        :type key: System.String
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ValueProviderResult
    
        
        .. code-block:: csharp
    
           public abstract ValueProviderResult GetValue(string key)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.BindingSourceValueProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.BindingSourceValueProvider.BindingSource
    
        
    
        Gets the corresponding :any:`Microsoft.AspNet.Mvc.ModelBinding.BindingSource`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.BindingSource
    
        
        .. code-block:: csharp
    
           protected BindingSource BindingSource { get; }
    

