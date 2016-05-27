

IDataProtector Interface
========================






An interface that can provide data protection services.


Namespace
    :dn:ns:`Microsoft.AspNetCore.DataProtection`
Assemblies
    * Microsoft.AspNetCore.DataProtection.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IDataProtector : IDataProtectionProvider








.. dn:interface:: Microsoft.AspNetCore.DataProtection.IDataProtector
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.DataProtection.IDataProtector

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.DataProtection.IDataProtector
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.IDataProtector.Protect(System.Byte[])
    
        
    
        
        Cryptographically protects a piece of plaintext data.
    
        
    
        
        :param plaintext: The plaintext data to protect.
        
        :type plaintext: System.Byte<System.Byte>[]
        :rtype: System.Byte<System.Byte>[]
        :return: The protected form of the plaintext data.
    
        
        .. code-block:: csharp
    
            byte[] Protect(byte[] plaintext)
    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.IDataProtector.Unprotect(System.Byte[])
    
        
    
        
        Cryptographically unprotects a piece of protected data.
    
        
    
        
        :param protectedData: The protected data to unprotect.
        
        :type protectedData: System.Byte<System.Byte>[]
        :rtype: System.Byte<System.Byte>[]
        :return: The plaintext form of the protected data.
    
        
        .. code-block:: csharp
    
            byte[] Unprotect(byte[] protectedData)
    

