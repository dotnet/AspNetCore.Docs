using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiSample.DataAccess.Models;

namespace WebApiSample.DataAccess.Repositories
{
    public class PetsRepository
    {
        private readonly PetContext _context;

        public PetsRepository(PetContext context)
        {
            _context = context;

            if (_context.Pets.Count() == 0)
            {
                _context.Pets.AddRange(
                    new Pet
                    {
                        Name = "Opie",
                        Breed = "Shih Tzu",
                        PetType = PetType.Dog
                    },
                    new Pet
                    {
                        Name = "Reggie",
                        Breed = "Beagle",
                        PetType = PetType.Dog
                    },
                    new Pet
                    {
                        Name = "Diesel",
                        Breed = "Bombay",
                        PetType = PetType.Cat
                    },
                    new Pet
                    {
                        Name = "Lucy",
                        Breed = "Maine Coon",
                        PetType = PetType.Cat
                    });
                _context.SaveChanges();
            }
        }

        public List<Pet> GetPets()
        {
            return _context.Pets.ToList();
        }

        public bool TryGetPet(int id, out Pet pet)
        {
            pet = _context.Pets.Find(id);

            return (pet != null);
        }

        public async Task<int> AddPetAsync(Pet pet)
        {
            int rowsAffected = 0;

            _context.Pets.Add(pet);
            rowsAffected = await _context.SaveChangesAsync();

            return rowsAffected;
        }
    }
}
