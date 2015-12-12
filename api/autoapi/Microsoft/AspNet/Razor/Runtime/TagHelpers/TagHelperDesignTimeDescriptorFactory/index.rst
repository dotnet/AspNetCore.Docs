

TagHelperDesignTimeDescriptorFactory Class
==========================================



.. contents:: 
   :local:



Summary
-------

Factory for providing :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDesignTimeDescriptor`\s from :any:`System.Type`\s and 
:any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperAttributeDesignTimeDescriptor`\s from :any:`System.Reflection.PropertyInfo`\s.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperDesignTimeDescriptorFactory`








Syntax
------

.. code-block:: csharp

   public class TagHelperDesignTimeDescriptorFactory





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor.Runtime/Runtime/TagHelpers/TagHelperDesignTimeDescriptorFactory.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperDesignTimeDescriptorFactory

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperDesignTimeDescriptorFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperDesignTimeDescriptorFactory.CreateAttributeDescriptor(System.Reflection.PropertyInfo)
    
        
    
        Creates a :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperAttributeDesignTimeDescriptor` from the given
        ``propertyInfo``.
    
        
        
        
        :param propertyInfo: The  to create a  from.
        
        :type propertyInfo: System.Reflection.PropertyInfo
        :rtype: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperAttributeDesignTimeDescriptor
        :return: A <see cref="T:Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperAttributeDesignTimeDescriptor" /> that describes design time specific
            information for the given <paramref name="propertyInfo" />.
    
        
        .. code-block:: csharp
    
           public static TagHelperAttributeDesignTimeDescriptor CreateAttributeDescriptor(PropertyInfo propertyInfo)
    
    .. dn:method:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperDesignTimeDescriptorFactory.CreateDescriptor(System.Type)
    
        
    
        Creates a :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDesignTimeDescriptor` from the given ``type``.
    
        
        
        
        :param type: The  to create a  from.
        
        :type type: System.Type
        :rtype: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDesignTimeDescriptor
        :return: A <see cref="T:Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDesignTimeDescriptor" /> that describes design time specific information
            for the given <paramref name="type" />.
    
        
        .. code-block:: csharp
    
           public static TagHelperDesignTimeDescriptor CreateDescriptor(Type type)
    

