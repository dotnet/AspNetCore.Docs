

TextChange Struct
=================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public struct TextChange





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/Text/TextChange.cs>`_





.. dn:structure:: Microsoft.AspNet.Razor.Text.TextChange

Constructors
------------

.. dn:structure:: Microsoft.AspNet.Razor.Text.TextChange
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Text.TextChange.TextChange(System.Int32, System.Int32, Microsoft.AspNet.Razor.Text.ITextBuffer, System.Int32, System.Int32, Microsoft.AspNet.Razor.Text.ITextBuffer)
    
        
        
        
        :type oldPosition: System.Int32
        
        
        :type oldLength: System.Int32
        
        
        :type oldBuffer: Microsoft.AspNet.Razor.Text.ITextBuffer
        
        
        :type newPosition: System.Int32
        
        
        :type newLength: System.Int32
        
        
        :type newBuffer: Microsoft.AspNet.Razor.Text.ITextBuffer
    
        
        .. code-block:: csharp
    
           public TextChange(int oldPosition, int oldLength, ITextBuffer oldBuffer, int newPosition, int newLength, ITextBuffer newBuffer)
    

Methods
-------

.. dn:structure:: Microsoft.AspNet.Razor.Text.TextChange
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Text.TextChange.ApplyChange(Microsoft.AspNet.Razor.Parser.SyntaxTree.Span)
    
        
    
        Applies the text change to the content of the span and returns the new content.
        This method doesn't update the span content.
    
        
        
        
        :type span: Microsoft.AspNet.Razor.Parser.SyntaxTree.Span
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ApplyChange(Span span)
    
    .. dn:method:: Microsoft.AspNet.Razor.Text.TextChange.ApplyChange(System.String, System.Int32)
    
        
        
        
        :type content: System.String
        
        
        :type changeOffset: System.Int32
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ApplyChange(string content, int changeOffset)
    
    .. dn:method:: Microsoft.AspNet.Razor.Text.TextChange.Equals(System.Object)
    
        
        
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNet.Razor.Text.TextChange.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNet.Razor.Text.TextChange.Normalize()
    
        
    
        Removes a common prefix from the edit to turn IntelliSense replacements into insertions where possible
    
        
        :rtype: Microsoft.AspNet.Razor.Text.TextChange
        :return: A normalized text change
    
        
        .. code-block:: csharp
    
           public TextChange Normalize()
    
    .. dn:method:: Microsoft.AspNet.Razor.Text.TextChange.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string ToString()
    

Properties
----------

.. dn:structure:: Microsoft.AspNet.Razor.Text.TextChange
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Text.TextChange.IsDelete
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsDelete { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Text.TextChange.IsInsert
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsInsert { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Text.TextChange.IsReplace
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsReplace { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Text.TextChange.NewBuffer
    
        
        :rtype: Microsoft.AspNet.Razor.Text.ITextBuffer
    
        
        .. code-block:: csharp
    
           public ITextBuffer NewBuffer { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Text.TextChange.NewLength
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int NewLength { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Text.TextChange.NewPosition
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int NewPosition { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Text.TextChange.NewText
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string NewText { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Text.TextChange.OldBuffer
    
        
        :rtype: Microsoft.AspNet.Razor.Text.ITextBuffer
    
        
        .. code-block:: csharp
    
           public ITextBuffer OldBuffer { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Text.TextChange.OldLength
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int OldLength { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Text.TextChange.OldPosition
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int OldPosition { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Text.TextChange.OldText
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string OldText { get; }
    

