

RazorEditorParser Class
=======================






Parser used by editors to avoid reparsing the entire document on each text change.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.RazorEditorParser`








Syntax
------

.. code-block:: csharp

    public class RazorEditorParser : IDisposable








.. dn:class:: Microsoft.AspNetCore.Razor.RazorEditorParser
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.RazorEditorParser

Events
------

.. dn:class:: Microsoft.AspNetCore.Razor.RazorEditorParser
    :noindex:
    :hidden:

    
    .. dn:event:: Microsoft.AspNetCore.Razor.RazorEditorParser.DocumentParseComplete
    
        
    
        
        Event fired when a full reparse of the document completes.
    
        
        :rtype: System.EventHandler<System.EventHandler`1>{Microsoft.AspNetCore.Razor.DocumentParseCompleteEventArgs<Microsoft.AspNetCore.Razor.DocumentParseCompleteEventArgs>}
    
        
        .. code-block:: csharp
    
            public event EventHandler<DocumentParseCompleteEventArgs> DocumentParseComplete
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.RazorEditorParser
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.RazorEditorParser.RazorEditorParser(Microsoft.AspNetCore.Razor.RazorEngineHost, System.String)
    
        
    
        
        Constructs the editor parser. One instance should be used per active editor. This
        instance <em>can</em> be shared among reparses, but should <em>never</em> be shared between documents.
    
        
    
        
        :param host: The :any:`Microsoft.AspNetCore.Razor.RazorEngineHost` which defines the environment in which the generated
            code will live. :dn:prop:`Microsoft.AspNetCore.Razor.RazorEngineHost.DesignTimeMode` should be set if design-time behavior is
            desired.
        
        :type host: Microsoft.AspNetCore.Razor.RazorEngineHost
    
        
        :param sourceFileName: The physical path to use in line pragmas.
        
        :type sourceFileName: System.String
    
        
        .. code-block:: csharp
    
            public RazorEditorParser(RazorEngineHost host, string sourceFileName)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.RazorEditorParser
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.RazorEditorParser.CheckForStructureChanges(Microsoft.AspNetCore.Razor.Text.TextChange)
    
        
    
        
        Determines if a change will cause a structural change to the document and if not, applies it to the
        existing tree. If a structural change would occur, automatically starts a reparse.
    
        
    
        
        :param change: The change to apply to the parse tree.
        
        :type change: Microsoft.AspNetCore.Razor.Text.TextChange
        :rtype: Microsoft.AspNetCore.Razor.PartialParseResult
        :return: A :any:`Microsoft.AspNetCore.Razor.PartialParseResult` value indicating the result of the incremental parse.
    
        
        .. code-block:: csharp
    
            public virtual PartialParseResult CheckForStructureChanges(TextChange change)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.RazorEditorParser.Dispose()
    
        
    
        
        Disposes of this parser. Should be called when the editor window is closed and the document is unloaded.
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.RazorEditorParser.Dispose(System.Boolean)
    
        
    
        
        :type disposing: System.Boolean
    
        
        .. code-block:: csharp
    
            protected virtual void Dispose(bool disposing)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.RazorEditorParser.GetAutoCompleteString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string GetAutoCompleteString()
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.RazorEditorParser
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.RazorEditorParser.CurrentParseTree
    
        
        :rtype: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block
    
        
        .. code-block:: csharp
    
            public Block CurrentParseTree { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.RazorEditorParser.FileName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string FileName { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.RazorEditorParser.Host
    
        
        :rtype: Microsoft.AspNetCore.Razor.RazorEngineHost
    
        
        .. code-block:: csharp
    
            public RazorEngineHost Host { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.RazorEditorParser.LastResultProvisional
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool LastResultProvisional { get; }
    

