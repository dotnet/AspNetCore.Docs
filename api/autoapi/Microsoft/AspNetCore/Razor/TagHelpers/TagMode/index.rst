

TagMode Enum
============






The mode in which an element should render.


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

    public enum TagMode








.. dn:enumeration:: Microsoft.AspNetCore.Razor.TagHelpers.TagMode
    :hidden:

.. dn:enumeration:: Microsoft.AspNetCore.Razor.TagHelpers.TagMode

Fields
------

.. dn:enumeration:: Microsoft.AspNetCore.Razor.TagHelpers.TagMode
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing
    
        
    
        
        A self-closed tag.
    
        
        :rtype: Microsoft.AspNetCore.Razor.TagHelpers.TagMode
    
        
        .. code-block:: csharp
    
            SelfClosing = 1
    
    .. dn:field:: Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag
    
        
    
        
        Include both start and end tags.
    
        
        :rtype: Microsoft.AspNetCore.Razor.TagHelpers.TagMode
    
        
        .. code-block:: csharp
    
            StartTagAndEndTag = 0
    
    .. dn:field:: Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly
    
        
    
        
        Only a start tag.
    
        
        :rtype: Microsoft.AspNetCore.Razor.TagHelpers.TagMode
    
        
        .. code-block:: csharp
    
            StartTagOnly = 2
    

