

CSharpSymbol Class
==================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Tokenizer.Symbols.SymbolBase{Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbolType}`
* :dn:cls:`Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbol`








Syntax
------

.. code-block:: csharp

   public class CSharpSymbol : SymbolBase<CSharpSymbolType>, ISymbol





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/Tokenizer/Symbols/CSharpSymbol.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbol

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbol
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbol.CSharpSymbol(Microsoft.AspNet.Razor.SourceLocation, System.String, Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbolType)
    
        
        
        
        :type start: Microsoft.AspNet.Razor.SourceLocation
        
        
        :type content: System.String
        
        
        :type type: Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbolType
    
        
        .. code-block:: csharp
    
           public CSharpSymbol(SourceLocation start, string content, CSharpSymbolType type)
    
    .. dn:constructor:: Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbol.CSharpSymbol(Microsoft.AspNet.Razor.SourceLocation, System.String, Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbolType, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Razor.RazorError>)
    
        
        
        
        :type start: Microsoft.AspNet.Razor.SourceLocation
        
        
        :type content: System.String
        
        
        :type type: Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbolType
        
        
        :type errors: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.RazorError}
    
        
        .. code-block:: csharp
    
           public CSharpSymbol(SourceLocation start, string content, CSharpSymbolType type, IEnumerable<RazorError> errors)
    
    .. dn:constructor:: Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbol.CSharpSymbol(System.Int32, System.Int32, System.Int32, System.String, Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbolType)
    
        
        
        
        :type offset: System.Int32
        
        
        :type line: System.Int32
        
        
        :type column: System.Int32
        
        
        :type content: System.String
        
        
        :type type: Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbolType
    
        
        .. code-block:: csharp
    
           public CSharpSymbol(int offset, int line, int column, string content, CSharpSymbolType type)
    
    .. dn:constructor:: Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbol.CSharpSymbol(System.Int32, System.Int32, System.Int32, System.String, Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbolType, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Razor.RazorError>)
    
        
        
        
        :type offset: System.Int32
        
        
        :type line: System.Int32
        
        
        :type column: System.Int32
        
        
        :type content: System.String
        
        
        :type type: Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbolType
        
        
        :type errors: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.RazorError}
    
        
        .. code-block:: csharp
    
           public CSharpSymbol(int offset, int line, int column, string content, CSharpSymbolType type, IEnumerable<RazorError> errors)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbol
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbol.Equals(System.Object)
    
        
        
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbol.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int GetHashCode()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbol
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbol.EscapedIdentifier
    
        
        :rtype: System.Nullable{System.Boolean}
    
        
        .. code-block:: csharp
    
           public bool ? EscapedIdentifier { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbol.Keyword
    
        
        :rtype: System.Nullable{Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpKeyword}
    
        
        .. code-block:: csharp
    
           public CSharpKeyword? Keyword { get; set; }
    

