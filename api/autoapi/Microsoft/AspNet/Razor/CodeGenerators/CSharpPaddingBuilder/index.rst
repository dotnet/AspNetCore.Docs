

CSharpPaddingBuilder Class
==========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.CSharpPaddingBuilder`








Syntax
------

.. code-block:: csharp

   public class CSharpPaddingBuilder





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/CodeGenerators/CSharpPaddingBuilder.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.CSharpPaddingBuilder

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.CSharpPaddingBuilder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.CodeGenerators.CSharpPaddingBuilder.CSharpPaddingBuilder(Microsoft.AspNet.Razor.RazorEngineHost)
    
        
        
        
        :type host: Microsoft.AspNet.Razor.RazorEngineHost
    
        
        .. code-block:: csharp
    
           public CSharpPaddingBuilder(RazorEngineHost host)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.CSharpPaddingBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.CSharpPaddingBuilder.BuildExpressionPadding(Microsoft.AspNet.Razor.Parser.SyntaxTree.Span)
    
        
        
        
        :type target: Microsoft.AspNet.Razor.Parser.SyntaxTree.Span
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string BuildExpressionPadding(Span target)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.CSharpPaddingBuilder.BuildExpressionPadding(Microsoft.AspNet.Razor.Parser.SyntaxTree.Span, System.Int32)
    
        
        
        
        :type target: Microsoft.AspNet.Razor.Parser.SyntaxTree.Span
        
        
        :type generatedStart: System.Int32
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string BuildExpressionPadding(Span target, int generatedStart)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.CSharpPaddingBuilder.BuildStatementPadding(Microsoft.AspNet.Razor.Parser.SyntaxTree.Span)
    
        
        
        
        :type target: Microsoft.AspNet.Razor.Parser.SyntaxTree.Span
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string BuildStatementPadding(Span target)
    

