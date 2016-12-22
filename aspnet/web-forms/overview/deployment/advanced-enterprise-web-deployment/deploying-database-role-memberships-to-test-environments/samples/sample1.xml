USE $(DatabaseName)
GO
CREATE USER [FABRIKAM\TESTWEB1$] FOR LOGIN[FABRIKAM\TESTWEB1$]
GO
USE [ContactManager]
GO
EXEC sp_addrolemember N'db_datareader', N'FABRIKAM\TESTWEB1$'
GO
USE [ContactManager]
GO
EXEC sp_addrolemember N'db_datawriter', N'FABRIKAM\TESTWEB1$'
GO