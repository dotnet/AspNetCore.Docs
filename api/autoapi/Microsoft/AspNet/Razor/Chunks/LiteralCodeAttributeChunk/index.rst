

LiteralCodeAttributeChunk Class
===============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Chunks.Chunk`
* :dn:cls:`Microsoft.AspNet.Razor.Chunks.ParentChunk`
* :dn:cls:`Microsoft.AspNet.Razor.Chunks.LiteralCodeAttributeChunk`








Syntax
------

.. code-block:: csharp

   public class LiteralCodeAttributeChunk : ParentChunk





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/Chunks/LiteralCodeAttributeChunk.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Chunks.LiteralCodeAttributeChunk

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Chunks.LiteralCodeAttributeChunk
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Chunks.LiteralCodeAttributeChunk.Code
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Code { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Chunks.LiteralCodeAttributeChunk.Prefix
    
        
        :rtype: Microsoft.AspNet.Razor.Text.LocationTagged{System.String}
    
        
        .. code-block:: csharp
    
           public LocationTagged<string> Prefix { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Chunks.LiteralCodeAttributeChunk.Value
    
        
        :rtype: Microsoft.AspNet.Razor.Text.LocationTagged{System.String}
    
        
        .. code-block:: csharp
    
           public LocationTagged<string> Value { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Chunks.LiteralCodeAttributeChunk.ValueLocation
    
        
        :rtype: Microsoft.AspNet.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
           public SourceLocation ValueLocation { get; set; }
    

