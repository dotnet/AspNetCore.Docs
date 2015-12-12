

TextBufferReader Class
======================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.MarshalByRefObject`
* :dn:cls:`System.IO.TextReader`
* :dn:cls:`Microsoft.AspNet.Razor.Text.LookaheadTextReader`
* :dn:cls:`Microsoft.AspNet.Razor.Text.TextBufferReader`








Syntax
------

.. code-block:: csharp

   public class TextBufferReader : LookaheadTextReader, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/Text/TextBufferReader.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Text.TextBufferReader

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Text.TextBufferReader
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Text.TextBufferReader.TextBufferReader(Microsoft.AspNet.Razor.Text.ITextBuffer)
    
        
        
        
        :type buffer: Microsoft.AspNet.Razor.Text.ITextBuffer
    
        
        .. code-block:: csharp
    
           public TextBufferReader(ITextBuffer buffer)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Text.TextBufferReader
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Text.TextBufferReader.BeginLookahead()
    
        
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
           public override IDisposable BeginLookahead()
    
    .. dn:method:: Microsoft.AspNet.Razor.Text.TextBufferReader.CancelBacktrack()
    
        
    
        
        .. code-block:: csharp
    
           public override void CancelBacktrack()
    
    .. dn:method:: Microsoft.AspNet.Razor.Text.TextBufferReader.Dispose(System.Boolean)
    
        
        
        
        :type disposing: System.Boolean
    
        
        .. code-block:: csharp
    
           protected override void Dispose(bool disposing)
    
    .. dn:method:: Microsoft.AspNet.Razor.Text.TextBufferReader.Peek()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int Peek()
    
    .. dn:method:: Microsoft.AspNet.Razor.Text.TextBufferReader.Read()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int Read()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Text.TextBufferReader
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Text.TextBufferReader.CurrentLocation
    
        
        :rtype: Microsoft.AspNet.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
           public override SourceLocation CurrentLocation { get; }
    

