

TokenizerView<TTokenizer, TSymbol, TSymbolType> Class
=====================================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Tokenizer.TokenizerView\<TTokenizer, TSymbol, TSymbolType>`








Syntax
------

.. code-block:: csharp

   public class TokenizerView<TTokenizer, TSymbol, TSymbolType> where TTokenizer : Tokenizer<TSymbol, TSymbolType> where TSymbol : SymbolBase<TSymbolType> where TSymbolType : struct





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/Tokenizer/TokenizerView.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Tokenizer.TokenizerView<TTokenizer, TSymbol, TSymbolType>

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Tokenizer.TokenizerView<TTokenizer, TSymbol, TSymbolType>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Tokenizer.TokenizerView<TTokenizer, TSymbol, TSymbolType>.TokenizerView(TTokenizer)
    
        
        
        
        :type tokenizer: {TTokenizer}
    
        
        .. code-block:: csharp
    
           public TokenizerView(TTokenizer tokenizer)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Tokenizer.TokenizerView<TTokenizer, TSymbol, TSymbolType>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Tokenizer.TokenizerView<TTokenizer, TSymbol, TSymbolType>.Next()
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Next()
    
    .. dn:method:: Microsoft.AspNet.Razor.Tokenizer.TokenizerView<TTokenizer, TSymbol, TSymbolType>.PutBack(TSymbol)
    
        
        
        
        :type symbol: {TSymbol}
    
        
        .. code-block:: csharp
    
           public void PutBack(TSymbol symbol)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Tokenizer.TokenizerView<TTokenizer, TSymbol, TSymbolType>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Tokenizer.TokenizerView<TTokenizer, TSymbol, TSymbolType>.Current
    
        
        :rtype: {TSymbol}
    
        
        .. code-block:: csharp
    
           public TSymbol Current { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Tokenizer.TokenizerView<TTokenizer, TSymbol, TSymbolType>.EndOfFile
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool EndOfFile { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Tokenizer.TokenizerView<TTokenizer, TSymbol, TSymbolType>.Source
    
        
        :rtype: Microsoft.AspNet.Razor.Text.ITextDocument
    
        
        .. code-block:: csharp
    
           public ITextDocument Source { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Tokenizer.TokenizerView<TTokenizer, TSymbol, TSymbolType>.Tokenizer
    
        
        :rtype: {TTokenizer}
    
        
        .. code-block:: csharp
    
           public TTokenizer Tokenizer { get; }
    

