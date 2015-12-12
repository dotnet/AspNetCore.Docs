

VirtualPathRazorPageFactory Class
=================================



.. contents:: 
   :local:



Summary
-------

Represents a :any:`Microsoft.AspNet.Mvc.Razor.IRazorPageFactory` that creates :any:`Microsoft.AspNet.Mvc.Razor.RazorPage` instances
from razor files in the file system.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.VirtualPathRazorPageFactory`








Syntax
------

.. code-block:: csharp

   public class VirtualPathRazorPageFactory : IRazorPageFactory





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Razor/VirtualPathRazorPageFactory.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.VirtualPathRazorPageFactory

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.VirtualPathRazorPageFactory
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.VirtualPathRazorPageFactory.VirtualPathRazorPageFactory(Microsoft.AspNet.Mvc.Razor.Compilation.IRazorCompilationService, Microsoft.AspNet.Mvc.Razor.Compilation.ICompilerCacheProvider)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Mvc.Razor.VirtualPathRazorPageFactory`\.
    
        
        
        
        :param razorCompilationService: The .
        
        :type razorCompilationService: Microsoft.AspNet.Mvc.Razor.Compilation.IRazorCompilationService
        
        
        :param compilerCacheProvider: The .
        
        :type compilerCacheProvider: Microsoft.AspNet.Mvc.Razor.Compilation.ICompilerCacheProvider
    
        
        .. code-block:: csharp
    
           public VirtualPathRazorPageFactory(IRazorCompilationService razorCompilationService, ICompilerCacheProvider compilerCacheProvider)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.VirtualPathRazorPageFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.VirtualPathRazorPageFactory.CreateInstance(System.String)
    
        
        
        
        :type relativePath: System.String
        :rtype: Microsoft.AspNet.Mvc.Razor.IRazorPage
    
        
        .. code-block:: csharp
    
           public IRazorPage CreateInstance(string relativePath)
    

