

CompilationErrorPageModel Class
===============================






Holds data to be displayed on the compilation error page.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Diagnostics.Views`
Assemblies
    * Microsoft.AspNetCore.Diagnostics

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Diagnostics.Views.CompilationErrorPageModel`








Syntax
------

.. code-block:: csharp

    public class CompilationErrorPageModel








.. dn:class:: Microsoft.AspNetCore.Diagnostics.Views.CompilationErrorPageModel
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Views.CompilationErrorPageModel

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Views.CompilationErrorPageModel
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Views.CompilationErrorPageModel.ErrorDetails
    
        
    
        
        Detailed information about each parse or compilation error.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Diagnostics.Views.ErrorDetails<Microsoft.AspNetCore.Diagnostics.Views.ErrorDetails>}
    
        
        .. code-block:: csharp
    
            public IList<ErrorDetails> ErrorDetails { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Views.CompilationErrorPageModel.Options
    
        
    
        
        Options for what output to display.
    
        
        :rtype: Microsoft.AspNetCore.Builder.DeveloperExceptionPageOptions
    
        
        .. code-block:: csharp
    
            public DeveloperExceptionPageOptions Options { get; set; }
    

