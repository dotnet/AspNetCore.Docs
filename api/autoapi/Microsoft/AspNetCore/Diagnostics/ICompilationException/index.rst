

ICompilationException Interface
===============================






Specifies the contract for an exception representing compilation failure.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Diagnostics`
Assemblies
    * Microsoft.AspNetCore.Diagnostics.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface ICompilationException








.. dn:interface:: Microsoft.AspNetCore.Diagnostics.ICompilationException
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Diagnostics.ICompilationException

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Diagnostics.ICompilationException
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.ICompilationException.CompilationFailures
    
        
    
        
        Gets a sequence of :any:`Microsoft.AspNetCore.Diagnostics.CompilationFailure` with compilation failures.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Diagnostics.CompilationFailure<Microsoft.AspNetCore.Diagnostics.CompilationFailure>}
    
        
        .. code-block:: csharp
    
            IEnumerable<CompilationFailure> CompilationFailures { get; }
    

