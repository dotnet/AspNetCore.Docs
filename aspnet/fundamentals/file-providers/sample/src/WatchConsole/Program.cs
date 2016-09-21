using System;
using System.IO;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;

namespace WatchConsole
{
    public class Program
    {
        private IChangeToken token;
        public static PhysicalFileProvider PhysicalFileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory());
        public static void Main(string[] args)
        {
            RegisterCallback(PhysicalFileProvider.Watch("foo.txt"));

            Console.WriteLine("Monitoring foo.txt for changes...");

            Console.ReadLine();
        }

        public static void RegisterCallback(IChangeToken token)
        {
            token.RegisterChangeCallback(state =>
            {
                Console.WriteLine("File system changed.");

                // re-register a new token so we continue to get notifications
                RegisterCallback(PhysicalFileProvider.Watch("foo.txt"));

            }, state: null);
        }
    }
}
