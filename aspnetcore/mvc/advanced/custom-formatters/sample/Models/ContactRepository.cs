using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomFormatterDemo.Models
{
    public class ContactRepository : IContactRepository
    {
        private static ConcurrentDictionary<string, Contact> _contacts =
            new ConcurrentDictionary<string, Contact>();

        public ContactRepository()
        {
            Add(new Contact() { FirstName = "Nancy", LastName = "Davolio" });
        }

        public void Add(Contact contact)
        {
            contact.ID = Guid.NewGuid().ToString();
            _contacts[contact.ID] = contact;
        }

        public Contact Get(string id)
        {
            Contact contact;
            _contacts.TryGetValue(id, out contact);
            return contact;
        }

        public IEnumerable<Contact> GetAll()
        {
            return _contacts.Values;
        }

        public Contact Remove(string id)
        {
            Contact contact;
            _contacts.TryRemove(id, out contact);
            return contact;
        }

        public void Update(Contact contact)
        {
            _contacts[contact.ID] = contact;
        }
    }
}
