

LiteralCodeAttributeChunk Class
===============================





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
* :dn:cls:`Microsoft.AspNetCore.Razor.Chunks.ParentChunk`
* :dn:cls:`Microsoft.AspNetCore.Razor.Chunks.LiteralCodeAttributeChunk`








Syntax
------

.. code-block:: csharp

    public class LiteralCodeAttributeChunk : ParentChunk








.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.LiteralCodeAttributeChunk
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.LiteralCodeAttributeChunk

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.LiteralCodeAttributeChunk
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Chunks.LiteralCodeAttributeChunk.Code
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Code { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Chunks.LiteralCodeAttributeChunk.Prefix
    
        
        :rtype: Microsoft.AspNetCore.Razor.Text.LocationTagged<Microsoft.AspNetCore.Razor.Text.LocationTagged`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public LocationTagged<string> Prefix { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Chunks.LiteralCodeAttributeChunk.Value
    
        
        :rtype: Microsoft.AspNetCore.Razor.Text.LocationTagged<Microsoft.AspNetCore.Razor.Text.LocationTagged`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public LocationTagged<string> Value { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Chunks.LiteralCodeAttributeChunk.ValueLocation
    
        
        :rtype: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
            public SourceLocation ValueLocation { get; set; }
    

