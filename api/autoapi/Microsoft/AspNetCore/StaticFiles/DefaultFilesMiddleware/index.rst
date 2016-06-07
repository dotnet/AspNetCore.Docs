

DefaultFilesMiddleware Class
============================






This examines a directory path and determines if there is a default file present.
If so the file name is appended to the path and execution continues.
Note we don't just serve the file because it may require interpretation.


Namespace
    :dn:ns:`Microsoft.AspNetCore.StaticFiles`
Assemblies
    * Microsoft.AspNetCore.StaticFiles

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.StaticFiles.DefaultFilesMiddleware`








Syntax
------

.. code-block:: csharp

    public class DefaultFilesMiddleware








.. dn:class:: Microsoft.AspNetCore.StaticFiles.DefaultFilesMiddleware
    :hidden:

.. dn:class:: Microsoft.AspNetCore.StaticFiles.DefaultFilesMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.StaticFiles.DefaultFilesMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.StaticFiles.DefaultFilesMiddleware.DefaultFilesMiddleware(Microsoft.AspNetCore.Http.RequestDelegate, Microsoft.AspNetCore.Hosting.IHostingEnvironment, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Builder.DefaultFilesOptions>)
    
        
    
        
        Creates a new instance of the DefaultFilesMiddleware.
    
        
    
        
        :param next: The next middleware in the pipeline.
        
        :type next: Microsoft.AspNetCore.Http.RequestDelegate
    
        
        :param hostingEnv: The :any:`Microsoft.AspNetCore.Hosting.IHostingEnvironment` used by this middleware.
        
        :type hostingEnv: Microsoft.AspNetCore.Hosting.IHostingEnvironment
    
        
        :param options: The configuration options for this middleware.
        
        :type options: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Builder.DefaultFilesOptions<Microsoft.AspNetCore.Builder.DefaultFilesOptions>}
    
        
        .. code-block:: csharp
    
            public DefaultFilesMiddleware(RequestDelegate next, IHostingEnvironment hostingEnv, IOptions<DefaultFilesOptions> options)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.StaticFiles.DefaultFilesMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.StaticFiles.DefaultFilesMiddleware.Invoke(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        This examines the request to see if it matches a configured directory, and if there are any files with the
        configured default names in that directory.  If so this will append the corresponding file name to the request
        path for a later middleware to handle.
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task Invoke(HttpContext context)
    

