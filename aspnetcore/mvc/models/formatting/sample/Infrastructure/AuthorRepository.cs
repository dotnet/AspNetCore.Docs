using System;
using System.Collections.Generic;
using System.Linq;
using ResponseFormattingSample.Interfaces;
using ResponseFormattingSample.Model;

namespace ResponseFormattingSample.Infrastructure
{
    public class AuthorRepository : IAuthorRepository
    {
        public List<Author> List()
        {
            return new List<Author>
            {
                new Author {Name="Steve Smith", Twitter="ardalis"},
                new Author {Name="Rick Anderson", Twitter="RickAndMSFT"},
                new Author {Name="Rachel Appel", Twitter="rachelappel"},
                new Author {Name="Daniel Roth", Twitter="danroth27"}
            }
            .OrderBy(a => a.Name).ToList();
        }

        public Author GetByAlias(string twitterAlias)
        {
            string loweredAlias = twitterAlias.ToLowerInvariant();
            return List()
                .FirstOrDefault(a => a.Twitter.ToLowerInvariant() == loweredAlias);
        }

        public List<Author> GetByNameSubstring(string nameSubstring)
        {
            return List()
                .Where(a => 
                    a.Name.IndexOf(nameSubstring, 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                        .ToList();
        }
    }
}
