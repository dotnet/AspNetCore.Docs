Configuration
=============
By :ref:`Steve Smith <configuration-author>` | Originally Published: 6 May 2015

ASP.NET 5 supports a variety of different configuration options. Application configuration data can come from files using built-in support for JSON, XML, and INI formats, as well as from environment variables. Of course, developers can build their own custom configuration providers, as well.

In this article:
	- `Getting and setting configuration settings`_
	- `Using the built-in providers`_
	- `Writing custom providers`_
	
`Download sample from GitHub <https://github.com/aspnet/docs>`_.

Getting and setting configuration settings
------------------------------------------

ASP.NET 5's configuration system has been rearchitected from previous versions of ASP.NET, which relied on ``System.Configuration`` and XML configuration files like ``web.config``. The new `configuration model <https://github.com/aspnet/Configuration>`_ provides streamlined access to key/value based settings that can be retrieved from a variety of sources.

To work with settings in your application, you simply need to add a reference to ``Microsoft.Framework.ConfigurationModel`` and access configuration as shown in this method:


Content goes here. What packages are required? For which formats? What's the minimum necessary to work with config?

Using the built-in providers
----------------------------

Content goes here.

Note that precedence is increasing with order of declaration - last one wins.

Cover JSON, XML, INI as well as in-memory, command-line, and env vars.

Note that Env Vars are a good option to keep secrets out of source control and easily enable production environments (or local dev machines) to use custom connection strings and other config settings independent of files.

Writing custom providers
------------------------

In addition to using the built-in providers, you can also write your own.
Content goes here.


Summary
-------

asdf


.. _configuration-author:

.. include:: /_authors/steve-smith.txt
