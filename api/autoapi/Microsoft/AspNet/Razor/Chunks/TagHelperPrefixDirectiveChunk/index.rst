

TagHelperPrefixDirectiveChunk Class
===================================



.. contents:: 
   :local:



Summary
-------

A :any:`Microsoft.AspNet.Razor.Chunks.Chunk` for the <c>@tagHelperPrefix</c> directive.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Chunks.Chunk`
* :dn:cls:`Microsoft.AspNet.Razor.Chunks.TagHelperPrefixDirectiveChunk`








Syntax
------

.. code-block:: csharp

   public class TagHelperPrefixDirectiveChunk : Chunk





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/Chunks/TagHelperPrefixDirectiveChunk.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Chunks.TagHelperPrefixDirectiveChunk

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Chunks.TagHelperPrefixDirectiveChunk
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Chunks.TagHelperPrefixDirectiveChunk.Prefix
    
        
    
        Text used as a required prefix when matching HTML start and end tags in the Razor source to available
        tag helpers.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Prefix { get; set; }
    

