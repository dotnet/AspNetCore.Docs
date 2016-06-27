

CompositeDirectoryContents Class
================================






Represents the result of a call composition of :dn:meth:`Microsoft.Extensions.FileProviders.IFileProvider.GetDirectoryContents(System.String)`
for a list of :any:`Microsoft.Extensions.FileProviders.IFileProvider` and a path.


Namespace
    :dn:ns:`Microsoft.Extensions.FileProviders.Composite`
Assemblies
    * Microsoft.Extensions.FileProviders.Composite

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.FileProviders.Composite.CompositeDirectoryContents`








Syntax
------

.. code-block:: csharp

    public class CompositeDirectoryContents : IDirectoryContents, IEnumerable<IFileInfo>, IEnumerable








.. dn:class:: Microsoft.Extensions.FileProviders.Composite.CompositeDirectoryContents
    :hidden:

.. dn:class:: Microsoft.Extensions.FileProviders.Composite.CompositeDirectoryContents

Constructors
------------

.. dn:class:: Microsoft.Extensions.FileProviders.Composite.CompositeDirectoryContents
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.FileProviders.Composite.CompositeDirectoryContents.CompositeDirectoryContents(System.Collections.Generic.IList<Microsoft.Extensions.FileProviders.IFileProvider>, System.String)
    
        
    
        
        Creates a new instance of :any:`Microsoft.Extensions.FileProviders.Composite.CompositeDirectoryContents` to represents the result of a call composition of 
        :dn:meth:`Microsoft.Extensions.FileProviders.IFileProvider.GetDirectoryContents(System.String)`\.
    
        
    
        
        :param fileProviders: The list of :any:`Microsoft.Extensions.FileProviders.IFileProvider` for which the results have to be composed.
        
        :type fileProviders: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.Extensions.FileProviders.IFileProvider<Microsoft.Extensions.FileProviders.IFileProvider>}
    
        
        :param subpath: The path.
        
        :type subpath: System.String
    
        
        .. code-block:: csharp
    
            public CompositeDirectoryContents(IList<IFileProvider> fileProviders, string subpath)
    

Properties
----------

.. dn:class:: Microsoft.Extensions.FileProviders.Composite.CompositeDirectoryContents
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.FileProviders.Composite.CompositeDirectoryContents.Exists
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Exists { get; }
    

Methods
-------

.. dn:class:: Microsoft.Extensions.FileProviders.Composite.CompositeDirectoryContents
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.FileProviders.Composite.CompositeDirectoryContents.GetEnumerator()
    
        
        :rtype: System.Collections.Generic.IEnumerator<System.Collections.Generic.IEnumerator`1>{Microsoft.Extensions.FileProviders.IFileInfo<Microsoft.Extensions.FileProviders.IFileInfo>}
    
        
        .. code-block:: csharp
    
            public IEnumerator<IFileInfo> GetEnumerator()
    
    .. dn:method:: Microsoft.Extensions.FileProviders.Composite.CompositeDirectoryContents.System.Collections.IEnumerable.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
            IEnumerator IEnumerable.GetEnumerator()
    

