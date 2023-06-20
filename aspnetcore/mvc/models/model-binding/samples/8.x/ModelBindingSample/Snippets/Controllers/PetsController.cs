using Microsoft.AspNetCore.Mvc;

namespace ModelBindingSample.Snippets.Controllers;

[NonController]
public class PetsController : ControllerBase
{
    // <snippet_GetById>
    [HttpGet("{id}")]
    public ActionResult<Pet> GetById(int id, bool dogsOnly)
    // </snippet_GetById>
    {
        return NoContent();
    }

    // <snippet_Create>
    public ActionResult<Pet> Create([FromBody] Pet pet)
    // </snippet_Create>
    {
        return NoContent();
    }
}
