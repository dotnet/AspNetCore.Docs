using System;
using System.Collections.Generic;

namespace PartialViewsSample.ViewModels
{
    public class Article
    {
        public string AuthorName { get; set; }

        public DateTime PublicationDate { get; set; } = DateTime.Today;

        public string Title { get; set; }

        public List<ArticleSection> Sections { get; } = new List<ArticleSection>();
    }
}
