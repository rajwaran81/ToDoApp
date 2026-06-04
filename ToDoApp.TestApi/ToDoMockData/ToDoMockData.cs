using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.TestApi.ToDoMockData
{
    public class ToDoMockData
    {
        public static List<Models.ToDo> GetToDos()
        {
            return new List<Models.ToDo>
            {
                new Models.ToDo
                {
                    Id = 1,
                    ItemName = "Buy groceries",
                    IsCompleted = false
                },
                new Models.ToDo
                {
                    Id = 2,
                    ItemName = "Finish project report",
                    IsCompleted = false
                },
                new Models.ToDo
                {
                    Id = 3,
                    ItemName = "Call plumber",
                    IsCompleted = true                }
            };
        }

        public static List<Models.ToDo> GetEmptyToDos()
        {
            return new List<Models.ToDo>();
        }

        public static Models.ToDo NewToDo()
        {
            return new Models.ToDo
            {
                Id = 0,
                ItemName = "Buy groceries",
                IsCompleted = false
            };
        }
    }
}
