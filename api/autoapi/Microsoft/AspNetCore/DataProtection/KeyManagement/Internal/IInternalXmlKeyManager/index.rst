

IInternalXmlKeyManager Interface
================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.DataProtection.KeyManagement.Internal`
Assemblies
    * Microsoft.AspNetCore.DataProtection

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IInternalXmlKeyManager








.. dn:interface:: Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.IInternalXmlKeyManager
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.IInternalXmlKeyManager

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.IInternalXmlKeyManager
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.IInternalXmlKeyManager.CreateNewKey(System.Guid, System.DateTimeOffset, System.DateTimeOffset, System.DateTimeOffset)
    
        
    
        
        :type keyId: System.Guid
    
        
        :type creationDate: System.DateTimeOffset
    
        
        :type activationDate: System.DateTimeOffset
    
        
        :type expirationDate: System.DateTimeOffset
        :rtype: Microsoft.AspNetCore.DataProtection.KeyManagement.IKey
    
        
        .. code-block:: csharp
    
            IKey CreateNewKey(Guid keyId, DateTimeOffset creationDate, DateTimeOffset activationDate, DateTimeOffset expirationDate)
    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.IInternalXmlKeyManager.DeserializeDescriptorFromKeyElement(System.Xml.Linq.XElement)
    
        
    
        
        :type keyElement: System.Xml.Linq.XElement
        :rtype: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptor
    
        
        .. code-block:: csharp
    
            IAuthenticatedEncryptorDescriptor DeserializeDescriptorFromKeyElement(XElement keyElement)
    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.IInternalXmlKeyManager.RevokeSingleKey(System.Guid, System.DateTimeOffset, System.String)
    
        
    
        
        :type keyId: System.Guid
    
        
        :type revocationDate: System.DateTimeOffset
    
        
        :type reason: System.String
    
        
        .. code-block:: csharp
    
            void RevokeSingleKey(Guid keyId, DateTimeOffset revocationDate, string reason)
    

