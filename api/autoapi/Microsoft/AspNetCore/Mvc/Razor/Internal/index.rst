

Microsoft.AspNetCore.Mvc.Razor.Internal Namespace
=================================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/Internal/CompilerCache/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/Internal/CompilerCacheResult/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/Internal/DefaultCompilerCacheProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/Internal/DefaultRazorPageFactoryProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/Internal/DefaultRazorViewEngineFileProviderAccessor/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/Internal/DefaultRoslynCompilationService/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/Internal/DefaultTagHelperActivator/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/Internal/DefaultTagHelperFactory/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/Internal/DependencyContextRazorViewEngineOptionsSetup/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/Internal/DesignTimeRazorPathNormalizer/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/Internal/ExpressionRewriter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/Internal/ICompilerCache/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/Internal/ICompilerCacheProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/Internal/IRazorViewEngineFileProviderAccessor/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/Internal/MvcRazorMvcViewOptionsSetup/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/Internal/RazorCompilationService/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/Internal/RazorInjectAttribute/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/Internal/RazorPathNormalizer/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/Internal/ServiceBasedTagHelperActivator/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/Internal/SymbolsUtility/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/Internal/TagHelpersAsServices/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/Internal/ViewLocationCacheItem/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/Internal/ViewLocationCacheKey/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/Internal/ViewLocationCacheResult/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.Mvc.Razor.Internal


    .. rubric:: Interfaces


    interface :dn:iface:`ICompilerCache`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Razor.Internal.ICompilerCache

        
        Caches the result of runtime compilation of Razor files for the duration of the app lifetime.


    interface :dn:iface:`ICompilerCacheProvider`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Razor.Internal.ICompilerCacheProvider

        
        Provides access to a cached :any:`Microsoft.AspNetCore.Mvc.Razor.Internal.ICompilerCache` instance.


    interface :dn:iface:`IRazorViewEngineFileProviderAccessor`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Razor.Internal.IRazorViewEngineFileProviderAccessor

        
        Accessor to the :any:`Microsoft.Extensions.FileProviders.IFileProvider` used by :any:`Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine`\.


    .. rubric:: Classes


    class :dn:cls:`CompilerCache`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.Internal.CompilerCache

        
        Caches the result of runtime compilation of Razor files for the duration of the application lifetime.


    class :dn:cls:`DefaultCompilerCacheProvider`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultCompilerCacheProvider

        
        Default implementation for :any:`Microsoft.AspNetCore.Mvc.Razor.Internal.ICompilerCacheProvider`\.


    class :dn:cls:`DefaultRazorPageFactoryProvider`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultRazorPageFactoryProvider

        
        Represents a :any:`Microsoft.AspNetCore.Mvc.Razor.IRazorPageFactoryProvider` that creates :any:`Microsoft.AspNetCore.Mvc.Razor.RazorPage` instances
        from razor files in the file system.


    class :dn:cls:`DefaultRazorViewEngineFileProviderAccessor`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultRazorViewEngineFileProviderAccessor

        
        Default implementation of :any:`Microsoft.AspNetCore.Mvc.Razor.Internal.IRazorViewEngineFileProviderAccessor`\.


    class :dn:cls:`DefaultRoslynCompilationService`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultRoslynCompilationService

        
        A type that uses Roslyn to compile C# content.


    class :dn:cls:`DefaultTagHelperActivator`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultTagHelperActivator

        
        Default implementation of :any:`Microsoft.AspNetCore.Mvc.Razor.ITagHelperActivator`\.


    class :dn:cls:`DefaultTagHelperFactory`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultTagHelperFactory

        
        Default implementation for :any:`Microsoft.AspNetCore.Mvc.Razor.ITagHelperFactory`\.


    class :dn:cls:`DependencyContextRazorViewEngineOptionsSetup`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.Internal.DependencyContextRazorViewEngineOptionsSetup

        
        Sets up compilation and parse option default options for :any:`Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions` using 
        :any:`Microsoft.Extensions.DependencyModel.DependencyContext`


    class :dn:cls:`DesignTimeRazorPathNormalizer`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.Internal.DesignTimeRazorPathNormalizer

        


    class :dn:cls:`ExpressionRewriter`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.Internal.ExpressionRewriter

        
        An expression rewriter which can hoist a simple expression lambda into a private field.


    class :dn:cls:`MvcRazorMvcViewOptionsSetup`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.Internal.MvcRazorMvcViewOptionsSetup

        
        Configures :any:`Microsoft.AspNetCore.Mvc.MvcViewOptions` to use :any:`Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine`\.


    class :dn:cls:`RazorCompilationService`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.Internal.RazorCompilationService

        
        Default implementation of :any:`Microsoft.AspNetCore.Mvc.Razor.Compilation.IRazorCompilationService`\.


    class :dn:cls:`RazorInjectAttribute`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute

        


    class :dn:cls:`RazorPathNormalizer`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.Internal.RazorPathNormalizer

        


    class :dn:cls:`ServiceBasedTagHelperActivator`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.Internal.ServiceBasedTagHelperActivator

        
        A :any:`Microsoft.AspNetCore.Mvc.Razor.ITagHelperActivator` that retrieves tag helpers as services from the request's 
        :any:`System.IServiceProvider`\.


    class :dn:cls:`SymbolsUtility`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.Internal.SymbolsUtility

        
        Utility type for determining if a platform supports full pdb file generation.


    class :dn:cls:`TagHelpersAsServices`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.Internal.TagHelpersAsServices

        


    class :dn:cls:`ViewLocationCacheResult`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheResult

        
        Result of view location cache lookup.


    .. rubric:: Structures


    struct :dn:struct:`CompilerCacheResult`
        .. object: type=struct name=Microsoft.AspNetCore.Mvc.Razor.Internal.CompilerCacheResult

        
        Result of :any:`Microsoft.AspNetCore.Mvc.Razor.Internal.ICompilerCache`\.


    struct :dn:struct:`ViewLocationCacheItem`
        .. object: type=struct name=Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheItem

        
        An item in :any:`Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheResult`\.


    struct :dn:struct:`ViewLocationCacheKey`
        .. object: type=struct name=Microsoft.AspNetCore.Mvc.Razor.Internal.ViewLocationCacheKey

        
        Key for entries in :dn:prop:`Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine.ViewLookupCache`\.


