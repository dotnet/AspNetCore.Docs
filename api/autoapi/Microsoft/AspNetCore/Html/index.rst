

Microsoft.AspNetCore.Html Namespace
===================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/Html/HtmlContentBuilder/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Html/HtmlContentBuilderExtensions/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Html/HtmlEncodedString/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Html/HtmlFormattableString/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Html/IHtmlContent/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Html/IHtmlContentBuilder/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Html/IHtmlContentContainer/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.Html


    .. rubric:: Classes


    class :dn:cls:`HtmlContentBuilder`
        .. object: type=class name=Microsoft.AspNetCore.Html.HtmlContentBuilder

        
        An :any:`Microsoft.AspNetCore.Html.IHtmlContentBuilder` implementation using an in memory list.


    class :dn:cls:`HtmlContentBuilderExtensions`
        .. object: type=class name=Microsoft.AspNetCore.Html.HtmlContentBuilderExtensions

        
        Extension methods for :any:`Microsoft.AspNetCore.Html.IHtmlContentBuilder`\.


    class :dn:cls:`HtmlEncodedString`
        .. object: type=class name=Microsoft.AspNetCore.Html.HtmlEncodedString

        
        An :any:`Microsoft.AspNetCore.Html.IHtmlContent` implementation that wraps an HTML encoded :any:`System.String`\.


    class :dn:cls:`HtmlFormattableString`
        .. object: type=class name=Microsoft.AspNetCore.Html.HtmlFormattableString

        
        An :any:`Microsoft.AspNetCore.Html.IHtmlContent` implementation of composite string formatting 
        (see https://msdn.microsoft.com/en-us/library/txafckwd(v=vs.110).aspx) which HTML encodes
        formatted arguments.


    .. rubric:: Interfaces


    interface :dn:iface:`IHtmlContent`
        .. object: type=interface name=Microsoft.AspNetCore.Html.IHtmlContent

        
        HTML content which can be written to a TextWriter.


    interface :dn:iface:`IHtmlContentBuilder`
        .. object: type=interface name=Microsoft.AspNetCore.Html.IHtmlContentBuilder

        
        A builder for HTML content.


    interface :dn:iface:`IHtmlContentContainer`
        .. object: type=interface name=Microsoft.AspNetCore.Html.IHtmlContentContainer

        
        Defines a contract for :any:`Microsoft.AspNetCore.Html.IHtmlContent` instances made up of several components which
        can be copied into an :any:`Microsoft.AspNetCore.Html.IHtmlContentBuilder`\.


