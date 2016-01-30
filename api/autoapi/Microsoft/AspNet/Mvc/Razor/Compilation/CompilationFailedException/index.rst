

CompilationFailedException Class
================================



.. contents:: 
   :local:



Summary
-------

An :any:`System.Exception` thrown when accessing the result of a failed compilation.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Exception`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.Compilation.CompilationFailedException`








Syntax
------

.. code-block:: csharp

   public class CompilationFailedException : Exception, ISerializable, _Exception, ICompilationException





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Razor/Compilation/CompilationFailedException.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.Compilation.CompilationFailedException

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Compilation.CompilationFailedException
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.Compilation.CompilationFailedException.CompilationFailedException(System.Collections.Generic.IEnumerable<Microsoft.Dnx.Compilation.CompilationFailure>)
    
        
    
        Instantiates a new instance of :any:`Microsoft.AspNet.Mvc.Razor.Compilation.CompilationFailedException`\.
    
        
        
        
        :param compilationFailures: s containing
            details of the compilation failure.
        
        :type compilationFailures: System.Collections.Generic.IEnumerable{Microsoft.Dnx.Compilation.CompilationFailure}
    
        
        .. code-block:: csharp
    
           public CompilationFailedException(IEnumerable<CompilationFailure> compilationFailures)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Compilation.CompilationFailedException
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.Compilation.CompilationFailedException.CompilationFailures
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.Dnx.Compilation.CompilationFailure}
    
        
        .. code-block:: csharp
    
           public IEnumerable<CompilationFailure> CompilationFailures { get; }
    

