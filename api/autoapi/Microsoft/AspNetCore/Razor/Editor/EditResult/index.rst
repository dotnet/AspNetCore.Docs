

EditResult Class
================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Editor`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.Editor.EditResult`








Syntax
------

.. code-block:: csharp

    public class EditResult








.. dn:class:: Microsoft.AspNetCore.Razor.Editor.EditResult
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Editor.EditResult

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Editor.EditResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Editor.EditResult.EditedSpan
    
        
        :rtype: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SpanBuilder
    
        
        .. code-block:: csharp
    
            public SpanBuilder EditedSpan
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Editor.EditResult.Result
    
        
        :rtype: Microsoft.AspNetCore.Razor.PartialParseResult
    
        
        .. code-block:: csharp
    
            public PartialParseResult Result
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Editor.EditResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Editor.EditResult.EditResult(Microsoft.AspNetCore.Razor.PartialParseResult, Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SpanBuilder)
    
        
    
        
        :type result: Microsoft.AspNetCore.Razor.PartialParseResult
    
        
        :type editedSpan: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SpanBuilder
    
        
        .. code-block:: csharp
    
            public EditResult(PartialParseResult result, SpanBuilder editedSpan)
    

