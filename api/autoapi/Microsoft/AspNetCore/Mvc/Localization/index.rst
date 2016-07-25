

Microsoft.AspNetCore.Mvc.Localization Namespace
===============================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Localization/HtmlLocalizer/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Localization/HtmlLocalizerExtensions/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Localization/HtmlLocalizerFactory/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Localization/HtmlLocalizer-TResource/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Localization/IHtmlLocalizer/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Localization/IHtmlLocalizerFactory/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Localization/IHtmlLocalizer-TResource/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Localization/IViewLocalizer/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Localization/LocalizedHtmlString/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Localization/ViewLocalizer/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.Mvc.Localization


    .. rubric:: Interfaces


    interface :dn:iface:`IHtmlLocalizer`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer

        
        Represents a type that that does HTML-aware localization of strings, by HTML encoding arguments that are
        formatted in the resource string.


    interface :dn:iface:`IHtmlLocalizerFactory`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizerFactory

        
        A factory that creates :any:`Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer` instances.


    interface :dn:iface:`IHtmlLocalizer\<TResource>`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer\<TResource>

        
        An :any:`Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer` that provides localized HTML content.


    interface :dn:iface:`IViewLocalizer`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Localization.IViewLocalizer

        
        Represents a type that provides HTML-aware localization for views.


    .. rubric:: Classes


    class :dn:cls:`HtmlLocalizer`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizer

        
        An :any:`Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer` that uses the provided :any:`Microsoft.Extensions.Localization.IStringLocalizer` to do HTML-aware
        localization of content.


    class :dn:cls:`HtmlLocalizerExtensions`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizerExtensions

        
        Extension methods for :any:`Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer`\.


    class :dn:cls:`HtmlLocalizerFactory`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizerFactory

        
        An :any:`Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizerFactory` that creates instances of :any:`Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizer` using the
        registered :any:`Microsoft.Extensions.Localization.IStringLocalizerFactory`\.


    class :dn:cls:`HtmlLocalizer\<TResource>`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizer\<TResource>

        
        An :any:`Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer` implementation that provides localized HTML content for the specified type
        <em>TResource</em>.


    class :dn:cls:`LocalizedHtmlString`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Localization.LocalizedHtmlString

        
        An :any:`Microsoft.AspNetCore.Html.IHtmlContent` with localized content.


    class :dn:cls:`ViewLocalizer`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Localization.ViewLocalizer

        
        An :any:`Microsoft.AspNetCore.Mvc.Localization.IViewLocalizer` implementation that derives the resource location from the executing view's
        file path.


