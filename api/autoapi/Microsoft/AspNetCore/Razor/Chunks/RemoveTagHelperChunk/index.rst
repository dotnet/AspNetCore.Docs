

RemoveTagHelperChunk Class
==========================






A :any:`Microsoft.AspNetCore.Razor.Chunks.Chunk` used to look up :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s that should be ignored
within the Razor page.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Chunks`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.Chunks.Chunk`
* :dn:cls:`Microsoft.AspNetCore.Razor.Chunks.RemoveTagHelperChunk`








Syntax
------

.. code-block:: csharp

    public class RemoveTagHelperChunk : Chunk








.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.RemoveTagHelperChunk
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.RemoveTagHelperChunk

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.RemoveTagHelperChunk
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Chunks.RemoveTagHelperChunk.LookupText
    
        
    
        
        Text used to look up :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s that should be ignored within the Razor
        page.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string LookupText { get; set; }
    

