using System.Collections.Generic;

namespace DependencyInjectionSample.Models
{
    public interface ICharacterRepository
    {
        IEnumerable<Character> ListAll();
        void Add(Character character);
    }
}