using Microsoft.AspNet.Mvc;
using Microsoft.Framework.ConfigurationModel;
using ConfigDemo.Models;

namespace ConfigDemo.Controllers
{
    public class SettingsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public SettingsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var config = new Configuration();
            config.Add(new EfSettingConfigurationSource(_dbContext));

            ViewBag.TwitterApiKey = config["TwitterApiKey"];
            ViewBag.FacebookApiKey = config["FacebookApiKey"];
            ViewBag.GoogleAnalyticsKey = config["GoogleAnalyticsKey"];

            return View();
        }
    }
}
