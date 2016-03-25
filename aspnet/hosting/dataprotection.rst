.. _dataprotection:

Data Protection
===============

By `Sourabh Shirhatti`_

The ASP.NET Core data protection stack provides a simple and easy to use cryptographic API a developer can use to protect data, including key management and rotation. This document provides an overview of how to configure Data Protection on your server to enable developers to use data protection.

Configuring Data Protection
---------------------------

.. WARNING::
  Data Protection is used by various ASP.NET middleware, including those used in authentication. The default behavior on IIS hosted web sites is to store keys in memory and discard them when the process restarts. This behavior will have side effects, for example, discarding keys invalidate any cookies written by the cookie authentication and users will have to login again.

To automatically persist keys for an application hosted in IIS, you must create registry hives for each application pool. Use the `Provisioning PowerShell script <https://github.com/aspnet/DataProtection/blob/dev/Provision-AutoGenKeys.ps1>`_ for each application pool you will be hosting ASP.NET Core applications under. This script will create a special registry key in the HKLM registry that is ACLed only to the worker process account. Keys are encrypted at rest using DPAPI.

.. note:: A developer can configure their applications Data Protection APIs to store data on the file system. Data Protection can be configured by the developer to use a UNC share to store keys, to enable load balancing. A hoster should ensure that the file permissions for such a share are limited to the Windows account the application runs as. In addition a developer may choose to protect keys at rest using an X509 certificate. A hoster may wish to consider a mechanism to allow users to upload certificates, place them into the user's trusted certificate store and ensure they are available on all machines the users application will run on.

Machine Wide Policy
-------------------

The data protection system has limited support for setting default :ref:`machine-wide policy <data-protection-configuration-machinewidepolicy>` for all applications that consume the data protection APIs. See the :doc:`data protection </security/data-protection/index>` documentation for more details.


