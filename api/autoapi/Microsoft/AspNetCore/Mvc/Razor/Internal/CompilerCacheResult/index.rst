

CompilerCacheResult Struct
==========================






Result of :any:`Microsoft.AspNetCore.Mvc.Razor.Internal.ICompilerCache`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Razor.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Razor

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public struct CompilerCacheResult








.. dn:structure:: Microsoft.AspNetCore.Mvc.Razor.Internal.CompilerCacheResult
    :hidden:

.. dn:structure:: Microsoft.AspNetCore.Mvc.Razor.Internal.CompilerCacheResult

Constructors
------------

.. dn:structure:: Microsoft.AspNetCore.Mvc.Razor.Internal.CompilerCacheResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.Internal.CompilerCacheResult.CompilerCacheResult(System.Collections.Generic.IList<Microsoft.Extensions.Primitives.IChangeToken>)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Razor.Internal.CompilerCacheResult` for a file that could not be
        found in the file system.
    
        
    
        
        :param expirationTokens: One or more :any:`Microsoft.Extensions.Primitives.IChangeToken` instances that indicate when
            this result has expired.
        
        :type expirationTokens: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.Extensions.Primitives.IChangeToken<Microsoft.Extensions.Primitives.IChangeToken>}
    
        
        .. code-block:: csharp
    
            public CompilerCacheResult(IList<IChangeToken> expirationTokens)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.Internal.CompilerCacheResult.CompilerCacheResult(System.String, Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationResult)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Razor.Internal.CompilerCacheResult` with the specified 
        :any:`Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationResult`\.
    
        
    
        
        :param relativePath: Path of the view file relative to the application base.
        
        :type relativePath: System.String
    
        
        :param compilationResult: The :any:`Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationResult`\.
        
        :type compilationResult: Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationResult
    
        
        .. code-block:: csharp
    
            public CompilerCacheResult(string relativePath, CompilationResult compilationResult)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.Internal.CompilerCacheResult.CompilerCacheResult(System.String, Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationResult, System.Collections.Generic.IList<Microsoft.Extensions.Primitives.IChangeToken>)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Razor.Internal.CompilerCacheResult` with the specified 
        :any:`Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationResult`\.
    
        
    
        
        :param relativePath: Path of the view file relative to the application base.
        
        :type relativePath: System.String
    
        
        :param compilationResult: The :any:`Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationResult`\.
        
        :type compilationResult: Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationResult
    
        
        :param expirationTokens: One or more :any:`Microsoft.Extensions.Primitives.IChangeToken` instances that indicate when
            this result has expired.
        
        :type expirationTokens: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.Extensions.Primitives.IChangeToken<Microsoft.Extensions.Primitives.IChangeToken>}
    
        
        .. code-block:: csharp
    
            public CompilerCacheResult(string relativePath, CompilationResult compilationResult, IList<IChangeToken> expirationTokens)
    

Properties
----------

.. dn:structure:: Microsoft.AspNetCore.Mvc.Razor.Internal.CompilerCacheResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.Internal.CompilerCacheResult.ExpirationTokens
    
        
    
        
        :any:`Microsoft.Extensions.Primitives.IChangeToken` instances that indicate when this result has expired.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.Extensions.Primitives.IChangeToken<Microsoft.Extensions.Primitives.IChangeToken>}
    
        
        .. code-block:: csharp
    
            public IList<IChangeToken> ExpirationTokens { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.Internal.CompilerCacheResult.PageFactory
    
        
    
        
        Gets a delegate that creates an instance of the :any:`Microsoft.AspNetCore.Mvc.Razor.IRazorPage`\.
    
        
        :rtype: System.Func<System.Func`1>{Microsoft.AspNetCore.Mvc.Razor.IRazorPage<Microsoft.AspNetCore.Mvc.Razor.IRazorPage>}
    
        
        .. code-block:: csharp
    
            public Func<IRazorPage> PageFactory { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.Internal.CompilerCacheResult.Success
    
        
    
        
        Gets a value that determines if the view was successfully found and compiled.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Success { get; }
    

