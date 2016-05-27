

SharedOptions Class
===================






Options common to several middleware components


Namespace
    :dn:ns:`Microsoft.AspNetCore.StaticFiles.Infrastructure`
Assemblies
    * Microsoft.AspNetCore.StaticFiles

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.StaticFiles.Infrastructure.SharedOptions`








Syntax
------

.. code-block:: csharp

    public class SharedOptions








.. dn:class:: Microsoft.AspNetCore.StaticFiles.Infrastructure.SharedOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.StaticFiles.Infrastructure.SharedOptions

Properties
----------

.. dn:class:: Microsoft.AspNetCore.StaticFiles.Infrastructure.SharedOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.StaticFiles.Infrastructure.SharedOptions.FileProvider
    
        
    
        
        The file system used to locate resources
    
        
        :rtype: Microsoft.Extensions.FileProviders.IFileProvider
    
        
        .. code-block:: csharp
    
            public IFileProvider FileProvider
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.StaticFiles.Infrastructure.SharedOptions.RequestPath
    
        
    
        
        The request path that maps to static resources
    
        
        :rtype: Microsoft.AspNetCore.Http.PathString
    
        
        .. code-block:: csharp
    
            public PathString RequestPath
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.StaticFiles.Infrastructure.SharedOptions
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.StaticFiles.Infrastructure.SharedOptions.SharedOptions()
    
        
    
        
        Defaults to all request paths.
    
        
    
        
        .. code-block:: csharp
    
            public SharedOptions()
    

