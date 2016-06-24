

StartupLoader Class
===================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Hosting.Internal`
Assemblies
    * Microsoft.AspNetCore.Hosting

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Hosting.Internal.StartupLoader`








Syntax
------

.. code-block:: csharp

    public class StartupLoader








.. dn:class:: Microsoft.AspNetCore.Hosting.Internal.StartupLoader
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Hosting.Internal.StartupLoader

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Hosting.Internal.StartupLoader
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Hosting.Internal.StartupLoader.FindStartupType(System.String, System.String)
    
        
    
        
        :type startupAssemblyName: System.String
    
        
        :type environmentName: System.String
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
            public static Type FindStartupType(string startupAssemblyName, string environmentName)
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.Internal.StartupLoader.LoadMethods(System.IServiceProvider, System.Type, System.String)
    
        
    
        
        :type services: System.IServiceProvider
    
        
        :type startupType: System.Type
    
        
        :type environmentName: System.String
        :rtype: Microsoft.AspNetCore.Hosting.Internal.StartupMethods
    
        
        .. code-block:: csharp
    
            public static StartupMethods LoadMethods(IServiceProvider services, Type startupType, string environmentName)
    

