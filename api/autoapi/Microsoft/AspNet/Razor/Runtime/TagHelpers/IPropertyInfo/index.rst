

IPropertyInfo Interface
=======================



.. contents:: 
   :local:



Summary
-------

Contains property metadata.











Syntax
------

.. code-block:: csharp

   public interface IPropertyInfo : IMemberInfo





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor.Runtime/Runtime/TagHelpers/IPropertyInfo.cs>`_





.. dn:interface:: Microsoft.AspNet.Razor.Runtime.TagHelpers.IPropertyInfo

Properties
----------

.. dn:interface:: Microsoft.AspNet.Razor.Runtime.TagHelpers.IPropertyInfo
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Runtime.TagHelpers.IPropertyInfo.HasPublicGetter
    
        
    
        Gets a value indicating whether this property has a public getter.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool HasPublicGetter { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Runtime.TagHelpers.IPropertyInfo.HasPublicSetter
    
        
    
        Gets a value indicating whether this property has a public setter.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool HasPublicSetter { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Runtime.TagHelpers.IPropertyInfo.PropertyType
    
        
    
        Gets the :any:`Microsoft.AspNet.Razor.Runtime.TagHelpers.ITypeInfo` of the property.
    
        
        :rtype: Microsoft.AspNet.Razor.Runtime.TagHelpers.ITypeInfo
    
        
        .. code-block:: csharp
    
           ITypeInfo PropertyType { get; }
    

