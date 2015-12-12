

SyntaxTreeGenerator Class
=========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.Compilation.SyntaxTreeGenerator`








Syntax
------

.. code-block:: csharp

   public class SyntaxTreeGenerator





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Razor/Compilation/SyntaxTreeGenerator.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.Compilation.SyntaxTreeGenerator

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Compilation.SyntaxTreeGenerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.Compilation.SyntaxTreeGenerator.Generate(System.String, System.String, Microsoft.Dnx.Compilation.CSharp.CompilationSettings)
    
        
        
        
        :type text: System.String
        
        
        :type path: System.String
        
        
        :type compilationSettings: Microsoft.Dnx.Compilation.CSharp.CompilationSettings
        :rtype: Microsoft.CodeAnalysis.SyntaxTree
    
        
        .. code-block:: csharp
    
           public static SyntaxTree Generate(string text, string path, CompilationSettings compilationSettings)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.Compilation.SyntaxTreeGenerator.GetParseOptions(Microsoft.Dnx.Compilation.CSharp.CompilationSettings)
    
        
        
        
        :type compilationSettings: Microsoft.Dnx.Compilation.CSharp.CompilationSettings
        :rtype: Microsoft.CodeAnalysis.CSharp.CSharpParseOptions
    
        
        .. code-block:: csharp
    
           public static CSharpParseOptions GetParseOptions(CompilationSettings compilationSettings)
    

