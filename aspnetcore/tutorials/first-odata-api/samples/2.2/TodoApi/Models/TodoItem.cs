using System.Runtime.Serialization;

namespace TodoApi.Models
{
    public class TodoItem
    {
        #region snippet
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
      
        public string Type { get; set; }
        public int priority { get; set; }
        public System.DateTime DueDate { get; set; }

        //[IgnoreDataMember]
        public string MySecret { get; set; }  // Not visible in the EDM
        #endregion
    }
}