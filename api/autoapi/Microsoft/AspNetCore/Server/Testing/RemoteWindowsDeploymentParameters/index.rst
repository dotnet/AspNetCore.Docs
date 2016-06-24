

RemoteWindowsDeploymentParameters Class
=======================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Testing`
Assemblies
    * Microsoft.AspNetCore.Server.Testing

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Server.Testing.DeploymentParameters`
* :dn:cls:`Microsoft.AspNetCore.Server.Testing.RemoteWindowsDeploymentParameters`








Syntax
------

.. code-block:: csharp

    public class RemoteWindowsDeploymentParameters : DeploymentParameters








.. dn:class:: Microsoft.AspNetCore.Server.Testing.RemoteWindowsDeploymentParameters
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Testing.RemoteWindowsDeploymentParameters

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Testing.RemoteWindowsDeploymentParameters
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Testing.RemoteWindowsDeploymentParameters.RemoteWindowsDeploymentParameters(System.String, System.String, Microsoft.AspNetCore.Server.Testing.ServerType, Microsoft.AspNetCore.Server.Testing.RuntimeFlavor, Microsoft.AspNetCore.Server.Testing.RuntimeArchitecture, System.String, System.String, System.String, System.String)
    
        
    
        
        :type applicationPath: System.String
    
        
        :type dotnetRuntimePath: System.String
    
        
        :type serverType: Microsoft.AspNetCore.Server.Testing.ServerType
    
        
        :type runtimeFlavor: Microsoft.AspNetCore.Server.Testing.RuntimeFlavor
    
        
        :type runtimeArchitecture: Microsoft.AspNetCore.Server.Testing.RuntimeArchitecture
    
        
        :type remoteServerFileSharePath: System.String
    
        
        :type remoteServerName: System.String
    
        
        :type remoteServerAccountName: System.String
    
        
        :type remoteServerAccountPassword: System.String
    
        
        .. code-block:: csharp
    
            public RemoteWindowsDeploymentParameters(string applicationPath, string dotnetRuntimePath, ServerType serverType, RuntimeFlavor runtimeFlavor, RuntimeArchitecture runtimeArchitecture, string remoteServerFileSharePath, string remoteServerName, string remoteServerAccountName, string remoteServerAccountPassword)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Server.Testing.RemoteWindowsDeploymentParameters
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Server.Testing.RemoteWindowsDeploymentParameters.DotnetRuntimePath
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string DotnetRuntimePath { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Testing.RemoteWindowsDeploymentParameters.RemoteServerFileSharePath
    
        
    
        
        The full path to the remote server's file share
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string RemoteServerFileSharePath { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Testing.RemoteWindowsDeploymentParameters.ServerAccountName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ServerAccountName { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Testing.RemoteWindowsDeploymentParameters.ServerAccountPassword
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ServerAccountPassword { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Testing.RemoteWindowsDeploymentParameters.ServerName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ServerName { get; }
    

