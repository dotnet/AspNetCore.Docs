

DefaultRoslynCompilationService Class
=====================================






A type that uses Roslyn to compile C# content.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Razor.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultRoslynCompilationService`








Syntax
------

.. code-block:: csharp

    public class DefaultRoslynCompilationService : ICompilationService








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultRoslynCompilationService
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultRoslynCompilationService

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultRoslynCompilationService
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultRoslynCompilationService.DefaultRoslynCompilationService(Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions>, Microsoft.AspNetCore.Mvc.Razor.Internal.IRazorViewEngineFileProviderAccessor, Microsoft.Extensions.Logging.ILoggerFactory)
    
        
    
        
        Initalizes a new instance of the :any:`Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultRoslynCompilationService` class.
    
        
    
        
        :param partManager: The :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager`\.
        
        :type partManager: Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager
    
        
        :param optionsAccessor: Accessor to :any:`Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions`\.
        
        :type optionsAccessor: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions<Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions>}
    
        
        :param fileProviderAccessor: The :any:`Microsoft.AspNetCore.Mvc.Razor.Internal.IRazorViewEngineFileProviderAccessor`\.
        
        :type fileProviderAccessor: Microsoft.AspNetCore.Mvc.Razor.Internal.IRazorViewEngineFileProviderAccessor
    
        
        :param loggerFactory: The :any:`Microsoft.Extensions.Logging.ILoggerFactory`\.
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
            public DefaultRoslynCompilationService(ApplicationPartManager partManager, IOptions<RazorViewEngineOptions> optionsAccessor, IRazorViewEngineFileProviderAccessor fileProviderAccessor, ILoggerFactory loggerFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultRoslynCompilationService
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultRoslynCompilationService.Compile(Microsoft.AspNetCore.Mvc.Razor.Compilation.RelativeFileInfo, System.String)
    
        
    
        
        :type fileInfo: Microsoft.AspNetCore.Mvc.Razor.Compilation.RelativeFileInfo
    
        
        :type compilationContent: System.String
        :rtype: Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationResult
    
        
        .. code-block:: csharp
    
            public CompilationResult Compile(RelativeFileInfo fileInfo, string compilationContent)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultRoslynCompilationService.GetCompilationReferences()
    
        
    
        
        Gets the sequence of :any:`Microsoft.CodeAnalysis.MetadataReference` instances used for compilation.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.CodeAnalysis.MetadataReference<Microsoft.CodeAnalysis.MetadataReference>}
        :return: The :any:`Microsoft.CodeAnalysis.MetadataReference` instances.
    
        
        .. code-block:: csharp
    
            protected virtual IList<MetadataReference> GetCompilationReferences()
    

