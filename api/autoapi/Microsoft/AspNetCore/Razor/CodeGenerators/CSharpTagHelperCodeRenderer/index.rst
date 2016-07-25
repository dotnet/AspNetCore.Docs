

CSharpTagHelperCodeRenderer Class
=================================






Renders tag helper rendering code.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.CodeGenerators`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.CodeGenerators.CSharpTagHelperCodeRenderer`








Syntax
------

.. code-block:: csharp

    public class CSharpTagHelperCodeRenderer








.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpTagHelperCodeRenderer
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpTagHelperCodeRenderer

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpTagHelperCodeRenderer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpTagHelperCodeRenderer.CSharpTagHelperCodeRenderer(Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.IChunkVisitor, Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter, Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext)
    
        
    
        
        Instantiates a new :any:`Microsoft.AspNetCore.Razor.CodeGenerators.CSharpTagHelperCodeRenderer`\.
    
        
    
        
        :param bodyVisitor: The :any:`Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.IChunkVisitor` used to render chunks found in the body.
        
        :type bodyVisitor: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.IChunkVisitor
    
        
        :param writer: The :any:`Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter` used to write code.
        
        :type writer: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        :param context: A :any:`Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext` instance that contains information about
            the current code generation process.
        
        :type context: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext
    
        
        .. code-block:: csharp
    
            public CSharpTagHelperCodeRenderer(IChunkVisitor bodyVisitor, CSharpCodeWriter writer, CodeGeneratorContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpTagHelperCodeRenderer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpTagHelperCodeRenderer.AttributeValueCodeRenderer
    
        
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.TagHelperAttributeValueCodeRenderer
    
        
        .. code-block:: csharp
    
            public TagHelperAttributeValueCodeRenderer AttributeValueCodeRenderer { get; set; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpTagHelperCodeRenderer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpTagHelperCodeRenderer.GenerateUniqueId()
    
        
    
        
        Generates a unique ID for an HTML element.
    
        
        :rtype: System.String
        :return: 
            A globally unique ID.
    
        
        .. code-block:: csharp
    
            protected virtual string GenerateUniqueId()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpTagHelperCodeRenderer.IsDynamicAttributeValue(Microsoft.AspNetCore.Razor.Chunks.Chunk)
    
        
    
        
        :type attributeValueChunk: Microsoft.AspNetCore.Razor.Chunks.Chunk
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool IsDynamicAttributeValue(Chunk attributeValueChunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpTagHelperCodeRenderer.RenderTagHelper(Microsoft.AspNetCore.Razor.Chunks.TagHelperChunk)
    
        
    
        
        Renders the code for the given <em>chunk</em>.
    
        
    
        
        :param chunk: A :any:`Microsoft.AspNetCore.Razor.Chunks.TagHelperChunk` to render.
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.TagHelperChunk
    
        
        .. code-block:: csharp
    
            public void RenderTagHelper(TagHelperChunk chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpTagHelperCodeRenderer.TryGetPlainTextValue(Microsoft.AspNetCore.Razor.Chunks.Chunk, out System.String)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.Chunk
    
        
        :type plainText: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool TryGetPlainTextValue(Chunk chunk, out string plainText)
    

