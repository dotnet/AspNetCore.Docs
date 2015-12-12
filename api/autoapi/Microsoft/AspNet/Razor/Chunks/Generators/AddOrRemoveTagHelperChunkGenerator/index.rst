

AddOrRemoveTagHelperChunkGenerator Class
========================================



.. contents:: 
   :local:



Summary
-------

A :any:`Microsoft.AspNet.Razor.Chunks.Generators.SpanChunkGenerator` responsible for generating :any:`Microsoft.AspNet.Razor.Chunks.AddTagHelperChunk`\s and 
:any:`Microsoft.AspNet.Razor.Chunks.RemoveTagHelperChunk`\s.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Chunks.Generators.SpanChunkGenerator`
* :dn:cls:`Microsoft.AspNet.Razor.Chunks.Generators.AddOrRemoveTagHelperChunkGenerator`








Syntax
------

.. code-block:: csharp

   public class AddOrRemoveTagHelperChunkGenerator : SpanChunkGenerator, ISpanChunkGenerator





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/Chunks/Generators/AddOrRemoveTagHelperChunkGenerator.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.AddOrRemoveTagHelperChunkGenerator

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.AddOrRemoveTagHelperChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Chunks.Generators.AddOrRemoveTagHelperChunkGenerator.AddOrRemoveTagHelperChunkGenerator(System.Boolean, System.String)
    
        
    
        Instantiates a new :any:`Microsoft.AspNet.Razor.Chunks.Generators.AddOrRemoveTagHelperChunkGenerator`\.
    
        
        
        
        :type removeTagHelperDescriptors: System.Boolean
        
        
        :param lookupText: Text used to look up s that should be added or removed.
        
        :type lookupText: System.String
    
        
        .. code-block:: csharp
    
           public AddOrRemoveTagHelperChunkGenerator(bool removeTagHelperDescriptors, string lookupText)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.AddOrRemoveTagHelperChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.Generators.AddOrRemoveTagHelperChunkGenerator.GenerateChunk(Microsoft.AspNet.Razor.Parser.SyntaxTree.Span, Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext)
    
        
    
        Generates :any:`Microsoft.AspNet.Razor.Chunks.AddTagHelperChunk`\s if :dn:prop:`Microsoft.AspNet.Razor.Chunks.Generators.AddOrRemoveTagHelperChunkGenerator.RemoveTagHelperDescriptors` is
        <c>true</c>, otherwise :any:`Microsoft.AspNet.Razor.Chunks.RemoveTagHelperChunk`\s are generated.
    
        
        
        
        :param target: The  responsible for this .
        
        :type target: Microsoft.AspNet.Razor.Parser.SyntaxTree.Span
        
        
        :param context: A  instance that contains information about
            the current chunk generation process.
        
        :type context: Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext
    
        
        .. code-block:: csharp
    
           public override void GenerateChunk(Span target, ChunkGeneratorContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.AddOrRemoveTagHelperChunkGenerator
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Chunks.Generators.AddOrRemoveTagHelperChunkGenerator.LookupText
    
        
    
        Gets the text used to look up :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s that should be added to or
        removed from the Razor page.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string LookupText { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Chunks.Generators.AddOrRemoveTagHelperChunkGenerator.RemoveTagHelperDescriptors
    
        
    
        Whether we want to remove :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s from the Razor page.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool RemoveTagHelperDescriptors { get; }
    

