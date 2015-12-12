

RazorEngineHost Class
=====================



.. contents:: 
   :local:



Summary
-------

Defines the environment in which a Razor template will live





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.RazorEngineHost`








Syntax
------

.. code-block:: csharp

   public class RazorEngineHost





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/RazorEngineHost.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.RazorEngineHost

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.RazorEngineHost
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.RazorEngineHost.RazorEngineHost()
    
        
    
        
        .. code-block:: csharp
    
           protected RazorEngineHost()
    
    .. dn:constructor:: Microsoft.AspNet.Razor.RazorEngineHost.RazorEngineHost(Microsoft.AspNet.Razor.RazorCodeLanguage)
    
        
    
        Creates a host which uses the specified code language and the HTML markup language
    
        
        
        
        :param codeLanguage: The code language to use
        
        :type codeLanguage: Microsoft.AspNet.Razor.RazorCodeLanguage
    
        
        .. code-block:: csharp
    
           public RazorEngineHost(RazorCodeLanguage codeLanguage)
    
    .. dn:constructor:: Microsoft.AspNet.Razor.RazorEngineHost.RazorEngineHost(Microsoft.AspNet.Razor.RazorCodeLanguage, System.Func<Microsoft.AspNet.Razor.Parser.ParserBase>)
    
        
        
        
        :type codeLanguage: Microsoft.AspNet.Razor.RazorCodeLanguage
        
        
        :type markupParserFactory: System.Func{Microsoft.AspNet.Razor.Parser.ParserBase}
    
        
        .. code-block:: csharp
    
           public RazorEngineHost(RazorCodeLanguage codeLanguage, Func<ParserBase> markupParserFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.RazorEngineHost
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.RazorEngineHost.CreateMarkupParser()
    
        
    
        Constructs the markup parser.  Must return a new instance on EVERY call to ensure thread-safety
    
        
        :rtype: Microsoft.AspNet.Razor.Parser.ParserBase
    
        
        .. code-block:: csharp
    
           public virtual ParserBase CreateMarkupParser()
    
    .. dn:method:: Microsoft.AspNet.Razor.RazorEngineHost.DecorateChunkGenerator(Microsoft.AspNet.Razor.Chunks.Generators.RazorChunkGenerator)
    
        
    
        Gets an instance of the chunk generator and is provided an opportunity to decorate or replace it
    
        
        
        
        :param incomingChunkGenerator: The chunk generator
        
        :type incomingChunkGenerator: Microsoft.AspNet.Razor.Chunks.Generators.RazorChunkGenerator
        :rtype: Microsoft.AspNet.Razor.Chunks.Generators.RazorChunkGenerator
        :return: Either the same chunk generator, after modifications, or a different chunk generator
    
        
        .. code-block:: csharp
    
           public virtual RazorChunkGenerator DecorateChunkGenerator(RazorChunkGenerator incomingChunkGenerator)
    
    .. dn:method:: Microsoft.AspNet.Razor.RazorEngineHost.DecorateCodeGenerator(Microsoft.AspNet.Razor.CodeGenerators.CodeGenerator, Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext)
    
        
    
        Gets an instance of the code generator and is provided an opportunity to decorate or replace it
    
        
        
        
        :param incomingBuilder: The code generator
        
        :type incomingBuilder: Microsoft.AspNet.Razor.CodeGenerators.CodeGenerator
        
        
        :type context: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext
        :rtype: Microsoft.AspNet.Razor.CodeGenerators.CodeGenerator
        :return: Either the same code generator, after modifications, or a different code generator.
    
        
        .. code-block:: csharp
    
           public virtual CodeGenerator DecorateCodeGenerator(CodeGenerator incomingBuilder, CodeGeneratorContext context)
    
    .. dn:method:: Microsoft.AspNet.Razor.RazorEngineHost.DecorateCodeParser(Microsoft.AspNet.Razor.Parser.ParserBase)
    
        
    
        Gets an instance of the code parser and is provided an opportunity to decorate or replace it
    
        
        
        
        :param incomingCodeParser: The code parser
        
        :type incomingCodeParser: Microsoft.AspNet.Razor.Parser.ParserBase
        :rtype: Microsoft.AspNet.Razor.Parser.ParserBase
        :return: Either the same code parser, after modifications, or a different code parser
    
        
        .. code-block:: csharp
    
           public virtual ParserBase DecorateCodeParser(ParserBase incomingCodeParser)
    
    .. dn:method:: Microsoft.AspNet.Razor.RazorEngineHost.DecorateMarkupParser(Microsoft.AspNet.Razor.Parser.ParserBase)
    
        
    
        Gets an instance of the markup parser and is provided an opportunity to decorate or replace it
    
        
        
        
        :param incomingMarkupParser: The markup parser
        
        :type incomingMarkupParser: Microsoft.AspNet.Razor.Parser.ParserBase
        :rtype: Microsoft.AspNet.Razor.Parser.ParserBase
        :return: Either the same markup parser, after modifications, or a different markup parser
    
        
        .. code-block:: csharp
    
           public virtual ParserBase DecorateMarkupParser(ParserBase incomingMarkupParser)
    
    .. dn:method:: Microsoft.AspNet.Razor.RazorEngineHost.DecorateRazorParser(Microsoft.AspNet.Razor.Parser.RazorParser, System.String)
    
        
    
        Provides an opportunity for derived types to modify the instance of :any:`Microsoft.AspNet.Razor.Parser.RazorParser`
        used by the :any:`Microsoft.AspNet.Razor.RazorTemplateEngine` to parse the Razor tree.
    
        
        
        
        :param incomingRazorParser: The
        
        :type incomingRazorParser: Microsoft.AspNet.Razor.Parser.RazorParser
        
        
        :param sourceFileName: The file name of the Razor file being parsed.
        
        :type sourceFileName: System.String
        :rtype: Microsoft.AspNet.Razor.Parser.RazorParser
        :return: Either the same code parser, after modifications, or a different code parser.
    
        
        .. code-block:: csharp
    
           public virtual RazorParser DecorateRazorParser(RazorParser incomingRazorParser, string sourceFileName)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.RazorEngineHost
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.RazorEngineHost.CodeLanguage
    
        
    
        The language of the code within the Razor template.
    
        
        :rtype: Microsoft.AspNet.Razor.RazorCodeLanguage
    
        
        .. code-block:: csharp
    
           public virtual RazorCodeLanguage CodeLanguage { get; protected set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.RazorEngineHost.DefaultBaseClass
    
        
    
        The base-class of the generated class
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public virtual string DefaultBaseClass { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.RazorEngineHost.DefaultClassName
    
        
    
        The name of the generated class
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public virtual string DefaultClassName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.RazorEngineHost.DefaultNamespace
    
        
    
        The namespace which will contain the generated class
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public virtual string DefaultNamespace { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.RazorEngineHost.DesignTimeMode
    
        
    
        Indicates if the parser and chunk generator should run in design-time mode
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual bool DesignTimeMode { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.RazorEngineHost.EnableInstrumentation
    
        
    
        Boolean indicating if instrumentation code should be injected into the output page
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual bool EnableInstrumentation { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.RazorEngineHost.GeneratedClassContext
    
        
    
        Details about the methods and types that should be used to generate code for Razor constructs
    
        
        :rtype: Microsoft.AspNet.Razor.CodeGenerators.GeneratedClassContext
    
        
        .. code-block:: csharp
    
           public virtual GeneratedClassContext GeneratedClassContext { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.RazorEngineHost.InstrumentedSourceFilePath
    
        
    
        Gets or sets the path to use for this document when generating Instrumentation calls
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public virtual string InstrumentedSourceFilePath { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.RazorEngineHost.IsIndentingWithTabs
    
        
    
        Gets or sets whether the design time editor is using tabs or spaces for indentation.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual bool IsIndentingWithTabs { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.RazorEngineHost.NamespaceImports
    
        
    
        A list of namespaces to import in the generated file
    
        
        :rtype: System.Collections.Generic.ISet{System.String}
    
        
        .. code-block:: csharp
    
           public virtual ISet<string> NamespaceImports { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.RazorEngineHost.StaticHelpers
    
        
    
        Boolean indicating if helper methods should be instance methods or static methods
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual bool StaticHelpers { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.RazorEngineHost.TabSize
    
        
    
        Tab size used by the hosting editor, when indenting with tabs.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public virtual int TabSize { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.RazorEngineHost.TagHelperDescriptorResolver
    
        
    
        The :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.ITagHelperDescriptorResolver` used to resolve :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s.
    
        
        :rtype: Microsoft.AspNet.Razor.Compilation.TagHelpers.ITagHelperDescriptorResolver
    
        
        .. code-block:: csharp
    
           public virtual ITagHelperDescriptorResolver TagHelperDescriptorResolver { get; set; }
    

