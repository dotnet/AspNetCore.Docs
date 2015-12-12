

DeploymentResult Class
======================



.. contents:: 
   :local:



Summary
-------

Result of a deployment.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Server.Testing.DeploymentResult`








Syntax
------

.. code-block:: csharp

   public class DeploymentResult





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/hosting/src/Microsoft.AspNet.Server.Testing/Common/DeploymentResult.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Testing.DeploymentResult

Properties
----------

.. dn:class:: Microsoft.AspNet.Server.Testing.DeploymentResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Server.Testing.DeploymentResult.ApplicationBaseUri
    
        
    
        Base Uri of the deployment application.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ApplicationBaseUri { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Testing.DeploymentResult.DeploymentParameters
    
        
    
        Original deployment parameters used for this deployment.
    
        
        :rtype: Microsoft.AspNet.Server.Testing.DeploymentParameters
    
        
        .. code-block:: csharp
    
           public DeploymentParameters DeploymentParameters { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Testing.DeploymentResult.HostShutdownToken
    
        
    
        Triggered when the host process dies or pulled down.
    
        
        :rtype: System.Threading.CancellationToken
    
        
        .. code-block:: csharp
    
           public CancellationToken HostShutdownToken { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Testing.DeploymentResult.WebRootLocation
    
        
    
        The web root folder where the application is hosted. This path can be different from the
        original application source location if published before deployment.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string WebRootLocation { get; set; }
    

