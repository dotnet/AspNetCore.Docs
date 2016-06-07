

HtmlDirectoryFormatter Class
============================






Generates an HTML view for a directory.


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
* :dn:cls:`Microsoft.AspNetCore.StaticFiles.HtmlDirectoryFormatter`








Syntax
------

.. code-block:: csharp

    public class HtmlDirectoryFormatter : IDirectoryFormatter








.. dn:class:: Microsoft.AspNetCore.StaticFiles.HtmlDirectoryFormatter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.StaticFiles.HtmlDirectoryFormatter

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.StaticFiles.HtmlDirectoryFormatter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.StaticFiles.HtmlDirectoryFormatter.HtmlDirectoryFormatter(System.Text.Encodings.Web.HtmlEncoder)
    
        
    
        
        :type encoder: System.Text.Encodings.Web.HtmlEncoder
    
        
        .. code-block:: csharp
    
            public HtmlDirectoryFormatter(HtmlEncoder encoder)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.StaticFiles.HtmlDirectoryFormatter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.StaticFiles.HtmlDirectoryFormatter.GenerateContentAsync(Microsoft.AspNetCore.Http.HttpContext, System.Collections.Generic.IEnumerable<Microsoft.Extensions.FileProviders.IFileInfo>)
    
        
    
        
        Generates an HTML view for a directory.
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type contents: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.Extensions.FileProviders.IFileInfo<Microsoft.Extensions.FileProviders.IFileInfo>}
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task GenerateContentAsync(HttpContext context, IEnumerable<IFileInfo> contents)
    

