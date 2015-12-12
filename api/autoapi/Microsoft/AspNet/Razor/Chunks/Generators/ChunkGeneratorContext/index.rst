

ChunkGeneratorContext Class
===========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext`








Syntax
------

.. code-block:: csharp

   public class ChunkGeneratorContext





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/Chunks/Generators/ChunkGeneratorContext.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext.ChunkGeneratorContext(Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext)
    
        
        
        
        :type context: Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext
    
        
        .. code-block:: csharp
    
           protected ChunkGeneratorContext(ChunkGeneratorContext context)
    
    .. dn:constructor:: Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext.ChunkGeneratorContext(Microsoft.AspNet.Razor.RazorEngineHost, System.String, System.String, System.String, System.Boolean)
    
        
        
        
        :type host: Microsoft.AspNet.Razor.RazorEngineHost
        
        
        :type className: System.String
        
        
        :type rootNamespace: System.String
        
        
        :type sourceFile: System.String
        
        
        :type shouldGenerateLinePragmas: System.Boolean
    
        
        .. code-block:: csharp
    
           public ChunkGeneratorContext(RazorEngineHost host, string className, string rootNamespace, string sourceFile, bool shouldGenerateLinePragmas)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext.ChunkTreeBuilder
    
        
        :rtype: Microsoft.AspNet.Razor.Chunks.ChunkTreeBuilder
    
        
        .. code-block:: csharp
    
           public ChunkTreeBuilder ChunkTreeBuilder { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext.ClassName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ClassName { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext.Host
    
        
        :rtype: Microsoft.AspNet.Razor.RazorEngineHost
    
        
        .. code-block:: csharp
    
           public RazorEngineHost Host { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext.RootNamespace
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string RootNamespace { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext.SourceFile
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string SourceFile { get; }
    

