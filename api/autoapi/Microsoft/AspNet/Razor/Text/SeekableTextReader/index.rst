

SeekableTextReader Class
========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.MarshalByRefObject`
* :dn:cls:`System.IO.TextReader`
* :dn:cls:`Microsoft.AspNet.Razor.Text.SeekableTextReader`








Syntax
------

.. code-block:: csharp

   public class SeekableTextReader : TextReader, IDisposable, ITextDocument, ITextBuffer





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/Text/SeekableTextReader.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Text.SeekableTextReader

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Text.SeekableTextReader
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Text.SeekableTextReader.SeekableTextReader(Microsoft.AspNet.Razor.Text.ITextBuffer)
    
        
        
        
        :type buffer: Microsoft.AspNet.Razor.Text.ITextBuffer
    
        
        .. code-block:: csharp
    
           public SeekableTextReader(ITextBuffer buffer)
    
    .. dn:constructor:: Microsoft.AspNet.Razor.Text.SeekableTextReader.SeekableTextReader(System.IO.TextReader)
    
        
        
        
        :type source: System.IO.TextReader
    
        
        .. code-block:: csharp
    
           public SeekableTextReader(TextReader source)
    
    .. dn:constructor:: Microsoft.AspNet.Razor.Text.SeekableTextReader.SeekableTextReader(System.String)
    
        
        
        
        :type content: System.String
    
        
        .. code-block:: csharp
    
           public SeekableTextReader(string content)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Text.SeekableTextReader
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Text.SeekableTextReader.Peek()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int Peek()
    
    .. dn:method:: Microsoft.AspNet.Razor.Text.SeekableTextReader.Read()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int Read()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Text.SeekableTextReader
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Text.SeekableTextReader.Length
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Length { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Text.SeekableTextReader.Location
    
        
        :rtype: Microsoft.AspNet.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
           public SourceLocation Location { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Text.SeekableTextReader.Position
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Position { get; set; }
    

