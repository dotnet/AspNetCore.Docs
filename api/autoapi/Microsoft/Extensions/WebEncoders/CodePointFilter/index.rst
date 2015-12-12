

CodePointFilter Class
=====================



.. contents:: 
   :local:



Summary
-------

Represents a filter which allows only certain Unicode code points through.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.WebEncoders.CodePointFilter`








Syntax
------

.. code-block:: csharp

   public sealed class CodePointFilter : ICodePointFilter





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.Extensions.WebEncoders.Core/CodePointFilter.cs>`_





.. dn:class:: Microsoft.Extensions.WebEncoders.CodePointFilter

Constructors
------------

.. dn:class:: Microsoft.Extensions.WebEncoders.CodePointFilter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.WebEncoders.CodePointFilter.CodePointFilter()
    
        
    
        Instantiates an empty filter (allows no code points through by default).
    
        
    
        
        .. code-block:: csharp
    
           public CodePointFilter()
    
    .. dn:constructor:: Microsoft.Extensions.WebEncoders.CodePointFilter.CodePointFilter(Microsoft.Extensions.WebEncoders.ICodePointFilter)
    
        
    
        Instantiates the filter by cloning the allow list of another :any:`Microsoft.Extensions.WebEncoders.ICodePointFilter`\.
    
        
        
        
        :type other: Microsoft.Extensions.WebEncoders.ICodePointFilter
    
        
        .. code-block:: csharp
    
           public CodePointFilter(ICodePointFilter other)
    
    .. dn:constructor:: Microsoft.Extensions.WebEncoders.CodePointFilter.CodePointFilter(Microsoft.Extensions.WebEncoders.UnicodeRange[])
    
        
    
        Instantiates the filter where only the character ranges specified by ``allowedRanges``
        are allowed by the filter.
    
        
        
        
        :type allowedRanges: Microsoft.Extensions.WebEncoders.UnicodeRange[]
    
        
        .. code-block:: csharp
    
           public CodePointFilter(params UnicodeRange[] allowedRanges)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.WebEncoders.CodePointFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.WebEncoders.CodePointFilter.AllowChar(System.Char)
    
        
    
        Allows the character specified by ``c`` through the filter.
    
        
        
        
        :type c: System.Char
        :rtype: Microsoft.Extensions.WebEncoders.CodePointFilter
        :return: The 'this' instance.
    
        
        .. code-block:: csharp
    
           public CodePointFilter AllowChar(char c)
    
    .. dn:method:: Microsoft.Extensions.WebEncoders.CodePointFilter.AllowChars(System.Char[])
    
        
    
        Allows all characters specified by ``chars`` through the filter.
    
        
        
        
        :type chars: System.Char[]
        :rtype: Microsoft.Extensions.WebEncoders.CodePointFilter
        :return: The 'this' instance.
    
        
        .. code-block:: csharp
    
           public CodePointFilter AllowChars(params char[] chars)
    
    .. dn:method:: Microsoft.Extensions.WebEncoders.CodePointFilter.AllowChars(System.String)
    
        
    
        Allows all characters in the string ``chars`` through the filter.
    
        
        
        
        :type chars: System.String
        :rtype: Microsoft.Extensions.WebEncoders.CodePointFilter
        :return: The 'this' instance.
    
        
        .. code-block:: csharp
    
           public CodePointFilter AllowChars(string chars)
    
    .. dn:method:: Microsoft.Extensions.WebEncoders.CodePointFilter.AllowFilter(Microsoft.Extensions.WebEncoders.ICodePointFilter)
    
        
    
        Allows all characters specified by ``filter`` through the filter.
    
        
        
        
        :type filter: Microsoft.Extensions.WebEncoders.ICodePointFilter
        :rtype: Microsoft.Extensions.WebEncoders.CodePointFilter
        :return: The 'this' instance.
    
        
        .. code-block:: csharp
    
           public CodePointFilter AllowFilter(ICodePointFilter filter)
    
    .. dn:method:: Microsoft.Extensions.WebEncoders.CodePointFilter.AllowRange(Microsoft.Extensions.WebEncoders.UnicodeRange)
    
        
    
        Allows all characters specified by ``range`` through the filter.
    
        
        
        
        :type range: Microsoft.Extensions.WebEncoders.UnicodeRange
        :rtype: Microsoft.Extensions.WebEncoders.CodePointFilter
        :return: The 'this' instance.
    
        
        .. code-block:: csharp
    
           public CodePointFilter AllowRange(UnicodeRange range)
    
    .. dn:method:: Microsoft.Extensions.WebEncoders.CodePointFilter.AllowRanges(Microsoft.Extensions.WebEncoders.UnicodeRange[])
    
        
    
        Allows all characters specified by ``ranges`` through the filter.
    
        
        
        
        :type ranges: Microsoft.Extensions.WebEncoders.UnicodeRange[]
        :rtype: Microsoft.Extensions.WebEncoders.CodePointFilter
        :return: The 'this' instance.
    
        
        .. code-block:: csharp
    
           public CodePointFilter AllowRanges(params UnicodeRange[] ranges)
    
    .. dn:method:: Microsoft.Extensions.WebEncoders.CodePointFilter.Clear()
    
        
    
        Resets this filter by disallowing all characters.
    
        
        :rtype: Microsoft.Extensions.WebEncoders.CodePointFilter
        :return: The 'this' instance.
    
        
        .. code-block:: csharp
    
           public CodePointFilter Clear()
    
    .. dn:method:: Microsoft.Extensions.WebEncoders.CodePointFilter.ForbidChar(System.Char)
    
        
    
        Disallows the character ``c`` through the filter.
    
        
        
        
        :type c: System.Char
        :rtype: Microsoft.Extensions.WebEncoders.CodePointFilter
        :return: The 'this' instance.
    
        
        .. code-block:: csharp
    
           public CodePointFilter ForbidChar(char c)
    
    .. dn:method:: Microsoft.Extensions.WebEncoders.CodePointFilter.ForbidChars(System.Char[])
    
        
    
        Disallows all characters specified by ``chars`` through the filter.
    
        
        
        
        :type chars: System.Char[]
        :rtype: Microsoft.Extensions.WebEncoders.CodePointFilter
        :return: The 'this' instance.
    
        
        .. code-block:: csharp
    
           public CodePointFilter ForbidChars(params char[] chars)
    
    .. dn:method:: Microsoft.Extensions.WebEncoders.CodePointFilter.ForbidChars(System.String)
    
        
    
        Disallows all characters in the string ``chars`` through the filter.
    
        
        
        
        :type chars: System.String
        :rtype: Microsoft.Extensions.WebEncoders.CodePointFilter
        :return: The 'this' instance.
    
        
        .. code-block:: csharp
    
           public CodePointFilter ForbidChars(string chars)
    
    .. dn:method:: Microsoft.Extensions.WebEncoders.CodePointFilter.ForbidRange(Microsoft.Extensions.WebEncoders.UnicodeRange)
    
        
    
        Disallows all characters specified by ``range`` through the filter.
    
        
        
        
        :type range: Microsoft.Extensions.WebEncoders.UnicodeRange
        :rtype: Microsoft.Extensions.WebEncoders.CodePointFilter
        :return: The 'this' instance.
    
        
        .. code-block:: csharp
    
           public CodePointFilter ForbidRange(UnicodeRange range)
    
    .. dn:method:: Microsoft.Extensions.WebEncoders.CodePointFilter.ForbidRanges(Microsoft.Extensions.WebEncoders.UnicodeRange[])
    
        
    
        Disallows all characters specified by ``ranges`` through the filter.
    
        
        
        
        :type ranges: Microsoft.Extensions.WebEncoders.UnicodeRange[]
        :rtype: Microsoft.Extensions.WebEncoders.CodePointFilter
        :return: The 'this' instance.
    
        
        .. code-block:: csharp
    
           public CodePointFilter ForbidRanges(params UnicodeRange[] ranges)
    
    .. dn:method:: Microsoft.Extensions.WebEncoders.CodePointFilter.GetAllowedCodePoints()
    
        
    
        Gets an enumeration of all allowed code points.
    
        
        :rtype: System.Collections.Generic.IEnumerable{System.Int32}
    
        
        .. code-block:: csharp
    
           public IEnumerable<int> GetAllowedCodePoints()
    
    .. dn:method:: Microsoft.Extensions.WebEncoders.CodePointFilter.IsCharacterAllowed(System.Char)
    
        
    
        Returns a value stating whether the character ``c`` is allowed through the filter.
    
        
        
        
        :type c: System.Char
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsCharacterAllowed(char c)
    

