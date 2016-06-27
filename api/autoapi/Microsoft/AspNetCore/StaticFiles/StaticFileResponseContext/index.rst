

StaticFileResponseContext Class
===============================






Contains information about the request and the file that will be served in response.


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
* :dn:cls:`Microsoft.AspNetCore.StaticFiles.StaticFileResponseContext`








Syntax
------

.. code-block:: csharp

    public class StaticFileResponseContext








.. dn:class:: Microsoft.AspNetCore.StaticFiles.StaticFileResponseContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.StaticFiles.StaticFileResponseContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.StaticFiles.StaticFileResponseContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.StaticFiles.StaticFileResponseContext.Context
    
        
    
        
        The request and response information.
    
        
        :rtype: Microsoft.AspNetCore.Http.HttpContext
    
        
        .. code-block:: csharp
    
            public HttpContext Context { get; }
    
    .. dn:property:: Microsoft.AspNetCore.StaticFiles.StaticFileResponseContext.File
    
        
    
        
        The file to be served.
    
        
        :rtype: Microsoft.Extensions.FileProviders.IFileInfo
    
        
        .. code-block:: csharp
    
            public IFileInfo File { get; }
    

