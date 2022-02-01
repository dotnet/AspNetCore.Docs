using System.Collections.Generic;

namespace JsonPatchSample.Models
{
    public class Customer
    {
        public string CustomerName { get; set; }
        public List<Order> Orders { get; set; }
    }
}
