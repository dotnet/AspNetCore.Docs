

RazorCodeLanguage Class
=======================



.. contents:: 
   :local:



Summary
-------

Represents a code language in Razor.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.RazorCodeLanguage`








Syntax
------

.. code-block:: csharp

   public abstract class RazorCodeLanguage





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/RazorCodeLanguage.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.RazorCodeLanguage

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.RazorCodeLanguage
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.RazorCodeLanguage.CreateChunkGenerator(System.String, System.String, System.String, Microsoft.AspNet.Razor.RazorEngineHost)
    
        
    
        Constructs the chunk generator.  Must return a new instance on EVERY call to ensure thread-safety
    
        
        
        
        :type className: System.String
        
        
        :type rootNamespaceName: System.String
        
        
        :type sourceFileName: System.String
        
        
        :type host: Microsoft.AspNet.Razor.RazorEngineHost
        :rtype: Microsoft.AspNet.Razor.Chunks.Generators.RazorChunkGenerator
    
        
        .. code-block:: csharp
    
           public abstract RazorChunkGenerator CreateChunkGenerator(string className, string rootNamespaceName, string sourceFileName, RazorEngineHost host)
    
    .. dn:method:: Microsoft.AspNet.Razor.RazorCodeLanguage.CreateCodeGenerator(Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext)
    
        
        
        
        :type chunkGeneratorContext: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext
        :rtype: Microsoft.AspNet.Razor.CodeGenerators.CodeGenerator
    
        
        .. code-block:: csharp
    
           public abstract CodeGenerator CreateCodeGenerator(CodeGeneratorContext chunkGeneratorContext)
    
    .. dn:method:: Microsoft.AspNet.Razor.RazorCodeLanguage.CreateCodeParser()
    
        
    
        Constructs the code parser.  Must return a new instance on EVERY call to ensure thread-safety
    
        
        :rtype: Microsoft.AspNet.Razor.Parser.ParserBase
    
        
        .. code-block:: csharp
    
           public abstract ParserBase CreateCodeParser()
    
    .. dn:method:: Microsoft.AspNet.Razor.RazorCodeLanguage.GetLanguageByExtension(System.String)
    
        
    
        Gets the RazorCodeLanguage registered for the specified file extension
    
        
        
        
        :param fileExtension: The extension, with or without a "."
        
        :type fileExtension: System.String
        :rtype: Microsoft.AspNet.Razor.RazorCodeLanguage
        :return: The language registered for that extension
    
        
        .. code-block:: csharp
    
           public static RazorCodeLanguage GetLanguageByExtension(string fileExtension)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.RazorCodeLanguage
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.RazorCodeLanguage.LanguageName
    
        
    
        The name of the language (for use in System.Web.Compilation.BuildProvider.GetDefaultCompilerTypeForLanguage)
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public abstract string LanguageName { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.RazorCodeLanguage.Languages
    
        
    
        Gets the list of registered languages mapped to file extensions (without a ".")
    
        
        :rtype: System.Collections.Generic.IDictionary{System.String,Microsoft.AspNet.Razor.RazorCodeLanguage}
    
        
        .. code-block:: csharp
    
           public static IDictionary<string, RazorCodeLanguage> Languages { get; }
    

