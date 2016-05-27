

PhysicalFilesWatcher Class
==========================





Namespace
    :dn:ns:`Microsoft.Extensions.FileProviders.Physical`
Assemblies
    * Microsoft.Extensions.FileProviders.Physical

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.FileProviders.Physical.PhysicalFilesWatcher`








Syntax
------

.. code-block:: csharp

    public class PhysicalFilesWatcher : IDisposable








.. dn:class:: Microsoft.Extensions.FileProviders.Physical.PhysicalFilesWatcher
    :hidden:

.. dn:class:: Microsoft.Extensions.FileProviders.Physical.PhysicalFilesWatcher

Constructors
------------

.. dn:class:: Microsoft.Extensions.FileProviders.Physical.PhysicalFilesWatcher
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.FileProviders.Physical.PhysicalFilesWatcher.PhysicalFilesWatcher(System.String, System.IO.FileSystemWatcher, System.Boolean)
    
        
    
        
        :type root: System.String
    
        
        :type fileSystemWatcher: System.IO.FileSystemWatcher
    
        
        :type pollForChanges: System.Boolean
    
        
        .. code-block:: csharp
    
            public PhysicalFilesWatcher(string root, FileSystemWatcher fileSystemWatcher, bool pollForChanges)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.FileProviders.Physical.PhysicalFilesWatcher
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.FileProviders.Physical.PhysicalFilesWatcher.CreateFileChangeToken(System.String)
    
        
    
        
        :type filter: System.String
        :rtype: Microsoft.Extensions.Primitives.IChangeToken
    
        
        .. code-block:: csharp
    
            public IChangeToken CreateFileChangeToken(string filter)
    
    .. dn:method:: Microsoft.Extensions.FileProviders.Physical.PhysicalFilesWatcher.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    

