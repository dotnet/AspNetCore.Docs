

DirectoryBrowserOptions Class
=============================






Directory browsing options


Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.StaticFiles

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.StaticFiles.Infrastructure.SharedOptionsBase`
* :dn:cls:`Microsoft.AspNetCore.Builder.DirectoryBrowserOptions`








Syntax
------

.. code-block:: csharp

    public class DirectoryBrowserOptions : SharedOptionsBase








.. dn:class:: Microsoft.AspNetCore.Builder.DirectoryBrowserOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.DirectoryBrowserOptions

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Builder.DirectoryBrowserOptions
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Builder.DirectoryBrowserOptions.DirectoryBrowserOptions()
    
        
    
        
        Enabled directory browsing for all request paths
    
        
    
        
        .. code-block:: csharp
    
            public DirectoryBrowserOptions()
    
    .. dn:constructor:: Microsoft.AspNetCore.Builder.DirectoryBrowserOptions.DirectoryBrowserOptions(Microsoft.AspNetCore.StaticFiles.Infrastructure.SharedOptions)
    
        
    
        
        Enabled directory browsing all request paths
    
        
    
        
        :type sharedOptions: Microsoft.AspNetCore.StaticFiles.Infrastructure.SharedOptions
    
        
        .. code-block:: csharp
    
            public DirectoryBrowserOptions(SharedOptions sharedOptions)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Builder.DirectoryBrowserOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Builder.DirectoryBrowserOptions.Formatter
    
        
    
        
        The component that generates the view.
    
        
        :rtype: Microsoft.AspNetCore.StaticFiles.IDirectoryFormatter
    
        
        .. code-block:: csharp
    
            public IDirectoryFormatter Formatter { get; set; }
    

