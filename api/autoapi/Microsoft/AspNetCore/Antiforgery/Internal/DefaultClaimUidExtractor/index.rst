

DefaultClaimUidExtractor Class
==============================






Default implementation of :any:`Microsoft.AspNetCore.Antiforgery.Internal.IClaimUidExtractor`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Antiforgery.Internal`
Assemblies
    * Microsoft.AspNetCore.Antiforgery

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Antiforgery.Internal.DefaultClaimUidExtractor`








Syntax
------

.. code-block:: csharp

    public class DefaultClaimUidExtractor : IClaimUidExtractor








.. dn:class:: Microsoft.AspNetCore.Antiforgery.Internal.DefaultClaimUidExtractor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Antiforgery.Internal.DefaultClaimUidExtractor

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Antiforgery.Internal.DefaultClaimUidExtractor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Antiforgery.Internal.DefaultClaimUidExtractor.DefaultClaimUidExtractor(Microsoft.Extensions.ObjectPool.ObjectPool<Microsoft.AspNetCore.Antiforgery.Internal.AntiforgerySerializationContext>)
    
        
    
        
        :type pool: Microsoft.Extensions.ObjectPool.ObjectPool<Microsoft.Extensions.ObjectPool.ObjectPool`1>{Microsoft.AspNetCore.Antiforgery.Internal.AntiforgerySerializationContext<Microsoft.AspNetCore.Antiforgery.Internal.AntiforgerySerializationContext>}
    
        
        .. code-block:: csharp
    
            public DefaultClaimUidExtractor(ObjectPool<AntiforgerySerializationContext> pool)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Antiforgery.Internal.DefaultClaimUidExtractor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Antiforgery.Internal.DefaultClaimUidExtractor.ExtractClaimUid(System.Security.Claims.ClaimsPrincipal)
    
        
    
        
        :type claimsPrincipal: System.Security.Claims.ClaimsPrincipal
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ExtractClaimUid(ClaimsPrincipal claimsPrincipal)
    
    .. dn:method:: Microsoft.AspNetCore.Antiforgery.Internal.DefaultClaimUidExtractor.GetUniqueIdentifierParameters(System.Collections.Generic.IEnumerable<System.Security.Claims.ClaimsIdentity>)
    
        
    
        
        :type claimsIdentities: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.Security.Claims.ClaimsIdentity<System.Security.Claims.ClaimsIdentity>}
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public static IList<string> GetUniqueIdentifierParameters(IEnumerable<ClaimsIdentity> claimsIdentities)
    

