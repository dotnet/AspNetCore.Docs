

DeploymentParameters Class
==========================



.. contents:: 
   :local:



Summary
-------

Parameters to control application deployment.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Server.Testing.DeploymentParameters`








Syntax
------

.. code-block:: csharp

   public class DeploymentParameters





GitHub
------

`View on GitHub <https://github.com/aspnet/hosting/blob/master/src/Microsoft.AspNet.Server.Testing/Common/DeploymentParameters.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Testing.DeploymentParameters

Constructors
------------

.. dn:class:: Microsoft.AspNet.Server.Testing.DeploymentParameters
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.Testing.DeploymentParameters.DeploymentParameters(System.String, Microsoft.AspNet.Server.Testing.ServerType, Microsoft.AspNet.Server.Testing.RuntimeFlavor, Microsoft.AspNet.Server.Testing.RuntimeArchitecture)
    
        
    
        Creates an instance of :any:`Microsoft.AspNet.Server.Testing.DeploymentParameters`\.
    
        
        
        
        :param applicationPath: Source code location of the target location to be deployed.
        
        :type applicationPath: System.String
        
        
        :param serverType: Where to be deployed on.
        
        :type serverType: Microsoft.AspNet.Server.Testing.ServerType
        
        
        :param runtimeFlavor: Flavor of the clr to run against.
        
        :type runtimeFlavor: Microsoft.AspNet.Server.Testing.RuntimeFlavor
        
        
        :param runtimeArchitecture: Architecture of the DNX to be used.
        
        :type runtimeArchitecture: Microsoft.AspNet.Server.Testing.RuntimeArchitecture
    
        
        .. code-block:: csharp
    
           public DeploymentParameters(string applicationPath, ServerType serverType, RuntimeFlavor runtimeFlavor, RuntimeArchitecture runtimeArchitecture)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Testing.DeploymentParameters
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Testing.DeploymentParameters.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string ToString()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Server.Testing.DeploymentParameters
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Server.Testing.DeploymentParameters.ApplicationBaseUriHint
    
        
    
        Suggested base url for the deployed application. The final deployed url could be
        different than this. Use :dn:prop:`Microsoft.AspNet.Server.Testing.DeploymentResult.ApplicationBaseUri` for the
        deployed url.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ApplicationBaseUriHint { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Testing.DeploymentParameters.ApplicationHostConfigLocation
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ApplicationHostConfigLocation { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Testing.DeploymentParameters.ApplicationHostConfigTemplateContent
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ApplicationHostConfigTemplateContent { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Testing.DeploymentParameters.ApplicationPath
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ApplicationPath { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Testing.DeploymentParameters.Command
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Command { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Testing.DeploymentParameters.DnxRuntime
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string DnxRuntime { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Testing.DeploymentParameters.EnvironmentName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string EnvironmentName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Testing.DeploymentParameters.EnvironmentVariables
    
        
    
        Environment variables to be set before starting the host.
        Not applicable for IIS Scenarios.
    
        
        :rtype: System.Collections.Generic.List{System.Collections.Generic.KeyValuePair{System.String,System.String}}
    
        
        .. code-block:: csharp
    
           public List<KeyValuePair<string, string>> EnvironmentVariables { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Testing.DeploymentParameters.PublishApplicationBeforeDeployment
    
        
    
        To publish the application before deployment.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool PublishApplicationBeforeDeployment { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Testing.DeploymentParameters.PublishWithNoSource
    
        
    
        Passes the --no-source option when publishing.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool PublishWithNoSource { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Testing.DeploymentParameters.PublishedApplicationRootPath
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string PublishedApplicationRootPath { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Testing.DeploymentParameters.RuntimeArchitecture
    
        
        :rtype: Microsoft.AspNet.Server.Testing.RuntimeArchitecture
    
        
        .. code-block:: csharp
    
           public RuntimeArchitecture RuntimeArchitecture { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Testing.DeploymentParameters.RuntimeFlavor
    
        
        :rtype: Microsoft.AspNet.Server.Testing.RuntimeFlavor
    
        
        .. code-block:: csharp
    
           public RuntimeFlavor RuntimeFlavor { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Testing.DeploymentParameters.ServerType
    
        
        :rtype: Microsoft.AspNet.Server.Testing.ServerType
    
        
        .. code-block:: csharp
    
           public ServerType ServerType { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Testing.DeploymentParameters.SiteName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string SiteName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Testing.DeploymentParameters.UserAdditionalCleanup
    
        
    
        For any application level cleanup to be invoked after performing host cleanup.
    
        
        :rtype: System.Action{Microsoft.AspNet.Server.Testing.DeploymentParameters}
    
        
        .. code-block:: csharp
    
           public Action<DeploymentParameters> UserAdditionalCleanup { get; set; }
    

