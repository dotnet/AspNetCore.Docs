

RegistryXmlRepository Class
===========================



.. contents:: 
   :local:



Summary
-------

An XML repository backed by the Windows registry.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.DataProtection.Repositories.RegistryXmlRepository`








Syntax
------

.. code-block:: csharp

   public class RegistryXmlRepository : IXmlRepository





GitHub
------

`View on GitHub <https://github.com/aspnet/dataprotection/blob/master/src/Microsoft.AspNet.DataProtection/Repositories/RegistryXmlRepository.cs>`_





.. dn:class:: Microsoft.AspNet.DataProtection.Repositories.RegistryXmlRepository

Constructors
------------

.. dn:class:: Microsoft.AspNet.DataProtection.Repositories.RegistryXmlRepository
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.Repositories.RegistryXmlRepository.RegistryXmlRepository(Microsoft.Win32.RegistryKey)
    
        
    
        Creates a :any:`Microsoft.AspNet.DataProtection.Repositories.RegistryXmlRepository` with keys stored in the given registry key.
    
        
        
        
        :param registryKey: The registry key in which to persist key material.
        
        :type registryKey: Microsoft.Win32.RegistryKey
    
        
        .. code-block:: csharp
    
           public RegistryXmlRepository(RegistryKey registryKey)
    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.Repositories.RegistryXmlRepository.RegistryXmlRepository(Microsoft.Win32.RegistryKey, System.IServiceProvider)
    
        
    
        Creates a :any:`Microsoft.AspNet.DataProtection.Repositories.RegistryXmlRepository` with keys stored in the given registry key.
    
        
        
        
        :param registryKey: The registry key in which to persist key material.
        
        :type registryKey: Microsoft.Win32.RegistryKey
        
        
        :type services: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           public RegistryXmlRepository(RegistryKey registryKey, IServiceProvider services)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.DataProtection.Repositories.RegistryXmlRepository
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.DataProtection.Repositories.RegistryXmlRepository.GetAllElements()
    
        
        :rtype: System.Collections.Generic.IReadOnlyCollection{System.Xml.Linq.XElement}
    
        
        .. code-block:: csharp
    
           public virtual IReadOnlyCollection<XElement> GetAllElements()
    
    .. dn:method:: Microsoft.AspNet.DataProtection.Repositories.RegistryXmlRepository.StoreElement(System.Xml.Linq.XElement, System.String)
    
        
        
        
        :type element: System.Xml.Linq.XElement
        
        
        :type friendlyName: System.String
    
        
        .. code-block:: csharp
    
           public virtual void StoreElement(XElement element, string friendlyName)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.DataProtection.Repositories.RegistryXmlRepository
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.DataProtection.Repositories.RegistryXmlRepository.DefaultRegistryKey
    
        
    
        The default key storage directory, which currently corresponds to
        "HKLM\SOFTWARE\Microsoft\ASP.NET\4.0.30319.0\AutoGenKeys\{SID}".
    
        
        :rtype: Microsoft.Win32.RegistryKey
    
        
        .. code-block:: csharp
    
           public static RegistryKey DefaultRegistryKey { get; }
    
    .. dn:property:: Microsoft.AspNet.DataProtection.Repositories.RegistryXmlRepository.RegistryKey
    
        
    
        The registry key into which key material will be written.
    
        
        :rtype: Microsoft.Win32.RegistryKey
    
        
        .. code-block:: csharp
    
           public RegistryKey RegistryKey { get; }
    
    .. dn:property:: Microsoft.AspNet.DataProtection.Repositories.RegistryXmlRepository.Services
    
        
    
        The :any:`System.IServiceProvider` provided to the constructor.
    
        
        :rtype: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           protected IServiceProvider Services { get; }
    

