

ITagHelperDescriptorResolver Interface
======================================






Contract used to resolve :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface ITagHelperDescriptorResolver








.. dn:interface:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.ITagHelperDescriptorResolver
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.ITagHelperDescriptorResolver

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.ITagHelperDescriptorResolver
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.ITagHelperDescriptorResolver.Resolve(Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptorResolutionContext)
    
        
    
        
        Resolves :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s based on the given <em>resolutionContext</em>.
    
        
    
        
        :param resolutionContext: 
            :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptorResolutionContext` used to resolve descriptors for the Razor page.
        
        :type resolutionContext: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptorResolutionContext
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor<Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor>}
        :return: An :any:`System.Collections.Generic.IEnumerable\`1` of :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s based
            on the given <em>resolutionContext</em>.
    
        
        .. code-block:: csharp
    
            IEnumerable<TagHelperDescriptor> Resolve(TagHelperDescriptorResolutionContext resolutionContext)
    

