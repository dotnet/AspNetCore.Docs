

StringLocalizer<TResourceSource> Class
======================================






Provides strings for <em>TResourceSource</em>.


Namespace
    :dn:ns:`Microsoft.Extensions.Localization`
Assemblies
    * Microsoft.Extensions.Localization.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Localization.StringLocalizer\<TResourceSource>`








Syntax
------

.. code-block:: csharp

    public class StringLocalizer<TResourceSource> : IStringLocalizer<TResourceSource>, IStringLocalizer








.. dn:class:: Microsoft.Extensions.Localization.StringLocalizer`1
    :hidden:

.. dn:class:: Microsoft.Extensions.Localization.StringLocalizer<TResourceSource>

Constructors
------------

.. dn:class:: Microsoft.Extensions.Localization.StringLocalizer<TResourceSource>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Localization.StringLocalizer<TResourceSource>.StringLocalizer(Microsoft.Extensions.Localization.IStringLocalizerFactory)
    
        
    
        
        Creates a new :any:`Microsoft.Extensions.Localization.StringLocalizer\`1`\.
    
        
    
        
        :param factory: The :any:`Microsoft.Extensions.Localization.IStringLocalizerFactory` to use.
        
        :type factory: Microsoft.Extensions.Localization.IStringLocalizerFactory
    
        
        .. code-block:: csharp
    
            public StringLocalizer(IStringLocalizerFactory factory)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Localization.StringLocalizer<TResourceSource>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Localization.StringLocalizer<TResourceSource>.GetAllStrings(System.Boolean)
    
        
    
        
        :type includeParentCultures: System.Boolean
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.Extensions.Localization.LocalizedString<Microsoft.Extensions.Localization.LocalizedString>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
    
    .. dn:method:: Microsoft.Extensions.Localization.StringLocalizer<TResourceSource>.WithCulture(System.Globalization.CultureInfo)
    
        
    
        
        :type culture: System.Globalization.CultureInfo
        :rtype: Microsoft.Extensions.Localization.IStringLocalizer
    
        
        .. code-block:: csharp
    
            public virtual IStringLocalizer WithCulture(CultureInfo culture)
    

Properties
----------

.. dn:class:: Microsoft.Extensions.Localization.StringLocalizer<TResourceSource>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Localization.StringLocalizer<TResourceSource>.Item[System.String]
    
        
    
        
        :type name: System.String
        :rtype: Microsoft.Extensions.Localization.LocalizedString
    
        
        .. code-block:: csharp
    
            public virtual LocalizedString this[string name] { get; }
    
    .. dn:property:: Microsoft.Extensions.Localization.StringLocalizer<TResourceSource>.Item[System.String, System.Object[]]
    
        
    
        
        :type name: System.String
    
        
        :type arguments: System.Object<System.Object>[]
        :rtype: Microsoft.Extensions.Localization.LocalizedString
    
        
        .. code-block:: csharp
    
            public virtual LocalizedString this[string name, params object[] arguments] { get; }
    

