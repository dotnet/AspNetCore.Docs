

CompositeFileProvider Class
===========================






Looks up files using a list of :any:`Microsoft.Extensions.FileProviders.IFileProvider`\.


Namespace
    :dn:ns:`Microsoft.Extensions.FileProviders`
Assemblies
    * Microsoft.Extensions.FileProviders.Composite

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.FileProviders.CompositeFileProvider`








Syntax
------

.. code-block:: csharp

    public class CompositeFileProvider : IFileProvider








.. dn:class:: Microsoft.Extensions.FileProviders.CompositeFileProvider
    :hidden:

.. dn:class:: Microsoft.Extensions.FileProviders.CompositeFileProvider

Properties
----------

.. dn:class:: Microsoft.Extensions.FileProviders.CompositeFileProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.FileProviders.CompositeFileProvider.FileProviders
    
        
    
        
        Gets the list of configured :any:`Microsoft.Extensions.FileProviders.IFileProvider` instances.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.Extensions.FileProviders.IFileProvider<Microsoft.Extensions.FileProviders.IFileProvider>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<IFileProvider> FileProviders
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.Extensions.FileProviders.CompositeFileProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.FileProviders.CompositeFileProvider.CompositeFileProvider(Microsoft.Extensions.FileProviders.IFileProvider[])
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.Extensions.FileProviders.CompositeFileProvider` class using a list of file provider.
    
        
    
        
        :type fileProviders: Microsoft.Extensions.FileProviders.IFileProvider<Microsoft.Extensions.FileProviders.IFileProvider>[]
    
        
        .. code-block:: csharp
    
            public CompositeFileProvider(params IFileProvider[] fileProviders)
    
    .. dn:constructor:: Microsoft.Extensions.FileProviders.CompositeFileProvider.CompositeFileProvider(System.Collections.Generic.IEnumerable<Microsoft.Extensions.FileProviders.IFileProvider>)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.Extensions.FileProviders.CompositeFileProvider` class using a list of file provider.
    
        
    
        
        :type fileProviders: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.Extensions.FileProviders.IFileProvider<Microsoft.Extensions.FileProviders.IFileProvider>}
    
        
        .. code-block:: csharp
    
            public CompositeFileProvider(IEnumerable<IFileProvider> fileProviders)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.FileProviders.CompositeFileProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.FileProviders.CompositeFileProvider.GetDirectoryContents(System.String)
    
        
    
        
        Enumerate a directory at the given path, if any.
    
        
    
        
        :param subpath: The path that identifies the directory
        
        :type subpath: System.String
        :rtype: Microsoft.Extensions.FileProviders.IDirectoryContents
        :return: Contents of the directory. Caller must check Exists property.
            The content is a merge of the contents of the provided :any:`Microsoft.Extensions.FileProviders.IFileProvider`\.
            When there is multiple :any:`Microsoft.Extensions.FileProviders.IFileInfo` with the same Name property, only the first one is included on the results.
    
        
        .. code-block:: csharp
    
            public IDirectoryContents GetDirectoryContents(string subpath)
    
    .. dn:method:: Microsoft.Extensions.FileProviders.CompositeFileProvider.GetFileInfo(System.String)
    
        
    
        
        Locates a file at the given path.
    
        
    
        
        :param subpath: The path that identifies the file. 
        
        :type subpath: System.String
        :rtype: Microsoft.Extensions.FileProviders.IFileInfo
        :return: The file information. Caller must check Exists property. This will be the first existing :any:`Microsoft.Extensions.FileProviders.IFileInfo` returned by the provided :any:`Microsoft.Extensions.FileProviders.IFileProvider` or a not found :any:`Microsoft.Extensions.FileProviders.IFileInfo` if no existing files is found.
    
        
        .. code-block:: csharp
    
            public IFileInfo GetFileInfo(string subpath)
    
    .. dn:method:: Microsoft.Extensions.FileProviders.CompositeFileProvider.Watch(System.String)
    
        
    
        
        Creates a :any:`Microsoft.Extensions.Primitives.IChangeToken` for the specified <em>pattern</em>.
    
        
    
        
        :param pattern: Filter string used to determine what files or folders to monitor. Example: ``**/*.cs``, ``*.*``, ``subFolder/**/*.cshtml``.
        
        :type pattern: System.String
        :rtype: Microsoft.Extensions.Primitives.IChangeToken
        :return: An :any:`Microsoft.Extensions.Primitives.IChangeToken` that is notified when a file matching <em>pattern</em> is added, modified or deleted.
            The change token will be notified when one of the change token returned by the provided :any:`Microsoft.Extensions.FileProviders.IFileProvider` will be notified.
    
        
        .. code-block:: csharp
    
            public IChangeToken Watch(string pattern)
    

