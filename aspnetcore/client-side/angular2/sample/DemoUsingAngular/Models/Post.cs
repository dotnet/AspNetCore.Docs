using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoUsingAngular.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Author { get; set; }
        public int BlogId { get; set; }
    }
}
