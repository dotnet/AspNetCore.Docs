

IDataProtector Interface
========================



.. contents:: 
   :local:



Summary
-------

An interface that can provide data protection services.











Syntax
------

.. code-block:: csharp

   public interface IDataProtector : IDataProtectionProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/dataprotection/blob/master/src/Microsoft.AspNet.DataProtection.Abstractions/IDataProtector.cs>`_





.. dn:interface:: Microsoft.AspNet.DataProtection.IDataProtector

Methods
-------

.. dn:interface:: Microsoft.AspNet.DataProtection.IDataProtector
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.DataProtection.IDataProtector.Protect(System.Byte[])
    
        
    
        Cryptographically protects a piece of plaintext data.
    
        
        
        
        :param plaintext: The plaintext data to protect.
        
        :type plaintext: System.Byte[]
        :rtype: System.Byte[]
        :return: The protected form of the plaintext data.
    
        
        .. code-block:: csharp
    
           byte[] Protect(byte[] plaintext)
    
    .. dn:method:: Microsoft.AspNet.DataProtection.IDataProtector.Unprotect(System.Byte[])
    
        
    
        Cryptographically unprotects a piece of protected data.
    
        
        
        
        :param protectedData: The protected data to unprotect.
        
        :type protectedData: System.Byte[]
        :rtype: System.Byte[]
        :return: The plaintext form of the protected data.
    
        
        .. code-block:: csharp
    
           byte[] Unprotect(byte[] protectedData)
    

