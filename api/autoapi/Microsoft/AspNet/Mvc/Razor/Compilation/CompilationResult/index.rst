

CompilationResult Class
=======================



.. contents:: 
   :local:



Summary
-------

Represents the result of compilation.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.Compilation.CompilationResult`








Syntax
------

.. code-block:: csharp

   public class CompilationResult





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Razor/Compilation/CompilationResult.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.Compilation.CompilationResult

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Compilation.CompilationResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.Compilation.CompilationResult.CompilationResult()
    
        
    
        Creates a new instance of :any:`Microsoft.AspNet.Mvc.Razor.Compilation.CompilationResult`\.
    
        
    
        
        .. code-block:: csharp
    
           protected CompilationResult()
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Compilation.CompilationResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.Compilation.CompilationResult.EnsureSuccessful()
    
        
    
        Gets the :any:`Microsoft.AspNet.Mvc.Razor.Compilation.CompilationResult`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.Razor.Compilation.CompilationResult
        :return: The current <see cref="T:Microsoft.AspNet.Mvc.Razor.Compilation.CompilationResult" /> instance.
    
        
        .. code-block:: csharp
    
           public CompilationResult EnsureSuccessful()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.Compilation.CompilationResult.Failed(System.Collections.Generic.IEnumerable<Microsoft.Dnx.Compilation.CompilationFailure>)
    
        
    
        Creates a :any:`Microsoft.AspNet.Mvc.Razor.Compilation.CompilationResult` for a failed compilation.
    
        
        
        
        :param compilationFailures: s produced from parsing or
            compiling the Razor file.
        
        :type compilationFailures: System.Collections.Generic.IEnumerable{Microsoft.Dnx.Compilation.CompilationFailure}
        :rtype: Microsoft.AspNet.Mvc.Razor.Compilation.CompilationResult
        :return: A <see cref="T:Microsoft.AspNet.Mvc.Razor.Compilation.CompilationResult" /> instance for a failed compilation.
    
        
        .. code-block:: csharp
    
           public static CompilationResult Failed(IEnumerable<CompilationFailure> compilationFailures)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.Compilation.CompilationResult.Successful(System.Type)
    
        
    
        Creates a :any:`Microsoft.AspNet.Mvc.Razor.Compilation.CompilationResult` for a successful compilation.
    
        
        
        
        :param type: The compiled type.
        
        :type type: System.Type
        :rtype: Microsoft.AspNet.Mvc.Razor.Compilation.CompilationResult
        :return: A <see cref="T:Microsoft.AspNet.Mvc.Razor.Compilation.CompilationResult" /> instance for a successful compilation.
    
        
        .. code-block:: csharp
    
           public static CompilationResult Successful(Type type)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Compilation.CompilationResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.Compilation.CompilationResult.CompilationFailures
    
        
    
        Gets the :any:`Microsoft.Dnx.Compilation.CompilationFailure`\s produced from parsing or compiling the Razor file.
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.Dnx.Compilation.CompilationFailure}
    
        
        .. code-block:: csharp
    
           public IEnumerable<CompilationFailure> CompilationFailures { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.Compilation.CompilationResult.CompiledContent
    
        
    
        Gets (or sets in derived types) the generated C# content that was compiled.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string CompiledContent { get; protected set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.Compilation.CompilationResult.CompiledType
    
        
    
        Gets (or sets in derived types) the type produced as a result of compilation.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
           public Type CompiledType { get; protected set; }
    

