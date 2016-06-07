

NullHtmlEncoder Class
=====================






A :any:`System.Text.Encodings.Web.HtmlEncoder` that does not encode. Should not be used when writing directly to a response
expected to contain valid HTML.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.TagHelpers`
Assemblies
    * Microsoft.AspNetCore.Razor.Runtime

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Text.Encodings.Web.TextEncoder`
* :dn:cls:`System.Text.Encodings.Web.HtmlEncoder`
* :dn:cls:`Microsoft.AspNetCore.Razor.TagHelpers.NullHtmlEncoder`








Syntax
------

.. code-block:: csharp

    public class NullHtmlEncoder : HtmlEncoder








.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.NullHtmlEncoder
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.NullHtmlEncoder

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.NullHtmlEncoder
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.TagHelpers.NullHtmlEncoder.Default
    
        
    
        
        A :any:`System.Text.Encodings.Web.HtmlEncoder` instance that does not encode. Should not be used when writing directly to a
        response expected to contain valid HTML.
    
        
        :rtype: Microsoft.AspNetCore.Razor.TagHelpers.NullHtmlEncoder
    
        
        .. code-block:: csharp
    
            public static NullHtmlEncoder Default
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.TagHelpers.NullHtmlEncoder.MaxOutputCharactersPerInputCharacter
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int MaxOutputCharactersPerInputCharacter
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.NullHtmlEncoder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.TagHelpers.NullHtmlEncoder.NullHtmlEncoder()
    
        
    
        
        Initializes a :any:`Microsoft.AspNetCore.Razor.TagHelpers.NullHtmlEncoder` instance.
    
        
    
        
        .. code-block:: csharp
    
            protected NullHtmlEncoder()
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.NullHtmlEncoder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.NullHtmlEncoder.Encode(System.IO.TextWriter, System.Char[], System.Int32, System.Int32)
    
        
    
        
        :type output: System.IO.TextWriter
    
        
        :type value: System.Char<System.Char>[]
    
        
        :type startIndex: System.Int32
    
        
        :type characterCount: System.Int32
    
        
        .. code-block:: csharp
    
            public override void Encode(TextWriter output, char[] value, int startIndex, int characterCount)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.NullHtmlEncoder.Encode(System.IO.TextWriter, System.String, System.Int32, System.Int32)
    
        
    
        
        :type output: System.IO.TextWriter
    
        
        :type value: System.String
    
        
        :type startIndex: System.Int32
    
        
        :type characterCount: System.Int32
    
        
        .. code-block:: csharp
    
            public override void Encode(TextWriter output, string value, int startIndex, int characterCount)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.NullHtmlEncoder.Encode(System.String)
    
        
    
        
        :type value: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string Encode(string value)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.NullHtmlEncoder.FindFirstCharacterToEncode(System.Char*, System.Int32)
    
        
    
        
        :type text: System.Char<System.Char>*
    
        
        :type textLength: System.Int32
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int FindFirstCharacterToEncode(char *text, int textLength)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.NullHtmlEncoder.TryEncodeUnicodeScalar(System.Int32, System.Char*, System.Int32, out System.Int32)
    
        
    
        
        :type unicodeScalar: System.Int32
    
        
        :type buffer: System.Char<System.Char>*
    
        
        :type bufferLength: System.Int32
    
        
        :type numberOfCharactersWritten: System.Int32
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool TryEncodeUnicodeScalar(int unicodeScalar, char *buffer, int bufferLength, out int numberOfCharactersWritten)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.NullHtmlEncoder.WillEncode(System.Int32)
    
        
    
        
        :type unicodeScalar: System.Int32
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool WillEncode(int unicodeScalar)
    

