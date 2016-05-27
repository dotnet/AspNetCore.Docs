

ITimeLimitedDataProtector Interface
===================================






An interface that can provide data protection services where payloads have
a finite lifetime.


Namespace
    :dn:ns:`Microsoft.AspNetCore.DataProtection`
Assemblies
    * Microsoft.AspNetCore.DataProtection.Extensions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface ITimeLimitedDataProtector : IDataProtector, IDataProtectionProvider








.. dn:interface:: Microsoft.AspNetCore.DataProtection.ITimeLimitedDataProtector
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.DataProtection.ITimeLimitedDataProtector

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.DataProtection.ITimeLimitedDataProtector
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.ITimeLimitedDataProtector.CreateProtector(System.String)
    
        
    
        
        Creates an :any:`Microsoft.AspNetCore.DataProtection.ITimeLimitedDataProtector` given a purpose.
    
        
    
        
        :param purpose: 
            The purpose to be assigned to the newly-created :any:`Microsoft.AspNetCore.DataProtection.ITimeLimitedDataProtector`\.
        
        :type purpose: System.String
        :rtype: Microsoft.AspNetCore.DataProtection.ITimeLimitedDataProtector
        :return: An :any:`Microsoft.AspNetCore.DataProtection.ITimeLimitedDataProtector` tied to the provided purpose.
    
        
        .. code-block:: csharp
    
            ITimeLimitedDataProtector CreateProtector(string purpose)
    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.ITimeLimitedDataProtector.Protect(System.Byte[], System.DateTimeOffset)
    
        
    
        
        Cryptographically protects a piece of plaintext data, expiring the data at
        the chosen time.
    
        
    
        
        :param plaintext: The plaintext data to protect.
        
        :type plaintext: System.Byte<System.Byte>[]
    
        
        :param expiration: The time when this payload should expire.
        
        :type expiration: System.DateTimeOffset
        :rtype: System.Byte<System.Byte>[]
        :return: The protected form of the plaintext data.
    
        
        .. code-block:: csharp
    
            byte[] Protect(byte[] plaintext, DateTimeOffset expiration)
    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.ITimeLimitedDataProtector.Unprotect(System.Byte[], out System.DateTimeOffset)
    
        
    
        
        Cryptographically unprotects a piece of protected data.
    
        
    
        
        :param protectedData: The protected data to unprotect.
        
        :type protectedData: System.Byte<System.Byte>[]
    
        
        :param expiration: An 'out' parameter which upon a successful unprotect
            operation receives the expiration date of the payload.
        
        :type expiration: System.DateTimeOffset
        :rtype: System.Byte<System.Byte>[]
        :return: The plaintext form of the protected data.
    
        
        .. code-block:: csharp
    
            byte[] Unprotect(byte[] protectedData, out DateTimeOffset expiration)
    

