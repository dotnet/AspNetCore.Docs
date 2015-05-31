.. _compatibility-replacing-machinekey:

Replacing <machineKey> in ASP.NET 4.5.1
=======================================

As of ASP.NET 4.5, the implementation of the <machineKey> element `is replaceable <http://blogs.msdn.com/b/webdev/archive/2012/10/23/cryptographic-improvements-in-asp-net-4-5-pt-2.aspx>`_. This allows most calls to ASP.NET 4.5+'s cryptographic routines to be routed through a replacement data protection mechanism, including the new data protection system.

Package installation
--------------------

.. note:: 
  The new data protection system can only be installed into an existing ASP.NET application targeting .NET 4.5.1 or higher. Installation will fail if the application targets .NET 4.5 or lower.

To install the new data protection system into an existing ASP.NET 4.5.1+ project, install the package Microsoft.AspNet.DataProtection.SystemWeb. This will instantiate the data protection system using the :ref:`default configuration <data-protection-default-settings>` settings.

When you install the package, it inserts a line into Web.config that tells ASP.NET to use it for `most cryptographic operations <http://blogs.msdn.com/b/webdev/archive/2012/10/23/cryptographic-improvements-in-asp-net-4-5-pt-2.aspx>`_, including forms authentication, view state, and calls to MachineKey.Protect. The line that's inserted reads as follows.

.. code-block:: xml

  <machineKey compatibilityMode="Framework45" dataProtectorType="..." />

.. tip:: 
  You can tell if the new data protection system is active by inspecting fields like __VIEWSTATE, which should begin with "CfDJ8" as in the below example. "CfDJ8" is the base64 representation of the magic "09 F0 C9 F0" header that identifies a payload protected by the data protection system.

.. code-block:: html

  <input type="hidden" name="__VIEWSTATE" id="__VIEWSTATE" value="CfDJ8AWPr2EQPTBGs3L2GCZOpk..." />

Package configuration
---------------------

The data protection system is instantiated with a default zero-setup configuration. However, since by default keys are persisted to the local file system, this won't work for applications which are deployed in a farm. To resolve this, you can provide configuration by creating a type which subclasses DataProtectionStartup and overrides its ConfigureServices method.

Below is an example of a custom data protection startup type which configured both where keys are persisted and how they're encrypted at rest. It also overrides the default app isolation policy by providing its own application name.

.. code-block:: c#

	using System;
	using System.IO;
	using Microsoft.AspNet.DataProtection.SystemWeb;
	using Microsoft.Framework.DependencyInjection;
	 
	namespace DataProtectionDemo
	{
	    public class MyDataProtectionStartup : DataProtectionStartup
	    {
	        public override void ConfigureServices(IServiceCollection services)
	        {
	            services.ConfigureDataProtection(configure =>
	            {
	                configure.SetApplicationName("my-app");
	                configure.PersistKeysToFileSystem(new DirectoryInfo(@"\\server\share\myapp-keys\"));
	                configure.ProtectKeysWithCertificate("thumbprint");
	            });
	        }
	    }
	}
 
.. tip::
  You can also use <machineKey applicationName="my-app" ... /> in place of an explicit call to SetApplicationName. This is a convenience mechanism to avoid forcing the developer to create a DataProtectionStartup-derived type if all he wanted to configure was setting the application name.

To enable this custom configuration, go back to Web.config and look for the <appSettings> element that the package install added to the config file. It will look like the below.

.. code-block:: xml

	<appSettings>
	  <!--
	  If you want to customize the behavior of the ASP.NET 5 Data Protection stack, set the
	  "aspnet:dataProtectionStartupType" switch below to be the fully-qualified name of a
	  type which subclasses Microsoft.AspNet.DataProtection.SystemWeb.DataProtectionStartup.
	  -->
	  <add key="aspnet:dataProtectionStartupType" value="" />
	</appSettings>

Fill in the blank value with the assembly-qualified name of the DataProtectionStartup-derived type you just created. If the name of the application is DataProtectionDemo, this would look like the below.

.. code-block:: xml

	<add key="aspnet:dataProtectionStartupType"
	     value="DataProtectionDemo.MyDataProtectionStartup, DataProtectionDemo" />

The newly-configured data protection system is now ready for use inside the application.