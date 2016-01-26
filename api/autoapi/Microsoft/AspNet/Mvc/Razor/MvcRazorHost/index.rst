

MvcRazorHost Class
==================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.RazorEngineHost`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.MvcRazorHost`








Syntax
------

.. code-block:: csharp

   public class MvcRazorHost : RazorEngineHost, IMvcRazorHost





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Razor.Host/MvcRazorHost.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.MvcRazorHost

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.MvcRazorHost
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.MvcRazorHost.MvcRazorHost(Microsoft.AspNet.Mvc.Razor.Directives.IChunkTreeCache)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Mvc.Razor.MvcRazorHost` using the specified ``chunkTreeCache``.
    
        
        
        
        :param chunkTreeCache: An  rooted at the application base path.
        
        :type chunkTreeCache: Microsoft.AspNet.Mvc.Razor.Directives.IChunkTreeCache
    
        
        .. code-block:: csharp
    
           public MvcRazorHost(IChunkTreeCache chunkTreeCache)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.MvcRazorHost
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.MvcRazorHost.DecorateCodeGenerator(Microsoft.AspNet.Razor.CodeGenerators.CodeGenerator, Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext)
    
        
        
        
        :type incomingGenerator: Microsoft.AspNet.Razor.CodeGenerators.CodeGenerator
        
        
        :type context: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext
        :rtype: Microsoft.AspNet.Razor.CodeGenerators.CodeGenerator
    
        
        .. code-block:: csharp
    
           public override CodeGenerator DecorateCodeGenerator(CodeGenerator incomingGenerator, CodeGeneratorContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.MvcRazorHost.DecorateCodeParser(Microsoft.AspNet.Razor.Parser.ParserBase)
    
        
        
        
        :type incomingCodeParser: Microsoft.AspNet.Razor.Parser.ParserBase
        :rtype: Microsoft.AspNet.Razor.Parser.ParserBase
    
        
        .. code-block:: csharp
    
           public override ParserBase DecorateCodeParser(ParserBase incomingCodeParser)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.MvcRazorHost.DecorateRazorParser(Microsoft.AspNet.Razor.Parser.RazorParser, System.String)
    
        
        
        
        :type razorParser: Microsoft.AspNet.Razor.Parser.RazorParser
        
        
        :type sourceFileName: System.String
        :rtype: Microsoft.AspNet.Razor.Parser.RazorParser
    
        
        .. code-block:: csharp
    
           public override RazorParser DecorateRazorParser(RazorParser razorParser, string sourceFileName)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.MvcRazorHost.GenerateCode(System.String, System.IO.Stream)
    
        
        
        
        :type rootRelativePath: System.String
        
        
        :type inputStream: System.IO.Stream
        :rtype: Microsoft.AspNet.Razor.CodeGenerators.GeneratorResults
    
        
        .. code-block:: csharp
    
           public GeneratorResults GenerateCode(string rootRelativePath, Stream inputStream)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.MvcRazorHost.GetInheritedChunkTreeResults(System.String)
    
        
    
        Locates and parses _ViewImports.cshtml files applying to the given ``sourceFileName`` to
        create :any:`Microsoft.AspNet.Mvc.Razor.Directives.ChunkTreeResult`\s.
    
        
        
        
        :param sourceFileName: The path to a Razor file to locate _ViewImports.cshtml for.
        
        :type sourceFileName: System.String
        :rtype: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Mvc.Razor.Directives.ChunkTreeResult}
        :return: Inherited <see cref="T:Microsoft.AspNet.Mvc.Razor.Directives.ChunkTreeResult" />s.
    
        
        .. code-block:: csharp
    
           public IReadOnlyList<ChunkTreeResult> GetInheritedChunkTreeResults(string sourceFileName)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.MvcRazorHost
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.MvcRazorHost.CreateModelExpressionMethod
    
        
    
        Gets the method name used to create model expressions.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public virtual string CreateModelExpressionMethod { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.MvcRazorHost.DefaultInheritedChunks
    
        
    
        Gets the list of chunks that are injected by default by this host.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Razor.Chunks.Chunk}
    
        
        .. code-block:: csharp
    
           public virtual IReadOnlyList<Chunk> DefaultInheritedChunks { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.MvcRazorHost.DefaultModel
    
        
    
        Gets the model type used by default when no model is specified.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public virtual string DefaultModel { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.MvcRazorHost.InjectAttribute
    
        
    
        Gets or sets the name attribute that is used to decorate properties that are injected and need to be
        activated.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public virtual string InjectAttribute { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.MvcRazorHost.MainClassNamePrefix
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string MainClassNamePrefix { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.MvcRazorHost.ModelExpressionType
    
        
    
        Gets the type name used to represent :any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper` model expression properties.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public virtual string ModelExpressionType { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.MvcRazorHost.TagHelperDescriptorResolver
    
        
        :rtype: Microsoft.AspNet.Razor.Compilation.TagHelpers.ITagHelperDescriptorResolver
    
        
        .. code-block:: csharp
    
           public override ITagHelperDescriptorResolver TagHelperDescriptorResolver { get; set; }
    

