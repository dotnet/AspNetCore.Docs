

TextChange Struct
=================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Text`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public struct TextChange








.. dn:structure:: Microsoft.AspNetCore.Razor.Text.TextChange
    :hidden:

.. dn:structure:: Microsoft.AspNetCore.Razor.Text.TextChange

Properties
----------

.. dn:structure:: Microsoft.AspNetCore.Razor.Text.TextChange
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Text.TextChange.IsDelete
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsDelete
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Text.TextChange.IsInsert
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsInsert
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Text.TextChange.IsReplace
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsReplace
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Text.TextChange.NewBuffer
    
        
        :rtype: Microsoft.AspNetCore.Razor.Text.ITextBuffer
    
        
        .. code-block:: csharp
    
            public ITextBuffer NewBuffer
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Text.TextChange.NewLength
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int NewLength
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Text.TextChange.NewPosition
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int NewPosition
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Text.TextChange.NewText
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string NewText
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Text.TextChange.OldBuffer
    
        
        :rtype: Microsoft.AspNetCore.Razor.Text.ITextBuffer
    
        
        .. code-block:: csharp
    
            public ITextBuffer OldBuffer
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Text.TextChange.OldLength
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int OldLength
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Text.TextChange.OldPosition
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int OldPosition
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Text.TextChange.OldText
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string OldText
            {
                get;
            }
    

Constructors
------------

.. dn:structure:: Microsoft.AspNetCore.Razor.Text.TextChange
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Text.TextChange.TextChange(System.Int32, System.Int32, Microsoft.AspNetCore.Razor.Text.ITextBuffer, System.Int32, System.Int32, Microsoft.AspNetCore.Razor.Text.ITextBuffer)
    
        
    
        
        :type oldPosition: System.Int32
    
        
        :type oldLength: System.Int32
    
        
        :type oldBuffer: Microsoft.AspNetCore.Razor.Text.ITextBuffer
    
        
        :type newPosition: System.Int32
    
        
        :type newLength: System.Int32
    
        
        :type newBuffer: Microsoft.AspNetCore.Razor.Text.ITextBuffer
    
        
        .. code-block:: csharp
    
            public TextChange(int oldPosition, int oldLength, ITextBuffer oldBuffer, int newPosition, int newLength, ITextBuffer newBuffer)
    

Methods
-------

.. dn:structure:: Microsoft.AspNetCore.Razor.Text.TextChange
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Text.TextChange.ApplyChange(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span)
    
        
    
        
        Applies the text change to the content of the span and returns the new content.
        This method doesn't update the span content.
    
        
    
        
        :type span: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ApplyChange(Span span)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Text.TextChange.ApplyChange(System.String, System.Int32)
    
        
    
        
        :type content: System.String
    
        
        :type changeOffset: System.Int32
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ApplyChange(string content, int changeOffset)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Text.TextChange.Equals(System.Object)
    
        
    
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Text.TextChange.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Text.TextChange.Normalize()
    
        
    
        
        Removes a common prefix from the edit to turn IntelliSense replacements into insertions where possible
    
        
        :rtype: Microsoft.AspNetCore.Razor.Text.TextChange
        :return: A normalized text change
    
        
        .. code-block:: csharp
    
            public TextChange Normalize()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Text.TextChange.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ToString()
    

