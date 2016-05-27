

DeploymentParameters Class
==========================






Parameters to control application deployment.


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








Syntax
------

.. code-block:: csharp

    public class DeploymentParameters








.. dn:class:: Microsoft.AspNetCore.Server.Testing.DeploymentParameters
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Testing.DeploymentParameters

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Server.Testing.DeploymentParameters
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Server.Testing.DeploymentParameters.ApplicationBaseUriHint
    
        
    
        
        Suggested base url for the deployed application. The final deployed url could be
        different than this. Use :dn:prop:`Microsoft.AspNetCore.Server.Testing.DeploymentResult.ApplicationBaseUri` for the 
        deployed url.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ApplicationBaseUriHint
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Testing.DeploymentParameters.ApplicationPath
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ApplicationPath
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Testing.DeploymentParameters.ApplicationType
    
        
        :rtype: Microsoft.AspNetCore.Server.Testing.ApplicationType
    
        
        .. code-block:: csharp
    
            public ApplicationType ApplicationType
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Testing.DeploymentParameters.EnvironmentName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string EnvironmentName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Testing.DeploymentParameters.EnvironmentVariables
    
        
    
        
        Environment variables to be set before starting the host.
        Not applicable for IIS Scenarios.
    
        
        :rtype: System.Collections.Generic.List<System.Collections.Generic.List`1>{System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, System.String<System.String>}}
    
        
        .. code-block:: csharp
    
            public List<KeyValuePair<string, string>> EnvironmentVariables
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Testing.DeploymentParameters.PublishApplicationBeforeDeployment
    
        
    
        
        To publish the application before deployment.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool PublishApplicationBeforeDeployment
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Testing.DeploymentParameters.PublishedApplicationRootPath
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string PublishedApplicationRootPath
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Testing.DeploymentParameters.RuntimeArchitecture
    
        
        :rtype: Microsoft.AspNetCore.Server.Testing.RuntimeArchitecture
    
        
        .. code-block:: csharp
    
            public RuntimeArchitecture RuntimeArchitecture
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Testing.DeploymentParameters.RuntimeFlavor
    
        
        :rtype: Microsoft.AspNetCore.Server.Testing.RuntimeFlavor
    
        
        .. code-block:: csharp
    
            public RuntimeFlavor RuntimeFlavor
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Testing.DeploymentParameters.ServerConfigLocation
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ServerConfigLocation
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Testing.DeploymentParameters.ServerConfigTemplateContent
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ServerConfigTemplateContent
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Testing.DeploymentParameters.ServerType
    
        
        :rtype: Microsoft.AspNetCore.Server.Testing.ServerType
    
        
        .. code-block:: csharp
    
            public ServerType ServerType
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Testing.DeploymentParameters.SiteName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string SiteName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Testing.DeploymentParameters.TargetFramework
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string TargetFramework
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Testing.DeploymentParameters.UserAdditionalCleanup
    
        
    
        
        For any application level cleanup to be invoked after performing host cleanup.
    
        
        :rtype: System.Action<System.Action`1>{Microsoft.AspNetCore.Server.Testing.DeploymentParameters<Microsoft.AspNetCore.Server.Testing.DeploymentParameters>}
    
        
        .. code-block:: csharp
    
            public Action<DeploymentParameters> UserAdditionalCleanup
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Testing.DeploymentParameters
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Testing.DeploymentParameters.DeploymentParameters(System.String, Microsoft.AspNetCore.Server.Testing.ServerType, Microsoft.AspNetCore.Server.Testing.RuntimeFlavor, Microsoft.AspNetCore.Server.Testing.RuntimeArchitecture)
    
        
    
        
        Creates an instance of :any:`Microsoft.AspNetCore.Server.Testing.DeploymentParameters`\.
    
        
    
        
        :param applicationPath: Source code location of the target location to be deployed.
        
        :type applicationPath: System.String
    
        
        :param serverType: Where to be deployed on.
        
        :type serverType: Microsoft.AspNetCore.Server.Testing.ServerType
    
        
        :param runtimeFlavor: Flavor of the clr to run against.
        
        :type runtimeFlavor: Microsoft.AspNetCore.Server.Testing.RuntimeFlavor
    
        
        :param runtimeArchitecture: Architecture of the runtime to be used.
        
        :type runtimeArchitecture: Microsoft.AspNetCore.Server.Testing.RuntimeArchitecture
    
        
        .. code-block:: csharp
    
            public DeploymentParameters(string applicationPath, ServerType serverType, RuntimeFlavor runtimeFlavor, RuntimeArchitecture runtimeArchitecture)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Testing.DeploymentParameters
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Testing.DeploymentParameters.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ToString()
    

