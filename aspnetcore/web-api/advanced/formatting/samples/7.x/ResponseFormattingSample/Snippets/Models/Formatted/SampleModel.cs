using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ResponseFormattingSample.Snippets.Models.Formatted;

// <snippet_Class>
public class SampleModel
{
    [Range(1, 10)]
    [JsonPropertyName("sampleValue")]
    public int Value { get; set; }
}
// </snippet_Class>
