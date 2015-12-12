

ISyntaxTreeRewriter Interface
=============================



.. contents:: 
   :local:



Summary
-------

Contract for rewriting a syntax tree.











Syntax
------

.. code-block:: csharp

   public interface ISyntaxTreeRewriter





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/Parser/ISyntaxTreeRewriter.cs>`_





.. dn:interface:: Microsoft.AspNet.Razor.Parser.ISyntaxTreeRewriter

Methods
-------

.. dn:interface:: Microsoft.AspNet.Razor.Parser.ISyntaxTreeRewriter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.ISyntaxTreeRewriter.Rewrite(Microsoft.AspNet.Razor.Parser.RewritingContext)
    
        
    
        Rewrites the provided ``context`s`` :dn:prop:`Microsoft.AspNet.Razor.Parser.RewritingContext.SyntaxTree`\.
    
        
        
        
        :param context: Contains information on the rewriting of the syntax tree.
        
        :type context: Microsoft.AspNet.Razor.Parser.RewritingContext
    
        
        .. code-block:: csharp
    
           void Rewrite(RewritingContext context)
    

