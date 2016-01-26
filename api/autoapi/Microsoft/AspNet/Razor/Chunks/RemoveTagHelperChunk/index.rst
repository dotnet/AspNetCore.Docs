

RemoveTagHelperChunk Class
==========================



.. contents:: 
   :local:



Summary
-------

A :any:`Microsoft.AspNet.Razor.Chunks.Chunk` used to look up :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s that should be ignored
within the Razor page.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Chunks.Chunk`
* :dn:cls:`Microsoft.AspNet.Razor.Chunks.RemoveTagHelperChunk`








Syntax
------

.. code-block:: csharp

   public class RemoveTagHelperChunk : Chunk





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/Chunks/RemoveTagHelperChunk.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Chunks.RemoveTagHelperChunk

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Chunks.RemoveTagHelperChunk
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Chunks.RemoveTagHelperChunk.LookupText
    
        
    
        Text used to look up :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s that should be ignored within the Razor
        page.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string LookupText { get; set; }
    

