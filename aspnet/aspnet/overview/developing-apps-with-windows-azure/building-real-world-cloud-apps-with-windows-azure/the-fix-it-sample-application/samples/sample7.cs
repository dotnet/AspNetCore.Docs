catch (Exception e)
{
    log.Error(e, "Error in FixItTaskRepository.FindTasksByCreatorAsync(creater={0})", creator);
    throw;
}