

CorsMiddleware Class
====================






An ASP.NET middleware for handling CORS.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Cors.Infrastructure`
Assemblies
    * Microsoft.AspNetCore.Cors

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Cors.Infrastructure.CorsMiddleware`








Syntax
------

.. code-block:: csharp

    public class CorsMiddleware








.. dn:class:: Microsoft.AspNetCore.Cors.Infrastructure.CorsMiddleware
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Cors.Infrastructure.CorsMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Cors.Infrastructure.CorsMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Cors.Infrastructure.CorsMiddleware.CorsMiddleware(Microsoft.AspNetCore.Http.RequestDelegate, Microsoft.AspNetCore.Cors.Infrastructure.ICorsService, Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy)
    
        
    
        
        Instantiates a new :any:`Microsoft.AspNetCore.Cors.Infrastructure.CorsMiddleware`\.
    
        
    
        
        :param next: The next middleware in the pipeline.
        
        :type next: Microsoft.AspNetCore.Http.RequestDelegate
    
        
        :param corsService: An instance of :any:`Microsoft.AspNetCore.Cors.Infrastructure.ICorsService`\.
        
        :type corsService: Microsoft.AspNetCore.Cors.Infrastructure.ICorsService
    
        
        :param policy: An instance of the :any:`Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy` which can be applied.
        
        :type policy: Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy
    
        
        .. code-block:: csharp
    
            public CorsMiddleware(RequestDelegate next, ICorsService corsService, CorsPolicy policy)
    
    .. dn:constructor:: Microsoft.AspNetCore.Cors.Infrastructure.CorsMiddleware.CorsMiddleware(Microsoft.AspNetCore.Http.RequestDelegate, Microsoft.AspNetCore.Cors.Infrastructure.ICorsService, Microsoft.AspNetCore.Cors.Infrastructure.ICorsPolicyProvider, System.String)
    
        
    
        
        Instantiates a new :any:`Microsoft.AspNetCore.Cors.Infrastructure.CorsMiddleware`\.
    
        
    
        
        :param next: The next middleware in the pipeline.
        
        :type next: Microsoft.AspNetCore.Http.RequestDelegate
    
        
        :param corsService: An instance of :any:`Microsoft.AspNetCore.Cors.Infrastructure.ICorsService`\.
        
        :type corsService: Microsoft.AspNetCore.Cors.Infrastructure.ICorsService
    
        
        :param policyProvider: A policy provider which can get an :any:`Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy`\.
        
        :type policyProvider: Microsoft.AspNetCore.Cors.Infrastructure.ICorsPolicyProvider
    
        
        :param policyName: An optional name of the policy to be fetched.
        
        :type policyName: System.String
    
        
        .. code-block:: csharp
    
            public CorsMiddleware(RequestDelegate next, ICorsService corsService, ICorsPolicyProvider policyProvider, string policyName)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Cors.Infrastructure.CorsMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Cors.Infrastructure.CorsMiddleware.Invoke(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task Invoke(HttpContext context)
    

