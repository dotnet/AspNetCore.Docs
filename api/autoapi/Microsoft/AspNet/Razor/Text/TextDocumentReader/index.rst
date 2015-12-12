

TextDocumentReader Class
========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.MarshalByRefObject`
* :dn:cls:`System.IO.TextReader`
* :dn:cls:`Microsoft.AspNet.Razor.Text.TextDocumentReader`








Syntax
------

.. code-block:: csharp

   public class TextDocumentReader : TextReader, IDisposable, ITextDocument, ITextBuffer





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/Text/TextDocumentReader.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Text.TextDocumentReader

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Text.TextDocumentReader
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Text.TextDocumentReader.TextDocumentReader(Microsoft.AspNet.Razor.Text.ITextDocument)
    
        
        
        
        :type source: Microsoft.AspNet.Razor.Text.ITextDocument
    
        
        .. code-block:: csharp
    
           public TextDocumentReader(ITextDocument source)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Text.TextDocumentReader
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Text.TextDocumentReader.Peek()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int Peek()
    
    .. dn:method:: Microsoft.AspNet.Razor.Text.TextDocumentReader.Read()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int Read()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Text.TextDocumentReader
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Text.TextDocumentReader.Length
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Length { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Text.TextDocumentReader.Location
    
        
        :rtype: Microsoft.AspNet.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
           public SourceLocation Location { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Text.TextDocumentReader.Position
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Position { get; set; }
    

