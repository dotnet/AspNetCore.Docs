using System.Collections.Generic;

namespace ContactManager.Models
{
    public interface IContactManagerRepository
    {
        // Contact methods
        Contact CreateContact(int groupId, Contact contactToCreate);
        void DeleteContact(Contact contactToDelete);
        Contact EditContact(int groupId, Contact contactToEdit);
        Contact GetContact(int id);

        // Group methods
        Group CreateGroup(Group groupToCreate);
        IEnumerable<Group> ListGroups();
        Group GetGroup(int groupId);
        Group GetFirstGroup();
        void DeleteGroup(Group groupToDelete);
    }
}