

RazorViewEngineOptions Class
============================






Provides programmatic configuration for the :any:`Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Razor`
Assemblies
    * Microsoft.AspNetCore.Mvc.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions`








Syntax
------

.. code-block:: csharp

    public class RazorViewEngineOptions








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions.AdditionalCompilationReferences
    
        
    
        
        Gets the :any:`Microsoft.CodeAnalysis.MetadataReference` instances that should be included in Razor compilation, along with
        those discovered by :any:`Microsoft.AspNetCore.Mvc.Razor.Compilation.MetadataReferenceFeatureProvider`\s.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.CodeAnalysis.MetadataReference<Microsoft.CodeAnalysis.MetadataReference>}
    
        
        .. code-block:: csharp
    
            public IList<MetadataReference> AdditionalCompilationReferences { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions.AreaViewLocationFormats
    
        
    
        
        Gets the locations where :any:`Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine` will search for views within an
        area.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IList<string> AreaViewLocationFormats { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions.CompilationCallback
    
        
    
        
        Gets or sets the callback that is used to customize Razor compilation
        to change compilation settings you can update :dn:prop:`Microsoft.AspNetCore.Mvc.Razor.Compilation.RoslynCompilationContext.Compilation` property.
    
        
        :rtype: System.Action<System.Action`1>{Microsoft.AspNetCore.Mvc.Razor.Compilation.RoslynCompilationContext<Microsoft.AspNetCore.Mvc.Razor.Compilation.RoslynCompilationContext>}
    
        
        .. code-block:: csharp
    
            public Action<RoslynCompilationContext> CompilationCallback { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions.CompilationOptions
    
        
    
        
        Gets or sets the :any:`Microsoft.CodeAnalysis.CSharp.CSharpCompilationOptions` used by Razor view compilation.
    
        
        :rtype: Microsoft.CodeAnalysis.CSharp.CSharpCompilationOptions
    
        
        .. code-block:: csharp
    
            public CSharpCompilationOptions CompilationOptions { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions.FileProviders
    
        
    
        
        Gets the sequence of :any:`Microsoft.Extensions.FileProviders.IFileProvider` instances used by :any:`Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine` to
        locate Razor files.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.Extensions.FileProviders.IFileProvider<Microsoft.Extensions.FileProviders.IFileProvider>}
    
        
        .. code-block:: csharp
    
            public IList<IFileProvider> FileProviders { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions.ParseOptions
    
        
    
        
        Gets or sets the :any:`Microsoft.CodeAnalysis.CSharp.CSharpParseOptions` options used by Razor view compilation.
    
        
        :rtype: Microsoft.CodeAnalysis.CSharp.CSharpParseOptions
    
        
        .. code-block:: csharp
    
            public CSharpParseOptions ParseOptions { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions.ViewLocationExpanders
    
        
    
        
        Gets a :any:`System.Collections.Generic.IList\`1` used by the :any:`Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine`\.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.Razor.IViewLocationExpander<Microsoft.AspNetCore.Mvc.Razor.IViewLocationExpander>}
    
        
        .. code-block:: csharp
    
            public IList<IViewLocationExpander> ViewLocationExpanders { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions.ViewLocationFormats
    
        
    
        
        Gets the locations where :any:`Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine` will search for views.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IList<string> ViewLocationFormats { get; }
    

