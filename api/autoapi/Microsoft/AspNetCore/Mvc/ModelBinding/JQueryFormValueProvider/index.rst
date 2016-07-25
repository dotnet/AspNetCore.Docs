

JQueryFormValueProvider Class
=============================






An :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider` for jQuery formatted form data.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.JQueryFormValueProvider`








Syntax
------

.. code-block:: csharp

    public class JQueryFormValueProvider : BindingSourceValueProvider, IBindingSourceValueProvider, IEnumerableValueProvider, IValueProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.JQueryFormValueProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.JQueryFormValueProvider

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.JQueryFormValueProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.JQueryFormValueProvider.JQueryFormValueProvider(Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource, System.Collections.Generic.IDictionary<System.String, Microsoft.Extensions.Primitives.StringValues>, System.Globalization.CultureInfo)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.JQueryFormValueProvider` class.
    
        
    
        
        :param bindingSource: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource` of the data.
        
        :type bindingSource: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource
    
        
        :param values: The values.
        
        :type values: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, Microsoft.Extensions.Primitives.StringValues<Microsoft.Extensions.Primitives.StringValues>}
    
        
        :param culture: The culture to return with ValueProviderResult instances.
        
        :type culture: System.Globalization.CultureInfo
    
        
        .. code-block:: csharp
    
            public JQueryFormValueProvider(BindingSource bindingSource, IDictionary<string, StringValues> values, CultureInfo culture)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.JQueryFormValueProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.JQueryFormValueProvider.ContainsPrefix(System.String)
    
        
    
        
        :type prefix: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool ContainsPrefix(string prefix)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.JQueryFormValueProvider.GetKeysFromPrefix(System.String)
    
        
    
        
        :type prefix: System.String
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IDictionary<string, string> GetKeysFromPrefix(string prefix)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.JQueryFormValueProvider.GetValue(System.String)
    
        
    
        
        :type key: System.String
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ValueProviderResult
    
        
        .. code-block:: csharp
    
            public override ValueProviderResult GetValue(string key)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.JQueryFormValueProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.JQueryFormValueProvider.PrefixContainer
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Internal.PrefixContainer
    
        
        .. code-block:: csharp
    
            protected PrefixContainer PrefixContainer { get; }
    

