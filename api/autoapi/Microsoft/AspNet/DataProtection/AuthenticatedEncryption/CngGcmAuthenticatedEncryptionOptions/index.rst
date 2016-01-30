

CngGcmAuthenticatedEncryptionOptions Class
==========================================



.. contents:: 
   :local:



Summary
-------

Options for configuring an authenticated encryption mechanism which uses
Windows CNG algorithms in GCM encryption + authentication modes.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.CngGcmAuthenticatedEncryptionOptions`








Syntax
------

.. code-block:: csharp

   public sealed class CngGcmAuthenticatedEncryptionOptions : IInternalAuthenticatedEncryptionOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/dataprotection/blob/master/src/Microsoft.AspNet.DataProtection/AuthenticatedEncryption/CngGcmAuthenticatedEncryptionOptions.cs>`_





.. dn:class:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.CngGcmAuthenticatedEncryptionOptions

Methods
-------

.. dn:class:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.CngGcmAuthenticatedEncryptionOptions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.CngGcmAuthenticatedEncryptionOptions.Validate()
    
        
    
        Validates that this :any:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.CngGcmAuthenticatedEncryptionOptions` is well-formed, i.e.,
        that the specified algorithm actually exists and can be instantiated properly.
        An exception will be thrown if validation fails.
    
        
    
        
        .. code-block:: csharp
    
           public void Validate()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.CngGcmAuthenticatedEncryptionOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.CngGcmAuthenticatedEncryptionOptions.EncryptionAlgorithm
    
        
    
        The name of the algorithm to use for symmetric encryption.
        This property corresponds to the 'pszAlgId' parameter of BCryptOpenAlgorithmProvider.
        This property is required to have a value.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string EncryptionAlgorithm { get; set; }
    
    .. dn:property:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.CngGcmAuthenticatedEncryptionOptions.EncryptionAlgorithmKeySize
    
        
    
        The length (in bits) of the key that will be used for symmetric encryption.
        This property is required to have a value.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int EncryptionAlgorithmKeySize { get; set; }
    
    .. dn:property:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.CngGcmAuthenticatedEncryptionOptions.EncryptionAlgorithmProvider
    
        
    
        The name of the provider which contains the implementation of the symmetric encryption algorithm.
        This property corresponds to the 'pszImplementation' parameter of BCryptOpenAlgorithmProvider.
        This property is optional.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string EncryptionAlgorithmProvider { get; set; }
    

