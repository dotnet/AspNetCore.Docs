using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace performance_best_practices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    #region snippet1
    public class AsyncBadSearchController : Controller
    {       
        [HttpGet("/search")]
        public async Task<SearchResults> Get(string query)
        {
            var query1 = SearchAsync(SearchEngine.Google, query);
            var query2 = SearchAsync(SearchEngine.Bing, query);
            var query3 = SearchAsync(SearchEngine.DuckDuckGo, query);

            await Task.WhenAll(query1, query2, query3);

            var results1 = await query1;
            var results2 = await query2;
            var results3 = await query3;

            return SearchResults.Combine(results1, results2, results3);
        }       

        private async Task<SearchResults> SearchAsync(SearchEngine engine, string query)
        {
            var searchResults = _searchService.Empty();
            try
            {
                _logger.LogInformation("Starting search query from {path}.", 
                                        HttpContext.Request.Path);
                searchResults = _searchService.Search(engine, query);
                _logger.LogInformation("Finishing search query from {path}.", 
                                        HttpContext.Request.Path);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed query from {path}", 
                                 HttpContext.Request.Path);
            }

            return await searchResults;
        }
        #endregion

        private readonly ILogger<AsyncBadSearchController> _logger;
        public readonly SearchService _searchService;

        public AsyncBadSearchController(ILogger<AsyncBadSearchController> logger,
                                         SearchService searchService)
        {
            _logger = logger;
            _searchService = searchService;
        }

    }

    #region snippet2
    public class AsyncGoodSearchController : Controller
    {       
        [HttpGet("/search")]
        public async Task<SearchResults> Get(string query)
        {
            string path = HttpContext.Request.Path;
            var query1 = SearchAsync(SearchEngine.Google, query,
                                     path);
            var query2 = SearchAsync(SearchEngine.Bing, query, path);
            var query3 = SearchAsync(SearchEngine.DuckDuckGo, query, path);

            await Task.WhenAll(query1, query2, query3);

            var results1 = await query1;
            var results2 = await query2;
            var results3 = await query3;

            return SearchResults.Combine(results1, results2, results3);
        }

        private async Task<SearchResults> SearchAsync(SearchEngine engine, string query,
                                                      string path)
        {
            var searchResults = _searchService.Empty();
            try
            {
                _logger.LogInformation("Starting search query from {path}.",
                                       path);
                searchResults = await _searchService.SearchAsync(engine, query);
                _logger.LogInformation("Finishing search query from {path}.", path);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed query from {path}", path);
            }

            return await searchResults;
        }

        #endregion

        private readonly ILogger<AsyncGoodSearchController> _logger;
        public readonly SearchService _searchService;

        public AsyncGoodSearchController(ILogger<AsyncGoodSearchController> logger,
                                         SearchService searchService)
        {
            _logger = logger;
            _searchService = searchService;
        }
    }

    public class SearchEngine
    {
        public static SearchEngine Bing { get; internal set; }
        public static SearchEngine Google { get; internal set; }
        public static SearchEngine DuckDuckGo { get; internal set; }
    }

    public class SearchResults
    {
        internal static SearchResults Combine(SearchResults results1, SearchResults results2, SearchResults results3)
        {
            throw new NotImplementedException();
        }

        public static implicit operator Task<object>(SearchResults v)
        {
            throw new NotImplementedException();
        }
    }    
}
