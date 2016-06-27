

CSharpSymbol Class
==================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Tokenizer.Symbols`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.Tokenizer.Symbols.SymbolBase{Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbolType}`
* :dn:cls:`Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbol`








Syntax
------

.. code-block:: csharp

    public class CSharpSymbol : SymbolBase<CSharpSymbolType>, ISymbol








.. dn:class:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbol
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbol

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbol
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbol.CSharpSymbol(Microsoft.AspNetCore.Razor.SourceLocation, System.String, Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbolType)
    
        
    
        
        :type start: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        :type content: System.String
    
        
        :type type: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbolType
    
        
        .. code-block:: csharp
    
            public CSharpSymbol(SourceLocation start, string content, CSharpSymbolType type)
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbol.CSharpSymbol(Microsoft.AspNetCore.Razor.SourceLocation, System.String, Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbolType, System.Collections.Generic.IReadOnlyList<Microsoft.AspNetCore.Razor.RazorError>)
    
        
    
        
        :type start: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        :type content: System.String
    
        
        :type type: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbolType
    
        
        :type errors: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Razor.RazorError<Microsoft.AspNetCore.Razor.RazorError>}
    
        
        .. code-block:: csharp
    
            public CSharpSymbol(SourceLocation start, string content, CSharpSymbolType type, IReadOnlyList<RazorError> errors)
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbol.CSharpSymbol(System.Int32, System.Int32, System.Int32, System.String, Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbolType)
    
        
    
        
        :type offset: System.Int32
    
        
        :type line: System.Int32
    
        
        :type column: System.Int32
    
        
        :type content: System.String
    
        
        :type type: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbolType
    
        
        .. code-block:: csharp
    
            public CSharpSymbol(int offset, int line, int column, string content, CSharpSymbolType type)
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbol.CSharpSymbol(System.Int32, System.Int32, System.Int32, System.String, Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbolType, System.Collections.Generic.IReadOnlyList<Microsoft.AspNetCore.Razor.RazorError>)
    
        
    
        
        :type offset: System.Int32
    
        
        :type line: System.Int32
    
        
        :type column: System.Int32
    
        
        :type content: System.String
    
        
        :type type: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbolType
    
        
        :type errors: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Razor.RazorError<Microsoft.AspNetCore.Razor.RazorError>}
    
        
        .. code-block:: csharp
    
            public CSharpSymbol(int offset, int line, int column, string content, CSharpSymbolType type, IReadOnlyList<RazorError> errors)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbol
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbol.Equals(System.Object)
    
        
    
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbol.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbol
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbol.EscapedIdentifier
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.Boolean<System.Boolean>}
    
        
        .. code-block:: csharp
    
            public bool ? EscapedIdentifier { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbol.Keyword
    
        
        :rtype: System.Nullable<System.Nullable`1>{Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpKeyword<Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpKeyword>}
    
        
        .. code-block:: csharp
    
            public CSharpKeyword? Keyword { get; set; }
    

