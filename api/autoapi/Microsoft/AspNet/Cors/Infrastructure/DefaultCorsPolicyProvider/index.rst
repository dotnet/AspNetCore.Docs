

DefaultCorsPolicyProvider Class
===============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Cors.Infrastructure.DefaultCorsPolicyProvider`








Syntax
------

.. code-block:: csharp

   public class DefaultCorsPolicyProvider : ICorsPolicyProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/cors/src/Microsoft.AspNet.Cors/DefaultCorsPolicyProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Cors.Infrastructure.DefaultCorsPolicyProvider

Constructors
------------

.. dn:class:: Microsoft.AspNet.Cors.Infrastructure.DefaultCorsPolicyProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Cors.Infrastructure.DefaultCorsPolicyProvider.DefaultCorsPolicyProvider(Microsoft.Extensions.OptionsModel.IOptions<Microsoft.AspNet.Cors.Infrastructure.CorsOptions>)
    
        
    
        Creates a new instance of :any:`Microsoft.AspNet.Cors.Infrastructure.DefaultCorsPolicyProvider`\.
    
        
        
        
        :param options: The options configured for the application.
        
        :type options: Microsoft.Extensions.OptionsModel.IOptions{Microsoft.AspNet.Cors.Infrastructure.CorsOptions}
    
        
        .. code-block:: csharp
    
           public DefaultCorsPolicyProvider(IOptions<CorsOptions> options)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Cors.Infrastructure.DefaultCorsPolicyProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Cors.Infrastructure.DefaultCorsPolicyProvider.GetPolicyAsync(Microsoft.AspNet.Http.HttpContext, System.String)
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :type policyName: System.String
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Cors.Infrastructure.CorsPolicy}
    
        
        .. code-block:: csharp
    
           public Task<CorsPolicy> GetPolicyAsync(HttpContext context, string policyName)
    

