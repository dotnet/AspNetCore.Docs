

CSharpRazorCodeLanguage Class
=============================



.. contents:: 
   :local:



Summary
-------

Defines the C# Code Language for Razor





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.RazorCodeLanguage`
* :dn:cls:`Microsoft.AspNet.Razor.CSharpRazorCodeLanguage`








Syntax
------

.. code-block:: csharp

   public class CSharpRazorCodeLanguage : RazorCodeLanguage





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/CSharpRazorCodeLanguage.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.CSharpRazorCodeLanguage

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.CSharpRazorCodeLanguage
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.CSharpRazorCodeLanguage.CreateChunkGenerator(System.String, System.String, System.String, Microsoft.AspNet.Razor.RazorEngineHost)
    
        
    
        Constructs a new instance of the chunk generator for this language with the specified settings
    
        
        
        
        :type className: System.String
        
        
        :type rootNamespaceName: System.String
        
        
        :type sourceFileName: System.String
        
        
        :type host: Microsoft.AspNet.Razor.RazorEngineHost
        :rtype: Microsoft.AspNet.Razor.Chunks.Generators.RazorChunkGenerator
    
        
        .. code-block:: csharp
    
           public override RazorChunkGenerator CreateChunkGenerator(string className, string rootNamespaceName, string sourceFileName, RazorEngineHost host)
    
    .. dn:method:: Microsoft.AspNet.Razor.CSharpRazorCodeLanguage.CreateCodeGenerator(Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext)
    
        
        
        
        :type context: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext
        :rtype: Microsoft.AspNet.Razor.CodeGenerators.CodeGenerator
    
        
        .. code-block:: csharp
    
           public override CodeGenerator CreateCodeGenerator(CodeGeneratorContext context)
    
    .. dn:method:: Microsoft.AspNet.Razor.CSharpRazorCodeLanguage.CreateCodeParser()
    
        
    
        Constructs a new instance of the code parser for this language
    
        
        :rtype: Microsoft.AspNet.Razor.Parser.ParserBase
    
        
        .. code-block:: csharp
    
           public override ParserBase CreateCodeParser()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.CSharpRazorCodeLanguage
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.CSharpRazorCodeLanguage.LanguageName
    
        
    
        Returns the name of the language: "csharp"
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string LanguageName { get; }
    

