

Microsoft.Extensions.WebEncoders Namespace
==========================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/Extensions/WebEncoders/CodePointFilter/index
   
   
   
   /autoapi/Microsoft/Extensions/WebEncoders/EncoderExtensions/index
   
   
   
   /autoapi/Microsoft/Extensions/WebEncoders/EncoderServiceProviderExtensions/index
   
   
   
   /autoapi/Microsoft/Extensions/WebEncoders/HtmlEncoder/index
   
   
   
   /autoapi/Microsoft/Extensions/WebEncoders/ICodePointFilter/index
   
   
   
   /autoapi/Microsoft/Extensions/WebEncoders/IHtmlEncoder/index
   
   
   
   /autoapi/Microsoft/Extensions/WebEncoders/IJavaScriptStringEncoder/index
   
   
   
   /autoapi/Microsoft/Extensions/WebEncoders/IUrlEncoder/index
   
   
   
   /autoapi/Microsoft/Extensions/WebEncoders/JavaScriptStringEncoder/index
   
   
   
   /autoapi/Microsoft/Extensions/WebEncoders/UnicodeRange/index
   
   
   
   /autoapi/Microsoft/Extensions/WebEncoders/UnicodeRanges/index
   
   
   
   /autoapi/Microsoft/Extensions/WebEncoders/UrlEncoder/index
   
   
   
   /autoapi/Microsoft/Extensions/WebEncoders/WebEncoderOptions/index
   
   











.. dn:namespace:: Microsoft.Extensions.WebEncoders


    .. rubric:: Classes


    class :dn:cls:`Microsoft.Extensions.WebEncoders.CodePointFilter`
        Represents a filter which allows only certain Unicode code points through.


    class :dn:cls:`Microsoft.Extensions.WebEncoders.EncoderExtensions`
        Helpful extension methods for the encoder classes.


    class :dn:cls:`Microsoft.Extensions.WebEncoders.EncoderServiceProviderExtensions`
        Contains extension methods for fetching encoders from an :any:`System.IServiceProvider`\.


    class :dn:cls:`Microsoft.Extensions.WebEncoders.HtmlEncoder`
        A class which can perform HTML encoding given an allow list of characters which
        can be represented unencoded.


    class :dn:cls:`Microsoft.Extensions.WebEncoders.JavaScriptStringEncoder`
        A class which can perform JavaScript string escaping given an allow list of characters which
        can be represented unescaped.


    class :dn:cls:`Microsoft.Extensions.WebEncoders.UnicodeRange`
        Represents a contiguous range of Unicode code points.


    class :dn:cls:`Microsoft.Extensions.WebEncoders.UnicodeRanges`
        Contains predefined :any:`Microsoft.Extensions.WebEncoders.UnicodeRange` instances which correspond to blocks
        from the Unicode 8.0 specification.


    class :dn:cls:`Microsoft.Extensions.WebEncoders.UrlEncoder`
        A class which can perform URL string escaping given an allow list of characters which
        can be represented unescaped.


    class :dn:cls:`Microsoft.Extensions.WebEncoders.WebEncoderOptions`
        Specifies options common to all three encoders (HtmlEncode, JavaScriptStringEncode, UrlEncode).


    .. rubric:: Interfaces


    interface :dn:iface:`Microsoft.Extensions.WebEncoders.ICodePointFilter`
        Represents a filter which allows only certain Unicode code points through.


    interface :dn:iface:`Microsoft.Extensions.WebEncoders.IHtmlEncoder`
        Provides services for HTML-encoding input.


    interface :dn:iface:`Microsoft.Extensions.WebEncoders.IJavaScriptStringEncoder`
        Provides services for JavaScript-escaping strings.


    interface :dn:iface:`Microsoft.Extensions.WebEncoders.IUrlEncoder`
        Provides services for URL-escaping strings.


