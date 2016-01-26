

BufferingTextReader Class
=========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.MarshalByRefObject`
* :dn:cls:`System.IO.TextReader`
* :dn:cls:`Microsoft.AspNet.Razor.Text.LookaheadTextReader`
* :dn:cls:`Microsoft.AspNet.Razor.Text.BufferingTextReader`








Syntax
------

.. code-block:: csharp

   public class BufferingTextReader : LookaheadTextReader, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/Text/BufferingTextReader.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Text.BufferingTextReader

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Text.BufferingTextReader
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Text.BufferingTextReader.BufferingTextReader(System.IO.TextReader)
    
        
        
        
        :type source: System.IO.TextReader
    
        
        .. code-block:: csharp
    
           public BufferingTextReader(TextReader source)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Text.BufferingTextReader
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Text.BufferingTextReader.BeginLookahead()
    
        
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
           public override IDisposable BeginLookahead()
    
    .. dn:method:: Microsoft.AspNet.Razor.Text.BufferingTextReader.CancelBacktrack()
    
        
    
        
        .. code-block:: csharp
    
           public override void CancelBacktrack()
    
    .. dn:method:: Microsoft.AspNet.Razor.Text.BufferingTextReader.Dispose(System.Boolean)
    
        
        
        
        :type disposing: System.Boolean
    
        
        .. code-block:: csharp
    
           protected override void Dispose(bool disposing)
    
    .. dn:method:: Microsoft.AspNet.Razor.Text.BufferingTextReader.ExpandBuffer()
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           protected bool ExpandBuffer()
    
    .. dn:method:: Microsoft.AspNet.Razor.Text.BufferingTextReader.NextCharacter()
    
        
    
        
        .. code-block:: csharp
    
           protected virtual void NextCharacter()
    
    .. dn:method:: Microsoft.AspNet.Razor.Text.BufferingTextReader.Peek()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int Peek()
    
    .. dn:method:: Microsoft.AspNet.Razor.Text.BufferingTextReader.Read()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int Read()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Text.BufferingTextReader
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Text.BufferingTextReader.CurrentCharacter
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           protected virtual int CurrentCharacter { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Text.BufferingTextReader.CurrentLocation
    
        
        :rtype: Microsoft.AspNet.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
           public override SourceLocation CurrentLocation { get; }
    

