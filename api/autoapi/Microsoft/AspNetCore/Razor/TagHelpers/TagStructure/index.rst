

TagStructure Enum
=================






The structure the element should be written in.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.TagHelpers`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public enum TagStructure








.. dn:enumeration:: Microsoft.AspNetCore.Razor.TagHelpers.TagStructure
    :hidden:

.. dn:enumeration:: Microsoft.AspNetCore.Razor.TagHelpers.TagStructure

Fields
------

.. dn:enumeration:: Microsoft.AspNetCore.Razor.TagHelpers.TagStructure
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Razor.TagHelpers.TagStructure.NormalOrSelfClosing
    
        
    
        
        Element can be written as <my-tag-helper></my-tag-helper> or <my-tag-helper />.
    
        
        :rtype: Microsoft.AspNetCore.Razor.TagHelpers.TagStructure
    
        
        .. code-block:: csharp
    
            NormalOrSelfClosing = 1
    
    .. dn:field:: Microsoft.AspNetCore.Razor.TagHelpers.TagStructure.Unspecified
    
        
    
        
        If no other tag helper applies to the same element and specifies a :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagStructure`\,
        :dn:field:`Microsoft.AspNetCore.Razor.TagHelpers.TagStructure.NormalOrSelfClosing` will be used.
    
        
        :rtype: Microsoft.AspNetCore.Razor.TagHelpers.TagStructure
    
        
        .. code-block:: csharp
    
            Unspecified = 0
    
    .. dn:field:: Microsoft.AspNetCore.Razor.TagHelpers.TagStructure.WithoutEndTag
    
        
    
        
        Element can be written as <my-tag-helper> or <my-tag-helper />.
    
        
        :rtype: Microsoft.AspNetCore.Razor.TagHelpers.TagStructure
    
        
        .. code-block:: csharp
    
            WithoutEndTag = 2
    

