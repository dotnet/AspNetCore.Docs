namespace WebApiSample.DataAccess.Models
{
    public class Pet
    {
        public int Id { get; set; }

        public string Breed { get; set; }
        public string Name { get; set; }

        public PetType PetType { get; set; }
    }

    public enum PetType
    {
        Dog = 0,
        Cat = 1
    }
}
