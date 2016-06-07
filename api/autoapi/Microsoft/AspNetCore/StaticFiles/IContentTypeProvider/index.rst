

IContentTypeProvider Interface
==============================






Used to look up MIME types given a file path


Namespace
    :dn:ns:`Microsoft.AspNetCore.StaticFiles`
Assemblies
    * Microsoft.AspNetCore.StaticFiles

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IContentTypeProvider








.. dn:interface:: Microsoft.AspNetCore.StaticFiles.IContentTypeProvider
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.StaticFiles.IContentTypeProvider

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.StaticFiles.IContentTypeProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.StaticFiles.IContentTypeProvider.TryGetContentType(System.String, out System.String)
    
        
    
        
        Given a file path, determine the MIME type
    
        
    
        
        :param subpath: A file path
        
        :type subpath: System.String
    
        
        :param contentType: The resulting MIME type
        
        :type contentType: System.String
        :rtype: System.Boolean
        :return: True if MIME type could be determined
    
        
        .. code-block:: csharp
    
            bool TryGetContentType(string subpath, out string contentType)
    

