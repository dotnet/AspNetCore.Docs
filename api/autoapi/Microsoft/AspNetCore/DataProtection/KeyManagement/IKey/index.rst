

IKey Interface
==============






The basic interface for representing an authenticated encryption key.


Namespace
    :dn:ns:`Microsoft.AspNetCore.DataProtection.KeyManagement`
Assemblies
    * Microsoft.AspNetCore.DataProtection

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IKey








.. dn:interface:: Microsoft.AspNetCore.DataProtection.KeyManagement.IKey
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.DataProtection.KeyManagement.IKey

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.DataProtection.KeyManagement.IKey
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.DataProtection.KeyManagement.IKey.ActivationDate
    
        
    
        
        The date at which encryptions with this key can begin taking place.
    
        
        :rtype: System.DateTimeOffset
    
        
        .. code-block:: csharp
    
            DateTimeOffset ActivationDate { get; }
    
    .. dn:property:: Microsoft.AspNetCore.DataProtection.KeyManagement.IKey.CreationDate
    
        
    
        
        The date on which this key was created.
    
        
        :rtype: System.DateTimeOffset
    
        
        .. code-block:: csharp
    
            DateTimeOffset CreationDate { get; }
    
    .. dn:property:: Microsoft.AspNetCore.DataProtection.KeyManagement.IKey.ExpirationDate
    
        
    
        
        The date after which encryptions with this key may no longer take place.
    
        
        :rtype: System.DateTimeOffset
    
        
        .. code-block:: csharp
    
            DateTimeOffset ExpirationDate { get; }
    
    .. dn:property:: Microsoft.AspNetCore.DataProtection.KeyManagement.IKey.IsRevoked
    
        
    
        
        Returns a value stating whether this key was revoked.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            bool IsRevoked { get; }
    
    .. dn:property:: Microsoft.AspNetCore.DataProtection.KeyManagement.IKey.KeyId
    
        
    
        
        The id of the key.
    
        
        :rtype: System.Guid
    
        
        .. code-block:: csharp
    
            Guid KeyId { get; }
    

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.DataProtection.KeyManagement.IKey
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.KeyManagement.IKey.CreateEncryptorInstance()
    
        
    
        
        Creates an IAuthenticatedEncryptor instance that can be used to encrypt data
        to and decrypt data from this key.
    
        
        :rtype: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.IAuthenticatedEncryptor
        :return: An IAuthenticatedEncryptor.
    
        
        .. code-block:: csharp
    
            IAuthenticatedEncryptor CreateEncryptorInstance()
    

