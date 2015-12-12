

IStartupLoader Interface
========================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IStartupLoader





GitHub
------

`View on GitHub <https://github.com/aspnet/hosting/blob/master/src/Microsoft.AspNet.Hosting/Startup/IStartupLoader.cs>`_





.. dn:interface:: Microsoft.AspNet.Hosting.Startup.IStartupLoader

Methods
-------

.. dn:interface:: Microsoft.AspNet.Hosting.Startup.IStartupLoader
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Hosting.Startup.IStartupLoader.FindStartupType(System.String, System.Collections.Generic.IList<System.String>)
    
        
        
        
        :type startupAssemblyName: System.String
        
        
        :type diagnosticMessages: System.Collections.Generic.IList{System.String}
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
           Type FindStartupType(string startupAssemblyName, IList<string> diagnosticMessages)
    
    .. dn:method:: Microsoft.AspNet.Hosting.Startup.IStartupLoader.LoadMethods(System.Type, System.Collections.Generic.IList<System.String>)
    
        
        
        
        :type startupType: System.Type
        
        
        :type diagnosticMessages: System.Collections.Generic.IList{System.String}
        :rtype: Microsoft.AspNet.Hosting.Startup.StartupMethods
    
        
        .. code-block:: csharp
    
           StartupMethods LoadMethods(Type startupType, IList<string> diagnosticMessages)
    

