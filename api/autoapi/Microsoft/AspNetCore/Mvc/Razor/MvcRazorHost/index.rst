

MvcRazorHost Class
==================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Razor`
Assemblies
    * Microsoft.AspNetCore.Mvc.Razor.Host

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.RazorEngineHost`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.MvcRazorHost`








Syntax
------

.. code-block:: csharp

    public class MvcRazorHost : RazorEngineHost, IMvcRazorHost, IDisposable








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.MvcRazorHost
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.MvcRazorHost

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.MvcRazorHost
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.MvcRazorHost.CreateModelExpressionMethod
    
        
    
        
        Gets the method name used to create model expressions.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string CreateModelExpressionMethod
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.MvcRazorHost.DefaultInheritedChunks
    
        
    
        
        Gets the list of chunks that are injected by default by this host.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Razor.Chunks.Chunk<Microsoft.AspNetCore.Razor.Chunks.Chunk>}
    
        
        .. code-block:: csharp
    
            public virtual IReadOnlyList<Chunk> DefaultInheritedChunks
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.MvcRazorHost.DefaultModel
    
        
    
        
        Gets the model type used by default when no model is specified.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string DefaultModel
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.MvcRazorHost.InjectAttribute
    
        
    
        
        Gets or sets the name attribute that is used to decorate properties that are injected and need to be
        activated.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string InjectAttribute
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.MvcRazorHost.ModelExpressionType
    
        
    
        
        Gets the type name used to represent :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper` model expression properties.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string ModelExpressionType
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.MvcRazorHost.TagHelperDescriptorResolver
    
        
        :rtype: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.ITagHelperDescriptorResolver
    
        
        .. code-block:: csharp
    
            public override ITagHelperDescriptorResolver TagHelperDescriptorResolver
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.MvcRazorHost
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.MvcRazorHost.MvcRazorHost(Microsoft.AspNetCore.Mvc.Razor.Directives.IChunkTreeCache, Microsoft.AspNetCore.Razor.Compilation.TagHelpers.ITagHelperDescriptorResolver)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Razor.MvcRazorHost` using the specified <em>chunkTreeCache</em>.
    
        
    
        
        :param chunkTreeCache: An :any:`Microsoft.AspNetCore.Mvc.Razor.Directives.IChunkTreeCache` rooted at the application base path.
        
        :type chunkTreeCache: Microsoft.AspNetCore.Mvc.Razor.Directives.IChunkTreeCache
    
        
        :param resolver: The :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.ITagHelperDescriptorResolver` used to resolve tag helpers on razor views.
        
        :type resolver: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.ITagHelperDescriptorResolver
    
        
        .. code-block:: csharp
    
            public MvcRazorHost(IChunkTreeCache chunkTreeCache, ITagHelperDescriptorResolver resolver)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.MvcRazorHost.MvcRazorHost(System.String)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Razor.MvcRazorHost` with the specified  <em>root</em>.
    
        
    
        
        :param root: The path to the application base.
        
        :type root: System.String
    
        
        .. code-block:: csharp
    
            public MvcRazorHost(string root)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.MvcRazorHost
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.MvcRazorHost.DecorateCodeGenerator(Microsoft.AspNetCore.Razor.CodeGenerators.CodeGenerator, Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext)
    
        
    
        
        :type incomingGenerator: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGenerator
    
        
        :type context: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGenerator
    
        
        .. code-block:: csharp
    
            public override CodeGenerator DecorateCodeGenerator(CodeGenerator incomingGenerator, CodeGeneratorContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.MvcRazorHost.DecorateCodeParser(Microsoft.AspNetCore.Razor.Parser.ParserBase)
    
        
    
        
        :type incomingCodeParser: Microsoft.AspNetCore.Razor.Parser.ParserBase
        :rtype: Microsoft.AspNetCore.Razor.Parser.ParserBase
    
        
        .. code-block:: csharp
    
            public override ParserBase DecorateCodeParser(ParserBase incomingCodeParser)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.MvcRazorHost.DecorateRazorParser(Microsoft.AspNetCore.Razor.Parser.RazorParser, System.String)
    
        
    
        
        :type razorParser: Microsoft.AspNetCore.Razor.Parser.RazorParser
    
        
        :type sourceFileName: System.String
        :rtype: Microsoft.AspNetCore.Razor.Parser.RazorParser
    
        
        .. code-block:: csharp
    
            public override RazorParser DecorateRazorParser(RazorParser razorParser, string sourceFileName)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.MvcRazorHost.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.MvcRazorHost.GenerateCode(System.String, System.IO.Stream)
    
        
    
        
        :type rootRelativePath: System.String
    
        
        :type inputStream: System.IO.Stream
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratorResults
    
        
        .. code-block:: csharp
    
            public GeneratorResults GenerateCode(string rootRelativePath, Stream inputStream)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.MvcRazorHost.GetInheritedChunkTreeResults(System.String)
    
        
    
        
        Locates and parses _ViewImports.cshtml files applying to the given <em>sourceFileName</em> to
        create :any:`Microsoft.AspNetCore.Mvc.Razor.Directives.ChunkTreeResult`\s.
    
        
    
        
        :param sourceFileName: The path to a Razor file to locate _ViewImports.cshtml for.
        
        :type sourceFileName: System.String
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Mvc.Razor.Directives.ChunkTreeResult<Microsoft.AspNetCore.Mvc.Razor.Directives.ChunkTreeResult>}
        :return: Inherited :any:`Microsoft.AspNetCore.Mvc.Razor.Directives.ChunkTreeResult`\s.
    
        
        .. code-block:: csharp
    
            public IReadOnlyList<ChunkTreeResult> GetInheritedChunkTreeResults(string sourceFileName)
    

