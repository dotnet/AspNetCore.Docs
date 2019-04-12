using System;

namespace WebApiSample.DataAccess.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
