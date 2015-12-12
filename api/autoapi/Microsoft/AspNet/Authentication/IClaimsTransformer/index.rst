

IClaimsTransformer Interface
============================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IClaimsTransformer





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authentication/IClaimsTransformer.cs>`_





.. dn:interface:: Microsoft.AspNet.Authentication.IClaimsTransformer

Methods
-------

.. dn:interface:: Microsoft.AspNet.Authentication.IClaimsTransformer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authentication.IClaimsTransformer.TransformAsync(System.Security.Claims.ClaimsPrincipal)
    
        
        
        
        :type principal: System.Security.Claims.ClaimsPrincipal
        :rtype: System.Threading.Tasks.Task{System.Security.Claims.ClaimsPrincipal}
    
        
        .. code-block:: csharp
    
           Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    

