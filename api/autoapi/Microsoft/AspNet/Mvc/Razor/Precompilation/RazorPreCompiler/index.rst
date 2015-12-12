

RazorPreCompiler Class
======================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.Precompilation.RazorPreCompiler`








Syntax
------

.. code-block:: csharp

   public class RazorPreCompiler





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Razor/Precompilation/RazorPreCompiler.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.Precompilation.RazorPreCompiler

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Precompilation.RazorPreCompiler
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.Precompilation.RazorPreCompiler.RazorPreCompiler(Microsoft.Dnx.Compilation.CSharp.BeforeCompileContext, Microsoft.AspNet.FileProviders.IFileProvider, Microsoft.Extensions.Caching.Memory.IMemoryCache)
    
        
        
        
        :type compileContext: Microsoft.Dnx.Compilation.CSharp.BeforeCompileContext
        
        
        :type fileProvider: Microsoft.AspNet.FileProviders.IFileProvider
        
        
        :type precompilationCache: Microsoft.Extensions.Caching.Memory.IMemoryCache
    
        
        .. code-block:: csharp
    
           public RazorPreCompiler(BeforeCompileContext compileContext, IFileProvider fileProvider, IMemoryCache precompilationCache)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Precompilation.RazorPreCompiler
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.Precompilation.RazorPreCompiler.CompileViews()
    
        
    
        
        .. code-block:: csharp
    
           public virtual void CompileViews()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.Precompilation.RazorPreCompiler.CreateFileInfoCollection()
    
        
        :rtype: Microsoft.AspNet.Mvc.Razor.Precompilation.RazorFileInfoCollection
    
        
        .. code-block:: csharp
    
           protected virtual RazorFileInfoCollection CreateFileInfoCollection()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.Precompilation.RazorPreCompiler.GeneratePrecompiledAssembly(System.Collections.Generic.IEnumerable<Microsoft.CodeAnalysis.SyntaxTree>, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.Razor.Precompilation.RazorFileInfo>)
    
        
        
        
        :type syntaxTrees: System.Collections.Generic.IEnumerable{Microsoft.CodeAnalysis.SyntaxTree}
        
        
        :type razorFileInfos: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.Razor.Precompilation.RazorFileInfo}
        :rtype: Microsoft.AspNet.Mvc.Razor.Precompilation.RazorFileInfoCollection
    
        
        .. code-block:: csharp
    
           protected virtual RazorFileInfoCollection GeneratePrecompiledAssembly(IEnumerable<SyntaxTree> syntaxTrees, IEnumerable<RazorFileInfo> razorFileInfos)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.Precompilation.RazorPreCompiler.GetCacheEntry(Microsoft.AspNet.Mvc.Razor.Compilation.RelativeFileInfo)
    
        
        
        
        :type fileInfo: Microsoft.AspNet.Mvc.Razor.Compilation.RelativeFileInfo
        :rtype: Microsoft.AspNet.Mvc.Razor.Precompilation.PrecompilationCacheEntry
    
        
        .. code-block:: csharp
    
           protected virtual PrecompilationCacheEntry GetCacheEntry(RelativeFileInfo fileInfo)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.Precompilation.RazorPreCompiler.GetRazorHost()
    
        
        :rtype: Microsoft.AspNet.Mvc.Razor.IMvcRazorHost
    
        
        .. code-block:: csharp
    
           protected IMvcRazorHost GetRazorHost()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Precompilation.RazorPreCompiler
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.Precompilation.RazorPreCompiler.CompilationSettings
    
        
        :rtype: Microsoft.Dnx.Compilation.CSharp.CompilationSettings
    
        
        .. code-block:: csharp
    
           protected CompilationSettings CompilationSettings { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.Precompilation.RazorPreCompiler.CompileContext
    
        
        :rtype: Microsoft.Dnx.Compilation.CSharp.BeforeCompileContext
    
        
        .. code-block:: csharp
    
           protected BeforeCompileContext CompileContext { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.Precompilation.RazorPreCompiler.FileExtension
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           protected virtual string FileExtension { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.Precompilation.RazorPreCompiler.FileProvider
    
        
        :rtype: Microsoft.AspNet.FileProviders.IFileProvider
    
        
        .. code-block:: csharp
    
           protected IFileProvider FileProvider { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.Precompilation.RazorPreCompiler.GenerateSymbols
    
        
    
        Gets or sets a value that determines if symbols (.pdb) file for the precompiled views is generated.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool GenerateSymbols { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.Precompilation.RazorPreCompiler.MaxDegreesOfParallelism
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           protected virtual int MaxDegreesOfParallelism { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.Precompilation.RazorPreCompiler.PreCompilationCache
    
        
        :rtype: Microsoft.Extensions.Caching.Memory.IMemoryCache
    
        
        .. code-block:: csharp
    
           protected IMemoryCache PreCompilationCache { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.Precompilation.RazorPreCompiler.TagHelperTypeResolver
    
        
        :rtype: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperTypeResolver
    
        
        .. code-block:: csharp
    
           protected virtual TagHelperTypeResolver TagHelperTypeResolver { get; }
    

