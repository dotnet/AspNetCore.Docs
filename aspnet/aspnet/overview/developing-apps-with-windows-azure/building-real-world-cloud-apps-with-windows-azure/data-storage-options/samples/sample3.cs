public class FixItTask
{
    public int FixItTaskId  { get; set; }
    public string CreatedBy { get; set; }
    [Required]
    public string Owner     { get; set; }
    [Required]
    public string Title     { get; set; }
    public string Notes     { get; set; }
    public string PhotoUrl  { get; set; }
    public bool IsDone      { get; set; } 
}