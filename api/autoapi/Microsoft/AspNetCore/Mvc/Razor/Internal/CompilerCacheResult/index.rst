

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

Properties
----------

.. dn:structure:: Microsoft.AspNetCore.Mvc.Razor.Internal.CompilerCacheResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.Internal.CompilerCacheResult.CompilationResult
    
        
    
        
        The :any:`Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationResult`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationResult
    
        
        .. code-block:: csharp
    
            public CompilationResult CompilationResult
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.Internal.CompilerCacheResult.ExpirationTokens
    
        
    
        
        :any:`Microsoft.Extensions.Primitives.IChangeToken` instances that indicate when this result has expired.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.Extensions.Primitives.IChangeToken<Microsoft.Extensions.Primitives.IChangeToken>}
    
        
        .. code-block:: csharp
    
            public IList<IChangeToken> ExpirationTokens
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.Internal.CompilerCacheResult.Success
    
        
    
        
        Gets a value that determines if the view was successfully found and compiled.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Success
            {
                get;
            }
    

Constructors
------------

.. dn:structure:: Microsoft.AspNetCore.Mvc.Razor.Internal.CompilerCacheResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.Internal.CompilerCacheResult.CompilerCacheResult(Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationResult)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Razor.Internal.CompilerCacheResult` with the specified
        :any:`Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationResult`\.
    
        
    
        
        :param compilationResult: The :any:`Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationResult`\.
        
        :type compilationResult: Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationResult
    
        
        .. code-block:: csharp
    
            public CompilerCacheResult(CompilationResult compilationResult)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.Internal.CompilerCacheResult.CompilerCacheResult(Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationResult, System.Collections.Generic.IList<Microsoft.Extensions.Primitives.IChangeToken>)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Razor.Internal.CompilerCacheResult` with the specified
        :any:`Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationResult`\.
    
        
    
        
        :param compilationResult: The :any:`Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationResult`\.
        
        :type compilationResult: Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationResult
    
        
        :param expirationTokens: One or more :any:`Microsoft.Extensions.Primitives.IChangeToken` instances that indicate when
            this result has expired.
        
        :type expirationTokens: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.Extensions.Primitives.IChangeToken<Microsoft.Extensions.Primitives.IChangeToken>}
    
        
        .. code-block:: csharp
    
            public CompilerCacheResult(CompilationResult compilationResult, IList<IChangeToken> expirationTokens)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.Internal.CompilerCacheResult.CompilerCacheResult(System.Collections.Generic.IList<Microsoft.Extensions.Primitives.IChangeToken>)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Razor.Internal.CompilerCacheResult` for a file that could not be
        found in the file system.
    
        
    
        
        :param expirationTokens: One or more :any:`Microsoft.Extensions.Primitives.IChangeToken` instances that indicate when
            this result has expired.
        
        :type expirationTokens: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.Extensions.Primitives.IChangeToken<Microsoft.Extensions.Primitives.IChangeToken>}
    
        
        .. code-block:: csharp
    
            public CompilerCacheResult(IList<IChangeToken> expirationTokens)
    

