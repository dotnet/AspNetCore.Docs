

IClaimsTransformer Interface
============================






Used for claims transformation.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication`
Assemblies
    * Microsoft.AspNetCore.Authentication

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IClaimsTransformer








.. dn:interface:: Microsoft.AspNetCore.Authentication.IClaimsTransformer
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Authentication.IClaimsTransformer

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Authentication.IClaimsTransformer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authentication.IClaimsTransformer.TransformAsync(Microsoft.AspNetCore.Authentication.ClaimsTransformationContext)
    
        
    
        
        Provides a central transformation point to change the specified principal.
    
        
    
        
        :param context: :any:`Microsoft.AspNetCore.Authentication.ClaimsTransformationContext` containing principal to transform and current HttpContext.
        
        :type context: Microsoft.AspNetCore.Authentication.ClaimsTransformationContext
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Security.Claims.ClaimsPrincipal<System.Security.Claims.ClaimsPrincipal>}
        :return: The transformed principal.
    
        
        .. code-block:: csharp
    
            Task<ClaimsPrincipal> TransformAsync(ClaimsTransformationContext context)
    

