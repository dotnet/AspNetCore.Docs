

DefaultClaimUidExtractor Class
==============================



.. contents:: 
   :local:



Summary
-------

Default implementation of :any:`Microsoft.AspNet.Antiforgery.IClaimUidExtractor`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Antiforgery.DefaultClaimUidExtractor`








Syntax
------

.. code-block:: csharp

   public class DefaultClaimUidExtractor : IClaimUidExtractor





GitHub
------

`View on GitHub <https://github.com/aspnet/antiforgery/blob/master/src/Microsoft.AspNet.Antiforgery/DefaultClaimUidExtractor.cs>`_





.. dn:class:: Microsoft.AspNet.Antiforgery.DefaultClaimUidExtractor

Methods
-------

.. dn:class:: Microsoft.AspNet.Antiforgery.DefaultClaimUidExtractor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Antiforgery.DefaultClaimUidExtractor.ExtractClaimUid(System.Security.Claims.ClaimsIdentity)
    
        
        
        
        :type claimsIdentity: System.Security.Claims.ClaimsIdentity
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ExtractClaimUid(ClaimsIdentity claimsIdentity)
    

