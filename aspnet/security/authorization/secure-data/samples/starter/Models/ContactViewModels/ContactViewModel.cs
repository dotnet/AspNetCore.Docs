using System.ComponentModel.DataAnnotations;

namespace ContactManager.Models.ContactViewModels
{
    public class ContactViewModel
    {
        public ContactViewModel( Contact contact) {
            ContactId = contact.ContactId;
            Name = contact.Name;
            Address = contact.Address;
            City = contact.City;
            State = contact.State;
            Zip = contact.Zip;
            Email = contact.Email;
        }
        public ContactViewModel() { }

        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
