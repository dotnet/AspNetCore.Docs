

CompilerCacheResult Class
=========================



.. contents:: 
   :local:



Summary
-------

Result of :any:`Microsoft.AspNet.Mvc.Razor.Compilation.ICompilerCache`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.Compilation.CompilerCacheResult`








Syntax
------

.. code-block:: csharp

   public class CompilerCacheResult





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Razor/Compilation/CompilerCacheResult.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.Compilation.CompilerCacheResult

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Compilation.CompilerCacheResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.Compilation.CompilerCacheResult.CompilerCacheResult()
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Mvc.Razor.Compilation.CompilerCacheResult` for a failed file lookup.
    
        
    
        
        .. code-block:: csharp
    
           protected CompilerCacheResult()
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.Compilation.CompilerCacheResult.CompilerCacheResult(Microsoft.AspNet.Mvc.Razor.Compilation.CompilationResult)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Mvc.Razor.Compilation.CompilerCacheResult` with the specified 
        :dn:prop:`Microsoft.AspNet.Mvc.Razor.Compilation.CompilerCacheResult.CompilationResult`\.
    
        
        
        
        :param compilationResult: The
        
        :type compilationResult: Microsoft.AspNet.Mvc.Razor.Compilation.CompilationResult
    
        
        .. code-block:: csharp
    
           public CompilerCacheResult(CompilationResult compilationResult)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Compilation.CompilerCacheResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.Compilation.CompilerCacheResult.CompilationResult
    
        
    
        The :any:`Microsoft.AspNet.Mvc.Razor.Compilation.CompilationResult`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.Razor.Compilation.CompilationResult
    
        
        .. code-block:: csharp
    
           public CompilationResult CompilationResult { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.Compilation.CompilerCacheResult.FileNotFound
    
        
    
        Result of :any:`Microsoft.AspNet.Mvc.Razor.Compilation.ICompilerCache` when the specified file does not exist in the
        file system.
    
        
        :rtype: Microsoft.AspNet.Mvc.Razor.Compilation.CompilerCacheResult
    
        
        .. code-block:: csharp
    
           public static CompilerCacheResult FileNotFound { get; }
    

