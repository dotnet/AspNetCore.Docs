

ITagHelperDescriptorResolver Interface
======================================



.. contents:: 
   :local:



Summary
-------

Contract used to resolve :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s.











Syntax
------

.. code-block:: csharp

   public interface ITagHelperDescriptorResolver





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/Compilation/TagHelpers/ITagHelperDescriptorResolver.cs>`_





.. dn:interface:: Microsoft.AspNet.Razor.Compilation.TagHelpers.ITagHelperDescriptorResolver

Methods
-------

.. dn:interface:: Microsoft.AspNet.Razor.Compilation.TagHelpers.ITagHelperDescriptorResolver
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Compilation.TagHelpers.ITagHelperDescriptorResolver.Resolve(Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptorResolutionContext)
    
        
    
        Resolves :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s based on the given ``resolutionContext``.
    
        
        
        
        :param resolutionContext: used to resolve descriptors for the Razor page.
        
        :type resolutionContext: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptorResolutionContext
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor}
        :return: An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor" />s based
            on the given <paramref name="resolutionContext" />.
    
        
        .. code-block:: csharp
    
           IEnumerable<TagHelperDescriptor> Resolve(TagHelperDescriptorResolutionContext resolutionContext)
    

