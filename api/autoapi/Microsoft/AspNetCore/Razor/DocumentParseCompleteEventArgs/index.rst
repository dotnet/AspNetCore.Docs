

DocumentParseCompleteEventArgs Class
====================================






Arguments for the DocumentParseComplete event in RazorEditorParser


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
* :dn:cls:`System.EventArgs`
* :dn:cls:`Microsoft.AspNetCore.Razor.DocumentParseCompleteEventArgs`








Syntax
------

.. code-block:: csharp

    public class DocumentParseCompleteEventArgs : EventArgs








.. dn:class:: Microsoft.AspNetCore.Razor.DocumentParseCompleteEventArgs
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.DocumentParseCompleteEventArgs

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.DocumentParseCompleteEventArgs
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.DocumentParseCompleteEventArgs.GeneratorResults
    
        
    
        
        The results of the chunk generation and parsing
    
        
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratorResults
    
        
        .. code-block:: csharp
    
            public GeneratorResults GeneratorResults { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.DocumentParseCompleteEventArgs.SourceChange
    
        
    
        
        The TextChange which triggered the re-parse
    
        
        :rtype: Microsoft.AspNetCore.Razor.Text.TextChange
    
        
        .. code-block:: csharp
    
            public TextChange SourceChange { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.DocumentParseCompleteEventArgs.TreeStructureChanged
    
        
    
        
        Indicates if the tree structure has actually changed since the previous re-parse.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool TreeStructureChanged { get; set; }
    

