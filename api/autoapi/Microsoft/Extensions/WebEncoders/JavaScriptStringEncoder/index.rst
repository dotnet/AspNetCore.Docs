

JavaScriptStringEncoder Class
=============================



.. contents:: 
   :local:



Summary
-------

A class which can perform JavaScript string escaping given an allow list of characters which
can be represented unescaped.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.WebEncoders.JavaScriptStringEncoder`








Syntax
------

.. code-block:: csharp

   public sealed class JavaScriptStringEncoder : IJavaScriptStringEncoder





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.Extensions.WebEncoders.Core/JavaScriptStringEncoder.cs>`_





.. dn:class:: Microsoft.Extensions.WebEncoders.JavaScriptStringEncoder

Constructors
------------

.. dn:class:: Microsoft.Extensions.WebEncoders.JavaScriptStringEncoder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.WebEncoders.JavaScriptStringEncoder.JavaScriptStringEncoder()
    
        
    
        Instantiates an encoder using :dn:prop:`Microsoft.Extensions.WebEncoders.UnicodeRanges.BasicLatin` as its allow list.
        Any character not in the :dn:prop:`Microsoft.Extensions.WebEncoders.UnicodeRanges.BasicLatin` range will be escaped.
    
        
    
        
        .. code-block:: csharp
    
           public JavaScriptStringEncoder()
    
    .. dn:constructor:: Microsoft.Extensions.WebEncoders.JavaScriptStringEncoder.JavaScriptStringEncoder(Microsoft.Extensions.WebEncoders.ICodePointFilter)
    
        
    
        Instantiates an encoder using a custom code point filter. Any character not in the
        set returned by ``filter``'s :dn:meth:`Microsoft.Extensions.WebEncoders.ICodePointFilter.GetAllowedCodePoints`
        method will be escaped.
    
        
        
        
        :type filter: Microsoft.Extensions.WebEncoders.ICodePointFilter
    
        
        .. code-block:: csharp
    
           public JavaScriptStringEncoder(ICodePointFilter filter)
    
    .. dn:constructor:: Microsoft.Extensions.WebEncoders.JavaScriptStringEncoder.JavaScriptStringEncoder(Microsoft.Extensions.WebEncoders.UnicodeRange[])
    
        
    
        Instantiates an encoder specifying which Unicode character ranges are allowed to
        pass through the encoder unescaped. Any character not in the set of ranges specified
        by ``allowedRanges`` will be escaped.
    
        
        
        
        :type allowedRanges: Microsoft.Extensions.WebEncoders.UnicodeRange[]
    
        
        .. code-block:: csharp
    
           public JavaScriptStringEncoder(params UnicodeRange[] allowedRanges)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.WebEncoders.JavaScriptStringEncoder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.WebEncoders.JavaScriptStringEncoder.JavaScriptStringEncode(System.Char[], System.Int32, System.Int32, System.IO.TextWriter)
    
        
    
        Everybody's favorite JavaScriptStringEncode routine.
    
        
        
        
        :type value: System.Char[]
        
        
        :type startIndex: System.Int32
        
        
        :type charCount: System.Int32
        
        
        :type output: System.IO.TextWriter
    
        
        .. code-block:: csharp
    
           public void JavaScriptStringEncode(char[] value, int startIndex, int charCount, TextWriter output)
    
    .. dn:method:: Microsoft.Extensions.WebEncoders.JavaScriptStringEncoder.JavaScriptStringEncode(System.String)
    
        
    
        Everybody's favorite JavaScriptStringEncode routine.
    
        
        
        
        :type value: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string JavaScriptStringEncode(string value)
    
    .. dn:method:: Microsoft.Extensions.WebEncoders.JavaScriptStringEncoder.JavaScriptStringEncode(System.String, System.Int32, System.Int32, System.IO.TextWriter)
    
        
    
        Everybody's favorite JavaScriptStringEncode routine.
    
        
        
        
        :type value: System.String
        
        
        :type startIndex: System.Int32
        
        
        :type charCount: System.Int32
        
        
        :type output: System.IO.TextWriter
    
        
        .. code-block:: csharp
    
           public void JavaScriptStringEncode(string value, int startIndex, int charCount, TextWriter output)
    

Properties
----------

.. dn:class:: Microsoft.Extensions.WebEncoders.JavaScriptStringEncoder
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.WebEncoders.JavaScriptStringEncoder.Default
    
        
    
        A default instance of :any:`Microsoft.Extensions.WebEncoders.JavaScriptStringEncoder`\.
    
        
        :rtype: Microsoft.Extensions.WebEncoders.JavaScriptStringEncoder
    
        
        .. code-block:: csharp
    
           public static JavaScriptStringEncoder Default { get; set; }
    

