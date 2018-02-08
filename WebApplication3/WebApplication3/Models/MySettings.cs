using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public static class MySettings
    {
        public static IEnumerable<ToDoItem> GetList ()
        { 
            return new List<ToDoItem>
            {
            new ToDoItem { Id = 1, Name = "Item 1 Work",IsComplete=true}
            , new ToDoItem { Id = 2, Name = "Item 2 Work", IsComplete = false }
            , new ToDoItem { Id = 3, Name = "Item 3 Work", IsComplete = true }
            , new ToDoItem { Id = 4, Name = "Item 4 Work", IsComplete = false }
            , new ToDoItem { Id = 5, Name = "Item 5 Work", IsComplete = true }
            , new ToDoItem { Id = 6, Name = "Item 6 Work", IsComplete = false }
            };
        }
    }
}
