using System.Collections.Generic;
using RepositoryPatternSample.Models;

namespace RepositoryPatternSample.Interfaces
{
    #region snippet1
    public interface ICharacterRepository
    {
        IEnumerable<Character> ListAll();
        void Add(Character character);
    }
    #endregion
}
