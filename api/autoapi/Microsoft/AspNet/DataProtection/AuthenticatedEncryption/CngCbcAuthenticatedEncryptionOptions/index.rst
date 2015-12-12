

CngCbcAuthenticatedEncryptionOptions Class
==========================================



.. contents:: 
   :local:



Summary
-------

Options for configuring an authenticated encryption mechanism which uses
Windows CNG algorithms in CBC encryption + HMAC authentication modes.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.CngCbcAuthenticatedEncryptionOptions`








Syntax
------

.. code-block:: csharp

   public sealed class CngCbcAuthenticatedEncryptionOptions : IInternalAuthenticatedEncryptionOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/dataprotection/src/Microsoft.AspNet.DataProtection/AuthenticatedEncryption/CngCbcAuthenticatedEncryptionOptions.cs>`_





.. dn:class:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.CngCbcAuthenticatedEncryptionOptions

Methods
-------

.. dn:class:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.CngCbcAuthenticatedEncryptionOptions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.CngCbcAuthenticatedEncryptionOptions.Validate()
    
        
    
        Validates that this :any:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.CngCbcAuthenticatedEncryptionOptions` is well-formed, i.e.,
        that the specified algorithms actually exist and that they can be instantiated properly.
        An exception will be thrown if validation fails.
    
        
    
        
        .. code-block:: csharp
    
           public void Validate()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.CngCbcAuthenticatedEncryptionOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.CngCbcAuthenticatedEncryptionOptions.EncryptionAlgorithm
    
        
    
        The name of the algorithm to use for symmetric encryption.
        This property corresponds to the 'pszAlgId' parameter of BCryptOpenAlgorithmProvider.
        This property is required to have a value.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string EncryptionAlgorithm { get; set; }
    
    .. dn:property:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.CngCbcAuthenticatedEncryptionOptions.EncryptionAlgorithmKeySize
    
        
    
        The length (in bits) of the key that will be used for symmetric encryption.
        This property is required to have a value.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int EncryptionAlgorithmKeySize { get; set; }
    
    .. dn:property:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.CngCbcAuthenticatedEncryptionOptions.EncryptionAlgorithmProvider
    
        
    
        The name of the provider which contains the implementation of the symmetric encryption algorithm.
        This property corresponds to the 'pszImplementation' parameter of BCryptOpenAlgorithmProvider.
        This property is optional.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string EncryptionAlgorithmProvider { get; set; }
    
    .. dn:property:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.CngCbcAuthenticatedEncryptionOptions.HashAlgorithm
    
        
    
        The name of the algorithm to use for hashing data.
        This property corresponds to the 'pszAlgId' parameter of BCryptOpenAlgorithmProvider.
        This property is required to have a value.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string HashAlgorithm { get; set; }
    
    .. dn:property:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.CngCbcAuthenticatedEncryptionOptions.HashAlgorithmProvider
    
        
    
        The name of the provider which contains the implementation of the hash algorithm.
        This property corresponds to the 'pszImplementation' parameter of BCryptOpenAlgorithmProvider.
        This property is optional.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string HashAlgorithmProvider { get; set; }
    

