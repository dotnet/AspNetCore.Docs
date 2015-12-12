

EditResult Class
================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Editor.EditResult`








Syntax
------

.. code-block:: csharp

   public class EditResult





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/Editor/EditResult.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Editor.EditResult

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Editor.EditResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Editor.EditResult.EditResult(Microsoft.AspNet.Razor.PartialParseResult, Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanBuilder)
    
        
        
        
        :type result: Microsoft.AspNet.Razor.PartialParseResult
        
        
        :type editedSpan: Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanBuilder
    
        
        .. code-block:: csharp
    
           public EditResult(PartialParseResult result, SpanBuilder editedSpan)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Editor.EditResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Editor.EditResult.EditedSpan
    
        
        :rtype: Microsoft.AspNet.Razor.Parser.SyntaxTree.SpanBuilder
    
        
        .. code-block:: csharp
    
           public SpanBuilder EditedSpan { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Editor.EditResult.Result
    
        
        :rtype: Microsoft.AspNet.Razor.PartialParseResult
    
        
        .. code-block:: csharp
    
           public PartialParseResult Result { get; set; }
    

