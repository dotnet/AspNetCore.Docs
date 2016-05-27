

ParserResults Class
===================






Represents the results of parsing a Razor document


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
* :dn:cls:`Microsoft.AspNetCore.Razor.ParserResults`








Syntax
------

.. code-block:: csharp

    public class ParserResults








.. dn:class:: Microsoft.AspNetCore.Razor.ParserResults
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.ParserResults

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.ParserResults
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.ParserResults.Document
    
        
    
        
        The root node in the document's syntax tree.
    
        
        :rtype: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block
    
        
        .. code-block:: csharp
    
            public Block Document
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.ParserResults.ErrorSink
    
        
    
        
        Used to aggregate :any:`Microsoft.AspNetCore.Razor.RazorError`\s.
    
        
        :rtype: Microsoft.AspNetCore.Razor.ErrorSink
    
        
        .. code-block:: csharp
    
            public ErrorSink ErrorSink
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.ParserResults.ParserErrors
    
        
    
        
        The list of errors which occurred during parsing.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.RazorError<Microsoft.AspNetCore.Razor.RazorError>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<RazorError> ParserErrors
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.ParserResults.Prefix
    
        
    
        
        Text used as a required prefix when matching HTML.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Prefix
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.ParserResults.Success
    
        
    
        
        Indicates if parsing was successful (no errors).
    
        
        :rtype: System.Boolean
        :return: <code>true</code> if parsing was successful, <code>false</code> otherwise.
    
        
        .. code-block:: csharp
    
            public bool Success
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.ParserResults.TagHelperDescriptors
    
        
    
        
        The :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s found for the current Razor document.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor<Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<TagHelperDescriptor> TagHelperDescriptors
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.ParserResults
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.ParserResults.ParserResults(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor>, Microsoft.AspNetCore.Razor.ErrorSink)
    
        
    
        
        Instantiates a new :any:`Microsoft.AspNetCore.Razor.ParserResults` instance.
    
        
    
        
        :param document: The :any:`Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block` for the syntax tree.
        
        :type document: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block
    
        
        :param tagHelperDescriptors: 
            The :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s that apply to the current Razor document.
        
        :type tagHelperDescriptors: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor<Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor>}
    
        
        :param errorSink: 
            The :dn:prop:`Microsoft.AspNetCore.Razor.ParserResults.ErrorSink` used to collect :any:`Microsoft.AspNetCore.Razor.RazorError`\s encountered when parsing the
            current Razor document.
        
        :type errorSink: Microsoft.AspNetCore.Razor.ErrorSink
    
        
        .. code-block:: csharp
    
            public ParserResults(Block document, IEnumerable<TagHelperDescriptor> tagHelperDescriptors, ErrorSink errorSink)
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.ParserResults.ParserResults(System.Boolean, Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor>, Microsoft.AspNetCore.Razor.ErrorSink)
    
        
    
        
        Instantiates a new :any:`Microsoft.AspNetCore.Razor.ParserResults` instance.
    
        
    
        
        :param success: <code>true</code> if parsing was successful, <code>false</code> otherwise.
        
        :type success: System.Boolean
    
        
        :param document: The :any:`Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block` for the syntax tree.
        
        :type document: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Block
    
        
        :param tagHelperDescriptors: 
            The :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s that apply to the current Razor document.
        
        :type tagHelperDescriptors: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor<Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor>}
    
        
        :param errorSink: 
            The :dn:prop:`Microsoft.AspNetCore.Razor.ParserResults.ErrorSink` used to collect :any:`Microsoft.AspNetCore.Razor.RazorError`\s encountered when parsing the
            current Razor document.
        
        :type errorSink: Microsoft.AspNetCore.Razor.ErrorSink
    
        
        .. code-block:: csharp
    
            protected ParserResults(bool success, Block document, IEnumerable<TagHelperDescriptor> tagHelperDescriptors, ErrorSink errorSink)
    

