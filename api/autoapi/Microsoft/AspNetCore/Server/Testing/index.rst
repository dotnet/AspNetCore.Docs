

Microsoft.AspNetCore.Server.Testing Namespace
=============================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/Server/Testing/ApplicationDeployer/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Server/Testing/ApplicationDeployerFactory/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Server/Testing/ApplicationType/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Server/Testing/DeploymentParameters/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Server/Testing/DeploymentResult/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Server/Testing/IApplicationDeployer/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Server/Testing/IISDeployer/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Server/Testing/IISExpressDeployer/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Server/Testing/NginxDeployer/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Server/Testing/RemoteWindowsDeployer/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Server/Testing/RemoteWindowsDeploymentParameters/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Server/Testing/RetryHelper/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Server/Testing/RuntimeArchitecture/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Server/Testing/RuntimeFlavor/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Server/Testing/SelfHostDeployer/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Server/Testing/ServerType/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Server/Testing/SkipIfCurrentRuntimeIsCoreClrAttribute/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Server/Testing/SkipIfEnvironmentVariableNotEnabledAttribute/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Server/Testing/SkipOn32BitOSAttribute/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.Server.Testing


    .. rubric:: Interfaces


    interface :dn:iface:`IApplicationDeployer`
        .. object: type=interface name=Microsoft.AspNetCore.Server.Testing.IApplicationDeployer

        
        Common operations on an application deployer.


    .. rubric:: Classes


    class :dn:cls:`ApplicationDeployer`
        .. object: type=class name=Microsoft.AspNetCore.Server.Testing.ApplicationDeployer

        
        Abstract base class of all deployers with implementation of some of the common helpers.


    class :dn:cls:`ApplicationDeployerFactory`
        .. object: type=class name=Microsoft.AspNetCore.Server.Testing.ApplicationDeployerFactory

        
        Factory to create an appropriate deployer based on :any:`Microsoft.AspNetCore.Server.Testing.DeploymentParameters`\.


    class :dn:cls:`DeploymentParameters`
        .. object: type=class name=Microsoft.AspNetCore.Server.Testing.DeploymentParameters

        
        Parameters to control application deployment.


    class :dn:cls:`DeploymentResult`
        .. object: type=class name=Microsoft.AspNetCore.Server.Testing.DeploymentResult

        
        Result of a deployment.


    class :dn:cls:`IISDeployer`
        .. object: type=class name=Microsoft.AspNetCore.Server.Testing.IISDeployer

        
        Deployer for IIS.


    class :dn:cls:`IISExpressDeployer`
        .. object: type=class name=Microsoft.AspNetCore.Server.Testing.IISExpressDeployer

        
        Deployment helper for IISExpress.


    class :dn:cls:`NginxDeployer`
        .. object: type=class name=Microsoft.AspNetCore.Server.Testing.NginxDeployer

        
        Deployer for Kestrel on Nginx.


    class :dn:cls:`RemoteWindowsDeployer`
        .. object: type=class name=Microsoft.AspNetCore.Server.Testing.RemoteWindowsDeployer

        


    class :dn:cls:`RemoteWindowsDeploymentParameters`
        .. object: type=class name=Microsoft.AspNetCore.Server.Testing.RemoteWindowsDeploymentParameters

        


    class :dn:cls:`RetryHelper`
        .. object: type=class name=Microsoft.AspNetCore.Server.Testing.RetryHelper

        


    class :dn:cls:`SelfHostDeployer`
        .. object: type=class name=Microsoft.AspNetCore.Server.Testing.SelfHostDeployer

        
        Deployer for WebListener and Kestrel.


    class :dn:cls:`SkipIfCurrentRuntimeIsCoreClrAttribute`
        .. object: type=class name=Microsoft.AspNetCore.Server.Testing.SkipIfCurrentRuntimeIsCoreClrAttribute

        
        Skips a test if the runtime used to run the test is CoreClr.


    class :dn:cls:`SkipIfEnvironmentVariableNotEnabledAttribute`
        .. object: type=class name=Microsoft.AspNetCore.Server.Testing.SkipIfEnvironmentVariableNotEnabledAttribute

        
        Skip test if a given environment variable is not enabled. To enable the test, set environment variable 
        to "true" for the test process.


    class :dn:cls:`SkipOn32BitOSAttribute`
        .. object: type=class name=Microsoft.AspNetCore.Server.Testing.SkipOn32BitOSAttribute

        
        Skips a 64 bit test if the current Windows OS is 32-bit.


    .. rubric:: Enumerations


    enum :dn:enum:`ApplicationType`
        .. object: type=enum name=Microsoft.AspNetCore.Server.Testing.ApplicationType

        


    enum :dn:enum:`RuntimeArchitecture`
        .. object: type=enum name=Microsoft.AspNetCore.Server.Testing.RuntimeArchitecture

        


    enum :dn:enum:`RuntimeFlavor`
        .. object: type=enum name=Microsoft.AspNetCore.Server.Testing.RuntimeFlavor

        


    enum :dn:enum:`ServerType`
        .. object: type=enum name=Microsoft.AspNetCore.Server.Testing.ServerType

        


