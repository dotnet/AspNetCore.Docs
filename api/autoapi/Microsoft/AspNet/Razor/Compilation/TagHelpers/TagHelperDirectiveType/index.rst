

TagHelperDirectiveType Enum
===========================



.. contents:: 
   :local:



Summary
-------

The type of tag helper directive.











Syntax
------

.. code-block:: csharp

   public enum TagHelperDirectiveType





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/Compilation/TagHelpers/TagHelperDirectiveType.cs>`_





.. dn:enumeration:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDirectiveType

Fields
------

.. dn:enumeration:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDirectiveType
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDirectiveType.AddTagHelper
    
        
    
        An <c>@addTagHelper</c> directive.
    
        
    
        
        .. code-block:: csharp
    
           AddTagHelper = 0
    
    .. dn:field:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDirectiveType.RemoveTagHelper
    
        
    
        A <c>@removeTagHelper</c> directive.
    
        
    
        
        .. code-block:: csharp
    
           RemoveTagHelper = 1
    
    .. dn:field:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDirectiveType.TagHelperPrefix
    
        
    
        A <c>@tagHelperPrefix</c> directive.
    
        
    
        
        .. code-block:: csharp
    
           TagHelperPrefix = 2
    

