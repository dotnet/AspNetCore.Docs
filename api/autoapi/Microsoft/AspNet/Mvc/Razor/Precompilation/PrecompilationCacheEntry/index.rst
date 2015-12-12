

PrecompilationCacheEntry Class
==============================



.. contents:: 
   :local:



Summary
-------

An entry in the cache used by :any:`Microsoft.AspNet.Mvc.Razor.Precompilation.RazorPreCompiler`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.Precompilation.PrecompilationCacheEntry`








Syntax
------

.. code-block:: csharp

   public class PrecompilationCacheEntry





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Razor/Precompilation/PrecompilationCacheEntry.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.Precompilation.PrecompilationCacheEntry

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Precompilation.PrecompilationCacheEntry
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.Precompilation.PrecompilationCacheEntry.PrecompilationCacheEntry(Microsoft.AspNet.Mvc.Razor.Precompilation.RazorFileInfo, Microsoft.CodeAnalysis.SyntaxTree)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Mvc.Razor.Precompilation.PrecompilationCacheEntry` for a successful parse.
    
        
        
        
        :param fileInfo: The  of the file being cached.
        
        :type fileInfo: Microsoft.AspNet.Mvc.Razor.Precompilation.RazorFileInfo
        
        
        :param syntaxTree: The  to cache.
        
        :type syntaxTree: Microsoft.CodeAnalysis.SyntaxTree
    
        
        .. code-block:: csharp
    
           public PrecompilationCacheEntry(RazorFileInfo fileInfo, SyntaxTree syntaxTree)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.Precompilation.PrecompilationCacheEntry.PrecompilationCacheEntry(System.Collections.Generic.IReadOnlyList<Microsoft.CodeAnalysis.Diagnostic>)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Mvc.Razor.Precompilation.PrecompilationCacheEntry` for a failed parse.
    
        
        
        
        :param diagnostics: The  produced from parsing the Razor
            file. This does not contain s produced from compiling the parsed
            .
        
        :type diagnostics: System.Collections.Generic.IReadOnlyList{Microsoft.CodeAnalysis.Diagnostic}
    
        
        .. code-block:: csharp
    
           public PrecompilationCacheEntry(IReadOnlyList<Diagnostic> diagnostics)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Precompilation.PrecompilationCacheEntry
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.Precompilation.PrecompilationCacheEntry.Diagnostics
    
        
    
        Gets the :any:`Microsoft.CodeAnalysis.Diagnostic`\s produced from parsing the generated contents of the file
        specified by :dn:prop:`Microsoft.AspNet.Mvc.Razor.Precompilation.PrecompilationCacheEntry.FileInfo`\. This does not contain :any:`Microsoft.CodeAnalysis.Diagnostic`\s produced from
        compiling the parsed :any:`Microsoft.CodeAnalysis.SyntaxTree`\.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList{Microsoft.CodeAnalysis.Diagnostic}
    
        
        .. code-block:: csharp
    
           public IReadOnlyList<Diagnostic> Diagnostics { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.Precompilation.PrecompilationCacheEntry.FileInfo
    
        
    
        Gets the :any:`Microsoft.AspNet.Mvc.Razor.Precompilation.RazorFileInfo` associated with this cache entry instance.
    
        
        :rtype: Microsoft.AspNet.Mvc.Razor.Precompilation.RazorFileInfo
    
        
        .. code-block:: csharp
    
           public RazorFileInfo FileInfo { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.Precompilation.PrecompilationCacheEntry.Success
    
        
    
        Gets a value that indicates if parsing was successful.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Success { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.Precompilation.PrecompilationCacheEntry.SyntaxTree
    
        
    
        Gets the :dn:prop:`Microsoft.AspNet.Mvc.Razor.Precompilation.PrecompilationCacheEntry.SyntaxTree` produced from parsing the Razor file.
    
        
        :rtype: Microsoft.CodeAnalysis.SyntaxTree
    
        
        .. code-block:: csharp
    
           public SyntaxTree SyntaxTree { get; }
    

