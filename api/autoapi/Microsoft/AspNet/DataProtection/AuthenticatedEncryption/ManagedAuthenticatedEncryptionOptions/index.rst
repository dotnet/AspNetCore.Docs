

ManagedAuthenticatedEncryptionOptions Class
===========================================



.. contents:: 
   :local:



Summary
-------

Options for configuring an authenticated encryption mechanism which uses
managed SymmetricAlgorithm and KeyedHashAlgorithm implementations.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ManagedAuthenticatedEncryptionOptions`








Syntax
------

.. code-block:: csharp

   public sealed class ManagedAuthenticatedEncryptionOptions : IInternalAuthenticatedEncryptionOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/dataprotection/src/Microsoft.AspNet.DataProtection/AuthenticatedEncryption/ManagedAuthenticatedEncryptionOptions.cs>`_





.. dn:class:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ManagedAuthenticatedEncryptionOptions

Methods
-------

.. dn:class:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ManagedAuthenticatedEncryptionOptions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ManagedAuthenticatedEncryptionOptions.Validate()
    
        
    
        Validates that this :any:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ManagedAuthenticatedEncryptionOptions` is well-formed, i.e.,
        that the specified algorithms actually exist and can be instantiated properly.
        An exception will be thrown if validation fails.
    
        
    
        
        .. code-block:: csharp
    
           public void Validate()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ManagedAuthenticatedEncryptionOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ManagedAuthenticatedEncryptionOptions.EncryptionAlgorithmKeySize
    
        
    
        The length (in bits) of the key that will be used for symmetric encryption.
        This property is required to have a value.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int EncryptionAlgorithmKeySize { get; set; }
    
    .. dn:property:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ManagedAuthenticatedEncryptionOptions.EncryptionAlgorithmType
    
        
    
        The type of the algorithm to use for symmetric encryption.
        The type must subclass :any:`System.Security.Cryptography.SymmetricAlgorithm`\.
        This property is required to have a value.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
           public Type EncryptionAlgorithmType { get; set; }
    
    .. dn:property:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ManagedAuthenticatedEncryptionOptions.ValidationAlgorithmType
    
        
    
        The type of the algorithm to use for validation.
        Type type must subclass :any:`System.Security.Cryptography.KeyedHashAlgorithm`\.
        This property is required to have a value.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
           public Type ValidationAlgorithmType { get; set; }
    

