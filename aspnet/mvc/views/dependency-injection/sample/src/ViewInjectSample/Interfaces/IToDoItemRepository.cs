using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewInjectSample.Model;

namespace ViewInjectSample.Interfaces
{
    public interface IToDoItemRepository
    {
        IEnumerable<ToDoItem> List();
    }
}
