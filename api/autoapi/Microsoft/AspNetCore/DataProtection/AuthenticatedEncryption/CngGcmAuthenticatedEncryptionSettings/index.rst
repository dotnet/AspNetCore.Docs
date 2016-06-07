

CngGcmAuthenticatedEncryptionSettings Class
===========================================






Settings for configuring an authenticated encryption mechanism which uses
Windows CNG algorithms in GCM encryption + authentication modes.


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
* :dn:cls:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.CngGcmAuthenticatedEncryptionSettings`








Syntax
------

.. code-block:: csharp

    public sealed class CngGcmAuthenticatedEncryptionSettings : IInternalAuthenticatedEncryptionSettings








.. dn:class:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.CngGcmAuthenticatedEncryptionSettings
    :hidden:

.. dn:class:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.CngGcmAuthenticatedEncryptionSettings

Properties
----------

.. dn:class:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.CngGcmAuthenticatedEncryptionSettings
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.CngGcmAuthenticatedEncryptionSettings.EncryptionAlgorithm
    
        
    
        
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
    
    .. dn:property:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.CngGcmAuthenticatedEncryptionSettings.EncryptionAlgorithmKeySize
    
        
    
        
        The length (in bits) of the key that will be used for symmetric encryption.
        This property is required to have a value.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int EncryptionAlgorithmKeySize
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.CngGcmAuthenticatedEncryptionSettings.EncryptionAlgorithmProvider
    
        
    
        
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
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.CngGcmAuthenticatedEncryptionSettings
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.CngGcmAuthenticatedEncryptionSettings.Validate()
    
        
    
        
        Validates that this :any:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.CngGcmAuthenticatedEncryptionSettings` is well-formed, i.e.,
        that the specified algorithm actually exists and can be instantiated properly.
        An exception will be thrown if validation fails.
    
        
    
        
        .. code-block:: csharp
    
            public void Validate()
    

