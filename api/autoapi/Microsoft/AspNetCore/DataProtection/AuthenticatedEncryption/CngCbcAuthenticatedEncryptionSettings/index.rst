

CngCbcAuthenticatedEncryptionSettings Class
===========================================






Settings for configuring an authenticated encryption mechanism which uses
Windows CNG algorithms in CBC encryption + HMAC authentication modes.


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
* :dn:cls:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.CngCbcAuthenticatedEncryptionSettings`








Syntax
------

.. code-block:: csharp

    public sealed class CngCbcAuthenticatedEncryptionSettings : IInternalAuthenticatedEncryptionSettings








.. dn:class:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.CngCbcAuthenticatedEncryptionSettings
    :hidden:

.. dn:class:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.CngCbcAuthenticatedEncryptionSettings

Properties
----------

.. dn:class:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.CngCbcAuthenticatedEncryptionSettings
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.CngCbcAuthenticatedEncryptionSettings.EncryptionAlgorithm
    
        
    
        
        The name of the algorithm to use for symmetric encryption.
        This property corresponds to the 'pszAlgId' parameter of BCryptOpenAlgorithmProvider.
        This property is required to have a value.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string EncryptionAlgorithm
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.CngCbcAuthenticatedEncryptionSettings.EncryptionAlgorithmKeySize
    
        
    
        
        The length (in bits) of the key that will be used for symmetric encryption.
        This property is required to have a value.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int EncryptionAlgorithmKeySize
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.CngCbcAuthenticatedEncryptionSettings.EncryptionAlgorithmProvider
    
        
    
        
        The name of the provider which contains the implementation of the symmetric encryption algorithm.
        This property corresponds to the 'pszImplementation' parameter of BCryptOpenAlgorithmProvider.
        This property is optional.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string EncryptionAlgorithmProvider
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.CngCbcAuthenticatedEncryptionSettings.HashAlgorithm
    
        
    
        
        The name of the algorithm to use for hashing data.
        This property corresponds to the 'pszAlgId' parameter of BCryptOpenAlgorithmProvider.
        This property is required to have a value.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string HashAlgorithm
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.CngCbcAuthenticatedEncryptionSettings.HashAlgorithmProvider
    
        
    
        
        The name of the provider which contains the implementation of the hash algorithm.
        This property corresponds to the 'pszImplementation' parameter of BCryptOpenAlgorithmProvider.
        This property is optional.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string HashAlgorithmProvider
            {
                get;
                set;
            }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.CngCbcAuthenticatedEncryptionSettings
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.CngCbcAuthenticatedEncryptionSettings.Validate()
    
        
    
        
        Validates that this :any:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.CngCbcAuthenticatedEncryptionSettings` is well-formed, i.e.,
        that the specified algorithms actually exist and that they can be instantiated properly.
        An exception will be thrown if validation fails.
    
        
    
        
        .. code-block:: csharp
    
            public void Validate()
    

