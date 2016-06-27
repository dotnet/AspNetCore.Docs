

ManagedAuthenticatedEncryptionSettings Class
============================================






Settings for configuring an authenticated encryption mechanism which uses
managed SymmetricAlgorithm and KeyedHashAlgorithm implementations.


Namespace
    :dn:ns:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption`
Assemblies
    * Microsoft.AspNetCore.DataProtection

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ManagedAuthenticatedEncryptionSettings`








Syntax
------

.. code-block:: csharp

    public sealed class ManagedAuthenticatedEncryptionSettings : IInternalAuthenticatedEncryptionSettings








.. dn:class:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ManagedAuthenticatedEncryptionSettings
    :hidden:

.. dn:class:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ManagedAuthenticatedEncryptionSettings

Properties
----------

.. dn:class:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ManagedAuthenticatedEncryptionSettings
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ManagedAuthenticatedEncryptionSettings.EncryptionAlgorithmKeySize
    
        
    
        
        The length (in bits) of the key that will be used for symmetric encryption.
        This property is required to have a value.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int EncryptionAlgorithmKeySize { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ManagedAuthenticatedEncryptionSettings.EncryptionAlgorithmType
    
        
    
        
        The type of the algorithm to use for symmetric encryption.
        The type must subclass :any:`System.Security.Cryptography.SymmetricAlgorithm`\.
        This property is required to have a value.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
            public Type EncryptionAlgorithmType { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ManagedAuthenticatedEncryptionSettings.ValidationAlgorithmType
    
        
    
        
        The type of the algorithm to use for validation.
        Type type must subclass :any:`System.Security.Cryptography.KeyedHashAlgorithm`\.
        This property is required to have a value.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
            public Type ValidationAlgorithmType { get; set; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ManagedAuthenticatedEncryptionSettings
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ManagedAuthenticatedEncryptionSettings.Validate()
    
        
    
        
        Validates that this :any:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ManagedAuthenticatedEncryptionSettings` is well-formed, i.e.,
        that the specified algorithms actually exist and can be instantiated properly.
        An exception will be thrown if validation fails.
    
        
    
        
        .. code-block:: csharp
    
            public void Validate()
    

