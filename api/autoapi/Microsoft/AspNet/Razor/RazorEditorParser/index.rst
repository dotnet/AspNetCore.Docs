

RazorEditorParser Class
=======================



.. contents:: 
   :local:



Summary
-------

Parser used by editors to avoid reparsing the entire document on each text change





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.RazorEditorParser`








Syntax
------

.. code-block:: csharp

   public class RazorEditorParser : IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/RazorEditorParser.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.RazorEditorParser

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.RazorEditorParser
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.RazorEditorParser.RazorEditorParser(Microsoft.AspNet.Razor.RazorEngineHost, System.String)
    
        
    
        Constructs the editor parser.  One instance should be used per active editor.  This
        instance _can_ be shared among reparses, but should _never_ be shared between documents.
    
        
        
        
        :param host: The  which defines the environment in which the generated code will live.   should be set if design-time code mappings are desired
        
        :type host: Microsoft.AspNet.Razor.RazorEngineHost
        
        
        :param sourceFileName: The physical path to use in line pragmas
        
        :type sourceFileName: System.String
    
        
        .. code-block:: csharp
    
           public RazorEditorParser(RazorEngineHost host, string sourceFileName)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.RazorEditorParser
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.RazorEditorParser.CheckForStructureChanges(Microsoft.AspNet.Razor.Text.TextChange)
    
        
    
        Determines if a change will cause a structural change to the document and if not, applies it to the existing tree.
        If a structural change would occur, automatically starts a reparse
    
        
        
        
        :param change: The change to apply to the parse tree
        
        :type change: Microsoft.AspNet.Razor.Text.TextChange
        :rtype: Microsoft.AspNet.Razor.PartialParseResult
        :return: A PartialParseResult value indicating the result of the incremental parse
    
        
        .. code-block:: csharp
    
           public virtual PartialParseResult CheckForStructureChanges(TextChange change)
    
    .. dn:method:: Microsoft.AspNet.Razor.RazorEditorParser.Dispose()
    
        
    
        Disposes of this parser.  Should be called when the editor window is closed and the document is unloaded.
    
        
    
        
        .. code-block:: csharp
    
           public void Dispose()
    
    .. dn:method:: Microsoft.AspNet.Razor.RazorEditorParser.Dispose(System.Boolean)
    
        
        
        
        :type disposing: System.Boolean
    
        
        .. code-block:: csharp
    
           protected virtual void Dispose(bool disposing)
    
    .. dn:method:: Microsoft.AspNet.Razor.RazorEditorParser.GetAutoCompleteString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public virtual string GetAutoCompleteString()
    

Events
------

.. dn:class:: Microsoft.AspNet.Razor.RazorEditorParser
    :noindex:
    :hidden:

    
    .. dn:event:: Microsoft.AspNet.Razor.RazorEditorParser.DocumentParseComplete
    
        
    
        Event fired when a full reparse of the document completes
    
        
    
        
        .. code-block:: csharp
    
           public event EventHandler<DocumentParseCompleteEventArgs> DocumentParseComplete
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.RazorEditorParser
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.RazorEditorParser.CurrentParseTree
    
        
        :rtype: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block
    
        
        .. code-block:: csharp
    
           public Block CurrentParseTree { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.RazorEditorParser.FileName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string FileName { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.RazorEditorParser.Host
    
        
        :rtype: Microsoft.AspNet.Razor.RazorEngineHost
    
        
        .. code-block:: csharp
    
           public RazorEngineHost Host { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.RazorEditorParser.LastResultProvisional
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool LastResultProvisional { get; }
    

