

FileVersionProvider Class
=========================



.. contents:: 
   :local:



Summary
-------

Provides version hash for a specified file.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.TagHelpers.Internal.FileVersionProvider`








Syntax
------

.. code-block:: csharp

   public class FileVersionProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.TagHelpers/Internal/FileVersionProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.Internal.FileVersionProvider

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.Internal.FileVersionProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.TagHelpers.Internal.FileVersionProvider.FileVersionProvider(Microsoft.AspNet.FileProviders.IFileProvider, Microsoft.Extensions.Caching.Memory.IMemoryCache, Microsoft.AspNet.Http.PathString)
    
        
    
        Creates a new instance of :any:`Microsoft.AspNet.Mvc.TagHelpers.Internal.FileVersionProvider`\.
    
        
        
        
        :param fileProvider: The file provider to get and watch files.
        
        :type fileProvider: Microsoft.AspNet.FileProviders.IFileProvider
        
        
        :param cache: where versioned urls of files are cached.
        
        :type cache: Microsoft.Extensions.Caching.Memory.IMemoryCache
        
        
        :type requestPathBase: Microsoft.AspNet.Http.PathString
    
        
        .. code-block:: csharp
    
           public FileVersionProvider(IFileProvider fileProvider, IMemoryCache cache, PathString requestPathBase)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.Internal.FileVersionProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.TagHelpers.Internal.FileVersionProvider.AddFileVersionToPath(System.String)
    
        
    
        Adds version query parameter to the specified file path.
    
        
        
        
        :param path: The path of the file to which version should be added.
        
        :type path: System.String
        :rtype: System.String
        :return: Path containing the version query string.
    
        
        .. code-block:: csharp
    
           public string AddFileVersionToPath(string path)
    

