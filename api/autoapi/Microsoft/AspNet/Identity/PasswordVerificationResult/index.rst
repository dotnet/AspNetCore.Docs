

PasswordVerificationResult Enum
===============================



.. contents:: 
   :local:



Summary
-------

Specifies the results for password verification.











Syntax
------

.. code-block:: csharp

   public enum PasswordVerificationResult





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/identity/src/Microsoft.AspNet.Identity/PasswordVerificationResult.cs>`_





.. dn:enumeration:: Microsoft.AspNet.Identity.PasswordVerificationResult

Fields
------

.. dn:enumeration:: Microsoft.AspNet.Identity.PasswordVerificationResult
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Identity.PasswordVerificationResult.Failed
    
        
    
        Indicates password verification failed.
    
        
    
        
        .. code-block:: csharp
    
           Failed = 0
    
    .. dn:field:: Microsoft.AspNet.Identity.PasswordVerificationResult.Success
    
        
    
        Indicates password verification was successful.
    
        
    
        
        .. code-block:: csharp
    
           Success = 1
    
    .. dn:field:: Microsoft.AspNet.Identity.PasswordVerificationResult.SuccessRehashNeeded
    
        
    
        Indicates password verification was successful however the password was encoded using a deprecated algorithm
        and should be rehashed and updated.
    
        
    
        
        .. code-block:: csharp
    
           SuccessRehashNeeded = 2
    

