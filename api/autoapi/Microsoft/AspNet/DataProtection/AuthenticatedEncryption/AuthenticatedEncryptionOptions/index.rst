

AuthenticatedEncryptionOptions Class
====================================



.. contents:: 
   :local:



Summary
-------

Options for configuring authenticated encryption algorithms.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.AuthenticatedEncryptionOptions`








Syntax
------

.. code-block:: csharp

   public sealed class AuthenticatedEncryptionOptions : IInternalAuthenticatedEncryptionOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/dataprotection/blob/master/src/Microsoft.AspNet.DataProtection/AuthenticatedEncryption/AuthenticatedEncryptionOptions.cs>`_





.. dn:class:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.AuthenticatedEncryptionOptions

Methods
-------

.. dn:class:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.AuthenticatedEncryptionOptions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.AuthenticatedEncryptionOptions.Validate()
    
        
    
        Validates that this :any:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.AuthenticatedEncryptionOptions` is well-formed, i.e.,
        that the specified algorithms actually exist and that they can be instantiated properly.
        An exception will be thrown if validation fails.
    
        
    
        
        .. code-block:: csharp
    
           public void Validate()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.AuthenticatedEncryptionOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.AuthenticatedEncryptionOptions.EncryptionAlgorithm
    
        
    
        The algorithm to use for symmetric encryption (confidentiality).
    
        
        :rtype: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.EncryptionAlgorithm
    
        
        .. code-block:: csharp
    
           public EncryptionAlgorithm EncryptionAlgorithm { get; set; }
    
    .. dn:property:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.AuthenticatedEncryptionOptions.ValidationAlgorithm
    
        
    
        The algorithm to use for message authentication (tamper-proofing).
    
        
        :rtype: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ValidationAlgorithm
    
        
        .. code-block:: csharp
    
           public ValidationAlgorithm ValidationAlgorithm { get; set; }
    

