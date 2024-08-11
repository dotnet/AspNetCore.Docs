<!--
delete_keys.md
-->

### Data Protection support for deleting keys

Historically, it has been intentionally impossible to delete data protection keys because doing so makes it impossible to decrypt any data protected with them (i.e. causing data loss).  Fortunately, keys are quite small, so the impact of accumulating many of them is minor.  However, in order to support _very_ long running services, we've added the ability to explicitly delete (typically, very old) keys. Only delete keys when you can accept the risk of data loss in exchange for storage savings.  Our guidance remains that data protection keys shouldn't be deleted.

:::code language="csharp" source="~/security/data-protection/configuration/samples/9/deleteKeys/Program.cs" id="snippet_1" :::
