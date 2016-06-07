

SelfHostDeployer Class
======================






Deployer for WebListener and Kestrel.


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
* :dn:cls:`Microsoft.AspNetCore.Server.Testing.SelfHostDeployer`








Syntax
------

.. code-block:: csharp

    public class SelfHostDeployer : ApplicationDeployer, IApplicationDeployer, IDisposable








.. dn:class:: Microsoft.AspNetCore.Server.Testing.SelfHostDeployer
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Testing.SelfHostDeployer

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Testing.SelfHostDeployer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Testing.SelfHostDeployer.SelfHostDeployer(Microsoft.AspNetCore.Server.Testing.DeploymentParameters, Microsoft.Extensions.Logging.ILogger)
    
        
    
        
        :type deploymentParameters: Microsoft.AspNetCore.Server.Testing.DeploymentParameters
    
        
        :type logger: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
            public SelfHostDeployer(DeploymentParameters deploymentParameters, ILogger logger)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Testing.SelfHostDeployer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Testing.SelfHostDeployer.Deploy()
    
        
        :rtype: Microsoft.AspNetCore.Server.Testing.DeploymentResult
    
        
        .. code-block:: csharp
    
            public override DeploymentResult Deploy()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Testing.SelfHostDeployer.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public override void Dispose()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Testing.SelfHostDeployer.StartSelfHost(System.Uri)
    
        
    
        
        :type uri: System.Uri
        :rtype: System.Threading.CancellationToken
    
        
        .. code-block:: csharp
    
            protected CancellationToken StartSelfHost(Uri uri)
    

