

FormValueProvider Class
=======================






An :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider` adapter for data stored in an :any:`Microsoft.AspNetCore.Http.IFormCollection`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.FormValueProvider`








Syntax
------

.. code-block:: csharp

    public class FormValueProvider : BindingSourceValueProvider, IBindingSourceValueProvider, IEnumerableValueProvider, IValueProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.FormValueProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.FormValueProvider

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.FormValueProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.FormValueProvider.FormValueProvider(Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource, Microsoft.AspNetCore.Http.IFormCollection, System.Globalization.CultureInfo)
    
        
    
        
        Creates a value provider for :any:`Microsoft.AspNetCore.Http.IFormCollection`\.
    
        
    
        
        :param bindingSource: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource` for the data.
        
        :type bindingSource: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource
    
        
        :param values: The key value pairs to wrap.
        
        :type values: Microsoft.AspNetCore.Http.IFormCollection
    
        
        :param culture: The culture to return with ValueProviderResult instances.
        
        :type culture: System.Globalization.CultureInfo
    
        
        .. code-block:: csharp
    
            public FormValueProvider(BindingSource bindingSource, IFormCollection values, CultureInfo culture)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.FormValueProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.FormValueProvider.ContainsPrefix(System.String)
    
        
    
        
        :type prefix: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool ContainsPrefix(string prefix)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.FormValueProvider.GetKeysFromPrefix(System.String)
    
        
    
        
        :type prefix: System.String
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public virtual IDictionary<string, string> GetKeysFromPrefix(string prefix)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.FormValueProvider.GetValue(System.String)
    
        
    
        
        :type key: System.String
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ValueProviderResult
    
        
        .. code-block:: csharp
    
            public override ValueProviderResult GetValue(string key)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.FormValueProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.FormValueProvider.Culture
    
        
        :rtype: System.Globalization.CultureInfo
    
        
        .. code-block:: csharp
    
            public CultureInfo Culture { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.FormValueProvider.PrefixContainer
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Internal.PrefixContainer
    
        
        .. code-block:: csharp
    
            protected PrefixContainer PrefixContainer { get; }
    

