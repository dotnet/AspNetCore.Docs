

SharedOptionsBase<T> Class
==========================



.. contents:: 
   :local:



Summary
-------

Options common to several middleware components





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.StaticFiles.Infrastructure.SharedOptionsBase\<T>`








Syntax
------

.. code-block:: csharp

   public abstract class SharedOptionsBase<T>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/staticfiles/src/Microsoft.AspNet.StaticFiles/Infrastructure/SharedOptionsBase.cs>`_





.. dn:class:: Microsoft.AspNet.StaticFiles.Infrastructure.SharedOptionsBase<T>

Constructors
------------

.. dn:class:: Microsoft.AspNet.StaticFiles.Infrastructure.SharedOptionsBase<T>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.StaticFiles.Infrastructure.SharedOptionsBase<T>.SharedOptionsBase(Microsoft.AspNet.StaticFiles.Infrastructure.SharedOptions)
    
        
    
        Creates an new instance of the SharedOptionsBase.
    
        
        
        
        :type sharedOptions: Microsoft.AspNet.StaticFiles.Infrastructure.SharedOptions
    
        
        .. code-block:: csharp
    
           protected SharedOptionsBase(SharedOptions sharedOptions)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.StaticFiles.Infrastructure.SharedOptionsBase<T>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.StaticFiles.Infrastructure.SharedOptionsBase<T>.FileProvider
    
        
    
        The file system used to locate resources
    
        
        :rtype: Microsoft.AspNet.FileProviders.IFileProvider
    
        
        .. code-block:: csharp
    
           public IFileProvider FileProvider { get; set; }
    
    .. dn:property:: Microsoft.AspNet.StaticFiles.Infrastructure.SharedOptionsBase<T>.RequestPath
    
        
    
        The relative request path that maps to static resources.
    
        
        :rtype: Microsoft.AspNet.Http.PathString
    
        
        .. code-block:: csharp
    
           public PathString RequestPath { get; set; }
    
    .. dn:property:: Microsoft.AspNet.StaticFiles.Infrastructure.SharedOptionsBase<T>.SharedOptions
    
        
    
        Options common to several middleware components
    
        
        :rtype: Microsoft.AspNet.StaticFiles.Infrastructure.SharedOptions
    
        
        .. code-block:: csharp
    
           protected SharedOptions SharedOptions { get; }
    

