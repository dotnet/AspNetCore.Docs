

TagHelperRequiredAttributeDescriptorComparer Class
==================================================






An :any:`System.Collections.Generic.IEqualityComparer\`1` used to check equality between
two :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptor`\s.


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
* :dn:cls:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptorComparer`








Syntax
------

.. code-block:: csharp

    public class TagHelperRequiredAttributeDescriptorComparer : IEqualityComparer<TagHelperRequiredAttributeDescriptor>








.. dn:class:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptorComparer
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptorComparer

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptorComparer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptorComparer.TagHelperRequiredAttributeDescriptorComparer()
    
        
    
        
        Initializes a new :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptor` instance.
    
        
    
        
        .. code-block:: csharp
    
            protected TagHelperRequiredAttributeDescriptorComparer()
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptorComparer
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptorComparer.Default
    
        
    
        
        A default instance of the :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptor`\.
    
        
        :rtype: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptorComparer
    
        
        .. code-block:: csharp
    
            public static readonly TagHelperRequiredAttributeDescriptorComparer Default
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptorComparer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptorComparer.Equals(Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptor, Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptor)
    
        
    
        
        :type descriptorX: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptor
    
        
        :type descriptorY: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptor
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public virtual bool Equals(TagHelperRequiredAttributeDescriptor descriptorX, TagHelperRequiredAttributeDescriptor descriptorY)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptorComparer.GetHashCode(Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptor)
    
        
    
        
        :type descriptor: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptor
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public virtual int GetHashCode(TagHelperRequiredAttributeDescriptor descriptor)
    

