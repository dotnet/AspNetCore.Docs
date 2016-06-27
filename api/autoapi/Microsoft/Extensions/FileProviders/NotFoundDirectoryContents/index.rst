

NotFoundDirectoryContents Class
===============================






Represents a non-existing directory


Namespace
    :dn:ns:`Microsoft.Extensions.FileProviders`
Assemblies
    * Microsoft.Extensions.FileProviders.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.FileProviders.NotFoundDirectoryContents`








Syntax
------

.. code-block:: csharp

    public class NotFoundDirectoryContents : IDirectoryContents, IEnumerable<IFileInfo>, IEnumerable








.. dn:class:: Microsoft.Extensions.FileProviders.NotFoundDirectoryContents
    :hidden:

.. dn:class:: Microsoft.Extensions.FileProviders.NotFoundDirectoryContents

Properties
----------

.. dn:class:: Microsoft.Extensions.FileProviders.NotFoundDirectoryContents
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.FileProviders.NotFoundDirectoryContents.Exists
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Exists { get; }
    

Methods
-------

.. dn:class:: Microsoft.Extensions.FileProviders.NotFoundDirectoryContents
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.FileProviders.NotFoundDirectoryContents.GetEnumerator()
    
        
        :rtype: System.Collections.Generic.IEnumerator<System.Collections.Generic.IEnumerator`1>{Microsoft.Extensions.FileProviders.IFileInfo<Microsoft.Extensions.FileProviders.IFileInfo>}
    
        
        .. code-block:: csharp
    
            public IEnumerator<IFileInfo> GetEnumerator()
    
    .. dn:method:: Microsoft.Extensions.FileProviders.NotFoundDirectoryContents.System.Collections.IEnumerable.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
            IEnumerator IEnumerable.GetEnumerator()
    

