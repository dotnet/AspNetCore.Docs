

TextBufferReader Class
======================





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
* :dn:cls:`Microsoft.AspNetCore.Razor.Text.LookaheadTextReader`
* :dn:cls:`Microsoft.AspNetCore.Razor.Text.TextBufferReader`








Syntax
------

.. code-block:: csharp

    public class TextBufferReader : LookaheadTextReader, IDisposable








.. dn:class:: Microsoft.AspNetCore.Razor.Text.TextBufferReader
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Text.TextBufferReader

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Text.TextBufferReader
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Text.TextBufferReader.CurrentLocation
    
        
        :rtype: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
            public override SourceLocation CurrentLocation
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Text.TextBufferReader
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Text.TextBufferReader.TextBufferReader(Microsoft.AspNetCore.Razor.Text.ITextBuffer)
    
        
    
        
        :type buffer: Microsoft.AspNetCore.Razor.Text.ITextBuffer
    
        
        .. code-block:: csharp
    
            public TextBufferReader(ITextBuffer buffer)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Text.TextBufferReader
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Text.TextBufferReader.BeginLookahead()
    
        
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
            public override IDisposable BeginLookahead()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Text.TextBufferReader.CancelBacktrack()
    
        
    
        
        .. code-block:: csharp
    
            public override void CancelBacktrack()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Text.TextBufferReader.Dispose(System.Boolean)
    
        
    
        
        :type disposing: System.Boolean
    
        
        .. code-block:: csharp
    
            protected override void Dispose(bool disposing)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Text.TextBufferReader.Peek()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int Peek()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Text.TextBufferReader.Read()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int Read()
    

