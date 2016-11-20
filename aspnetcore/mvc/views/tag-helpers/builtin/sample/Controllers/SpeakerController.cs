using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace TagHelpersLocal.Web.Controllers
{
    public class SpeakerController : Controller
    {
        public List<ModelData> Speakers = new List<ModelData>
        {
            new ModelData {SpeakerId = 10},
            new ModelData {SpeakerId = 11},
            new ModelData {SpeakerId = 12}
        };

        [Route("Speaker/{id:int}")]
        public IActionResult Detail(int id)
        {
            return View(Speakers.FirstOrDefault(a => a.SpeakerId == id));
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(Speakers);
        }
    }

    public class ModelData
    {
        public int SpeakerId { get; set; }
    }
}