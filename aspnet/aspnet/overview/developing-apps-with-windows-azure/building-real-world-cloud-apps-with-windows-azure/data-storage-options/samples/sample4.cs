public interface IFixItTaskRepository
{
    Task<List<FixItTask>> FindOpenTasksByOwnerAsync(string userName);
    Task<List<FixItTask>> FindTasksByCreatorAsync(string userName); 

    Task<MyFixIt.Persistence.FixItTask> FindTaskByIdAsync(int id);

    Task CreateAsync(FixItTask taskToAdd);
    Task UpdateAsync(FixItTask taskToSave);
    Task DeleteAsync(int id);
}