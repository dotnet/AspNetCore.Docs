using System.Runtime.Serialization;

namespace TodoApi.Models
{
    #region snippet
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }

        // Requires using System.Runtime.Serialization;
        [IgnoreDataMember]
        public decimal Salary { get; set; }
    }
    #endregion
}
