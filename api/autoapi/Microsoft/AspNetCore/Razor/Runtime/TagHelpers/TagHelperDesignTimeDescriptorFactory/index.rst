

TagHelperDesignTimeDescriptorFactory Class
==========================================






Factory for providing :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDesignTimeDescriptor`\s from :any:`System.Type`\s and 
:any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperAttributeDesignTimeDescriptor`\s from :any:`System.Reflection.PropertyInfo`\s.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Runtime.TagHelpers`
Assemblies
    * Microsoft.AspNetCore.Razor.Runtime

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperDesignTimeDescriptorFactory`








Syntax
------

.. code-block:: csharp

    public class TagHelperDesignTimeDescriptorFactory








.. dn:class:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperDesignTimeDescriptorFactory
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperDesignTimeDescriptorFactory

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperDesignTimeDescriptorFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperDesignTimeDescriptorFactory.CreateAttributeDescriptor(System.Reflection.PropertyInfo)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperAttributeDesignTimeDescriptor` from the given
        <em>propertyInfo</em>.
    
        
    
        
        :param propertyInfo: 
            The :any:`System.Reflection.PropertyInfo` to create a :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperAttributeDesignTimeDescriptor` from.
        
        :type propertyInfo: System.Reflection.PropertyInfo
        :rtype: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperAttributeDesignTimeDescriptor
        :return: A :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperAttributeDesignTimeDescriptor` that describes design time specific
            information for the given <em>propertyInfo</em>.
    
        
        .. code-block:: csharp
    
            public TagHelperAttributeDesignTimeDescriptor CreateAttributeDescriptor(PropertyInfo propertyInfo)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperDesignTimeDescriptorFactory.CreateDescriptor(System.Type)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDesignTimeDescriptor` from the given <em>type</em>.
    
        
    
        
        :param type: 
            The :any:`System.Type` to create a :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDesignTimeDescriptor` from.
        
        :type type: System.Type
        :rtype: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDesignTimeDescriptor
        :return: A :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDesignTimeDescriptor` that describes design time specific information
            for the given <em>type</em>.
    
        
        .. code-block:: csharp
    
            public TagHelperDesignTimeDescriptor CreateDescriptor(Type type)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperDesignTimeDescriptorFactory.GetAssemblyLocation(System.Reflection.Assembly)
    
        
    
        
        Retrieves <em>assembly</em>'s location on disk.
    
        
    
        
        :param assembly: The assembly.
        
        :type assembly: System.Reflection.Assembly
        :rtype: System.String
        :return: The path to the given <em>assembly</em>.
    
        
        .. code-block:: csharp
    
            public virtual string GetAssemblyLocation(Assembly assembly)
    

