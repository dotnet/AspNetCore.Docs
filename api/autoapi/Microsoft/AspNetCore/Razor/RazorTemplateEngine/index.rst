

RazorTemplateEngine Class
=========================






Entry-point to the Razor Template Engine


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
* :dn:cls:`Microsoft.AspNetCore.Razor.RazorTemplateEngine`








Syntax
------

.. code-block:: csharp

    public class RazorTemplateEngine








.. dn:class:: Microsoft.AspNetCore.Razor.RazorTemplateEngine
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.RazorTemplateEngine

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.RazorTemplateEngine
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.RazorTemplateEngine.RazorTemplateEngine(Microsoft.AspNetCore.Razor.RazorEngineHost)
    
        
    
        
        Constructs a new RazorTemplateEngine with the specified host
    
        
    
        
        :param host: 
            The host which defines the environment in which the generated template code will live.
        
        :type host: Microsoft.AspNetCore.Razor.RazorEngineHost
    
        
        .. code-block:: csharp
    
            public RazorTemplateEngine(RazorEngineHost host)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.RazorTemplateEngine
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.RazorTemplateEngine.CreateChunkGenerator(System.String, System.String, System.String)
    
        
    
        
        :type className: System.String
    
        
        :type rootNamespace: System.String
    
        
        :type sourceFileName: System.String
        :rtype: Microsoft.AspNetCore.Razor.Chunks.Generators.RazorChunkGenerator
    
        
        .. code-block:: csharp
    
            protected virtual RazorChunkGenerator CreateChunkGenerator(string className, string rootNamespace, string sourceFileName)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.RazorTemplateEngine.CreateCodeGenerator(Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGenerator
    
        
        .. code-block:: csharp
    
            protected virtual CodeGenerator CreateCodeGenerator(CodeGeneratorContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.RazorTemplateEngine.CreateParser(System.String)
    
        
    
        
        :type sourceFileName: System.String
        :rtype: Microsoft.AspNetCore.Razor.Parser.RazorParser
    
        
        .. code-block:: csharp
    
            protected virtual RazorParser CreateParser(string sourceFileName)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.RazorTemplateEngine.GenerateCode(Microsoft.AspNetCore.Razor.Text.ITextBuffer)
    
        
    
        
        :type input: Microsoft.AspNetCore.Razor.Text.ITextBuffer
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratorResults
    
        
        .. code-block:: csharp
    
            public GeneratorResults GenerateCode(ITextBuffer input)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.RazorTemplateEngine.GenerateCode(Microsoft.AspNetCore.Razor.Text.ITextBuffer, System.Nullable<System.Threading.CancellationToken>)
    
        
    
        
        :type input: Microsoft.AspNetCore.Razor.Text.ITextBuffer
    
        
        :type cancelToken: System.Nullable<System.Nullable`1>{System.Threading.CancellationToken<System.Threading.CancellationToken>}
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratorResults
    
        
        .. code-block:: csharp
    
            public GeneratorResults GenerateCode(ITextBuffer input, CancellationToken? cancelToken)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.RazorTemplateEngine.GenerateCode(Microsoft.AspNetCore.Razor.Text.ITextBuffer, System.String, System.String, System.String)
    
        
    
        
        :type input: Microsoft.AspNetCore.Razor.Text.ITextBuffer
    
        
        :type className: System.String
    
        
        :type rootNamespace: System.String
    
        
        :type sourceFileName: System.String
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratorResults
    
        
        .. code-block:: csharp
    
            public GeneratorResults GenerateCode(ITextBuffer input, string className, string rootNamespace, string sourceFileName)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.RazorTemplateEngine.GenerateCode(Microsoft.AspNetCore.Razor.Text.ITextBuffer, System.String, System.String, System.String, System.Nullable<System.Threading.CancellationToken>)
    
        
    
        
        Parses the template specified by the TextBuffer, generates code for it, and returns the constructed code.
    
        
    
        
        :param input: The input text to parse.
        
        :type input: Microsoft.AspNetCore.Razor.Text.ITextBuffer
    
        
        :param className: 
            The name of the generated class, overriding whatever is specified in the Host.  The default value (defined
            in the Host) can be used by providing null for this argument.
        
        :type className: System.String
    
        
        :param rootNamespace: The namespace in which the generated class will reside, overriding whatever is
            specified in the Host.  The default value (defined in the Host) can be used by providing null for this
            argument.
        
        :type rootNamespace: System.String
    
        
        :param sourceFileName: 
            The file name to use in line pragmas, usually the original Razor file, overriding whatever is specified in
            the Host.  The default value (defined in the Host) can be used by providing null for this argument.
        
        :type sourceFileName: System.String
    
        
        :param cancelToken: A token used to cancel the parser.
        
        :type cancelToken: System.Nullable<System.Nullable`1>{System.Threading.CancellationToken<System.Threading.CancellationToken>}
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratorResults
        :return: The resulting parse tree AND generated code.
    
        
        .. code-block:: csharp
    
            public GeneratorResults GenerateCode(ITextBuffer input, string className, string rootNamespace, string sourceFileName, CancellationToken? cancelToken)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.RazorTemplateEngine.GenerateCode(System.IO.Stream, System.String, System.String, System.String)
    
        
    
        
        Parses the contents specified by the <em>inputStream</em> and returns the generated code.
    
        
    
        
        :param inputStream: A :any:`System.IO.Stream` that represents the contents to be parsed.
        
        :type inputStream: System.IO.Stream
    
        
        :param className: The name of the generated class. When <code>null</code>, defaults to 
            :dn:prop:`Microsoft.AspNetCore.Razor.RazorEngineHost.DefaultClassName` (<code>Host.DefaultClassName</code>).
        
        :type className: System.String
    
        
        :param rootNamespace: The namespace in which the generated class will reside. When <code>null</code>,
            defaults to :dn:prop:`Microsoft.AspNetCore.Razor.RazorEngineHost.DefaultNamespace` (<code>Host.DefaultNamespace</code>).
        
        :type rootNamespace: System.String
    
        
        :param sourceFileName: 
            The file name to use in line pragmas, usually the original Razor file.
        
        :type sourceFileName: System.String
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratorResults
        :return: A :any:`Microsoft.AspNetCore.Razor.CodeGenerators.GeneratorResults` that represents the results of parsing the content.
    
        
        .. code-block:: csharp
    
            public GeneratorResults GenerateCode(Stream inputStream, string className, string rootNamespace, string sourceFileName)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.RazorTemplateEngine.GenerateCode(System.IO.TextReader)
    
        
    
        
        :type input: System.IO.TextReader
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratorResults
    
        
        .. code-block:: csharp
    
            public GeneratorResults GenerateCode(TextReader input)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.RazorTemplateEngine.GenerateCode(System.IO.TextReader, System.Nullable<System.Threading.CancellationToken>)
    
        
    
        
        :type input: System.IO.TextReader
    
        
        :type cancelToken: System.Nullable<System.Nullable`1>{System.Threading.CancellationToken<System.Threading.CancellationToken>}
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratorResults
    
        
        .. code-block:: csharp
    
            public GeneratorResults GenerateCode(TextReader input, CancellationToken? cancelToken)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.RazorTemplateEngine.GenerateCode(System.IO.TextReader, System.String, System.String, System.String)
    
        
    
        
        :type input: System.IO.TextReader
    
        
        :type className: System.String
    
        
        :type rootNamespace: System.String
    
        
        :type sourceFileName: System.String
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratorResults
    
        
        .. code-block:: csharp
    
            public GeneratorResults GenerateCode(TextReader input, string className, string rootNamespace, string sourceFileName)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.RazorTemplateEngine.GenerateCode(System.IO.TextReader, System.String, System.String, System.String, System.Nullable<System.Threading.CancellationToken>)
    
        
    
        
        :type input: System.IO.TextReader
    
        
        :type className: System.String
    
        
        :type rootNamespace: System.String
    
        
        :type sourceFileName: System.String
    
        
        :type cancelToken: System.Nullable<System.Nullable`1>{System.Threading.CancellationToken<System.Threading.CancellationToken>}
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratorResults
    
        
        .. code-block:: csharp
    
            public GeneratorResults GenerateCode(TextReader input, string className, string rootNamespace, string sourceFileName, CancellationToken? cancelToken)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.RazorTemplateEngine.GenerateCodeCore(Microsoft.AspNetCore.Razor.Text.ITextDocument, System.String, System.String, System.String, System.String, System.Nullable<System.Threading.CancellationToken>)
    
        
    
        
        :type input: Microsoft.AspNetCore.Razor.Text.ITextDocument
    
        
        :type className: System.String
    
        
        :type rootNamespace: System.String
    
        
        :type sourceFileName: System.String
    
        
        :type checksum: System.String
    
        
        :type cancelToken: System.Nullable<System.Nullable`1>{System.Threading.CancellationToken<System.Threading.CancellationToken>}
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratorResults
    
        
        .. code-block:: csharp
    
            protected virtual GeneratorResults GenerateCodeCore(ITextDocument input, string className, string rootNamespace, string sourceFileName, string checksum, CancellationToken? cancelToken)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.RazorTemplateEngine.ParseTemplate(Microsoft.AspNetCore.Razor.Text.ITextBuffer)
    
        
    
        
        :type input: Microsoft.AspNetCore.Razor.Text.ITextBuffer
        :rtype: Microsoft.AspNetCore.Razor.ParserResults
    
        
        .. code-block:: csharp
    
            public ParserResults ParseTemplate(ITextBuffer input)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.RazorTemplateEngine.ParseTemplate(Microsoft.AspNetCore.Razor.Text.ITextBuffer, System.Nullable<System.Threading.CancellationToken>)
    
        
    
        
        Parses the template specified by the TextBuffer and returns it's result
    
        
    
        
        :param input: The input text to parse.
        
        :type input: Microsoft.AspNetCore.Razor.Text.ITextBuffer
    
        
        :param cancelToken: A token used to cancel the parser.
        
        :type cancelToken: System.Nullable<System.Nullable`1>{System.Threading.CancellationToken<System.Threading.CancellationToken>}
        :rtype: Microsoft.AspNetCore.Razor.ParserResults
        :return: The resulting parse tree.
    
        
        .. code-block:: csharp
    
            public ParserResults ParseTemplate(ITextBuffer input, CancellationToken? cancelToken)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.RazorTemplateEngine.ParseTemplate(System.IO.TextReader, System.Nullable<System.Threading.CancellationToken>)
    
        
    
        
        :type input: System.IO.TextReader
    
        
        :type cancelToken: System.Nullable<System.Nullable`1>{System.Threading.CancellationToken<System.Threading.CancellationToken>}
        :rtype: Microsoft.AspNetCore.Razor.ParserResults
    
        
        .. code-block:: csharp
    
            public ParserResults ParseTemplate(TextReader input, CancellationToken? cancelToken)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.RazorTemplateEngine.ParseTemplate(System.IO.TextReader, System.String)
    
        
    
        
        :type input: System.IO.TextReader
    
        
        :type sourceFileName: System.String
        :rtype: Microsoft.AspNetCore.Razor.ParserResults
    
        
        .. code-block:: csharp
    
            public ParserResults ParseTemplate(TextReader input, string sourceFileName)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.RazorTemplateEngine.ParseTemplateCore(Microsoft.AspNetCore.Razor.Text.ITextDocument, System.String, System.Nullable<System.Threading.CancellationToken>)
    
        
    
        
        :type input: Microsoft.AspNetCore.Razor.Text.ITextDocument
    
        
        :type sourceFileName: System.String
    
        
        :type cancelToken: System.Nullable<System.Nullable`1>{System.Threading.CancellationToken<System.Threading.CancellationToken>}
        :rtype: Microsoft.AspNetCore.Razor.ParserResults
    
        
        .. code-block:: csharp
    
            protected virtual ParserResults ParseTemplateCore(ITextDocument input, string sourceFileName, CancellationToken? cancelToken)
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Razor.RazorTemplateEngine
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Razor.RazorTemplateEngine.DefaultClassName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static readonly string DefaultClassName
    
    .. dn:field:: Microsoft.AspNetCore.Razor.RazorTemplateEngine.DefaultNamespace
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static readonly string DefaultNamespace
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.RazorTemplateEngine
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.RazorTemplateEngine.Host
    
        
    
        
        The RazorEngineHost which defines the environment in which the generated template code will live
    
        
        :rtype: Microsoft.AspNetCore.Razor.RazorEngineHost
    
        
        .. code-block:: csharp
    
            public RazorEngineHost Host { get; }
    

