

Microsoft.AspNetCore.Mvc.Razor Namespace
========================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/GeneratedTagHelperAttributeContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/HelperResult/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/IMvcRazorHost/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/IRazorPage/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/IRazorPageActivator/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/IRazorPageFactoryProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/IRazorViewEngine/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/ITagHelperActivator/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/ITagHelperFactory/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/ITagHelperInitializer-TTagHelper/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/IViewLocationExpander/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/InjectChunk/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/InjectChunkVisitor/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/InjectParameterGenerator/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/LanguageViewLocationExpander/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/LanguageViewLocationExpanderFormat/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/ModelChunk/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/MvcCSharpChunkVisitor/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/MvcCSharpCodeGenerator/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/MvcCSharpCodeVisitor/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/MvcCSharpDesignTimeCodeVisitor/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/MvcRazorCodeParser/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/MvcRazorHost/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/MvcRazorParser/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/MvcTagHelperAttributeValueCodeRenderer/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/RazorPage/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/RazorPageActivator/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/RazorPageFactoryResult/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/RazorPageResult/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/RazorPage-TModel/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/RazorView/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/RazorViewEngine/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/RazorViewEngineOptions/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/RenderAsyncDelegate/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/TagHelperInitializer-TTagHelper/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/ViewHierarchyUtility/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/ViewLocationExpanderContext/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.Mvc.Razor


    .. rubric:: Interfaces


    interface :dn:iface:`IMvcRazorHost`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Razor.IMvcRazorHost

        
        Specifies the contracts for a Razor host that parses Razor files and generates C# code.


    interface :dn:iface:`IRazorPage`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Razor.IRazorPage

        
        Represents properties and methods that are used by :any:`Microsoft.AspNetCore.Mvc.Razor.RazorView` for execution.


    interface :dn:iface:`IRazorPageActivator`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Razor.IRazorPageActivator

        
        Provides methods to activate properties on a :any:`Microsoft.AspNetCore.Mvc.Razor.IRazorPage` instance.


    interface :dn:iface:`IRazorPageFactoryProvider`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Razor.IRazorPageFactoryProvider

        
        Defines methods that are used for creating :any:`Microsoft.AspNetCore.Mvc.Razor.IRazorPage` instances at a given path.


    interface :dn:iface:`IRazorViewEngine`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Razor.IRazorViewEngine

        
        An :any:`Microsoft.AspNetCore.Mvc.ViewEngines.IViewEngine` used to render pages that use the Razor syntax.


    interface :dn:iface:`ITagHelperActivator`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Razor.ITagHelperActivator

        
        Provides methods to create a tag helper.


    interface :dn:iface:`ITagHelperFactory`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Razor.ITagHelperFactory

        
        Provides methods to create and initialize tag helpers.


    interface :dn:iface:`ITagHelperInitializer\<TTagHelper>`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Razor.ITagHelperInitializer\<TTagHelper>

        
        Initializes an :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper` before it's executed.


    interface :dn:iface:`IViewLocationExpander`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Razor.IViewLocationExpander

        
        Specifies the contracts for a view location expander that is used by :any:`Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine` instances to
        determine search paths for a view.


    .. rubric:: Structures


    struct :dn:struct:`RazorPageFactoryResult`
        .. object: type=struct name=Microsoft.AspNetCore.Mvc.Razor.RazorPageFactoryResult

        
        Result of :dn:meth:`Microsoft.AspNetCore.Mvc.Razor.IRazorPageFactoryProvider.CreateFactory(System.String)`\.


    struct :dn:struct:`RazorPageResult`
        .. object: type=struct name=Microsoft.AspNetCore.Mvc.Razor.RazorPageResult

        
        Result of locating a :any:`Microsoft.AspNetCore.Mvc.Razor.IRazorPage`\.


    .. rubric:: Delegates


    delegate :dn:del:`RenderAsyncDelegate`
        .. object: type=delegate name=Microsoft.AspNetCore.Mvc.Razor.RenderAsyncDelegate

        


    .. rubric:: Classes


    class :dn:cls:`GeneratedTagHelperAttributeContext`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.GeneratedTagHelperAttributeContext

        
        Contains information for the :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper` attribute code
        generation process.


    class :dn:cls:`HelperResult`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.HelperResult

        
        Represents a deferred write operation in a :any:`Microsoft.AspNetCore.Mvc.Razor.RazorPage`\.


    class :dn:cls:`InjectChunk`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.InjectChunk

        


    class :dn:cls:`InjectChunkVisitor`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.InjectChunkVisitor

        


    class :dn:cls:`InjectParameterGenerator`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.InjectParameterGenerator

        


    class :dn:cls:`LanguageViewLocationExpander`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpander

        
        A :any:`Microsoft.AspNetCore.Mvc.Razor.IViewLocationExpander` that adds the language as an extension prefix to view names. Language
        that is getting added as extension prefix comes from :any:`Microsoft.AspNetCore.Http.HttpContext`\.


    class :dn:cls:`ModelChunk`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.ModelChunk

        
        :any:`Microsoft.AspNetCore.Razor.Chunks.Chunk` for an <code>@model</code> directive.


    class :dn:cls:`MvcCSharpChunkVisitor`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.MvcCSharpChunkVisitor

        


    class :dn:cls:`MvcCSharpCodeGenerator`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.MvcCSharpCodeGenerator

        


    class :dn:cls:`MvcCSharpCodeVisitor`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.MvcCSharpCodeVisitor

        


    class :dn:cls:`MvcCSharpDesignTimeCodeVisitor`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.MvcCSharpDesignTimeCodeVisitor

        


    class :dn:cls:`MvcRazorCodeParser`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.MvcRazorCodeParser

        


    class :dn:cls:`MvcRazorHost`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.MvcRazorHost

        


    class :dn:cls:`MvcRazorParser`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.MvcRazorParser

        
        A subtype of :any:`Microsoft.AspNetCore.Razor.Parser.RazorParser` that :any:`Microsoft.AspNetCore.Mvc.Razor.MvcRazorHost` uses to support inheritance of tag
        helpers from <code>_ViewImports</code> files.


    class :dn:cls:`MvcTagHelperAttributeValueCodeRenderer`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.MvcTagHelperAttributeValueCodeRenderer

        


    class :dn:cls:`RazorPage`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.RazorPage

        
        Represents properties and methods that are needed in order to render a view that uses Razor syntax.


    class :dn:cls:`RazorPageActivator`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.RazorPageActivator

        


    class :dn:cls:`RazorPage\<TModel>`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.RazorPage\<TModel>

        
        Represents the properties and methods that are needed in order to render a view that uses Razor syntax.


    class :dn:cls:`RazorView`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.RazorView

        
        Default implementation for :any:`Microsoft.AspNetCore.Mvc.ViewEngines.IView` that executes one or more :any:`Microsoft.AspNetCore.Mvc.Razor.IRazorPage`
        as parts of its execution.


    class :dn:cls:`RazorViewEngine`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine

        
        Default implementation of :any:`Microsoft.AspNetCore.Mvc.Razor.IRazorViewEngine`\.


    class :dn:cls:`RazorViewEngineOptions`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions

        
        Provides programmatic configuration for the :any:`Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine`\.


    class :dn:cls:`TagHelperInitializer\<TTagHelper>`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.TagHelperInitializer\<TTagHelper>

        


    class :dn:cls:`ViewHierarchyUtility`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.ViewHierarchyUtility

        
        Contains methods to locate <code>_ViewStart.cshtml</code> and <code>_ViewImports.cshtml</code>


    class :dn:cls:`ViewLocationExpanderContext`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.ViewLocationExpanderContext

        
        A context for containing information for :any:`Microsoft.AspNetCore.Mvc.Razor.IViewLocationExpander`\.


    .. rubric:: Enumerations


    enum :dn:enum:`LanguageViewLocationExpanderFormat`
        .. object: type=enum name=Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat

        
        Specifies the localized view format for :any:`Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpander`\.


