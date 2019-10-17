using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelBindingSample.Models
{
    public class OfficeAssignment
    {
        [Display(Name = "Office Location")]
        public string Location { get; set; }
    }
}