<!--
[!INCLUDE[](~/release-notes/aspnetcore-9/includes/delete_keys.md)]
-->

### Data Protection support for deleting keys

Historically, it was intentionally impossible to delete data protection keys because deleting keys makes it impossible to decrypt any data protected by them. Keys are small, so the impact of accumulating many of them is minor.  However, in order to support _very_ long running services, we've added the ability to explicitly delete keys. Generally, only old keys should be deleted. Only delete keys when you can accept the risk of data loss in exchange for storage savings. We recommend data protection keys should ___not___ be deleted.

:::code language="csharp" source="~/security/data-protection/configuration/samples/9/deleteKeys/Program.cs" highlight="11-24":::
