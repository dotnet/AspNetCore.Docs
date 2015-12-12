

ParserResults Class
===================



.. contents:: 
   :local:



Summary
-------

Represents the results of parsing a Razor document





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.ParserResults`








Syntax
------

.. code-block:: csharp

   public class ParserResults





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/ParserResults.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.ParserResults

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.ParserResults
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.ParserResults.ParserResults(Microsoft.AspNet.Razor.Parser.SyntaxTree.Block, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor>, Microsoft.AspNet.Razor.ErrorSink)
    
        
    
        Instantiates a new :any:`Microsoft.AspNet.Razor.ParserResults` instance.
    
        
        
        
        :param document: The  for the syntax tree.
        
        :type document: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block
        
        
        :param tagHelperDescriptors: The s that apply to the current Razor document.
        
        :type tagHelperDescriptors: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor}
        
        
        :param errorSink: The  used to collect s encountered when parsing the
            current Razor document.
        
        :type errorSink: Microsoft.AspNet.Razor.ErrorSink
    
        
        .. code-block:: csharp
    
           public ParserResults(Block document, IEnumerable<TagHelperDescriptor> tagHelperDescriptors, ErrorSink errorSink)
    
    .. dn:constructor:: Microsoft.AspNet.Razor.ParserResults.ParserResults(System.Boolean, Microsoft.AspNet.Razor.Parser.SyntaxTree.Block, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor>, Microsoft.AspNet.Razor.ErrorSink)
    
        
    
        Instantiates a new :any:`Microsoft.AspNet.Razor.ParserResults` instance.
    
        
        
        
        :param success: true if parsing was successful, false otherwise.
        
        :type success: System.Boolean
        
        
        :param document: The  for the syntax tree.
        
        :type document: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block
        
        
        :param tagHelperDescriptors: The s that apply to the current Razor document.
        
        :type tagHelperDescriptors: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor}
        
        
        :param errorSink: The  used to collect s encountered when parsing the
            current Razor document.
        
        :type errorSink: Microsoft.AspNet.Razor.ErrorSink
    
        
        .. code-block:: csharp
    
           protected ParserResults(bool success, Block document, IEnumerable<TagHelperDescriptor> tagHelperDescriptors, ErrorSink errorSink)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.ParserResults
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.ParserResults.Document
    
        
    
        The root node in the document's syntax tree.
    
        
        :rtype: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block
    
        
        .. code-block:: csharp
    
           public Block Document { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.ParserResults.ErrorSink
    
        
    
        Used to aggregate :any:`Microsoft.AspNet.Razor.RazorError`\s.
    
        
        :rtype: Microsoft.AspNet.Razor.ErrorSink
    
        
        .. code-block:: csharp
    
           public ErrorSink ErrorSink { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.ParserResults.ParserErrors
    
        
    
        The list of errors which occurred during parsing.
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.RazorError}
    
        
        .. code-block:: csharp
    
           public IEnumerable<RazorError> ParserErrors { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.ParserResults.Prefix
    
        
    
        Text used as a required prefix when matching HTML.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Prefix { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.ParserResults.Success
    
        
    
        Indicates if parsing was successful (no errors).
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Success { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.ParserResults.TagHelperDescriptors
    
        
    
        The :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s found for the current Razor document.
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor}
    
        
        .. code-block:: csharp
    
           public IEnumerable<TagHelperDescriptor> TagHelperDescriptors { get; }
    

