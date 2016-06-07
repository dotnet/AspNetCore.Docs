

IDirectoryContents Interface
============================






Represents a directory's content in the file provider.


Namespace
    :dn:ns:`Microsoft.Extensions.FileProviders`
Assemblies
    * Microsoft.Extensions.FileProviders.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IDirectoryContents : IEnumerable<IFileInfo>, IEnumerable








.. dn:interface:: Microsoft.Extensions.FileProviders.IDirectoryContents
    :hidden:

.. dn:interface:: Microsoft.Extensions.FileProviders.IDirectoryContents

Properties
----------

.. dn:interface:: Microsoft.Extensions.FileProviders.IDirectoryContents
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.FileProviders.IDirectoryContents.Exists
    
        
    
        
        True if a directory was located at the given path.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            bool Exists
            {
                get;
            }
    

