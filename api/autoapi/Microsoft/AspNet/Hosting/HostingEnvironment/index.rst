

HostingEnvironment Class
========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Hosting.HostingEnvironment`








Syntax
------

.. code-block:: csharp

   public class HostingEnvironment : IHostingEnvironment





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/hosting/src/Microsoft.AspNet.Hosting/HostingEnvironment.cs>`_





.. dn:class:: Microsoft.AspNet.Hosting.HostingEnvironment

Properties
----------

.. dn:class:: Microsoft.AspNet.Hosting.HostingEnvironment
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Hosting.HostingEnvironment.EnvironmentName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string EnvironmentName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Hosting.HostingEnvironment.WebRootFileProvider
    
        
        :rtype: Microsoft.AspNet.FileProviders.IFileProvider
    
        
        .. code-block:: csharp
    
           public IFileProvider WebRootFileProvider { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Hosting.HostingEnvironment.WebRootPath
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string WebRootPath { get; set; }
    

