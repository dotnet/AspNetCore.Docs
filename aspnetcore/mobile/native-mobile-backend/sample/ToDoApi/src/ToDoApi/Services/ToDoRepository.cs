using System.Collections.Generic;
using System.Linq;
using ToDoApi.Interfaces;
using ToDoApi.Models;

namespace ToDoApi.Services {
    public class ToDoRepository : IToDoRepository {
        private List<ToDoItem> _toDoList;

        public ToDoRepository () {
            InitializeData ();
        }

        public List<ToDoItem> Get () => _toDoList;

        public ToDoItem Get (string id) =>
            _toDoList.FirstOrDefault (item => item.Id == id);

        public ToDoItem Create (ToDoItem item) {
            _toDoList.Add (item);
            return item;
        }

        public void Update (ToDoItem item) {
            var todoItem = this.Get (item.Id);
            var index = _toDoList.IndexOf (todoItem);
            _toDoList.RemoveAt (index);
            _toDoList.Insert (index, item);
        }

        public void Delete (string id) {
            _toDoList.Remove (this.Get (id));
        }

        public void Delete (ToDoItem item) {
            _toDoList.Remove (this.Get (item.Id));
        }

        public bool DoesItemExist (string id) {
            return _toDoList.Any (item => item.Id == id);
        }

        private void InitializeData () {
            _toDoList = new List<ToDoItem> ();

            var todoItem1 = new ToDoItem {
                Id = "6bb8a868-dba1-4f1a-93b7-24ebce87e243",
                Name = "Learn app development",
                Notes = "Attend Xamarin University",
                Done = true
            };

            var todoItem2 = new ToDoItem {
                Id = "b94afb54-a1cb-4313-8af3-b7511551b33b",
                Name = "Develop apps",
                Notes = "Use Xamarin Studio/Visual Studio",
                Done = false
            };

            var todoItem3 = new ToDoItem {
                Id = "ecfa6f80-3671-4911-aabe-63cc442c1ecf",
                Name = "Publish apps",
                Notes = "All app stores",
                Done = false,
            };

            _toDoList.Add (todoItem1);
            _toDoList.Add (todoItem2);
            _toDoList.Add (todoItem3);
        }
    }
}