public class TriviaQuestion
{
     public int Id { get; set; }

     [Required]
     public string Title { get; set; }

     public virtual List<TriviaOption> Options { get; set; }

     public string Hint { get; set; }
}