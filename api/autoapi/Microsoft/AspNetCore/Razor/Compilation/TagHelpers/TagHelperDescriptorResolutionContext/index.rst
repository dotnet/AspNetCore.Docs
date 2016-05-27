

TagHelperDescriptorResolutionContext Class
==========================================






Contains information needed to resolve :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s.


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
* :dn:cls:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptorResolutionContext`








Syntax
------

.. code-block:: csharp

    public class TagHelperDescriptorResolutionContext








.. dn:class:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptorResolutionContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptorResolutionContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptorResolutionContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptorResolutionContext.DirectiveDescriptors
    
        
    
        
        :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDirectiveDescriptor`\s used to resolve :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDirectiveDescriptor<Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDirectiveDescriptor>}
    
        
        .. code-block:: csharp
    
            public IList<TagHelperDirectiveDescriptor> DirectiveDescriptors
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptorResolutionContext.ErrorSink
    
        
    
        
        Used to aggregate :any:`Microsoft.AspNetCore.Razor.RazorError`\s.
    
        
        :rtype: Microsoft.AspNetCore.Razor.ErrorSink
    
        
        .. code-block:: csharp
    
            public ErrorSink ErrorSink
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptorResolutionContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptorResolutionContext.TagHelperDescriptorResolutionContext(System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDirectiveDescriptor>, Microsoft.AspNetCore.Razor.ErrorSink)
    
        
    
        
        Instantiates a new instance of :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptorResolutionContext`\.
    
        
    
        
        :param directiveDescriptors: :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDirectiveDescriptor`\s used to resolve 
            :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s.
        
        :type directiveDescriptors: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDirectiveDescriptor<Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDirectiveDescriptor>}
    
        
        :param errorSink: Used to aggregate :any:`Microsoft.AspNetCore.Razor.RazorError`\s.
        
        :type errorSink: Microsoft.AspNetCore.Razor.ErrorSink
    
        
        .. code-block:: csharp
    
            public TagHelperDescriptorResolutionContext(IEnumerable<TagHelperDirectiveDescriptor> directiveDescriptors, ErrorSink errorSink)
    

