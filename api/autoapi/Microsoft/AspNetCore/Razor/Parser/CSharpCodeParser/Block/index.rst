

Block Class
===========





Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Parser.CSharpCodeParser`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.Parser.CSharpCodeParser.Block`








Syntax
------

.. code-block:: csharp

    protected class Block








.. dn:class:: Microsoft.AspNetCore.Razor.Parser.CSharpCodeParser.Block
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.CSharpCodeParser.Block

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.CSharpCodeParser.Block
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Parser.CSharpCodeParser.Block.Block(Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbol)
    
        
    
        
        :type symbol: Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbol
    
        
        .. code-block:: csharp
    
            public Block(CSharpSymbol symbol)
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Parser.CSharpCodeParser.Block.Block(System.String, Microsoft.AspNetCore.Razor.SourceLocation)
    
        
    
        
        :type name: System.String
    
        
        :type start: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
            public Block(string name, SourceLocation start)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.CSharpCodeParser.Block
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.CSharpCodeParser.Block.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Name { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.CSharpCodeParser.Block.Start
    
        
        :rtype: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
            public SourceLocation Start { get; set; }
    

