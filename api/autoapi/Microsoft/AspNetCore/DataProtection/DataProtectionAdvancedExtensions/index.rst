

DataProtectionAdvancedExtensions Class
======================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.DataProtection`
Assemblies
    * Microsoft.AspNetCore.DataProtection.Extensions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.DataProtection.DataProtectionAdvancedExtensions`








Syntax
------

.. code-block:: csharp

    public class DataProtectionAdvancedExtensions








.. dn:class:: Microsoft.AspNetCore.DataProtection.DataProtectionAdvancedExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.DataProtection.DataProtectionAdvancedExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.DataProtection.DataProtectionAdvancedExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.DataProtectionAdvancedExtensions.Protect(Microsoft.AspNetCore.DataProtection.ITimeLimitedDataProtector, System.Byte[], System.TimeSpan)
    
        
    
        
        Cryptographically protects a piece of plaintext data, expiring the data after
        the specified amount of time has elapsed.
    
        
    
        
        :param protector: The protector to use.
        
        :type protector: Microsoft.AspNetCore.DataProtection.ITimeLimitedDataProtector
    
        
        :param plaintext: The plaintext data to protect.
        
        :type plaintext: System.Byte<System.Byte>[]
    
        
        :param lifetime: The amount of time after which the payload should no longer be unprotectable.
        
        :type lifetime: System.TimeSpan
        :rtype: System.Byte<System.Byte>[]
        :return: The protected form of the plaintext data.
    
        
        .. code-block:: csharp
    
            public static byte[] Protect(this ITimeLimitedDataProtector protector, byte[] plaintext, TimeSpan lifetime)
    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.DataProtectionAdvancedExtensions.Protect(Microsoft.AspNetCore.DataProtection.ITimeLimitedDataProtector, System.String, System.DateTimeOffset)
    
        
    
        
        Cryptographically protects a piece of plaintext data, expiring the data at
        the chosen time.
    
        
    
        
        :param protector: The protector to use.
        
        :type protector: Microsoft.AspNetCore.DataProtection.ITimeLimitedDataProtector
    
        
        :param plaintext: The plaintext data to protect.
        
        :type plaintext: System.String
    
        
        :param expiration: The time when this payload should expire.
        
        :type expiration: System.DateTimeOffset
        :rtype: System.String
        :return: The protected form of the plaintext data.
    
        
        .. code-block:: csharp
    
            public static string Protect(this ITimeLimitedDataProtector protector, string plaintext, DateTimeOffset expiration)
    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.DataProtectionAdvancedExtensions.Protect(Microsoft.AspNetCore.DataProtection.ITimeLimitedDataProtector, System.String, System.TimeSpan)
    
        
    
        
        Cryptographically protects a piece of plaintext data, expiring the data after
        the specified amount of time has elapsed.
    
        
    
        
        :param protector: The protector to use.
        
        :type protector: Microsoft.AspNetCore.DataProtection.ITimeLimitedDataProtector
    
        
        :param plaintext: The plaintext data to protect.
        
        :type plaintext: System.String
    
        
        :param lifetime: The amount of time after which the payload should no longer be unprotectable.
        
        :type lifetime: System.TimeSpan
        :rtype: System.String
        :return: The protected form of the plaintext data.
    
        
        .. code-block:: csharp
    
            public static string Protect(this ITimeLimitedDataProtector protector, string plaintext, TimeSpan lifetime)
    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.DataProtectionAdvancedExtensions.ToTimeLimitedDataProtector(Microsoft.AspNetCore.DataProtection.IDataProtector)
    
        
    
        
        Converts an :any:`Microsoft.AspNetCore.DataProtection.IDataProtector` into an :any:`Microsoft.AspNetCore.DataProtection.ITimeLimitedDataProtector`
        so that payloads can be protected with a finite lifetime.
    
        
    
        
        :param protector: The :any:`Microsoft.AspNetCore.DataProtection.IDataProtector` to convert to a time-limited protector.
        
        :type protector: Microsoft.AspNetCore.DataProtection.IDataProtector
        :rtype: Microsoft.AspNetCore.DataProtection.ITimeLimitedDataProtector
        :return: An :any:`Microsoft.AspNetCore.DataProtection.ITimeLimitedDataProtector`\.
    
        
        .. code-block:: csharp
    
            public static ITimeLimitedDataProtector ToTimeLimitedDataProtector(this IDataProtector protector)
    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.DataProtectionAdvancedExtensions.Unprotect(Microsoft.AspNetCore.DataProtection.ITimeLimitedDataProtector, System.String, out System.DateTimeOffset)
    
        
    
        
        Cryptographically unprotects a piece of protected data.
    
        
    
        
        :param protector: The protector to use.
        
        :type protector: Microsoft.AspNetCore.DataProtection.ITimeLimitedDataProtector
    
        
        :param protectedData: The protected data to unprotect.
        
        :type protectedData: System.String
    
        
        :param expiration: An 'out' parameter which upon a successful unprotect
            operation receives the expiration date of the payload.
        
        :type expiration: System.DateTimeOffset
        :rtype: System.String
        :return: The plaintext form of the protected data.
    
        
        .. code-block:: csharp
    
            public static string Unprotect(this ITimeLimitedDataProtector protector, string protectedData, out DateTimeOffset expiration)
    

