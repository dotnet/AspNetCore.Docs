

UncachedCompilationResult Class
===============================



.. contents:: 
   :local:



Summary
-------

Represents the result of compilation that does not come from the :any:`Microsoft.AspNet.Mvc.Razor.Compilation.ICompilerCache`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.Compilation.CompilationResult`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.Compilation.UncachedCompilationResult`








Syntax
------

.. code-block:: csharp

   public class UncachedCompilationResult : CompilationResult





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Razor/Compilation/UncachedCompilationResult.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.Compilation.UncachedCompilationResult

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Compilation.UncachedCompilationResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.Compilation.UncachedCompilationResult.Successful(System.Type, System.String)
    
        
    
        Creates a :any:`Microsoft.AspNet.Mvc.Razor.Compilation.UncachedCompilationResult` that represents a success in compilation.
    
        
        
        
        :param type: The compiled type.
        
        :type type: System.Type
        
        
        :param compiledContent: The generated C# content that was compiled.
        
        :type compiledContent: System.String
        :rtype: Microsoft.AspNet.Mvc.Razor.Compilation.UncachedCompilationResult
        :return: An <see cref="T:Microsoft.AspNet.Mvc.Razor.Compilation.UncachedCompilationResult" /> instance that indicates a successful
            compilation.
    
        
        .. code-block:: csharp
    
           public static UncachedCompilationResult Successful(Type type, string compiledContent)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Compilation.UncachedCompilationResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.Compilation.UncachedCompilationResult.RazorFileContent
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string RazorFileContent { get; }
    

