

CSharpRazorCodeLanguage Class
=============================






Defines the C# Code Language for Razor


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
* :dn:cls:`Microsoft.AspNetCore.Razor.CSharpRazorCodeLanguage`








Syntax
------

.. code-block:: csharp

    public class CSharpRazorCodeLanguage : RazorCodeLanguage








.. dn:class:: Microsoft.AspNetCore.Razor.CSharpRazorCodeLanguage
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.CSharpRazorCodeLanguage

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.CSharpRazorCodeLanguage
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.CSharpRazorCodeLanguage.LanguageName
    
        
    
        
        Returns the name of the language: "csharp"
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string LanguageName
            {
                get;
            }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.CSharpRazorCodeLanguage
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.CSharpRazorCodeLanguage.CreateChunkGenerator(System.String, System.String, System.String, Microsoft.AspNetCore.Razor.RazorEngineHost)
    
        
    
        
        Constructs a new instance of the chunk generator for this language with the specified settings
    
        
    
        
        :type className: System.String
    
        
        :type rootNamespaceName: System.String
    
        
        :type sourceFileName: System.String
    
        
        :type host: Microsoft.AspNetCore.Razor.RazorEngineHost
        :rtype: Microsoft.AspNetCore.Razor.Chunks.Generators.RazorChunkGenerator
    
        
        .. code-block:: csharp
    
            public override RazorChunkGenerator CreateChunkGenerator(string className, string rootNamespaceName, string sourceFileName, RazorEngineHost host)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CSharpRazorCodeLanguage.CreateCodeGenerator(Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext)
    
        
    
        
        :type chunkGeneratorContext: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGenerator
    
        
        .. code-block:: csharp
    
            public override CodeGenerator CreateCodeGenerator(CodeGeneratorContext chunkGeneratorContext)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CSharpRazorCodeLanguage.CreateCodeParser()
    
        
    
        
        Constructs a new instance of the code parser for this language
    
        
        :rtype: Microsoft.AspNetCore.Razor.Parser.ParserBase
    
        
        .. code-block:: csharp
    
            public override ParserBase CreateCodeParser()
    

