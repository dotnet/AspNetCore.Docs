using ConfigurationSample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace ConfigurationSample
{
    #region snippet
    public class TvShow2Model : PageModel
    {
        private readonly IConfiguration Config;
        public TvShow TvShow { get; private set; }

        public TvShow2Model(IConfiguration config)
        {
            Config = config;
        }

        public ContentResult OnGet()
        {
            var tvShow = new TvShow();
            Config.GetSection("tvshow").Bind(tvShow);
            TvShow = tvShow;

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