

XmlKeyManager Class
===================






A key manager backed by an :any:`Microsoft.AspNetCore.DataProtection.Repositories.IXmlRepository`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.DataProtection.KeyManagement`
Assemblies
    * Microsoft.AspNetCore.DataProtection

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.DataProtection.KeyManagement.XmlKeyManager`








Syntax
------

.. code-block:: csharp

    public sealed class XmlKeyManager : IKeyManager, IInternalXmlKeyManager








.. dn:class:: Microsoft.AspNetCore.DataProtection.KeyManagement.XmlKeyManager
    :hidden:

.. dn:class:: Microsoft.AspNetCore.DataProtection.KeyManagement.XmlKeyManager

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.DataProtection.KeyManagement.XmlKeyManager
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.DataProtection.KeyManagement.XmlKeyManager.XmlKeyManager(Microsoft.AspNetCore.DataProtection.Repositories.IXmlRepository, Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorConfiguration, System.IServiceProvider)
    
        
    
        
        Creates an :any:`Microsoft.AspNetCore.DataProtection.KeyManagement.XmlKeyManager`\.
    
        
    
        
        :param repository: The repository where keys are stored.
        
        :type repository: Microsoft.AspNetCore.DataProtection.Repositories.IXmlRepository
    
        
        :param configuration: Configuration for newly-created keys.
        
        :type configuration: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorConfiguration
    
        
        :param services: A provider of optional services.
        
        :type services: System.IServiceProvider
    
        
        .. code-block:: csharp
    
            public XmlKeyManager(IXmlRepository repository, IAuthenticatedEncryptorConfiguration configuration, IServiceProvider services)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.DataProtection.KeyManagement.XmlKeyManager
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.KeyManagement.XmlKeyManager.CreateNewKey(System.DateTimeOffset, System.DateTimeOffset)
    
        
    
        
        :type activationDate: System.DateTimeOffset
    
        
        :type expirationDate: System.DateTimeOffset
        :rtype: Microsoft.AspNetCore.DataProtection.KeyManagement.IKey
    
        
        .. code-block:: csharp
    
            public IKey CreateNewKey(DateTimeOffset activationDate, DateTimeOffset expirationDate)
    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.KeyManagement.XmlKeyManager.GetAllKeys()
    
        
        :rtype: System.Collections.Generic.IReadOnlyCollection<System.Collections.Generic.IReadOnlyCollection`1>{Microsoft.AspNetCore.DataProtection.KeyManagement.IKey<Microsoft.AspNetCore.DataProtection.KeyManagement.IKey>}
    
        
        .. code-block:: csharp
    
            public IReadOnlyCollection<IKey> GetAllKeys()
    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.KeyManagement.XmlKeyManager.GetCacheExpirationToken()
    
        
        :rtype: System.Threading.CancellationToken
    
        
        .. code-block:: csharp
    
            public CancellationToken GetCacheExpirationToken()
    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.KeyManagement.XmlKeyManager.Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.IInternalXmlKeyManager.CreateNewKey(System.Guid, System.DateTimeOffset, System.DateTimeOffset, System.DateTimeOffset)
    
        
    
        
        :type keyId: System.Guid
    
        
        :type creationDate: System.DateTimeOffset
    
        
        :type activationDate: System.DateTimeOffset
    
        
        :type expirationDate: System.DateTimeOffset
        :rtype: Microsoft.AspNetCore.DataProtection.KeyManagement.IKey
    
        
        .. code-block:: csharp
    
            IKey IInternalXmlKeyManager.CreateNewKey(Guid keyId, DateTimeOffset creationDate, DateTimeOffset activationDate, DateTimeOffset expirationDate)
    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.KeyManagement.XmlKeyManager.Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.IInternalXmlKeyManager.DeserializeDescriptorFromKeyElement(System.Xml.Linq.XElement)
    
        
    
        
        :type keyElement: System.Xml.Linq.XElement
        :rtype: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptor
    
        
        .. code-block:: csharp
    
            IAuthenticatedEncryptorDescriptor IInternalXmlKeyManager.DeserializeDescriptorFromKeyElement(XElement keyElement)
    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.KeyManagement.XmlKeyManager.Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.IInternalXmlKeyManager.RevokeSingleKey(System.Guid, System.DateTimeOffset, System.String)
    
        
    
        
        :type keyId: System.Guid
    
        
        :type revocationDate: System.DateTimeOffset
    
        
        :type reason: System.String
    
        
        .. code-block:: csharp
    
            void IInternalXmlKeyManager.RevokeSingleKey(Guid keyId, DateTimeOffset revocationDate, string reason)
    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.KeyManagement.XmlKeyManager.RevokeAllKeys(System.DateTimeOffset, System.String)
    
        
    
        
        :type revocationDate: System.DateTimeOffset
    
        
        :type reason: System.String
    
        
        .. code-block:: csharp
    
            public void RevokeAllKeys(DateTimeOffset revocationDate, string reason = null)
    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.KeyManagement.XmlKeyManager.RevokeKey(System.Guid, System.String)
    
        
    
        
        :type keyId: System.Guid
    
        
        :type reason: System.String
    
        
        .. code-block:: csharp
    
            public void RevokeKey(Guid keyId, string reason = null)
    

