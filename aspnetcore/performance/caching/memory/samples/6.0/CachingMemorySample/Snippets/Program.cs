namespace CachingMemorySample.Snippets
{
    public static class Program
    {
        public static void AddSingletonMyMemoryCache(string[] args)
        {
            #region snippet_AddSingletonMyMemoryCache
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton<MyMemoryCache>();
            #endregion
        }
    }
}
