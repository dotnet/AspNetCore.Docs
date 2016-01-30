

SessionMiddleware Class
=======================



.. contents:: 
   :local:



Summary
-------

Enables the session state for the application.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Session.SessionMiddleware`








Syntax
------

.. code-block:: csharp

   public class SessionMiddleware





GitHub
------

`View on GitHub <https://github.com/aspnet/session/blob/master/src/Microsoft.AspNet.Session/SessionMiddleware.cs>`_





.. dn:class:: Microsoft.AspNet.Session.SessionMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNet.Session.SessionMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Session.SessionMiddleware.SessionMiddleware(Microsoft.AspNet.Builder.RequestDelegate, Microsoft.Extensions.Logging.ILoggerFactory, Microsoft.AspNet.Session.ISessionStore, Microsoft.Extensions.OptionsModel.IOptions<Microsoft.AspNet.Session.SessionOptions>)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Session.SessionMiddleware`\.
    
        
        
        
        :param next: The  representing the next middleware in the pipeline.
        
        :type next: Microsoft.AspNet.Builder.RequestDelegate
        
        
        :param loggerFactory: The  representing the factory that used to create logger instances.
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
        
        
        :param sessionStore: The  representing the session store.
        
        :type sessionStore: Microsoft.AspNet.Session.ISessionStore
        
        
        :param options: The session configuration options.
        
        :type options: Microsoft.Extensions.OptionsModel.IOptions{Microsoft.AspNet.Session.SessionOptions}
    
        
        .. code-block:: csharp
    
           public SessionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory, ISessionStore sessionStore, IOptions<SessionOptions> options)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Session.SessionMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Session.SessionMiddleware.Invoke(Microsoft.AspNet.Http.HttpContext)
    
        
    
        Invokes the logic of the middleware.
    
        
        
        
        :param context: The .
        
        :type context: Microsoft.AspNet.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
        :return: A <see cref="T:System.Threading.Tasks.Task" /> that completes when the middleware has completed processing.
    
        
        .. code-block:: csharp
    
           public Task Invoke(HttpContext context)
    

