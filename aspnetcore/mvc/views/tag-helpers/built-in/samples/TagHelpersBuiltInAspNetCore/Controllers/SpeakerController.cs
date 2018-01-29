namespace TagHelpersBuiltInAspNetCore.Controllers
{
    #region snippet_SpeakerController
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;

    public class SpeakerController : Controller
    {
        private List<ModelData> Speakers =
            new List<ModelData>
            {
                new ModelData {SpeakerId = 10},
                new ModelData {SpeakerId = 11},
                new ModelData {SpeakerId = 12}
            };

        [Route("Speaker/{id:int}")]
        public IActionResult Detail(int id) =>
            View(Speakers.FirstOrDefault(a => a.SpeakerId == id));

        [Route("/Speaker/Evaluations", 
               Name = "speakerevals")]
        public IActionResult Evaluations() => View();

        public IActionResult Index() => View(Speakers);
    }

    public class ModelData
    {
        public int SpeakerId { get; set; }
    }
    #endregion
}