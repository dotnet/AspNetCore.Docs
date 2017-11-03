using System;

namespace ResourceBasedAuthApp.Models
{
    public class Document
    {
        public string Author { get; set; }

        public byte[] Content { get; set; }

        public Guid ID { get; set; }

        public string Title { get; set; }
    }
}
