

DirectoryBrowserOptions Class
=============================



.. contents:: 
   :local:



Summary
-------

Directory browsing options





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.StaticFiles.Infrastructure.SharedOptionsBase{Microsoft.AspNet.StaticFiles.DirectoryBrowserOptions}`
* :dn:cls:`Microsoft.AspNet.StaticFiles.DirectoryBrowserOptions`








Syntax
------

.. code-block:: csharp

   public class DirectoryBrowserOptions : SharedOptionsBase<DirectoryBrowserOptions>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/staticfiles/src/Microsoft.AspNet.StaticFiles/DirectoryBrowserOptions.cs>`_





.. dn:class:: Microsoft.AspNet.StaticFiles.DirectoryBrowserOptions

Constructors
------------

.. dn:class:: Microsoft.AspNet.StaticFiles.DirectoryBrowserOptions
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.StaticFiles.DirectoryBrowserOptions.DirectoryBrowserOptions()
    
        
    
        Enabled directory browsing for all request paths
    
        
    
        
        .. code-block:: csharp
    
           public DirectoryBrowserOptions()
    
    .. dn:constructor:: Microsoft.AspNet.StaticFiles.DirectoryBrowserOptions.DirectoryBrowserOptions(Microsoft.AspNet.StaticFiles.Infrastructure.SharedOptions)
    
        
    
        Enabled directory browsing all request paths
    
        
        
        
        :type sharedOptions: Microsoft.AspNet.StaticFiles.Infrastructure.SharedOptions
    
        
        .. code-block:: csharp
    
           public DirectoryBrowserOptions(SharedOptions sharedOptions)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.StaticFiles.DirectoryBrowserOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.StaticFiles.DirectoryBrowserOptions.Formatter
    
        
    
        The component that generates the view.
    
        
        :rtype: Microsoft.AspNet.StaticFiles.IDirectoryFormatter
    
        
        .. code-block:: csharp
    
           public IDirectoryFormatter Formatter { get; set; }
    

