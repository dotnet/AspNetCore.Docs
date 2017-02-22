using System;
using System.Collections.Generic;

namespace ContactManager.Models
{
    public interface IContactRepository
    {
        Contact CreateContact(Contact contactToCreate);
        void DeleteContact(Contact contactToDelete);
        Contact EditContact(Contact contactToUpdate);
        Contact GetContact(int id);
        IEnumerable<Contact> ListContacts();

    }
}