

BindingSourceValueProvider Class
================================






A value provider which provides data from a specific :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.BindingSourceValueProvider.BindingSource`\.


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








Syntax
------

.. code-block:: csharp

    public abstract class BindingSourceValueProvider : IBindingSourceValueProvider, IValueProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSourceValueProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSourceValueProvider

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSourceValueProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSourceValueProvider.BindingSourceValueProvider(Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ModelBinding.BindingSourceValueProvider`\.
    
        
    
        
        :param bindingSource: 
            The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource`\. Must be a single-source (non-composite) with 
            :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource.IsGreedy` equal to <code>false</code>.
        
        :type bindingSource: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource
    
        
        .. code-block:: csharp
    
            public BindingSourceValueProvider(BindingSource bindingSource)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSourceValueProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSourceValueProvider.BindingSource
    
        
    
        
        Gets the corresponding :any:`Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource
    
        
        .. code-block:: csharp
    
            protected BindingSource BindingSource { get; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSourceValueProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSourceValueProvider.ContainsPrefix(System.String)
    
        
    
        
        :type prefix: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public abstract bool ContainsPrefix(string prefix)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSourceValueProvider.Filter(Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource)
    
        
    
        
        :type bindingSource: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider
    
        
        .. code-block:: csharp
    
            public virtual IValueProvider Filter(BindingSource bindingSource)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSourceValueProvider.GetValue(System.String)
    
        
    
        
        :type key: System.String
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ValueProviderResult
    
        
        .. code-block:: csharp
    
            public abstract ValueProviderResult GetValue(string key)
    

