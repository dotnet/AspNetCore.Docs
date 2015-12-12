

UnicodeRange Class
==================



.. contents:: 
   :local:



Summary
-------

Represents a contiguous range of Unicode code points.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.WebEncoders.UnicodeRange`








Syntax
------

.. code-block:: csharp

   public sealed class UnicodeRange





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.Extensions.WebEncoders.Core/UnicodeRange.cs>`_





.. dn:class:: Microsoft.Extensions.WebEncoders.UnicodeRange

Constructors
------------

.. dn:class:: Microsoft.Extensions.WebEncoders.UnicodeRange
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.WebEncoders.UnicodeRange.UnicodeRange(System.Int32, System.Int32)
    
        
    
        Creates a new :any:`Microsoft.Extensions.WebEncoders.UnicodeRange`\.
    
        
        
        
        :param firstCodePoint: The first code point in the range.
        
        :type firstCodePoint: System.Int32
        
        
        :param rangeSize: The number of code points in the range.
        
        :type rangeSize: System.Int32
    
        
        .. code-block:: csharp
    
           public UnicodeRange(int firstCodePoint, int rangeSize)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.WebEncoders.UnicodeRange
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.WebEncoders.UnicodeRange.FromSpan(System.Char, System.Char)
    
        
    
        Creates a new :any:`Microsoft.Extensions.WebEncoders.UnicodeRange` from a span of characters.
    
        
        
        
        :param firstChar: The first character in the range.
        
        :type firstChar: System.Char
        
        
        :param lastChar: The last character in the range.
        
        :type lastChar: System.Char
        :rtype: Microsoft.Extensions.WebEncoders.UnicodeRange
        :return: The <see cref="T:Microsoft.Extensions.WebEncoders.UnicodeRange" /> representing this span.
    
        
        .. code-block:: csharp
    
           public static UnicodeRange FromSpan(char firstChar, char lastChar)
    

Properties
----------

.. dn:class:: Microsoft.Extensions.WebEncoders.UnicodeRange
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.WebEncoders.UnicodeRange.FirstCodePoint
    
        
    
        The first code point in this range.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int FirstCodePoint { get; }
    
    .. dn:property:: Microsoft.Extensions.WebEncoders.UnicodeRange.RangeSize
    
        
    
        The number of code points in this range.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int RangeSize { get; }
    

