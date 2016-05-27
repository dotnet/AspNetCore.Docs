

ElementalValueProvider Class
============================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.ElementalValueProvider`








Syntax
------

.. code-block:: csharp

    public class ElementalValueProvider : IValueProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ElementalValueProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ElementalValueProvider

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ElementalValueProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.ElementalValueProvider.Culture
    
        
        :rtype: System.Globalization.CultureInfo
    
        
        .. code-block:: csharp
    
            public CultureInfo Culture
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.ElementalValueProvider.Key
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Key
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.ElementalValueProvider.Value
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Value
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ElementalValueProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.ElementalValueProvider.ElementalValueProvider(System.String, System.String, System.Globalization.CultureInfo)
    
        
    
        
        :type key: System.String
    
        
        :type value: System.String
    
        
        :type culture: System.Globalization.CultureInfo
    
        
        .. code-block:: csharp
    
            public ElementalValueProvider(string key, string value, CultureInfo culture)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ElementalValueProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ElementalValueProvider.ContainsPrefix(System.String)
    
        
    
        
        :type prefix: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool ContainsPrefix(string prefix)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ElementalValueProvider.GetValue(System.String)
    
        
    
        
        :type key: System.String
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ValueProviderResult
    
        
        .. code-block:: csharp
    
            public ValueProviderResult GetValue(string key)
    

