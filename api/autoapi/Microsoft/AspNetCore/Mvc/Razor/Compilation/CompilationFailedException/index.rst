

CompilationFailedException Class
================================






An :any:`System.Exception` thrown when accessing the result of a failed compilation.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Razor.Compilation`
Assemblies
    * Microsoft.AspNetCore.Mvc.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Exception`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationFailedException`








Syntax
------

.. code-block:: csharp

    public class CompilationFailedException : Exception, ISerializable, _Exception, ICompilationException








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationFailedException
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationFailedException

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationFailedException
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationFailedException.CompilationFailures
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Diagnostics.CompilationFailure<Microsoft.AspNetCore.Diagnostics.CompilationFailure>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<CompilationFailure> CompilationFailures
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationFailedException
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationFailedException.CompilationFailedException(System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Diagnostics.CompilationFailure>)
    
        
    
        
        Instantiates a new instance of :any:`Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationFailedException`\.
    
        
    
        
        :param compilationFailures: :any:`Microsoft.AspNetCore.Diagnostics.CompilationFailure`\s containing
            details of the compilation failure.
        
        :type compilationFailures: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Diagnostics.CompilationFailure<Microsoft.AspNetCore.Diagnostics.CompilationFailure>}
    
        
        .. code-block:: csharp
    
            public CompilationFailedException(IEnumerable<CompilationFailure> compilationFailures)
    

