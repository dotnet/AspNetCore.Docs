using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternSample.Interfaces;
using RepositoryPatternSample.Models;

namespace RepositoryPatternSample.Controllers
{
    #region snippet1
    public class HomeController : Controller
    {
        private readonly ICharacterRepository _characterRepository;

        public HomeController(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public IActionResult Index()
        {
            PopulateCharactersIfNoneExist();

            var characters = _characterRepository.ListAll();

            return View(characters);
        }

        private void PopulateCharactersIfNoneExist()
        {
            if (!_characterRepository.ListAll().Any())
            {
                _characterRepository.Add(new Character("Darth Maul"));
                _characterRepository.Add(new Character("Darth Vader"));
                _characterRepository.Add(new Character("Yoda"));
                _characterRepository.Add(new Character("Mace Windu"));
            }
        }
    }
    #endregion
}
