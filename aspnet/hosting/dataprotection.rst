.. _dataprotection:

Data Protection
===============

By `Sourabh Shirhatti`_

The ASP.NET 5 data protection stack provides a simple and easy to use cryptographic API a developer can use to protect data, including key management and rotation. This document provides an overview of how to configure Data Protection on your server to enable developers to use data protection.

Create Data Protection Registry Hive
------------------------------------

By default, keys are not persisted outside of the current process. When the process shuts down, all generated keys will be lost. To persist keys for an application hosted in IIS, you must create registry hives for each application pool to store the keys. You should use the `Provisioning PowerShell script <https://github.com/aspnet/DataProtection/blob/dev/Provision-AutoGenKeys.ps1>`_ for each application pool you will be hosting ASP.NET 5 applications under. This script will create a special registry key in the HKLM registry that is ACLed only to the worker process account. Keys are encrypted at rest using DPAPI.

.. note:: A developer can consume the Data Protection APIs to encrypt data at rest using a X.509 certificates.

Machine Wide Policy
-------------------

The data protection system has limited support for setting default machine-wide policy for all applications that consume the data protection APIs. For more information on how to configure the machine wide policy have a look at :ref:`this article <data-protection-configuration-machinewidepolicy>`.


