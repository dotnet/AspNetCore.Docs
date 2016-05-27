

RewritingContext Class
======================






Informational class for rewriting a syntax tree.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Parser`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.Parser.RewritingContext`








Syntax
------

.. code-block:: csharp

    public class RewritingContext








.. dn:class:: Microsoft.AspNetCore.Razor.Parser.RewritingContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.RewritingContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.RewritingContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.RewritingContext.ErrorSink
    
        
        :rtype: Microsoft.AspNetCore.Razor.ErrorSink
    
        
        .. code-block:: csharp
    
            public ErrorSink ErrorSink
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.RewritingContext.SyntaxTree
    
        
    
        
        The documents syntax tree.
    
        
        :rtype: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block
    
        
        .. code-block:: csharp
    
            public Block SyntaxTree
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.RewritingContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Parser.RewritingContext.RewritingContext(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block, Microsoft.AspNetCore.Razor.ErrorSink)
    
        
    
        
        Instantiates a new :any:`Microsoft.AspNetCore.Razor.Parser.RewritingContext`\.
    
        
    
        
        :type syntaxTree: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block
    
        
        :type errorSink: Microsoft.AspNetCore.Razor.ErrorSink
    
        
        .. code-block:: csharp
    
            public RewritingContext(Block syntaxTree, ErrorSink errorSink)
    

