

ClaimsTransformer Class
=======================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication`
Assemblies
    * Microsoft.AspNetCore.Authentication

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authentication.ClaimsTransformer`








Syntax
------

.. code-block:: csharp

    public class ClaimsTransformer : IClaimsTransformer








.. dn:class:: Microsoft.AspNetCore.Authentication.ClaimsTransformer
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.ClaimsTransformer

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.ClaimsTransformer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.ClaimsTransformer.OnTransform
    
        
        :rtype: System.Func<System.Func`2>{Microsoft.AspNetCore.Authentication.ClaimsTransformationContext<Microsoft.AspNetCore.Authentication.ClaimsTransformationContext>, System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Security.Claims.ClaimsPrincipal<System.Security.Claims.ClaimsPrincipal>}}
    
        
        .. code-block:: csharp
    
            public Func<ClaimsTransformationContext, Task<ClaimsPrincipal>> OnTransform { get; set; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authentication.ClaimsTransformer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authentication.ClaimsTransformer.TransformAsync(Microsoft.AspNetCore.Authentication.ClaimsTransformationContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Authentication.ClaimsTransformationContext
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Security.Claims.ClaimsPrincipal<System.Security.Claims.ClaimsPrincipal>}
    
        
        .. code-block:: csharp
    
            public virtual Task<ClaimsPrincipal> TransformAsync(ClaimsTransformationContext context)
    

