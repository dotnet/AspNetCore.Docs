

TagStructure Enum
=================



.. contents:: 
   :local:



Summary
-------

The structure the element should be written in.











Syntax
------

.. code-block:: csharp

   public enum TagStructure





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/TagHelpers/TagStructure.cs>`_





.. dn:enumeration:: Microsoft.AspNet.Razor.TagHelpers.TagStructure

Fields
------

.. dn:enumeration:: Microsoft.AspNet.Razor.TagHelpers.TagStructure
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Razor.TagHelpers.TagStructure.NormalOrSelfClosing
    
        
    
        Element can be written as &lt;my-tag-helper&gt;&lt;/my-tag-helper&gt; or &lt;my-tag-helper /&gt;.
    
        
    
        
        .. code-block:: csharp
    
           NormalOrSelfClosing = 1
    
    .. dn:field:: Microsoft.AspNet.Razor.TagHelpers.TagStructure.Unspecified
    
        
    
        If no other tag helper applies to the same element and specifies a :any:`Microsoft.AspNet.Razor.TagHelpers.TagStructure`\, 
        :dn:field:`Microsoft.AspNet.Razor.TagHelpers.TagStructure.NormalOrSelfClosing` will be used.
    
        
    
        
        .. code-block:: csharp
    
           Unspecified = 0
    
    .. dn:field:: Microsoft.AspNet.Razor.TagHelpers.TagStructure.WithoutEndTag
    
        
    
        Element can be written as &lt;my-tag-helper&gt; or &lt;my-tag-helper /&gt;.
    
        
    
        
        .. code-block:: csharp
    
           WithoutEndTag = 2
    

