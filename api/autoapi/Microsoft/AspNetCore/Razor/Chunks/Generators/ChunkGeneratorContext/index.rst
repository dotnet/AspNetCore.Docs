

ChunkGeneratorContext Class
===========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Chunks.Generators`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext`








Syntax
------

.. code-block:: csharp

    public class ChunkGeneratorContext








.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext.ChunkTreeBuilder
    
        
        :rtype: Microsoft.AspNetCore.Razor.Chunks.ChunkTreeBuilder
    
        
        .. code-block:: csharp
    
            public ChunkTreeBuilder ChunkTreeBuilder
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext.ClassName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ClassName
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext.Host
    
        
        :rtype: Microsoft.AspNetCore.Razor.RazorEngineHost
    
        
        .. code-block:: csharp
    
            public RazorEngineHost Host
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext.RootNamespace
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string RootNamespace
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext.SourceFile
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string SourceFile
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext.ChunkGeneratorContext(Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext
    
        
        .. code-block:: csharp
    
            protected ChunkGeneratorContext(ChunkGeneratorContext context)
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext.ChunkGeneratorContext(Microsoft.AspNetCore.Razor.RazorEngineHost, System.String, System.String, System.String, System.Boolean)
    
        
    
        
        :type host: Microsoft.AspNetCore.Razor.RazorEngineHost
    
        
        :type className: System.String
    
        
        :type rootNamespace: System.String
    
        
        :type sourceFile: System.String
    
        
        :type shouldGenerateLinePragmas: System.Boolean
    
        
        .. code-block:: csharp
    
            public ChunkGeneratorContext(RazorEngineHost host, string className, string rootNamespace, string sourceFile, bool shouldGenerateLinePragmas)
    

