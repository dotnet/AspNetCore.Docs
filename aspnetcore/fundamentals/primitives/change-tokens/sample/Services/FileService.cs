using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;
using static ChangeTokenSample.Utilities.Utilities;

namespace ChangeTokenSample
{
    #region snippet1
    public class FileService
    {
        private readonly IMemoryCache _cache;
        private readonly IFileProvider _fileProvider;
        private List<string> _tokens = new List<string>();

        public FileService(IMemoryCache cache, IHostingEnvironment env)
        {
            _cache = cache;
            _fileProvider = env.ContentRootFileProvider;
        }

        public async Task<string> GetFileContents(string fileName)
        {
            // For the purposes of this example, files are stored 
            // in the content root of the app. To obtain the physical
            // path to a file at the content root, use the
            // ContentRootFileProvider on IHostingEnvironment.
            var filePath = _fileProvider.GetFileInfo(fileName).PhysicalPath;
            string fileContent;

            // Try to obtain the file contents from the cache.
            if (_cache.TryGetValue(filePath, out fileContent))
            {
                return fileContent;
            }

            // The cache doesn't have the entry, so obtain the file 
            // contents from the file itself.
            fileContent = await GetFileContent(filePath);

            if (fileContent != null)
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(5));

                // Put the file contents into the cache.
                _cache.Set(filePath, fileContent, cacheEntryOptions);

                // If there's no token for this file, establish a 
                // change token on the file. If the file changes,
                // obtain its content and set the cache.
                if (!_tokens.Contains(filePath))
                {
                    _tokens.Add(filePath);
                    
                    ChangeToken.OnChange(
                        () => _fileProvider.Watch(fileName),
                        async () => 
                        {
                            // Update the file content in the cache.
                            var updatedFileContent = await GetFileContent(filePath);
                            _cache.Set(filePath, updatedFileContent);
                        }
                    );
                }

                return fileContent;
            }

            return string.Empty;
        }
    }
    #endregion
}
