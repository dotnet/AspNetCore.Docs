

TagHelperDescriptorResolutionContext Class
==========================================



.. contents:: 
   :local:



Summary
-------

Contains information needed to resolve :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptorResolutionContext`








Syntax
------

.. code-block:: csharp

   public class TagHelperDescriptorResolutionContext





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/Compilation/TagHelpers/TagHelperDescriptorResolutionContext.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptorResolutionContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptorResolutionContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptorResolutionContext.TagHelperDescriptorResolutionContext(System.Collections.Generic.IEnumerable<Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDirectiveDescriptor>, Microsoft.AspNet.Razor.ErrorSink)
    
        
    
        Instantiates a new instance of :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptorResolutionContext`\.
    
        
        
        
        :param directiveDescriptors: s used to resolve
            s.
        
        :type directiveDescriptors: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDirectiveDescriptor}
        
        
        :param errorSink: Used to aggregate s.
        
        :type errorSink: Microsoft.AspNet.Razor.ErrorSink
    
        
        .. code-block:: csharp
    
           public TagHelperDescriptorResolutionContext(IEnumerable<TagHelperDirectiveDescriptor> directiveDescriptors, ErrorSink errorSink)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptorResolutionContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptorResolutionContext.DirectiveDescriptors
    
        
    
        :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDirectiveDescriptor`\s used to resolve :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s.
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDirectiveDescriptor}
    
        
        .. code-block:: csharp
    
           public IList<TagHelperDirectiveDescriptor> DirectiveDescriptors { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptorResolutionContext.ErrorSink
    
        
    
        Used to aggregate :any:`Microsoft.AspNet.Razor.RazorError`\s.
    
        
        :rtype: Microsoft.AspNet.Razor.ErrorSink
    
        
        .. code-block:: csharp
    
           public ErrorSink ErrorSink { get; }
    

