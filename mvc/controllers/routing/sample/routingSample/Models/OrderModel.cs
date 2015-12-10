using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvcOrderManagerSample.Models
{
    public class OrderModel
    {
        public int OrderID { get; set; }
        public string Client { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
    }
}
