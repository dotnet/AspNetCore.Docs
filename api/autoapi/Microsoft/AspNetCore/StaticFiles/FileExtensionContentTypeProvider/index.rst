

FileExtensionContentTypeProvider Class
======================================






Provides a mapping between file extensions and MIME types.


Namespace
    :dn:ns:`Microsoft.AspNetCore.StaticFiles`
Assemblies
    * Microsoft.AspNetCore.StaticFiles

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider`








Syntax
------

.. code-block:: csharp

    public class FileExtensionContentTypeProvider : IContentTypeProvider








.. dn:class:: Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider.FileExtensionContentTypeProvider()
    
        
    
        
        Creates a new provider with a set of default mappings.
    
        
    
        
        .. code-block:: csharp
    
            public FileExtensionContentTypeProvider()
    
    .. dn:constructor:: Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider.FileExtensionContentTypeProvider(System.Collections.Generic.IDictionary<System.String, System.String>)
    
        
    
        
        Creates a lookup engine using the provided mapping.
        It is recommended that the IDictionary instance use StringComparer.OrdinalIgnoreCase.
    
        
    
        
        :type mapping: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public FileExtensionContentTypeProvider(IDictionary<string, string> mapping)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider.Mappings
    
        
    
        
        The cross reference table of file extensions and content-types.
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IDictionary<string, string> Mappings { get; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider.TryGetContentType(System.String, out System.String)
    
        
    
        
        Given a file path, determine the MIME type
    
        
    
        
        :param subpath: A file path
        
        :type subpath: System.String
    
        
        :param contentType: The resulting MIME type
        
        :type contentType: System.String
        :rtype: System.Boolean
        :return: True if MIME type could be determined
    
        
        .. code-block:: csharp
    
            public bool TryGetContentType(string subpath, out string contentType)
    

