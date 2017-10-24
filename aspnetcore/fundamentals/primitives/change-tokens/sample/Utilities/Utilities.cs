using System.IO;

namespace ChangeTokenSample.Utilities
{
    public static class Utilities
    {
        #region snippet1
        public static byte[] ComputeHash(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (var fs = File.OpenRead(filePath))
                {
                    return System.Security.Cryptography.SHA1.Create().ComputeHash(fs);
                }
            }

            return new byte[20];
        }
        #endregion
    }
}
