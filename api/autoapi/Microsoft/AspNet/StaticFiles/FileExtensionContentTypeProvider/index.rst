

FileExtensionContentTypeProvider Class
======================================



.. contents:: 
   :local:



Summary
-------

Provides a mapping between file extensions and MIME types.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.StaticFiles.FileExtensionContentTypeProvider`








Syntax
------

.. code-block:: csharp

   public class FileExtensionContentTypeProvider : IContentTypeProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/staticfiles/src/Microsoft.AspNet.StaticFiles/FileExtensionContentTypeProvider.cs>`_





.. dn:class:: Microsoft.AspNet.StaticFiles.FileExtensionContentTypeProvider

Constructors
------------

.. dn:class:: Microsoft.AspNet.StaticFiles.FileExtensionContentTypeProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.StaticFiles.FileExtensionContentTypeProvider.FileExtensionContentTypeProvider()
    
        
    
        Creates a new provider with a set of default mappings.
    
        
    
        
        .. code-block:: csharp
    
           public FileExtensionContentTypeProvider()
    
    .. dn:constructor:: Microsoft.AspNet.StaticFiles.FileExtensionContentTypeProvider.FileExtensionContentTypeProvider(System.Collections.Generic.IDictionary<System.String, System.String>)
    
        
    
        Creates a lookup engine using the provided mapping.
        It is recommended that the IDictionary instance use StringComparer.OrdinalIgnoreCase.
    
        
        
        
        :type mapping: System.Collections.Generic.IDictionary{System.String,System.String}
    
        
        .. code-block:: csharp
    
           public FileExtensionContentTypeProvider(IDictionary<string, string> mapping)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.StaticFiles.FileExtensionContentTypeProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.StaticFiles.FileExtensionContentTypeProvider.TryGetContentType(System.String, out System.String)
    
        
    
        Given a file path, determine the MIME type
    
        
        
        
        :param subpath: A file path
        
        :type subpath: System.String
        
        
        :param contentType: The resulting MIME type
        
        :type contentType: System.String
        :rtype: System.Boolean
        :return: True if MIME type could be determined
    
        
        .. code-block:: csharp
    
           public bool TryGetContentType(string subpath, out string contentType)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.StaticFiles.FileExtensionContentTypeProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.StaticFiles.FileExtensionContentTypeProvider.Mappings
    
        
    
        The cross reference table of file extensions and content-types.
    
        
        :rtype: System.Collections.Generic.IDictionary{System.String,System.String}
    
        
        .. code-block:: csharp
    
           public IDictionary<string, string> Mappings { get; }
    

