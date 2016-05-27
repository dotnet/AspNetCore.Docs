

RoslynCompilationContext Class
==============================






Context object used to pass information about the current Razor page compilation.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.Compilation.RoslynCompilationContext`








Syntax
------

.. code-block:: csharp

    public class RoslynCompilationContext








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Compilation.RoslynCompilationContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Compilation.RoslynCompilationContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Compilation.RoslynCompilationContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.Compilation.RoslynCompilationContext.Compilation
    
        
    
        
        Gets or sets the :any:`Microsoft.CodeAnalysis.CSharp.CSharpCompilation` used for current source file compilation.
    
        
        :rtype: Microsoft.CodeAnalysis.CSharp.CSharpCompilation
    
        
        .. code-block:: csharp
    
            public CSharpCompilation Compilation
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Compilation.RoslynCompilationContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.Compilation.RoslynCompilationContext.RoslynCompilationContext(Microsoft.CodeAnalysis.CSharp.CSharpCompilation)
    
        
    
        
        Constructs a new instance of the :any:`Microsoft.AspNetCore.Mvc.Razor.Compilation.RoslynCompilationContext` type.
    
        
    
        
        :param compilation: :any:`Microsoft.CodeAnalysis.CSharp.CSharpCompilation` to be set to :dn:prop:`Microsoft.AspNetCore.Mvc.Razor.Compilation.RoslynCompilationContext.Compilation` property.
        
        :type compilation: Microsoft.CodeAnalysis.CSharp.CSharpCompilation
    
        
        .. code-block:: csharp
    
            public RoslynCompilationContext(CSharpCompilation compilation)
    

