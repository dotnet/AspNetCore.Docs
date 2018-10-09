using System;
using System.ComponentModel.DataAnnotations;

namespace RepositoryPatternSample.Models
{
    #region snippet1
    public class Character
    {
        public Character(string name)
        {
            Name = name;
        }

        [Key]
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; } = String.Empty;
    }
    #endregion
}
