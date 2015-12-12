

ParserBase Class
================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Parser.ParserBase`








Syntax
------

.. code-block:: csharp

   public abstract class ParserBase





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/Parser/ParserBase.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Parser.ParserBase

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Parser.ParserBase
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.ParserBase.BuildSpan(Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanBuilder, Microsoft.AspNet.Razor.SourceLocation, System.String)
    
        
        
        
        :type span: Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanBuilder
        
        
        :type start: Microsoft.AspNet.Razor.SourceLocation
        
        
        :type content: System.String
    
        
        .. code-block:: csharp
    
           public abstract void BuildSpan(SpanBuilder span, SourceLocation start, string content)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.ParserBase.ParseBlock()
    
        
    
        
        .. code-block:: csharp
    
           public abstract void ParseBlock()
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.ParserBase.ParseDocument()
    
        
    
        
        .. code-block:: csharp
    
           public virtual void ParseDocument()
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.ParserBase.ParseSection(System.Tuple<System.String, System.String>, System.Boolean)
    
        
        
        
        :type nestingSequences: System.Tuple{System.String,System.String}
        
        
        :type caseSensitive: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual void ParseSection(Tuple<string, string> nestingSequences, bool caseSensitive)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Parser.ParserBase
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.ParserBase.Context
    
        
        :rtype: Microsoft.AspNet.Razor.Parser.ParserContext
    
        
        .. code-block:: csharp
    
           public virtual ParserContext Context { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.ParserBase.IsMarkupParser
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual bool IsMarkupParser { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.ParserBase.OtherParser
    
        
        :rtype: Microsoft.AspNet.Razor.Parser.ParserBase
    
        
        .. code-block:: csharp
    
           protected abstract ParserBase OtherParser { get; }
    

