/* For SQL Server authentication... */
aspnet_regsql.exe -S server -U user -P password -d database -ed
/* For Windows Authentication... */
aspnet_regsql.exe -S server -E -d database -ed