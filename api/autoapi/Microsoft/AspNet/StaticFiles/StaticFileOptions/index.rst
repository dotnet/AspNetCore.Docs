

StaticFileOptions Class
=======================



.. contents:: 
   :local:



Summary
-------

Options for serving static files





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.StaticFiles.Infrastructure.SharedOptionsBase{Microsoft.AspNet.StaticFiles.StaticFileOptions}`
* :dn:cls:`Microsoft.AspNet.StaticFiles.StaticFileOptions`








Syntax
------

.. code-block:: csharp

   public class StaticFileOptions : SharedOptionsBase<StaticFileOptions>





GitHub
------

`View on GitHub <https://github.com/aspnet/staticfiles/blob/master/src/Microsoft.AspNet.StaticFiles/StaticFileOptions.cs>`_





.. dn:class:: Microsoft.AspNet.StaticFiles.StaticFileOptions

Constructors
------------

.. dn:class:: Microsoft.AspNet.StaticFiles.StaticFileOptions
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.StaticFiles.StaticFileOptions.StaticFileOptions()
    
        
    
        Defaults to all request paths
    
        
    
        
        .. code-block:: csharp
    
           public StaticFileOptions()
    
    .. dn:constructor:: Microsoft.AspNet.StaticFiles.StaticFileOptions.StaticFileOptions(Microsoft.AspNet.StaticFiles.Infrastructure.SharedOptions)
    
        
    
        Defaults to all request paths
    
        
        
        
        :type sharedOptions: Microsoft.AspNet.StaticFiles.Infrastructure.SharedOptions
    
        
        .. code-block:: csharp
    
           public StaticFileOptions(SharedOptions sharedOptions)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.StaticFiles.StaticFileOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.StaticFiles.StaticFileOptions.ContentTypeProvider
    
        
    
        Used to map files to content-types.
    
        
        :rtype: Microsoft.AspNet.StaticFiles.IContentTypeProvider
    
        
        .. code-block:: csharp
    
           public IContentTypeProvider ContentTypeProvider { get; set; }
    
    .. dn:property:: Microsoft.AspNet.StaticFiles.StaticFileOptions.DefaultContentType
    
        
    
        The default content type for a request if the ContentTypeProvider cannot determine one.
        None is provided by default, so the client must determine the format themselves.
        http://www.w3.org/Protocols/rfc2616/rfc2616-sec7.html#sec7
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string DefaultContentType { get; set; }
    
    .. dn:property:: Microsoft.AspNet.StaticFiles.StaticFileOptions.OnPrepareResponse
    
        
    
        Called after the status code and headers have been set, but before the body has been written.
        This can be used to add or change the response headers.
    
        
        :rtype: System.Action{Microsoft.AspNet.StaticFiles.StaticFileResponseContext}
    
        
        .. code-block:: csharp
    
           public Action<StaticFileResponseContext> OnPrepareResponse { get; set; }
    
    .. dn:property:: Microsoft.AspNet.StaticFiles.StaticFileOptions.ServeUnknownFileTypes
    
        
    
        If the file is not a recognized content-type should it be served?
        Default: false.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool ServeUnknownFileTypes { get; set; }
    

