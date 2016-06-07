

CodeAttributeChunk Class
========================





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
* :dn:cls:`Microsoft.AspNetCore.Razor.Chunks.CodeAttributeChunk`








Syntax
------

.. code-block:: csharp

    public class CodeAttributeChunk : ParentChunk








.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.CodeAttributeChunk
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.CodeAttributeChunk

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.CodeAttributeChunk
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Chunks.CodeAttributeChunk.Attribute
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Attribute
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Chunks.CodeAttributeChunk.Prefix
    
        
        :rtype: Microsoft.AspNetCore.Razor.Text.LocationTagged<Microsoft.AspNetCore.Razor.Text.LocationTagged`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public LocationTagged<string> Prefix
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Chunks.CodeAttributeChunk.Suffix
    
        
        :rtype: Microsoft.AspNetCore.Razor.Text.LocationTagged<Microsoft.AspNetCore.Razor.Text.LocationTagged`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public LocationTagged<string> Suffix
            {
                get;
                set;
            }
    

