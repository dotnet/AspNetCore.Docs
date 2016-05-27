

SeekableTextReader Class
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
* :dn:cls:`Microsoft.AspNetCore.Razor.Text.SeekableTextReader`








Syntax
------

.. code-block:: csharp

    public class SeekableTextReader : TextReader, IDisposable, ITextDocument, ITextBuffer








.. dn:class:: Microsoft.AspNetCore.Razor.Text.SeekableTextReader
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Text.SeekableTextReader

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Text.SeekableTextReader
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Text.SeekableTextReader.Length
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Length
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Text.SeekableTextReader.Location
    
        
        :rtype: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
            public SourceLocation Location
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Text.SeekableTextReader.Position
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Position
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Text.SeekableTextReader
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Text.SeekableTextReader.SeekableTextReader(Microsoft.AspNetCore.Razor.Text.ITextBuffer)
    
        
    
        
        :type buffer: Microsoft.AspNetCore.Razor.Text.ITextBuffer
    
        
        .. code-block:: csharp
    
            public SeekableTextReader(ITextBuffer buffer)
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Text.SeekableTextReader.SeekableTextReader(System.IO.TextReader)
    
        
    
        
        :type source: System.IO.TextReader
    
        
        .. code-block:: csharp
    
            public SeekableTextReader(TextReader source)
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Text.SeekableTextReader.SeekableTextReader(System.String)
    
        
    
        
        :type content: System.String
    
        
        .. code-block:: csharp
    
            public SeekableTextReader(string content)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Text.SeekableTextReader
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Text.SeekableTextReader.Peek()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int Peek()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Text.SeekableTextReader.Read()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int Read()
    

