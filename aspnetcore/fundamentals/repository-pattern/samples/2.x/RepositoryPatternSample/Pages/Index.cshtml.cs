using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RepositoryPatternSample.Interfaces;
using RepositoryPatternSample.Models;

namespace RepositoryPatternSample.Pages
{
    #region snippet1
    public class IndexModel : PageModel
    {
        private readonly ICharacterRepository _characterRepository;

        public IndexModel(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public IEnumerable<Character> Characters { get; set; }

        public void OnGet()
        {
            PopulateCharactersIfNoneExist();

            Characters = _characterRepository.ListAll();
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
