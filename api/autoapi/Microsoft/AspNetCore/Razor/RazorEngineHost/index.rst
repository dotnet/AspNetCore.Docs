

RazorEngineHost Class
=====================






Defines the environment in which a Razor template will live


Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.RazorEngineHost`








Syntax
------

.. code-block:: csharp

    public class RazorEngineHost








.. dn:class:: Microsoft.AspNetCore.Razor.RazorEngineHost
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.RazorEngineHost

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.RazorEngineHost
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.RazorEngineHost.RazorEngineHost()
    
        
    
        
        .. code-block:: csharp
    
            protected RazorEngineHost()
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.RazorEngineHost.RazorEngineHost(Microsoft.AspNetCore.Razor.RazorCodeLanguage)
    
        
    
        
        Creates a host which uses the specified code language and the HTML markup language
    
        
    
        
        :param codeLanguage: The code language to use
        
        :type codeLanguage: Microsoft.AspNetCore.Razor.RazorCodeLanguage
    
        
        .. code-block:: csharp
    
            public RazorEngineHost(RazorCodeLanguage codeLanguage)
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.RazorEngineHost.RazorEngineHost(Microsoft.AspNetCore.Razor.RazorCodeLanguage, System.Func<Microsoft.AspNetCore.Razor.Parser.ParserBase>)
    
        
    
        
        :type codeLanguage: Microsoft.AspNetCore.Razor.RazorCodeLanguage
    
        
        :type markupParserFactory: System.Func<System.Func`1>{Microsoft.AspNetCore.Razor.Parser.ParserBase<Microsoft.AspNetCore.Razor.Parser.ParserBase>}
    
        
        .. code-block:: csharp
    
            public RazorEngineHost(RazorCodeLanguage codeLanguage, Func<ParserBase> markupParserFactory)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.RazorEngineHost
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.RazorEngineHost.CodeLanguage
    
        
    
        
        The language of the code within the Razor template.
    
        
        :rtype: Microsoft.AspNetCore.Razor.RazorCodeLanguage
    
        
        .. code-block:: csharp
    
            public virtual RazorCodeLanguage CodeLanguage { get; protected set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.RazorEngineHost.DefaultBaseClass
    
        
    
        
        The base-class of the generated class
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string DefaultBaseClass { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.RazorEngineHost.DefaultClassName
    
        
    
        
        The name of the generated class
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string DefaultClassName { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.RazorEngineHost.DefaultNamespace
    
        
    
        
        The namespace which will contain the generated class
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string DefaultNamespace { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.RazorEngineHost.DesignTimeMode
    
        
    
        
        Indicates if the parser and chunk generator should run in design-time mode
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public virtual bool DesignTimeMode { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.RazorEngineHost.EnableInstrumentation
    
        
    
        
        Boolean indicating if instrumentation code should be injected into the output page
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public virtual bool EnableInstrumentation { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.RazorEngineHost.GeneratedClassContext
    
        
    
        
        Details about the methods and types that should be used to generate code for Razor constructs
    
        
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedClassContext
    
        
        .. code-block:: csharp
    
            public virtual GeneratedClassContext GeneratedClassContext { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.RazorEngineHost.InstrumentedSourceFilePath
    
        
    
        
        Gets or sets the path to use for this document when generating Instrumentation calls
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string InstrumentedSourceFilePath { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.RazorEngineHost.IsIndentingWithTabs
    
        
    
        
        Gets or sets whether the design time editor is using tabs or spaces for indentation.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public virtual bool IsIndentingWithTabs { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.RazorEngineHost.NamespaceImports
    
        
    
        
        A list of namespaces to import in the generated file
    
        
        :rtype: System.Collections.Generic.ISet<System.Collections.Generic.ISet`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public virtual ISet<string> NamespaceImports { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.RazorEngineHost.StaticHelpers
    
        
    
        
        Boolean indicating if helper methods should be instance methods or static methods
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public virtual bool StaticHelpers { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.RazorEngineHost.TabSize
    
        
    
        
        Tab size used by the hosting editor, when indenting with tabs.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public virtual int TabSize { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.RazorEngineHost.TagHelperDescriptorResolver
    
        
    
        
        The :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.ITagHelperDescriptorResolver` used to resolve :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s.
    
        
        :rtype: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.ITagHelperDescriptorResolver
    
        
        .. code-block:: csharp
    
            public virtual ITagHelperDescriptorResolver TagHelperDescriptorResolver { get; set; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.RazorEngineHost
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.RazorEngineHost.CreateMarkupParser()
    
        
    
        
        Constructs the markup parser.  Must return a new instance on EVERY call to ensure thread-safety
    
        
        :rtype: Microsoft.AspNetCore.Razor.Parser.ParserBase
    
        
        .. code-block:: csharp
    
            public virtual ParserBase CreateMarkupParser()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.RazorEngineHost.DecorateChunkGenerator(Microsoft.AspNetCore.Razor.Chunks.Generators.RazorChunkGenerator)
    
        
    
        
        Gets an instance of the chunk generator and is provided an opportunity to decorate or replace it
    
        
    
        
        :param incomingChunkGenerator: The chunk generator
        
        :type incomingChunkGenerator: Microsoft.AspNetCore.Razor.Chunks.Generators.RazorChunkGenerator
        :rtype: Microsoft.AspNetCore.Razor.Chunks.Generators.RazorChunkGenerator
        :return: Either the same chunk generator, after modifications, or a different chunk generator
    
        
        .. code-block:: csharp
    
            public virtual RazorChunkGenerator DecorateChunkGenerator(RazorChunkGenerator incomingChunkGenerator)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.RazorEngineHost.DecorateCodeGenerator(Microsoft.AspNetCore.Razor.CodeGenerators.CodeGenerator, Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext)
    
        
    
        
        Gets an instance of the code generator and is provided an opportunity to decorate or replace it
    
        
    
        
        :param incomingBuilder: The :any:`Microsoft.AspNetCore.Razor.CodeGenerators.CodeGenerator`\.
        
        :type incomingBuilder: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGenerator
    
        
        :param context: The :any:`Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext`\.
        
        :type context: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGenerator
        :return: Either the same code generator, after modifications, or a different code generator.
    
        
        .. code-block:: csharp
    
            public virtual CodeGenerator DecorateCodeGenerator(CodeGenerator incomingBuilder, CodeGeneratorContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.RazorEngineHost.DecorateCodeParser(Microsoft.AspNetCore.Razor.Parser.ParserBase)
    
        
    
        
        Gets an instance of the code parser and is provided an opportunity to decorate or replace it
    
        
    
        
        :param incomingCodeParser: The code parser
        
        :type incomingCodeParser: Microsoft.AspNetCore.Razor.Parser.ParserBase
        :rtype: Microsoft.AspNetCore.Razor.Parser.ParserBase
        :return: Either the same code parser, after modifications, or a different code parser
    
        
        .. code-block:: csharp
    
            public virtual ParserBase DecorateCodeParser(ParserBase incomingCodeParser)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.RazorEngineHost.DecorateMarkupParser(Microsoft.AspNetCore.Razor.Parser.ParserBase)
    
        
    
        
        Gets an instance of the markup parser and is provided an opportunity to decorate or replace it
    
        
    
        
        :param incomingMarkupParser: The markup parser
        
        :type incomingMarkupParser: Microsoft.AspNetCore.Razor.Parser.ParserBase
        :rtype: Microsoft.AspNetCore.Razor.Parser.ParserBase
        :return: Either the same markup parser, after modifications, or a different markup parser
    
        
        .. code-block:: csharp
    
            public virtual ParserBase DecorateMarkupParser(ParserBase incomingMarkupParser)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.RazorEngineHost.DecorateRazorParser(Microsoft.AspNetCore.Razor.Parser.RazorParser, System.String)
    
        
    
        
        Provides an opportunity for derived types to modify the instance of :any:`Microsoft.AspNetCore.Razor.Parser.RazorParser`
        used by the :any:`Microsoft.AspNetCore.Razor.RazorTemplateEngine` to parse the Razor tree.
    
        
    
        
        :param incomingRazorParser: The :any:`Microsoft.AspNetCore.Razor.Parser.RazorParser`
        
        :type incomingRazorParser: Microsoft.AspNetCore.Razor.Parser.RazorParser
    
        
        :param sourceFileName: The file name of the Razor file being parsed.
        
        :type sourceFileName: System.String
        :rtype: Microsoft.AspNetCore.Razor.Parser.RazorParser
        :return: Either the same code parser, after modifications, or a different code parser.
    
        
        .. code-block:: csharp
    
            public virtual RazorParser DecorateRazorParser(RazorParser incomingRazorParser, string sourceFileName)
    

