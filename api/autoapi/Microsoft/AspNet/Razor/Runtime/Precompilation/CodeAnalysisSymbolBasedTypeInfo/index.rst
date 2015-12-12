

CodeAnalysisSymbolBasedTypeInfo Class
=====================================



.. contents:: 
   :local:



Summary
-------

:any:`Microsoft.AspNet.Razor.Runtime.TagHelpers.ITypeInfo` implementation using Code Analysis symbols.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Runtime.Precompilation.CodeAnalysisSymbolBasedTypeInfo`








Syntax
------

.. code-block:: csharp

   public class CodeAnalysisSymbolBasedTypeInfo : ITypeInfo, IMemberInfo, IEquatable<ITypeInfo>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor.Runtime.Precompilation/CodeAnalysisSymbolBasedTypeInfo.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Runtime.Precompilation.CodeAnalysisSymbolBasedTypeInfo

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Runtime.Precompilation.CodeAnalysisSymbolBasedTypeInfo
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Runtime.Precompilation.CodeAnalysisSymbolBasedTypeInfo.CodeAnalysisSymbolBasedTypeInfo(Microsoft.CodeAnalysis.ITypeSymbol)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Razor.Runtime.Precompilation.CodeAnalysisSymbolBasedTypeInfo`\.
    
        
        
        
        :type type: Microsoft.CodeAnalysis.ITypeSymbol
    
        
        .. code-block:: csharp
    
           public CodeAnalysisSymbolBasedTypeInfo(ITypeSymbol type)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Runtime.Precompilation.CodeAnalysisSymbolBasedTypeInfo
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Runtime.Precompilation.CodeAnalysisSymbolBasedTypeInfo.Equals(Microsoft.AspNet.Razor.Runtime.TagHelpers.ITypeInfo)
    
        
        
        
        :type other: Microsoft.AspNet.Razor.Runtime.TagHelpers.ITypeInfo
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Equals(ITypeInfo other)
    
    .. dn:method:: Microsoft.AspNet.Razor.Runtime.Precompilation.CodeAnalysisSymbolBasedTypeInfo.Equals(System.Object)
    
        
        
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNet.Razor.Runtime.Precompilation.CodeAnalysisSymbolBasedTypeInfo.GetAssemblyQualifiedName(Microsoft.CodeAnalysis.ITypeSymbol)
    
        
    
        Gets the assembly qualified named of the specified ``symbol``.
    
        
        
        
        :param symbol: The  to generate the name for.
        
        :type symbol: Microsoft.CodeAnalysis.ITypeSymbol
        :rtype: System.String
        :return: The assembly qualified name.
    
        
        .. code-block:: csharp
    
           public static string GetAssemblyQualifiedName(ITypeSymbol symbol)
    
    .. dn:method:: Microsoft.AspNet.Razor.Runtime.Precompilation.CodeAnalysisSymbolBasedTypeInfo.GetCustomAttributes<TAttribute>()
    
        
        :rtype: System.Collections.Generic.IEnumerable{{TAttribute}}
    
        
        .. code-block:: csharp
    
           public IEnumerable<TAttribute> GetCustomAttributes<TAttribute>()where TAttribute : Attribute
    
    .. dn:method:: Microsoft.AspNet.Razor.Runtime.Precompilation.CodeAnalysisSymbolBasedTypeInfo.GetGenericDictionaryParameters()
    
        
        :rtype: Microsoft.AspNet.Razor.Runtime.TagHelpers.ITypeInfo[]
    
        
        .. code-block:: csharp
    
           public ITypeInfo[] GetGenericDictionaryParameters()
    
    .. dn:method:: Microsoft.AspNet.Razor.Runtime.Precompilation.CodeAnalysisSymbolBasedTypeInfo.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNet.Razor.Runtime.Precompilation.CodeAnalysisSymbolBasedTypeInfo.ImplementsInterface(Microsoft.AspNet.Razor.Runtime.TagHelpers.ITypeInfo)
    
        
        
        
        :type interfaceTypeInfo: Microsoft.AspNet.Razor.Runtime.TagHelpers.ITypeInfo
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool ImplementsInterface(ITypeInfo interfaceTypeInfo)
    
    .. dn:method:: Microsoft.AspNet.Razor.Runtime.Precompilation.CodeAnalysisSymbolBasedTypeInfo.IsType(Microsoft.CodeAnalysis.ITypeSymbol, System.Reflection.TypeInfo)
    
        
    
        Gets a value that indicates if ``targetTypeInfo`` is represented using
        ``sourceTypeSymbol`` in the symbol graph.
    
        
        
        
        :param sourceTypeSymbol: The .
        
        :type sourceTypeSymbol: Microsoft.CodeAnalysis.ITypeSymbol
        
        
        :param targetTypeInfo: The .
        
        :type targetTypeInfo: System.Reflection.TypeInfo
        :rtype: System.Boolean
        :return: <c>true</c> if <paramref name="targetTypeInfo" /> is a symbol for
            <paramref name="sourceTypeSymbol" />.
    
        
        .. code-block:: csharp
    
           public static bool IsType(ITypeSymbol sourceTypeSymbol, TypeInfo targetTypeInfo)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Runtime.Precompilation.CodeAnalysisSymbolBasedTypeInfo
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Runtime.Precompilation.CodeAnalysisSymbolBasedTypeInfo.FullName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string FullName { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Runtime.Precompilation.CodeAnalysisSymbolBasedTypeInfo.IsAbstract
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsAbstract { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Runtime.Precompilation.CodeAnalysisSymbolBasedTypeInfo.IsGenericType
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsGenericType { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Runtime.Precompilation.CodeAnalysisSymbolBasedTypeInfo.IsNested
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsNested { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Runtime.Precompilation.CodeAnalysisSymbolBasedTypeInfo.IsPublic
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsPublic { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Runtime.Precompilation.CodeAnalysisSymbolBasedTypeInfo.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Name { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Runtime.Precompilation.CodeAnalysisSymbolBasedTypeInfo.Properties
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.Runtime.TagHelpers.IPropertyInfo}
    
        
        .. code-block:: csharp
    
           public IEnumerable<IPropertyInfo> Properties { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Runtime.Precompilation.CodeAnalysisSymbolBasedTypeInfo.TypeSymbol
    
        
    
        The :any:`Microsoft.CodeAnalysis.ITypeSymbol` instance.
    
        
        :rtype: Microsoft.CodeAnalysis.ITypeSymbol
    
        
        .. code-block:: csharp
    
           public ITypeSymbol TypeSymbol { get; }
    

