

IISDeployer Class
=================






Deployer for IIS.


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
* :dn:cls:`Microsoft.AspNetCore.Server.Testing.IISDeployer`








Syntax
------

.. code-block:: csharp

    public class IISDeployer : ApplicationDeployer, IApplicationDeployer, IDisposable








.. dn:class:: Microsoft.AspNetCore.Server.Testing.IISDeployer
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Testing.IISDeployer

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Testing.IISDeployer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Testing.IISDeployer.IISDeployer(Microsoft.AspNetCore.Server.Testing.DeploymentParameters, Microsoft.Extensions.Logging.ILogger)
    
        
    
        
        :type startParameters: Microsoft.AspNetCore.Server.Testing.DeploymentParameters
    
        
        :type logger: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
            public IISDeployer(DeploymentParameters startParameters, ILogger logger)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Testing.IISDeployer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Testing.IISDeployer.Deploy()
    
        
        :rtype: Microsoft.AspNetCore.Server.Testing.DeploymentResult
    
        
        .. code-block:: csharp
    
            public override DeploymentResult Deploy()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Testing.IISDeployer.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public override void Dispose()
    

