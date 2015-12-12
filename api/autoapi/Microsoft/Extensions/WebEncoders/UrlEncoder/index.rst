

UrlEncoder Class
================



.. contents:: 
   :local:



Summary
-------

A class which can perform URL string escaping given an allow list of characters which
can be represented unescaped.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.WebEncoders.UrlEncoder`








Syntax
------

.. code-block:: csharp

   public sealed class UrlEncoder : IUrlEncoder





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.Extensions.WebEncoders.Core/UrlEncoder.cs>`_





.. dn:class:: Microsoft.Extensions.WebEncoders.UrlEncoder

Constructors
------------

.. dn:class:: Microsoft.Extensions.WebEncoders.UrlEncoder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.WebEncoders.UrlEncoder.UrlEncoder()
    
        
    
        Instantiates an encoder using :dn:prop:`Microsoft.Extensions.WebEncoders.UnicodeRanges.BasicLatin` as its allow list.
        Any character not in the :dn:prop:`Microsoft.Extensions.WebEncoders.UnicodeRanges.BasicLatin` range will be escaped.
    
        
    
        
        .. code-block:: csharp
    
           public UrlEncoder()
    
    .. dn:constructor:: Microsoft.Extensions.WebEncoders.UrlEncoder.UrlEncoder(Microsoft.Extensions.WebEncoders.ICodePointFilter)
    
        
    
        Instantiates an encoder using a custom code point filter. Any character not in the
        set returned by ``filter``'s :dn:meth:`Microsoft.Extensions.WebEncoders.ICodePointFilter.GetAllowedCodePoints`
        method will be escaped.
    
        
        
        
        :type filter: Microsoft.Extensions.WebEncoders.ICodePointFilter
    
        
        .. code-block:: csharp
    
           public UrlEncoder(ICodePointFilter filter)
    
    .. dn:constructor:: Microsoft.Extensions.WebEncoders.UrlEncoder.UrlEncoder(Microsoft.Extensions.WebEncoders.UnicodeRange[])
    
        
    
        Instantiates an encoder specifying which Unicode character ranges are allowed to
        pass through the encoder unescaped. Any character not in the set of ranges specified
        by ``allowedRanges`` will be escaped.
    
        
        
        
        :type allowedRanges: Microsoft.Extensions.WebEncoders.UnicodeRange[]
    
        
        .. code-block:: csharp
    
           public UrlEncoder(params UnicodeRange[] allowedRanges)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.WebEncoders.UrlEncoder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.WebEncoders.UrlEncoder.UrlEncode(System.Char[], System.Int32, System.Int32, System.IO.TextWriter)
    
        
    
        Everybody's favorite UrlEncode routine.
    
        
        
        
        :type value: System.Char[]
        
        
        :type startIndex: System.Int32
        
        
        :type charCount: System.Int32
        
        
        :type output: System.IO.TextWriter
    
        
        .. code-block:: csharp
    
           public void UrlEncode(char[] value, int startIndex, int charCount, TextWriter output)
    
    .. dn:method:: Microsoft.Extensions.WebEncoders.UrlEncoder.UrlEncode(System.String)
    
        
    
        Everybody's favorite UrlEncode routine.
    
        
        
        
        :type value: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string UrlEncode(string value)
    
    .. dn:method:: Microsoft.Extensions.WebEncoders.UrlEncoder.UrlEncode(System.String, System.Int32, System.Int32, System.IO.TextWriter)
    
        
    
        Everybody's favorite UrlEncode routine.
    
        
        
        
        :type value: System.String
        
        
        :type startIndex: System.Int32
        
        
        :type charCount: System.Int32
        
        
        :type output: System.IO.TextWriter
    
        
        .. code-block:: csharp
    
           public void UrlEncode(string value, int startIndex, int charCount, TextWriter output)
    

Properties
----------

.. dn:class:: Microsoft.Extensions.WebEncoders.UrlEncoder
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.WebEncoders.UrlEncoder.Default
    
        
    
        A default instance of :any:`Microsoft.Extensions.WebEncoders.UrlEncoder`\.
    
        
        :rtype: Microsoft.Extensions.WebEncoders.UrlEncoder
    
        
        .. code-block:: csharp
    
           public static UrlEncoder Default { get; set; }
    

