.. _directory-structure:

Directory Structure
===================

By `Sourabh Shirhatti`_


In ASP.NET 5, the application directory comprises of three sub-directories. This is unlike previous versions of ASP.NET where the entire application lived inside the web root directory. The recommended permissions for each of the directories are specified in the table below.

=======  ==============  ===========
Folder   Permissions     Description     
=======  ==============  ===========  
approot  Read & Execute  Contains the application, app config files, packages and the runtime.
logs     Read & Write    The default folder for HTTP Platform Handler to redirect logs to.
wwwroot  Read & Execute  Contains the static assets
=======  ==============  ===========

The **wwwroot** directory represents the web root of the application. The physical path for the IIS site should point to the web root directory. While deploying a web site, a developer will need access to the entire application directory.