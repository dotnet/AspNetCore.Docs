

TagHelperDirectiveDescriptor Class
==================================






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
* :dn:cls:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDirectiveDescriptor`








Syntax
------

.. code-block:: csharp

    public class TagHelperDirectiveDescriptor








.. dn:class:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDirectiveDescriptor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDirectiveDescriptor

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDirectiveDescriptor
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDirectiveDescriptor.DirectiveText
    
        
    
        
        A :any:`System.String` used to find tag helper :any:`System.Type`\s.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string DirectiveText
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDirectiveDescriptor.DirectiveType
    
        
    
        
        The :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDirectiveType` of this directive.
    
        
        :rtype: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDirectiveType
    
        
        .. code-block:: csharp
    
            public TagHelperDirectiveType DirectiveType
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDirectiveDescriptor.Location
    
        
    
        
        The :any:`Microsoft.AspNetCore.Razor.SourceLocation` of the directive.
    
        
        :rtype: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
            public SourceLocation Location
            {
                get;
                set;
            }
    

