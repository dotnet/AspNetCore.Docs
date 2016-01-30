

Microsoft.AspNet.Mvc.Localization Namespace
===========================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNet/Mvc/Localization/HtmlLocalizer/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Localization/HtmlLocalizerFactory/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Localization/HtmlLocalizer-TResource/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Localization/IHtmlLocalizer/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Localization/IHtmlLocalizerFactory/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Localization/IHtmlLocalizer-TResource/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Localization/IViewLocalizer/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Localization/LocalizedHtmlString/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Localization/ViewLocalizer/index
   
   











.. dn:namespace:: Microsoft.AspNet.Mvc.Localization


    .. rubric:: Classes


    class :dn:cls:`Microsoft.AspNet.Mvc.Localization.HtmlLocalizer`
        An :any:`Microsoft.AspNet.Mvc.Localization.IHtmlLocalizer` that uses the :any:`Microsoft.Extensions.Localization.IStringLocalizer` to provide localized HTML content.
        This service just encodes the arguments but not the resource string.


    class :dn:cls:`Microsoft.AspNet.Mvc.Localization.HtmlLocalizerFactory`
        An :any:`Microsoft.AspNet.Mvc.Localization.IHtmlLocalizerFactory` that creates instances of :any:`Microsoft.AspNet.Mvc.Localization.HtmlLocalizer`\.


    class :dn:cls:`Microsoft.AspNet.Mvc.Localization.HtmlLocalizer\<TResource>`
        This is an :any:`Microsoft.AspNet.Mvc.Localization.HtmlLocalizer` that provides localized HTML content.


    class :dn:cls:`Microsoft.AspNet.Mvc.Localization.LocalizedHtmlString`
        An :any:`Microsoft.AspNet.Mvc.Rendering.HtmlString` with localized content.


    class :dn:cls:`Microsoft.AspNet.Mvc.Localization.ViewLocalizer`
        A :any:`Microsoft.AspNet.Mvc.Localization.HtmlLocalizer` that provides localized strings for views.


    .. rubric:: Interfaces


    interface :dn:iface:`Microsoft.AspNet.Mvc.Localization.IHtmlLocalizer`
        This service does not HTML encode the resource string. It HTML encodes all arguments that are formatted in
        the resource string.


    interface :dn:iface:`Microsoft.AspNet.Mvc.Localization.IHtmlLocalizerFactory`
        A factory that creates :any:`Microsoft.AspNet.Mvc.Localization.IHtmlLocalizer` instances.


    interface :dn:iface:`Microsoft.AspNet.Mvc.Localization.IHtmlLocalizer\<TResource>`
        An :any:`Microsoft.AspNet.Mvc.Localization.IHtmlLocalizer` that provides localized HTML content.


    interface :dn:iface:`Microsoft.AspNet.Mvc.Localization.IViewLocalizer`
        A service that provides localized strings for views.


