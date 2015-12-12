

StaticFileResponseContext Class
===============================



.. contents:: 
   :local:



Summary
-------

Contains information about the request and the file that will be served in response.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.StaticFiles.StaticFileResponseContext`








Syntax
------

.. code-block:: csharp

   public class StaticFileResponseContext





GitHub
------

`View on GitHub <https://github.com/aspnet/staticfiles/blob/master/src/Microsoft.AspNet.StaticFiles/StaticFileResponseContext.cs>`_





.. dn:class:: Microsoft.AspNet.StaticFiles.StaticFileResponseContext

Properties
----------

.. dn:class:: Microsoft.AspNet.StaticFiles.StaticFileResponseContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.StaticFiles.StaticFileResponseContext.Context
    
        
    
        The request and response information.
    
        
        :rtype: Microsoft.AspNet.Http.HttpContext
    
        
        .. code-block:: csharp
    
           public HttpContext Context { get; }
    
    .. dn:property:: Microsoft.AspNet.StaticFiles.StaticFileResponseContext.File
    
        
    
        The file to be served.
    
        
        :rtype: Microsoft.AspNet.FileProviders.IFileInfo
    
        
        .. code-block:: csharp
    
           public IFileInfo File { get; }
    

