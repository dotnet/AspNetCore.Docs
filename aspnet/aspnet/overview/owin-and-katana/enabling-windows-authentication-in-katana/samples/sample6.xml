using Microsoft.Owin.Hosting;
using System;

namespace KatanaSelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>("http://localhost:9000"))
            {
                Console.WriteLine("Press Enter to quit.");
                Console.ReadKey();
            }        
        }
    }
}