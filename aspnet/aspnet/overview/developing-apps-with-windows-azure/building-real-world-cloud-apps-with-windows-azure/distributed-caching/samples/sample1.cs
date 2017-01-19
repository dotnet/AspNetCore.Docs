public async Task<FixItTask> FindTaskByIdAsync(int id)
 {
    FixItTask fixItTask = null;
    Stopwatch timespan = Stopwatch.StartNew();
    string hitMiss = "Hit";

    try
    {
       fixItTask = (FixItTask)cache.Get(id.ToString());
       if (fixItTask == null)
       {
          fixItTask = await db.FixItTasks.FindAsync(id);
          cache.Put(id.ToString(), fixItTask);
          hitMiss = "Miss";
       }

       timespan.Stop();
       log.TraceApi("SQL Database", "FixItTaskRepository.FindTaskByIdAsync", timespan.Elapsed, 
                    "cache {0}, id={1}", hitMiss, id);
    }
    catch (Exception e)
    {
       log.Error(e, "Error in FixItTaskRepository.FindTaskByIdAsynx(id={0})", id);
    }

    return fixItTask;
 }