

IDirectoryFormatter Interface
=============================



.. contents:: 
   :local:



Summary
-------

Generates the view for a directory











Syntax
------

.. code-block:: csharp

   public interface IDirectoryFormatter





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/staticfiles/src/Microsoft.AspNet.StaticFiles/IDirectoryFormatter.cs>`_





.. dn:interface:: Microsoft.AspNet.StaticFiles.IDirectoryFormatter

Methods
-------

.. dn:interface:: Microsoft.AspNet.StaticFiles.IDirectoryFormatter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.StaticFiles.IDirectoryFormatter.GenerateContentAsync(Microsoft.AspNet.Http.HttpContext, System.Collections.Generic.IEnumerable<Microsoft.AspNet.FileProviders.IFileInfo>)
    
        
    
        Generates the view for a directory.
        Implementers should properly handle HEAD requests.
        Implementers should set all necessary response headers (e.g. Content-Type, Content-Length, etc.).
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :type contents: System.Collections.Generic.IEnumerable{Microsoft.AspNet.FileProviders.IFileInfo}
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task GenerateContentAsync(HttpContext context, IEnumerable<IFileInfo> contents)
    

