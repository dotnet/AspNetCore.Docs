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
        private static PhysicalFileProvider _fileProvider = 
            new PhysicalFileProvider(Directory.GetCurrentDirectory());

        public static void Main(string[] args)
        {
            Console.WriteLine("Monitoring quotes.txt for changes (Ctrl-c to quit)...");

            while (true)
            {
                MainAsync().GetAwaiter().GetResult();
            }
        }

        private static async Task MainAsync()
        {
            IChangeToken token = _fileProvider.Watch("quotes.txt");
            var tcs = new TaskCompletionSource<object>();

            token.RegisterChangeCallback(state => 
                ((TaskCompletionSource<object>)state).TrySetResult(null), tcs);

            await tcs.Task.ConfigureAwait(false);

            Console.WriteLine("quotes.txt changed");
        }
        #endregion
    }
}
