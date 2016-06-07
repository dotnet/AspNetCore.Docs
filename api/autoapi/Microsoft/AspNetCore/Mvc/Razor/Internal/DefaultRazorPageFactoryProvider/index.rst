

DefaultRazorPageFactoryProvider Class
=====================================






Represents a :any:`Microsoft.AspNetCore.Mvc.Razor.IRazorPageFactoryProvider` that creates :any:`Microsoft.AspNetCore.Mvc.Razor.RazorPage` instances
from razor files in the file system.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultRazorPageFactoryProvider`








Syntax
------

.. code-block:: csharp

    public class DefaultRazorPageFactoryProvider : IRazorPageFactoryProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultRazorPageFactoryProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultRazorPageFactoryProvider

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultRazorPageFactoryProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultRazorPageFactoryProvider.DefaultRazorPageFactoryProvider(Microsoft.AspNetCore.Mvc.Razor.Compilation.IRazorCompilationService, Microsoft.AspNetCore.Mvc.Razor.Internal.ICompilerCacheProvider)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultRazorPageFactoryProvider`\.
    
        
    
        
        :param razorCompilationService: The :any:`Microsoft.AspNetCore.Mvc.Razor.Compilation.IRazorCompilationService`\.
        
        :type razorCompilationService: Microsoft.AspNetCore.Mvc.Razor.Compilation.IRazorCompilationService
    
        
        :param compilerCacheProvider: The :any:`Microsoft.AspNetCore.Mvc.Razor.Internal.ICompilerCacheProvider`\.
        
        :type compilerCacheProvider: Microsoft.AspNetCore.Mvc.Razor.Internal.ICompilerCacheProvider
    
        
        .. code-block:: csharp
    
            public DefaultRazorPageFactoryProvider(IRazorCompilationService razorCompilationService, ICompilerCacheProvider compilerCacheProvider)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultRazorPageFactoryProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultRazorPageFactoryProvider.CreateFactory(System.String)
    
        
    
        
        :type relativePath: System.String
        :rtype: Microsoft.AspNetCore.Mvc.Razor.RazorPageFactoryResult
    
        
        .. code-block:: csharp
    
            public RazorPageFactoryResult CreateFactory(string relativePath)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultRazorPageFactoryProvider.GetPageFactory(System.Type, System.String)
    
        
    
        
        Creates a factory for :any:`Microsoft.AspNetCore.Mvc.Razor.IRazorPage`\.
    
        
    
        
        :param compiledType: The :any:`System.Type` to produce an instance of :any:`Microsoft.AspNetCore.Mvc.Razor.IRazorPage`
            from.
        
        :type compiledType: System.Type
    
        
        :param relativePath: The application relative path of the page.
        
        :type relativePath: System.String
        :rtype: System.Func<System.Func`1>{Microsoft.AspNetCore.Mvc.Razor.IRazorPage<Microsoft.AspNetCore.Mvc.Razor.IRazorPage>}
        :return: A factory for <em>compiledType</em>.
    
        
        .. code-block:: csharp
    
            protected virtual Func<IRazorPage> GetPageFactory(Type compiledType, string relativePath)
    

