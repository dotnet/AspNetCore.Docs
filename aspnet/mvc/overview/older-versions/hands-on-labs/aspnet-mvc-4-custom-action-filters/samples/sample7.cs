// Clean up Logs Table
MusicStoreEntities storeDB = new MusicStoreEntities();
foreach (var log in 

storeDB.ActionLogs.ToList())
{
   storeDB.ActionLogs.Remove(log);
}

storeDB.SaveChanges();