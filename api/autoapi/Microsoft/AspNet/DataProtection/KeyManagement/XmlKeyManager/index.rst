

XmlKeyManager Class
===================



.. contents:: 
   :local:



Summary
-------

A key manager backed by an :any:`Microsoft.AspNet.DataProtection.Repositories.IXmlRepository`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.DataProtection.KeyManagement.XmlKeyManager`








Syntax
------

.. code-block:: csharp

   public sealed class XmlKeyManager : IKeyManager, IInternalXmlKeyManager





GitHub
------

`View on GitHub <https://github.com/aspnet/dataprotection/blob/master/src/Microsoft.AspNet.DataProtection/KeyManagement/XmlKeyManager.cs>`_





.. dn:class:: Microsoft.AspNet.DataProtection.KeyManagement.XmlKeyManager

Constructors
------------

.. dn:class:: Microsoft.AspNet.DataProtection.KeyManagement.XmlKeyManager
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.KeyManagement.XmlKeyManager.XmlKeyManager(Microsoft.AspNet.DataProtection.Repositories.IXmlRepository, Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorConfiguration, System.IServiceProvider)
    
        
    
        Creates an :any:`Microsoft.AspNet.DataProtection.KeyManagement.XmlKeyManager`\.
    
        
        
        
        :param repository: The repository where keys are stored.
        
        :type repository: Microsoft.AspNet.DataProtection.Repositories.IXmlRepository
        
        
        :param configuration: Configuration for newly-created keys.
        
        :type configuration: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorConfiguration
        
        
        :param services: A provider of optional services.
        
        :type services: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           public XmlKeyManager(IXmlRepository repository, IAuthenticatedEncryptorConfiguration configuration, IServiceProvider services)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.DataProtection.KeyManagement.XmlKeyManager
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.DataProtection.KeyManagement.XmlKeyManager.CreateNewKey(System.DateTimeOffset, System.DateTimeOffset)
    
        
        
        
        :type activationDate: System.DateTimeOffset
        
        
        :type expirationDate: System.DateTimeOffset
        :rtype: Microsoft.AspNet.DataProtection.KeyManagement.IKey
    
        
        .. code-block:: csharp
    
           public IKey CreateNewKey(DateTimeOffset activationDate, DateTimeOffset expirationDate)
    
    .. dn:method:: Microsoft.AspNet.DataProtection.KeyManagement.XmlKeyManager.GetAllKeys()
    
        
        :rtype: System.Collections.Generic.IReadOnlyCollection{Microsoft.AspNet.DataProtection.KeyManagement.IKey}
    
        
        .. code-block:: csharp
    
           public IReadOnlyCollection<IKey> GetAllKeys()
    
    .. dn:method:: Microsoft.AspNet.DataProtection.KeyManagement.XmlKeyManager.GetCacheExpirationToken()
    
        
        :rtype: System.Threading.CancellationToken
    
        
        .. code-block:: csharp
    
           public CancellationToken GetCacheExpirationToken()
    
    .. dn:method:: Microsoft.AspNet.DataProtection.KeyManagement.XmlKeyManager.RevokeAllKeys(System.DateTimeOffset, System.String)
    
        
        
        
        :type revocationDate: System.DateTimeOffset
        
        
        :type reason: System.String
    
        
        .. code-block:: csharp
    
           public void RevokeAllKeys(DateTimeOffset revocationDate, string reason = null)
    
    .. dn:method:: Microsoft.AspNet.DataProtection.KeyManagement.XmlKeyManager.RevokeKey(System.Guid, System.String)
    
        
        
        
        :type keyId: System.Guid
        
        
        :type reason: System.String
    
        
        .. code-block:: csharp
    
           public void RevokeKey(Guid keyId, string reason = null)
    

