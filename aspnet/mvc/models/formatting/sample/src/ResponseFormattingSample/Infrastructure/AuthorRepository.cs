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
            return new List<Author>()
            {
                new Author() {Name = "Steve Smith", Twitter = "ardalis"},
                new Author() {Name="Rick Anderson", Twitter = "RickAndMSFT"}
            };
        }

        public Author GetByAlias(string twitterAlias)
        {
            string loweredAlias = twitterAlias.ToLowerInvariant();
            return List().FirstOrDefault(a => a.Twitter.ToLowerInvariant() == loweredAlias);
        }
    }
}