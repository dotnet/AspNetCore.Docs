

ISymbol Interface
=================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface ISymbol





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/Tokenizer/Symbols/ISymbol.cs>`_





.. dn:interface:: Microsoft.AspNet.Razor.Tokenizer.Symbols.ISymbol

Methods
-------

.. dn:interface:: Microsoft.AspNet.Razor.Tokenizer.Symbols.ISymbol
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Tokenizer.Symbols.ISymbol.ChangeStart(Microsoft.AspNet.Razor.SourceLocation)
    
        
        
        
        :type newStart: Microsoft.AspNet.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
           void ChangeStart(SourceLocation newStart)
    
    .. dn:method:: Microsoft.AspNet.Razor.Tokenizer.Symbols.ISymbol.OffsetStart(Microsoft.AspNet.Razor.SourceLocation)
    
        
        
        
        :type documentStart: Microsoft.AspNet.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
           void OffsetStart(SourceLocation documentStart)
    

Properties
----------

.. dn:interface:: Microsoft.AspNet.Razor.Tokenizer.Symbols.ISymbol
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Tokenizer.Symbols.ISymbol.Content
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string Content { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Tokenizer.Symbols.ISymbol.Start
    
        
        :rtype: Microsoft.AspNet.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
           SourceLocation Start { get; }
    

