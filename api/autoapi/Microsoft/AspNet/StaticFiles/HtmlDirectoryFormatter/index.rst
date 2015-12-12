

HtmlDirectoryFormatter Class
============================



.. contents:: 
   :local:



Summary
-------

Generates an HTML view for a directory.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.StaticFiles.HtmlDirectoryFormatter`








Syntax
------

.. code-block:: csharp

   public class HtmlDirectoryFormatter : IDirectoryFormatter





GitHub
------

`View on GitHub <https://github.com/aspnet/staticfiles/blob/master/src/Microsoft.AspNet.StaticFiles/HtmlDirectoryFormatter.cs>`_





.. dn:class:: Microsoft.AspNet.StaticFiles.HtmlDirectoryFormatter

Methods
-------

.. dn:class:: Microsoft.AspNet.StaticFiles.HtmlDirectoryFormatter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.StaticFiles.HtmlDirectoryFormatter.GenerateContentAsync(Microsoft.AspNet.Http.HttpContext, System.Collections.Generic.IEnumerable<Microsoft.AspNet.FileProviders.IFileInfo>)
    
        
    
        Generates an HTML view for a directory.
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :type contents: System.Collections.Generic.IEnumerable{Microsoft.AspNet.FileProviders.IFileInfo}
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task GenerateContentAsync(HttpContext context, IEnumerable<IFileInfo> contents)
    

