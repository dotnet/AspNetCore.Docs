

SourceLocation Struct
=====================



.. contents:: 
   :local:



Summary
-------

A location in a Razor file.











Syntax
------

.. code-block:: csharp

   public struct SourceLocation : IEquatable<SourceLocation>, IComparable<SourceLocation>





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/SourceLocation.cs>`_





.. dn:structure:: Microsoft.AspNet.Razor.SourceLocation

Constructors
------------

.. dn:structure:: Microsoft.AspNet.Razor.SourceLocation
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.SourceLocation.SourceLocation(System.Int32, System.Int32, System.Int32)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Razor.SourceLocation`\.
    
        
        
        
        :param absoluteIndex: The absolute index.
        
        :type absoluteIndex: System.Int32
        
        
        :param lineIndex: The line index.
        
        :type lineIndex: System.Int32
        
        
        :param characterIndex: The character index.
        
        :type characterIndex: System.Int32
    
        
        .. code-block:: csharp
    
           public SourceLocation(int absoluteIndex, int lineIndex, int characterIndex)
    
    .. dn:constructor:: Microsoft.AspNet.Razor.SourceLocation.SourceLocation(System.String, System.Int32, System.Int32, System.Int32)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Razor.SourceLocation`\.
    
        
        
        
        :param filePath: The file path.
        
        :type filePath: System.String
        
        
        :param absoluteIndex: The absolute index.
        
        :type absoluteIndex: System.Int32
        
        
        :param lineIndex: The line index.
        
        :type lineIndex: System.Int32
        
        
        :param characterIndex: The character index.
        
        :type characterIndex: System.Int32
    
        
        .. code-block:: csharp
    
           public SourceLocation(string filePath, int absoluteIndex, int lineIndex, int characterIndex)
    

Methods
-------

.. dn:structure:: Microsoft.AspNet.Razor.SourceLocation
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.SourceLocation.Advance(Microsoft.AspNet.Razor.SourceLocation, System.String)
    
        
    
        Advances the :any:`Microsoft.AspNet.Razor.SourceLocation` by the length of the ``text``.
    
        
        
        
        :param left: The  to advance.
        
        :type left: Microsoft.AspNet.Razor.SourceLocation
        
        
        :param text: The  to advance  by.
        
        :type text: System.String
        :rtype: Microsoft.AspNet.Razor.SourceLocation
        :return: The advanced <see cref="T:Microsoft.AspNet.Razor.SourceLocation" />.
    
        
        .. code-block:: csharp
    
           public static SourceLocation Advance(SourceLocation left, string text)
    
    .. dn:method:: Microsoft.AspNet.Razor.SourceLocation.CompareTo(Microsoft.AspNet.Razor.SourceLocation)
    
        
        
        
        :type other: Microsoft.AspNet.Razor.SourceLocation
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int CompareTo(SourceLocation other)
    
    .. dn:method:: Microsoft.AspNet.Razor.SourceLocation.Equals(Microsoft.AspNet.Razor.SourceLocation)
    
        
        
        
        :type other: Microsoft.AspNet.Razor.SourceLocation
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Equals(SourceLocation other)
    
    .. dn:method:: Microsoft.AspNet.Razor.SourceLocation.Equals(System.Object)
    
        
        
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNet.Razor.SourceLocation.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNet.Razor.SourceLocation.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string ToString()
    

Fields
------

.. dn:structure:: Microsoft.AspNet.Razor.SourceLocation
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Razor.SourceLocation.Undefined
    
        
    
        An undefined :any:`Microsoft.AspNet.Razor.SourceLocation`\.
    
        
    
        
        .. code-block:: csharp
    
           public static readonly SourceLocation Undefined
    
    .. dn:field:: Microsoft.AspNet.Razor.SourceLocation.Zero
    
        
    
        A :any:`Microsoft.AspNet.Razor.SourceLocation` with :dn:prop:`Microsoft.AspNet.Razor.SourceLocation.AbsoluteIndex`\, :dn:prop:`Microsoft.AspNet.Razor.SourceLocation.LineIndex`\, and 
        :dn:prop:`Microsoft.AspNet.Razor.SourceLocation.CharacterIndex` initialized to 0.
    
        
    
        
        .. code-block:: csharp
    
           public static readonly SourceLocation Zero
    

Properties
----------

.. dn:structure:: Microsoft.AspNet.Razor.SourceLocation
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.SourceLocation.AbsoluteIndex
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int AbsoluteIndex { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.SourceLocation.CharacterIndex
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int CharacterIndex { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.SourceLocation.FilePath
    
        
    
        Path of the file.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string FilePath { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.SourceLocation.LineIndex
    
        
    
        Gets the 1-based index of the line referred to by this Source Location.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int LineIndex { get; set; }
    

