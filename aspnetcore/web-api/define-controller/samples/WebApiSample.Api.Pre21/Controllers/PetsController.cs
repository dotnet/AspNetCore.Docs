using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiSample.DataAccess.Models;
using WebApiSample.DataAccess.Repositories;

namespace WebApiSample.Api.Controllers
{
    #region snippet_PetsController
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly PetsRepository _repository;

        public PetsController(PetsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Pet>), 200)]
        public IActionResult Get()
        {
            return Ok(_repository.GetPets());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Pet), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetById(int id)
        {
            if (!_repository.TryGetPet(id, out var pet))
            {
                return NotFound();
            }

            return Ok(pet);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Pet), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateAsync([FromBody] Pet pet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repository.AddPetAsync(pet);

            return CreatedAtAction(nameof(GetById),
                new { id = pet.Id }, pet);
        }
    }
    #endregion
}