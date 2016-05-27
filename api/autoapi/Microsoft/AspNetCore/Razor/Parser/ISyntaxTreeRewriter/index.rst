

ISyntaxTreeRewriter Interface
=============================






Contract for rewriting a syntax tree.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Parser`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface ISyntaxTreeRewriter








.. dn:interface:: Microsoft.AspNetCore.Razor.Parser.ISyntaxTreeRewriter
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Razor.Parser.ISyntaxTreeRewriter

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Razor.Parser.ISyntaxTreeRewriter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.ISyntaxTreeRewriter.Rewrite(Microsoft.AspNetCore.Razor.Parser.RewritingContext)
    
        
    
        
        Rewrites the provided <em>context</em>s :dn:prop:`Microsoft.AspNetCore.Razor.Parser.RewritingContext.SyntaxTree`\.
    
        
    
        
        :param context: Contains information on the rewriting of the syntax tree.
        
        :type context: Microsoft.AspNetCore.Razor.Parser.RewritingContext
    
        
        .. code-block:: csharp
    
            void Rewrite(RewritingContext context)
    

