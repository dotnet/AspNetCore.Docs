

Microsoft.AspNet.Server.Testing Namespace
=========================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNet/Server/Testing/ApplicationDeployer/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Testing/ApplicationDeployerFactory/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Testing/DeploymentParameters/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Testing/DeploymentResult/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Testing/IApplicationDeployer/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Testing/IISExpressDeployer/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Testing/MonoDeployer/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Testing/RetryHelper/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Testing/RuntimeArchitecture/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Testing/RuntimeFlavor/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Testing/SelfHostDeployer/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Testing/ServerType/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Testing/SkipIfCurrentRuntimeIsCoreClrAttribute/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Testing/SkipIfIISVariationsNotEnabledAttribute/index
   
   
   
   /autoapi/Microsoft/AspNet/Server/Testing/SkipOn32BitOSAttribute/index
   
   











.. dn:namespace:: Microsoft.AspNet.Server.Testing


    .. rubric:: Classes


    class :dn:cls:`Microsoft.AspNet.Server.Testing.ApplicationDeployer`
        Abstract base class of all deployers with implementation of some of the common helpers.


    class :dn:cls:`Microsoft.AspNet.Server.Testing.ApplicationDeployerFactory`
        Factory to create an appropriate deployer based on :any:`Microsoft.AspNet.Server.Testing.DeploymentParameters`\.


    class :dn:cls:`Microsoft.AspNet.Server.Testing.DeploymentParameters`
        Parameters to control application deployment.


    class :dn:cls:`Microsoft.AspNet.Server.Testing.DeploymentResult`
        Result of a deployment.


    class :dn:cls:`Microsoft.AspNet.Server.Testing.IISExpressDeployer`
        Deployment helper for IISExpress.


    class :dn:cls:`Microsoft.AspNet.Server.Testing.MonoDeployer`
        Deployer for Kestrel on Mono.


    class :dn:cls:`Microsoft.AspNet.Server.Testing.RetryHelper`
        


    class :dn:cls:`Microsoft.AspNet.Server.Testing.SelfHostDeployer`
        Deployer for WebListener and Kestrel.


    class :dn:cls:`Microsoft.AspNet.Server.Testing.SkipIfCurrentRuntimeIsCoreClrAttribute`
        Skips a test if the DNX used to run the test is CoreClr.


    class :dn:cls:`Microsoft.AspNet.Server.Testing.SkipIfIISVariationsNotEnabledAttribute`
        Skip test if IIS variations are not enabled. To enable set environment variable
        IIS_VARIATIONS_ENABLED=true for the test process.


    class :dn:cls:`Microsoft.AspNet.Server.Testing.SkipOn32BitOSAttribute`
        Skips a 64 bit test if the current Windows OS is 32-bit.


    .. rubric:: Interfaces


    interface :dn:iface:`Microsoft.AspNet.Server.Testing.IApplicationDeployer`
        Common operations on an application deployer.


    .. rubric:: Enumerations


    enum :dn:enum:`Microsoft.AspNet.Server.Testing.RuntimeArchitecture`
        


    enum :dn:enum:`Microsoft.AspNet.Server.Testing.RuntimeFlavor`
        


    enum :dn:enum:`Microsoft.AspNet.Server.Testing.ServerType`
        


