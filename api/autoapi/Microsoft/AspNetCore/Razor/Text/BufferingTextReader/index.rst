

BufferingTextReader Class
=========================





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
* :dn:cls:`Microsoft.AspNetCore.Razor.Text.BufferingTextReader`








Syntax
------

.. code-block:: csharp

    public class BufferingTextReader : LookaheadTextReader, IDisposable








.. dn:class:: Microsoft.AspNetCore.Razor.Text.BufferingTextReader
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Text.BufferingTextReader

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Text.BufferingTextReader
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Text.BufferingTextReader.CurrentCharacter
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            protected virtual int CurrentCharacter
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Text.BufferingTextReader.CurrentLocation
    
        
        :rtype: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
            public override SourceLocation CurrentLocation
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Text.BufferingTextReader
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Text.BufferingTextReader.BufferingTextReader(System.IO.TextReader)
    
        
    
        
        :type source: System.IO.TextReader
    
        
        .. code-block:: csharp
    
            public BufferingTextReader(TextReader source)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Text.BufferingTextReader
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Text.BufferingTextReader.BeginLookahead()
    
        
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
            public override IDisposable BeginLookahead()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Text.BufferingTextReader.CancelBacktrack()
    
        
    
        
        .. code-block:: csharp
    
            public override void CancelBacktrack()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Text.BufferingTextReader.Dispose(System.Boolean)
    
        
    
        
        :type disposing: System.Boolean
    
        
        .. code-block:: csharp
    
            protected override void Dispose(bool disposing)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Text.BufferingTextReader.ExpandBuffer()
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected bool ExpandBuffer()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Text.BufferingTextReader.NextCharacter()
    
        
    
        
        .. code-block:: csharp
    
            protected virtual void NextCharacter()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Text.BufferingTextReader.Peek()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int Peek()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Text.BufferingTextReader.Read()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int Read()
    

