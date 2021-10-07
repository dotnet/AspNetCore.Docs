namespace TagHelpersBuiltIn.Controllers
{
    #region snippet_SpeakerController
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    public class SpeakerController : Controller
    {
        #region snippet_SpeakerDetailAction
        private List<Speaker> Speakers =
            new List<Speaker>
            {
                new Speaker {SpeakerId = 10},
                new Speaker {SpeakerId = 11},
                new Speaker {SpeakerId = 12}
            };

        [Route("Speaker/{id:int}")]
        public IActionResult Detail(int id) =>
            View(Speakers.FirstOrDefault(a => a.SpeakerId == id));
        #endregion

        [Route("/Speaker/Evaluations", 
               Name = "speakerevals")]
        public IActionResult Evaluations() => View();

        [Route("/Speaker/EvaluationsCurrent",
               Name = "speakerevalscurrent")]
        public IActionResult Evaluations(
            int speakerId,
            bool currentYear) => View();

        public IActionResult Index() => View(Speakers);
    }

    public class Speaker
    {
        public int SpeakerId { get; set; }
    }
    #endregion
}