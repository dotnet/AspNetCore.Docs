namespace TodoApi.Models
{
    public class TodoItem
    {
        #region OldProps
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        #endregion

        #region  NewProps
        public string Type { get; set; }
        public int priority { get; set; }
        public System.DateTime DueDate { get; set; }
        #endregion
    }
}