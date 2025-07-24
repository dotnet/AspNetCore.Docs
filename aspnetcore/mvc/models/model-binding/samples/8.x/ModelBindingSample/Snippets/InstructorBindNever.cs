using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ModelBindingSample.Snippets;

// <snippet_Class>
public class InstructorBindNever
{
    [BindNever]
    public int Id { get; set; }

    // ...
}
// </snippet_Class>
