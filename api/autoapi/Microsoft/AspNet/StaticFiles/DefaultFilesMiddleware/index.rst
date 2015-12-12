

DefaultFilesMiddleware Class
============================



.. contents:: 
   :local:



Summary
-------

This examines a directory path and determines if there is a default file present.
If so the file name is appended to the path and execution continues.
Note we don't just serve the file because it may require interpretation.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.StaticFiles.DefaultFilesMiddleware`








Syntax
------

.. code-block:: csharp

   public class DefaultFilesMiddleware





GitHub
------

`View on GitHub <https://github.com/aspnet/staticfiles/blob/master/src/Microsoft.AspNet.StaticFiles/DefaultFilesMiddleware.cs>`_





.. dn:class:: Microsoft.AspNet.StaticFiles.DefaultFilesMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNet.StaticFiles.DefaultFilesMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.StaticFiles.DefaultFilesMiddleware.DefaultFilesMiddleware(Microsoft.AspNet.Builder.RequestDelegate, Microsoft.AspNet.Hosting.IHostingEnvironment, Microsoft.AspNet.StaticFiles.DefaultFilesOptions)
    
        
    
        Creates a new instance of the DefaultFilesMiddleware.
    
        
        
        
        :param next: The next middleware in the pipeline.
        
        :type next: Microsoft.AspNet.Builder.RequestDelegate
        
        
        :type hostingEnv: Microsoft.AspNet.Hosting.IHostingEnvironment
        
        
        :param options: The configuration options for this middleware.
        
        :type options: Microsoft.AspNet.StaticFiles.DefaultFilesOptions
    
        
        .. code-block:: csharp
    
           public DefaultFilesMiddleware(RequestDelegate next, IHostingEnvironment hostingEnv, DefaultFilesOptions options)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.StaticFiles.DefaultFilesMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.StaticFiles.DefaultFilesMiddleware.Invoke(Microsoft.AspNet.Http.HttpContext)
    
        
    
        This examines the request to see if it matches a configured directory, and if there are any files with the
        configured default names in that directory.  If so this will append the corresponding file name to the request
        path for a later middleware to handle.
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task Invoke(HttpContext context)
    

