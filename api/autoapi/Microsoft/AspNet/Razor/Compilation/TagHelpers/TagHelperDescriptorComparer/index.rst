

TagHelperDescriptorComparer Class
=================================



.. contents:: 
   :local:



Summary
-------

An :any:`System.Collections.Generic.IEqualityComparer\`1` used to check equality between
two :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptorComparer`








Syntax
------

.. code-block:: csharp

   public class TagHelperDescriptorComparer : IEqualityComparer<TagHelperDescriptor>





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/Compilation/TagHelpers/TagHelperDescriptorComparer.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptorComparer

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptorComparer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptorComparer.TagHelperDescriptorComparer()
    
        
    
        Initializes a new :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptorComparer` instance.
    
        
    
        
        .. code-block:: csharp
    
           protected TagHelperDescriptorComparer()
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptorComparer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptorComparer.Equals(Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor, Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor)
    
        
        
        
        :type descriptorX: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor
        
        
        :type descriptorY: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual bool Equals(TagHelperDescriptor descriptorX, TagHelperDescriptor descriptorY)
    
    .. dn:method:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptorComparer.GetHashCode(Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor)
    
        
        
        
        :type descriptor: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public virtual int GetHashCode(TagHelperDescriptor descriptor)
    

Fields
------

.. dn:class:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptorComparer
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptorComparer.Default
    
        
    
        A default instance of the :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptorComparer`\.
    
        
    
        
        .. code-block:: csharp
    
           public static readonly TagHelperDescriptorComparer Default
    

