

RegistryXmlRepository Class
===========================






An XML repository backed by the Windows registry.


Namespace
    :dn:ns:`Microsoft.AspNetCore.DataProtection.Repositories`
Assemblies
    * Microsoft.AspNetCore.DataProtection

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.DataProtection.Repositories.RegistryXmlRepository`








Syntax
------

.. code-block:: csharp

    public class RegistryXmlRepository : IXmlRepository








.. dn:class:: Microsoft.AspNetCore.DataProtection.Repositories.RegistryXmlRepository
    :hidden:

.. dn:class:: Microsoft.AspNetCore.DataProtection.Repositories.RegistryXmlRepository

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.DataProtection.Repositories.RegistryXmlRepository
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.DataProtection.Repositories.RegistryXmlRepository.RegistryXmlRepository(Microsoft.Win32.RegistryKey)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.DataProtection.Repositories.RegistryXmlRepository` with keys stored in the given registry key.
    
        
    
        
        :param registryKey: The registry key in which to persist key material.
        
        :type registryKey: Microsoft.Win32.RegistryKey
    
        
        .. code-block:: csharp
    
            public RegistryXmlRepository(RegistryKey registryKey)
    
    .. dn:constructor:: Microsoft.AspNetCore.DataProtection.Repositories.RegistryXmlRepository.RegistryXmlRepository(Microsoft.Win32.RegistryKey, System.IServiceProvider)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.DataProtection.Repositories.RegistryXmlRepository` with keys stored in the given registry key.
    
        
    
        
        :param registryKey: The registry key in which to persist key material.
        
        :type registryKey: Microsoft.Win32.RegistryKey
    
        
        :param services: The :any:`System.IServiceProvider` used to resolve services.
        
        :type services: System.IServiceProvider
    
        
        .. code-block:: csharp
    
            public RegistryXmlRepository(RegistryKey registryKey, IServiceProvider services)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.DataProtection.Repositories.RegistryXmlRepository
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.DataProtection.Repositories.RegistryXmlRepository.DefaultRegistryKey
    
        
    
        
        The default key storage directory, which currently corresponds to
        "HKLM\SOFTWARE\Microsoft\ASP.NET\4.0.30319.0\AutoGenKeys\{SID}".
    
        
        :rtype: Microsoft.Win32.RegistryKey
    
        
        .. code-block:: csharp
    
            public static RegistryKey DefaultRegistryKey { get; }
    
    .. dn:property:: Microsoft.AspNetCore.DataProtection.Repositories.RegistryXmlRepository.RegistryKey
    
        
    
        
        The registry key into which key material will be written.
    
        
        :rtype: Microsoft.Win32.RegistryKey
    
        
        .. code-block:: csharp
    
            public RegistryKey RegistryKey { get; }
    
    .. dn:property:: Microsoft.AspNetCore.DataProtection.Repositories.RegistryXmlRepository.Services
    
        
    
        
        The :any:`System.IServiceProvider` provided to the constructor.
    
        
        :rtype: System.IServiceProvider
    
        
        .. code-block:: csharp
    
            protected IServiceProvider Services { get; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.DataProtection.Repositories.RegistryXmlRepository
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.Repositories.RegistryXmlRepository.GetAllElements()
    
        
        :rtype: System.Collections.Generic.IReadOnlyCollection<System.Collections.Generic.IReadOnlyCollection`1>{System.Xml.Linq.XElement<System.Xml.Linq.XElement>}
    
        
        .. code-block:: csharp
    
            public virtual IReadOnlyCollection<XElement> GetAllElements()
    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.Repositories.RegistryXmlRepository.StoreElement(System.Xml.Linq.XElement, System.String)
    
        
    
        
        :type element: System.Xml.Linq.XElement
    
        
        :type friendlyName: System.String
    
        
        .. code-block:: csharp
    
            public virtual void StoreElement(XElement element, string friendlyName)
    

