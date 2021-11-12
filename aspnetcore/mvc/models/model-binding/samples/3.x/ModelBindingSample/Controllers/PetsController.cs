using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSample.DataAccess.Models;

namespace WebApiSample.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private static List<Pet> _petsInMemoryStore = new List<Pet>();

        public PetsController()
        {
            if (_petsInMemoryStore.Count == 0)
            {
                _petsInMemoryStore.Add(new Pet { Breed = "Collie", Id = 1, Name = "Fido", PetType = PetType.Dog });
            }
        }

        [HttpGet]
        public ActionResult<List<Pet>> GetAll()
        {
            return _petsInMemoryStore;
        }

        // <snippet_DogsOnly>
        [HttpGet("{id}")]
        public ActionResult<Pet> GetById(int id, bool dogsOnly)
        // </snippet_DogsOnly>
        {
            var pet = _petsInMemoryStore.FirstOrDefault(
                p => p.Id == id &&
                (!dogsOnly || p.PetType == PetType.Dog));

            if (pet == null)
            {
                return NotFound();
            }

            return pet;
        }

        #region snippet_400And201
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Pet> Create(Pet pet)
        {
            pet.Id = _petsInMemoryStore.Any() ? _petsInMemoryStore.Max(p => p.Id) + 1 : 1;
            _petsInMemoryStore.Add(pet);

            return CreatedAtAction(nameof(GetById),
                new { id = pet.Id }, pet);
        }
        #endregion
    }
}
