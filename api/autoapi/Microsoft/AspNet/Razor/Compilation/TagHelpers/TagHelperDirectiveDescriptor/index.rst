

TagHelperDirectiveDescriptor Class
==================================



.. contents:: 
   :local:



Summary
-------

Contains information needed to resolve :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDirectiveDescriptor`








Syntax
------

.. code-block:: csharp

   public class TagHelperDirectiveDescriptor





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/Compilation/TagHelpers/TagHelperDirectiveDescriptor.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDirectiveDescriptor

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDirectiveDescriptor
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDirectiveDescriptor.DirectiveText
    
        
    
        A :any:`System.String` used to find tag helper :any:`System.Type`\s.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string DirectiveText { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDirectiveDescriptor.DirectiveType
    
        
    
        The :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDirectiveType` of this directive.
    
        
        :rtype: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDirectiveType
    
        
        .. code-block:: csharp
    
           public TagHelperDirectiveType DirectiveType { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDirectiveDescriptor.Location
    
        
    
        The :any:`Microsoft.AspNet.Razor.SourceLocation` of the directive.
    
        
        :rtype: Microsoft.AspNet.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
           public SourceLocation Location { get; set; }
    

