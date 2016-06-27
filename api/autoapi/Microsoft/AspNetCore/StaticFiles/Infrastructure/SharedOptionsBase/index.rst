

SharedOptionsBase Class
=======================






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
* :dn:cls:`Microsoft.AspNetCore.StaticFiles.Infrastructure.SharedOptionsBase`








Syntax
------

.. code-block:: csharp

    public abstract class SharedOptionsBase








.. dn:class:: Microsoft.AspNetCore.StaticFiles.Infrastructure.SharedOptionsBase
    :hidden:

.. dn:class:: Microsoft.AspNetCore.StaticFiles.Infrastructure.SharedOptionsBase

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.StaticFiles.Infrastructure.SharedOptionsBase
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.StaticFiles.Infrastructure.SharedOptionsBase.SharedOptionsBase(Microsoft.AspNetCore.StaticFiles.Infrastructure.SharedOptions)
    
        
    
        
        Creates an new instance of the SharedOptionsBase.
    
        
    
        
        :type sharedOptions: Microsoft.AspNetCore.StaticFiles.Infrastructure.SharedOptions
    
        
        .. code-block:: csharp
    
            protected SharedOptionsBase(SharedOptions sharedOptions)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.StaticFiles.Infrastructure.SharedOptionsBase
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.StaticFiles.Infrastructure.SharedOptionsBase.FileProvider
    
        
    
        
        The file system used to locate resources
    
        
        :rtype: Microsoft.Extensions.FileProviders.IFileProvider
    
        
        .. code-block:: csharp
    
            public IFileProvider FileProvider { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.StaticFiles.Infrastructure.SharedOptionsBase.RequestPath
    
        
    
        
        The relative request path that maps to static resources.
    
        
        :rtype: Microsoft.AspNetCore.Http.PathString
    
        
        .. code-block:: csharp
    
            public PathString RequestPath { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.StaticFiles.Infrastructure.SharedOptionsBase.SharedOptions
    
        
    
        
        Options common to several middleware components
    
        
        :rtype: Microsoft.AspNetCore.StaticFiles.Infrastructure.SharedOptions
    
        
        .. code-block:: csharp
    
            protected SharedOptions SharedOptions { get; }
    

