

RazorCodeLanguage Class
=======================






Represents a code language in Razor.


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
* :dn:cls:`Microsoft.AspNetCore.Razor.RazorCodeLanguage`








Syntax
------

.. code-block:: csharp

    public abstract class RazorCodeLanguage








.. dn:class:: Microsoft.AspNetCore.Razor.RazorCodeLanguage
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.RazorCodeLanguage

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.RazorCodeLanguage
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.RazorCodeLanguage.LanguageName
    
        
    
        
        The name of the language (for use in System.Web.Compilation.BuildProvider.GetDefaultCompilerTypeForLanguage)
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public abstract string LanguageName
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.RazorCodeLanguage.Languages
    
        
    
        
        Gets the list of registered languages mapped to file extensions (without a ".")
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, Microsoft.AspNetCore.Razor.RazorCodeLanguage<Microsoft.AspNetCore.Razor.RazorCodeLanguage>}
    
        
        .. code-block:: csharp
    
            public static IDictionary<string, RazorCodeLanguage> Languages
            {
                get;
            }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.RazorCodeLanguage
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.RazorCodeLanguage.CreateChunkGenerator(System.String, System.String, System.String, Microsoft.AspNetCore.Razor.RazorEngineHost)
    
        
    
        
        Constructs the chunk generator.  Must return a new instance on EVERY call to ensure thread-safety
    
        
    
        
        :type className: System.String
    
        
        :type rootNamespaceName: System.String
    
        
        :type sourceFileName: System.String
    
        
        :type host: Microsoft.AspNetCore.Razor.RazorEngineHost
        :rtype: Microsoft.AspNetCore.Razor.Chunks.Generators.RazorChunkGenerator
    
        
        .. code-block:: csharp
    
            public abstract RazorChunkGenerator CreateChunkGenerator(string className, string rootNamespaceName, string sourceFileName, RazorEngineHost host)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.RazorCodeLanguage.CreateCodeGenerator(Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext)
    
        
    
        
        :type chunkGeneratorContext: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGenerator
    
        
        .. code-block:: csharp
    
            public abstract CodeGenerator CreateCodeGenerator(CodeGeneratorContext chunkGeneratorContext)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.RazorCodeLanguage.CreateCodeParser()
    
        
    
        
        Constructs the code parser.  Must return a new instance on EVERY call to ensure thread-safety
    
        
        :rtype: Microsoft.AspNetCore.Razor.Parser.ParserBase
    
        
        .. code-block:: csharp
    
            public abstract ParserBase CreateCodeParser()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.RazorCodeLanguage.GetLanguageByExtension(System.String)
    
        
    
        
        Gets the RazorCodeLanguage registered for the specified file extension
    
        
    
        
        :param fileExtension: The extension, with or without a "."
        
        :type fileExtension: System.String
        :rtype: Microsoft.AspNetCore.Razor.RazorCodeLanguage
        :return: The language registered for that extension
    
        
        .. code-block:: csharp
    
            public static RazorCodeLanguage GetLanguageByExtension(string fileExtension)
    

