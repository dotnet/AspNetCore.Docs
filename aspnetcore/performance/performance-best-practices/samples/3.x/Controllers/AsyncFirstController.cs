/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace performance_best_practices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

#if BAD
    #region snippet1
    public class AsyncFirstController : Controller
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
            var searchResults = SearchResults.Empty;
            try
            {
                _logger.LogInformation("Starting search query from {path}.", HttpContext.Request.Path);
                searchResults = await _searchService.SearchAsync(engine, query);
                _logger.LogInformation("Finishing search query from {path}.", HttpContext.Request.Path);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed query from {path}", HttpContext.Request.Path);
            }

            return searchResults;
        }
    }
    #endregion
#else
    #region snippet2
    public class AsyncFirstController : Controller
    {
        [HttpGet("/search")]
        public async Task<SearchResults> Get(string query)
        {
            string path = HttpContext.Request.Path;
            var query1 = SearchAsync(SearchEngine.Google, query, path);
            var query2 = SearchAsync(SearchEngine.Bing, query, path);
            var query3 = SearchAsync(SearchEngine.DuckDuckGo, query, path);

            await Task.WhenAll(query1, query2, query3);

            var results1 = await query1;
            var results2 = await query2;
            var results3 = await query3;

            return SearchResults.Combine(results1, results2, results3);
        }

        private async Task<SearchResults> SearchAsync(SearchEngine engine, string query, string path)
        {
            var searchResults = SearchResults.Empty;
            try
            {
                _logger.LogInformation("Starting search query from {path}.", path);
                searchResults = await _searchService.SearchAsync(engine, query);
                _logger.LogInformation("Finishing search query from {path}.", path);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed query from {path}", path);
            }

            return searchResults;
        }
    }
    #endregion
#endif
}
*/