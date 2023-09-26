using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ChangeTokenSample.Utilities
{
    public static class Utilities
    {
        #region snippet1
        public static byte[] ComputeHash(string filePath)
        {
            var runCount = 1;

            while(runCount < 4)
            {
                try
                {
                    if (File.Exists(filePath))
                    {
                        using (var fs = File.OpenRead(filePath))
                        {
                            return System.Security.Cryptography.SHA1
                                .Create().ComputeHash(fs);
                        }
                    }
                    else 
                    {
                        throw new FileNotFoundException();
                    }
                }
                catch (IOException ex)
                {
                    if (runCount == 3)
                    {
                        throw;
                    }

                    Thread.Sleep(TimeSpan.FromSeconds(Math.Pow(2, runCount)));
                    runCount++;
                }
            }

            return new byte[20];
        }
        #endregion

        public static void WriteConsole(string s)
        {
            var consoleString = $"{DateTime.Now} {s}";
            var l = consoleString.Length;

            Console.WriteLine(new string('*', l));
            Console.WriteLine(consoleString);
            Console.WriteLine(new string('*', l));
        }

        #region snippet2
        public async static Task<string> GetFileContent(string filePath)
        {
            var runCount = 1;

            while(runCount < 4)
            {
                try
                {
                    if (File.Exists(filePath))
                    {
                        using (var fileStreamReader = File.OpenText(filePath))
                        {
                            return await fileStreamReader.ReadToEndAsync();
                        }
                    }
                    else 
                    {
                        throw new FileNotFoundException();
                    }
                }
                catch (IOException ex)
                {
                    if (runCount == 3 || ex.HResult != -2147024864)
                    {
                        throw;
                    }
                    else
                    {
                        await Task.Delay(TimeSpan.FromSeconds(Math.Pow(2, runCount)));
                        runCount++;
                    }
                }
            }

            return null;
        }
        #endregion
    }
}
