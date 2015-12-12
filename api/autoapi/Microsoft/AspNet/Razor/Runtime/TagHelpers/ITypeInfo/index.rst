

ITypeInfo Interface
===================



.. contents:: 
   :local:



Summary
-------

Contains type metadata.











Syntax
------

.. code-block:: csharp

   public interface ITypeInfo : IMemberInfo, IEquatable<ITypeInfo>





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor.Runtime/Runtime/TagHelpers/ITypeInfo.cs>`_





.. dn:interface:: Microsoft.AspNet.Razor.Runtime.TagHelpers.ITypeInfo

Methods
-------

.. dn:interface:: Microsoft.AspNet.Razor.Runtime.TagHelpers.ITypeInfo
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Runtime.TagHelpers.ITypeInfo.GetGenericDictionaryParameters()
    
        
    
        Gets the :any:`Microsoft.AspNet.Razor.Runtime.TagHelpers.ITypeInfo` for the <c>TKey</c> and <c>TValue</c> parameters of 
        :any:`System.Collections.Generic.IDictionary\`2`\.
    
        
        :rtype: Microsoft.AspNet.Razor.Runtime.TagHelpers.ITypeInfo[]
        :return: The <see cref="T:Microsoft.AspNet.Razor.Runtime.TagHelpers.ITypeInfo" /> of <c>TKey</c> and <c>TValue</c>
            parameters if the type implements <see cref="T:System.Collections.Generic.IDictionary`2" />, otherwise <c>null</c>.
    
        
        .. code-block:: csharp
    
           ITypeInfo[] GetGenericDictionaryParameters()
    
    .. dn:method:: Microsoft.AspNet.Razor.Runtime.TagHelpers.ITypeInfo.ImplementsInterface(Microsoft.AspNet.Razor.Runtime.TagHelpers.ITypeInfo)
    
        
    
        Gets a value indicating whether the type implements the <param name="interfaceTypeInfo" /> interface.
    
        
        
        
        :type interfaceTypeInfo: Microsoft.AspNet.Razor.Runtime.TagHelpers.ITypeInfo
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool ImplementsInterface(ITypeInfo interfaceTypeInfo)
    

Properties
----------

.. dn:interface:: Microsoft.AspNet.Razor.Runtime.TagHelpers.ITypeInfo
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Runtime.TagHelpers.ITypeInfo.FullName
    
        
    
        Fully qualified name of the type.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string FullName { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Runtime.TagHelpers.ITypeInfo.IsAbstract
    
        
    
        Gets a value indicating whether the type is abstract or an interface.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool IsAbstract { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Runtime.TagHelpers.ITypeInfo.IsGenericType
    
        
    
        Gets a value indicating whether the type is generic.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool IsGenericType { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Runtime.TagHelpers.ITypeInfo.IsPublic
    
        
    
        Gets a value indicating whether the type is public.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool IsPublic { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Runtime.TagHelpers.ITypeInfo.Properties
    
        
    
        Gets :any:`Microsoft.AspNet.Razor.Runtime.TagHelpers.IPropertyInfo`\s for all properties of the current type excluding indexers.
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.Runtime.TagHelpers.IPropertyInfo}
    
        
        .. code-block:: csharp
    
           IEnumerable<IPropertyInfo> Properties { get; }
    

