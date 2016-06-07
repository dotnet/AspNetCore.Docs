

MvcRazorCodeParser Class
========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Razor`
Assemblies
    * Microsoft.AspNetCore.Mvc.Razor.Host

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.Parser.ParserBase`
* :dn:cls:`Microsoft.AspNetCore.Razor.Parser.TokenizerBackedParser{Microsoft.AspNetCore.Razor.Tokenizer.CSharpTokenizer,Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbol,Microsoft.AspNetCore.Razor.Tokenizer.Symbols.CSharpSymbolType}`
* :dn:cls:`Microsoft.AspNetCore.Razor.Parser.CSharpCodeParser`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.MvcRazorCodeParser`








Syntax
------

.. code-block:: csharp

    public class MvcRazorCodeParser : CSharpCodeParser








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.MvcRazorCodeParser
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.MvcRazorCodeParser

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.MvcRazorCodeParser
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.MvcRazorCodeParser.MvcRazorCodeParser()
    
        
    
        
        .. code-block:: csharp
    
            public MvcRazorCodeParser()
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.MvcRazorCodeParser
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.MvcRazorCodeParser.InheritsDirective()
    
        
    
        
        .. code-block:: csharp
    
            protected override void InheritsDirective()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.MvcRazorCodeParser.InjectDirective()
    
        
    
        
        .. code-block:: csharp
    
            protected virtual void InjectDirective()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.MvcRazorCodeParser.ModelDirective()
    
        
    
        
        .. code-block:: csharp
    
            protected virtual void ModelDirective()
    

