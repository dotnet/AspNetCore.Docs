

ExpressionRewriter Class
========================



.. contents:: 
   :local:



Summary
-------

An expression rewriter which can hoist a simple expression lambda into a private field.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor{Microsoft.CodeAnalysis.SyntaxNode}`
* :dn:cls:`Microsoft.CodeAnalysis.CSharp.CSharpSyntaxRewriter`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.Compilation.ExpressionRewriter`








Syntax
------

.. code-block:: csharp

   public class ExpressionRewriter : CSharpSyntaxRewriter





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Razor/Compilation/ExpressionRewriter.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.Compilation.ExpressionRewriter

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Compilation.ExpressionRewriter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.Compilation.ExpressionRewriter.ExpressionRewriter(Microsoft.CodeAnalysis.SemanticModel)
    
        
        
        
        :type semanticModel: Microsoft.CodeAnalysis.SemanticModel
    
        
        .. code-block:: csharp
    
           public ExpressionRewriter(SemanticModel semanticModel)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Compilation.ExpressionRewriter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.Compilation.ExpressionRewriter.VisitClassDeclaration(Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax)
    
        
        
        
        :type node: Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax
        :rtype: Microsoft.CodeAnalysis.SyntaxNode
    
        
        .. code-block:: csharp
    
           public override SyntaxNode VisitClassDeclaration(ClassDeclarationSyntax node)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.Compilation.ExpressionRewriter.VisitSimpleLambdaExpression(Microsoft.CodeAnalysis.CSharp.Syntax.SimpleLambdaExpressionSyntax)
    
        
        
        
        :type node: Microsoft.CodeAnalysis.CSharp.Syntax.SimpleLambdaExpressionSyntax
        :rtype: Microsoft.CodeAnalysis.SyntaxNode
    
        
        .. code-block:: csharp
    
           public override SyntaxNode VisitSimpleLambdaExpression(SimpleLambdaExpressionSyntax node)
    

