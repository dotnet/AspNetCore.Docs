using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ModelBindingSample.Snippets;

// <snippet_Class>
public class InstructorBindRequired
{
    // ...

    [BindRequired]
    public DateTime HireDate { get; set; }
}
// </snippet_Class>
