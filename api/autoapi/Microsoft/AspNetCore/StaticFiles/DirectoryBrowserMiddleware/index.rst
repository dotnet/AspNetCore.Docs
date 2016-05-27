

DirectoryBrowserMiddleware Class
================================






Enables directory browsing


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
* :dn:cls:`Microsoft.AspNetCore.StaticFiles.DirectoryBrowserMiddleware`








Syntax
------

.. code-block:: csharp

    public class DirectoryBrowserMiddleware








.. dn:class:: Microsoft.AspNetCore.StaticFiles.DirectoryBrowserMiddleware
    :hidden:

.. dn:class:: Microsoft.AspNetCore.StaticFiles.DirectoryBrowserMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.StaticFiles.DirectoryBrowserMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.StaticFiles.DirectoryBrowserMiddleware.DirectoryBrowserMiddleware(Microsoft.AspNetCore.Http.RequestDelegate, Microsoft.AspNetCore.Hosting.IHostingEnvironment, System.Text.Encodings.Web.HtmlEncoder, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Builder.DirectoryBrowserOptions>)
    
        
    
        
        Creates a new instance of the SendFileMiddleware.
    
        
    
        
        :param next: The next middleware in the pipeline.
        
        :type next: Microsoft.AspNetCore.Http.RequestDelegate
    
        
        :param hostingEnv: The :any:`Microsoft.AspNetCore.Hosting.IHostingEnvironment` used by this middleware.
        
        :type hostingEnv: Microsoft.AspNetCore.Hosting.IHostingEnvironment
    
        
        :param encoder: The :any:`System.Text.Encodings.Web.HtmlEncoder` used by the default :any:`Microsoft.AspNetCore.StaticFiles.HtmlDirectoryFormatter`\.
        
        :type encoder: System.Text.Encodings.Web.HtmlEncoder
    
        
        :param options: The configuration for this middleware.
        
        :type options: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Builder.DirectoryBrowserOptions<Microsoft.AspNetCore.Builder.DirectoryBrowserOptions>}
    
        
        .. code-block:: csharp
    
            public DirectoryBrowserMiddleware(RequestDelegate next, IHostingEnvironment hostingEnv, HtmlEncoder encoder, IOptions<DirectoryBrowserOptions> options)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.StaticFiles.DirectoryBrowserMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.StaticFiles.DirectoryBrowserMiddleware.Invoke(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        Examines the request to see if it matches a configured directory.  If so, a view of the directory contents is returned.
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task Invoke(HttpContext context)
    

