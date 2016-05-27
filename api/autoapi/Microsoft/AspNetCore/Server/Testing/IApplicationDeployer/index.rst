

IApplicationDeployer Interface
==============================






Common operations on an application deployer.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Testing`
Assemblies
    * Microsoft.AspNetCore.Server.Testing

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IApplicationDeployer : IDisposable








.. dn:interface:: Microsoft.AspNetCore.Server.Testing.IApplicationDeployer
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Server.Testing.IApplicationDeployer

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Server.Testing.IApplicationDeployer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Testing.IApplicationDeployer.Deploy()
    
        
    
        
        Deploys the application to the target with specified :any:`Microsoft.AspNetCore.Server.Testing.DeploymentParameters`\.
    
        
        :rtype: Microsoft.AspNetCore.Server.Testing.DeploymentResult
    
        
        .. code-block:: csharp
    
            DeploymentResult Deploy()
    

