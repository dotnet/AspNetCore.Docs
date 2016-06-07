

IStartupLoader Interface
========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Hosting.Startup`
Assemblies
    * Microsoft.AspNetCore.Hosting

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IStartupLoader








.. dn:interface:: Microsoft.AspNetCore.Hosting.Startup.IStartupLoader
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Hosting.Startup.IStartupLoader

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Hosting.Startup.IStartupLoader
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Hosting.Startup.IStartupLoader.FindStartupType(System.String, System.Collections.Generic.IList<System.String>)
    
        
    
        
        :type startupAssemblyName: System.String
    
        
        :type diagnosticMessages: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
            Type FindStartupType(string startupAssemblyName, IList<string> diagnosticMessages)
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.Startup.IStartupLoader.LoadMethods(System.Type, System.Collections.Generic.IList<System.String>)
    
        
    
        
        :type startupType: System.Type
    
        
        :type diagnosticMessages: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
        :rtype: Microsoft.AspNetCore.Hosting.Startup.StartupMethods
    
        
        .. code-block:: csharp
    
            StartupMethods LoadMethods(Type startupType, IList<string> diagnosticMessages)
    

