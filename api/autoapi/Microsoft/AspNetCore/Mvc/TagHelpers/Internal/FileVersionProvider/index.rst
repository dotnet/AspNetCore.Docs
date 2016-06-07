

FileVersionProvider Class
=========================






Provides version hash for a specified file.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.TagHelpers.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.TagHelpers

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.TagHelpers.Internal.FileVersionProvider`








Syntax
------

.. code-block:: csharp

    public class FileVersionProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.FileVersionProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.FileVersionProvider

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.FileVersionProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.FileVersionProvider.FileVersionProvider(Microsoft.Extensions.FileProviders.IFileProvider, Microsoft.Extensions.Caching.Memory.IMemoryCache, Microsoft.AspNetCore.Http.PathString)
    
        
    
        
        Creates a new instance of :any:`Microsoft.AspNetCore.Mvc.TagHelpers.Internal.FileVersionProvider`\.
    
        
    
        
        :param fileProvider: The file provider to get and watch files.
        
        :type fileProvider: Microsoft.Extensions.FileProviders.IFileProvider
    
        
        :param cache: :any:`Microsoft.Extensions.Caching.Memory.IMemoryCache` where versioned urls of files are cached.
        
        :type cache: Microsoft.Extensions.Caching.Memory.IMemoryCache
    
        
        :param requestPathBase: The base path for the current HTTP request.
        
        :type requestPathBase: Microsoft.AspNetCore.Http.PathString
    
        
        .. code-block:: csharp
    
            public FileVersionProvider(IFileProvider fileProvider, IMemoryCache cache, PathString requestPathBase)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.FileVersionProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.FileVersionProvider.AddFileVersionToPath(System.String)
    
        
    
        
        Adds version query parameter to the specified file path.
    
        
    
        
        :param path: The path of the file to which version should be added.
        
        :type path: System.String
        :rtype: System.String
        :return: Path containing the version query string.
    
        
        .. code-block:: csharp
    
            public string AddFileVersionToPath(string path)
    

