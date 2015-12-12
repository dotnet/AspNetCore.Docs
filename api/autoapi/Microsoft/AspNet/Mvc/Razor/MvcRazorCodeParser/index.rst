

MvcRazorCodeParser Class
========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Parser.ParserBase`
* :dn:cls:`Microsoft.AspNet.Razor.Parser.TokenizerBackedParser{Microsoft.AspNet.Razor.Tokenizer.CSharpTokenizer,Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbol,Microsoft.AspNet.Razor.Tokenizer.Symbols.CSharpSymbolType}`
* :dn:cls:`Microsoft.AspNet.Razor.Parser.CSharpCodeParser`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.MvcRazorCodeParser`








Syntax
------

.. code-block:: csharp

   public class MvcRazorCodeParser : CSharpCodeParser





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Razor.Host/MvcRazorCodeParser.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.MvcRazorCodeParser

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.MvcRazorCodeParser
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.MvcRazorCodeParser.MvcRazorCodeParser()
    
        
    
        
        .. code-block:: csharp
    
           public MvcRazorCodeParser()
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.MvcRazorCodeParser
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.MvcRazorCodeParser.InheritsDirective()
    
        
    
        
        .. code-block:: csharp
    
           protected override void InheritsDirective()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.MvcRazorCodeParser.InjectDirective()
    
        
    
        
        .. code-block:: csharp
    
           protected virtual void InjectDirective()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.MvcRazorCodeParser.ModelDirective()
    
        
    
        
        .. code-block:: csharp
    
           protected virtual void ModelDirective()
    

