

CodeAttributeChunk Class
========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Chunks.Chunk`
* :dn:cls:`Microsoft.AspNet.Razor.Chunks.ParentChunk`
* :dn:cls:`Microsoft.AspNet.Razor.Chunks.CodeAttributeChunk`








Syntax
------

.. code-block:: csharp

   public class CodeAttributeChunk : ParentChunk





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/Chunks/CodeAttributeChunk.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Chunks.CodeAttributeChunk

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Chunks.CodeAttributeChunk
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Chunks.CodeAttributeChunk.Attribute
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Attribute { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Chunks.CodeAttributeChunk.Prefix
    
        
        :rtype: Microsoft.AspNet.Razor.Text.LocationTagged{System.String}
    
        
        .. code-block:: csharp
    
           public LocationTagged<string> Prefix { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Chunks.CodeAttributeChunk.Suffix
    
        
        :rtype: Microsoft.AspNet.Razor.Text.LocationTagged{System.String}
    
        
        .. code-block:: csharp
    
           public LocationTagged<string> Suffix { get; set; }
    

