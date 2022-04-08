using System.ComponentModel.DataAnnotations;

namespace ResponseFormattingSample.Snippets.Models;

// <snippet_Class>
public class SampleModel
{
    [Range(1, 10)]
    public int Value { get; set; }
}
// </snippet_Class>
