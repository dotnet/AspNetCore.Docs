

RelativeFileInfo Class
======================






A container type that represents :any:`Microsoft.Extensions.FileProviders.IFileInfo` along with the application base relative path
for a file in the file system.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Razor.Compilation`
Assemblies
    * Microsoft.AspNetCore.Mvc.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.Compilation.RelativeFileInfo`








Syntax
------

.. code-block:: csharp

    public class RelativeFileInfo








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Compilation.RelativeFileInfo
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Compilation.RelativeFileInfo

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Compilation.RelativeFileInfo
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.Compilation.RelativeFileInfo.FileInfo
    
        
    
        
        Gets the :any:`Microsoft.Extensions.FileProviders.IFileInfo` associated with this instance of :any:`Microsoft.AspNetCore.Mvc.Razor.Compilation.RelativeFileInfo`\.
    
        
        :rtype: Microsoft.Extensions.FileProviders.IFileInfo
    
        
        .. code-block:: csharp
    
            public IFileInfo FileInfo
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.Compilation.RelativeFileInfo.RelativePath
    
        
    
        
        Gets the path of the file relative to the application base.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string RelativePath
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Compilation.RelativeFileInfo
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.Compilation.RelativeFileInfo.RelativeFileInfo(Microsoft.Extensions.FileProviders.IFileInfo, System.String)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Razor.Compilation.RelativeFileInfo`\.
    
        
    
        
        :param fileInfo: :any:`Microsoft.Extensions.FileProviders.IFileInfo` for the file.
        
        :type fileInfo: Microsoft.Extensions.FileProviders.IFileInfo
    
        
        :param relativePath: Path of the file relative to the application base.
        
        :type relativePath: System.String
    
        
        .. code-block:: csharp
    
            public RelativeFileInfo(IFileInfo fileInfo, string relativePath)
    

