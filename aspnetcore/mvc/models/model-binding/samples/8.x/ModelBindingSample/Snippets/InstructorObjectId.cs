using System.ComponentModel.DataAnnotations;

namespace ModelBindingSample.Snippets;

// <snippet_Class>
public class InstructorObjectId
{
    [Required]
    public ObjectId ObjectId { get; set; } = null!;
}
// </snippet_Class>
