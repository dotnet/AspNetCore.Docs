

TagHelperDescriptorComparer Class
=================================






An :any:`System.Collections.Generic.IEqualityComparer\`1` used to check equality between
two :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s.


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
* :dn:cls:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptorComparer`








Syntax
------

.. code-block:: csharp

    public class TagHelperDescriptorComparer : IEqualityComparer<TagHelperDescriptor>








.. dn:class:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptorComparer
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptorComparer

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptorComparer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptorComparer.TagHelperDescriptorComparer()
    
        
    
        
        Initializes a new :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptorComparer` instance.
    
        
    
        
        .. code-block:: csharp
    
            protected TagHelperDescriptorComparer()
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptorComparer
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptorComparer.Default
    
        
    
        
        A default instance of the :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptorComparer`\.
    
        
        :rtype: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptorComparer
    
        
        .. code-block:: csharp
    
            public static readonly TagHelperDescriptorComparer Default
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptorComparer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptorComparer.Equals(Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor, Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor)
    
        
    
        
        :type descriptorX: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor
    
        
        :type descriptorY: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public virtual bool Equals(TagHelperDescriptor descriptorX, TagHelperDescriptor descriptorY)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptorComparer.GetHashCode(Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor)
    
        
    
        
        :type descriptor: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public virtual int GetHashCode(TagHelperDescriptor descriptor)
    

