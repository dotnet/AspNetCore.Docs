

IKey Interface
==============



.. contents:: 
   :local:



Summary
-------

The basic interface for representing an authenticated encryption key.











Syntax
------

.. code-block:: csharp

   public interface IKey





GitHub
------

`View on GitHub <https://github.com/aspnet/dataprotection/blob/master/src/Microsoft.AspNet.DataProtection/KeyManagement/IKey.cs>`_





.. dn:interface:: Microsoft.AspNet.DataProtection.KeyManagement.IKey

Methods
-------

.. dn:interface:: Microsoft.AspNet.DataProtection.KeyManagement.IKey
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.DataProtection.KeyManagement.IKey.CreateEncryptorInstance()
    
        
    
        Creates an IAuthenticatedEncryptor instance that can be used to encrypt data
        to and decrypt data from this key.
    
        
        :rtype: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.IAuthenticatedEncryptor
        :return: An IAuthenticatedEncryptor.
    
        
        .. code-block:: csharp
    
           IAuthenticatedEncryptor CreateEncryptorInstance()
    

Properties
----------

.. dn:interface:: Microsoft.AspNet.DataProtection.KeyManagement.IKey
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.DataProtection.KeyManagement.IKey.ActivationDate
    
        
    
        The date at which encryptions with this key can begin taking place.
    
        
        :rtype: System.DateTimeOffset
    
        
        .. code-block:: csharp
    
           DateTimeOffset ActivationDate { get; }
    
    .. dn:property:: Microsoft.AspNet.DataProtection.KeyManagement.IKey.CreationDate
    
        
    
        The date on which this key was created.
    
        
        :rtype: System.DateTimeOffset
    
        
        .. code-block:: csharp
    
           DateTimeOffset CreationDate { get; }
    
    .. dn:property:: Microsoft.AspNet.DataProtection.KeyManagement.IKey.ExpirationDate
    
        
    
        The date after which encryptions with this key may no longer take place.
    
        
        :rtype: System.DateTimeOffset
    
        
        .. code-block:: csharp
    
           DateTimeOffset ExpirationDate { get; }
    
    .. dn:property:: Microsoft.AspNet.DataProtection.KeyManagement.IKey.IsRevoked
    
        
    
        Returns a value stating whether this key was revoked.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool IsRevoked { get; }
    
    .. dn:property:: Microsoft.AspNet.DataProtection.KeyManagement.IKey.KeyId
    
        
    
        The id of the key.
    
        
        :rtype: System.Guid
    
        
        .. code-block:: csharp
    
           Guid KeyId { get; }
    

