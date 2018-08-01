using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Pet>> GetPetsAsync()
        {
            return await _context.Pets.ToListAsync();
        }

        public async Task<Pet> GetPetAsync(int id)
        {
            return await _context.Pets.FindAsync(id);
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
