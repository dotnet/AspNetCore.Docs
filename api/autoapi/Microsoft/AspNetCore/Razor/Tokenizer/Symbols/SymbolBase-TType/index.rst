

SymbolBase<TType> Class
=======================





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
* :dn:cls:`Microsoft.AspNetCore.Razor.Tokenizer.Symbols.SymbolBase\<TType>`








Syntax
------

.. code-block:: csharp

    public abstract class SymbolBase<TType> : ISymbol where TType : struct








.. dn:class:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.SymbolBase`1
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.SymbolBase<TType>

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.SymbolBase<TType>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.SymbolBase<TType>.SymbolBase(Microsoft.AspNetCore.Razor.SourceLocation, System.String, TType, System.Collections.Generic.IReadOnlyList<Microsoft.AspNetCore.Razor.RazorError>)
    
        
    
        
        :type start: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        :type content: System.String
    
        
        :type type: TType
    
        
        :type errors: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Razor.RazorError<Microsoft.AspNetCore.Razor.RazorError>}
    
        
        .. code-block:: csharp
    
            protected SymbolBase(SourceLocation start, string content, TType type, IReadOnlyList<RazorError> errors)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.SymbolBase<TType>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.SymbolBase<TType>.ChangeStart(Microsoft.AspNetCore.Razor.SourceLocation)
    
        
    
        
        :type newStart: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
            public void ChangeStart(SourceLocation newStart)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.SymbolBase<TType>.Equals(System.Object)
    
        
    
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.SymbolBase<TType>.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.SymbolBase<TType>.OffsetStart(Microsoft.AspNetCore.Razor.SourceLocation)
    
        
    
        
        :type documentStart: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
            public void OffsetStart(SourceLocation documentStart)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.SymbolBase<TType>.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ToString()
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.SymbolBase<TType>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.SymbolBase<TType>.Content
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Content { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.SymbolBase<TType>.Errors
    
        
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Razor.RazorError<Microsoft.AspNetCore.Razor.RazorError>}
    
        
        .. code-block:: csharp
    
            public IReadOnlyList<RazorError> Errors { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.SymbolBase<TType>.Start
    
        
        :rtype: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
            public SourceLocation Start { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.SymbolBase<TType>.Type
    
        
        :rtype: TType
    
        
        .. code-block:: csharp
    
            public TType Type { get; }
    

