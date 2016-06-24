

RemoteWindowsDeployer Class
===========================





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
* :dn:cls:`Microsoft.AspNetCore.Server.Testing.ApplicationDeployer`
* :dn:cls:`Microsoft.AspNetCore.Server.Testing.RemoteWindowsDeployer`








Syntax
------

.. code-block:: csharp

    public class RemoteWindowsDeployer : ApplicationDeployer, IApplicationDeployer, IDisposable








.. dn:class:: Microsoft.AspNetCore.Server.Testing.RemoteWindowsDeployer
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Testing.RemoteWindowsDeployer

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Testing.RemoteWindowsDeployer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Testing.RemoteWindowsDeployer.RemoteWindowsDeployer(Microsoft.AspNetCore.Server.Testing.RemoteWindowsDeploymentParameters, Microsoft.Extensions.Logging.ILogger)
    
        
    
        
        :type deploymentParameters: Microsoft.AspNetCore.Server.Testing.RemoteWindowsDeploymentParameters
    
        
        :type logger: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
            public RemoteWindowsDeployer(RemoteWindowsDeploymentParameters deploymentParameters, ILogger logger)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Testing.RemoteWindowsDeployer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Testing.RemoteWindowsDeployer.Deploy()
    
        
        :rtype: Microsoft.AspNetCore.Server.Testing.DeploymentResult
    
        
        .. code-block:: csharp
    
            public override DeploymentResult Deploy()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Testing.RemoteWindowsDeployer.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public override void Dispose()
    

