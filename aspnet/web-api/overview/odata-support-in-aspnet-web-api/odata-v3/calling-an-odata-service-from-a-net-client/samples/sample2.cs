using System;
using System.Data.Services.Client;
using System.Linq;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri uri = new Uri("http://localhost:1234/odata/");
            var container = new ProductService.Container(uri);

            // ...
        }
    }
}
