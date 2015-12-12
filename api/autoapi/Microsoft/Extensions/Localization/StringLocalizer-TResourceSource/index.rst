

StringLocalizer<TResourceSource> Class
======================================



.. contents:: 
   :local:



Summary
-------

Provides strings for TResourceSource\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Localization.StringLocalizer\<TResourceSource>`








Syntax
------

.. code-block:: csharp

   public class StringLocalizer<TResourceSource> : IStringLocalizer<TResourceSource>, IStringLocalizer





GitHub
------

`View on GitHub <https://github.com/aspnet/localization/blob/master/src/Microsoft.Extensions.Localization.Abstractions/StringLocalizerOfT.cs>`_





.. dn:class:: Microsoft.Extensions.Localization.StringLocalizer<TResourceSource>

Constructors
------------

.. dn:class:: Microsoft.Extensions.Localization.StringLocalizer<TResourceSource>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Localization.StringLocalizer<TResourceSource>.StringLocalizer(Microsoft.Extensions.Localization.IStringLocalizerFactory)
    
        
    
        Creates a new :any:`Microsoft.Extensions.Localization.StringLocalizer\`1`\.
    
        
        
        
        :param factory: The  to use.
        
        :type factory: Microsoft.Extensions.Localization.IStringLocalizerFactory
    
        
        .. code-block:: csharp
    
           public StringLocalizer(IStringLocalizerFactory factory)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Localization.StringLocalizer<TResourceSource>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Localization.StringLocalizer<TResourceSource>.GetAllStrings(System.Boolean)
    
        
        
        
        :type includeAncestorCultures: System.Boolean
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.Extensions.Localization.LocalizedString}
    
        
        .. code-block:: csharp
    
           public IEnumerable<LocalizedString> GetAllStrings(bool includeAncestorCultures)
    
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
        
        
        :type arguments: System.Object[]
        :rtype: Microsoft.Extensions.Localization.LocalizedString
    
        
        .. code-block:: csharp
    
           public virtual LocalizedString this[string name, params object[] arguments] { get; }
    

