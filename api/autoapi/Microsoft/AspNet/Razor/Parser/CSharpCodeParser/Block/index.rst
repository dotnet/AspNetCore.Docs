

Block Class
===========



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Parser.CSharpCodeParser.Block`








Syntax
------

.. code-block:: csharp

   protected class Block





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/Parser/CSharpCodeParser.Statements.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Parser.CSharpCodeParser.Block

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Parser.CSharpCodeParser.Block
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Parser.CSharpCodeParser.Block.Block(Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbol)
    
        
        
        
        :type symbol: Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbol
    
        
        .. code-block:: csharp
    
           public Block(CSharpSymbol symbol)
    
    .. dn:constructor:: Microsoft.AspNet.Razor.Parser.CSharpCodeParser.Block.Block(System.String, Microsoft.AspNet.Razor.SourceLocation)
    
        
        
        
        :type name: System.String
        
        
        :type start: Microsoft.AspNet.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
           public Block(string name, SourceLocation start)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Parser.CSharpCodeParser.Block
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.CSharpCodeParser.Block.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Name { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.CSharpCodeParser.Block.Start
    
        
        :rtype: Microsoft.AspNet.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
           public SourceLocation Start { get; set; }
    

