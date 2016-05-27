

CSharpPaddingBuilder Class
==========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.CodeGenerators`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.CodeGenerators.CSharpPaddingBuilder`








Syntax
------

.. code-block:: csharp

    public class CSharpPaddingBuilder








.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpPaddingBuilder
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpPaddingBuilder

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpPaddingBuilder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpPaddingBuilder.CSharpPaddingBuilder(Microsoft.AspNetCore.Razor.RazorEngineHost)
    
        
    
        
        :type host: Microsoft.AspNetCore.Razor.RazorEngineHost
    
        
        .. code-block:: csharp
    
            public CSharpPaddingBuilder(RazorEngineHost host)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpPaddingBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpPaddingBuilder.BuildExpressionPadding(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span)
    
        
    
        
        :type target: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string BuildExpressionPadding(Span target)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpPaddingBuilder.BuildExpressionPadding(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span, System.Int32)
    
        
    
        
        :type target: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span
    
        
        :type generatedStart: System.Int32
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string BuildExpressionPadding(Span target, int generatedStart)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpPaddingBuilder.BuildStatementPadding(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span)
    
        
    
        
        :type target: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string BuildStatementPadding(Span target)
    

