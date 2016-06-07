

IDefaultKeyServices Interface
=============================






Provides default implementations of the services required by an :any:`Microsoft.AspNetCore.DataProtection.KeyManagement.IKeyManager`\.


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

    public interface IDefaultKeyServices








.. dn:interface:: Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.IDefaultKeyServices
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.IDefaultKeyServices

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.IDefaultKeyServices
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.IDefaultKeyServices.GetKeyEncryptor()
    
        
    
        
        Gets the default :any:`Microsoft.AspNetCore.DataProtection.XmlEncryption.IXmlEncryptor` service (could return null).
    
        
        :rtype: Microsoft.AspNetCore.DataProtection.XmlEncryption.IXmlEncryptor
    
        
        .. code-block:: csharp
    
            IXmlEncryptor GetKeyEncryptor()
    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.IDefaultKeyServices.GetKeyRepository()
    
        
    
        
        Gets the default :any:`Microsoft.AspNetCore.DataProtection.Repositories.IXmlRepository` service (must not be null).
    
        
        :rtype: Microsoft.AspNetCore.DataProtection.Repositories.IXmlRepository
    
        
        .. code-block:: csharp
    
            IXmlRepository GetKeyRepository()
    

