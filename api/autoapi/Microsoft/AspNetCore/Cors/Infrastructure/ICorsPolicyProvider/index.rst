

ICorsPolicyProvider Interface
=============================






A type which can provide a :any:`Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy` for a particular :any:`Microsoft.AspNetCore.Http.HttpContext`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Cors.Infrastructure`
Assemblies
    * Microsoft.AspNetCore.Cors

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface ICorsPolicyProvider








.. dn:interface:: Microsoft.AspNetCore.Cors.Infrastructure.ICorsPolicyProvider
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Cors.Infrastructure.ICorsPolicyProvider

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Cors.Infrastructure.ICorsPolicyProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Cors.Infrastructure.ICorsPolicyProvider.GetPolicyAsync(Microsoft.AspNetCore.Http.HttpContext, System.String)
    
        
    
        
        Gets a :any:`Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy` from the given <em>context</em>
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Http.HttpContext` associated with this call.
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :param policyName: An optional policy name to look for.
        
        :type policyName: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy<Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy>}
        :return: A :any:`Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy`
    
        
        .. code-block:: csharp
    
            Task<CorsPolicy> GetPolicyAsync(HttpContext context, string policyName)
    

