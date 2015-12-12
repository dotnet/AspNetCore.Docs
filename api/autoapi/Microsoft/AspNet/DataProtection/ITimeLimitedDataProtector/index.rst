

ITimeLimitedDataProtector Interface
===================================



.. contents:: 
   :local:



Summary
-------

An interface that can provide data protection services where payloads have
a finite lifetime.











Syntax
------

.. code-block:: csharp

   public interface ITimeLimitedDataProtector : IDataProtector, IDataProtectionProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/dataprotection/src/Microsoft.AspNet.DataProtection.Extensions/ITimeLimitedDataProtector.cs>`_





.. dn:interface:: Microsoft.AspNet.DataProtection.ITimeLimitedDataProtector

Methods
-------

.. dn:interface:: Microsoft.AspNet.DataProtection.ITimeLimitedDataProtector
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.DataProtection.ITimeLimitedDataProtector.CreateProtector(System.String)
    
        
    
        Creates an :any:`Microsoft.AspNet.DataProtection.ITimeLimitedDataProtector` given a purpose.
    
        
        
        
        :type purpose: System.String
        :rtype: Microsoft.AspNet.DataProtection.ITimeLimitedDataProtector
        :return: An <see cref="T:Microsoft.AspNet.DataProtection.ITimeLimitedDataProtector" /> tied to the provided purpose.
    
        
        .. code-block:: csharp
    
           ITimeLimitedDataProtector CreateProtector(string purpose)
    
    .. dn:method:: Microsoft.AspNet.DataProtection.ITimeLimitedDataProtector.Protect(System.Byte[], System.DateTimeOffset)
    
        
    
        Cryptographically protects a piece of plaintext data, expiring the data at
        the chosen time.
    
        
        
        
        :param plaintext: The plaintext data to protect.
        
        :type plaintext: System.Byte[]
        
        
        :param expiration: The time when this payload should expire.
        
        :type expiration: System.DateTimeOffset
        :rtype: System.Byte[]
        :return: The protected form of the plaintext data.
    
        
        .. code-block:: csharp
    
           byte[] Protect(byte[] plaintext, DateTimeOffset expiration)
    
    .. dn:method:: Microsoft.AspNet.DataProtection.ITimeLimitedDataProtector.Unprotect(System.Byte[], out System.DateTimeOffset)
    
        
    
        Cryptographically unprotects a piece of protected data.
    
        
        
        
        :param protectedData: The protected data to unprotect.
        
        :type protectedData: System.Byte[]
        
        
        :param expiration: An 'out' parameter which upon a successful unprotect
            operation receives the expiration date of the payload.
        
        :type expiration: System.DateTimeOffset
        :rtype: System.Byte[]
        :return: The plaintext form of the protected data.
    
        
        .. code-block:: csharp
    
           byte[] Unprotect(byte[] protectedData, out DateTimeOffset expiration)
    

