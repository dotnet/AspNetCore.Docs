

CodeAnalysisSymbolBasedPropertyInfo Class
=========================================



.. contents:: 
   :local:



Summary
-------

:any:`Microsoft.AspNet.Razor.Runtime.TagHelpers.IPropertyInfo` implementation using Code Analysis symbols.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Runtime.Precompilation.CodeAnalysisSymbolBasedPropertyInfo`








Syntax
------

.. code-block:: csharp

   public class CodeAnalysisSymbolBasedPropertyInfo : IPropertyInfo, IMemberInfo





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor.Runtime.Precompilation/CodeAnalysisSymbolBasedPropertyInfo.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Runtime.Precompilation.CodeAnalysisSymbolBasedPropertyInfo

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Runtime.Precompilation.CodeAnalysisSymbolBasedPropertyInfo
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Runtime.Precompilation.CodeAnalysisSymbolBasedPropertyInfo.CodeAnalysisSymbolBasedPropertyInfo(Microsoft.CodeAnalysis.IPropertySymbol)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Razor.Runtime.Precompilation.CodeAnalysisSymbolBasedPropertyInfo`\.
    
        
        
        
        :param propertySymbol: The .
        
        :type propertySymbol: Microsoft.CodeAnalysis.IPropertySymbol
    
        
        .. code-block:: csharp
    
           public CodeAnalysisSymbolBasedPropertyInfo(IPropertySymbol propertySymbol)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Runtime.Precompilation.CodeAnalysisSymbolBasedPropertyInfo
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Runtime.Precompilation.CodeAnalysisSymbolBasedPropertyInfo.GetCustomAttributes<TAttribute>()
    
        
        :rtype: System.Collections.Generic.IEnumerable{{TAttribute}}
    
        
        .. code-block:: csharp
    
           public IEnumerable<TAttribute> GetCustomAttributes<TAttribute>()where TAttribute : Attribute
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Runtime.Precompilation.CodeAnalysisSymbolBasedPropertyInfo
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Runtime.Precompilation.CodeAnalysisSymbolBasedPropertyInfo.HasPublicGetter
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool HasPublicGetter { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Runtime.Precompilation.CodeAnalysisSymbolBasedPropertyInfo.HasPublicSetter
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool HasPublicSetter { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Runtime.Precompilation.CodeAnalysisSymbolBasedPropertyInfo.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Name { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Runtime.Precompilation.CodeAnalysisSymbolBasedPropertyInfo.PropertyType
    
        
        :rtype: Microsoft.AspNet.Razor.Runtime.TagHelpers.ITypeInfo
    
        
        .. code-block:: csharp
    
           public ITypeInfo PropertyType { get; }
    

