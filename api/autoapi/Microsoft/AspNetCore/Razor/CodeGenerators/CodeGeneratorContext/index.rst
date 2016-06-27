

CodeGeneratorContext Class
==========================






Context object with information used to generate a Razor page.


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
* :dn:cls:`Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext`
* :dn:cls:`Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext`








Syntax
------

.. code-block:: csharp

    public class CodeGeneratorContext : ChunkGeneratorContext








.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext.CodeGeneratorContext(Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext, Microsoft.AspNetCore.Razor.ErrorSink)
    
        
    
        
        Instantiates a new instance of the :any:`Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext` object.
    
        
    
        
        :param generatorContext: A :any:`Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext` to copy information from.
        
        :type generatorContext: Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext
    
        
        :param errorSink: 
            The :dn:prop:`Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext.ErrorSink` used to collect :any:`Microsoft.AspNetCore.Razor.RazorError`\s encountered
            when parsing the current Razor document.
        
        :type errorSink: Microsoft.AspNetCore.Razor.ErrorSink
    
        
        .. code-block:: csharp
    
            public CodeGeneratorContext(ChunkGeneratorContext generatorContext, ErrorSink errorSink)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext.Checksum
    
        
    
        
        Gets or sets the <code>SHA1</code> based checksum for the file whose location is defined by 
        :dn:prop:`Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext.SourceFile`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Checksum { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext.ErrorSink
    
        
    
        
        Used to aggregate :any:`Microsoft.AspNetCore.Razor.RazorError`\s.
    
        
        :rtype: Microsoft.AspNetCore.Razor.ErrorSink
    
        
        .. code-block:: csharp
    
            public ErrorSink ErrorSink { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext.ExpressionRenderingMode
    
        
    
        
        The current C# rendering mode.
    
        
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.ExpressionRenderingMode
    
        
        .. code-block:: csharp
    
            public ExpressionRenderingMode ExpressionRenderingMode { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext.TargetWriterName
    
        
    
        
        The C# writer to write :any:`Microsoft.AspNetCore.Razor.Chunks.Chunk` information to.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string TargetWriterName { get; set; }
    

