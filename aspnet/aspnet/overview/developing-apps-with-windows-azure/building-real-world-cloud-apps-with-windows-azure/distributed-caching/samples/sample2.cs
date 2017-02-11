public async Task UpdateAsync(FixItTask taskToSave)
{
   Stopwatch timespan = Stopwatch.StartNew();

   try
   {
      cache.Remove(taskToSave.FixItTaskId.ToString());
      db.Entry(taskToSave).State = EntityState.Modified;
      await db.SaveChangesAsync();

      timespan.Stop();
      log.TraceApi("SQL Database", "FixItTaskRepository.UpdateAsync", timespan.Elapsed, "taskToSave={0}", taskToSave);
   }
   catch (Exception e)
   {
      log.Error(e, "Error in FixItTaskRepository.UpdateAsync(taskToSave={0})", taskToSave);
   }
}