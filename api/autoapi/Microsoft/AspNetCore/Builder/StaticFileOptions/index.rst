

StaticFileOptions Class
=======================






Options for serving static files


Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.StaticFiles

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.StaticFiles.Infrastructure.SharedOptionsBase`
* :dn:cls:`Microsoft.AspNetCore.Builder.StaticFileOptions`








Syntax
------

.. code-block:: csharp

    public class StaticFileOptions : SharedOptionsBase








.. dn:class:: Microsoft.AspNetCore.Builder.StaticFileOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.StaticFileOptions

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Builder.StaticFileOptions
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Builder.StaticFileOptions.StaticFileOptions()
    
        
    
        
        Defaults to all request paths
    
        
    
        
        .. code-block:: csharp
    
            public StaticFileOptions()
    
    .. dn:constructor:: Microsoft.AspNetCore.Builder.StaticFileOptions.StaticFileOptions(Microsoft.AspNetCore.StaticFiles.Infrastructure.SharedOptions)
    
        
    
        
        Defaults to all request paths
    
        
    
        
        :type sharedOptions: Microsoft.AspNetCore.StaticFiles.Infrastructure.SharedOptions
    
        
        .. code-block:: csharp
    
            public StaticFileOptions(SharedOptions sharedOptions)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Builder.StaticFileOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Builder.StaticFileOptions.ContentTypeProvider
    
        
    
        
        Used to map files to content-types.
    
        
        :rtype: Microsoft.AspNetCore.StaticFiles.IContentTypeProvider
    
        
        .. code-block:: csharp
    
            public IContentTypeProvider ContentTypeProvider { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.StaticFileOptions.DefaultContentType
    
        
    
        
        The default content type for a request if the ContentTypeProvider cannot determine one.
        None is provided by default, so the client must determine the format themselves.
        http://www.w3.org/Protocols/rfc2616/rfc2616-sec7.html#sec7
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string DefaultContentType { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.StaticFileOptions.OnPrepareResponse
    
        
    
        
        Called after the status code and headers have been set, but before the body has been written.
        This can be used to add or change the response headers.
    
        
        :rtype: System.Action<System.Action`1>{Microsoft.AspNetCore.StaticFiles.StaticFileResponseContext<Microsoft.AspNetCore.StaticFiles.StaticFileResponseContext>}
    
        
        .. code-block:: csharp
    
            public Action<StaticFileResponseContext> OnPrepareResponse { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.StaticFileOptions.ServeUnknownFileTypes
    
        
    
        
        If the file is not a recognized content-type should it be served?
        Default: false.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool ServeUnknownFileTypes { get; set; }
    

