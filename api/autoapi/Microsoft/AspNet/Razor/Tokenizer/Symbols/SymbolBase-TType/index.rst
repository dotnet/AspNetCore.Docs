

SymbolBase<TType> Class
=======================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Tokenizer.Symbols.SymbolBase\<TType>`








Syntax
------

.. code-block:: csharp

   public abstract class SymbolBase<TType> : ISymbol where TType : struct





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/Tokenizer/Symbols/SymbolBase.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Tokenizer.Symbols.SymbolBase<TType>

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Tokenizer.Symbols.SymbolBase<TType>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Tokenizer.Symbols.SymbolBase<TType>.SymbolBase(Microsoft.AspNet.Razor.SourceLocation, System.String, TType, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Razor.RazorError>)
    
        
        
        
        :type start: Microsoft.AspNet.Razor.SourceLocation
        
        
        :type content: System.String
        
        
        :type type: {TType}
        
        
        :type errors: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.RazorError}
    
        
        .. code-block:: csharp
    
           protected SymbolBase(SourceLocation start, string content, TType type, IEnumerable<RazorError> errors)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Tokenizer.Symbols.SymbolBase<TType>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Tokenizer.Symbols.SymbolBase<TType>.ChangeStart(Microsoft.AspNet.Razor.SourceLocation)
    
        
        
        
        :type newStart: Microsoft.AspNet.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
           public void ChangeStart(SourceLocation newStart)
    
    .. dn:method:: Microsoft.AspNet.Razor.Tokenizer.Symbols.SymbolBase<TType>.Equals(System.Object)
    
        
        
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNet.Razor.Tokenizer.Symbols.SymbolBase<TType>.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNet.Razor.Tokenizer.Symbols.SymbolBase<TType>.OffsetStart(Microsoft.AspNet.Razor.SourceLocation)
    
        
        
        
        :type documentStart: Microsoft.AspNet.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
           public void OffsetStart(SourceLocation documentStart)
    
    .. dn:method:: Microsoft.AspNet.Razor.Tokenizer.Symbols.SymbolBase<TType>.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string ToString()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Tokenizer.Symbols.SymbolBase<TType>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Tokenizer.Symbols.SymbolBase<TType>.Content
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Content { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Tokenizer.Symbols.SymbolBase<TType>.Errors
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.RazorError}
    
        
        .. code-block:: csharp
    
           public IEnumerable<RazorError> Errors { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Tokenizer.Symbols.SymbolBase<TType>.Start
    
        
        :rtype: Microsoft.AspNet.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
           public SourceLocation Start { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Tokenizer.Symbols.SymbolBase<TType>.Type
    
        
        :rtype: {TType}
    
        
        .. code-block:: csharp
    
           public TType Type { get; }
    

