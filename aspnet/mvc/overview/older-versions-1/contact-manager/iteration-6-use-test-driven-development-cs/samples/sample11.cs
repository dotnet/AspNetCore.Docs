using System;
using System.Collections.Generic;
using ContactManager.Models;

namespace ContactManager.Tests.Models
{
    public class FakeContactManagerRepository : IContactManagerRepository
    {
        private IList<Group> _groups = new List<Group>(); 
        
        #region IContactManagerRepository Members

        // Group methods

        public Group CreateGroup(Group groupToCreate)
        {
            _groups.Add(groupToCreate);
            return groupToCreate;
        }

        public IEnumerable<Group> ListGroups()
        {
            return _groups;
        }

        // Contact methods
        
        public Contact CreateContact(Contact contactToCreate)
        {
            throw new NotImplementedException();
        }

        public void DeleteContact(Contact contactToDelete)
        {
            throw new NotImplementedException();
        }

        public Contact EditContact(Contact contactToEdit)
        {
            throw new NotImplementedException();
        }

        public Contact GetContact(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contact> ListContacts()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}