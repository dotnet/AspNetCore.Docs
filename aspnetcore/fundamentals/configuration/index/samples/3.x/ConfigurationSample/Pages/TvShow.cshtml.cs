using ConfigurationSample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace ConfigurationSample
{
    #region snippet
    public class TvShowModel : PageModel
    {
        private readonly IConfiguration Config;
        public TvShow TvShow { get; private set; }

        public TvShowModel(IConfiguration config)
        {
            Config = config;
        }

        public ContentResult OnGet()
        {

            TvShow = Config.GetSection("tvshow").Get<TvShow>();

            return Content(
                        $"Series:   {TvShow.Metadata.Series}   \n" +
                        $"Title:    {TvShow.Metadata.Title}    \n" +
                        $"AirDate:  {TvShow.Metadata.AirDate}  \n" +
                        $"Episodes: {TvShow.Metadata.Episodes} \n" +
                        $"Actors:   {TvShow.Actors.Names}"         );
        }
    }
    #endregion
}