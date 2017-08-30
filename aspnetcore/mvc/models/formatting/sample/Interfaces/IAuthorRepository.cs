using System.Collections.Generic;
using ResponseFormattingSample.Model;

namespace ResponseFormattingSample.Interfaces
{
    public interface IAuthorRepository
    {
        List<Author> List();
        Author GetByAlias(string twitterAlias);
        List<Author> GetByNameSubstring(string nameSubstring);
    }
}
