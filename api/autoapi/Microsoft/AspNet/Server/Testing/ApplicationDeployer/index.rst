

ApplicationDeployer Class
=========================



.. contents:: 
   :local:



Summary
-------

Abstract base class of all deployers with implementation of some of the common helpers.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Server.Testing.ApplicationDeployer`








Syntax
------

.. code-block:: csharp

   public abstract class ApplicationDeployer : IApplicationDeployer, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/hosting/src/Microsoft.AspNet.Server.Testing/Deployers/ApplicationDeployer.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Testing.ApplicationDeployer

Constructors
------------

.. dn:class:: Microsoft.AspNet.Server.Testing.ApplicationDeployer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.Testing.ApplicationDeployer.ApplicationDeployer(Microsoft.AspNet.Server.Testing.DeploymentParameters, Microsoft.Extensions.Logging.ILogger)
    
        
        
        
        :type deploymentParameters: Microsoft.AspNet.Server.Testing.DeploymentParameters
        
        
        :type logger: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
           public ApplicationDeployer(DeploymentParameters deploymentParameters, ILogger logger)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Testing.ApplicationDeployer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Testing.ApplicationDeployer.AddEnvironmentVariablesToProcess(System.Diagnostics.ProcessStartInfo)
    
        
        
        
        :type startInfo: System.Diagnostics.ProcessStartInfo
    
        
        .. code-block:: csharp
    
           protected void AddEnvironmentVariablesToProcess(ProcessStartInfo startInfo)
    
    .. dn:method:: Microsoft.AspNet.Server.Testing.ApplicationDeployer.CleanPublishedOutput()
    
        
    
        
        .. code-block:: csharp
    
           protected void CleanPublishedOutput()
    
    .. dn:method:: Microsoft.AspNet.Server.Testing.ApplicationDeployer.Deploy()
    
        
        :rtype: Microsoft.AspNet.Server.Testing.DeploymentResult
    
        
        .. code-block:: csharp
    
           public abstract DeploymentResult Deploy()
    
    .. dn:method:: Microsoft.AspNet.Server.Testing.ApplicationDeployer.DnuPublish(System.String)
    
        
        
        
        :type publishRoot: System.String
    
        
        .. code-block:: csharp
    
           protected void DnuPublish(string publishRoot = null)
    
    .. dn:method:: Microsoft.AspNet.Server.Testing.ApplicationDeployer.PopulateChosenRuntimeInformation()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           protected string PopulateChosenRuntimeInformation()
    
    .. dn:method:: Microsoft.AspNet.Server.Testing.ApplicationDeployer.ShutDownIfAnyHostProcess(System.Diagnostics.Process)
    
        
        
        
        :type hostProcess: System.Diagnostics.Process
    
        
        .. code-block:: csharp
    
           protected void ShutDownIfAnyHostProcess(Process hostProcess)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Server.Testing.ApplicationDeployer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Server.Testing.ApplicationDeployer.ChosenRuntimeName
    
        
    
        Examples: dnx-coreclr-win-x64.1.0.0-rc1-15844, dnx-mono.1.0.0-rc1-15844
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           protected string ChosenRuntimeName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Testing.ApplicationDeployer.ChosenRuntimePath
    
        
    
        Example: runtimes/dnx-coreclr-win-x64.1.0.0-rc1-15844/bin
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           protected string ChosenRuntimePath { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Testing.ApplicationDeployer.DeploymentParameters
    
        
        :rtype: Microsoft.AspNet.Server.Testing.DeploymentParameters
    
        
        .. code-block:: csharp
    
           protected DeploymentParameters DeploymentParameters { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Testing.ApplicationDeployer.DnuCommandName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           protected string DnuCommandName { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Testing.ApplicationDeployer.DnxCommandName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           protected string DnxCommandName { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Testing.ApplicationDeployer.Logger
    
        
        :rtype: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
           protected ILogger Logger { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Testing.ApplicationDeployer.OSPrefix
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           protected string OSPrefix { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Testing.ApplicationDeployer.StopWatch
    
        
        :rtype: System.Diagnostics.Stopwatch
    
        
        .. code-block:: csharp
    
           protected Stopwatch StopWatch { get; }
    

