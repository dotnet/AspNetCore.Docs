

TypeBasedTagHelperDescriptorComparer Class
==========================================






An :any:`System.Collections.Generic.IEqualityComparer\`1` that checks equality between two 
:any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s using only their :dn:prop:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor.AssemblyName`\s and 
:dn:prop:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor.TypeName`\s.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TypeBasedTagHelperDescriptorComparer`








Syntax
------

.. code-block:: csharp

    public class TypeBasedTagHelperDescriptorComparer : IEqualityComparer<TagHelperDescriptor>








.. dn:class:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TypeBasedTagHelperDescriptorComparer
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TypeBasedTagHelperDescriptorComparer

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TypeBasedTagHelperDescriptorComparer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TypeBasedTagHelperDescriptorComparer.Equals(Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor, Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor)
    
        
    
        
        :type descriptorX: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor
    
        
        :type descriptorY: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Equals(TagHelperDescriptor descriptorX, TagHelperDescriptor descriptorY)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TypeBasedTagHelperDescriptorComparer.GetHashCode(Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor)
    
        
    
        
        :type descriptor: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int GetHashCode(TagHelperDescriptor descriptor)
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TypeBasedTagHelperDescriptorComparer
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TypeBasedTagHelperDescriptorComparer.Default
    
        
    
        
        A default instance of the :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TypeBasedTagHelperDescriptorComparer`\.
    
        
        :rtype: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TypeBasedTagHelperDescriptorComparer
    
        
        .. code-block:: csharp
    
            public static readonly TypeBasedTagHelperDescriptorComparer Default
    

