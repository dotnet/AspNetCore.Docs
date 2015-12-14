.. _directory-structure:

Directory Structure
===================

By `Sourabh Shirhatti`


In ASP.NET 5, the application directory comprises of three sub-directories. This is unlike previous versions of ASP.NET where the entire application lived inside the web root directory.

=======   ===========
Folder    Description     
=======   ===========  
approot   Contains the application, app config files, packages and the DNX runtime.
logs      The default folder for HTTP PlatformHandler to redirect logs to.
wwwroot   Contains the static assets
=======   ===========

The **wwwroot** directory represents the web root of the application. The physical path for the IIS site should point to the web root directory. During deployment of a web site, a developer will require access to the entire application directory.