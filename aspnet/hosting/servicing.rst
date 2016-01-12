.. _hosting-servicing:

Servicing
=========

By `Sourabh Shirhatti`

ASP.NET 5 supports servicing of runtime components (DNX) and packages through Microsoft Update, which will deliver updates to patch any vulnerabilities when they are discovered. This document provides an overview of how to setup your Windows Server correctly to receive updates.

Breadcrumbs Directory
---------------------

All serviceable assemblies will leave a breadcrumb in the ``BreadcrumbStore`` Directory. At the time of servicing Microsoft Update looks in this directory to figure out which assemblies are used on the server and require patching. The ``BreadcrumbStore`` directory must be protected by ACLs to prevent rogue applications from deleting entries from this directory. To create the ``BreadcrumbStore`` directory and set the ACLs securely, run the following powershell script below in an elevated prompt: to create the ``BreadcrumbStore`` directory and set ACLs on it correctly.


.. code-block:: powershell

    $breadcrumbFolder = $env:ALLUSERSPROFILE + '\Microsoft DNX\BreadcrumbStore'
    New-Item -Force -Path $breadcrumbFolder -ItemType "Directory"
    $ACL = Get-Acl -Path $breadcrumbFolder
    # Clear any permissions
    $ACL.SetAccessRuleProtection($true, $false)
    # Set new permissions
    $ACL.SetSecurityDescriptorSddlForm("O:SYG:SYD:P(A;OICI;CCDCSWWPLORC;;;WD)(A;OICI;FA;;;SY)(A;OICI;FA;;;BA)")
    Set-Acl -Path $breadcrumbFolder -AclObject $ACL

Servicing Directory
-------------------

At the time of loading an asset, DNX will check against an index file in the ``Servicing`` directory to determine whether it should load a patched version instead of what it would normally load. The index file is updated by Microsoft Update during servicing to point to the location of the patched version of the asset on disk, which will reside in the ``Servicing`` directory. The index file defaults to ``%PROGRAMFILES%\Microsoft DNX\Servicing``, but you can change this by setting the ``DNX_SERVICING`` environment variable to a different path.
