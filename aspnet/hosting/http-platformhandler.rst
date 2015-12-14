.. _http-platformhandler:

HTTP PlatformHandler
====================

By `Sourabh Shirhatti`

In ASP.NET 5 the web application is hosted by an external process outside of IIS. The HTTP PlatformHandler is an IIS 8.0+ module which is responsible for process management of http listeners and to proxy requests to processes that it manages. This document provides an overview of how to configure the HTTP PlatformHandler module for shared ASP.NET 5 hosting.

Installing the HTTP PlatformHandler
-----------------------------------

To get started with hosting with ASP.NET 5 applications you will need to install the HTTP PlatformHandler version 1.2 or higher on an IIS 8 or higher server. Download links are below

* `64 bit HTTP PlatformHandler <http://go.microsoft.com/fwlink/?LinkID=690721>`_ 
* `32 bit HTTP PlatformHandler <http://go.microsoft.com/fwlink/?LinkId=690722>`_ 


Configuring the HTTP PlatformHandler
------------------------------------

The HttpPlatformHandler is configured via a site or applications web.config file and has its own configuration section within **system.webServer - httpPlatform**. The `HTTP PlatformHandler configuration reference whitepaper <http://www.iis.net/learn/extensions/httpplatformhandler/httpplatformhandler-configuration-reference>`_ describes in detail how to modify Configuration Attributes for the HTTP PlatformHandler module.

Environment Variables
---------------------

The IIS PlatformHandler module allows you specify environment variables for the process specified in the **processPath** setting by specifying them in **environmentVariables** child attribute to the **httpPlatform** attribute. The example below illustrates how you would use it.


.. code:: xml

    <configuration>
      <system.webServer>
        <handlers>
          <remove name="ExtensionlessUrlHandler-Integrated-4.0" />
          <remove name="OPTIONSVerbHandler" />
          <remove name="TRACEVerbHandler" />
          <add name="httpplatformhandler"
                path="*" verb="*"
                modules="httpPlatformHandler"
                resourceType="Unspecified" />
        </handlers>
        <httpPlatform processPath="..\approot\web.cmd"
                arguments=""
                stdoutLogEnabled="false"
                stdoutLogFile="..\logs\stdout.log"
                startupTimeLimit="3600">
          <environmentVariables>
            <environmentVariable name="DEMO" value="demo_value" />
          </environmentVariables>
        </httpPlatform>
      </system.webServer>
    </configuration>