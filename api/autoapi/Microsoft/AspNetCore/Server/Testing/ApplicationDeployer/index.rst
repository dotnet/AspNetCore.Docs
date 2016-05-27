

ApplicationDeployer Class
=========================






Abstract base class of all deployers with implementation of some of the common helpers.


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








Syntax
------

.. code-block:: csharp

    public abstract class ApplicationDeployer : IApplicationDeployer, IDisposable








.. dn:class:: Microsoft.AspNetCore.Server.Testing.ApplicationDeployer
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Testing.ApplicationDeployer

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Server.Testing.ApplicationDeployer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Server.Testing.ApplicationDeployer.DeploymentParameters
    
        
        :rtype: Microsoft.AspNetCore.Server.Testing.DeploymentParameters
    
        
        .. code-block:: csharp
    
            protected DeploymentParameters DeploymentParameters
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Testing.ApplicationDeployer.Logger
    
        
        :rtype: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
            protected ILogger Logger
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Testing.ApplicationDeployer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Testing.ApplicationDeployer.ApplicationDeployer(Microsoft.AspNetCore.Server.Testing.DeploymentParameters, Microsoft.Extensions.Logging.ILogger)
    
        
    
        
        :type deploymentParameters: Microsoft.AspNetCore.Server.Testing.DeploymentParameters
    
        
        :type logger: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
            public ApplicationDeployer(DeploymentParameters deploymentParameters, ILogger logger)
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Server.Testing.ApplicationDeployer
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Server.Testing.ApplicationDeployer.DotnetArgumentSeparator
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static readonly string DotnetArgumentSeparator
    
    .. dn:field:: Microsoft.AspNetCore.Server.Testing.ApplicationDeployer.DotnetCommandName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static readonly string DotnetCommandName
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Testing.ApplicationDeployer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Testing.ApplicationDeployer.AddEnvironmentVariablesToProcess(System.Diagnostics.ProcessStartInfo)
    
        
    
        
        :type startInfo: System.Diagnostics.ProcessStartInfo
    
        
        .. code-block:: csharp
    
            protected void AddEnvironmentVariablesToProcess(ProcessStartInfo startInfo)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Testing.ApplicationDeployer.CleanPublishedOutput()
    
        
    
        
        .. code-block:: csharp
    
            protected void CleanPublishedOutput()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Testing.ApplicationDeployer.Deploy()
    
        
        :rtype: Microsoft.AspNetCore.Server.Testing.DeploymentResult
    
        
        .. code-block:: csharp
    
            public abstract DeploymentResult Deploy()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Testing.ApplicationDeployer.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public abstract void Dispose()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Testing.ApplicationDeployer.DotnetPublish(System.String)
    
        
    
        
        :type publishRoot: System.String
    
        
        .. code-block:: csharp
    
            protected void DotnetPublish(string publishRoot = null)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Testing.ApplicationDeployer.GetOSPrefix()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            protected static string GetOSPrefix()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Testing.ApplicationDeployer.InvokeUserApplicationCleanup()
    
        
    
        
        .. code-block:: csharp
    
            protected void InvokeUserApplicationCleanup()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Testing.ApplicationDeployer.SetEnvironmentVariable(System.Collections.Specialized.StringDictionary, System.String, System.String)
    
        
    
        
        :type environment: System.Collections.Specialized.StringDictionary
    
        
        :type name: System.String
    
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
            protected void SetEnvironmentVariable(StringDictionary environment, string name, string value)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Testing.ApplicationDeployer.ShutDownIfAnyHostProcess(System.Diagnostics.Process)
    
        
    
        
        :type hostProcess: System.Diagnostics.Process
    
        
        .. code-block:: csharp
    
            protected void ShutDownIfAnyHostProcess(Process hostProcess)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Testing.ApplicationDeployer.StartTimer()
    
        
    
        
        .. code-block:: csharp
    
            protected void StartTimer()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Testing.ApplicationDeployer.StopTimer()
    
        
    
        
        .. code-block:: csharp
    
            protected void StopTimer()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Testing.ApplicationDeployer.TriggerHostShutdown(System.Threading.CancellationTokenSource)
    
        
    
        
        :type hostShutdownSource: System.Threading.CancellationTokenSource
    
        
        .. code-block:: csharp
    
            protected void TriggerHostShutdown(CancellationTokenSource hostShutdownSource)
    

