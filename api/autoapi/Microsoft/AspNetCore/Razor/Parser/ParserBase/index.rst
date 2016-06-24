

ParserBase Class
================





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
* :dn:cls:`Microsoft.AspNetCore.Razor.Parser.ParserBase`








Syntax
------

.. code-block:: csharp

    public abstract class ParserBase








.. dn:class:: Microsoft.AspNetCore.Razor.Parser.ParserBase
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.ParserBase

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.ParserBase
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.ParserBase.BuildSpan(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SpanBuilder, Microsoft.AspNetCore.Razor.SourceLocation, System.String)
    
        
    
        
        :type span: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SpanBuilder
    
        
        :type start: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        :type content: System.String
    
        
        .. code-block:: csharp
    
            public abstract void BuildSpan(SpanBuilder span, SourceLocation start, string content)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.ParserBase.ParseBlock()
    
        
    
        
        .. code-block:: csharp
    
            public abstract void ParseBlock()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.ParserBase.ParseDocument()
    
        
    
        
        .. code-block:: csharp
    
            public virtual void ParseDocument()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Parser.ParserBase.ParseSection(System.Tuple<System.String, System.String>, System.Boolean)
    
        
    
        
        :type nestingSequences: System.Tuple<System.Tuple`2>{System.String<System.String>, System.String<System.String>}
    
        
        :type caseSensitive: System.Boolean
    
        
        .. code-block:: csharp
    
            public virtual void ParseSection(Tuple<string, string> nestingSequences, bool caseSensitive)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.ParserBase
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.ParserBase.Context
    
        
        :rtype: Microsoft.AspNetCore.Razor.Parser.ParserContext
    
        
        .. code-block:: csharp
    
            public virtual ParserContext Context { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.ParserBase.IsMarkupParser
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public virtual bool IsMarkupParser { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.ParserBase.OtherParser
    
        
        :rtype: Microsoft.AspNetCore.Razor.Parser.ParserBase
    
        
        .. code-block:: csharp
    
            protected abstract ParserBase OtherParser { get; }
    

