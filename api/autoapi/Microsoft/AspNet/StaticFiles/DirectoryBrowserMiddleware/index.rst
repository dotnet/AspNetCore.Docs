

DirectoryBrowserMiddleware Class
================================



.. contents:: 
   :local:



Summary
-------

Enables directory browsing





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.StaticFiles.DirectoryBrowserMiddleware`








Syntax
------

.. code-block:: csharp

   public class DirectoryBrowserMiddleware





GitHub
------

`View on GitHub <https://github.com/aspnet/staticfiles/blob/master/src/Microsoft.AspNet.StaticFiles/DirectoryBrowserMiddleware.cs>`_





.. dn:class:: Microsoft.AspNet.StaticFiles.DirectoryBrowserMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNet.StaticFiles.DirectoryBrowserMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.StaticFiles.DirectoryBrowserMiddleware.DirectoryBrowserMiddleware(Microsoft.AspNet.Builder.RequestDelegate, Microsoft.AspNet.Hosting.IHostingEnvironment, Microsoft.AspNet.StaticFiles.DirectoryBrowserOptions)
    
        
    
        Creates a new instance of the SendFileMiddleware.
    
        
        
        
        :param next: The next middleware in the pipeline.
        
        :type next: Microsoft.AspNet.Builder.RequestDelegate
        
        
        :type hostingEnv: Microsoft.AspNet.Hosting.IHostingEnvironment
        
        
        :param options: The configuration for this middleware.
        
        :type options: Microsoft.AspNet.StaticFiles.DirectoryBrowserOptions
    
        
        .. code-block:: csharp
    
           public DirectoryBrowserMiddleware(RequestDelegate next, IHostingEnvironment hostingEnv, DirectoryBrowserOptions options)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.StaticFiles.DirectoryBrowserMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.StaticFiles.DirectoryBrowserMiddleware.Invoke(Microsoft.AspNet.Http.HttpContext)
    
        
    
        Examines the request to see if it matches a configured directory.  If so, a view of the directory contents is returned.
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task Invoke(HttpContext context)
    

