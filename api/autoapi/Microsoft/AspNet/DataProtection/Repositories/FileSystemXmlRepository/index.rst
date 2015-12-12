

FileSystemXmlRepository Class
=============================



.. contents:: 
   :local:



Summary
-------

An XML repository backed by a file system.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.DataProtection.Repositories.FileSystemXmlRepository`








Syntax
------

.. code-block:: csharp

   public class FileSystemXmlRepository : IXmlRepository





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/dataprotection/src/Microsoft.AspNet.DataProtection/Repositories/FileSystemXmlRepository.cs>`_





.. dn:class:: Microsoft.AspNet.DataProtection.Repositories.FileSystemXmlRepository

Constructors
------------

.. dn:class:: Microsoft.AspNet.DataProtection.Repositories.FileSystemXmlRepository
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.Repositories.FileSystemXmlRepository.FileSystemXmlRepository(System.IO.DirectoryInfo)
    
        
    
        Creates a :any:`Microsoft.AspNet.DataProtection.Repositories.FileSystemXmlRepository` with keys stored at the given directory.
    
        
        
        
        :param directory: The directory in which to persist key material.
        
        :type directory: System.IO.DirectoryInfo
    
        
        .. code-block:: csharp
    
           public FileSystemXmlRepository(DirectoryInfo directory)
    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.Repositories.FileSystemXmlRepository.FileSystemXmlRepository(System.IO.DirectoryInfo, System.IServiceProvider)
    
        
    
        Creates a :any:`Microsoft.AspNet.DataProtection.Repositories.FileSystemXmlRepository` with keys stored at the given directory.
    
        
        
        
        :param directory: The directory in which to persist key material.
        
        :type directory: System.IO.DirectoryInfo
        
        
        :param services: An optional  to provide ancillary services.
        
        :type services: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           public FileSystemXmlRepository(DirectoryInfo directory, IServiceProvider services)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.DataProtection.Repositories.FileSystemXmlRepository
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.DataProtection.Repositories.FileSystemXmlRepository.GetAllElements()
    
        
        :rtype: System.Collections.Generic.IReadOnlyCollection{System.Xml.Linq.XElement}
    
        
        .. code-block:: csharp
    
           public virtual IReadOnlyCollection<XElement> GetAllElements()
    
    .. dn:method:: Microsoft.AspNet.DataProtection.Repositories.FileSystemXmlRepository.StoreElement(System.Xml.Linq.XElement, System.String)
    
        
        
        
        :type element: System.Xml.Linq.XElement
        
        
        :type friendlyName: System.String
    
        
        .. code-block:: csharp
    
           public virtual void StoreElement(XElement element, string friendlyName)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.DataProtection.Repositories.FileSystemXmlRepository
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.DataProtection.Repositories.FileSystemXmlRepository.DefaultKeyStorageDirectory
    
        
    
        The default key storage directory, which currently corresponds to
        "%LOCALAPPDATA%\ASP.NET\DataProtection-Keys".
    
        
        :rtype: System.IO.DirectoryInfo
    
        
        .. code-block:: csharp
    
           public static DirectoryInfo DefaultKeyStorageDirectory { get; }
    
    .. dn:property:: Microsoft.AspNet.DataProtection.Repositories.FileSystemXmlRepository.Directory
    
        
    
        The directory into which key material will be written.
    
        
        :rtype: System.IO.DirectoryInfo
    
        
        .. code-block:: csharp
    
           public DirectoryInfo Directory { get; }
    
    .. dn:property:: Microsoft.AspNet.DataProtection.Repositories.FileSystemXmlRepository.Services
    
        
    
        The :any:`System.IServiceProvider` provided to the constructor.
    
        
        :rtype: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           protected IServiceProvider Services { get; }
    

