

IAuthenticatedEncryptorConfiguration Interface
==============================================



.. contents:: 
   :local:



Summary
-------

The basic configuration that serves as a factory for types related to authenticated encryption.











Syntax
------

.. code-block:: csharp

   public interface IAuthenticatedEncryptorConfiguration





GitHub
------

`View on GitHub <https://github.com/aspnet/dataprotection/blob/master/src/Microsoft.AspNet.DataProtection/AuthenticatedEncryption/ConfigurationModel/IAuthenticatedEncryptorConfiguration.cs>`_





.. dn:interface:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorConfiguration

Methods
-------

.. dn:interface:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorConfiguration
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorConfiguration.CreateNewDescriptor()
    
        
    
        Creates a new :any:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptor` instance based on this
        configuration. The newly-created instance contains unique key material and is distinct
        from all other descriptors created by the :dn:meth:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorConfiguration.CreateNewDescriptor` method.
    
        
        :rtype: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptor
        :return: A unique <see cref="T:Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptor" />.
    
        
        .. code-block:: csharp
    
           IAuthenticatedEncryptorDescriptor CreateNewDescriptor()
    

