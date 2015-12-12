

ClaimsTransformer Class
=======================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.ClaimsTransformer`








Syntax
------

.. code-block:: csharp

   public class ClaimsTransformer : IClaimsTransformer





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication/ClaimsTransformer.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.ClaimsTransformer

Methods
-------

.. dn:class:: Microsoft.AspNet.Authentication.ClaimsTransformer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authentication.ClaimsTransformer.TransformAsync(System.Security.Claims.ClaimsPrincipal)
    
        
        
        
        :type principal: System.Security.Claims.ClaimsPrincipal
        :rtype: System.Threading.Tasks.Task{System.Security.Claims.ClaimsPrincipal}
    
        
        .. code-block:: csharp
    
           public virtual Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.ClaimsTransformer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.ClaimsTransformer.OnTransform
    
        
        :rtype: System.Func{System.Security.Claims.ClaimsPrincipal,System.Threading.Tasks.Task{System.Security.Claims.ClaimsPrincipal}}
    
        
        .. code-block:: csharp
    
           public Func<ClaimsPrincipal, Task<ClaimsPrincipal>> OnTransform { get; set; }
    

