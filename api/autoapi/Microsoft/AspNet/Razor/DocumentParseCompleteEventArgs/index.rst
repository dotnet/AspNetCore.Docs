

DocumentParseCompleteEventArgs Class
====================================



.. contents:: 
   :local:



Summary
-------

Arguments for the DocumentParseComplete event in RazorEditorParser





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.EventArgs`
* :dn:cls:`Microsoft.AspNet.Razor.DocumentParseCompleteEventArgs`








Syntax
------

.. code-block:: csharp

   public class DocumentParseCompleteEventArgs : EventArgs





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/DocumentParseCompleteEventArgs.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.DocumentParseCompleteEventArgs

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.DocumentParseCompleteEventArgs
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.DocumentParseCompleteEventArgs.GeneratorResults
    
        
    
        The results of the chunk generation and parsing
    
        
        :rtype: Microsoft.AspNet.Razor.CodeGenerators.GeneratorResults
    
        
        .. code-block:: csharp
    
           public GeneratorResults GeneratorResults { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.DocumentParseCompleteEventArgs.SourceChange
    
        
    
        The TextChange which triggered the re-parse
    
        
        :rtype: Microsoft.AspNet.Razor.Text.TextChange
    
        
        .. code-block:: csharp
    
           public TextChange SourceChange { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.DocumentParseCompleteEventArgs.TreeStructureChanged
    
        
    
        Indicates if the tree structure has actually changed since the previous re-parse.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool TreeStructureChanged { get; set; }
    

