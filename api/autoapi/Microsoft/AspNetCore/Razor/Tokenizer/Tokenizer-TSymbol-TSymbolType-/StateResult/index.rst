

StateResult Struct
==================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer`2`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    protected struct StateResult








.. dn:structure:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer`2.StateResult
    :hidden:

.. dn:structure:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.StateResult

Constructors
------------

.. dn:structure:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.StateResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.StateResult.StateResult(System.Nullable<System.Int32>, TSymbol)
    
        
    
        
        :type state: System.Nullable<System.Nullable`1>{System.Int32<System.Int32>}
    
        
        :type result: TSymbol
    
        
        .. code-block:: csharp
    
            public StateResult(int ? state, TSymbol result)
    

Properties
----------

.. dn:structure:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.StateResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.StateResult.Result
    
        
        :rtype: TSymbol
    
        
        .. code-block:: csharp
    
            public TSymbol Result { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Tokenizer.Tokenizer<TSymbol, TSymbolType>.StateResult.State
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.Int32<System.Int32>}
    
        
        .. code-block:: csharp
    
            public int ? State { get; }
    

