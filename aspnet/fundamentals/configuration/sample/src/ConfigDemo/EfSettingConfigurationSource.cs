using ConfigDemo.Models;
using Microsoft.Framework.ConfigurationModel;
using System.Linq;

namespace ConfigDemo
{
    public class EfSettingConfigurationSource : ConfigurationSource
    {

        public EfSettingConfigurationSource(ApplicationDbContext dbContext)
        {
            var settings = dbContext.Settings.FirstOrDefault();
            if(settings == null)
            {
                settings = CreateAndSaveDefaultSettings(dbContext);
            }
            LoadData(settings);
        }

        private void LoadData(Settings settings)
        {
            Data[nameof(settings.TwitterApiKey)] = settings.TwitterApiKey;
            Data[nameof(settings.FacebookApiKey)] = settings.FacebookApiKey;
            Data[nameof(settings.GoogleAnalyticsKey)] = settings.GoogleAnalyticsKey;
        }

        private Settings CreateAndSaveDefaultSettings(ApplicationDbContext dbContext)
        {
            var settings = new Settings()
            {
                TwitterApiKey = "twitterkey",
                FacebookApiKey = "facebookkey",
                GoogleAnalyticsKey = "googlekey"
            };
            dbContext.Settings.Add(settings);
            dbContext.SaveChanges();
            return settings;
        }
    }
}
