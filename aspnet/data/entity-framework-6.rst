Building Web Applications with Entity Framework 6
===========================================================

By `Damien Pontifex <https://github.com/DamienPontifex>`_

.. code-block:: c#
    :linenos:

    [DbConfigurationType(typeof(CodeConfig))] // point to the class that inherit from DbConfiguration
	public class ApplicationDbContext : DbContext
	{
		[...]
	}
	
	public class CodeConfig : DbConfiguration
	{
		public CodeConfig()
		{
			SetDefaultConnectionFactory(new System.Data.Entity.Infrastructure.SqlConnectionFactory());
			SetProviderServices("System.Data.SqlClient",
				System.Data.Entity.SqlServer.SqlProviderServices.Instance);
			}
		}
	}
