

Microsoft.AspNetCore.Mvc.Razor.Compilation Namespace
====================================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/Compilation/CompilationFailedException/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/Compilation/CompilationResult/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/Compilation/ICompilationService/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/Compilation/IRazorCompilationService/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/Compilation/MetadataReferenceFeature/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/Compilation/MetadataReferenceFeatureProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/Compilation/RelativeFileInfo/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Razor/Compilation/RoslynCompilationContext/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.Mvc.Razor.Compilation


    .. rubric:: Interfaces


    interface :dn:iface:`ICompilationService`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Razor.Compilation.ICompilationService

        
        Provides methods for compilation of a Razor page.


    interface :dn:iface:`IRazorCompilationService`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Razor.Compilation.IRazorCompilationService

        
        Specifies the contracts for a service that compiles Razor files.


    .. rubric:: Classes


    class :dn:cls:`CompilationFailedException`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationFailedException

        
        An :any:`System.Exception` thrown when accessing the result of a failed compilation.


    class :dn:cls:`MetadataReferenceFeature`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.Compilation.MetadataReferenceFeature

        
        Specifies the list of :any:`Microsoft.CodeAnalysis.MetadataReference` used in Razor compilation.


    class :dn:cls:`MetadataReferenceFeatureProvider`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.Compilation.MetadataReferenceFeatureProvider

        
        An :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.IApplicationFeatureProvider\`1` for :any:`Microsoft.AspNetCore.Mvc.Razor.Compilation.MetadataReferenceFeature` that 
        uses :any:`Microsoft.Extensions.DependencyModel.DependencyContext` for registered :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.AssemblyPart` instances to create 
        :any:`Microsoft.CodeAnalysis.MetadataReference`\.


    class :dn:cls:`RelativeFileInfo`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.Compilation.RelativeFileInfo

        
        A container type that represents :any:`Microsoft.Extensions.FileProviders.IFileInfo` along with the application base relative path
        for a file in the file system.


    class :dn:cls:`RoslynCompilationContext`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Razor.Compilation.RoslynCompilationContext

        
        Context object used to pass information about the current Razor page compilation.


    .. rubric:: Structures


    struct :dn:struct:`CompilationResult`
        .. object: type=struct name=Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationResult

        
        Represents the result of compilation.


