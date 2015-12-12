

IDirectoryContents Interface
============================



.. contents:: 
   :local:



Summary
-------

Represents a directory's content in the file provider.











Syntax
------

.. code-block:: csharp

   public interface IDirectoryContents : IEnumerable<IFileInfo>, IEnumerable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/filesystem/src/Microsoft.AspNet.FileProviders.Abstractions/IDirectoryContents.cs>`_





.. dn:interface:: Microsoft.AspNet.FileProviders.IDirectoryContents

Properties
----------

.. dn:interface:: Microsoft.AspNet.FileProviders.IDirectoryContents
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.FileProviders.IDirectoryContents.Exists
    
        
    
        True if a directory was located at the given path.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool Exists { get; }
    

