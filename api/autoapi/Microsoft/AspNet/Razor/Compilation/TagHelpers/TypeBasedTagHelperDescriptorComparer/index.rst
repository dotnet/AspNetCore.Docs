

TypeBasedTagHelperDescriptorComparer Class
==========================================



.. contents:: 
   :local:



Summary
-------

An :any:`System.Collections.Generic.IEqualityComparer\`1` that checks equality between two 
:any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s using only their :dn:prop:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor.AssemblyName`\s and 
:dn:prop:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor.TypeName`\s.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TypeBasedTagHelperDescriptorComparer`








Syntax
------

.. code-block:: csharp

   public class TypeBasedTagHelperDescriptorComparer : IEqualityComparer<TagHelperDescriptor>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/Compilation/TagHelpers/TypeBasedTagHelperDescriptorComparer.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TypeBasedTagHelperDescriptorComparer

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TypeBasedTagHelperDescriptorComparer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TypeBasedTagHelperDescriptorComparer.Equals(Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor, Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor)
    
        
        
        
        :type descriptorX: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor
        
        
        :type descriptorY: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Equals(TagHelperDescriptor descriptorX, TagHelperDescriptor descriptorY)
    
    .. dn:method:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TypeBasedTagHelperDescriptorComparer.GetHashCode(Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor)
    
        
        
        
        :type descriptor: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int GetHashCode(TagHelperDescriptor descriptor)
    

Fields
------

.. dn:class:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TypeBasedTagHelperDescriptorComparer
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TypeBasedTagHelperDescriptorComparer.Default
    
        
    
        A default instance of the :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TypeBasedTagHelperDescriptorComparer`\.
    
        
    
        
        .. code-block:: csharp
    
           public static readonly TypeBasedTagHelperDescriptorComparer Default
    

