

TagMode Enum
============



.. contents:: 
   :local:



Summary
-------

The mode in which an element should render.











Syntax
------

.. code-block:: csharp

   public enum TagMode





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/TagHelpers/TagMode.cs>`_





.. dn:enumeration:: Microsoft.AspNet.Razor.TagHelpers.TagMode

Fields
------

.. dn:enumeration:: Microsoft.AspNet.Razor.TagHelpers.TagMode
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Razor.TagHelpers.TagMode.SelfClosing
    
        
    
        A self-closed tag.
    
        
    
        
        .. code-block:: csharp
    
           SelfClosing = 1
    
    .. dn:field:: Microsoft.AspNet.Razor.TagHelpers.TagMode.StartTagAndEndTag
    
        
    
        Include both start and end tags.
    
        
    
        
        .. code-block:: csharp
    
           StartTagAndEndTag = 0
    
    .. dn:field:: Microsoft.AspNet.Razor.TagHelpers.TagMode.StartTagOnly
    
        
    
        Only a start tag.
    
        
    
        
        .. code-block:: csharp
    
           StartTagOnly = 2
    

