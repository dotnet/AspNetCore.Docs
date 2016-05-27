

PasswordVerificationResult Enum
===============================






Specifies the results for password verification.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Identity`
Assemblies
    * Microsoft.AspNetCore.Identity

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public enum PasswordVerificationResult








.. dn:enumeration:: Microsoft.AspNetCore.Identity.PasswordVerificationResult
    :hidden:

.. dn:enumeration:: Microsoft.AspNetCore.Identity.PasswordVerificationResult

Fields
------

.. dn:enumeration:: Microsoft.AspNetCore.Identity.PasswordVerificationResult
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Identity.PasswordVerificationResult.Failed
    
        
    
        
        Indicates password verification failed.
    
        
        :rtype: Microsoft.AspNetCore.Identity.PasswordVerificationResult
    
        
        .. code-block:: csharp
    
            Failed = 0
    
    .. dn:field:: Microsoft.AspNetCore.Identity.PasswordVerificationResult.Success
    
        
    
        
        Indicates password verification was successful.
    
        
        :rtype: Microsoft.AspNetCore.Identity.PasswordVerificationResult
    
        
        .. code-block:: csharp
    
            Success = 1
    
    .. dn:field:: Microsoft.AspNetCore.Identity.PasswordVerificationResult.SuccessRehashNeeded
    
        
    
        
        Indicates password verification was successful however the password was encoded using a deprecated algorithm
        and should be rehashed and updated.
    
        
        :rtype: Microsoft.AspNetCore.Identity.PasswordVerificationResult
    
        
        .. code-block:: csharp
    
            SuccessRehashNeeded = 2
    

