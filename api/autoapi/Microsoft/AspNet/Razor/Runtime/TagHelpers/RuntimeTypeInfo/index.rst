

RuntimeTypeInfo Class
=====================



.. contents:: 
   :local:



Summary
-------

:any:`Microsoft.AspNet.Razor.Runtime.TagHelpers.ITypeInfo` adapter for :any:`System.Reflection.TypeInfo` instances.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Runtime.TagHelpers.RuntimeTypeInfo`








Syntax
------

.. code-block:: csharp

   public class RuntimeTypeInfo : ITypeInfo, IMemberInfo, IEquatable<ITypeInfo>





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor.Runtime/Runtime/TagHelpers/RuntimeTypeInfo.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Runtime.TagHelpers.RuntimeTypeInfo

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Runtime.TagHelpers.RuntimeTypeInfo
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Runtime.TagHelpers.RuntimeTypeInfo.RuntimeTypeInfo(System.Reflection.TypeInfo)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Razor.Runtime.TagHelpers.RuntimeTypeInfo`
    
        
        
        
        :type typeInfo: System.Reflection.TypeInfo
    
        
        .. code-block:: csharp
    
           public RuntimeTypeInfo(TypeInfo typeInfo)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Runtime.TagHelpers.RuntimeTypeInfo
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Runtime.TagHelpers.RuntimeTypeInfo.Equals(Microsoft.AspNet.Razor.Runtime.TagHelpers.ITypeInfo)
    
        
        
        
        :type other: Microsoft.AspNet.Razor.Runtime.TagHelpers.ITypeInfo
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Equals(ITypeInfo other)
    
    .. dn:method:: Microsoft.AspNet.Razor.Runtime.TagHelpers.RuntimeTypeInfo.Equals(System.Object)
    
        
        
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNet.Razor.Runtime.TagHelpers.RuntimeTypeInfo.GetCustomAttributes<TAttribute>()
    
        
        :rtype: System.Collections.Generic.IEnumerable{{TAttribute}}
    
        
        .. code-block:: csharp
    
           public IEnumerable<TAttribute> GetCustomAttributes<TAttribute>()where TAttribute : Attribute
    
    .. dn:method:: Microsoft.AspNet.Razor.Runtime.TagHelpers.RuntimeTypeInfo.GetGenericDictionaryParameters()
    
        
        :rtype: Microsoft.AspNet.Razor.Runtime.TagHelpers.ITypeInfo[]
    
        
        .. code-block:: csharp
    
           public ITypeInfo[] GetGenericDictionaryParameters()
    
    .. dn:method:: Microsoft.AspNet.Razor.Runtime.TagHelpers.RuntimeTypeInfo.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNet.Razor.Runtime.TagHelpers.RuntimeTypeInfo.ImplementsInterface(Microsoft.AspNet.Razor.Runtime.TagHelpers.ITypeInfo)
    
        
        
        
        :type interfaceTypeInfo: Microsoft.AspNet.Razor.Runtime.TagHelpers.ITypeInfo
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool ImplementsInterface(ITypeInfo interfaceTypeInfo)
    
    .. dn:method:: Microsoft.AspNet.Razor.Runtime.TagHelpers.RuntimeTypeInfo.SanitizeFullName(System.String)
    
        
    
        Removes assembly qualification from generic type parameters for the specified ``fullName``.
    
        
        
        
        :param fullName: Full name.
        
        :type fullName: System.String
        :rtype: System.String
        :return: Full name without fully qualified generic parameters.
    
        
        .. code-block:: csharp
    
           public static string SanitizeFullName(string fullName)
    
    .. dn:method:: Microsoft.AspNet.Razor.Runtime.TagHelpers.RuntimeTypeInfo.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string ToString()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Runtime.TagHelpers.RuntimeTypeInfo
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Runtime.TagHelpers.RuntimeTypeInfo.FullName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string FullName { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Runtime.TagHelpers.RuntimeTypeInfo.IsAbstract
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsAbstract { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Runtime.TagHelpers.RuntimeTypeInfo.IsGenericType
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsGenericType { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Runtime.TagHelpers.RuntimeTypeInfo.IsPublic
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsPublic { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Runtime.TagHelpers.RuntimeTypeInfo.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Name { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Runtime.TagHelpers.RuntimeTypeInfo.Properties
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.Runtime.TagHelpers.IPropertyInfo}
    
        
        .. code-block:: csharp
    
           public IEnumerable<IPropertyInfo> Properties { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Runtime.TagHelpers.RuntimeTypeInfo.TypeInfo
    
        
    
        The :any:`System.Reflection.TypeInfo` instance.
    
        
        :rtype: System.Reflection.TypeInfo
    
        
        .. code-block:: csharp
    
           public TypeInfo TypeInfo { get; }
    

