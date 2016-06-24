

FileSystemXmlRepository Class
=============================






An XML repository backed by a file system.


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
* :dn:cls:`Microsoft.AspNetCore.DataProtection.Repositories.FileSystemXmlRepository`








Syntax
------

.. code-block:: csharp

    public class FileSystemXmlRepository : IXmlRepository








.. dn:class:: Microsoft.AspNetCore.DataProtection.Repositories.FileSystemXmlRepository
    :hidden:

.. dn:class:: Microsoft.AspNetCore.DataProtection.Repositories.FileSystemXmlRepository

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.DataProtection.Repositories.FileSystemXmlRepository
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.DataProtection.Repositories.FileSystemXmlRepository.FileSystemXmlRepository(System.IO.DirectoryInfo)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.DataProtection.Repositories.FileSystemXmlRepository` with keys stored at the given directory.
    
        
    
        
        :param directory: The directory in which to persist key material.
        
        :type directory: System.IO.DirectoryInfo
    
        
        .. code-block:: csharp
    
            public FileSystemXmlRepository(DirectoryInfo directory)
    
    .. dn:constructor:: Microsoft.AspNetCore.DataProtection.Repositories.FileSystemXmlRepository.FileSystemXmlRepository(System.IO.DirectoryInfo, System.IServiceProvider)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.DataProtection.Repositories.FileSystemXmlRepository` with keys stored at the given directory.
    
        
    
        
        :param directory: The directory in which to persist key material.
        
        :type directory: System.IO.DirectoryInfo
    
        
        :param services: An optional :any:`System.IServiceProvider` to provide ancillary services.
        
        :type services: System.IServiceProvider
    
        
        .. code-block:: csharp
    
            public FileSystemXmlRepository(DirectoryInfo directory, IServiceProvider services)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.DataProtection.Repositories.FileSystemXmlRepository
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.DataProtection.Repositories.FileSystemXmlRepository.DefaultKeyStorageDirectory
    
        
    
        
        The default key storage directory, which currently corresponds to
        "%LOCALAPPDATA%\ASP.NET\DataProtection-Keys".
    
        
        :rtype: System.IO.DirectoryInfo
    
        
        .. code-block:: csharp
    
            public static DirectoryInfo DefaultKeyStorageDirectory { get; }
    
    .. dn:property:: Microsoft.AspNetCore.DataProtection.Repositories.FileSystemXmlRepository.Directory
    
        
    
        
        The directory into which key material will be written.
    
        
        :rtype: System.IO.DirectoryInfo
    
        
        .. code-block:: csharp
    
            public DirectoryInfo Directory { get; }
    
    .. dn:property:: Microsoft.AspNetCore.DataProtection.Repositories.FileSystemXmlRepository.Services
    
        
    
        
        The :any:`System.IServiceProvider` provided to the constructor.
    
        
        :rtype: System.IServiceProvider
    
        
        .. code-block:: csharp
    
            protected IServiceProvider Services { get; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.DataProtection.Repositories.FileSystemXmlRepository
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.Repositories.FileSystemXmlRepository.GetAllElements()
    
        
        :rtype: System.Collections.Generic.IReadOnlyCollection<System.Collections.Generic.IReadOnlyCollection`1>{System.Xml.Linq.XElement<System.Xml.Linq.XElement>}
    
        
        .. code-block:: csharp
    
            public virtual IReadOnlyCollection<XElement> GetAllElements()
    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.Repositories.FileSystemXmlRepository.StoreElement(System.Xml.Linq.XElement, System.String)
    
        
    
        
        :type element: System.Xml.Linq.XElement
    
        
        :type friendlyName: System.String
    
        
        .. code-block:: csharp
    
            public virtual void StoreElement(XElement element, string friendlyName)
    

