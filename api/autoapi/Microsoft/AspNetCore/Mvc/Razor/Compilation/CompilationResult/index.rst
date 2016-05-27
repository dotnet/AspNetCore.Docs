

CompilationResult Struct
========================






Represents the result of compilation.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Razor.Compilation`
Assemblies
    * Microsoft.AspNetCore.Mvc.Razor

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public struct CompilationResult








.. dn:structure:: Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationResult
    :hidden:

.. dn:structure:: Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationResult

Properties
----------

.. dn:structure:: Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationResult.CompilationFailures
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Diagnostics.CompilationFailure`\s produced from parsing or compiling the Razor file.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Diagnostics.CompilationFailure<Microsoft.AspNetCore.Diagnostics.CompilationFailure>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<CompilationFailure> CompilationFailures
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationResult.CompiledType
    
        
    
        
        Gets the type produced as a result of compilation.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
            public Type CompiledType
            {
                get;
            }
    

Constructors
------------

.. dn:structure:: Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationResult.CompilationResult(System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Diagnostics.CompilationFailure>)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationResult` for a failed compilation.
    
        
    
        
        :param compilationFailures: :any:`Microsoft.AspNetCore.Diagnostics.CompilationFailure`\s produced from parsing or
            compiling the Razor file.
        
        :type compilationFailures: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Diagnostics.CompilationFailure<Microsoft.AspNetCore.Diagnostics.CompilationFailure>}
    
        
        .. code-block:: csharp
    
            public CompilationResult(IEnumerable<CompilationFailure> compilationFailures)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationResult.CompilationResult(System.Type)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationResult` for a successful compilation.
    
        
    
        
        :param type: The compiled type.
        
        :type type: System.Type
    
        
        .. code-block:: csharp
    
            public CompilationResult(Type type)
    

Methods
-------

.. dn:structure:: Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationResult.EnsureSuccessful()
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationResult`\.
    
        
    
        
        .. code-block:: csharp
    
            public void EnsureSuccessful()
    

