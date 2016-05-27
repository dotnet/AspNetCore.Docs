

AuthenticationMiddleware<TOptions> Class
========================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication`
Assemblies
    * Microsoft.AspNetCore.Authentication

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authentication.AuthenticationMiddleware\<TOptions>`








Syntax
------

.. code-block:: csharp

    public abstract class AuthenticationMiddleware<TOptions>
        where TOptions : AuthenticationOptions, new ()








.. dn:class:: Microsoft.AspNetCore.Authentication.AuthenticationMiddleware`1
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.AuthenticationMiddleware<TOptions>

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.AuthenticationMiddleware<TOptions>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.AuthenticationMiddleware<TOptions>.AuthenticationScheme
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string AuthenticationScheme
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.AuthenticationMiddleware<TOptions>.Logger
    
        
        :rtype: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
            public ILogger Logger
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.AuthenticationMiddleware<TOptions>.Options
    
        
        :rtype: TOptions
    
        
        .. code-block:: csharp
    
            public TOptions Options
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.AuthenticationMiddleware<TOptions>.UrlEncoder
    
        
        :rtype: System.Text.Encodings.Web.UrlEncoder
    
        
        .. code-block:: csharp
    
            public UrlEncoder UrlEncoder
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authentication.AuthenticationMiddleware<TOptions>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.AuthenticationMiddleware<TOptions>.AuthenticationMiddleware(Microsoft.AspNetCore.Http.RequestDelegate, Microsoft.Extensions.Options.IOptions<TOptions>, Microsoft.Extensions.Logging.ILoggerFactory, System.Text.Encodings.Web.UrlEncoder)
    
        
    
        
        :type next: Microsoft.AspNetCore.Http.RequestDelegate
    
        
        :type options: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{TOptions}
    
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        :type encoder: System.Text.Encodings.Web.UrlEncoder
    
        
        .. code-block:: csharp
    
            protected AuthenticationMiddleware(RequestDelegate next, IOptions<TOptions> options, ILoggerFactory loggerFactory, UrlEncoder encoder)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authentication.AuthenticationMiddleware<TOptions>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authentication.AuthenticationMiddleware<TOptions>.CreateHandler()
    
        
        :rtype: Microsoft.AspNetCore.Authentication.AuthenticationHandler<Microsoft.AspNetCore.Authentication.AuthenticationHandler`1>{TOptions}
    
        
        .. code-block:: csharp
    
            protected abstract AuthenticationHandler<TOptions> CreateHandler()
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.AuthenticationMiddleware<TOptions>.Invoke(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task Invoke(HttpContext context)
    

