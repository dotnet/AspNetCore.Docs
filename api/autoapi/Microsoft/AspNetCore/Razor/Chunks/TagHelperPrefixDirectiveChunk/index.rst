

TagHelperPrefixDirectiveChunk Class
===================================






A :any:`Microsoft.AspNetCore.Razor.Chunks.Chunk` for the <code>@tagHelperPrefix</code> directive.


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
* :dn:cls:`Microsoft.AspNetCore.Razor.Chunks.TagHelperPrefixDirectiveChunk`








Syntax
------

.. code-block:: csharp

    public class TagHelperPrefixDirectiveChunk : Chunk








.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.TagHelperPrefixDirectiveChunk
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.TagHelperPrefixDirectiveChunk

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.TagHelperPrefixDirectiveChunk
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Chunks.TagHelperPrefixDirectiveChunk.Prefix
    
        
    
        
        Text used as a required prefix when matching HTML start and end tags in the Razor source to available 
        tag helpers.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Prefix
            {
                get;
                set;
            }
    

