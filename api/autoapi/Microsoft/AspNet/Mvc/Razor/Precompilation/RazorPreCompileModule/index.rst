

RazorPreCompileModule Class
===========================



.. contents:: 
   :local:



Summary
-------

An :any:`Microsoft.Dnx.Compilation.CSharp.ICompileModule` implementation that pre-compiles Razor views in the application.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.Precompilation.RazorPreCompileModule`








Syntax
------

.. code-block:: csharp

   public abstract class RazorPreCompileModule : ICompileModule





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Razor/Precompilation/RazorPreCompileModule.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.Precompilation.RazorPreCompileModule

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Precompilation.RazorPreCompileModule
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.Precompilation.RazorPreCompileModule.AfterCompile(Microsoft.Dnx.Compilation.CSharp.AfterCompileContext)
    
        
        
        
        :type context: Microsoft.Dnx.Compilation.CSharp.AfterCompileContext
    
        
        .. code-block:: csharp
    
           public void AfterCompile(AfterCompileContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.Precompilation.RazorPreCompileModule.BeforeCompile(Microsoft.Dnx.Compilation.CSharp.BeforeCompileContext)
    
        
        
        
        :type context: Microsoft.Dnx.Compilation.CSharp.BeforeCompileContext
    
        
        .. code-block:: csharp
    
           public virtual void BeforeCompile(BeforeCompileContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.Precompilation.RazorPreCompileModule.EnablePreCompilation(Microsoft.Dnx.Compilation.CSharp.BeforeCompileContext)
    
        
    
        Determines if this instance of :any:`Microsoft.AspNet.Mvc.Razor.Precompilation.RazorPreCompileModule` should enable
        compilation of views.
    
        
        
        
        :param context: The .
        
        :type context: Microsoft.Dnx.Compilation.CSharp.BeforeCompileContext
        :rtype: System.Boolean
        :return: <c>true</c> if views should be precompiled; otherwise <c>false</c>.
    
        
        .. code-block:: csharp
    
           protected virtual bool EnablePreCompilation(BeforeCompileContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Precompilation.RazorPreCompileModule
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.Precompilation.RazorPreCompileModule.GenerateSymbols
    
        
    
        Gets or sets a value that determines if symbols (.pdb) file for the precompiled views is generated.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool GenerateSymbols { get; protected set; }
    

