

SharedOptions Class
===================



.. contents:: 
   :local:



Summary
-------

Options common to several middleware components





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.StaticFiles.Infrastructure.SharedOptions`








Syntax
------

.. code-block:: csharp

   public class SharedOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/staticfiles/src/Microsoft.AspNet.StaticFiles/Infrastructure/SharedOptions.cs>`_





.. dn:class:: Microsoft.AspNet.StaticFiles.Infrastructure.SharedOptions

Constructors
------------

.. dn:class:: Microsoft.AspNet.StaticFiles.Infrastructure.SharedOptions
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.StaticFiles.Infrastructure.SharedOptions.SharedOptions()
    
        
    
        Defaults to all request paths.
    
        
    
        
        .. code-block:: csharp
    
           public SharedOptions()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.StaticFiles.Infrastructure.SharedOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.StaticFiles.Infrastructure.SharedOptions.FileProvider
    
        
    
        The file system used to locate resources
    
        
        :rtype: Microsoft.AspNet.FileProviders.IFileProvider
    
        
        .. code-block:: csharp
    
           public IFileProvider FileProvider { get; set; }
    
    .. dn:property:: Microsoft.AspNet.StaticFiles.Infrastructure.SharedOptions.RequestPath
    
        
    
        The request path that maps to static resources
    
        
        :rtype: Microsoft.AspNet.Http.PathString
    
        
        .. code-block:: csharp
    
           public PathString RequestPath { get; set; }
    

