namespace ContosoUniversity.Models.ViewModels
{
    public class CourseAssigned
    {
        public int CourseID { get; set; }
        public string Title { get; set; } = default!;
        public bool Assigned { get; set; }
    }
}
