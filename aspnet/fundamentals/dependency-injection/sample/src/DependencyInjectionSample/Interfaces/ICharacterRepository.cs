using System.Collections.Generic;
using DependencyInjectionSample.Models;

namespace DependencyInjectionSample.Interfaces
{
    public interface ICharacterRepository
    {
        IEnumerable<Character> ListAll();
        void Add(Character character);
    }
}