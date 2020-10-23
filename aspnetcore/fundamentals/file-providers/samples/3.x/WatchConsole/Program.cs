using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;

namespace WatchConsole
{
    public class Program
    {
        #region snippet1
        private static readonly string _fileFilter = Path.Combine("TextFiles", "*.txt");

        public static void Main(string[] args)
        {
            Console.WriteLine($"Monitoring for changes with filter '{_fileFilter}' (Ctrl + C to quit)...");

            while (true)
            {
                MainAsync().GetAwaiter().GetResult();
            }
        }

        private static async Task MainAsync()
        {
            var fileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory());
            IChangeToken token = fileProvider.Watch(_fileFilter);
            var tcs = new TaskCompletionSource<object>();

            token.RegisterChangeCallback(state =>
                ((TaskCompletionSource<object>)state).TrySetResult(null), tcs);

            await tcs.Task.ConfigureAwait(false);

            Console.WriteLine("file changed");
        }
        #endregion
    }
}
