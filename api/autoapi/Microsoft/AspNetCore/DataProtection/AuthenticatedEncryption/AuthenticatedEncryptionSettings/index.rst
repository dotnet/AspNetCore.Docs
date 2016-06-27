

AuthenticatedEncryptionSettings Class
=====================================






Settings for configuring authenticated encryption algorithms.


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
* :dn:cls:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.AuthenticatedEncryptionSettings`








Syntax
------

.. code-block:: csharp

    public sealed class AuthenticatedEncryptionSettings : IInternalAuthenticatedEncryptionSettings








.. dn:class:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.AuthenticatedEncryptionSettings
    :hidden:

.. dn:class:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.AuthenticatedEncryptionSettings

Properties
----------

.. dn:class:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.AuthenticatedEncryptionSettings
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.AuthenticatedEncryptionSettings.EncryptionAlgorithm
    
        
    
        
        The algorithm to use for symmetric encryption (confidentiality).
    
        
        :rtype: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.EncryptionAlgorithm
    
        
        .. code-block:: csharp
    
            public EncryptionAlgorithm EncryptionAlgorithm { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.AuthenticatedEncryptionSettings.ValidationAlgorithm
    
        
    
        
        The algorithm to use for message authentication (tamper-proofing).
    
        
        :rtype: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ValidationAlgorithm
    
        
        .. code-block:: csharp
    
            public ValidationAlgorithm ValidationAlgorithm { get; set; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.AuthenticatedEncryptionSettings
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.AuthenticatedEncryptionSettings.Validate()
    
        
    
        
        Validates that this :any:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.AuthenticatedEncryptionSettings` is well-formed, i.e.,
        that the specified algorithms actually exist and that they can be instantiated properly.
        An exception will be thrown if validation fails.
    
        
    
        
        .. code-block:: csharp
    
            public void Validate()
    

