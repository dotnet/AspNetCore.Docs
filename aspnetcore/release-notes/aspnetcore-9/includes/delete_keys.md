### Data Protection support for deleting keys

Prior to .NET 9, data protection keys were ___not___ deletable by design, to prevent data loss. Deleting a key renders its protected data irretrievable. Given their small size, the accumulation of these keys generally posed minimal impact. However, to accommodate extremely long-running services, we have introduced the option to delete keys. Generally, only old keys should be deleted. Only delete keys when you can accept the risk of data loss in exchange for storage savings. We recommend data protection keys should ___not___ be deleted.

:::code language="csharp" source="~/security/data-protection/configuration/samples/9/deleteKeys/Program.cs" :::
