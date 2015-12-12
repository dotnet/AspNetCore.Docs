

CompilationOptionsProviderExtension Class
=========================================



.. contents:: 
   :local:



Summary
-------

Extension methods for :any:`Microsoft.Dnx.Compilation.ICompilerOptionsProvider`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.Compilation.CompilationOptionsProviderExtension`








Syntax
------

.. code-block:: csharp

   public class CompilationOptionsProviderExtension





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Razor/Compilation/CompilationOptionsProviderExtension.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.Compilation.CompilationOptionsProviderExtension

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Compilation.CompilationOptionsProviderExtension
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.Compilation.CompilationOptionsProviderExtension.GetCompilationSettings(Microsoft.Dnx.Compilation.ICompilerOptionsProvider, Microsoft.Extensions.PlatformAbstractions.IApplicationEnvironment)
    
        
    
        Parses the :any:`Microsoft.Extensions.PlatformAbstractions.ICompilerOptions` for the current executing application and returns a 
        :any:`Microsoft.Dnx.Compilation.CSharp.CompilationSettings` used for Roslyn compilation.
    
        
        
        
        :param compilerOptionsProvider: A  that reads compiler options.
        
        :type compilerOptionsProvider: Microsoft.Dnx.Compilation.ICompilerOptionsProvider
        
        
        :param applicationEnvironment: The  for the executing application.
        
        :type applicationEnvironment: Microsoft.Extensions.PlatformAbstractions.IApplicationEnvironment
        :rtype: Microsoft.Dnx.Compilation.CSharp.CompilationSettings
        :return: The <see cref="T:Microsoft.Dnx.Compilation.CSharp.CompilationSettings" /> for the current application.
    
        
        .. code-block:: csharp
    
           public static CompilationSettings GetCompilationSettings(ICompilerOptionsProvider compilerOptionsProvider, IApplicationEnvironment applicationEnvironment)
    

