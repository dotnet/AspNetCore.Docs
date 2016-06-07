

IAuthenticatedEncryptorConfiguration Interface
==============================================






The basic configuration that serves as a factory for types related to authenticated encryption.


Namespace
    :dn:ns:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel`
Assemblies
    * Microsoft.AspNetCore.DataProtection

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IAuthenticatedEncryptorConfiguration








.. dn:interface:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorConfiguration
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorConfiguration

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorConfiguration
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorConfiguration.CreateNewDescriptor()
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptor` instance based on this
        configuration. The newly-created instance contains unique key material and is distinct
        from all other descriptors created by the :dn:meth:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorConfiguration.CreateNewDescriptor` method.
    
        
        :rtype: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptor
        :return: A unique :any:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptor`\.
    
        
        .. code-block:: csharp
    
            IAuthenticatedEncryptorDescriptor CreateNewDescriptor()
    

