

CodeGeneratorContext Class
==========================



.. contents:: 
   :local:



Summary
-------

Context object with information used to generate a Razor page.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext`








Syntax
------

.. code-block:: csharp

   public class CodeGeneratorContext : ChunkGeneratorContext





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/CodeGenerators/CodeGeneratorContext.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext.CodeGeneratorContext(Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext, Microsoft.AspNet.Razor.ErrorSink)
    
        
    
        Instantiates a new instance of the :any:`Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext` object.
    
        
        
        
        :param generatorContext: A  to copy information from.
        
        :type generatorContext: Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext
        
        
        :param errorSink: The  used to collect s encountered
            when parsing the current Razor document.
        
        :type errorSink: Microsoft.AspNet.Razor.ErrorSink
    
        
        .. code-block:: csharp
    
           public CodeGeneratorContext(ChunkGeneratorContext generatorContext, ErrorSink errorSink)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext.Checksum
    
        
    
        Gets or sets the <c>SHA1</c> based checksum for the file whose location is defined by 
        :dn:prop:`Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext.SourceFile`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Checksum { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext.ErrorSink
    
        
    
        Used to aggregate :any:`Microsoft.AspNet.Razor.RazorError`\s.
    
        
        :rtype: Microsoft.AspNet.Razor.ErrorSink
    
        
        .. code-block:: csharp
    
           public ErrorSink ErrorSink { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext.ExpressionRenderingMode
    
        
    
        The current C# rendering mode.
    
        
        :rtype: Microsoft.AspNet.Razor.CodeGenerators.ExpressionRenderingMode
    
        
        .. code-block:: csharp
    
           public ExpressionRenderingMode ExpressionRenderingMode { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext.TargetWriterName
    
        
    
        The C# writer to write :any:`Microsoft.AspNet.Razor.Chunks.Chunk` information to.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string TargetWriterName { get; set; }
    

