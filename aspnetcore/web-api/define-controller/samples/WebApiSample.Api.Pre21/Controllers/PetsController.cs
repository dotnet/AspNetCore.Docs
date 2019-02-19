using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [ProducesResponseType(typeof(IEnumerable<Pet>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            var pets = await _repository.GetPetsAsync();

            return Ok(pets);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Pet), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var pet = await _repository.GetPetAsync(id);

            if (pet == null)
            {
                return NotFound();
            }

            return Ok(pet);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Pet), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody] Pet pet)
        {
            #region snippet_ModelStateIsValidCheck
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            #endregion

            await _repository.AddPetAsync(pet);

            return CreatedAtAction(nameof(GetByIdAsync),
                new { id = pet.Id }, pet);
        }
    }
    #endregion
}