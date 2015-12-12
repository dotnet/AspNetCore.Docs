

ICorsPolicyProvider Interface
=============================



.. contents:: 
   :local:



Summary
-------

A type which can provide a :any:`Microsoft.AspNet.Cors.Infrastructure.CorsPolicy` for a particular :any:`Microsoft.AspNet.Http.HttpContext`\.











Syntax
------

.. code-block:: csharp

   public interface ICorsPolicyProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/cors/src/Microsoft.AspNet.Cors/ICorsPolicyProvider.cs>`_





.. dn:interface:: Microsoft.AspNet.Cors.Infrastructure.ICorsPolicyProvider

Methods
-------

.. dn:interface:: Microsoft.AspNet.Cors.Infrastructure.ICorsPolicyProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Cors.Infrastructure.ICorsPolicyProvider.GetPolicyAsync(Microsoft.AspNet.Http.HttpContext, System.String)
    
        
    
        Gets a :any:`Microsoft.AspNet.Cors.Infrastructure.CorsPolicy` from the given ``context``
    
        
        
        
        :param context: The  associated with this call.
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :param policyName: An optional policy name to look for.
        
        :type policyName: System.String
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Cors.Infrastructure.CorsPolicy}
        :return: A <see cref="T:Microsoft.AspNet.Cors.Infrastructure.CorsPolicy" />
    
        
        .. code-block:: csharp
    
           Task<CorsPolicy> GetPolicyAsync(HttpContext context, string policyName)
    

