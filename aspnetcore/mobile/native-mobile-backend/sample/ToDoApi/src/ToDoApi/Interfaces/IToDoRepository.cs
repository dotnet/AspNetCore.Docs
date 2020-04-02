using System.Collections.Generic;
using ToDoApi.Models;

namespace ToDoApi.Interfaces {
    public interface IToDoRepository {
        List<ToDoItem> Get ();
        ToDoItem Get (string id);
        ToDoItem Create (ToDoItem item);
        void Update (ToDoItem itemIn);
        void Delete (ToDoItem itemIn);
        void Delete (string id);
        bool DoesItemExist (string id);
    }
}