

ElementalValueProvider Class
============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.ElementalValueProvider`








Syntax
------

.. code-block:: csharp

   public class ElementalValueProvider : IValueProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/ModelBinding/ElementalValueProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ElementalValueProvider

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ElementalValueProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.ElementalValueProvider.ElementalValueProvider(System.String, System.String, System.Globalization.CultureInfo)
    
        
        
        
        :type key: System.String
        
        
        :type value: System.String
        
        
        :type culture: System.Globalization.CultureInfo
    
        
        .. code-block:: csharp
    
           public ElementalValueProvider(string key, string value, CultureInfo culture)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ElementalValueProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ElementalValueProvider.ContainsPrefix(System.String)
    
        
        
        
        :type prefix: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool ContainsPrefix(string prefix)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ElementalValueProvider.GetValue(System.String)
    
        
        
        
        :type key: System.String
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ValueProviderResult
    
        
        .. code-block:: csharp
    
           public ValueProviderResult GetValue(string key)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ElementalValueProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ElementalValueProvider.Culture
    
        
        :rtype: System.Globalization.CultureInfo
    
        
        .. code-block:: csharp
    
           public CultureInfo Culture { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ElementalValueProvider.Key
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Key { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ElementalValueProvider.Value
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Value { get; }
    

