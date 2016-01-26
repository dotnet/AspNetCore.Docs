

IContentTypeProvider Interface
==============================



.. contents:: 
   :local:



Summary
-------

Used to look up MIME types given a file path











Syntax
------

.. code-block:: csharp

   public interface IContentTypeProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/staticfiles/blob/master/src/Microsoft.AspNet.StaticFiles/IContentTypeProvider.cs>`_





.. dn:interface:: Microsoft.AspNet.StaticFiles.IContentTypeProvider

Methods
-------

.. dn:interface:: Microsoft.AspNet.StaticFiles.IContentTypeProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.StaticFiles.IContentTypeProvider.TryGetContentType(System.String, out System.String)
    
        
    
        Given a file path, determine the MIME type
    
        
        
        
        :param subpath: A file path
        
        :type subpath: System.String
        
        
        :param contentType: The resulting MIME type
        
        :type contentType: System.String
        :rtype: System.Boolean
        :return: True if MIME type could be determined
    
        
        .. code-block:: csharp
    
           bool TryGetContentType(string subpath, out string contentType)
    

