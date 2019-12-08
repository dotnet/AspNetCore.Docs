using System.ComponentModel.DataAnnotations;

namespace ModelBindingSample.Models
{
    public class OfficeAssignment
    {
        [Display(Name = "Office Location")]
        public string Location { get; set; }
    }
}
