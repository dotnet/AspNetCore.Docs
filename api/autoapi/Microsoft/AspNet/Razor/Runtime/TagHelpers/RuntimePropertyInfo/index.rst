

RuntimePropertyInfo Class
=========================



.. contents:: 
   :local:



Summary
-------

:any:`Microsoft.AspNet.Razor.Runtime.TagHelpers.IPropertyInfo` adapter for :any:`System.Reflection.PropertyInfo` instances.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Runtime.TagHelpers.RuntimePropertyInfo`








Syntax
------

.. code-block:: csharp

   public class RuntimePropertyInfo : IPropertyInfo, IMemberInfo





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor.Runtime/Runtime/TagHelpers/RuntimePropertyInfo.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Runtime.TagHelpers.RuntimePropertyInfo

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Runtime.TagHelpers.RuntimePropertyInfo
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Runtime.TagHelpers.RuntimePropertyInfo.RuntimePropertyInfo(System.Reflection.PropertyInfo)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Razor.Runtime.TagHelpers.RuntimePropertyInfo`\.
    
        
        
        
        :param propertyInfo: The  instance to adapt.
        
        :type propertyInfo: System.Reflection.PropertyInfo
    
        
        .. code-block:: csharp
    
           public RuntimePropertyInfo(PropertyInfo propertyInfo)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Runtime.TagHelpers.RuntimePropertyInfo
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Runtime.TagHelpers.RuntimePropertyInfo.GetCustomAttributes<TAttribute>()
    
        
        :rtype: System.Collections.Generic.IEnumerable{{TAttribute}}
    
        
        .. code-block:: csharp
    
           public IEnumerable<TAttribute> GetCustomAttributes<TAttribute>()where TAttribute : Attribute
    
    .. dn:method:: Microsoft.AspNet.Razor.Runtime.TagHelpers.RuntimePropertyInfo.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string ToString()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Runtime.TagHelpers.RuntimePropertyInfo
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Runtime.TagHelpers.RuntimePropertyInfo.HasPublicGetter
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool HasPublicGetter { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Runtime.TagHelpers.RuntimePropertyInfo.HasPublicSetter
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool HasPublicSetter { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Runtime.TagHelpers.RuntimePropertyInfo.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Name { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Runtime.TagHelpers.RuntimePropertyInfo.Property
    
        
    
        The :any:`System.Reflection.PropertyInfo` instance.
    
        
        :rtype: System.Reflection.PropertyInfo
    
        
        .. code-block:: csharp
    
           public PropertyInfo Property { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Runtime.TagHelpers.RuntimePropertyInfo.PropertyType
    
        
        :rtype: Microsoft.AspNet.Razor.Runtime.TagHelpers.ITypeInfo
    
        
        .. code-block:: csharp
    
           public ITypeInfo PropertyType { get; }
    

