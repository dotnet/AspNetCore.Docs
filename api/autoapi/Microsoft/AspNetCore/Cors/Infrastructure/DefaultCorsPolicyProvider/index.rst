

DefaultCorsPolicyProvider Class
===============================





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
* :dn:cls:`Microsoft.AspNetCore.Cors.Infrastructure.DefaultCorsPolicyProvider`








Syntax
------

.. code-block:: csharp

    public class DefaultCorsPolicyProvider : ICorsPolicyProvider








.. dn:class:: Microsoft.AspNetCore.Cors.Infrastructure.DefaultCorsPolicyProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Cors.Infrastructure.DefaultCorsPolicyProvider

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Cors.Infrastructure.DefaultCorsPolicyProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Cors.Infrastructure.DefaultCorsPolicyProvider.DefaultCorsPolicyProvider(Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Cors.Infrastructure.CorsOptions>)
    
        
    
        
        Creates a new instance of :any:`Microsoft.AspNetCore.Cors.Infrastructure.DefaultCorsPolicyProvider`\.
    
        
    
        
        :param options: The options configured for the application.
        
        :type options: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Cors.Infrastructure.CorsOptions<Microsoft.AspNetCore.Cors.Infrastructure.CorsOptions>}
    
        
        .. code-block:: csharp
    
            public DefaultCorsPolicyProvider(IOptions<CorsOptions> options)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Cors.Infrastructure.DefaultCorsPolicyProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Cors.Infrastructure.DefaultCorsPolicyProvider.GetPolicyAsync(Microsoft.AspNetCore.Http.HttpContext, System.String)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type policyName: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy<Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy>}
    
        
        .. code-block:: csharp
    
            public Task<CorsPolicy> GetPolicyAsync(HttpContext context, string policyName)
    

