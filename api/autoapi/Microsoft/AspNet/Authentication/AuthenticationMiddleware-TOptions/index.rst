

AuthenticationMiddleware<TOptions> Class
========================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.AuthenticationMiddleware\<TOptions>`








Syntax
------

.. code-block:: csharp

   public abstract class AuthenticationMiddleware<TOptions> where TOptions : AuthenticationOptions, new ()





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authentication/AuthenticationMiddleware.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.AuthenticationMiddleware<TOptions>

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.AuthenticationMiddleware<TOptions>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.AuthenticationMiddleware<TOptions>.AuthenticationMiddleware(Microsoft.AspNet.Builder.RequestDelegate, TOptions, Microsoft.Extensions.Logging.ILoggerFactory, Microsoft.Extensions.WebEncoders.IUrlEncoder)
    
        
        
        
        :type next: Microsoft.AspNet.Builder.RequestDelegate
        
        
        :type options: {TOptions}
        
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
        
        
        :type encoder: Microsoft.Extensions.WebEncoders.IUrlEncoder
    
        
        .. code-block:: csharp
    
           protected AuthenticationMiddleware(RequestDelegate next, TOptions options, ILoggerFactory loggerFactory, IUrlEncoder encoder)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Authentication.AuthenticationMiddleware<TOptions>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authentication.AuthenticationMiddleware<TOptions>.CreateHandler()
    
        
        :rtype: Microsoft.AspNet.Authentication.AuthenticationHandler{{TOptions}}
    
        
        .. code-block:: csharp
    
           protected abstract AuthenticationHandler<TOptions> CreateHandler()
    
    .. dn:method:: Microsoft.AspNet.Authentication.AuthenticationMiddleware<TOptions>.Invoke(Microsoft.AspNet.Http.HttpContext)
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task Invoke(HttpContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.AuthenticationMiddleware<TOptions>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.AuthenticationMiddleware<TOptions>.AuthenticationScheme
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string AuthenticationScheme { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.AuthenticationMiddleware<TOptions>.Logger
    
        
        :rtype: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
           public ILogger Logger { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.AuthenticationMiddleware<TOptions>.Options
    
        
        :rtype: {TOptions}
    
        
        .. code-block:: csharp
    
           public TOptions Options { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.AuthenticationMiddleware<TOptions>.UrlEncoder
    
        
        :rtype: Microsoft.Extensions.WebEncoders.IUrlEncoder
    
        
        .. code-block:: csharp
    
           public IUrlEncoder UrlEncoder { get; set; }
    

