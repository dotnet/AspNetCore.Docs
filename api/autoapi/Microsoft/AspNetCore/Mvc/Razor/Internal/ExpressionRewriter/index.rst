

ExpressionRewriter Class
========================






An expression rewriter which can hoist a simple expression lambda into a private field.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Razor.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor{Microsoft.CodeAnalysis.SyntaxNode}`
* :dn:cls:`Microsoft.CodeAnalysis.CSharp.CSharpSyntaxRewriter`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.Internal.ExpressionRewriter`








Syntax
------

.. code-block:: csharp

    public class ExpressionRewriter : CSharpSyntaxRewriter








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Internal.ExpressionRewriter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Internal.ExpressionRewriter

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Internal.ExpressionRewriter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.Internal.ExpressionRewriter.ExpressionRewriter(Microsoft.CodeAnalysis.SemanticModel)
    
        
    
        
        :type semanticModel: Microsoft.CodeAnalysis.SemanticModel
    
        
        .. code-block:: csharp
    
            public ExpressionRewriter(SemanticModel semanticModel)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Internal.ExpressionRewriter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.Internal.ExpressionRewriter.VisitClassDeclaration(Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax)
    
        
    
        
        :type node: Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax
        :rtype: Microsoft.CodeAnalysis.SyntaxNode
    
        
        .. code-block:: csharp
    
            public override SyntaxNode VisitClassDeclaration(ClassDeclarationSyntax node)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.Internal.ExpressionRewriter.VisitSimpleLambdaExpression(Microsoft.CodeAnalysis.CSharp.Syntax.SimpleLambdaExpressionSyntax)
    
        
    
        
        :type node: Microsoft.CodeAnalysis.CSharp.Syntax.SimpleLambdaExpressionSyntax
        :rtype: Microsoft.CodeAnalysis.SyntaxNode
    
        
        .. code-block:: csharp
    
            public override SyntaxNode VisitSimpleLambdaExpression(SimpleLambdaExpressionSyntax node)
    

