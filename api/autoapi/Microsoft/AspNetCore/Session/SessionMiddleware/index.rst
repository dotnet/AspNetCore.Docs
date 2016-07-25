

SessionMiddleware Class
=======================






Enables the session state for the application.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Session`
Assemblies
    * Microsoft.AspNetCore.Session

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Session.SessionMiddleware`








Syntax
------

.. code-block:: csharp

    public class SessionMiddleware








.. dn:class:: Microsoft.AspNetCore.Session.SessionMiddleware
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Session.SessionMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Session.SessionMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Session.SessionMiddleware.SessionMiddleware(Microsoft.AspNetCore.Http.RequestDelegate, Microsoft.Extensions.Logging.ILoggerFactory, Microsoft.AspNetCore.DataProtection.IDataProtectionProvider, Microsoft.AspNetCore.Session.ISessionStore, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Builder.SessionOptions>)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Session.SessionMiddleware`\.
    
        
    
        
        :param next: The :any:`Microsoft.AspNetCore.Http.RequestDelegate` representing the next middleware in the pipeline.
        
        :type next: Microsoft.AspNetCore.Http.RequestDelegate
    
        
        :param loggerFactory: The :any:`Microsoft.Extensions.Logging.ILoggerFactory` representing the factory that used to create logger instances.
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        :param dataProtectionProvider: The :any:`Microsoft.AspNetCore.DataProtection.IDataProtectionProvider` used to protect and verify the cookie.
        
        :type dataProtectionProvider: Microsoft.AspNetCore.DataProtection.IDataProtectionProvider
    
        
        :param sessionStore: The :any:`Microsoft.AspNetCore.Session.ISessionStore` representing the session store.
        
        :type sessionStore: Microsoft.AspNetCore.Session.ISessionStore
    
        
        :param options: The session configuration options.
        
        :type options: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Builder.SessionOptions<Microsoft.AspNetCore.Builder.SessionOptions>}
    
        
        .. code-block:: csharp
    
            public SessionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory, IDataProtectionProvider dataProtectionProvider, ISessionStore sessionStore, IOptions<SessionOptions> options)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Session.SessionMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Session.SessionMiddleware.Invoke(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        Invokes the logic of the middleware.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Http.HttpContext`\.
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
        :return: A :any:`System.Threading.Tasks.Task` that completes when the middleware has completed processing.
    
        
        .. code-block:: csharp
    
            public Task Invoke(HttpContext context)
    

