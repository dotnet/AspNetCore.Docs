

IClaimUidExtractor Interface
============================



.. contents:: 
   :local:



Summary
-------

This interface can extract unique identifers for a claims-based identity.











Syntax
------

.. code-block:: csharp

   public interface IClaimUidExtractor





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/antiforgery/src/Microsoft.AspNet.Antiforgery/IClaimUidExtractor.cs>`_





.. dn:interface:: Microsoft.AspNet.Antiforgery.IClaimUidExtractor

Methods
-------

.. dn:interface:: Microsoft.AspNet.Antiforgery.IClaimUidExtractor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Antiforgery.IClaimUidExtractor.ExtractClaimUid(System.Security.Claims.ClaimsIdentity)
    
        
    
        Extracts claims identifier.
    
        
        
        
        :param identity: The .
        
        :type identity: System.Security.Claims.ClaimsIdentity
        :rtype: System.String
        :return: The claims identifier.
    
        
        .. code-block:: csharp
    
           string ExtractClaimUid(ClaimsIdentity identity)
    

