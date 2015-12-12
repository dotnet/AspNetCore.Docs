

RuntimeInfoMiddleware Class
===========================



.. contents:: 
   :local:



Summary
-------

Displays information about the packages used by the application at runtime





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Diagnostics.RuntimeInfoMiddleware`








Syntax
------

.. code-block:: csharp

   public class RuntimeInfoMiddleware





GitHub
------

`View on GitHub <https://github.com/aspnet/diagnostics/blob/master/src/Microsoft.AspNet.Diagnostics/RuntimeInfo/RuntimeInfoMiddleware.cs>`_





.. dn:class:: Microsoft.AspNet.Diagnostics.RuntimeInfoMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNet.Diagnostics.RuntimeInfoMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Diagnostics.RuntimeInfoMiddleware.RuntimeInfoMiddleware(Microsoft.AspNet.Builder.RequestDelegate, Microsoft.AspNet.Diagnostics.RuntimeInfoPageOptions, Microsoft.Extensions.PlatformAbstractions.ILibraryManager, Microsoft.Extensions.PlatformAbstractions.IRuntimeEnvironment)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Diagnostics.RuntimeInfoMiddleware` class
    
        
        
        
        :type next: Microsoft.AspNet.Builder.RequestDelegate
        
        
        :type options: Microsoft.AspNet.Diagnostics.RuntimeInfoPageOptions
        
        
        :type libraryManager: Microsoft.Extensions.PlatformAbstractions.ILibraryManager
        
        
        :type runtimeEnvironment: Microsoft.Extensions.PlatformAbstractions.IRuntimeEnvironment
    
        
        .. code-block:: csharp
    
           public RuntimeInfoMiddleware(RequestDelegate next, RuntimeInfoPageOptions options, ILibraryManager libraryManager, IRuntimeEnvironment runtimeEnvironment)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Diagnostics.RuntimeInfoMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Diagnostics.RuntimeInfoMiddleware.Invoke(Microsoft.AspNet.Http.HttpContext)
    
        
    
        Process an individual request.
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task Invoke(HttpContext context)
    

