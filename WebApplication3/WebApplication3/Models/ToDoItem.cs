using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class ToDoItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
    public interface IWorkItemsService
    {
        IEnumerable<ToDoItem> GetAllToDoItems();
    }

    public class WorkItemsService : IWorkItemsService
    {
        IEnumerable<ToDoItem> _listOfItems = null;
        public WorkItemsService()
        {
            _listOfItems = new List<ToDoItem>
            {
            new ToDoItem { Id = 1, Name = "Item 1 Work",IsComplete=true}
            , new ToDoItem { Id = 2, Name = "Item 2 Work", IsComplete = false }
            , new ToDoItem { Id = 3, Name = "Item 3 Work", IsComplete = true }
            , new ToDoItem { Id = 4, Name = "Item 4 Work", IsComplete = false }
            , new ToDoItem { Id = 5, Name = "Item 5 Work", IsComplete = true }
            , new ToDoItem { Id = 6, Name = "Item 6 Work", IsComplete = false }
            };
        }

        public IEnumerable<ToDoItem> GetAllToDoItems()
        {
            return _listOfItems;
        }
    }
}
