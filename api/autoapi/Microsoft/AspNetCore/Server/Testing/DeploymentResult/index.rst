

DeploymentResult Class
======================






Result of a deployment.


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
* :dn:cls:`Microsoft.AspNetCore.Server.Testing.DeploymentResult`








Syntax
------

.. code-block:: csharp

    public class DeploymentResult








.. dn:class:: Microsoft.AspNetCore.Server.Testing.DeploymentResult
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Testing.DeploymentResult

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Server.Testing.DeploymentResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Server.Testing.DeploymentResult.ApplicationBaseUri
    
        
    
        
        Base Uri of the deployment application.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ApplicationBaseUri { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Testing.DeploymentResult.ContentRoot
    
        
    
        
        The folder where the application is hosted. This path can be different from the 
        original application source location if published before deployment.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ContentRoot { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Testing.DeploymentResult.DeploymentParameters
    
        
    
        
        Original deployment parameters used for this deployment.
    
        
        :rtype: Microsoft.AspNetCore.Server.Testing.DeploymentParameters
    
        
        .. code-block:: csharp
    
            public DeploymentParameters DeploymentParameters { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Testing.DeploymentResult.HostShutdownToken
    
        
    
        
        Triggered when the host process dies or pulled down.
    
        
        :rtype: System.Threading.CancellationToken
    
        
        .. code-block:: csharp
    
            public CancellationToken HostShutdownToken { get; set; }
    

