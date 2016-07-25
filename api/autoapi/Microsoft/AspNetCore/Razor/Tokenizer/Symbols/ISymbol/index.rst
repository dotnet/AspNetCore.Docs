

ISymbol Interface
=================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Tokenizer.Symbols`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface ISymbol








.. dn:interface:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol.ChangeStart(Microsoft.AspNetCore.Razor.SourceLocation)
    
        
    
        
        :type newStart: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
            void ChangeStart(SourceLocation newStart)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol.OffsetStart(Microsoft.AspNetCore.Razor.SourceLocation)
    
        
    
        
        :type documentStart: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
            void OffsetStart(SourceLocation documentStart)
    

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol.Content
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string Content { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.ISymbol.Start
    
        
        :rtype: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
            SourceLocation Start { get; }
    

