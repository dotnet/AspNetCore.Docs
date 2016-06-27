

TextDocumentReader Class
========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Text`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.MarshalByRefObject`
* :dn:cls:`System.IO.TextReader`
* :dn:cls:`Microsoft.AspNetCore.Razor.Text.TextDocumentReader`








Syntax
------

.. code-block:: csharp

    public class TextDocumentReader : TextReader, IDisposable, ITextDocument, ITextBuffer








.. dn:class:: Microsoft.AspNetCore.Razor.Text.TextDocumentReader
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Text.TextDocumentReader

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Text.TextDocumentReader
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Text.TextDocumentReader.TextDocumentReader(Microsoft.AspNetCore.Razor.Text.ITextDocument)
    
        
    
        
        :type source: Microsoft.AspNetCore.Razor.Text.ITextDocument
    
        
        .. code-block:: csharp
    
            public TextDocumentReader(ITextDocument source)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Text.TextDocumentReader
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Text.TextDocumentReader.Length
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Length { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Text.TextDocumentReader.Location
    
        
        :rtype: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
            public SourceLocation Location { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Text.TextDocumentReader.Position
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Position { get; set; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Text.TextDocumentReader
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Text.TextDocumentReader.Peek()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int Peek()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Text.TextDocumentReader.Read()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int Read()
    

