using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceBasedAuthApp1.Models
{
    public class Document
    {
        public string Author { get; set; }

        public byte[] Content { get; set; }

        public Guid ID { get; set; }

        public string Title { get; set; }
    }
}
