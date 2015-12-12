

RelativeFileInfo Class
======================



.. contents:: 
   :local:



Summary
-------

A container type that represents :any:`Microsoft.AspNet.FileProviders.IFileInfo` along with the application base relative path
for a file in the file system.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.Compilation.RelativeFileInfo`








Syntax
------

.. code-block:: csharp

   public class RelativeFileInfo





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Razor/Compilation/RelativeFileInfo.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.Compilation.RelativeFileInfo

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Compilation.RelativeFileInfo
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.Compilation.RelativeFileInfo.RelativeFileInfo(Microsoft.AspNet.FileProviders.IFileInfo, System.String)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Mvc.Razor.Compilation.RelativeFileInfo`\.
    
        
        
        
        :param fileInfo: for the file.
        
        :type fileInfo: Microsoft.AspNet.FileProviders.IFileInfo
        
        
        :param relativePath: Path of the file relative to the application base.
        
        :type relativePath: System.String
    
        
        .. code-block:: csharp
    
           public RelativeFileInfo(IFileInfo fileInfo, string relativePath)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Compilation.RelativeFileInfo
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.Compilation.RelativeFileInfo.FileInfo
    
        
    
        Gets the :any:`Microsoft.AspNet.FileProviders.IFileInfo` associated with this instance of :any:`Microsoft.AspNet.Mvc.Razor.Compilation.RelativeFileInfo`\.
    
        
        :rtype: Microsoft.AspNet.FileProviders.IFileInfo
    
        
        .. code-block:: csharp
    
           public IFileInfo FileInfo { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.Compilation.RelativeFileInfo.RelativePath
    
        
    
        Gets the path of the file relative to the application base.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string RelativePath { get; }
    

