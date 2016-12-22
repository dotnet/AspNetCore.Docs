using System.Collections.Generic;
using System.Linq;
using System;

namespace ContactManager.Models
{
    public class EntityContactManagerRepository : ContactManager.Models.IContactManagerRepository
    {
        private ContactManagerDBEntities _entities = new ContactManagerDBEntities();

        // Contact methods

        public Contact GetContact(int id)
        {
            return (from c in _entities.ContactSet.Include("Group")
                    where c.Id == id
                    select c).FirstOrDefault();
        }

        public Contact CreateContact(int groupId, Contact contactToCreate)
        {
            // Associate group with contact
            contactToCreate.Group = GetGroup(groupId);

            // Save new contact
            _entities.AddToContactSet(contactToCreate);
            _entities.SaveChanges();
            return contactToCreate;
        }

        public Contact EditContact(int groupId, Contact contactToEdit)
        {
            // Get original contact
            var originalContact = GetContact(contactToEdit.Id);
            
            // Update with new group
            originalContact.Group = GetGroup(groupId);
            
            // Save changes
            _entities.ApplyPropertyChanges(originalContact.EntityKey.EntitySetName, contactToEdit);
            _entities.SaveChanges();
            return contactToEdit;
        }

        public void DeleteContact(Contact contactToDelete)
        {
            var originalContact = GetContact(contactToDelete.Id);
            _entities.DeleteObject(originalContact);
            _entities.SaveChanges();
        }

        public Group CreateGroup(Group groupToCreate)
        {
            _entities.AddToGroupSet(groupToCreate);
            _entities.SaveChanges();
            return groupToCreate;
        }

        // Group Methods

        public IEnumerable<Group> ListGroups()
        {
            return _entities.GroupSet.ToList();
        }

        public Group GetFirstGroup()
        {
            return _entities.GroupSet.Include("Contacts").FirstOrDefault();
        }

        public Group GetGroup(int id)
        {
            return (from g in _entities.GroupSet.Include("Contacts")
                       where g.Id == id
                       select g).FirstOrDefault();
        }

        public void DeleteGroup(Group groupToDelete)
        {
            var originalGroup = GetGroup(groupToDelete.Id);
            _entities.DeleteObject(originalGroup);
            _entities.SaveChanges();

        }

    }
}