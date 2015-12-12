

RewritingContext Class
======================



.. contents:: 
   :local:



Summary
-------

Informational class for rewriting a syntax tree.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Parser.RewritingContext`








Syntax
------

.. code-block:: csharp

   public class RewritingContext





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/Parser/RewritingContext.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Parser.RewritingContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Parser.RewritingContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Parser.RewritingContext.RewritingContext(Microsoft.AspNet.Razor.Parser.SyntaxTree.Block, Microsoft.AspNet.Razor.ErrorSink)
    
        
    
        Instantiates a new :any:`Microsoft.AspNet.Razor.Parser.RewritingContext`\.
    
        
        
        
        :type syntaxTree: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block
        
        
        :type errorSink: Microsoft.AspNet.Razor.ErrorSink
    
        
        .. code-block:: csharp
    
           public RewritingContext(Block syntaxTree, ErrorSink errorSink)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Parser.RewritingContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.RewritingContext.ErrorSink
    
        
        :rtype: Microsoft.AspNet.Razor.ErrorSink
    
        
        .. code-block:: csharp
    
           public ErrorSink ErrorSink { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.RewritingContext.SyntaxTree
    
        
    
        The documents syntax tree.
    
        
        :rtype: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block
    
        
        .. code-block:: csharp
    
           public Block SyntaxTree { get; set; }
    

