

IISExpressDeployer Class
========================






Deployment helper for IISExpress.


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
* :dn:cls:`Microsoft.AspNetCore.Server.Testing.IISExpressDeployer`








Syntax
------

.. code-block:: csharp

    public class IISExpressDeployer : ApplicationDeployer, IApplicationDeployer, IDisposable








.. dn:class:: Microsoft.AspNetCore.Server.Testing.IISExpressDeployer
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Testing.IISExpressDeployer

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Testing.IISExpressDeployer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Testing.IISExpressDeployer.IISExpressDeployer(Microsoft.AspNetCore.Server.Testing.DeploymentParameters, Microsoft.Extensions.Logging.ILogger)
    
        
    
        
        :type deploymentParameters: Microsoft.AspNetCore.Server.Testing.DeploymentParameters
    
        
        :type logger: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
            public IISExpressDeployer(DeploymentParameters deploymentParameters, ILogger logger)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Testing.IISExpressDeployer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Testing.IISExpressDeployer.Deploy()
    
        
        :rtype: Microsoft.AspNetCore.Server.Testing.DeploymentResult
    
        
        .. code-block:: csharp
    
            public override DeploymentResult Deploy()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Testing.IISExpressDeployer.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public override void Dispose()
    

