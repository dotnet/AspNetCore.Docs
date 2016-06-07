

IDirectoryFormatter Interface
=============================






Generates the view for a directory


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

    public interface IDirectoryFormatter








.. dn:interface:: Microsoft.AspNetCore.StaticFiles.IDirectoryFormatter
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.StaticFiles.IDirectoryFormatter

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.StaticFiles.IDirectoryFormatter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.StaticFiles.IDirectoryFormatter.GenerateContentAsync(Microsoft.AspNetCore.Http.HttpContext, System.Collections.Generic.IEnumerable<Microsoft.Extensions.FileProviders.IFileInfo>)
    
        
    
        
        Generates the view for a directory.
        Implementers should properly handle HEAD requests.
        Implementers should set all necessary response headers (e.g. Content-Type, Content-Length, etc.).
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type contents: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.Extensions.FileProviders.IFileInfo<Microsoft.Extensions.FileProviders.IFileInfo>}
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            Task GenerateContentAsync(HttpContext context, IEnumerable<IFileInfo> contents)
    

